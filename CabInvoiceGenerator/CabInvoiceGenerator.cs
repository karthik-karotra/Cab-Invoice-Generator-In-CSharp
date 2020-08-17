// <copyright file="CabInvoiceGenerator.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoicer Generator Service Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static double costPerKilometer;
        private static double costPerMinute;
        private static double minimumFare;
        private RideType rideType = new RideType();

        /// <summary>
        /// Method For Calculating Fare Of A Ride.
        /// </summary>
        /// <param name="type">Type Of Ride.</param>
        /// <param name="distance">Distance Of Ride.</param>
        /// <param name="time">Time Taken For Ride.</param>
        /// <returns>Fare For A Ride.</returns>
        public double CalculateFare(RideType.Type type, double distance, double time)
        {
            this.SetValues(type);
            double totalFare = (distance * costPerKilometer) + (time * costPerMinute);
            return Math.Max(totalFare, minimumFare);
        }

        /// <summary>
        ///  Method to Calculate Aggregate Fare Of Multiple Rides.
        /// </summary>
        /// <param name="type">Type Of Ride.</param>
        /// <param name="rides">Array Of Ride Object Class.</param>
        /// <returns>Aggregate Of Total Fare.</returns>
        public InvoiceSummary CalculateFare(RideType.Type type, Rides[] rides)
        {
            double totalRidesFare = 0.0;
            foreach (Rides ride in rides)
            {
                totalRidesFare += this.CalculateFare(type, ride.RideDistance, ride.RideTime);
            }

            return new InvoiceSummary(rides.Length, totalRidesFare);
        }

        public void SetValues(RideType.Type type)
        {
            this.rideType = this.rideType.SetValuesAsPerRideType(type);
            costPerKilometer = this.rideType.CostPerKms;
            costPerMinute = this.rideType.CostPerMinute;
            minimumFare = this.rideType.MinimumFare;
        }

        public void MapRidesToUser(string userID, Rides[] rides) => RideRepository.AddRides(userID, rides);

        public InvoiceSummary GetInvoiceSummary(RideType.Type type, string userID)
            => this.CalculateFare(type, RideRepository.GetRides(userID));
    }
}
