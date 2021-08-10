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
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow _record;

        /// <summary>
        /// Gets or sets the work days.
        /// </summary>
        /// <value>
        /// The work days.
        /// </value>
        private protected IElement _workDays;

        /// <summary>
        /// Gets or sets the week days.
        /// </summary>
        /// <value>
        /// The week days.
        /// </value>
        private protected IElement _weekDays;

        /// <summary>
        /// Gets or sets the week ends.
        /// </summary>
        /// <value>
        /// The week ends.
        /// </value>
        private protected IElement _weekEnds;

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        private protected DateTime _currentDate = DateTime.Today;

        /// <summary>
        /// Gets the current month.
        /// </summary>
        /// <value>
        /// The current month.
        /// </value>
        private protected readonly int _currentMonth = DateTime.Now.Month;

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <value>
        /// The current day.
        /// </value>
        private protected readonly int _currentDay = DateTime.Now.Day;

        /// <summary>
        /// Gets the current year.
        /// </summary>
        /// <value>
        /// The current year.
        /// </value>
        private protected readonly int _currentYear = DateTime.Now.Year;
        
        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetCurrentDate()
        {
            try
            {
                return _currentDate;
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
                return _currentMonth;
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
                return _currentYear;
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
                return _currentDay;
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
                return new Element( _record, Field.WorkDays );
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
                return new Element( _record, Field.WeekDays );
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
                return new Element( _record, Field.WeekEnds );
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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
