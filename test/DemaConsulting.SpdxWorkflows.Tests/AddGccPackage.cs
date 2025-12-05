namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddGccPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void TestAddGccPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddGccPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-GCC-11.4.0",
            "version=11.4.0");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-GCC-11.4.0");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("GNU Compiler Collection", package.Name);
        Assert.AreEqual("GPL-3.0-or-later", package.ConcludedLicense);
        Assert.AreEqual("Copyright (C) 2009 Free Software Foundation, Inc. <http://fsf.org/>", package.CopyrightText);
        Assert.AreEqual("11.4.0", package.Version);
        Assert.AreEqual("Organization: GNU", package.Originator);
        Assert.AreEqual("https://gcc.gnu.org/", package.HomePage);
        Assert.AreEqual(
            "The GNU Compiler Collection includes front ends for C, C++, Objective-C, Fortran, Java, and Ada, as well as libraries for these languages (libstdc++, libgcj,...).",
            package.Summary);

        // Verify the PURL
        Assert.HasCount(1, package.ExternalReferences);
        Assert.AreEqual(SpdxModel.SpdxReferenceCategory.PackageManager, package.ExternalReferences[0].Category);
        Assert.AreEqual("purl", package.ExternalReferences[0].Type);
        Assert.AreEqual("pkg:github/gcc-mirror/gcc@releases/gcc-11.4.0", package.ExternalReferences[0].Locator);
    }
}