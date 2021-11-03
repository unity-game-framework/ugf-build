# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-preview.6](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.6) - 2021-11-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/6?closed=1)  
    

### Added

- Add get of the build report object ([#22](https://github.com/unity-game-framework/ugf-build/pull/22))  
    - Add `BuildEditorUtility.TryGetBuildReport()` method to get `BuildReport` object after build process.

## [1.0.0-preview.5](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.5) - 2021-09-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/5?closed=1)  
    

### Added

- Add header display for platform settings ([#20](https://github.com/unity-game-framework/ugf-build/pull/20))  
    - Add missing display label under the setup platform settings section.

## [1.0.0-preview.4](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.4) - 2021-09-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/4?closed=1)  
    

### Added

- Add stopwatch scope ([#16](https://github.com/unity-game-framework/ugf-build/pull/16))  
    - Add `BuildStopwatch` structure to log and measure execution of any part of the build process.
- Add build step auto name ([#15](https://github.com/unity-game-framework/ugf-build/pull/15))  
    - Add `BuildStep` auto naming using name of the type when creating class without specified name.

### Changed

- Add pre and post export setup name env variable settings ([#17](https://github.com/unity-game-framework/ugf-build/pull/17))  
    - Add `BuildEditorSettingsData.PreExportSetupNameEnvironmentVariable` property to define environment variable with setup name for pre export execution.
    - Add `BuildEditorSettingsData.PostExportSetupNameEnvironmentVariable` property to define environment variable with setup name for post export execution.
    - Add `BuildEditorUtility.ExecutePreExport()` and `PostExport()` methods used to execute setup from environment variables and specified context.
    - Change `BuildEditorUtility.TryGetSetupNameFromEnvironmentVariables()` and `GetSetupNameFromEnvironmentVariables()` methods to require environment variable name to get setup name from.
    - Fix `UnityCloudBuild.PreExport()` and `PostExport()` methods create context with _Unity Cloud Build_ manifest included.
    - Remove `BuildEditorSettingsData.SetupNameEnvironmentVariableName` property, use `PreExportSetupNameEnvironmentVariable` and `PostExportSetupNameEnvironmentVariable` properties instead.
    - Remove `BuildEditorUtility.Execute()` method with zero arguments.
    - Remove `UnityCloudBuildEditorUtility.Execute()` method.

## [1.0.0-preview.3](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.3) - 2021-08-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/3?closed=1)  
    

### Fixed

- Fix missing SetupNameEnvironmentVariableName in editor settings ([#11](https://github.com/unity-game-framework/ugf-build/pull/11))  
    - Update dependencies: `com.ugf.editortools` to `1.13.0` version.
    - Fix missing `SetupNameEnvironmentVariableName` property in _BuildEditorSettings_ project settings.

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.2) - 2021-08-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/2?closed=1)  
    

### Added

- Add logger setup for build setup execute ([#8](https://github.com/unity-game-framework/ugf-build/pull/8))  
    - Add `BuildLogScope` disposable structure to create scope with specific logger options.
    - Change `BuildEditorUtility.Execute()` methods to use log settings from `BuildEditorSettings` settings.
- Add log report for each step ([#7](https://github.com/unity-game-framework/ugf-build/pull/7))  
    - Add `BuildSetup` log start and end of setup and each step with execution time.

### Fixed

- Fix build platform tab display error ([#5](https://github.com/unity-game-framework/ugf-build/pull/5))  
    - Fix error when initialize platforms to display build setups.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview.1) - 2021-08-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-build/milestone/1?closed=1)  
    

### Changed

- Change package.json meta guid ([#2](https://github.com/unity-game-framework/ugf-build/pull/2))  
    - Regenerate _Guid_ for `package.json` meta file.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-build/releases/tag/1.0.0-preview) - 2021-08-21  

### Release Notes

- No release notes.


