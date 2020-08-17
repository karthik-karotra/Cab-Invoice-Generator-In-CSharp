// <copyright file="Rides.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    /// <summary>
    /// Rides Class For Storing Information Of Rides.
    /// </summary>
    public class Rides
    {
        public double RideDistance;
        public double RideTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// </summary>
        /// <param name="rideDistance">Ride Distance Of A Ride.</param>
        /// <param name="rideTime">Ride Time Of A Ride.</param>
        public Rides(double rideDistance, double rideTime)
        {
            this.RideDistance = rideDistance;
            this.RideTime = rideTime;
        }
    }
}
