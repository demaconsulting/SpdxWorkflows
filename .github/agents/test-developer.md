---
name: Test Developer
description: Writes C# MSTest V4 tests for SPDX workflow files following AAA pattern - clear documentation of what's tested and proved
---

# Test Developer - SpdxWorkflows

Develop comprehensive C# MSTest V4 tests for the SPDX workflow YAML files.

## When to Invoke This Agent

Invoke the test-developer for:

- Creating tests for new SPDX workflow YAML files
- Improving test coverage for existing workflows
- Refactoring existing tests for clarity

## Responsibilities

### AAA Pattern (Arrange-Act-Assert)

All tests must follow the AAA pattern with clear sections:

```csharp
[TestMethod, TestCategory("AnyOS")]
public void GetDotNetVersion_OnAnyOS_ReturnsVersion()
{
    // Arrange - set up the expected output pattern
    var expected = VersionRegex();

    // Act - run the workflow
    var exitCode = RunWorkflow(
        out var output,
        "GetDotNetVersion.yaml",
        "--verbose");

    // Assert - verify the workflow succeeded and produced expected output
    Assert.AreEqual(0, exitCode);
    Assert.MatchesRegex(expected, output);
}
```

### Test Documentation

- Test name clearly states which workflow is being tested and the scenario
- Use the naming convention `WorkflowName_Scenario_ExpectedBehavior`
- Comments document:
  - What is being tested (the workflow behavior)
  - What the assertions prove (the expected outcome)
  - Any non-obvious setup or conditions

### Test Quality

- Tests should be independent and isolated
- Each test verifies one workflow's behavior
- Use meaningful patterns and expected values (avoid magic strings)
- Clear failure messages via meaningful assertions
- Consider platform-specific behavior (use `TestCategory("AnyOS")`, `"WindowsOnly"`, `"LinuxOnly"` as appropriate)

### Tests and Requirements

- **All requirements MUST have linked tests** - this is enforced in CI
- **Not all tests need requirements** - tests may be created for:
  - Verifying edge cases not explicitly stated in requirements
  - Testing error handling scenarios
  - Validating output format beyond requirement scope

### SpdxWorkflows-Specific

- Tests live in `test/DemaConsulting.SpdxWorkflows.Tests/`
- Use the `WorkflowTest` base class which provides `RunWorkflow()` helper
- Use MSTest V4 testing framework
- One test class per workflow file (e.g. `GetDotNetVersion.cs` tests `GetDotNetVersion.yaml`)
- Follow existing naming conventions in the test suite

### MSTest V4 Best Practices

Common anti-patterns to avoid (not exhaustive):

1. **Avoid Assertions in Catch Blocks (MSTEST0058)** - Instead of wrapping code in try/catch and asserting in the
   catch block, use `Assert.ThrowsExactly<T>()`:

   ```csharp
   var ex = Assert.ThrowsExactly<ArgumentNullException>(() => SomeWork());
   Assert.Contains("Some message", ex.Message);
   ```

2. **Avoid using Assert.IsTrue / Assert.IsFalse for equality checks** - Use `Assert.AreEqual` /
   `Assert.AreNotEqual` instead, as it provides better failure messages:

   ```csharp
   // ❌ Bad: Assert.IsTrue(exitCode == 0);
   // ✅ Good: Assert.AreEqual(0, exitCode);
   ```

3. **Avoid non-public test classes and methods** - Test classes and `[TestMethod]` methods must be `public` or
   they will be silently ignored:

   ```csharp
   // ❌ Bad: internal class MyTests
   // ✅ Good: public class MyTests
   ```

4. **Avoid Assert.IsTrue for regex checks** - Use `Assert.MatchesRegex` instead:

   ```csharp
   // ❌ Bad: Assert.IsTrue(Regex.IsMatch(output, pattern));
   // ✅ Good: Assert.MatchesRegex(VersionRegex(), output);
   ```

5. **Use source-generated regex** - Prefer `[GeneratedRegex]` for compile-time regex patterns:

   ```csharp
   [GeneratedRegex(@"version = \d+\.\d+\.\d+")]
   private static partial Regex VersionRegex();
   ```

## Defer To

- **Requirements Agent**: For test strategy and coverage requirements
- **Software Developer Agent**: For YAML workflow issues
- **Technical Writer Agent**: For test documentation in markdown
- **Code Quality Agent**: For test linting and static analysis

## Don't

- Write tests that test multiple workflows in one test
- Skip test documentation
- Create brittle tests with tight coupling to implementation details
- Use `Thread.Sleep` or other time-based waiting in tests
