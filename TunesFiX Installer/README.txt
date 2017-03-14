SwiftMiX Windows MSI Installer Project:

DetectNewerInstalledVersions=FALSE
RemovePreviousVersions=FALSE

When you re-run the same .msi that's already installed we get nice prompt to repair or uninstall... OK!

To update to a new version, change Version (say from 1.73.0 to 1.74.0) AND when it prompts to change the product code select YES.
The compiled version will install over the previous version.

SignInstaller.bat, run twice, first to sign (with all timestamping "rem" commented-out) then with sign commented out and the timestamp server uncommented.