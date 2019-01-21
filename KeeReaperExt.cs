using KeePassLib;
using KeePass.Forms;
using KeePass.Plugins;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeeReaper
{
    public class KeeReaperExt : Plugin
    {
        private IPluginHost host = null;

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

        private void MainWindow_FileOpened(object sender, FileOpenedEventArgs e)
        {
            var expired = WalkInvalid(e.Database.RootGroup, new List<string>());

            if (expired.Count > 0)
            {
                MessageBox.Show("Some passwords need to be rotated.");
            }
        }

        private List<string> WalkInvalid(PwGroup root, List<string> invalid)
        {
            foreach (var entry in root.Entries)
            {
                // todo: determine if entry should be rotated
            }

            foreach (var group in root.Groups)
            {
                WalkInvalid(group, invalid);
            }

            return invalid;
        }
    }
}
