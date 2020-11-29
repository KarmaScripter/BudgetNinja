// <copyright file = "PayrollObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public class PayrollObligation : Obligation
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <inheritdoc/>
        public PayrollObligation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public PayrollObligation( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PayrollObligationId );
            RpioCode = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            AhCode = new Element( Record, Field.AhCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            HrOrgCode = new Element( Record, Field.HrOrgCode );
            WorkCode = new Element( Record, Field.WorkCode );
            FocCode = new Element( Record, Field.FocCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            Amount = new Amount( Record, Numeric.Amount );
            Hours = new Amount( Record, Numeric.Hours );
            AllocationPercentage = new Amount( Record, Numeric.AllocationPercentage );
            AnnualBaseHours = new Amount( Record, Numeric.AnnualBaseHours );
            AnnualBasePaid = new Amount( Record, Numeric.AnnualBasePaid );
            CumulativeBenefits = new Amount( Record, Numeric.CumulativeBenefits );
            AnnualOtherHours = new Amount( Record, Numeric.AnnualOtherHours );
            AnnualOtherPaid = new Amount( Record, Numeric.AnnualOtherPaid );
            AnnualOvertimeHours = new Amount( Record, Numeric.AnnualOvertimePaid );
            AnnualOvertimePaid = new Amount( Record, Numeric.AnnualOvertimePaid );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PayrollObligation( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.PayrollObligationId );
            RpioCode = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            AhCode = new Element( Record, Field.AhCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            HrOrgCode = new Element( Record, Field.HrOrgCode );
            WorkCode = new Element( Record, Field.WorkCode );
            FocCode = new Element( Record, Field.FocCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            Amount = new Amount( Record, Numeric.Amount );
            Hours = new Amount( Record, Numeric.Hours );
            AllocationPercentage = new Amount( Record, Numeric.AllocationPercentage );
            AnnualBaseHours = new Amount( Record, Numeric.AnnualBaseHours );
            AnnualBasePaid = new Amount( Record, Numeric.AnnualBasePaid );
            CumulativeBenefits = new Amount( Record, Numeric.CumulativeBenefits );
            AnnualOtherHours = new Amount( Record, Numeric.AnnualOtherHours );
            AnnualOtherPaid = new Amount( Record, Numeric.AnnualOtherPaid );
            AnnualOvertimeHours = new Amount( Record, Numeric.AnnualOvertimePaid );
            AnnualOvertimePaid = new Amount( Record, Numeric.AnnualOvertimePaid );
            Type = OutlayType.Obligation;
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public PayrollObligation( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.PayrollObligationId );
            RpioCode = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            AhCode = new Element( Record, Field.AhCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            HrOrgCode = new Element( Record, Field.HrOrgCode );
            WorkCode = new Element( Record, Field.WorkCode );
            FocCode = new Element( Record, Field.FocCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            Amount = new Amount( Record, Numeric.Amount );
            Hours = new Amount( Record, Numeric.Hours );
            AllocationPercentage = new Amount( Record, Numeric.AllocationPercentage );
            AnnualBaseHours = new Amount( Record, Numeric.AnnualBaseHours );
            AnnualBasePaid = new Amount( Record, Numeric.AnnualBasePaid );
            CumulativeBenefits = new Amount( Record, Numeric.CumulativeBenefits );
            AnnualOtherHours = new Amount( Record, Numeric.AnnualOtherHours );
            AnnualOtherPaid = new Amount( Record, Numeric.AnnualOtherPaid );
            AnnualOvertimeHours = new Amount( Record, Numeric.AnnualOvertimePaid );
            AnnualOvertimePaid = new Amount( Record, Numeric.AnnualOvertimePaid );
            Type = OutlayType.Obligation;
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.PayrollObligations;

        /// <summary>
        /// Gets the payroll obligation identifier.
        /// </summary>
        /// <value>
        /// The payroll obligation identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected override IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets the allocation percentage.
        /// </summary>
        /// <value>
        /// The allocation percentage.
        /// </value>
        private IAmount AllocationPercentage { get; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <value>
        /// The hours.
        /// </value>
        private IAmount Hours { get; }

        /// <summary>
        /// Gets the annual base paid.
        /// </summary>
        /// <value>
        /// The annual base paid.
        /// </value>
        private IAmount AnnualBasePaid { get; }

        /// <summary>
        /// Gets the annual base hours.
        /// </summary>
        /// <value>
        /// The annual base hours.
        /// </value>
        private IAmount AnnualBaseHours { get; }

        /// <summary>
        /// Gets the cumulative benefits.
        /// </summary>
        /// <value>
        /// The cumulative benefits.
        /// </value>
        private IAmount CumulativeBenefits { get; }

        /// <summary>
        /// Gets the annual other hours.
        /// </summary>
        /// <value>
        /// The annual other hours.
        /// </value>
        private IAmount AnnualOtherHours { get; }

        /// <summary>
        /// Gets the annual other paid.
        /// </summary>
        /// <value>
        /// The annual other paid.
        /// </value>
        private IAmount AnnualOtherPaid { get; }

        /// <summary>
        /// Gets the annual overtime paid.
        /// </summary>
        /// <value>
        /// The annual overtime paid.
        /// </value>
        private IAmount AnnualOvertimePaid { get; }

        /// <summary>
        /// Gets the annual overtime hours.
        /// </summary>
        /// <value>
        /// The annual overtime hours.
        /// </value>
        private IAmount AnnualOvertimeHours { get; }

        // ********************************************************************************************************************************
        // ************************************************  METHODS   ********************************************************************
        // ********************************************************************************************************************************

        /// <summary>
        /// Gets the human resource organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetHrOrgCode()
        {
            try
            {
                return Verify.Input( HrOrgCode?.GetValue() )
                    ? HrOrgCode
                    : default;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual base paid.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualBasePaid()
        {
            try
            {
                return AnnualBasePaid?.GetFunding() > -1.0
                    ? AnnualBasePaid
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual base hours.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualBaseHours()
        {
            try
            {
                return AnnualBaseHours.GetFunding() > -1.0
                    ? AnnualBaseHours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the cumulative benefits.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetCumulativeBenefits()
        {
            try
            {
                return CumulativeBenefits.GetFunding() > -1.0
                    ? CumulativeBenefits
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual other hours.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualOtherHours()
        {
            try
            {
                return AnnualOtherHours?.GetFunding() > -1.0
                    ? AnnualOtherHours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual other paid.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualOtherPaid()
        {
            try
            {
                return AnnualOtherPaid?.GetFunding() > -1.0
                    ? AnnualOtherPaid
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual overtime hours.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualOvertimeHours()
        {
            try
            {
                return AnnualOvertimeHours?.GetFunding() > -1.0
                    ? AnnualOvertimeHours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the annual overtime paid.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAnnualOvertimePaid()
        {
            try
            {
                return AnnualOvertimePaid?.GetFunding() > -1.0
                    ? AnnualOvertimePaid
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the allocation percentage.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAllocationPercentage()
        {
            try
            {
                return AllocationPercentage?.GetFunding() > -0.001
                    ? AllocationPercentage
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetHours()
        {
            try
            {
                return Hours?.GetFunding() > -1.0
                    ? Hours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Amount?.GetFunding() > -1
                    ? Amount
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
