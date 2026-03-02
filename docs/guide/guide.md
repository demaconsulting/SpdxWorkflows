# Introduction

## Purpose

This document is the user guide for SpdxWorkflows, a collection of standard
workflow files for the SpdxTool utility.

## Scope

This user guide covers:

- Overview of available workflow files
- How to reference workflows in SpdxTool configurations
- Workflow parameters and outputs

# Installation

SpdxWorkflows are referenced directly by URL in SpdxTool workflow steps. No
separate installation is required beyond having SpdxTool installed.

Install SpdxTool using the .NET CLI:

```bash
dotnet tool install --global DemaConsulting.SpdxTool
```

# Usage

## Referencing Workflows

Workflows are referenced by URL in your SpdxTool YAML configuration files:

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

## Available Workflows

### GetDotNetVersion

Retrieves the version of the installed .NET SDK.

**Outputs:**

- `version`: The .NET SDK version string

### GetGccVersion

Retrieves the version of the installed GCC compiler.

**Outputs:**

- `version`: The GCC version string

### GetIarEwArmVersion

Retrieves the version of the installed IAR Embedded Workbench for ARM.

**Outputs:**

- `version`: The IAR EW ARM version string

### GetMsBuildVersion

Retrieves the version of the installed MSBuild tool.

**Outputs:**

- `version`: The MSBuild version string

### GetNugetVersion

Retrieves the version of the installed NuGet client.

**Outputs:**

- `version`: The NuGet version string

### GetVsTestVersion

Retrieves the version of the installed VSTest tool.

**Outputs:**

- `version`: The VSTest version string

### AddDotNetPackage

Adds a .NET package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document
- `package`: Package name to add

### AddGccPackage

Adds a GCC compiler package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document

### AddIarEwArmPackage

Adds an IAR EW ARM package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document

### AddMsBuildPackage

Adds an MSBuild package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document

### AddNugetPackage

Adds a NuGet package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document
- `package`: Package name to add

### AddVsTestPackage

Adds a VSTest package to an SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document

### EnhancePackageFromNugetSpdx

Enhances an SPDX document package with information from a NuGet SPDX document.

**Parameters:**

- `spdx`: Path to the SPDX document
- `package`: Package name to enhance

### GetNugetPackagePath

Retrieves the path of a NuGet package in the local cache.

**Parameters:**

- `package`: Package name
- `version`: Package version

**Outputs:**

- `path`: The path to the NuGet package
