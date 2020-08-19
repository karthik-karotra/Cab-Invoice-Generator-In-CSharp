// <copyright file="CabInvoiceException.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoice Exception Class.
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="message">Excetion Messsage.</param>
        public CabInvoiceException(string message)
            : base(message)
        {
        }
    }
}
