namespace DemaConsulting.SpdxWorkflows.Tests;

/// <summary>
/// Base class for workflow tests
/// </summary>
public abstract class WorkflowTest
{
    /// <summary>
    /// Run a 
    /// </summary>
    /// <param name="output"></param>
    /// <param name="yamlName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    protected int RunWorkflow(out string output, string yamlName, params string[] args)
    {
        // Construct the arguments
        var allArgs = new List<string>
        {
            "spdx-tool",
            "run-workflow",
            $"../../../../../{yamlName}"
        };
        allArgs.AddRange(args);

        // Run the workflow
        return Runner.Run(out output, "dotnet", allArgs.ToArray());
    }
}
