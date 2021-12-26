// <copyright file = "CalendarYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ICalendarYear"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class CalendarYear : ICalendarYear
    {
        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get; set; } 

        /// <summary>
        /// Gets or sets the work days.
        /// </summary>
        /// <value>
        /// The work days.
        /// </value>
        public IElement WorkDays { get; set; } 

        /// <summary>
        /// Gets or sets the week days.
        /// </summary>
        /// <value>
        /// The week days.
        /// </value>
        public IElement WeekDays { get; set; } 

        /// <summary>
        /// Gets or sets the week ends.
        /// </summary>
        /// <value>
        /// The week ends.
        /// </value>
        public IElement WeekEnds { get; set; } 

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        public DateTime CurrentDate = DateTime.Today;

        /// <summary>
        /// Gets the current month.
        /// </summary>
        /// <value>
        /// The current month.
        /// </value>
        public readonly int CurrentMonth = DateTime.Now.Month;

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <value>
        /// The current day.
        /// </value>
        public readonly int CurrentDay = DateTime.Now.Day;

        /// <summary>
        /// Gets the current year.
        /// </summary>
        /// <value>
        /// The current year.
        /// </value>
        public readonly int CurrentYear = DateTime.Now.Year;
        
        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetCurrentDate()
        {
            try
            {
                return CurrentDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
            }
        }

        /// <summary>
        /// Gets the current month.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetCurrentMonth()
        {
            try
            {
                return CurrentMonth;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Gets the current year.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetCurrentYear()
        {
            try
            {
                return CurrentYear;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetCurrentDay()
        {
            try
            {
                return CurrentDay;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Gets the work days.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetWorkDays()
        {
            try
            {
                return new Element( Record, Field.WorkDays );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the week days.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetWeekDays()
        {
            try
            {
                return new Element( Record, Field.WeekDays );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the week ends.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetWeekEnds()
        {
            try
            {
                return new Element( Record, Field.WeekEnds );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
