// <copyright file="CabInvoiceGeneratorTest.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Cab Invoice Generator Test Class.
    /// </summary>
    public class CabInvoiceGeneratorTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;

        /// <summary>
        /// SetUp Method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        /// <summary>
        /// Test Method for calculating fare when fare is greater than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenTotalFareGreaterThanMinimumFare_ShouldReturnFare()
        {
            double distance = 10.0;
            double time = 10;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(110, totalFare);
        }

        /// <summary>
        /// Test Method for calculating fare when fare is less than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            double time = 1;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5.0d, totalFare);
        }
    }
}
