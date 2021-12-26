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
    public class Authority : ProgramResultsCode 
    {
        /// <summary>
        /// Gets or sets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        public IResourcePlanningOffice RPIO { get; } 

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <value>
        /// The fiscal year.
        /// </value>
        public IBudgetFiscalYear BudgetFiscalYear { get; set; }

        /// <summary>
        /// Gets or sets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        public IFund Fund { get; } 
        
        /// <summary>
        /// Gets or sets the allowance holder.
        /// </summary>
        /// <value>
        /// The allowance holder.
        /// </value>
        public IAllowanceHolder AllowanceHolder { get; } 

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public IOrganization Organization { get; } 

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public IAccount Account { get; } 

        /// <summary>
        /// Gets or sets the responsibility center.
        /// </summary>
        /// <value>
        /// The responsibility center.
        /// </value>
        public IResponsibilityCenter ResponsibilityCenter { get; } 

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        public IActivity Activity { get; }

        /// <summary>
        /// The source
        /// </summary>
        public new Source Source { get; } = Source.Allocations;

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
            Source = query.GetSource();
            Record = new DataBuilder( query )?.GetRecord();
            BudgetFiscalYear = GetBudgetFiscalYear();
            RPIO = GetResourcePlanningOffice();
            Fund = GetFund();
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            AllowanceHolder = GetAllowanceHolder();
            Organization = GetOrganization();
            Account = GetAccount();
            ResponsibilityCenter = GetResponsibilityCenter();
            Data = Record?.ToDictionary();
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
            Record = builder?.GetRecord();
            Source = GetSource( Record );
            BudgetFiscalYear = GetBudgetFiscalYear();
            RPIO = GetResourcePlanningOffice();
            Fund = GetFund();
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            AllowanceHolder = GetAllowanceHolder();
            Organization = GetOrganization();
            Account = GetAccount();
            ResponsibilityCenter = GetResponsibilityCenter();
            Amount = GetAmount();
            Data = Record?.ToDictionary();
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
            Record = dataRow;
            Source = GetSource( Record );
            BudgetFiscalYear = GetBudgetFiscalYear();
            RPIO = GetResourcePlanningOffice();
            Fund = GetFund();
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            AllowanceHolder = GetAllowanceHolder();
            Organization = GetOrganization();
            Account = GetAccount();
            ResponsibilityCenter = GetResponsibilityCenter();
            Activity = Account.GetActivity();
            Amount = GetAmount();
            Data = Record?.ToDictionary();
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
            if( Validate.Source( Source )
                && Verify.Map( Data ) )
            {
                try
                {
                    var _builder = new Builder( Source, Data );

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
        /// Gets the dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Validate.Source( Source )
                && Verify.Map( Data ) )
            {
                try
                {
                    var _rows = new DataBuilder( Source, Data )
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
                    var _rows = new DataBuilder( Source, Data )
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
                var _element = BudgetFiscalYear
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
