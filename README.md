# SpdxWorkflows

[![GitHub forks][badge-forks]][link-forks]
[![GitHub stars][badge-stars]][link-stars]
[![GitHub contributors][badge-contributors]][link-contributors]
[![License][badge-license]][link-license]
[![Build][badge-build]][link-build]

DEMA Consulting collection of standard [SpdxTool][link-spdxtool] workflow YAML files for
capturing build-tool version information and populating [SPDX][link-spdx] software bills of
materials (SBOMs).

## Features

This collection provides:

- **Version Discovery Workflows**: Detect and capture the installed versions of common build
  tools — .NET SDK, GCC, MSBuild, NuGet, VSTest, and IAR EW ARM
- **SPDX Package Workflows**: Add build-tool packages to an SPDX document — .NET SDK, GCC,
  MSBuild, NuGet, VSTest, and IAR EW ARM
- **NuGet SPDX Enhancement**: Enrich an SPDX document package with metadata sourced from a
  NuGet package's own SPDX document
- **Multi-Platform Support**: Workflows target Windows and Linux build environments
- **MSTest V4**: Modern unit testing with MSTest framework version 4
- **Comprehensive CI/CD**: GitHub Actions workflows with quality checks and builds

## Installation

SpdxWorkflows are referenced directly by URL inside your own SpdxTool workflow YAML files.
No separate installation step is required beyond having SpdxTool available.

Install SpdxTool using the .NET CLI:

```bash
dotnet tool install --global DemaConsulting.SpdxTool
```

## Usage

Reference a workflow by supplying its versioned GitHub URL and an optional SHA-512 integrity
hash to the `run-workflow` command:

```yaml
- command: run-workflow
  inputs:
    url: 'https://github.com/demaconsulting/SpdxWorkflows/blob/0.1.0/GetDotNetVersion.yaml'
    integrity: d9c80d18f6ad6b3cbd5facb28d6c5712bc68c58ace11ebf890cfc92e0857628b
    parameters:
      <optional parameters>
    outputs:
      <optional outputs>
```

Replace `0.1.0` with the desired release tag. See [Releases][link-releases] for available
versions and their workflow integrity hashes.

## Available Workflows

### Version Discovery

These workflows detect and capture the installed version of a build tool. All version
discovery workflows produce a single `version` output parameter.

| Workflow | Description | Platform |
| --- | --- | --- |
| [GetDotNetVersion.yaml][link-wf-getdotnet] | Gets the installed .NET SDK version | Windows, Linux |
| [GetGccVersion.yaml][link-wf-getgcc] | Gets the installed GCC version | Linux |
| [GetIarEwArmVersion.yaml][link-wf-getiar] | Gets the installed IAR EW ARM version | Windows |
| [GetMsBuildVersion.yaml][link-wf-getmsbuild] | Gets the installed MSBuild version | Windows |
| [GetNugetVersion.yaml][link-wf-getnuget] | Gets the installed NuGet version | Windows |
| [GetNugetPackagePath.yaml][link-wf-getnugetpath] | Gets the path to a NuGet package in the local cache | Windows |
| [GetVsTestVersion.yaml][link-wf-getvstest] | Gets the installed VSTest version | Windows |

### SPDX Package Addition

These workflows add a build-tool entry as a package to an existing SPDX document.

| Workflow | Description | Platform |
| --- | --- | --- |
| [AddDotNetPackage.yaml][link-wf-adddotnet] | Adds the .NET SDK package to an SPDX document | Windows, Linux |
| [AddGccPackage.yaml][link-wf-addgcc] | Adds the GCC package to an SPDX document | Linux |
| [AddIarEwArmPackage.yaml][link-wf-addiar] | Adds the IAR EW ARM package to an SPDX document | Windows |
| [AddMsBuildPackage.yaml][link-wf-addmsbuild] | Adds the MSBuild package to an SPDX document | Windows |
| [AddNugetPackage.yaml][link-wf-addnuget] | Adds the NuGet package to an SPDX document | Windows |
| [AddVsTestPackage.yaml][link-wf-addvstest] | Adds the VSTest package to an SPDX document | Windows |
| [EnhancePackageFromNugetSpdx.yaml][link-wf-enhance] | Enhances an SPDX package with metadata from a NuGet SPDX document | Windows |

For full parameter and output details see the [User Guide][link-guide].

## Documentation

- **[User Guide][link-guide]**: Workflow parameters, outputs, and usage examples

## License

Copyright (c) DEMA Consulting. Licensed under the MIT License. See [LICENSE][link-license] for
details.

By contributing to this project, you agree that your contributions will be licensed under the
MIT License.

<!-- Badge references -->
[badge-forks]: https://img.shields.io/github/forks/demaconsulting/SpdxWorkflows?style=plastic
[badge-stars]: https://img.shields.io/github/stars/demaconsulting/SpdxWorkflows?style=plastic
[badge-contributors]: https://img.shields.io/github/contributors/demaconsulting/SpdxWorkflows?style=plastic
[badge-license]: https://img.shields.io/github/license/demaconsulting/SpdxWorkflows?style=plastic
[badge-build]: https://img.shields.io/github/actions/workflow/status/demaconsulting/SpdxWorkflows/build_on_push.yaml?style=plastic

<!-- Link references -->
[link-forks]: https://github.com/demaconsulting/SpdxWorkflows/network/members
[link-stars]: https://github.com/demaconsulting/SpdxWorkflows/stargazers
[link-contributors]: https://github.com/demaconsulting/SpdxWorkflows/graphs/contributors
[link-license]: LICENSE
[link-build]: https://github.com/demaconsulting/SpdxWorkflows/actions/workflows/build_on_push.yaml
[link-releases]: https://github.com/demaconsulting/SpdxWorkflows/releases
[link-guide]: docs/guide/guide.md
[link-spdxtool]: https://github.com/demaconsulting/SpdxTool
[link-spdx]: https://spdx.dev

<!-- Workflow file references -->
[link-wf-getdotnet]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetDotNetVersion.yaml
[link-wf-getgcc]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetGccVersion.yaml
[link-wf-getiar]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetIarEwArmVersion.yaml
[link-wf-getmsbuild]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetMsBuildVersion.yaml
[link-wf-getnuget]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetNugetVersion.yaml
[link-wf-getnugetpath]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetNugetPackagePath.yaml
[link-wf-getvstest]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/GetVsTestVersion.yaml
[link-wf-adddotnet]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddDotNetPackage.yaml
[link-wf-addgcc]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddGccPackage.yaml
[link-wf-addiar]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddIarEwArmPackage.yaml
[link-wf-addmsbuild]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddMsBuildPackage.yaml
[link-wf-addnuget]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddNugetPackage.yaml
[link-wf-addvstest]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/AddVsTestPackage.yaml
[link-wf-enhance]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/EnhancePackageFromNugetSpdx.yaml
