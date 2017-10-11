# PDFEditorPluginSample
A sample on how to create a simple plugin for the End-User Editor

## Sample Structure
There are two projects in this sample - PluginSample and PluginCOMWrapper.

The **PluginCOMWrapper** is used to create the pvp file with the PXCE_GetPlugin method available. 
This method basically creates an IPXV_Plugin interface and gives it to the End-User Editor.
The wrapper itself is crutial for the .Net and C++ communication.

The **PluginSample** is the plugin itself.
The most important methods are Setup (where are you getting the IPXV_Inst) and Unload (where you should clear all of the objects used).
For more information see this link:
[IPXV_Plugin](http://sdkhelp.tracker-software.com/view/PXV:IPXV_Plugin)

## To start, you will have to do these steps:
0. If needed install the UnmanagedExports by Robert Giesecke nuget packet for the Solution.
1. Add a refference to the PDFXEditCore.xXX.dll to both the PluginCOMWrapper and PluginSample project.
2. In the Solution Items\PXEPlugin.props file you should give the correct PDFOutputDir to the End-User Editor's directory.
3. In the PluginCOMWrapper\PluginCOMWrapper.csproj.user change the EditorPath to the End-User Editor's exe file path.
4. Unload and Reload the PluginCOMWrapper project to update the project.
5. Build the PluginCOMWrapper project. Note that you should choose the x86 or x64 version not the AnyCPU option.
6. If everything is successful, the PDFXChange Editor should launch.
7. Press Ctrl+K (Preferences) and check the Plugins tab to see whether your plugin is there.
