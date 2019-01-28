using KeePass.Forms;
using KeePass.Plugins;
using KeePassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeeReaper
{
    public class KeeReaperExt : Plugin
    {
        private const int cutoffDays = 90;
        private IPluginHost host = null;
        private PwDatabase currentDatabase = null;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
            {
                return false;
            }

            this.host = host;
            host.MainWindow.FileOpened += MainWindow_FileOpened;
            return true;
        }

        public override void Terminate()
        {
            host.MainWindow.FileOpened -= MainWindow_FileOpened;
            host = null;
        }

        public override ToolStripMenuItem GetMenuItem(PluginMenuType type)
        {
            switch (type)
            {
                case PluginMenuType.Main:
                    var checkStaleItem = new ToolStripMenuItem("Show stale entries...");
                    checkStaleItem.Click += CheckStaleItem_Click;
                    return checkStaleItem;
            }

            return null;
        }

        private void MainWindow_FileOpened(object sender, FileOpenedEventArgs e)
        {
            currentDatabase = e.Database;
        }

        private void CheckStaleItem_Click(object sender, EventArgs e)
        {
            PerformCheck();
        }

        private void PerformCheck()
        {
            var expired = WalkEntries(currentDatabase.RootGroup, new List<StaleEntry>());

            if (expired.Count == 0)
            {
                return;
            }

            using (var dialog = new StaleEntries()
            {
                Database = host.MainWindow.ActiveDatabase
            })
            {
                dialog.AddEntries(expired);
                dialog.ShowDialog();
            }
        }

        private List<StaleEntry> WalkEntries(PwGroup root, List<StaleEntry> entries)
        {
            var today = DateTime.Now;
            var cutoff = today.AddDays(-cutoffDays);
            entries.AddRange(root
                .Entries
                .Where(entry => entry.LastModificationTime <= cutoff)
                .Select(StaleEntry.FromPwEntry)
            );

            foreach (var group in root.Groups)
            {
                if (group.IsVirtual || !group.Entries.Any() || group.Name == "Recycle Bin")
                {
                    continue;
                }

                WalkEntries(group, entries);
            }

            return entries;
        }
    }
}
