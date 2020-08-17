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
        private double totalFare = 0.0;

        /// <summary>
        /// Method for calculating fare of a ride.
        /// </summary>
        /// <param name="distance">Distance of ride.</param>
        /// <param name="time">Time Taken for ride.</param>
        /// <returns>Fare for a ride.</returns>
        public double CalculateFare(double distance, double time)
        {
            this.totalFare = (distance * CostPerKilometer) + (time * CostPerMinute);
            return Math.Max(this.totalFare, MinimumFare);
        }
    }
}
