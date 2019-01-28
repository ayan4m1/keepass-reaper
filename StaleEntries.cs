using KeePass.Forms;
using KeePass.UI;
using KeePassLib;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KeeReaper
{
    public partial class StaleEntries : Form
    {
        public PwDatabase Database;

        private Assembly thisAssembly = Assembly.GetEntryAssembly();

        public StaleEntries()
        {
            InitializeComponent();

            EntriesList.ListViewItemSorter = Comparer<ListViewItem>.Create((x, y) => {
                var xEntry = x.Tag as StaleEntry;
                var yEntry = y.Tag as StaleEntry;

                return xEntry.AgeDays.CompareTo(yEntry.AgeDays);
            });
        }

        public void AddEntry(StaleEntry entry)
        {
            EntriesList.Items.Add(entry.ToListViewItem());
        }

        public void AddEntries(List<StaleEntry> entries)
        {
            entries.ForEach(AddEntry);
        }

        private ImageList GetImageList()
        {
            var result = new ImageList();
            var (cx, cy) = (DpiUtil.ScaleIntX(16), DpiUtil.ScaleIntY(16));
            var iconStream = thisAssembly.GetManifestResourceStream("B15x14_FileNew");
            var bitmap = Image.FromStream(iconStream);

            result.Images.Add(bitmap);

            return result;
        }

        private void EntriesList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            EntriesList.Sorting = (EntriesList.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            EntriesList.Sort();
        }

        private void EntriesList_DoubleClick(object rawSender, System.EventArgs e)
        {
            var sender = rawSender as ListView;
            var staleEntry = sender.SelectedItems[0].Tag as StaleEntry;
            var pwEntry = staleEntry.BackingEntry;
            using (var form = new PwEntryForm())
            {
                form.InitEx(pwEntry, PwEditMode.ViewReadOnlyEntry, Database, GetImageList(), false, false);
                UIUtil.ShowDialogAndDestroy(form);
            }
        }
    }
}
