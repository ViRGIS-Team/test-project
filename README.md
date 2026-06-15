# GDAL, MDAL, PDAL Unity Test Project

This is a small project that is used to test build the following, related UPM packages:

- GDAL [![openupm](https://img.shields.io/npm/v/com.virgis.gdal?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.virgis.gdal/) [GitHub](https://github.com/ViRGIS-Team/gdal-upm)
- PDAL [![openupm](https://img.shields.io/npm/v/com.virgis.pdal?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.virgis.pdal/) [GitHub](https://github.com/ViRGIS-Team/pdal-upm)
- MDAL [![openupm](https://img.shields.io/npm/v/com.virgis.mdal?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.virgis.mdal/) [GitHub](https://github.com/ViRGIS-Team/mdal-upm)

The project tests that the package loads the plugin correctly and the plugin can be called successfully. If you can see coloured artifacts on the screen, then the application is working but you really need to check the Player Log to know that it all worked.

# Platform Support

To down dopwnload the binaries for all built platforms - see the latest Github Release

## Fully Working and Building using IL2CPP

### Windows

### OSX-64

### OSX-ARM

### Linux
NOTE : The linux binaries only work if the LD_LIBRARY_PATH is set to point to the `test-project-linux-64_Data/Plugins/x86_64` folder. Otherwise, the native plugins will not be found.

## Building on Cloud but the client not tested yet

### UWP

## Not Working




