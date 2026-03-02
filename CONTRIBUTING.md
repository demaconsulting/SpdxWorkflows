# Contributing to SpdxWorkflows

Thank you for your interest in contributing to SpdxWorkflows! We welcome contributions from the community and
appreciate your help in making this project better.

## Code of Conduct

This project adheres to a [Code of Conduct][code-of-conduct]. By participating, you are expected to uphold this code.
Please report unacceptable behavior through GitHub.

## How to Contribute

### Reporting Bugs

If you find a bug, please create an issue on GitHub with the following information:

- **Description**: Clear description of the bug
- **Steps to Reproduce**: Detailed steps to reproduce the issue
- **Expected Behavior**: What you expected to happen
- **Actual Behavior**: What actually happened
- **Environment**: Operating system, .NET version, SpdxTool version
- **Logs**: Any relevant error messages or logs

### Suggesting Features

We welcome feature suggestions! Please create an issue on GitHub with:

- **Feature Description**: Clear description of the proposed feature
- **Use Case**: Why this feature would be useful
- **Proposed Solution**: Your ideas on how to implement it (optional)
- **Alternatives**: Any alternative solutions you've considered (optional)

### Submitting Pull Requests

We follow a standard GitHub workflow for contributions:

1. **Fork** the repository
2. **Clone** your fork locally
3. **Create a branch** for your changes (`git checkout -b feature/my-feature`)
4. **Make your changes** following our coding standards
5. **Test your changes** thoroughly
6. **Commit your changes** with clear commit messages
7. **Push** to your fork
8. **Create a Pull Request** to the main repository

## Development Setup

### Prerequisites

- [.NET SDK][dotnet-download] 10.0
- [SpdxTool][spdxtool] (installed as a dotnet tool)
- Git
- A code editor (Visual Studio, VS Code, or Rider recommended)

### Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/demaconsulting/SpdxWorkflows.git
   cd SpdxWorkflows
   ```

2. Restore dotnet tools:

   ```bash
   dotnet tool restore
   ```

3. Run tests:

   ```bash
   dotnet test --configuration Release test/DemaConsulting.SpdxWorkflows.Tests/
   ```

## Coding Standards

### YAML Workflow Files

- Use literate-style comments — every logical section should have a comment explaining what it does
- Every workflow file must begin with a header comment block describing its name, purpose, parameters, and outputs
- Follow `.yamllint.yaml` configuration:
  - **Indentation**: 2 spaces
  - **Line length**: Maximum 120 characters
  - **Comments**: Minimum 2 spaces from content

### C# Test Code

This project has C# tests only (no C# production code). Follow these conventions:

- Use clear, descriptive names for variables, methods, and classes
- Write XML documentation comments for all members
- Keep methods focused and single-purpose

### Code Style

This project enforces code style through `.editorconfig`. Key requirements:

- **Indentation**: 4 spaces for C#, 2 spaces for YAML/JSON/XML
- **Line Endings**: LF (Unix-style)
- **Encoding**: UTF-8 with BOM
- **Namespaces**: Use file-scoped namespace declarations

## Testing Guidelines

### Test Framework

We use MSTest v4 for tests.

### Test Naming Convention

Use the pattern: `ClassName_MethodUnderTest_Scenario_ExpectedBehavior`

Examples:

- `GetDotNetVersion_Run_OnAnyOS_ReturnsVersion`
- `AddDotNetPackage_Run_WithValidInputs_AddsPackage`

### Writing Tests

- Write tests that are clear and focused
- Use the AAA pattern (Arrange-Act-Assert) with clear section comments
- Use modern MSTest v4 assertions:
  - `Assert.AreEqual(expected, actual)`
  - `Assert.MatchesRegex(regex, value)`
  - `Assert.ThrowsExactly<T>(() => SomeWork())`
- Always ensure tests verify observable workflow output

### Running Tests

```bash
# Run all tests
dotnet test --configuration Release test/DemaConsulting.SpdxWorkflows.Tests/

# Run a specific test
dotnet test --filter "FullyQualifiedName~YourTestName" \
  test/DemaConsulting.SpdxWorkflows.Tests/
```

## Documentation

### Markdown Guidelines

All markdown files must follow these rules (enforced by markdownlint):

- Maximum line length: 120 characters
- Use ATX-style headers (`# Header`)
- Lists must be surrounded by blank lines
- Use reference-style links: `[text][ref]` with `[ref]: url` at document end
- **Exception**: AI agent markdown files (`.github/agents/*.md`) use inline links `[text](url)` so URLs are
  visible in agent context

### Spell Checking

All files are spell-checked using cspell. Add project-specific terms to `.cspell.json`:

```json
{
  "words": [
    "myterm"
  ]
}
```

## Quality Checks

Before submitting a pull request, ensure all quality checks pass:

### 1. Test

```bash
# Run all tests
dotnet test --configuration Release test/DemaConsulting.SpdxWorkflows.Tests/
```

All tests must pass with zero warnings.

### 2. Linting

```bash
# Run all linters
./lint.sh     # Linux/macOS
lint.bat      # Windows
```

## Commit Messages

Write clear, concise commit messages:

- Use present tense ("Add feature" not "Added feature")
- Use imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit first line to 72 characters
- Reference issues and pull requests when applicable

Examples:

- `Add GetPythonVersion workflow`
- `Fix version pattern in GetGccVersion workflow`
- `Update documentation for AddDotNetPackage workflow`
- `Refactor test base class for better reuse`

## Pull Request Process

1. **Update Documentation**: Update relevant documentation for your changes
2. **Add Tests**: Include tests that cover your changes
3. **Run Quality Checks**: Ensure all linters, tests, and builds pass
4. **Submit PR**: Create a pull request with a clear description
5. **Code Review**: Address feedback from maintainers
6. **Merge**: Once approved, a maintainer will merge your PR

### Pull Request Template

When creating a pull request, include:

- **Description**: What changes does this PR introduce?
- **Motivation**: Why are these changes needed?
- **Related Issues**: Link to any related issues
- **Testing**: How have you tested these changes?
- **Checklist**:
  - [ ] Tests added/updated
  - [ ] Documentation updated
  - [ ] All tests pass
  - [ ] YAML follows style guidelines
  - [ ] No new linting warnings introduced

## Getting Help

- **Questions**: Use [GitHub Discussions][discussions]
- **Bugs**: Report via [GitHub Issues][issues]
- **Security**: See [SECURITY.md][security] for vulnerability reporting

## License

By contributing to SpdxWorkflows, you agree that your contributions will be licensed under the MIT License.

Thank you for contributing to SpdxWorkflows!

[code-of-conduct]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/CODE_OF_CONDUCT.md
[dotnet-download]: https://dotnet.microsoft.com/download
[spdxtool]: https://github.com/demaconsulting/SpdxTool
[discussions]: https://github.com/demaconsulting/SpdxWorkflows/discussions
[issues]: https://github.com/demaconsulting/SpdxWorkflows/issues
[security]: https://github.com/demaconsulting/SpdxWorkflows/blob/main/SECURITY.md
