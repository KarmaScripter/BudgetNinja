// <copyright file = "BudgetFiscalYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// When a law appropriates budget authority, it sets the period during which you
    /// can use it to incur newobligations. We call this the period of availability for
    /// new obligations of the budget authority, and the period normally is specified
    /// in the law providing the budget authority. The period of availability for
    /// incurring new obligations is shorter than the period of availability for making
    /// disbursements, which iscovered by a general law.  The period of availability is
    /// described by the Budget Fiscal Year. The fiscal year of the Treasury begins on
    /// October 1 of each year and ends on September 30 of the following year. Accounts
    /// of receipts and expenditures required under law to be published each year shall
    /// be published for the fiscal year.
    /// </summary>
    /// <inheritdoc cref = "T:BudgetExecution.BudgetFiscalYear"/>
    /// <summary>
    /// Defines the <see cref = "T:BudgetExecution.BudgetFiscalYear"/>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class BudgetFiscalYear : FiscalYear, IBudgetFiscalYear, ISource
    {
        // **************************************************************************************************************************
        // ****************************************************     FIELDS    *******************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        private static readonly Source Source = Source.FiscalYears;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        public BudgetFiscalYear()
        {
            Record = new DataBuilder( Source, Provider.SQLite, SetArgs( GetCurrentYear().ToString() ) )
                ?.GetRecord();

            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy <see cref = "string"/>
        /// </param>
        public BudgetFiscalYear( string bfy )
        {
            InputYear = new Element( Field.BFY, bfy );
            Record = new DataBuilder( Source, SetArgs( bfy ) )?.GetRecord();
            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public BudgetFiscalYear( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public BudgetFiscalYear( IBuilder builder )
        {
            Record = builder?.GetRecord();
            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        /// <param name = "fy" >
        /// The fy <see cref = "BFY"/>
        /// </param>
        public BudgetFiscalYear( BFY fy )
        {
            Record = new DataBuilder( Source, Provider.SQLite, SetArgs( fy ) )?.GetRecord();
            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFiscalYear"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data <see cref = "DataRow"/>
        /// </param>
        public BudgetFiscalYear( DataRow data )
        {
            Record = data;
            InputYear = new Element( Record, GetCurrentYear().ToString() );
            FiscalYearId = new Key( Record, PrimaryKey.FiscalYearId );
            BBFY = new Element( Record, Field.BBFY );
            EBFY = new Element( Record, Field.EBFY );
            Availablity = new Element( Record, Field.Availability );
            FirstYear = new Element( Record, Field.FirstYear );
            LastYear = new Element( Record, Field.LastYear );
            Holidays = new HolidayFactory( Record );
            WorkDays = new Element( Record, Field.WorkDays );
            WeekDays = new Element( Record, Field.WeekDays );
            WeekEnds = new Element( Record, Field.WeekEnds );
            ExpiringYear = new Element( Record, Field.ExpiringYear );
            StartDate = new Element( Record, Field.StartDate );
            EndDate = new Element( Record, Field.EndDate );
            CancellationDate = new Element( Record, Field.CancellationDate );
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the holidays.
        /// </summary>
        /// <value>
        /// The holidays.
        /// </value>
        private HolidayFactory Holidays { get; }

        /// <summary>
        /// Gets the availablity.
        /// </summary>
        /// <value>
        /// The availablity.
        /// </value>
        private IElement Availablity { get; }

        /// <summary>
        /// Gets or sets the federal holidays.
        /// </summary>
        /// <value>
        /// The federal holidays.
        /// </value>
        private IDictionary<Holiday, DateTime> FederalHolidays { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the fiscal year identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetFiscalYearId()
        {
            try
            {
                return Verify.Key( FiscalYearId )
                    ? FiscalYearId
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the first year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFirstYear()
        {
            try
            {
                return Verify.Element( FirstYear )
                    ? FirstYear
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the last year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetLastYear()
        {
            try
            {
                return Verify.Element( LastYear )
                    ? LastYear
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the availability.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetAvailability()
        {
            try
            {
                return Verify.Element( Availablity )
                    ? Availablity
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the federal holidays.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<Field, DateTime> GetFederalHolidays()
        {
            try
            {
                var holidays = new Dictionary<Field, DateTime>();
                var holidayfactory = new HolidayFactory( Record );
                holidays.Add( Field.NewYears, DateTime.Parse( holidayfactory.GetNewYearsDay().GetValue() ) );

                holidays.Add( Field.MartinLutherKing,
                    DateTime.Parse( holidayfactory.GetMartinLutherKingDay().GetValue() ) );

                holidays.Add( Field.Memorial, DateTime.Parse( holidayfactory.GetMemorialDay().GetValue() ) );

                holidays.Add( Field.Presidents,
                    DateTime.Parse( holidayfactory.GetPresidentsDay().GetValue() ) );

                holidays.Add( Field.Veterans, DateTime.Parse( holidayfactory.GetVeteransDay().GetValue() ) );
                holidays.Add( Field.Labor, DateTime.Parse( holidayfactory.GetLaborDay().GetValue() ) );

                holidays.Add( Field.Independence,
                    DateTime.Parse( holidayfactory.GetIndependenceDay().GetValue() ) );

                holidays.Add( Field.Columbus, DateTime.Parse( holidayfactory.GetColumbusDay().GetValue() ) );

                holidays.Add( Field.Thanksgiving,
                    DateTime.Parse( holidayfactory.GetThanksgivingDay().GetValue() ) );

                holidays.Add( Field.Christmas,
                    DateTime.Parse( holidayfactory.GetChristmasDay().GetValue() ) );

                return holidays.Any()
                    ? holidays
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc cref = "T:System.String"/>
        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>
        /// The <see cref = "T:System.String"/>
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( FirstYear?.GetValue() )
                    ? FirstYear?.GetValue()
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
                return MemberwiseClone() as BudgetFiscalYear;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetFiscalYear );
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
                return Verify.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }
    }
}
