// <copyright file = "Authority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// Budget authority  is  the  authority  provided  in  law  to  enter into legal
    /// obligations that will result in immediate or future outlays of the Government.
    /// In other words, it is the amount of money that agencies are allowed to commit
    /// to  be  spent  in  current  or  future  years.  Government  officials may
    /// obligate the Government to make outlays only to the extent they have been
    /// granted budget authority. The  budget  records  new  budget  authority  as  a
    /// dollar  amount in the year when it first becomes available for obligation. When
    /// permitted by law, unobligated balances of budget authority may be carried over
    /// and used in the next year. The budget does not record these balances as budget
    /// authority again. They do, however, constitute a budgetary resource  that  is
    /// available  for  obligation.
    /// 
    /// </summary>
    /// <seealso/>
    /// <seealso cref = "IBudgetFiscalYear"/>
    /// <seealso cref = "IDataBuilder"/>
    [ SuppressMessage( "ReSharper", "ArrangeModifiersOrder" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "AccessToStaticMemberViaDerivedType" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Authority : ProgramResultsCode, IAuthority
    {
        /// <summary>
        /// Gets or sets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private protected IResourcePlanningOffice _rpio;

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <value>
        /// The fiscal year.
        /// </value>
        private protected IBudgetFiscalYear _budgetFiscalYear;

        /// <summary>
        /// Gets or sets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        private protected IFund _fund;

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        private protected readonly IBudgetLevel _budgetLevel;

        /// <summary>
        /// Gets or sets the allowance holder.
        /// </summary>
        /// <value>
        /// The allowance holder.
        /// </value>
        private protected IAllowanceHolder _allowanceHolder;

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        private protected IOrganization _organization;

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        private protected IAccount _account;

        /// <summary>
        /// Gets or sets the responsibility center.
        /// </summary>
        /// <value>
        /// The responsibility center.
        /// </value>
        private protected IResponsibilityCenter _responsibilityCenter;

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        private protected IActivity _activity;

        /// <summary>
        /// Gets the metric.
        /// </summary>
        /// <value>
        /// The metric.
        /// </value>
        private protected IDataMetric _metric;

        /// <summary>
        /// The source
        /// </summary>
        private readonly Source _source;

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        public Authority()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Authority( IQuery query )
            : base( query )
        {
            _source = query.GetSource();
            _records = new DataBuilder( query )?.GetRecord();
            _budgetFiscalYear = GetBudgetFiscalYear();
            _rpio = GetResourcePlanningOffice();
            _fund = GetFund();
            _budgetLevel = GetBudgetLevel();
            _allowanceHolder = GetAllowanceHolder();
            _organization = GetOrganization();
            _account = GetAccount();
            _responsibilityCenter = GetResponsibilityCenter();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The dataRow.
        /// </param>
        public Authority( IBuilder builder )
            : base( builder )
        {
            _records = builder?.GetRecord();
            _source = GetSource( _records );
            _budgetFiscalYear = GetBudgetFiscalYear();
            _rpio = GetResourcePlanningOffice();
            _fund = GetFund();
            _budgetLevel = GetBudgetLevel();
            _allowanceHolder = GetAllowanceHolder();
            _organization = GetOrganization();
            _account = GetAccount();
            _responsibilityCenter = GetResponsibilityCenter();
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Authority( DataRow dataRow )
            : base( dataRow )
        {
            _records = dataRow;
            _source = GetSource( _records );
            _budgetFiscalYear = GetBudgetFiscalYear();
            _rpio = GetResourcePlanningOffice();
            _fund = GetFund();
            _budgetLevel = GetBudgetLevel();
            _allowanceHolder = GetAllowanceHolder();
            _organization = GetOrganization();
            _account = GetAccount();
            _responsibilityCenter = GetResponsibilityCenter();
            _activity = GetActivity();
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Source GetSource( DataRow dataRow )
        {
            if( Verify.Row( dataRow ) )
            {
                try
                {
                    var _name = dataRow
                        ?.Table
                        ?.TableName;

                    if( Verify.Input( _name ) )
                    {
                        var _value = (Source)Enum.Parse( typeof( Source ), _name );

                        if( Enum.IsDefined( typeof( Source ), _value ) )
                        {
                            return _value;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Source.NS;
                }
            }

            return Source.NS;
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBuilder GetBuilder()
        {
            if( Validate.Source( _source )
                && Verify.Map( _data ) )
            {
                try
                {
                    var _builder = new Builder( _source, _data );

                    return Verify.Rows( _builder?.GetData() )
                        ? _builder
                        : default( Builder );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IBuilder );
                }
            }

            return default( IBuilder );
        }

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAllocation GetAllocation()
        {
            try
            {
                return new Allocation( this );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAllocation );
            }
        }

        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Validate.Source( _source )
                && Verify.Map( _data ) )
            {
                try
                {
                    var _rows = new DataBuilder( _source, _data )
                        ?.GetData();

                    return Verify.Rows( _rows )
                        ? _rows
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "filter" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> FilterData( Field field, string filter )
        {
            if( Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var _rows = new DataBuilder( _source, _data )
                        ?.GetData();

                    var _filter = _rows
                        ?.Filter( field.ToString(), filter );

                    return Verify.Rows( _filter )
                        ? _filter
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the fiscal year availability of the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        public FundAvailability GetAvailability()
        {
            try
            {
                var _element = _budgetFiscalYear
                    ?.GetAvailability();

                if( Verify.Element( _element ) )
                {
                    try
                    {
                        var _availability =
                            (FundAvailability)Enum.Parse( typeof( FundAvailability ), _element?.GetValue() );

                        return Validate.Availability( _availability )
                            ? _availability
                            : default( FundAvailability );
                    }
                    catch( Exception ex )
                    {
                        Fail( ex );
                        return default( FundAvailability );
                    }
                }

                return default( FundAvailability );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FundAvailability );
            }
        }

        /// <summary>
        /// Gets the metric.
        /// </summary>
        /// <param name = "dataRow" >
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// </param>
        /// <returns>
        /// </returns>
        public IDataMetric GetMetric( IEnumerable<DataRow> dataRow, Field field, Numeric numeric = Numeric.Amount )
        {
            if( Verify.Rows( dataRow )
                && Validate.Field( field )
                && Validate.Numeric( numeric )
                && dataRow.HasNumeric() )
            {
                try
                {
                    return new DataMetric( dataRow, field, numeric );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDataMetric );
                }
            }

            return default( IDataMetric );
        }
    }
}
