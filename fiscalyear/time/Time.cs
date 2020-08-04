// <copyright file="Time.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TimeBase" />
    /// <seealso cref="ITime" />
    /// <seealso cref="TimeBase" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class Time : TimeBase, ITime
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The default
        /// </summary>
        public static readonly Time Default = new Time( Date.NS );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        public Time()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="kvp">The KVP.</param>
        public Time( KeyValuePair<string, object> kvp )
        {
            Name = SetName( kvp.Key );
            Date = SetDate( kvp.Key );
            Day = SetDay( kvp.Value?.ToString() );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Time( string name, string value = "" )
        {
            Name = SetName( name );
            Date = SetDate( name );
            Day = SetDay( value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="value">The value.</param>
        public Time( Date date, string value = "" )
        {
            Name = SetName( date );
            Date = SetDate( date.ToString() );
            Day = SetDay( value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="date">The date.</param>
        public Time( DataRow datarow, Date date )
        {
            Date = SetDate( datarow, date );
            Name = SetName( datarow, date );
            Day = SetDay( datarow, date );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="value">The value.</param>
        public Time( DataRow datarow, string value )
        {
            Date = SetDate( datarow, value );
            Name = SetName( datarow, value );
            Day = SetDay( datarow, value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="column">The column.</param>
        public Time( DataRow datarow, DataColumn column )
        {
            Date = SetDate( datarow, column.ColumnName );
            Name = SetName( datarow, column.ColumnName );
            Day = SetDay( datarow, datarow[ column ]?.ToString() );
            Data = Day.ToString();
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        private protected Date Date { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected DateTime Day { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDay()
        {
            try
            {
                return Verify.DateTime( Day )
                    ? Day
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
            }
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        public Date GetDate()
        {
            try
            {
                return Enum.IsDefined( typeof( Date ), Date )
                    ? Date
                    : Date.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Date.NS;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return !Verify.DateTime( Day )
                    ? Name + " = " + Day
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the specified element is equal.
        /// </summary>
        /// <param name="day">The element.</param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified element is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public bool IsEqual( ITime day )
        {
            if( day != null
                && day != Default )
            {
                try
                {
                    if( day?.GetValue()?.Equals( Day ) == true
                        && day?.GetName() == Name )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified primary is equal.
        /// </summary>
        /// <param name="first">The primary.</param>
        /// <param name="second">The secondary.</param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified primary is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public static bool IsEqual( ITime first, ITime second )
        {
            if( first != null
                && first != Element.Default
                && first != null
                && second != Element.Default )
            {
                try
                {
                    if( first?.GetValue()?.Equals( second?.GetValue() ) == true
                        && first?.GetName() == second?.GetName() )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }
    }
}