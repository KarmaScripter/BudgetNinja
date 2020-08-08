// <copyright file="Leave.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Threading;

    /// <summary>
    /// Defines the <see cref = "LeaveBase"/> .
    /// </summary>
    /// <seealso cref = "IPerson"/>
    /// <seealso cref = "ILeave"/>
    public abstract class LeaveBase : Employee
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source.
        /// </summary>
        private protected override Source Source { get; set; } = Source.LeaveProjections;

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the LeaveProjectionId Gets the LeaveProjectionId Gets the
        /// LeaveProjectionId Gets or sets the PrimaryKey of the LeaveProjections
        /// DataTable..
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the RpioCode Gets the RpioCode Gets the RpioCode.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private protected IElement RpioCode { get; set; }

        /// <summary>
        /// Gets or sets the HumanResourceOrganizationCode Gets the
        /// HumanResourceOrganizationCode.
        /// </summary>
        /// <value>
        /// The human resource organization code.
        /// </value>
        private protected IElement HumanResourceOrganizationCode { get; set; }

        /// <summary>
        /// Gets or sets the HumanResourceOrganizationName Gets the
        /// HumanResourceOrganizationName.
        /// </summary>
        /// <value>
        /// The name of the human resource organization.
        /// </value>
        private protected IElement HumanResourceOrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the YearToDateEarned Gets the YearToDateEarned.
        /// </summary>
        /// <value>
        /// The year to date earned.
        /// </value>
        private protected IAmount YearToDateEarned { get; set; }

        /// <summary>
        /// Gets or sets the WorkCode Gets the WorkCode Gets the WorkCode.
        /// </summary>
        /// <value>
        /// The work code.
        /// </value>
        private protected IElement WorkCode { get; set; }

        /// <summary>
        /// Gets or sets the YearToDateUsed Gets the YearToDateUsed Gets or sets the
        /// YearToDateUsed.
        /// </summary>
        /// <value>
        /// The year to date used.
        /// </value>
        private protected IAmount YearToDateUsed { get; set; }

        /// <summary>
        /// Gets or sets the MaxLeaveCarryover Gets the MaxLeaveCarryover Gets the
        /// MaxLeaveCarryover Gets or sets the MaxLeaveCarryover.
        /// </summary>
        /// <value>
        /// The maximum leave carryover.
        /// </value>
        private protected IAmount MaxLeaveCarryover { get; set; }

        /// <summary>
        /// Gets or sets the UseOrLose Gets the UseOrLose Gets or sets the UseOrLose.
        /// </summary>
        /// <value>
        /// The use or lose.
        /// </value>
        private protected IAmount UseOrLose { get; set; }

        /// <summary>
        /// Gets or sets the ProjectedPayPeriod Gets the ProjectedPayPeriod.
        /// </summary>
        /// <value>
        /// The projected pay period.
        /// </value>
        private protected IAmount ProjectedPayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the ProjectedAnnual Gets the ProjectedAnnual
        /// <see cref = "ProjectedAnnual"/> .
        /// </summary>
        /// <value>
        /// The projected annual.
        /// </value>
        private protected IAmount ProjectedAnnual { get; set; }

        /// <summary>
        /// Gets or sets the AvailableHours Gets the AvailableHours Gets the AvailableHours
        /// Gets or sets the <see cref = "AvailableHours"/> .
        /// </summary>
        /// <value>
        /// The available hours.
        /// </value>
        private protected IAmount AvailableHours { get; set; }

        /// <summary>
        /// Gets or sets the annual hours.
        /// </summary>
        /// <value>
        /// The annual hours.
        /// </value>
        private protected IAmount AnnualHours { get; set; }
    }
}