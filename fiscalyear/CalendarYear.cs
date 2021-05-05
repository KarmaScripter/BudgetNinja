// <copyright file = "CalendarYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ICalendarYear"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public abstract class CalendarYear : ICalendarYear
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the work days.
        /// </summary>
        /// <value>
        /// The work days.
        /// </value>
        private protected IElement WorkDays { get; set; }

        /// <summary>
        /// Gets or sets the week days.
        /// </summary>
        /// <value>
        /// The week days.
        /// </value>
        private protected IElement WeekDays { get; set; }

        /// <summary>
        /// Gets or sets the week ends.
        /// </summary>
        /// <value>
        /// The week ends.
        /// </value>
        private protected IElement WeekEnds { get; set; }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        private protected DateTime CurrentDate { get; } = DateTime.Today;

        /// <summary>
        /// Gets the current month.
        /// </summary>
        /// <value>
        /// The current month.
        /// </value>
        private protected int CurrentMonth { get; } = DateTime.Now.Month;

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <value>
        /// The current day.
        /// </value>
        private protected int CurrentDay { get; } = DateTime.Now.Day;

        /// <summary>
        /// Gets the current year.
        /// </summary>
        /// <value>
        /// The current year.
        /// </value>
        private protected int CurrentYear { get; } = DateTime.Now.Year;

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                return default;
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
                return default;
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
                return default;
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
                return default;
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
                return default;
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
                return default;
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
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
