TunesFiX C# is authored by Scott Swift. v1.88 released under GPL v3 14-March-2017.

Built with Microsoft Visual Studio, Community 2017.

Unzip the files in the x86Dlls and Resourses folders.

From Scott Swift's mediatag-sharp GitHub repository:
  MediaTags.dll, TaglibSharp.dll, WinMediaLib.dll

From MsgBoxCheck:
  MsgBoxCheck.dll, cbtHook.dll, WindowsHook.dll  

You may also need to add a reference to IWshRuntimeLibrary:
This can be found under COM Objects "Scripthost Object Model"

Important! If you are building the installer, you must set the target to "Release" and "x86"!

To build, first right-click the "TunesFiX" project and choose "Rebuild" then right-click the "TunesFiX Installer" project and choose "Rebuild". The TunesFiX.msi Windows installer will be in "TunesFiX Installer\Release"

Questions? Contact author: dxzl@live.com
