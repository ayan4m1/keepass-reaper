using System;
using System.Drawing;
using System.Windows.Forms;
using KeePassLib;

namespace KeeReaper
{
    /// <summary>
    /// PwEntry > StaleEntry > ListViewItem
    /// ListViewItem.Tag -> StaleEntry
    /// StaleEntry.BackingEntry -> PwEntry
    /// </summary>
    public class StaleEntry
    {
        public string Path { get; private set; }
        public string Username { get; private set; }
        public string Url { get; private set; }
        public DateTime LastChanged { get; private set; }
        public DateTime? Expires { get; private set; }
        public PwEntry BackingEntry { get; private set; }

        public int AgeDays => (int)Math.Ceiling((DateTime.Now - LastChanged).TotalDays);
        public bool Expired => Expires.HasValue && DateTime.Today.CompareTo(Expires) > 0;

        public static StaleEntry FromPwEntry(PwEntry entry) => new StaleEntry
        {
            Path = GetPath(entry),
            Username = ReadString(entry, PwDefs.UserNameField),
            LastChanged = entry.LastModificationTime,
            Expires = entry.Expires ? entry.ExpiryTime : new DateTime?(),
            Url = ReadString(entry, PwDefs.UrlField),
            BackingEntry = entry
        };

        private static string GetPath(PwEntry entry)
        {
            var title = ReadString(entry, PwDefs.TitleField);
            var parentGroup = entry.ParentGroup;

            if (parentGroup == null)
            {
                return title;
            }

            var path = parentGroup.GetFullPath(" > ", false);
            return string.IsNullOrWhiteSpace(title) ? path : $"{path} > {title}";
        }

        private static string ReadString(PwEntry entry, string field) => entry.Strings.GetSafe(field).ReadString();
    }

    public static class StaleEntryExtensions
    {
        public static ListViewItem ToListViewItem(this StaleEntry entry)
        {
            var result = new ListViewItem(entry.Path);

            result.SubItems.Add(entry.Username);
            var ageDays = entry.AgeDays.ToString();
            result.SubItems.Add($"{ageDays} days");
            result.Tag = entry;

            if (entry.Expired)
            {
                result.BackColor = Color.DarkRed;
                result.ForeColor = Color.White;
            }

            return result;
        }
    }
}
