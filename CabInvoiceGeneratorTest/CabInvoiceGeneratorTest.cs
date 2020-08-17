﻿// <copyright file="CabInvoiceGeneratorTest.cs" company="BridgeLabz Solution">
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

        /// <summary>
        /// Test Method To Calculate Aggregate Fare Of Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Rides[] ride = { new Rides(4.0, 5.0), new Rides(3.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(40.0, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test Method To Get Enhanced Invoice Summary With More Ride Details.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            InvoiceSummary invoiceSummary = new InvoiceSummary(2, 605);
            Rides[] rides = { new Rides(30, 30), new Rides(25, 25) };
            InvoiceSummary invoiceSummaryOne = this.cabInvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(invoiceSummary, invoiceSummaryOne);
        }

        /// <summary>
        /// Test Method To Get Invoice Summary By User Id.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserFound_ShouldReturnInvoiceSummary()
        {
            string userId = "karthik@gmail.com";
            Rides[] rides = { new Rides(3, 5), new Rides(4, 5) };
            this.cabInvoiceGenerator.MapRidesToUser(userId, rides);
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary invoiceSummaryOne = new InvoiceSummary(2, 80);
            Assert.AreEqual(invoiceSummary, invoiceSummaryOne);
        }
    }
}
