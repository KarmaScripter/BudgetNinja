// // <copyright file = "Authority.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

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
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            BudgetLevel = GetBudgetLevel();
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
        /// The data.
        /// </param>
        public Authority( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            Source = GetSource( Record );
            BudgetFiscalYear = GetBudgetFiscalYear();
            RPIO = GetResourcePlanningOffice();
            Fund = GetFund();
            BudgetLevel = GetBudgetLevel();
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
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Authority( DataRow data )
            : base( data )
        {
            Record = data;
            Source = GetSource( Record );
            BudgetFiscalYear = GetBudgetFiscalYear();
            RPIO = GetResourcePlanningOffice();
            Fund = GetFund();
            BudgetLevel = GetBudgetLevel();
            AllowanceHolder = GetAllowanceHolder();
            Organization = GetOrganization();
            Account = GetAccount();
            ResponsibilityCenter = GetResponsibilityCenter();
            Activity = GetActivity();
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private protected IResourcePlanningOffice RPIO { get; }

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <value>
        /// The fiscal year.
        /// </value>
        private protected IBudgetFiscalYear BudgetFiscalYear { get; set; }

        /// <summary>
        /// Gets or sets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        private protected IFund Fund { get; }

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        private protected IBudgetLevel BudgetLevel { get; }

        /// <summary>
        /// Gets or sets the allowance holder.
        /// </summary>
        /// <value>
        /// The allowance holder.
        /// </value>
        private protected IAllowanceHolder AllowanceHolder { get; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        private protected IOrganization Organization { get; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        private protected IAccount Account { get; }

        /// <summary>
        /// Gets or sets the responsibility center.
        /// </summary>
        /// <value>
        /// The responsibility center.
        /// </value>
        private protected IResponsibilityCenter ResponsibilityCenter { get; }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        private protected IActivity Activity { get; }

        /// <summary>
        /// Gets the metric.
        /// </summary>
        /// <value>
        /// The metric.
        /// </value>
        private protected IDataMetric Metric { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                    Authority.Fail( ex );
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
            if( Verify.Source( Source )
                && Verify.Map( Data ) )
            {
                try
                {
                    var builder = new Builder( Source, Data );

                    return Verify.Rows( builder?.GetData() )
                        ? builder
                        : default;
                }
                catch( Exception ex )
                {
                    Authority.Fail( ex );
                    return default;
                }
            }

            return default;
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
                Authority.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Source( Source )
                && Verify.Map( Data ) )
            {
                try
                {
                    var data = new DataBuilder( Source, Data )?.GetData();

                    return Verify.Rows( data )
                        ? data
                        : default;
                }
                catch( Exception ex )
                {
                    Authority.Fail( ex );
                    return default;
                }
            }

            return default;
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
            if( Verify.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var data = new DataBuilder( Source, Data )?.GetData();

                    var filtered = data?.Filter( field.ToString(), filter );

                    return Verify.Rows( filtered )
                        ? filtered
                        : default;
                }
                catch( Exception ex )
                {
                    Authority.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the fiscal year availability of the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        public Availability GetAvailability()
        {
            try
            {
                var bfy = BudgetFiscalYear?.GetAvailability();

                if( Verify.Element( bfy ) )
                {
                    try
                    {
                        var availability =
                            (Availability)Enum.Parse( typeof( Availability ), bfy?.GetValue() );

                        return Verify.Availability( availability )
                            ? availability
                            : default;
                    }
                    catch( Exception ex )
                    {
                        Authority.Fail( ex );
                        return default;
                    }
                }

                return default;
            }
            catch( Exception ex )
            {
                Authority.Fail( ex );
                return default;
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
                && Verify.Field( field )
                && Verify.Numeric( numeric )
                && data.HasNumeric() )
            {
                try
                {
                    return new DataMetric( data, field, numeric );
                }
                catch( Exception ex )
                {
                    Authority.Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}
