using KeePassLib;
using System;
using System.Windows.Forms;

namespace KeeReaper
{
    /// <summary>
    /// PwEntry > StaleEntry > ListViewItem
    /// ListViewItem.Tag -> StaleEntry
    /// StaleEntry.BackingEntry -> PwEntry
    /// </summary>
    public class StaleEntry
    {
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string URL { get; private set; }
        public DateTime LastChanged { get; private set; }
        public PwEntry BackingEntry { get; private set; }

        public int AgeDays => (int)Math.Ceiling((DateTime.Now - LastChanged).TotalDays);

        public static StaleEntry FromPwEntry(PwEntry entry) => new StaleEntry()
        {
            Name = ReadString(entry, PwDefs.TitleField),
            Username = ReadString(entry, PwDefs.UserNameField),
            LastChanged = entry.LastModificationTime,
            URL = ReadString(entry, PwDefs.UrlField),
            BackingEntry = entry
        };

        private static string ReadString(PwEntry entry, string field) => entry.Strings.GetSafe(field).ReadString();
    }

    public static class StaleEntryExtensions
    {
        public static ListViewItem ToListViewItem(this StaleEntry entry)
        {
            var result = new ListViewItem(entry.Name);

            result.SubItems.Add(entry.Username);
            result.SubItems.Add(entry.LastChanged.ToString("yyyy-MM-dd"));
            result.SubItems.Add(entry.AgeDays.ToString());
            result.Tag = entry;

            return result;
        }
    }
}
