// <copyright file = "WorkCode.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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
        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; } = Source.WorkCodes;
        
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
            Notification = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BFY = new Element( Record, Field.BBFY );
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
            Notification = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BFY = new Element( Record, Field.BBFY );
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
        /// The Data.
        /// </param>
        public WorkCode( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.WorkCodeId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            ShortName = new Element( Record, Field.ShortName );
            Notification = new Element( Record, Field.Notifications );
            Status = new Element( Record, Field.Status );
            PayPeriod = new Element( Record, Field.PayPeriod );
            BFY = new Element( Record, Field.BBFY );
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
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Args { get; set; }
        
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
                return Verify.Element( BFY )
                    ? new BudgetFiscalYear( BFY?.GetValue() )
                    : default( BudgetFiscalYear );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetFiscalYear );
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
                    var _dict = new Dictionary<string, object>
                    {
                        [ $"{Field.FocCode}" ] = FocCode?.GetValue()
                    };

                    var _builder = new ConnectionBuilder( Source.FinanceObjectClass );
                    var _statement = new SqlStatement( _builder, _dict, SQL.SELECT );
                    using var _query = new Query( _builder, _statement );
                    return new FinanceObjectClass( _query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IFinanceObjectClass );
                }
            }

            return default( IFinanceObjectClass );
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
                    : default( Fund );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IFund );
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
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.CostOrgCode}" ] = CostOrgCode?.GetValue()
                    };

                    var _builder = new ConnectionBuilder( Source.Organizations );
                    var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                    using var _query = new Query( _builder, _statement );
                    return new Organization( _query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IOrganization );
                }
            }

            return default( IOrganization );
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
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = AccountCode?.GetValue()
                    };

                    var _builder = new ConnectionBuilder( Source.Accounts );
                    var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                    using var _query = new Query( _builder, _statement );
                    return new Account( _query );
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
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = RcCode?.GetValue()
                    };

                    var _builder = new ConnectionBuilder( Source.ResponsibilityCenters );
                    var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                    using var _query = new Query( _builder, _statement );
                    return new ResponsibilityCenter( _query );
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
                    var _data = new Builder( Source.WorkCodes, Args )
                        ?.GetData()
                        ?.Select( h => h );

                    var _query = _data
                        ?.Select( h => new WorkCode( h ) );

                    return _query?.Any() == true
                        ? _query.ToArray()
                        : default( WorkCode[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IWorkCode> );
                }
            }

            return default( IEnumerable<IWorkCode> );
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
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
        
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( Source )
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
