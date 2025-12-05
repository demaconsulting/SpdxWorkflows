using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public partial class GetGccVersion : WorkflowTest
{
    [TestMethod, TestCategory("Linux")]
    public void TestGetGccVersion()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetGccVersion.yaml",
            "--verbose");

        // Verify we found a valid GCC version
        Assert.AreEqual(0, exitCode);
        Assert.MatchesRegex(VersionRegex(), output);
    }

    [GeneratedRegex(@"version = \d+\.\d+")]
    private static partial Regex VersionRegex();
}