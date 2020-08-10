// // <copyright file = "PrcConfig.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

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
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public PrcConfig( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.PrcId );
            Level = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PrcConfig( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            Level = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public PrcConfig( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            Level = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PrcConfig"/> class.
        /// </summary>
        /// <param name = "dict" >
        /// </param>
        public PrcConfig( IDictionary<string, object> dict )
        {
            Record = new DataBuilder( Source, dict )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            Level = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
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
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetLevel GetBudgetLevel()
        {
            try
            {
                return Verify.Element( Level )
                    ? new BudgetLevel( Level?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Element( BFY )
                    ? new BudgetFiscalYear( BFY?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                    [ $"{Field.Code}" ] = RpioCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.ResourcePlanningOffices );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new ResourcePlanningOffice( query );
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
        public IAllowanceHolder GetAllowanceHolder()
        {
            try
            {
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = AhCode?.GetValue()
                };

                var connectbuilder = new ConnectionBuilder( Source.AllowanceHolders );
                var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                using var query = new Query( connectbuilder, sqlstatement );
                return new AllowanceHolder( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = OrgCode?.GetValue()
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
                return default;
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
                    [ $"{Field.Code}" ] = BocCode?.GetValue()
                };

                var connection = new ConnectionBuilder( Source.BudgetObjectClass );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new BudgetObjectClass( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return default;
            }
        }
    }
}
