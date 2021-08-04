// <copyright file = "LeaveBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary>
    /// Defines the <see cref = "LeaveBase"/> .
    /// </summary>
    /// <seealso cref = "IPerson"/>
    /// <seealso cref = "ILeave"/>
    public abstract class LeaveBase : Employee
    {
        /// <summary>
        /// The source.
        /// </summary>
        private protected Source _source = Source.LeaveProjections;
        
        /// <summary>
        /// Gets or sets the RpioCode Gets the RpioCode Gets the RpioCode.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private protected IElement _rpioCode;

        /// <summary>
        /// Gets or sets the HumanResourceOrganizationCode Gets the
        /// HumanResourceOrganizationCode.
        /// </summary>
        /// <value>
        /// The human resource organization code.
        /// </value>
        private protected IElement _humanResourceOrganizationCode;

        /// <summary>
        /// Gets or sets the HumanResourceOrganizationName Gets the
        /// HumanResourceOrganizationName.
        /// </summary>
        /// <value>
        /// The name of the human resource organization.
        /// </value>
        private protected IElement _humanResourceOrganizationName;

        /// <summary>
        /// Gets or sets the YearToDateEarned Gets the YearToDateEarned.
        /// </summary>
        /// <value>
        /// The year to date earned.
        /// </value>
        private protected IAmount _yearToDateEarned;

        /// <summary>
        /// Gets or sets the WorkCode Gets the WorkCode Gets the WorkCode.
        /// </summary>
        /// <value>
        /// The work code.
        /// </value>
        private protected IElement _workCode;

        /// <summary>
        /// Gets or sets the YearToDateUsed Gets the YearToDateUsed Gets or sets the
        /// YearToDateUsed.
        /// </summary>
        /// <value>
        /// The year to date used.
        /// </value>
        private protected IAmount _yearToDateUsed;

        /// <summary>
        /// Gets or sets the MaxLeaveCarryover Gets the MaxLeaveCarryover Gets the
        /// MaxLeaveCarryover Gets or sets the MaxLeaveCarryover.
        /// </summary>
        /// <value>
        /// The maximum leave carryover.
        /// </value>
        private protected IAmount _maxLeaveCarryover;

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
        private protected IAmount _projectedPayPeriod;

        /// <summary>
        /// Gets or sets the ProjectedAnnual Gets the ProjectedAnnual
        /// <see cref = "_projectedAnnual"/> .
        /// </summary>
        /// <value>
        /// The projected annual.
        /// </value>
        private protected IAmount _projectedAnnual;

        /// <summary>
        /// Gets or sets the AvailableHours Gets the AvailableHours Gets the AvailableHours
        /// Gets or sets the <see cref = "_availableHours"/> .
        /// </summary>
        /// <value>
        /// The available hours.
        /// </value>
        private protected IAmount _availableHours;

        /// <summary>
        /// Gets or sets the annual hours.
        /// </summary>
        /// <value>
        /// The annual hours.
        /// </value>
        private protected IAmount _annualHours;
    }
}
