// <copyright file="RideRepository.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Ride Repository Class To Store Cab Rides And Get Cab Rides By User Id.
    /// </summary>
    public class RideRepository
    {
        private static Dictionary<string, List<Rides>> userRideList = new Dictionary<string, List<Rides>>();

        /// <summary>
        /// Static Method For Adding Ride Details By User Id.
        /// </summary>
        /// <param name="userID">User Id Of User.</param>
        /// <param name="ride">Array Of Rides.</param>
        public static void AddRides(string userID, Rides[] ride)
        {
            bool checkList = userRideList.ContainsKey(userID);

            if (checkList == false)
            {
                userRideList.Add(userID, new List<Rides>(ride));
            }
        }

        /// <summary>
        /// Static Method To Get Cab Rides Of User By User Id.
        /// </summary>
        /// <param name="userId">User Id Of User.</param>
        /// <returns>Cab Rides Of User.</returns>
        public static Rides[] GetRides(string userId)
        {
            return userRideList[userId].ToArray();
        }
    }
}
