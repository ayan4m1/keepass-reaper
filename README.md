# KeePass Reaper

This plugin shows you the age of your credentials. It adds an item to the Tools menu called "Show stale entries," which brings up a small dialog that shows all credentials that are either older than (i.e. last modified before) the configurable cutoff date _or_ explicitly expired based on the KeePass entry's expiration date.

*NOTE* This plugin only supports KeePass 2.x.

## Installation

Follow the [generic instructions](https://keepass.info/help/v2/plugins.html) for plugin installation. Basically, place the DLL in your KeePass Plugins directory.

## Usage

Goto Tools > Show stale entries... You should see a dialog like the following:

![stale entries dialog](https://i.imgur.com/Lmz7WE1.png)

If an entry has a value in the built-in KeePass URL field, you can double-click the stale entry to open the URL using the default shell handler.

You can adjust the cutoff date after which results will be displayed. Clicking "Dismiss" or pressing Escape will close the dialog.

If an entry is _expired_ using the KeePass built-in expiration feature, it will appear in red.

If you have more than ten thousand credentials, the cutoff date refresh may be slow.
