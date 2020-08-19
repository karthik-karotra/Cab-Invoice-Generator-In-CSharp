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
        private static readonly Dictionary<string, List<Rides>> UserRideList = new Dictionary<string, List<Rides>>();

        /// <summary>
        /// Static Method For Adding Ride Details By User Id.
        /// </summary>
        /// <param name="userID">User Id Of User.</param>
        /// <param name="ride">Array Of Rides.</param>
        public static void AddRides(string userID, Rides[] ride)
        {
            bool isUserPresent = UserRideList.ContainsKey(userID);
            if (isUserPresent)
            {
                List<Rides> lists = UserRideList[userID];
                lists.AddRange(ride);
                UserRideList[userID] = lists;
            }

            if (!isUserPresent)
            {
                UserRideList.Add(userID, new List<Rides>(ride));
            }
        }

        /// <summary>
        /// Static Method To Get Cab Rides Of User By User Id.
        /// </summary>
        /// <param name="userId">User Id Of User.</param>
        /// <returns>Cab Rides Of User.</returns>
        public static Rides[] GetRides(string userId)
        {
            return UserRideList[userId].ToArray();
        }
    }
}
