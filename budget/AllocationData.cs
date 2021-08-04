// <copyright file = "AllocationData.cs" company = "Terry D. Eppler">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso/>
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class AllocationData : Authority
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the funds.
        /// </summary>
        /// <value>
        /// The funds.
        /// </value>
        private protected IEnumerable<IFund> Funds { get; set; }

        /// <summary>
        /// Gets or sets the PRC.
        /// </summary>
        /// <value>
        /// The PRC.
        /// </value>
        private protected IEnumerable<IProgramResultsCode> ProgramResultCodes { get; set; }

        /// <summary>
        /// Gets or sets the fte.
        /// </summary>
        /// <value>
        /// The fte.
        /// </value>
        private protected IEnumerable<IProgramResultsCode> FullTimeEquivalents { get; set; }

        /// <summary>
        /// Gets or sets the org.
        /// </summary>
        /// <value>
        /// The org.
        /// </value>
        private protected IEnumerable<IOrganization> Organizations { get; set; }

        /// <summary>
        /// Gets or sets the ah.
        /// </summary>
        /// <value>
        /// The ah.
        /// </value>
        private protected IEnumerable<IAllowanceHolder> AllowanceHolders { get; set; }

        /// <summary>
        /// Gets or sets the boc.
        /// </summary>
        /// <value>
        /// The boc.
        /// </value>
        private protected IEnumerable<IBudgetObjectClass> ObjectClasses { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        private protected IEnumerable<IAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        /// <value>
        /// The awards.
        /// </value>
        private protected IEnumerable<ISupplemental> Awards { get; set; }

        /// <summary>
        /// Gets or sets the overtime.
        /// </summary>
        /// <value>
        /// The overtime.
        /// </value>
        private protected IEnumerable<ISupplemental> Overtime { get; set; }

        /// <summary>
        /// Gets or sets the time off.
        /// </summary>
        /// <value>
        /// The time off.
        /// </value>
        private protected IEnumerable<ISupplemental> TimeOff { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the funds.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IFund> GetFunds()
        {
            try
            {
                var builder = GetBuilder();
                var boc = builder?.ProgramElements[ $"{Field.FundCode}" ];
                var funds = boc?.Select( f => new Fund( f ) );

                return funds?.Any() == true
                    ? funds
                    : default( IEnumerable<Fund> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IFund> );
            }
        }

        /// <summary>
        /// Gets the organizations.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IOrganization> GetOrganizations()
        {
            try
            {
                var builder = GetBuilder();
                var codes = builder?.ProgramElements[ $"{Field.OrgCode}" ];
                var orgs = codes?.Select( o => new Organization( o ) );

                return orgs?.Any() == true
                    ? orgs
                    : default( IEnumerable<Organization> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IOrganization> );
            }
        }

        /// <summary>
        /// Gets the allowance holders.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IAllowanceHolder> GetAllowanceHolders()
        {
            try
            {
                var builder = GetBuilder();
                var codes = builder?.ProgramElements[ $"{Field.BocCode}" ];
                var ah = codes?.Select( a => new AllowanceHolder( a ) );

                return ah?.Any() == true
                    ? ah
                    : default( IEnumerable<AllowanceHolder> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IAllowanceHolder> );
            }
        }

        /// <summary>
        /// Gets the budget object classes.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IBudgetObjectClass> GetBudgetObjectClasses()
        {
            try
            {
                var builder = GetBuilder();
                var codes = builder?.ProgramElements[ $"{Field.BocCode}" ];
                var boc = codes?.Select( b => new BudgetObjectClass( b ) );

                return boc?.Any() == true
                    ? boc
                    : default( IEnumerable<BudgetObjectClass> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IBudgetObjectClass> );
            }
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IAccount> GetAccounts()
        {
            try
            {
                var builder = GetBuilder();
                var codes = builder?.ProgramElements[ $"{Field.AccountCode}" ];
                var accounts = codes?.Select( c => new Account( c ) );

                return accounts?.Any() == true
                    ? accounts
                    : default( IEnumerable<Account> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IAccount> );
            }
        }

        /// <summary>
        /// Gets the ProgramResultsCode allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IProgramResultsCode> GetProgramResultsCodes()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.BudgetLevel}" ] = ( _budgetLevel as IElement )?.GetValue(),
                    [ $"{Field.BFY}" ] = _bfy?.GetValue(),
                    [ $"{Field.FundCode}" ] = _fundCode?.GetValue(),
                    [ $"{Field.AhCode}" ] = _ahCode?.GetValue(),
                    [ $"{Field.RcCode}" ] = _rcCode?.GetValue()
                };

                var data = new DataBuilder( Source.PRC, args )?.GetData();

                var prc = data?.Where( p => p.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                    ?.Select( p => new ProgramResultsCode( p ) );

                return prc?.Any() == true
                    ? prc
                    : default( IEnumerable<ProgramResultsCode> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IProgramResultsCode> );
            }
        }

        /// <summary>
        /// Gets the full time equivalents.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IProgramResultsCode> GetFullTimeEquivalents()
        {
            try
            {
                var builder = GetBuilder();
                var boc = builder?.ProgramElements[ $"{Field.BocCode}" ];

                if( boc?.Any() == true
                    && boc.Contains( "17" ) )
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.BudgetLevel}" ] = ( _budgetLevel as IElement )?.GetValue(),
                        [ $"{Field.BFY}" ] = _budgetFiscalYear.GetFirstYear().GetValue(),
                        [ $"{Field.FundCode}" ] = _fundCode.GetValue(),
                        [ $"{Field.AhCode}" ] = _ahCode.GetValue(),
                        [ $"{Field.RcCode}" ] = _rcCode.GetValue()
                    };

                    var data = new DataBuilder( Source.FTE, args )?.GetData();
                    var fte = data?.Select( p => new FullTimeEquivalent( p ) );

                    return fte?.Any() == true
                        ? fte
                        : default( IEnumerable<FullTimeEquivalent> );
                }

                return default( IEnumerable<IProgramResultsCode> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IProgramResultsCode> );
            }
        }

        /// <summary>
        /// Gets the awards.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<ISupplemental> GetAwards()
        {
            if( Resource.DivisionSources?.Contains( GetSource() ) == true )
            {
                try
                {
                    var rc = GetResponsibilityCenter()?.GetCode()?.GetValue();

                    if( Verify.Input( rc ) )
                    {
                        var args = new Dictionary<string, object>
                        {
                            [ $"{Field.RcCode}" ] = rc
                        };

                        var data = new DataBuilder( Source.Awards, args )?.GetData();
                        var awards = data?.Select( r => new Awards( r ) );

                        return awards?.Any() == true
                            ? awards
                            : default( IEnumerable<Awards> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<ISupplemental> );
                }
            }

            return default( IEnumerable<ISupplemental> );
        }

        /// <summary>
        /// Gets the time off.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<ISupplemental> GetTimeOff()
        {
            if( Resource.DivisionSources?.Contains( GetSource() ) == true )
            {
                try
                {
                    var rc = GetResponsibilityCenter()?.GetCode();

                    if( Verify.Input( rc?.GetValue() ) )
                    {
                        var args = new Dictionary<string, object>
                        {
                            {
                                $"{Field.RcCode}", rc?.GetValue()
                            }
                        };

                        var data = new Builder( Source.TimeOff, args )?.GetData();
                        var timeoff = data?.Select( r => new TimeOff( r ) );

                        return timeoff?.Any() == true
                            ? timeoff
                            : default( IEnumerable<TimeOff> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<ISupplemental> );
                }
            }

            return default( IEnumerable<ISupplemental> );
        }

        /// <summary>
        /// Gets the over time.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<ISupplemental> GetOverTime()
        {
            if( Resource.DivisionSources?.Contains( GetSource() ) == true )
            {
                try
                {
                    var rc = GetResponsibilityCenter()?.GetCode();

                    if( Verify.Input( rc?.GetValue() ) )
                    {
                        var args = new Dictionary<string, object>
                        {
                            {
                                $"{Field.RcCode}", rc?.GetValue()
                            }
                        };

                        var data = new Builder( Source.Overtime, args )?.GetData();
                        var overtime = data?.Select( r => new Overtime( r ) );

                        return overtime?.Any() == true
                            ? overtime
                            : default( IEnumerable<Overtime> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<ISupplemental> );
                }
            }

            return default( IEnumerable<ISupplemental> );
        }
    }
}
