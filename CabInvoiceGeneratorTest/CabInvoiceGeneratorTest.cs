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
        /// <summary>
        /// Distance For First Ride.
        /// </summary>
        private readonly double firstDistance = 10;

        /// <summary>
        /// Time For First Ride.
        /// </summary>
        private readonly double firstTime = 10;

        /// <summary>
        /// Distance For Second Ride.
        /// </summary>
        private readonly double secondDistance = 3;

        /// <summary>
        /// Time For Second Ride.
        /// </summary>
        private readonly double secondTime = 5;

        /// <summary>
        /// Distance For Third Ride.
        /// </summary>
        private readonly double thirdDistance = 0.1;

        /// <summary>
        /// Time For Third Ride.
        /// </summary>
        private readonly double thirdTime = 1;

        /// <summary>
        /// Object of <see cref="CabInvoiceService"/> class.
        /// </summary>
        private CabInvoiceService cabInvoiceService;

        /// <summary>
        /// SetUp Method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceService = new CabInvoiceService();
        }

        /// <summary>
        /// Test Method for calculating fare for normal ride when fare is greater than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForNormalRide_WhenTotalFareGreaterThanMinimumFare_ShouldReturnFare()
        {
            double totalFare = this.cabInvoiceService.CalculateFare(RideType.Type.NORMAL, this.firstDistance, this.firstTime);
            Assert.AreEqual(110, totalFare);
        }

        /// <summary>
        /// Test Method for calculating fare for normal ride when fare is less than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForNormalRide_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            double totalFare = this.cabInvoiceService.CalculateFare(RideType.Type.NORMAL, this.thirdDistance, this.thirdTime);
            Assert.AreEqual(5.0d, totalFare);
        }

        /// <summary>
        /// Test Method To Calculate Aggregate Fare Of Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Rides[] ride = { new Rides(RideType.Type.NORMAL, this.firstDistance, this.firstTime), new Rides(RideType.Type.NORMAL, this.secondDistance, this.secondTime) };
            InvoiceSummary invoiceSummary = this.cabInvoiceService.CalculateFare(RideType.Type.NORMAL, ride);
            Assert.AreEqual(72.5, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test Method To Get Enhanced Invoice Summary With More Ride Details.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            InvoiceSummary invoiceSummary = new InvoiceSummary(2, 145);
            Rides[] rides = { new Rides(RideType.Type.NORMAL, this.firstDistance, this.firstTime), new Rides(RideType.Type.NORMAL, this.secondDistance, this.secondTime) };
            InvoiceSummary invoiceSummaryOne = this.cabInvoiceService.CalculateFare(RideType.Type.NORMAL, rides);
            Assert.AreEqual(invoiceSummary, invoiceSummaryOne);
        }

        /// <summary>
        /// Test Method To Get Invoice Summary By User Id.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserIdValid_ShouldReturnInvoiceSummary()
        {
            string userId = "karthik@gmail.com";
            Rides[] rides = { new Rides(RideType.Type.NORMAL, this.firstDistance, this.firstTime), new Rides(RideType.Type.NORMAL, this.secondDistance, this.secondTime) };
            this.cabInvoiceService.MapRidesToUser(userId, rides);
            InvoiceSummary invoiceSummary = this.cabInvoiceService.GetInvoiceSummary(RideType.Type.NORMAL, userId);
            InvoiceSummary invoiceSummaryOne = new InvoiceSummary(2, 145);
            Assert.AreEqual(invoiceSummary, invoiceSummaryOne);
        }

        /// <summary>
        /// Test Method To Get Invoice Summary By User Id.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserIdNotValid_ShouldThrowException()
        {
            string userId = "karthik";
            Rides[] rides = { new Rides(RideType.Type.NORMAL, this.firstDistance, this.firstTime), new Rides(RideType.Type.NORMAL, this.secondDistance, this.secondTime) };
            var error = Assert.Throws<CabInvoiceException>(() => this.cabInvoiceService.MapRidesToUser(userId, rides));
            Assert.AreEqual(CabInvoiceException.CabInvoiceExceptionType.INVALID_USERID, error.ExceptionType);
        }

        /// <summary>
        /// Test Method for calculating fare for premium ride when fare is greater than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenTotalFareGreaterThanMinimumFare_ShouldReturnFare()
        {
            double totalFare = this.cabInvoiceService.CalculateFare(RideType.Type.PREMIUM, this.firstDistance, this.firstTime);
            Assert.AreEqual(170, totalFare);
        }

        /// <summary>
        /// Test Method for calculating fare for premium ride when fare is less than minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            double totalFare = this.cabInvoiceService.CalculateFare(RideType.Type.PREMIUM, this.thirdDistance, this.thirdTime);
            Assert.AreEqual(20.0d, totalFare);
        }
    }
}
