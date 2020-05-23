[![Build status](https://ci.appveyor.com/api/projects/status/x9n4h3b72cxj845t?svg=true)](https://ci.appveyor.com/project/dampee/imageprocessor-plugins-pdf)
[![NuGet release](https://img.shields.io/nuget/v/ImageProcessor.Plugins.Pdf.svg)](https://www.nuget.org/packages/ImageProcessor.Plugins.Pdf/)

# Pdf fileformat for ImageProcessor

This is a plugin for ImageProcessorThis project is a plugin for [ImageProcessor](http://imageprocessor.org/). 
*It adds PDF as a supported file format*.  This gives you the ability to preview the first page of a PDF file on your web page.

## Installation using Nuget

    Install-Package ImageProcessor.Plugins.PDF

## GhostScript
We use [GhostScript.Net](https://github.com/jhabjan/Ghostscript.NET) as a managed wrapper for [GhostScript](https://ghostscript.com/).  
The good thing is, you don't need to install ghostscript on your machine.
You can just copy (one or both) `gsdll32.dll` and `gsdll64.dll` in the /bin directory. 
**These files are not provided in this packages and must be added manually.**

I read that Ghostscript does not handle requests from multiple processes.  
When running on a webserver, be sure to run the website in his own applicationpool.

## Configuration
Just add `/myfile.pdf?format=jpg&width=500` to get the first page as an image.

## running locally on IIS express
If you run locally, and you have the 64 bit version of ghostscript installed, 
don't forget to [activate 64 bit of IIS express](https://visualstudio.uservoice.com/forums/121579-visual-studio-ide/suggestions/3254745-allow-for-iis-express-64-bit-to-run-from-visual-st).  


