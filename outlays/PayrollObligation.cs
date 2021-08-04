// <copyright file = "PayrollObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class PayrollObligation : Obligation
    {
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
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _ahCode = new Element( _record, Field.AhCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            HrOrgCode = new Element( _record, Field.HrOrgCode );
            WorkCode = new Element( _record, Field.WorkCode );
            FocCode = new Element( _record, Field.FocCode );
            PayPeriod = new Element( _record, Field.PayPeriod );
            _amount = new Amount( _record, Numeric.Amount );
            _hours = new Amount( _record, Numeric.Hours );
            _allocationPercentage = new Amount( _record, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _record, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _record, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _record, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _record, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _record, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _record, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _record, Numeric.AnnualOvertimePaid );
            _data = _record?.ToDictionary();
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
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _ahCode = new Element( _record, Field.AhCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            HrOrgCode = new Element( _record, Field.HrOrgCode );
            WorkCode = new Element( _record, Field.WorkCode );
            FocCode = new Element( _record, Field.FocCode );
            PayPeriod = new Element( _record, Field.PayPeriod );
            _amount = new Amount( _record, Numeric.Amount );
            _hours = new Amount( _record, Numeric.Hours );
            _allocationPercentage = new Amount( _record, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _record, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _record, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _record, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _record, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _record, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _record, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _record, Numeric.AnnualOvertimePaid );
            Type = OutlayType.Obligation;
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public PayrollObligation( DataRow datarow )
        {
            _record = datarow;
            _id = new Key( _record, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _ahCode = new Element( _record, Field.AhCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            HrOrgCode = new Element( _record, Field.HrOrgCode );
            WorkCode = new Element( _record, Field.WorkCode );
            FocCode = new Element( _record, Field.FocCode );
            PayPeriod = new Element( _record, Field.PayPeriod );
            _amount = new Amount( _record, Numeric.Amount );
            _hours = new Amount( _record, Numeric.Hours );
            _allocationPercentage = new Amount( _record, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _record, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _record, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _record, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _record, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _record, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _record, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _record, Numeric.AnnualOvertimePaid );
            Type = OutlayType.Obligation;
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected new Source _source = Source.PayrollObligations;

        /// <summary>
        /// Gets the allocation percentage.
        /// </summary>
        /// <value>
        /// The allocation percentage.
        /// </value>
        private readonly IAmount _allocationPercentage;

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <value>
        /// The hours.
        /// </value>
        private readonly IAmount _hours;

        /// <summary>
        /// Gets the annual base paid.
        /// </summary>
        /// <value>
        /// The annual base paid.
        /// </value>
        private readonly IAmount _annualBasePaid;

        /// <summary>
        /// Gets the annual base hours.
        /// </summary>
        /// <value>
        /// The annual base hours.
        /// </value>
        private readonly IAmount _annualBaseHours;

        /// <summary>
        /// Gets the cumulative benefits.
        /// </summary>
        /// <value>
        /// The cumulative benefits.
        /// </value>
        private readonly IAmount _cumulativeBenefits;

        /// <summary>
        /// Gets the annual other hours.
        /// </summary>
        /// <value>
        /// The annual other hours.
        /// </value>
        private readonly IAmount _annualOtherHours;

        /// <summary>
        /// Gets the annual other paid.
        /// </summary>
        /// <value>
        /// The annual other paid.
        /// </value>
        private readonly IAmount _annualOtherPaid;

        /// <summary>
        /// Gets the annual overtime paid.
        /// </summary>
        /// <value>
        /// The annual overtime paid.
        /// </value>
        private readonly IAmount _annualOvertimePaid;

        /// <summary>
        /// Gets the annual overtime hours.
        /// </summary>
        /// <value>
        /// The annual overtime hours.
        /// </value>
        private readonly IAmount _annualOvertimeHours;
        
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
                    : default( IElement );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( IElement );
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
                return _annualBasePaid?.GetFunding() > -1.0
                    ? _annualBasePaid
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _annualBaseHours.GetFunding() > -1.0
                    ? _annualBaseHours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _cumulativeBenefits.GetFunding() > -1.0
                    ? _cumulativeBenefits
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _annualOtherHours?.GetFunding() > -1.0
                    ? _annualOtherHours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _annualOtherPaid?.GetFunding() > -1.0
                    ? _annualOtherPaid
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _annualOvertimeHours?.GetFunding() > -1.0
                    ? _annualOvertimeHours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _annualOvertimePaid?.GetFunding() > -1.0
                    ? _annualOvertimePaid
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _allocationPercentage?.GetFunding() > -0.001
                    ? _allocationPercentage
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _hours?.GetFunding() > -1.0
                    ? _hours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return _amount?.GetFunding() > -1
                    ? _amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
