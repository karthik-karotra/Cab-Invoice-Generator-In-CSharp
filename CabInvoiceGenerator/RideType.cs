// <copyright file="RideType.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    public class RideType
    {
        public double CostPerKms;
        public double CostPerMinute;
        public double MinimumFare;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideType"/> class.
        /// </summary>
        public RideType()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RideType"/> class.
        /// </summary>
        /// <param name="costPerKms">Cost Per Km Of Ride.</param>
        /// <param name="costPerMinute">Cost Per Minute Of Ride.</param>
        /// <param name="minimumFare">Minimum Fare Of Ride.</param>
        public RideType(double costPerKms, double costPerMinute, double minimumFare)
        {
            this.CostPerKms = costPerKms;
            this.CostPerMinute = costPerMinute;
            this.MinimumFare = minimumFare;
        }

        /// <summary>
        /// Enum Class For Ride Type.
        /// </summary>
        public enum Type
        {
            NORMAL,
            PREMIUM,
        }

        /// <summary>
        /// Function For Setting Values As Per Ride Type.
        /// </summary>
        /// <param name="type">Enum Of Ride Type.</param>
        /// <returns>Values As Per Ride Type.</returns>
        public RideType SetValuesAsPerRideType(Type type)
        {
            return type switch
            {
                Type.NORMAL => new RideType(10.0, 1.0, 5.0),
                Type.PREMIUM => new RideType(15.0, 2.0, 20.0),
                _ => null,
            };
        }
    }
}
