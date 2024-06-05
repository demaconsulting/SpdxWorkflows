# Spdx Workflows

This repository contains standard SpdxTool workflow files.

These files can be executed using the following SpdxTool workflow steps:

```yaml
  # Run GetDotNetVersion workflow
- command: run-workflow
  inputs:
    url: 'https://github.com/demaconsulting/SpdxWorkflows/blob/0.1.0/GetDotNetVersion.yaml'
    integrity: d9c80d18f6ad6b3cbd5facb28d6c5712bc68c58ace11ebf890cfc92e0857628b
    parameters:
      <optional parameters>
    outputs:
      <optional outputs>
```
