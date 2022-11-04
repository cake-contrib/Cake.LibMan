# Cake.LibMan

Cake.LibMan is an Addin that extends [Cake](http://cakebuild.net/) for executing commands with the  (Library Manager) command line interface (cli).
In order to use this extension, the [LibMan CLI](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli?#installation) will already have to be installed on the computer the cake build script is being executed on.

[![License](http://img.shields.io/:license-mit-blue.svg)](http://cake-contrib.mit-license.org)

## Table of Cnontents

- [Install](#install)
- [Usage](#usage)
- [Information](#information)
- [Build Status](#build-status)
- [Code Coverage](#code-coverage)
- [Quick Links](#quick-links)
- [Discussion](#discussion)

## Install

```cs
#addin nuget:?package=Cake.LibMan&version={Version}
```

## Usage

```cs
#addin nuget:?package=Cake.LibMan&version={Version}
// Add Libary Manager as global tool
#tool dotnet:?package=Microsoft.Web.LibraryManager.Cli&version={version}&global

Task("Restore-LibMan")
.Does(() => {
    var settings = new LibManRestoreSettings
       {
           WorkingDirectory = "./Directory/with/libmanFile",
           Verbosity = LibManVerbosity.Detailed
       };
    LibManRestore(settings);
});
```

## Information

|                |                                             Stable                                              |                                                                     Pre-release                                                                      |
| :------------: | :---------------------------------------------------------------------------------------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------: |
| GitHub Release |                                                -                                                | [![GitHub release](https://img.shields.io/github/release/cake-contrib/Cake.LibMan.svg)](https://github.com/cake-contrib/Cake.LibMan/releases/latest) |
|     NuGet      | [![NuGet](https://img.shields.io/nuget/v/Cake.LibMan.svg)](https://www.nuget.org/packages/Cake.LibMan) |                      [![NuGet](https://img.shields.io/nuget/vpre/Cake.LibMan.svg)](https://www.nuget.org/packages/Cake.LibMan)                       |

## Build Status

|                                                                             Develop                                                                             |                                                                                     Master                                                                                     |
| :-------------------------------------------------------------------------------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| [![Build status](https://ci.appveyor.com/api/projects/status//branch/develop?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-LibMan/branch/develop) | [![Build status](https://ci.appveyor.com/api/projects/status/oqn617679k8fy2q6/branch/develop?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-LibMan/branch/master) |

## Code Coverage

[![Coverage Status](https://coveralls.io/repos/github/cake-contrib/Cake.LibMan/badge.svg?branch=develop)](https://coveralls.io/github/cake-contrib/Cake.LibMan?branch=develop)

## Quick Links

- [Documentation](https://cakebuild.net/dsl/libman/)

## Discussion

If you have questions, search for an existing one, or create a new discussion on the Cake GitHub repository, using the  `Extension Q&A` category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)

