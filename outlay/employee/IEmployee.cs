// // <copyright file = "IEmployee.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IPerson"/>
    public interface IEmployee : IPerson
    {
        /// <summary>
        /// Gets the employee identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetSection();

        /// <summary>
        /// Gets the office.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetOffice();

        /// <summary>
        /// Gets the phone.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPhoneNumber();

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetCellNumber();

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmail();

        /// <summary>
        /// Gets the employement status.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmployementStatus();
    }
}
