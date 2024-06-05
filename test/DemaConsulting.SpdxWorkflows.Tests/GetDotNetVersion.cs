using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class GetDotNetVersion : WorkflowTest
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
        Assert.IsTrue(Regex.IsMatch(output, @"version = \d+\.\d+\.\d+"));
    }
}