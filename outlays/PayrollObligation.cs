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
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.PayrollObligations;

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
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _fundCode = new Element( _records, Field.FundCode );
            _ahCode = new Element( _records, Field.AhCode );
            _orgCode = new Element( _records, Field.OrgCode );
            _rcCode = new Element( _records, Field.RcCode );
            _accountCode = new Element( _records, Field.AccountCode );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _hrOrgCode = new Element( _records, Field.HrOrgCode );
            _workCode = new Element( _records, Field.WorkCode );
            _focCode = new Element( _records, Field.FocCode );
            _payPeriod = new Element( _records, Field.PayPeriod );
            _amount = new Amount( _records, Numeric.Amount );
            _hours = new Amount( _records, Numeric.Hours );
            _allocationPercentage = new Amount( _records, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _records, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _records, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _records, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _records, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _records, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _records, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _records, Numeric.AnnualOvertimePaid );
            _data = _records?.ToDictionary();
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
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _fundCode = new Element( _records, Field.FundCode );
            _ahCode = new Element( _records, Field.AhCode );
            _orgCode = new Element( _records, Field.OrgCode );
            _rcCode = new Element( _records, Field.RcCode );
            _accountCode = new Element( _records, Field.AccountCode );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _hrOrgCode = new Element( _records, Field.HrOrgCode );
            _workCode = new Element( _records, Field.WorkCode );
            _focCode = new Element( _records, Field.FocCode );
            _payPeriod = new Element( _records, Field.PayPeriod );
            _amount = new Amount( _records, Numeric.Amount );
            _hours = new Amount( _records, Numeric.Hours );
            _allocationPercentage = new Amount( _records, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _records, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _records, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _records, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _records, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _records, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _records, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _records, Numeric.AnnualOvertimePaid );
            _type = OutlayType.Obligation;
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public PayrollObligation( DataRow datarow )
        {
            _records = datarow;
            _id = new Key( _records, PrimaryKey.PayrollObligationId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _fundCode = new Element( _records, Field.FundCode );
            _ahCode = new Element( _records, Field.AhCode );
            _orgCode = new Element( _records, Field.OrgCode );
            _rcCode = new Element( _records, Field.RcCode );
            _accountCode = new Element( _records, Field.AccountCode );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _hrOrgCode = new Element( _records, Field.HrOrgCode );
            _workCode = new Element( _records, Field.WorkCode );
            _focCode = new Element( _records, Field.FocCode );
            _payPeriod = new Element( _records, Field.PayPeriod );
            _amount = new Amount( _records, Numeric.Amount );
            _hours = new Amount( _records, Numeric.Hours );
            _allocationPercentage = new Amount( _records, Numeric.AllocationPercentage );
            _annualBaseHours = new Amount( _records, Numeric.AnnualBaseHours );
            _annualBasePaid = new Amount( _records, Numeric.AnnualBasePaid );
            _cumulativeBenefits = new Amount( _records, Numeric.CumulativeBenefits );
            _annualOtherHours = new Amount( _records, Numeric.AnnualOtherHours );
            _annualOtherPaid = new Amount( _records, Numeric.AnnualOtherPaid );
            _annualOvertimeHours = new Amount( _records, Numeric.AnnualOvertimePaid );
            _annualOvertimePaid = new Amount( _records, Numeric.AnnualOvertimePaid );
            _type = OutlayType.Obligation;
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the human resource organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetHrOrgCode()
        {
            try
            {
                return Verify.Input( _hrOrgCode?.GetValue() )
                    ? _hrOrgCode
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
