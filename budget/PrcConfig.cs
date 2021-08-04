// <copyright file = "PrcConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "PrcBase"/>
    public class PrcConfig : PrcBase
    {
        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        public PrcConfig()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public PrcConfig( DataRow dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PrcConfig( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public PrcConfig( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "dict" >
        /// </param>
        public PrcConfig( IDictionary<string, object> dict )
        {
            _record = new DataBuilder( _source, dict )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
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
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetLevel GetBudgetLevel()
        {
            try
            {
                return Verify.Element( _level )
                    ? new BudgetLevel( _level?.GetValue() )
                    : default( BudgetLevel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetLevel );
            }
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
                return Verify.Element( _bfy )
                    ? new BudgetFiscalYear( _bfy?.GetValue() )
                    : default( BudgetFiscalYear );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetFiscalYear );
            }
        }

        /// <summary>
        /// Gets the resource planning office.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            try
            {
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _rpioCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.ResourcePlanningOffices );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new ResourcePlanningOffice( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IResourcePlanningOffice );
            }
        }

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAllowanceHolder GetAllowanceHolder()
        {
            try
            {
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _ahCode?.GetValue()
                };

                var connectbuilder = new ConnectionBuilder( Source.AllowanceHolders );
                var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                using var query = new Query( connectbuilder, sqlstatement );
                return new AllowanceHolder( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAllowanceHolder );
            }
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
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _orgCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.Organizations );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Organization( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IOrganization );
            }
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAccount GetAccount()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _accountCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.Accounts );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Account( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAccount );
            }
        }

        /// <summary>
        /// Gets the budget object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetObjectClass GetBudgetObjectClass()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _bocCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.BudgetObjectClass );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new BudgetObjectClass( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetObjectClass );
            }
        }

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResponsibilityCenter GetResponsibilityCenter()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _rcCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.ResponsibilityCenters );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new ResponsibilityCenter( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IResponsibilityCenter );
            }
        }
    }
}
