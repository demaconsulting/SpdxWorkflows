﻿namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddNugetPackage : AddPackageTest
{
    [TestMethod]
    public void TestAddNugetPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddNugetPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-NuGet-6.9.1.3",
            "version=6.9.1.3");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-NuGet-6.9.1.3");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("NuGet Command Line Interface", package.Name);
        Assert.AreEqual("Apache-2.0", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) .NET Foundation and Contributors.", package.CopyrightText);
        Assert.AreEqual("6.9.1.3", package.Version);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Supplier);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Originator);
        Assert.AreEqual("https://www.nuget.org", package.HomePage);
        Assert.AreEqual("The NuGet client tools provide the ability to produce and consume packages.", package.Summary);
    }
}