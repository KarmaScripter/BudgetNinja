// <copyright file = "ExcelBudget.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "BudgetConfig"/>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ExcelBudget : BudgetConfig
    {
        /// <summary>
        /// The sheet count
        /// </summary>
        private readonly int _sheetCount;

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <value>
        /// The allocation.
        /// </value>
        private readonly IAllocation _allocation;

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        private readonly IAuthority _authority;

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private readonly IBudgetFiscalYear _bfy;

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private readonly IResourcePlanningOffice _rpio;

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        private readonly IFund _fund;

        /// <summary>
        /// Gets the ah.
        /// </summary>
        /// <value>
        /// The ah.
        /// </value>
        private readonly IAllowanceHolder _ah;

        /// <summary>
        /// Gets the org.
        /// </summary>
        /// <value>
        /// The org.
        /// </value>
        private readonly IOrganization _org;

        /// <summary>
        /// Gets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        private readonly IResponsibilityCenter _rc;

        /// <summary>
        /// Gets the division.
        /// </summary>
        /// <value>
        /// The division.
        /// </value>
        private readonly IDivision _division;

        /// <summary>
        /// Initializes a new instance of the <see cref = "ExcelBudget"/> class.
        /// </summary>
        public ExcelBudget()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ExcelBudget"/> class.
        /// </summary>
        /// <param name = "authority" >
        /// The authority.
        /// </param>
        public ExcelBudget( IAuthority authority )
        {
            _excel = new ExcelPackage( new FileInfo( _filePath ) );
            _workbook = _worksheet.Workbook;
            _sheetCount = _workbook.Worksheets.Count;
            _authority = authority;
            _allocation = _authority.GetAllocation();
            _data = _allocation.GetData();
            _bfy = _authority.GetBudgetFiscalYear();
            _rpio = _authority.GetResourcePlanningOffice();
            _fund = _authority.GetFund();
            _ah = _authority.GetAllowanceHolder();
            _org = _authority.GetOrganization();
            _rc = _authority.GetResponsibilityCenter();
            _division = new Division( _rc );
        }

        /// <summary>
        /// Gets the control number.
        /// </summary>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "fy" >
        /// The fy.
        /// </param>
        /// <returns>
        /// </returns>
        private IControlNumber GetControlNumber( IFund fund, IBudgetFiscalYear fy )
        {
            if( fund != null
                && fy != null )
            {
                try
                {
                    var _connection = new ConnectionBuilder( Source.ControlNumbers, Provider.SQLite );

                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.FundCode}" ] = fund.GetCode(),
                        [ $"{Field.BFY}" ] = _bfy.GetFirstYear(),
                        [ $"{Field.RcCode}" ] = _rc.GetCode()
                    };

                    var _sqlStatement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                    var _query = new Query( _connection, _sqlStatement );
                    return new ControlNumber( _query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IControlNumber );
                }
            }

            return default( IControlNumber );
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
                return _allocation ?? default( IAllocation );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAllocation );
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            if( _worksheet != null )
            {
                try
                {
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Hides the workSheet.
        /// </summary>
        public void HideWorksheet()
        {
            if( _worksheet != null )
            {
                try
                {
                    _worksheet.Hidden = eWorkSheetHidden.Hidden;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name of the workSheet.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        public void SetWorksheetName( string name )
        {
            if( _worksheet != null
                && Verify.Input( name ) )
            {
                try
                {
                    _worksheet.Name = name;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the work sheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetWorkSheet()
        {
            try
            {
                return _worksheet ?? default( ExcelWorksheet );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ExcelWorksheet );
            }
        }

        /// <summary>
        /// Sets the budget header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetBudgetHeaderFormat( Grid grid )
        {
            if( grid != null )
            {
                try
                {
                    using var _range = grid.GetRange();
                    _range.Style.Font.Color.SetColor( Color.Black );
                    _range.Style.Font.SetFromFont( _dataFont );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the non site header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "org" >
        /// The org.
        /// </param>
        public void SetNonSiteHeaderFormat( Grid grid, IFund fund, IOrganization org = null )
        {
            if( grid != null
                && fund != null )
            {
                try
                {
                    SetDataConfiguration( grid, fund, org );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the data configuration.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "org" >
        /// The org.
        /// </param>
        private void SetDataConfiguration( Grid grid, IFund fund, IOrganization org )
        {
            if( grid != null
                && fund != null )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _col = grid.GetFrom().Column;

                    if( org == null )
                    {
                        _sheet.Cells[ _row - 1, _col ].Value = $"{fund.GetName()} - {fund.GetCode()}";
                    }

                    if( org != null )
                    {
                        _sheet.Cells[ _row - 1, _col ].Value = $"{org.GetName()} - {org.GetCode()}";
                    }

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ]
                        .Style.Fill.BackgroundColor.SetColor( _primaryBackColor );

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    _sheet.Cells[ _row, _col ].Value = "Account";
                    _sheet.Cells[ _row, _col + 1 ].Value = "Travel";
                    _sheet.Cells[ _row, _col + 2 ].Value = "Expenses";
                    _sheet.Cells[ _row, _col + 3 ].Value = "Contracts";
                    _sheet.Cells[ _row, _col + 4 ].Value = "Grants";
                    _sheet.Cells[ _row, _col + 5 ].Value = "_total";
                    using var _range = _sheet.Cells[ _row, _col, _row, _col + 6 ];
                    _range.Style.Font.Bold = true;
                    _range.Style.Font.Color.SetColor( _fontColor );
                    _range.Style.Font.SetFromFont( _dataFont );
                    _range.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( _secondaryBackColor );
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the allocation table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "ah" >
        /// The ah.
        /// </param>
        public void SetAllocationTableFormat( Grid grid, IFund fund, IAllowanceHolder ah = null )
        {
            if( grid?.GetWorksheet() != null
                && grid.GetRange() != null
                && fund != null )
            {
                try
                {
                    using var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _col = grid.GetFrom().Column;

                    if( ah == null )
                    {
                        _sheet.Cells[ _row - 3, _col ].Value =
                            $"FundCode - {fund.GetName()} - {fund.GetCode()}";
                    }

                    if( ah != null )
                    {
                        _sheet.Cells[ _row - 2, _col ].Value =
                            $"{ah.GetName()} - {fund.GetCode()} - {ah.GetCode()}";
                    }

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ]
                        .Style.Fill.BackgroundColor.SetColor( _primaryBackColor );

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 6 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    _sheet.Cells[ _row, _col ].Value = "Account";
                    _sheet.Cells[ _row, _col + 1 ].Value = "Site";
                    _sheet.Cells[ _row, _col + 2 ].Value = "Travel";
                    _sheet.Cells[ _row, _col + 3 ].Value = "Expenses";
                    _sheet.Cells[ _row, _col + 4 ].Value = "Contracts";
                    _sheet.Cells[ _row, _col + 5 ].Value = "Grants";
                    _sheet.Cells[ _row, _col + 6 ].Value = "_total";
                    using var _range = _sheet.Cells[ _row, _col, _row, _col + 6 ];
                    _range.Style.Font.Bold = true;
                    _range.Style.Font.Color.SetColor( Color.Black );
                    _range.Style.Font.SetFromFont( _dataFont );
                    _range.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( Color.FromArgb( 255, 221, 235, 247 ) );
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the awards header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetAwardsHeaderFormat( Grid grid )
        {
            if( grid?.GetWorksheet() != null
                && grid.GetRange() != null
                && _allocation.GetAwards().Any() )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _col = grid.GetFrom().Column;
                    _sheet.Cells[ _row - 1, _col ].Value = "Supplemental";

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 1 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 1 ]
                        .Style.Fill.BackgroundColor.SetColor( _primaryBackColor );

                    _sheet.Cells[ _row - 1, _col, _row - 1, _col + 1 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    _sheet.Cells[ _row, _col ].Value = "Type";
                    _sheet.Cells[ _row, _col + 1 ].Value = "Amount";
                    using var _range = _sheet.Cells[ _row, _col, _row, _col + 1 ];
                    _range.Style.Font.Bold = true;
                    _range.Style.Font.Color.SetColor( Color.Black );
                    _range.Style.Font.SetFromFont( _dataFont );
                    _range.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( Color.FromArgb( 255, 221, 235, 247 ) );
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the budget header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        public void SetBudgetHeaderFormat( Grid grid, IFund fund, IBudgetFiscalYear bfy )
        {
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null
                && fund != null
                && bfy != null )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _number = GetControlNumber( fund, bfy );

                    _sheet.Cells[ grid.GetFrom().Row, grid.GetFrom().Column ].Value =
                        $"Division {_division.GetDivisionName()}";

                    _sheet.Cells[ 2, 3, 2, 4 ].Value = $"{_division.GetDivisionName()}";
                    _sheet.Cells[ 3, 2 ].Value = $"Control {_number?.GetBudgetControlNumber()}";
                    _sheet.Cells[ 2, 7 ].Value = $"Fiscal Year {bfy.GetFirstYear()}";
                    _sheet.Cells[ 3, 7 ].Value = $"Treasury {fund.GetTreasurySymbol()}";
                    _sheet.Cells[ 4, 2 ].Value = "Authority  PL 166-6";
                    _sheet.Cells[ 4, 7 ].Value = "Organization ";

                    if( fund.GetCode()?.GetValue()?.StartsWith( $"{FundCode.B}" ) == true )
                    {
                        _sheet.Cells[ 3, 8 ].Value = fund.GetTreasurySymbol()
                            ?.GetValue()
                            .Replace( "{A}/{B}", bfy.GetFirstYear() + "-" + bfy.GetLastYear() );
                    }

                    if( !fund.GetCode()?.GetValue()?.StartsWith( $"{FundCode.B}" ) == true )
                    {
                        _sheet.Cells[ 3, 8 ].Value = fund.GetTreasurySymbol();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the summary format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetSummaryFormat( Grid grid )
        {
            if( grid?.GetWorksheet() != null
                && grid.GetRange() != null )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _col = grid.GetFrom().Column;
                    _sheet.Cells[ _row, _col ].Value = "Authority";
                    _sheet.Cells[ _row, _col ].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    _sheet.Cells[ _row, _col ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _sheet.Cells[ _row, _col + 1 ].Formula = $"=SUM(C{_index}:C{_row - 1})";
                    _sheet.Cells[ _row, _col + 2 ].Formula = $"=SUM(D{_index}:D{_row - 1})";
                    _sheet.Cells[ _row, _col + 3 ].Formula = $"=SUM(E{_index}:E{_row - 1})";
                    _sheet.Cells[ _row, _col + 4 ].Formula = $"=SUM(F{_index}:F{_row - 1})";
                    _sheet.Cells[ _row, _col + 5 ].Formula = $"=SUM(G{_index}:G{_row - 1})";
                    _sheet.Cells[ _row, _col + 6 ].Formula = $"=SUM(H{_index}:H{_row - 1})";
                    _sheet.Cells[ _row, _col, _row, _col + 6 ].Style.Font.Bold = true;
                    _sheet.Cells[ _row, _col + 1, _row, _col + 6 ].Style.Numberformat.Format = "#,###";

                    _sheet.Cells[ _row, _col, _row, _col + 6 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Center;

                    SetTotalRowFormat( grid );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the award rows format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        public void SetAwardRowsFormat( Grid grid, IFund fund )
        {
            if( grid?.GetWorksheet() != null
                && grid.GetRange() != null
                && Verify.Input( fund.GetCode().GetValue() ) )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _column = grid.GetFrom().Column;
                    var _enumerable = _allocation.GetAwards();

                    var _lookup = _enumerable
                        ?.Where( p => p.GetFundCode().Equals( fund.GetCode().GetValue() ) )
                        ?.ToLookup( p => p.GetFundCode(), p => p );

                    if( _lookup != null )
                    {
                        foreach( var _group in _lookup )
                        {
                            _sheet.Cells[ _row, _column ].Style.HorizontalAlignment =
                                ExcelHorizontalAlignment.Left;

                            _sheet.Cells[ _row, _column ].Value = _group.Key;

                            _sheet.Cells[ _row, _column + 1 ].Value =
                                decimal.Parse( _lookup[ _group.Key ].ToString() );

                            _row++;
                        }
                    }

                    _sheet.Cells[ _row, _column ].Value = "_total";
                    _sheet.Cells[ _row, _column, _row, _column + 1 ].Style.Font.Bold = true;
                    _sheet.Cells[ _row, _column ].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    _sheet.Cells[ _row, _column ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _sheet.Cells[ _row, _column + 1 ].Formula = $"=SUM(C{_row}:C{_row - 1})";
                    _sheet.Cells[ _row, _column + 1 ].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Calculates the boc total.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <param name = "filter" >
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateBocTotal( IEnumerable<DataRow> data, Field column, BOC filter )
        {
            if( data?.Any() == true
                && Enum.IsDefined( typeof( Field ), column )
                && Enum.IsDefined( typeof( BOC ), filter ) )
            {
                var _sum = data
                    ?.Where( p => p.Field<string>( column.ToString() ).Equals( filter.ToString() ) )
                    ?.Select( p => p.Field<decimal>( Numeric.Amount.ToString() ) )
                    ?.Sum();

                return _sum > 0
                    ? (double)_sum
                    : default( double );
            }

            return default( double );
        }

        /// <summary>
        /// Populates the account rows.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <param name = "kvp" >
        /// The KVP.
        /// </param>
        public void PopulateAccountRows( Grid grid, ILookup<string, DataRow> code,
            IGrouping<string, DataRow> kvp )
        {
            if( grid?.GetWorksheet() != null
                && grid.GetRange() != null
                && code != null
                && kvp != null )
            {
                try
                {
                    var _sheet = grid.GetWorksheet();
                    var _row = grid.GetFrom().Row;
                    var _column = grid.GetFrom().Column;
                    var _travel = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Travel );
                    var _site = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.SiteTravel );
                    var _expenses = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Expenses );
                    var _contracts = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Contracts );
                    var _grants = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Grants );
                    var _total = _travel + _expenses + _contracts + _grants;

                    switch( _sheet.Name )
                    {
                        case "SF-6A REMOVALS":
                        {
                            foreach( var p in code[ kvp.Key ] )
                            {
                                _sheet.Cells[ _row, _column ].Value = p.Field<string>( $"{Field.AccountCode}" )
                                    + " " 
                                    + p.Field<string>( $"{Field.OrgCode}" )
                                        ?.Replace( "0600", "-" );

                                _sheet.Cells[ _row, _column + 1 ].Value = _site;
                                _sheet.Cells[ _row, _column + 2 ].Value = _travel;
                                _sheet.Cells[ _row, _column + 3 ].Value = _expenses;
                                _sheet.Cells[ _row, _column + 4 ].Value = _contracts;
                                _sheet.Cells[ _row, _column + 5 ].Value = _grants;
                                _sheet.Cells[ _row, _column + 6 ].Value = _total;
                            }

                            break;
                        }

                        case "SF SPECIAL ACCT":
                        {
                            foreach( var p in code[ kvp.Key ] )
                            {
                                _sheet.Cells[ _row, _column ].Value = p.Field<string>( $"{Field.AccountCode}" )
                                    + "- "
                                    + p.Field<string>( $"{Field.FundCode}" );

                                _sheet.Cells[ _row, _column + 1 ].Value = _site;
                                _sheet.Cells[ _row, _column + 2 ].Value = _travel;
                                _sheet.Cells[ _row, _column + 3 ].Value = _expenses;
                                _sheet.Cells[ _row, _column + 4 ].Value = _contracts;
                                _sheet.Cells[ _row, _column + 5 ].Value = _grants;
                                _sheet.Cells[ _row, _column + 6 ].Value = _total;
                            }

                            break;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
