// <copyright file="WorkCode.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "WorkCodeBase"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class WorkCode : WorkCodeBase, ISource, IWorkCode
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source Source = Source.WorkCodes;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        public WorkCode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public WorkCode( IQuery query )
            : this()
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.WorkCodeId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            ShortName = new Element( Record, Field.ShortName );
            Notifications = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BBFY = new Element( Record, Field.BBFY );
            FundCode = new Element( Record, Field.FundCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            CostOrgName = new Element( Record, Field.CostOrgName );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProjectCodeName = new Element( Record, Field.ProjectName );
            ApprovalDate = DateTime.Parse( Record[ $"{Field.ApprovalDate}" ].ToString() );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public WorkCode( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.WorkCodeId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            ShortName = new Element( Record, Field.ShortName );
            Notifications = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BBFY = new Element( Record, Field.BBFY );
            FundCode = new Element( Record, Field.FundCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            CostOrgName = new Element( Record, Field.CostOrgName );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProjectCodeName = new Element( Record, Field.ProjectName );
            ApprovalDate = DateTime.Parse( Record?[ $"{Field.ApprovalDate}" ].ToString() );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public WorkCode( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.WorkCodeId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            ShortName = new Element( Record, Field.ShortName );
            Notifications = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BBFY = new Element( Record, Field.BBFY );
            FundCode = new Element( Record, Field.FundCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            CostOrgName = new Element( Record, Field.CostOrgName );
            RcCode = new Element( Record, Field.RcCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProjectCodeName = new Element( Record, Field.ProjectName );
            ApprovalDate = DateTime.Parse( Record[ $"{Field.ApprovalDate}" ].ToString() );
            Args = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Args { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Element( Code ) )
            {
                try
                {
                    return Code.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetFiscalYear GetBudgetFiscalYear()
        {
            try
            {
                return Verify.Element( BBFY )
                    ? new BudgetFiscalYear( BBFY?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFinanceObjectClass GetFinanceObjectClass()
        {
            if( Verify.Element( FocCode ) )
            {
                try
                {
                    var dict = new Dictionary<string, object>
                    {
                        [ $"{Field.FocCode}" ] = FocCode?.GetValue()
                    };

                    var connectbuilder = new ConnectionBuilder( Source.FinanceObjectClass );
                    var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                    using var query = new Query( connectbuilder, sqlstatement );
                    return new FinanceObjectClass( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFund GetFund()
        {
            try
            {
                return Verify.Element( FundCode )
                    ? new Fund( FundCode?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IOrganization GetOrganization()
        {
            if( Verify.Element( CostOrgCode ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.CostOrgCode}" ] = CostOrgCode?.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.Organizations );
                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new Organization( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAccount GetAccount()
        {
            if( Verify.Element( AccountCode ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = AccountCode?.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.Accounts );
                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new Account( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( Account );
                }
            }

            return default( Account );
        }

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResponsibilityCenter GetResponsibilityCenter()
        {
            if( Verify.Element( RcCode ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = RcCode?.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.ResponsibilityCenters );
                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new ResponsibilityCenter( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ResponsibilityCenter );
                }
            }

            return default( ResponsibilityCenter );
        }

        /// <summary>
        /// Gets the work codes.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IWorkCode> GetWorkCodes()
        {
            if( Verify.Map( Args ) )
            {
                try
                {
                    var data = new Builder( Source.WorkCodes, Args )
                        ?.GetData()
                        ?.Select( h => h );

                    if( data != null )
                    {
                        var query = data.Select( h => new WorkCode( h ) );

                        return query.Any()
                            ? query.ToArray()
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the division.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDivision GetDivision()
        {
            if( Verify.Element( RcCode ) )
            {
                try
                {
                    var rc = RcCode.GetValue();
                    return new Division( rc );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( Division );
                }
            }

            return default( Division );
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Args )
                    ? Args
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        // ***************************************************************************************************************************
        // ******************************************* INTERFACE IMPLIMENTATIONS *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Element( Code )
                    ? Code
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Element( Name )
                    ? Name
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }
    }
}