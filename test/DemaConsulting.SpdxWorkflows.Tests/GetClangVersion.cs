using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public partial class GetClangVersion : WorkflowTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void GetClangVersion_OnAnyOS_ReturnsVersion()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetClangVersion.yaml",
            "--verbose");

        // Verify we found a valid Clang version
        Assert.AreEqual(0, exitCode);
        Assert.MatchesRegex(VersionRegex(), output);
    }

    [GeneratedRegex(@"version = \d+\.\d+")]
    private static partial Regex VersionRegex();
}
