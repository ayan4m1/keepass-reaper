using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KeePass.Forms;
using KeePass.Plugins;
using KeePassLib;

namespace KeeReaper
{
    public class KeeReaperExt : Plugin
    {
        private IPluginHost _host;
        private PwDatabase _currentDatabase;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
            {
                return false;
            }

            _host = host;
            host.MainWindow.FileOpened += MainWindow_FileOpened;
            return true;
        }

        public override void Terminate()
        {
            _host.MainWindow.FileOpened -= MainWindow_FileOpened;
            _host = null;
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
            _currentDatabase = e.Database;
        }

        private void CheckStaleItem_Click(object sender, EventArgs e)
        {
            PerformCheck();
        }

        private void PerformCheck()
        {
            var expired = WalkEntries(_currentDatabase.RootGroup, new List<StaleEntry>());

            if (expired.Count == 0)
            {
                return;
            }

            using (var dialog = new StaleEntries
            {
                Database = _host.MainWindow.ActiveDatabase
            })
            {
                dialog.AddEntries(expired);
                dialog.ShowDialog();
            }
        }

        private static List<StaleEntry> WalkEntries(PwGroup root, List<StaleEntry> entries)
        {
            entries.AddRange(root.Entries.Select(StaleEntry.FromPwEntry));

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
