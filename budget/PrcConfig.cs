// <copyright file = "PrcConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "PrcBase"/>
    public abstract class PrcConfig : PrcBase
    {
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
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _rpioCode?.GetValue()
                };

                var _connection = new ConnectionBuilder( Source.ResourcePlanningOffices );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new ResourcePlanningOffice( _query );
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
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _ahCode?.GetValue()
                };

                var _builder = new ConnectionBuilder( Source.AllowanceHolders );
                var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                using var _query = new Query( _builder, _statement );
                return new AllowanceHolder( _query );
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
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _orgCode?.GetValue()
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

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAccount GetAccount()
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
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _bocCode?.GetValue()
                };

                var _builder = new ConnectionBuilder( Source.BudgetObjectClass );
                var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                using var _query = new Query( _builder, _statement );
                return new BudgetObjectClass( _query );
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
                return default( IResponsibilityCenter );
            }
        }
    }
}
