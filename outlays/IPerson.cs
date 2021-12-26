// <copyright file = "IPerson.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public interface IPerson
    {
        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFirstName();

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetLastName();

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmployeeNumber();
    }
}
