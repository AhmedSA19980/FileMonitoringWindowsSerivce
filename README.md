# FileMonitoringWindowsSerivce
this project is to design, develop, and deploy a Windows Service that monitors a specific folder for new files, processes them by renaming with a GUID, moves them to a destination folder, and deletes the original file.



1. Core Functionalities
Folder Monitoring:
Monitor a source folder for new files.
Automatically detect any file added to the folder.
File Processing:
Rename each detected file using a GUID (Globally Unique Identifier).
Move the renamed file to a destination folder.
File Cleanup:
Ensure the file is deleted from the source folder after successful movement.
