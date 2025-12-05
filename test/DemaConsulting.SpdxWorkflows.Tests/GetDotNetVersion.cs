using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public partial class GetDotNetVersion : WorkflowTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void TestGetDotNetVersion()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetDotNetVersion.yaml",
            "--verbose");

        // Verify we found a valid DotNet version
        Assert.AreEqual(0, exitCode);
        Assert.MatchesRegex(VersionRegex(), output);
    }

    [GeneratedRegex(@"version = \d+\.\d+\.\d+")]
    private static partial Regex VersionRegex();
}