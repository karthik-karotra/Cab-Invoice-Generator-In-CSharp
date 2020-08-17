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
        private static readonly double CostPerKilometer = 10.0;
        private static readonly double CostPerMinute = 1.0;
        private static readonly double MinimumFare = 5.0;

        /// <summary>
        /// Method For Calculating Fare Of A Ride.
        /// </summary>
        /// <param name="distance">Distance Of Ride.</param>
        /// <param name="time">Time Taken For Ride.</param>
        /// <returns>Fare For A Ride.</returns>
        public double CalculateFare(double distance, double time)
        {
            double totalFare = (distance * CostPerKilometer) + (time * CostPerMinute);
            return Math.Max(totalFare, MinimumFare);
        }

        /// <summary>
        ///  Method to Calculate Aggregate Fare Of Multiple Rides.
        /// </summary>
        /// <param name="rides">Array Of Ride Object Class.</param>
        /// <returns>Aggregate Of Total Fare.</returns>
        public double GetMultipleRideFare(Rides[] rides)
        {
            double totalRidesFare = 0.0;
            foreach (Rides ride in rides)
            {
                totalRidesFare += this.CalculateFare(ride.RideDistance, ride.RideTime);
            }

            return totalRidesFare / rides.Length;
        }
    }
}
