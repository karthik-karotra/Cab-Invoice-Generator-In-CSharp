// <copyright file="InvoiceSummary.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Invoice Summary Class To Store Invoice Data.
    /// </summary>
    public class InvoiceSummary
    {
        public int NumberOfRides;
        public double TotalFare;
        public double AverageFarePerRide;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Total Number Of Rides.</param>
        /// <param name="totalFare">Total Fare Of Rides.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NumberOfRides = numberOfRides;
            this.TotalFare = totalFare;
            this.AverageFarePerRide = this.TotalFare / this.NumberOfRides;
        }

        /// <summary>
        /// Overriding Equals Method.
        /// </summary>
        /// <param name="obj">Object Of <see cref="InvoiceSummary"/> Class.</param>
        /// <returns>Returns True If Object Value Are Same.</returns>
        public override bool Equals(object obj) => obj is InvoiceSummary summary &&
                   this.NumberOfRides == summary.NumberOfRides &&
                   this.TotalFare == summary.TotalFare &&
                   this.AverageFarePerRide == summary.AverageFarePerRide;

        /// <summary>
        /// Overriding GetHashCode Method.
        /// </summary>
        /// <returns>Returns Hash Code.</returns>
        public override int GetHashCode() => HashCode.Combine(this.NumberOfRides, this.TotalFare, this.AverageFarePerRide);
    }
}
