# Agent Quick Reference

Project-specific guidance for agents working on SpdxWorkflows - a collection of standard
[SpdxTool](https://github.com/demaconsulting/SpdxTool) workflow YAML files with C# MSTest V4 tests.

## Available Specialized Agents

- **Requirements Agent** - Develops requirements and ensures test coverage linkage
- **Technical Writer** - Creates accurate documentation following regulatory best practices
- **Software Developer** - Creates and maintains SPDX workflow YAML files
- **Test Developer** - Creates C# MSTest V4 tests for SPDX workflow files
- **Code Quality Agent** - Enforces linting, static analysis, and quality standards

## Tech Stack

- YAML workflow files (SpdxTool workflows)
- C# 12, .NET 10.0, dotnet CLI, MSTest V4 (tests only)

## Key Files

- **`*.yaml`** (root) - SPDX workflow YAML files executed by SpdxTool
- **`requirements.yaml`** - All requirements with test linkage (enforced via `dotnet reqstream --enforce`)
- **`test/DemaConsulting.SpdxWorkflows.Tests/`** - C# MSTest V4 tests for the workflows
- **`.editorconfig`** - Code style (4-space indent, UTF-8+BOM, LF endings)
- **`.cspell.json`, `.markdownlint-cli2.jsonc`, `.yamllint.yaml`** - Linting configs

## Requirements

- All requirements MUST be linked to tests
- Not all tests need to be linked to requirements (tests may exist for corner cases, etc.)
- Enforced in CI: `dotnet reqstream --requirements requirements.yaml --tests "test-results/**/*.trx" --enforce`
- When adding features: add requirement + link to test

## Testing

- **Test Naming**: `WorkflowName_Scenario_ExpectedBehavior` for workflow tests
- **Test Framework**: Uses MSTest V4 for testing
- **Test Location**: `test/DemaConsulting.SpdxWorkflows.Tests/`
- Tests run the YAML workflow files via `dotnet spdx-tool run-workflow`

## Code Style

- **YAML Workflows**: Use YAML comments (`#`) for literate-style documentation
- **C# Tests**: File-scoped namespaces, 4-space indent, XML docs on all members
- **String Formatting**: Use interpolated strings ($"") for clarity

## Project Structure

- **Root `*.yaml`**: SPDX workflow files (e.g. `GetDotNetVersion.yaml`, `AddDotNetPackage.yaml`)
- **`test/`**: C# test project that runs each workflow and verifies output

## Build and Test

```bash
# Run unit tests
dotnet test --configuration Release test/DemaConsulting.SpdxWorkflows.Tests/

# Run all linters
./lint.sh     # Linux/macOS
lint.bat      # Windows
```

## Documentation

- **User Guide**: `docs/guide/guide.md`
- **README.md**: Usage guide for the workflows
- **CONTRIBUTING.md**: Contribution guidelines
- **SECURITY.md**: Security policy and vulnerability reporting
- **CODE_OF_CONDUCT.md**: Community standards and conduct expectations
- **Requirements**: `requirements.yaml` -> auto-generated docs
- **Build Notes**: Auto-generated via BuildMark
- **CHANGELOG.md**: Not present - changes are captured in the auto-generated build notes

## Markdown Link Style

- **AI agent markdown files** (`.github/agents/*.md`): Use inline links `[text](url)` so URLs are visible in agent context
- **README.md**: Use reference-style links `[text][ref]` with `[ref]: url` at document end
- **All other markdown files**: Use reference-style links `[text][ref]` with `[ref]: url` at document end

## CI/CD

- **Quality Checks**: Markdown lint, spell check, YAML lint
- **Tests**: Multi-platform (Windows/Linux)
- **CodeQL**: Security scanning

## Common Tasks

```bash
# Run all linters
./lint.sh     # Linux/macOS
lint.bat      # Windows
```

## Agent Report Files

When agents need to write report files to communicate with each other or the user, follow these guidelines:

- **Naming Convention**: Use the pattern `AGENT_REPORT_xxxx.md` (e.g., `AGENT_REPORT_analysis.md`, `AGENT_REPORT_results.md`)
- **Purpose**: These files are for temporary inter-agent communication and should not be committed
- **Exclusions**: Files matching `AGENT_REPORT_*.md` are automatically:
  - Excluded from git (via .gitignore)
  - Excluded from markdown linting
  - Excluded from spell checking
