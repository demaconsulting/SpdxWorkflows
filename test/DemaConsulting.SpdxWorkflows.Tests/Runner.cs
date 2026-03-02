using System.Diagnostics;

namespace DemaConsulting.SpdxWorkflows.Tests;

/// <summary>
/// Program runner class
/// </summary>
internal static class Runner
{
    /// <summary>
    /// Run the specified program
    /// </summary>
    /// <param name="output">Program output</param>
    /// <param name="program">Program name</param>
    /// <param name="arguments">Program arguments</param>
    /// <returns>Program exit code</returns>
    /// <exception cref="InvalidOperationException">On program start error</exception>
    public static int Run(out string output, string program, params string[] arguments)
    {
        // Construct the start information
        var startInfo = new ProcessStartInfo(program)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Disable MSBuild server and node reuse to prevent lingering child
        // processes that cause VSTest to hang waiting for process tree exit.
        startInfo.Environment["DOTNET_CLI_DO_NOT_USE_MSBUILD_SERVER"] = "1";
        startInfo.Environment["MSBUILDDISABLENODEREUSE"] = "1";

        // Add the arguments
        foreach (var argument in arguments)
            startInfo.ArgumentList.Add(argument);

        // Start the process
        var process = Process.Start(startInfo) ??
                      throw new InvalidOperationException("Failed to start process");

        // Capture the output
        output = process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();

        // Wait for the process to exit
        process.WaitForExit();

        // Return the exit code
        return process.ExitCode;
    }
}