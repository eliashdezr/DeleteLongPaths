# DeleteLongPaths
Delete files and folders that are located in long paths in Windows. 

The reason I made this little tool is because it was a pain trying to get rid of folders on node projects that have the **node_modules** nesting issue.

Internally, this uses Windows Powershell, so you might needed before running this tool. If you want to running directly in your Powershell console, use the following commands.

```
mkdir temp; 
robocopy .\temp .\folder_to_delete /s /mir > null;
rmdir .\folder_to_delete -Recurse -Force; 
rmdir temp;
rm null;
```

# Compability
Works on Windows 7 and 8.1. Haven't tested in Windows XP or 10, but it should work if PowerShell and .NET Framework 4.5 are installed. 

The reason why I'm using .NET 4.5 is because of the async/wait pattern.

# Copyrights
The icon used in the application is a work from [GuillenDesign](http://www.iconarchive.com/show/variations-1-icons-by-guillendesign/Trash-full-2-icon.html)
