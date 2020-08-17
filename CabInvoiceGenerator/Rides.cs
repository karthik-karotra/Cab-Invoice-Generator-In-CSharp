// <copyright file="Rides.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Rides Class For Storing Information Of Rides.
    /// </summary>
    public class Rides
    {
        /// <summary>
        /// Variable For Storing Ride Distance Of A Particular Ride.
        /// </summary>
        public double RideDistance;

        /// <summary>
        /// Variable For Storing Ride Time Of A Particular Ride.
        /// </summary>
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
