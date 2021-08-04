// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // **********************************************************   ASSEMBLIES   ************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedVariable" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class BudgetFactory
    {
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>The budget</summary>
        private readonly ExcelBudget _budget;

        /// <summary>The worksheet</summary>
        private readonly ExcelWorksheet _worksheet;

        // ***************************************************************************************************************************
        // *******************************************************   CONSTRUCTORS ****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetFactory"/> class.
        /// </summary>
        /// <param name="excelbudget">The excelbudget.</param>
        public BudgetFactory( ExcelBudget excelbudget )
        {
            _budget = excelbudget;
            _worksheet = _budget.GetWorkSheet();
            Allocation = _budget.GetAllocation();
            Authority = Allocation.GetAuthority();
        }

        // ***************************************************************************************************************************
        // *******************************************************  PROPERTIES  ******************************************************
        // ***************************************************************************************************************************

        /// <summary>Gets the allocation.</summary>
        /// <value>The allocation.</value>
        private IAllocation Allocation { get; }

        /// <summary>Gets the authority.</summary>
        /// <value>The authority.</value>
        private IAuthority Authority { get; }

        // **************************************************************************************************************************
        // ******************************************************     METHODS   *****************************************************
        // **************************************************************************************************************************

        /// <summary>Gets the epm worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetEpmWorksheet()
        {
            var funds = Allocation.GetFunds();
            var awards = Allocation.GetAwards();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.B}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var hdr = grid.From.Row - 1;
                    var fund = new Fund( $"{FundCode.B}" );
                    _budget?.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var prcdata = Allocation.GetData() != null
                        ? Allocation.GetData().Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.B}" ) ) != null
                            ? Allocation.GetData().Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.B}" ) ).Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" ) != null
                                ? Allocation.GetData().Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.B}" ) ).Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" ).ToLookup( f => f.Field<string>( $"{Field.AccountCode}" ), f => f )
                                : null
                            : null
                        : null;

                    var start = grid.From.Row;

                    if( prcdata != null )
                    {
                        foreach( var kvp in prcdata )
                        {
                            _budget?.SetAllocationTableFormat( grid, fund );
                            _budget?.PopulateAccountRows( grid, prcdata, kvp );
                            start++;
                        }
                    }

                    var endrow = start;

                    var query = awards?.Where( a => a.GetFundCode().Equals( $"{FundCode.B}" ) )
                        .Select( a => a );

                    if( query?.Any() ?? false )
                    {
                        _budget?.SetAwardsHeaderFormat( grid );
                        _budget?.SetAwardRowsFormat( grid, fund );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.B}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the stag worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetStagWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.E}" ) ) )
            {
                try
                {
                    var code = prc?.Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.E}" ) )
                        ?.Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        ?.ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.E}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the lust worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetLustWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.F}" ) ) )
            {
                try
                {
                    var code = prc?.Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.F}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.F}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.Equals( $"{FundCode.F}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the oil worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetOilWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.H}" ) ) )
            {
                try
                {
                    var fund = new Fund( $"{FundCode.H}" );

                    var code = prc?.Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.H}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.H}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.H}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the deep water horizon worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetDeepWaterHorizonWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.ZL}" ) ) )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _row = _grid.From.Row;
                    var _hdr = _row - 1;
                    var _fund = new Fund( $"{FundCode.ZL}" );
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( _grid, _fund, Allocation?.GetBudgetFiscalYear() );

                    var _lookup = prc?.Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.ZL}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .Select( f => f )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( _lookup != null )
                    {
                        foreach( var kvp in _lookup )
                        {
                            _budget?.SetAllocationTableFormat( _grid, _fund );
                            _budget?.PopulateAccountRows( _grid, _lookup, kvp );
                            _row++;
                        }
                    }

                    _budget?.SetSummaryFormat( _grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.ZL}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the superfund worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetSuperfundWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.T}" ) ) )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _fromRow = _grid.From.Row;
                    var _hdr = _fromRow - 1;
                    var _fund = new Fund( $"{FundCode.T}" );
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( _grid, _fund, Allocation.GetBudgetFiscalYear() );

                    var _lookup = prc?.Where( p => p.Field<string>( $"{Field.AhCode}" ).Equals( "06" ) )
                        .Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.T}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( _lookup != null )
                    {
                        foreach( var kvv in _lookup )
                        {
                            _budget?.SetAllocationTableFormat( _grid, _fund );
                            _budget?.PopulateAccountRows( _grid, _lookup, kvv );
                            _fromRow++;
                        }
                    }

                    var _endrow = _fromRow;
                    _budget?.SetSummaryFormat( _grid );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.H}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                        _budget?.SetAwardsHeaderFormat( _grid );
                        _budget?.SetAwardRowsFormat( _grid, _fund );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.T}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the s f6 a worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetSF6AWorksheet()
        {
            var _data = Allocation.GetData();
            var _enumerable = Allocation.GetBuilder().ProgramElements[ Field.AhCode.ToString() ];

            if( _enumerable.Any( f => f.Equals( "6A" ) ) )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _fromRow = _grid.From.Row;
                    var _hdr = _fromRow - 1;
                    var _fund = new Fund( $"{FundCode.T}" );
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( _grid, _fund, Allocation.GetBudgetFiscalYear() );

                    var _code = _data?.Where( p => p.Field<string>( $"{Field.AhCode}" ).Equals( "6A" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.OrgCode}" ), p => p );

                    if ( _code != null )
                    {
                        foreach( var kvp in _code )
                        {
                            var _dictionary = new Dictionary<string, object>
                            {
                                [ $"{Field.AhCode}" ] = "6A"
                            };

                            var _builder = new ConnectionBuilder( Source.AllowanceHolders,
                                Provider.SQLite );

                            var _statement = new SqlStatement( _builder, _dictionary, SQL.SELECT );
                            var _query = new Query( _builder, _statement );

                            _budget?.SetAllocationTableFormat( _grid, _fund,
                                new AllowanceHolder( _query ) );

                            _budget?.PopulateAccountRows( _grid, _code, kvp );
                            _fromRow++;
                        }
                    }

                    _budget?.SetSummaryFormat( _grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !_enumerable.Any( f => f.Equals( "6A" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the special accounts worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetSpecialAccountsWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().Contains( $"{FundCode.TR}" ) ) )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _fromRow = _grid.From.Row;
                    var _hdr = _fromRow - 1;

                    var _codes = prc?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Contains( $"{FundCode.TR}" ) )
                        ?.Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        ?.Select( p => p )
                        ?.ToArray();

                    var _fund = new Fund( $"{FundCode.TR}" );
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( _grid, _fund, Allocation.GetBudgetFiscalYear() );

                    for( var i = 0; i < _codes?.Length; i++ )
                    {
                        var _ = _codes[ i ];

                        var _lookup = prc
                            ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.TR}" ) )
                            ?.Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                            ?.Select( p => p )
                            ?.ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                        foreach( var kvp in _lookup )
                        {
                            _budget?.SetAllocationTableFormat( _grid, _fund );
                            _budget?.PopulateAccountRows( _grid, _lookup, kvp );
                            _fromRow++;
                        }

                        var _endrow = _fromRow;
                        _budget?.SetSummaryFormat( _grid );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().Contains( $"{FundCode.TR}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the superfund supplement worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetSuperfundSupplementWorksheet()
        {
            var _data = Allocation.GetData();
            var _funds = Allocation.GetFunds();

            if( _funds.Any( p => p.GetCode().Equals( $"{FundCode.TS3}" ) ) )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _fromRow = _grid.From.Row;
                    var _hdr = _fromRow - 1;
                    var _fund = new Fund( $"{FundCode.TS3}" );
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    _budget?.SetBudgetHeaderFormat( _grid, _fund, Allocation.GetBudgetFiscalYear() );

                    var _lookup = _data?.Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.TS3}" ) )
                        ?.Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        ?.ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if ( _lookup != null )
                    {
                        foreach( var kvp in _lookup )
                        {
                            _budget?.SetNonSiteHeaderFormat( _grid, _fund );
                            _budget?.PopulateAccountRows( _grid, _lookup, kvp );
                            _fromRow++;
                        }
                    }

                    _budget?.SetSummaryFormat( _grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !_funds.Any( p => p.GetCode().Equals( $"{FundCode.TS3}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Gets the lust supplemental worksheet.</summary>
        /// <returns></returns>
        public ExcelWorksheet GetLustSupplementalWorksheet()
        {
            var _data = Allocation.GetData();
            var _funds = Allocation.GetFunds();

            if( _funds?.Any( p => p.GetCode().Equals( $"{FundCode.FS3}" ) ) ?? false )
            {
                try
                {
                    var _grid = new Grid( _worksheet, ( 10, 2 ) );
                    var _fromRow = _grid.From.Row;
                    var _hdr = _fromRow - 1;
                    _budget?.SetWorksheetProperties( _grid.GetWorksheet() );
                    var _fund = new Fund( $"{FundCode.FS3}" );

                    var _rows = _data?.Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.FS3}" ) )
                        ?.Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        ?.Select( f => f )
                        ?.ToArray();

                    var _lookup = _rows
                        ?.ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if ( _lookup != null )
                    {
                        foreach( var group in _lookup )
                        {
                            _budget?.SetNonSiteHeaderFormat( _grid, _fund );
                            _budget?.PopulateAccountRows( _grid, _lookup, group );
                            _fromRow++;
                        }
                    }

                    _budget?.SetSummaryFormat( _grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !_funds?.Any( p => p.GetCode().Equals( $"{FundCode.FS3}" ) ) ?? false )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>Fails the specified ex.</summary>
        /// <param name="ex">The ex.</param>
        private static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}