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
            _record = new DataBuilder( query )?.GetRecord();
            _budgetFiscalYear = GetBudgetFiscalYear();
            _rpio = GetResourcePlanningOffice();
            _fund = GetFund();
            _budgetLevel = GetBudgetLevel();
            _allowanceHolder = GetAllowanceHolder();
            _organization = GetOrganization();
            _account = GetAccount();
            _responsibilityCenter = GetResponsibilityCenter();
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The data.
        /// </param>
        public Authority( IBuilder builder )
            : base( builder )
        {
            _record = builder?.GetRecord();
            _source = GetSource( _record );
            _budgetFiscalYear = GetBudgetFiscalYear();
            _rpio = GetResourcePlanningOffice();
            _fund = GetFund();
            _budgetLevel = GetBudgetLevel();
            _allowanceHolder = GetAllowanceHolder();
            _organization = GetOrganization();
            _account = GetAccount();
            _responsibilityCenter = GetResponsibilityCenter();
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Authority( DataRow data )
            : base( data )
        {
            _record = data;
            _source = GetSource( _record );
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
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Source GetSource( DataRow data )
        {
            if( Verify.Row( data ) )
            {
                try
                {
                    var name = data?.Table?.TableName;

                    if( Verify.Input( name ) )
                    {
                        var source = (Source)Enum.Parse( typeof( Source ), name );

                        if( Enum.IsDefined( typeof( Source ), source ) )
                        {
                            return source;
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
                    var builder = new Builder( _source, _data );

                    return Verify.Rows( builder?.GetData() )
                        ? builder
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
        /// Gets the data.
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
                    var data = new DataBuilder( _source, _data )?.GetData();

                    return Verify.Rows( data )
                        ? data
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
        /// Gets the data.
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
                    var data = new DataBuilder( _source, _data )?.GetData();
                    var filtered = data?.Filter( field.ToString(), filter );

                    return Verify.Rows( filtered )
                        ? filtered
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
                var bfy = _budgetFiscalYear?.GetAvailability();

                if( Verify.Element( bfy ) )
                {
                    try
                    {
                        var availability =
                            (FundAvailability)Enum.Parse( typeof( FundAvailability ), bfy?.GetValue() );

                        return Validate.Availability( availability )
                            ? availability
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
        /// <param name = "data" >
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// </param>
        /// <returns>
        /// </returns>
        public IDataMetric GetMetric( IEnumerable<DataRow> data, Field field,
            Numeric numeric = Numeric.Amount )
        {
            if( Verify.Rows( data )
                && Validate.Field( field )
                && Validate.Numeric( numeric )
                && data.HasNumeric() )
            {
                try
                {
                    return new DataMetric( data, field, numeric );
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
