// <copyright file = "ExcelBudget.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

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
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The sheet count
        /// </summary>
        private readonly int SheetCount;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Excel = new ExcelPackage( new FileInfo( FilePath ) );
            Workbook = Excel.Workbook;
            SheetCount = Workbook.Worksheets.Count;
            Authority = authority;
            Allocation = Authority.GetAllocation();
            Data = Allocation.GetData();
            BFY = Authority.GetBudgetFiscalYear();
            RPIO = Authority.GetResourcePlanningOffice();
            Fund = Authority.GetFund();
            AH = Authority.GetAllowanceHolder();
            ORG = Authority.GetOrganization();
            RC = Authority.GetResponsibilityCenter();
            Division = new Division( RC );
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <value>
        /// The allocation.
        /// </value>
        private IAllocation Allocation { get; }

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        private IAuthority Authority { get; }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private IBudgetFiscalYear BFY { get; }

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private IResourcePlanningOffice RPIO { get; }

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        private IFund Fund { get; }

        /// <summary>
        /// Gets the ah.
        /// </summary>
        /// <value>
        /// The ah.
        /// </value>
        private IAllowanceHolder AH { get; }

        /// <summary>
        /// Gets the org.
        /// </summary>
        /// <value>
        /// The org.
        /// </value>
        private IOrganization ORG { get; }

        /// <summary>
        /// Gets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        private IResponsibilityCenter RC { get; }

        /// <summary>
        /// Gets the division.
        /// </summary>
        /// <value>
        /// The division.
        /// </value>
        private IDivision Division { get; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        private string Text { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
                    var connection = new ConnectionBuilder( Source.ControlNumbers, Provider.SQLite );

                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.FundCode}" ] = fund.GetCode(),
                        [ $"{Field.BFY}" ] = BFY.GetFirstYear(),
                        [ $"{Field.RcCode}" ] = RC.GetCode()
                    };

                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    var query = new Query( connection, sqlstatement );
                    return new ControlNumber( query );
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
        /// Gets the allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAllocation GetAllocation()
        {
            try
            {
                return Allocation ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            if( Excel != null )
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
        /// Hides the worksheet.
        /// </summary>
        public void HideWorksheet()
        {
            if( Worksheet != null )
            {
                try
                {
                    Worksheet.Hidden = eWorkSheetHidden.Hidden;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name of the worksheet.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        public void SetWorksheetName( string name )
        {
            if( Worksheet != null
                && Verify.Input( name ) )
            {
                try
                {
                    Worksheet.Name = name;
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
                return Worksheet ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                    using var rng = grid.GetRange();
                    rng.Style.Font.Color.SetColor( Color.Black );
                    rng.Style.Font.SetFromFont( DataFont );
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
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
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;

                    if( org == null )
                    {
                        worksheet.Cells[ row - 1, col ].Value = $"{fund.GetName()} - {fund.GetCode()}";
                    }

                    if( org != null )
                    {
                        worksheet.Cells[ row - 1, col ].Value = $"{org.GetName()} - {org.GetCode()}";
                    }

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ]
                        .Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    worksheet.Cells[ row, col ].Value = "Account";
                    worksheet.Cells[ row, col + 1 ].Value = "Travel";
                    worksheet.Cells[ row, col + 2 ].Value = "Expenses";
                    worksheet.Cells[ row, col + 3 ].Value = "Contracts";
                    worksheet.Cells[ row, col + 4 ].Value = "Grants";
                    worksheet.Cells[ row, col + 5 ].Value = "Total";
                    using var hdr = worksheet.Cells[ row, col, row, col + 6 ];
                    hdr.Style.Font.Bold = true;
                    hdr.Style.Font.Color.SetColor( FontColor );
                    hdr.Style.Font.SetFromFont( DataFont );
                    hdr.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    hdr.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    hdr.Style.Fill.BackgroundColor.SetColor( SecondaryBackColor );
                    hdr.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
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
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null
                && fund != null )
            {
                try
                {
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;

                    if( ah == null )
                    {
                        worksheet.Cells[ row - 3, col ].Value =
                            $"FundCode - {fund.GetName()} - {fund.GetCode()}";
                    }

                    if( ah != null )
                    {
                        worksheet.Cells[ row - 2, col ].Value =
                            $"{ah.GetName()} - {fund.GetCode()} - {ah.GetCode()}";
                    }

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ]
                        .Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );

                    worksheet.Cells[ row - 1, col, row - 1, col + 6 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    worksheet.Cells[ row, col ].Value = "Account";
                    worksheet.Cells[ row, col + 1 ].Value = "Site";
                    worksheet.Cells[ row, col + 2 ].Value = "Travel";
                    worksheet.Cells[ row, col + 3 ].Value = "Expenses";
                    worksheet.Cells[ row, col + 4 ].Value = "Contracts";
                    worksheet.Cells[ row, col + 5 ].Value = "Grants";
                    worksheet.Cells[ row, col + 6 ].Value = "Total";
                    using var hdr = worksheet.Cells[ row, col, row, col + 6 ];
                    hdr.Style.Font.Bold = true;
                    hdr.Style.Font.Color.SetColor( Color.Black );
                    hdr.Style.Font.SetFromFont( DataFont );
                    hdr.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    hdr.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    hdr.Style.Fill.BackgroundColor.SetColor( Color.FromArgb( 255, 221, 235, 247 ) );
                    hdr.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
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
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null
                && Allocation.GetAwards().Any() )
            {
                try
                {
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;
                    worksheet.Cells[ row - 1, col ].Value = "Supplemental";

                    worksheet.Cells[ row - 1, col, row - 1, col + 1 ].Style.Fill.PatternType =
                        ExcelFillStyle.Solid;

                    worksheet.Cells[ row - 1, col, row - 1, col + 1 ]
                        .Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );

                    worksheet.Cells[ row - 1, col, row - 1, col + 1 ].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Left;

                    worksheet.Cells[ row, col ].Value = "Type";
                    worksheet.Cells[ row, col + 1 ].Value = "Amount";
                    using var hdr = worksheet.Cells[ row, col, row, col + 1 ];
                    hdr.Style.Font.Bold = true;
                    hdr.Style.Font.Color.SetColor( Color.Black );
                    hdr.Style.Font.SetFromFont( DataFont );
                    hdr.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    hdr.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    hdr.Style.Fill.BackgroundColor.SetColor( Color.FromArgb( 255, 221, 235, 247 ) );
                    hdr.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
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
                    var worksheet = grid.GetWorksheet();
                    var controlnumber = GetControlNumber( fund, bfy );

                    worksheet.Cells[ grid.From.Row, grid.From.Column ].Value =
                        $"Division {Division.GetDivisionName()}";

                    worksheet.Cells[ 2, 3, 2, 4 ].Value = $"{Division.GetDivisionName()}";
                    worksheet.Cells[ 3, 2 ].Value = $"Control {controlnumber?.GetBudgetControlNumber()}";
                    worksheet.Cells[ 2, 7 ].Value = $"Fiscal Year {bfy.GetFirstYear()}";
                    worksheet.Cells[ 3, 7 ].Value = $"Treasury {fund.GetTreasurySymbol()}";
                    worksheet.Cells[ 4, 2 ].Value = "Authority  PL 166-6";
                    worksheet.Cells[ 4, 7 ].Value = "Organization ";

                    if( fund.GetCode().GetValue().StartsWith( $"{FundCode.B}" ) )
                    {
                        worksheet.Cells[ 3, 8 ].Value = fund.GetTreasurySymbol()
                            ?.GetValue()
                            .Replace( "{A}/{B}", bfy.GetFirstYear() + "-" + bfy.GetLastYear() );
                    }

                    if( !fund.GetCode().GetValue().StartsWith( $"{FundCode.B}" ) )
                    {
                        worksheet.Cells[ 3, 8 ].Value = fund.GetTreasurySymbol();
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
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null )
            {
                try
                {
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;
                    worksheet.Cells[ row, col ].Value = "Authority";
                    worksheet.Cells[ row, col ].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[ row, col ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[ row, col + 1 ].Formula = $"=SUM(C{Index}:C{row - 1})";
                    worksheet.Cells[ row, col + 2 ].Formula = $"=SUM(D{Index}:D{row - 1})";
                    worksheet.Cells[ row, col + 3 ].Formula = $"=SUM(E{Index}:E{row - 1})";
                    worksheet.Cells[ row, col + 4 ].Formula = $"=SUM(F{Index}:F{row - 1})";
                    worksheet.Cells[ row, col + 5 ].Formula = $"=SUM(G{Index}:G{row - 1})";
                    worksheet.Cells[ row, col + 6 ].Formula = $"=SUM(H{Index}:H{row - 1})";
                    worksheet.Cells[ row, col, row, col + 6 ].Style.Font.Bold = true;
                    worksheet.Cells[ row, col + 1, row, col + 6 ].Style.Numberformat.Format = "#,###";

                    worksheet.Cells[ row, col, row, col + 6 ].Style.HorizontalAlignment =
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
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null
                && Verify.Input( fund.GetCode().GetValue() ) )
            {
                try
                {
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;
                    var awards = Allocation.GetAwards();

                    var lookup = awards.Where( p => p.GetFundCode().Equals( fund.GetCode().GetValue() ) )
                        .ToLookup( p => p.GetFundCode(), p => p );

                    foreach( var group in lookup )
                    {
                        worksheet.Cells[ row, col ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells[ row, col ].Value = group.Key;

                        worksheet.Cells[ row, col + 1 ].Value =
                            decimal.Parse( lookup[ group.Key ].ToString() );

                        row++;
                    }

                    worksheet.Cells[ row, col ].Value = "Total";
                    worksheet.Cells[ row, col, row, col + 1 ].Style.Font.Bold = true;
                    worksheet.Cells[ row, col ].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[ row, col ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[ row, col + 1 ].Formula = $"=SUM(C{row}:C{row - 1})";
                    worksheet.Cells[ row, col + 1 ].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
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
            if( data.Any()
                && Enum.IsDefined( typeof( Field ), column )
                && Enum.IsDefined( typeof( BOC ), filter ) )
            {
                var sum = data.Where( p => p.Field<string>( column.ToString() ).Equals( filter.ToString() ) )
                    .Select( p => p.Field<decimal>( Numeric.Amount.ToString() ) )
                    .Sum();

                return sum > 0
                    ? (double)sum
                    : default;
            }

            return default;
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
            if( grid.GetWorksheet() != null
                && grid.GetRange() != null
                && code != null
                && kvp != null )
            {
                try
                {
                    var worksheet = grid.GetWorksheet();
                    var row = grid.From.Row;
                    var col = grid.From.Column;
                    var travel = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Travel );
                    var site = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.SiteTravel );
                    var expenses = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Expenses );
                    var contracts = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Contracts );
                    var grants = CalculateBocTotal( code[ kvp.Key ], Field.BocCode, BOC.Grants );
                    var total = travel + expenses + contracts + grants;

                    switch( worksheet.Name )
                    {
                        case "SF-6A REMOVALS":
                        {
                            foreach( var p in code[ kvp.Key ] )
                            {
                                worksheet.Cells[ row, col ].Value = p.Field<string>( $"{Field.AccountCode}" )
                                    + " " 
                                    + p.Field<string>( $"{Field.OrgCode}" )
                                        ?.Replace( "0600", "-" );

                                worksheet.Cells[ row, col + 1 ].Value = site;
                                worksheet.Cells[ row, col + 2 ].Value = travel;
                                worksheet.Cells[ row, col + 3 ].Value = expenses;
                                worksheet.Cells[ row, col + 4 ].Value = contracts;
                                worksheet.Cells[ row, col + 5 ].Value = grants;
                                worksheet.Cells[ row, col + 6 ].Value = total;
                            }

                            break;
                        }

                        case "SF SPECIAL ACCT":
                        {
                            foreach( var p in code[ kvp.Key ] )
                            {
                                worksheet.Cells[ row, col ].Value = p.Field<string>( $"{Field.AccountCode}" )
                                    + "- "
                                    + p.Field<string>( $"{Field.FundCode}" );

                                worksheet.Cells[ row, col + 1 ].Value = site;
                                worksheet.Cells[ row, col + 2 ].Value = travel;
                                worksheet.Cells[ row, col + 3 ].Value = expenses;
                                worksheet.Cells[ row, col + 4 ].Value = contracts;
                                worksheet.Cells[ row, col + 5 ].Value = grants;
                                worksheet.Cells[ row, col + 6 ].Value = total;
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
