# FileMonitoringWindowsSerivce
this project is to design, develop, and deploy a Windows Service that monitors a specific folder for new files, processes them by renaming with a GUID, moves them to a destination folder, and deletes the original file.


The system implements file-based logging to track all critical operations and ensure traceability during runtime. Each log entry is recorded with a timestamp to help with debugging and monitoring service behavior.

The logging mechanism captures the following events:

Service lifecycle events: Logs when the service starts and stops.

File processing events: Records detection of new files, including their full source and destination paths.

File operations: Logs successful file movements and renaming actions.

Error handling: Captures and logs any errors encountered during file movement or renaming, along with relevant details.


1. Core Functionalities

### Folder Monitoring:
Monitor a source folder for new files.
Automatically detect any file added to the folder.
### File Processing:
Rename each detected file using a GUID (Globally Unique Identifier).
Move the renamed file to a destination folder.
### File Cleanup:
Ensure the file is deleted from the source folder after successful movement.


## Example Configurations:

```
<appSettings>
    <add key="SourceFolder" value="C:\FileMonitoring\Source" />
    <add key="DestinationFolder" value="C:\FileMonitoring\Destination" />
    <add key="LogFolder" value="C:\FileMonitoring\Logs" />
</appSettings>

```
