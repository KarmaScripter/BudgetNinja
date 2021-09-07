// <copyright file = "AllocationData.cs" company = "Terry D. Eppler">
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
    /// <seealso/>
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class AllocationData : Authority
    {
        /// <summary>
        /// Gets or sets the funds.
        /// </summary>
        /// <value>
        /// The funds.
        /// </value>
        private protected IEnumerable<IFund> _funds;

        /// <summary>
        /// Gets or sets the PRC.
        /// </summary>
        /// <value>
        /// The PRC.
        /// </value>
        private protected IEnumerable<IProgramResultsCode> _programResultCodes;

        /// <summary>
        /// Gets or sets the fte.
        /// </summary>
        /// <value>
        /// The fte.
        /// </value>
        private protected IEnumerable<IProgramResultsCode> _fullTimeEquivalents;

        /// <summary>
        /// Gets or sets the org.
        /// </summary>
        /// <value>
        /// The org.
        /// </value>
        private protected IEnumerable<IOrganization> _organizations;

        /// <summary>
        /// Gets or sets the ah.
        /// </summary>
        /// <value>
        /// The ah.
        /// </value>
        private protected IEnumerable<IAllowanceHolder> _allowanceHolders;

        /// <summary>
        /// Gets or sets the boc.
        /// </summary>
        /// <value>
        /// The boc.
        /// </value>
        private protected IEnumerable<IBudgetObjectClass> _objectClasses;

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        private protected IEnumerable<IAccount> _accounts;

        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        /// <value>
        /// The awards.
        /// </value>
        private protected IEnumerable<ISupplemental> _awards;

        /// <summary>
        /// Gets or sets the overtime.
        /// </summary>
        /// <value>
        /// The overtime.
        /// </value>
        private protected IEnumerable<ISupplemental> _overtime;

        /// <summary>
        /// Gets or sets the time off.
        /// </summary>
        /// <value>
        /// The time off.
        /// </value>
        private protected IEnumerable<ISupplemental> _timeOff;
        
        /// <summary>
        /// Gets the funds.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IFund> GetFunds()
        {
            try
            {
                var _builder = GetBuilder();
                var _code = _builder?.GetData();
                var _select = _code?.Select( f => new Fund( f ) );

                return _select?.Any() == true
                    ? _select
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
                var _builder = GetBuilder();
                var _codes = _builder?.GetData();
                var _select = _codes?.Select( o => new Organization( o ) );

                return _select?.Any() == true
                    ? _select
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
                var _builder = GetBuilder();
                var _codes = _builder?.GetData();
                var _select = _codes?.Select( a => new AllowanceHolder( a ) );

                return _select?.Any() == true
                    ? _select
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
                var _codes = builder?.GetData();
                var _select = _codes?.Select( b => new BudgetObjectClass( b ) );

                return _select?.Any() == true
                    ? _select
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
                var _builder = GetBuilder();
                var _codes = _builder?.GetData();
                var _select = _codes?.Select( c => new Account( c ) );

                return _select?.Any() == true
                    ? _select
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
                var _args = new Dictionary<string, object>
                {
                    [ $"{Field.BudgetLevel}" ] = ( _budgetLevel as IElement )?.GetValue(),
                    [ $"{Field.BFY}" ] = _bfy?.GetValue(),
                    [ $"{Field.FundCode}" ] = _fundCode?.GetValue(),
                    [ $"{Field.AhCode}" ] = _ahCode?.GetValue(),
                    [ $"{Field.RcCode}" ] = _rcCode?.GetValue()
                };

                var _rows = new DataBuilder( Source.PRC, _args )
                    ?.GetData();

                var _prc = _rows?.Where( p => p.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                    ?.Select( p => new ProgramResultsCode( p ) );

                return _prc?.Any() == true
                    ? _prc
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
                var _builder = GetBuilder();

                var _boc = _builder?.GetData()
                    ?.Select( b => new BudgetObjectClass() );

                if( _boc?.Any() == true )
                {
                    var _args = new Dictionary<string, object>
                    {
                        [ $"{Field.BudgetLevel}" ] = ( _budgetLevel as IElement )?.GetValue(),
                        [ $"{Field.BFY}" ] = _budgetFiscalYear.GetFirstYear().GetValue(),
                        [ $"{Field.FundCode}" ] = _fundCode.GetValue(),
                        [ $"{Field.AhCode}" ] = _ahCode.GetValue(),
                        [ $"{Field.RcCode}" ] = _rcCode.GetValue()
                    };

                    var _rows = new DataBuilder( Source.FTE, _args )?.GetData();
                    var _fte = _rows?.Select( p => new FullTimeEquivalent( p ) );

                    return _fte?.Any() == true
                        ? _fte
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
                    var _rc = GetResponsibilityCenter()
                        ?.GetCode()
                        ?.GetValue();

                    if( Verify.Input( _rc ) )
                    {
                        var _args = new Dictionary<string, object>
                        {
                            [ $"{Field.RcCode}" ] = _rc
                        };

                        var _rows = new DataBuilder( Source.Awards, _args )
                            ?.GetData();

                        var _select = _rows?.Select( r => new Awards( r ) );

                        return _select?.Any() == true
                            ? _select
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
                    var _rc = GetResponsibilityCenter()
                        ?.GetCode();

                    if( Verify.Input( _rc?.GetValue() ) )
                    {
                        var _args = new Dictionary<string, object>
                        {
                            {
                                $"{Field.RcCode}", _rc?.GetValue()
                            }
                        };

                        var _rows = new Builder( Source.TimeOff, _args )?.GetData();
                        var _select = _rows?.Select( r => new TimeOff( r ) );

                        return _select?.Any() == true
                            ? _select
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
                    var _rc = GetResponsibilityCenter()
                        ?.GetCode();

                    if( Verify.Input( _rc?.GetValue() ) )
                    {
                        var _args = new Dictionary<string, object>
                        {
                            {
                                $"{Field.RcCode}", _rc?.GetValue()
                            }
                        };

                        var _rows = new Builder( Source.Overtime, _args )
                            ?.GetData();

                        var _select = _rows?.Select( r => new Overtime( r ) );

                        return _select?.Any() == true
                            ? _select
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