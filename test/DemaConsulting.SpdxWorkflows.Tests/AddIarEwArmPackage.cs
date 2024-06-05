namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddIarEwArmPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void TestAddIarEwArmPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddIarEwArmPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-IAR-EWARM-9.40.2.374",
            "version=9.40.2.374");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-IAR-EWARM-9.40.2.374");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("IAR Embedded Workbench for Arm", package.Name);
        Assert.AreEqual("9.40.2.374", package.Version);
        Assert.AreEqual("Organization: IAR Systems AB", package.Supplier);
        Assert.AreEqual("Organization: IAR Systems AB", package.Originator);
        Assert.AreEqual("https://www.iar.com/products/architectures/arm/iar-embedded-workbench-for-arm", package.HomePage);
        Assert.AreEqual("Complete development environment for Arm", package.Summary);
    }
}