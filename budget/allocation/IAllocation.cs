// // <copyright file = "IAllocation.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public interface IAllocation : IAuthority
    {
        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        IAuthority GetAuthority();

        /// <summary>
        /// Gets the funds.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<IFund> GetFunds();

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns>
        /// </returns>
        IBuilder GetBuilder();

        /// <summary>
        /// Gets the ProgramResultsCode allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<IProgramResultsCode> GetProgramResultsCodes();

        /// <summary>
        /// Gets the full time equivalents.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<IProgramResultsCode> GetFullTimeEquivalents();

        /// <summary>
        /// Gets the awards.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<ISupplemental> GetAwards();

        /// <summary>
        /// Gets the time off.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<ISupplemental> GetTimeOff();

        /// <summary>
        /// Gets the over time.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<ISupplemental> GetOverTime();
    }
}
