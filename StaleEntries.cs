using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using KeePassLib;

namespace KeeReaper
{
    public partial class StaleEntries : Form
    {
        public PwDatabase Database;

        private const int DefaultCutoffDays = 90;
        private readonly ListView _hiddenEntriesList = new ListView();

        private int CurrentCutoffDays => (int)CutoffDays.Value;

        public StaleEntries()
        {
            InitializeComponent();

            CutoffDays.Value = DefaultCutoffDays;

            EntriesList.ListViewItemSorter = Comparer<ListViewItem>.Create((x, y) => {
                var xEntry = x.Tag as StaleEntry;
                var yEntry = y.Tag as StaleEntry;

                return xEntry?.AgeDays.CompareTo(yEntry?.AgeDays) ?? 0;
            });
        }

        public void AddEntry(StaleEntry entry)
        {
            var listItem = entry.ToListViewItem();

            if (entry.AgeDays >= CurrentCutoffDays || entry.Expired)
            {
                EntriesList.Items.Add(listItem);
            }
            else
            {
                _hiddenEntriesList.Items.Add(listItem);
            }
        }

        public void AddEntries(List<StaleEntry> entries)
        {
            entries.ForEach(AddEntry);
        }

        private void EntriesList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            EntriesList.Sorting = (EntriesList.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            EntriesList.Sort();
        }

        private void EntriesList_DoubleClick(object rawSender, EventArgs e)
        {
            var sender = rawSender as ListView;
            var staleEntry = sender?.SelectedItems[0].Tag as StaleEntry;
            var pwEntry = staleEntry?.BackingEntry;

            if (pwEntry == null)
            {
                return;
            }

            var url = pwEntry?.Strings.ReadSafe(PwDefs.UrlField);

            if (url == null || string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("No URL to open!", "Open failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void CutoffDays_ValueChanged(object sender, EventArgs e)
        {
            var toShow = new List<ListViewItem>();
            var toHide = new List<ListViewItem>();

            foreach (var rawItem in EntriesList.Items)
            {
                var item = rawItem as ListViewItem;
                var entry = item?.Tag as StaleEntry;
                if (entry?.AgeDays <= CurrentCutoffDays && !entry.Expired)
                {
                    toHide.Add(item);
                    EntriesList.Items.Remove(item);
                }
            }

            foreach (var rawItem in _hiddenEntriesList.Items)
            {
                var item = rawItem as ListViewItem;
                var entry = item?.Tag as StaleEntry;
                if (entry?.AgeDays > CurrentCutoffDays)
                {
                    toShow.Add(item);
                    _hiddenEntriesList.Items.Remove(item);
                }
            }

            EntriesList.Items.AddRange(toShow.ToArray());
            _hiddenEntriesList.Items.AddRange(toHide.ToArray());
        }
    }
}
