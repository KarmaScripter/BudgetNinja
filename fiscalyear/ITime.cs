// <copyright file = "ITime.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    /// <summary>
    /// Defines the interface for the budget time objects
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetName();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetValue();

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetDay();

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns>
        /// </returns>
        EventDate GetEventDate();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        string ToString();

        /// <summary>
        /// Determines whether the specified element is equal.
        /// </summary>
        /// <param name = "element" >
        /// The element.
        /// </param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified element is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        bool IsEqual( ITime element );
    }
}
