using DemaConsulting.SpdxModel;
using DemaConsulting.SpdxModel.IO;

namespace DemaConsulting.SpdxWorkflows.Tests;

/// <summary>
/// Base class for add-package tests
/// </summary>
public abstract class AddPackageTest : WorkflowTest
{
    /// <summary>
    /// Empty SPDX text
    /// </summary>
    protected const string EmptySpdx = "{\r\n" +
                                       "  \"files\": [],\r\n" +
                                       "  \"packages\": [],\r\n" +
                                       "  \"relationships\": [],\r\n" +
                                       "  \"spdxVersion\": \"SPDX-2.2\",\r\n" +
                                       "  \"dataLicense\": \"CC0-1.0\",\r\n" +
                                       "  \"SPDXID\": \"SPDXRef-DOCUMENT\",\r\n" +
                                       "  \"name\": \"Test Document\",\r\n" +
                                       "  \"documentNamespace\": \"https://sbom.spdx.org\",\r\n" +
                                       "  \"creationInfo\": {\r\n" +
                                       "    \"created\": \"2024-06-05T00:00:00Z\",\r\n" +
                                       "    \"creators\": [ \"Person: Malcolm Nixon\" ]\r\n" +
                                       "  },\r\n" +
                                       "  \"documentDescribes\": [ ]\r\n" +
                                       "}";

    /// <summary>
    /// Run an add-package workflow
    /// </summary>
    /// <param name="yamlName">Name of the workflow file</param>
    /// <param name="args">Workflow arguments</param>
    /// <returns>Parsed SPDX document for inspection</returns>
    protected static SpdxDocument RunAddPackageWorkflow(string yamlName, params string[] args)
    {
        try
        {
            // Write the test file
            File.WriteAllText("spdx.json", EmptySpdx);

            // Run the workflow
            var exitCode = RunWorkflow(
                out _,
                yamlName,
                args);

            // Verify no errors
            Assert.AreEqual(0, exitCode);

            // Return the SPDX document
            return Spdx2JsonDeserializer.Deserialize(File.ReadAllText("spdx.json"));
        }
        finally
        {
            // Delete the test file
            File.Delete("spdx.json");
        }
    }
}