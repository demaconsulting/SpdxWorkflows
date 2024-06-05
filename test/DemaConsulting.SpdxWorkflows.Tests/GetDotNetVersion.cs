using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class GetDotNetVersion
{
    [TestMethod]
    public void TestGetDotNetVersion()
    {
        // Run the workflow
        var exitCode = Runner.Run(
            out var output,
            "dotnet",
            "spdx-tool",
            "run-workflow",
            "../../../../../GetDotNetVersion.yaml",
            "--verbose");

        // Verify we found a valid DotNet version
        Assert.AreEqual(0, exitCode);
        Assert.IsTrue(Regex.IsMatch(output, @"version = \d+\.\d+\.\d+"));
    }
}