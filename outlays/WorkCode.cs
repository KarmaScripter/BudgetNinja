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
        private readonly static Source _source = Source.WorkCodes;

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
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.WorkCodeId );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _shortName = new Element( _record, Field.ShortName );
            _notifications = new Element( _record, Field.Notifications );
            _status = new Element( _record, Field.Status );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _bbfy = new Element( _record, Field.BBFY );
            _fundCode = new Element( _record, Field.FundCode );
            _focCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _costOrgName = new Element( _record, Field.CostOrgName );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectCodeName = new Element( _record, Field.ProjectName );
            _approvalDate = DateTime.Parse( _record[ $"{Field.ApprovalDate}" ].ToString() );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public WorkCode( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.WorkCodeId );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _shortName = new Element( _record, Field.ShortName );
            _notifications = new Element( _record, Field.Notifications );
            _status = new Element( _record, Field.Status );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _bbfy = new Element( _record, Field.BBFY );
            _fundCode = new Element( _record, Field.FundCode );
            _focCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _costOrgName = new Element( _record, Field.CostOrgName );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectCodeName = new Element( _record, Field.ProjectName );
            _approvalDate = DateTime.Parse( _record?[ $"{Field.ApprovalDate}" ].ToString() );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WorkCode"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public WorkCode( DataRow data )
        {
            _record = data;
            _id = new Key( _record, PrimaryKey.WorkCodeId );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _shortName = new Element( _record, Field.ShortName );
            _notifications = new Element( _record, Field.Notifications );
            _status = new Element( _record, Field.Status );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _bbfy = new Element( _record, Field.BBFY );
            _fundCode = new Element( _record, Field.FundCode );
            _focCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _costOrgName = new Element( _record, Field.CostOrgName );
            _rcCode = new Element( _record, Field.RcCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectCodeName = new Element( _record, Field.ProjectName );
            _approvalDate = DateTime.Parse( _record[ $"{Field.ApprovalDate}" ].ToString() );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _args;
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Element( _code ) )
            {
                try
                {
                    return _code.GetValue();
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
                return Verify.Element( _bbfy )
                    ? new BudgetFiscalYear( _bbfy?.GetValue() )
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
            if( Verify.Element( _focCode ) )
            {
                try
                {
                    var _dict = new Dictionary<string, object>
                    {
                        [ $"{Field.FocCode}" ] = _focCode?.GetValue()
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
                return Verify.Element( _fundCode )
                    ? new Fund( _fundCode?.GetValue() )
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
            if( Verify.Element( _costOrgCode ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.CostOrgCode}" ] = _costOrgCode?.GetValue()
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
            if( Verify.Element( _accountCode ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = _accountCode?.GetValue()
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
            if( Verify.Element( _rcCode ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = _rcCode?.GetValue()
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
            if( Verify.Map( _args ) )
            {
                try
                {
                    var _data = new Builder( Source.WorkCodes, _args )
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
        /// Gets the division.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDivision GetDivision()
        {
            if( Verify.Element( _rcCode ) )
            {
                try
                {
                    var _rc = _rcCode.GetValue();
                    return new Division( _rc );
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
                return Verify.Map( _args )
                    ? _args
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
                return Validate.Source( _source )
                    ? _source
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
                return Verify.Key( _id )
                    ? _id
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
                return Verify.Element( _code )
                    ? _code
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
                return Verify.Element( _name )
                    ? _name
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
