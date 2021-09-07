// <copyright file = "Time.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TimeBase" />
    /// <seealso cref="ITime" />
    /// <seealso cref="TimeBase" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeModifiersOrder" ) ]
    public class Time : TimeBase, ITime
    {
        /// <summary>
        /// The default
        /// </summary>
        public static readonly Time Default = new Time( EventDate.NS );
        
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
            _name = SetName( kvp.Key );
            _date = SetDate( kvp.Key );
            _day = SetDay( kvp.Value?.ToString() );
            _data = _day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Time( string name, string value = "" )
        {
            _name = SetName( name );
            _date = SetDate( name );
            _day = SetDay( value );
            _data = _day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="value">The value.</param>
        public Time( EventDate date, string value = "" )
        {
            _name = SetName( date );
            _date = SetDate( date.ToString() );
            _day = SetDay( value );
            _data = _day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="dataRow">The data.</param>
        /// <param name="date">The date.</param>
        public Time( DataRow dataRow, EventDate date )
        {
            _date = SetDate( dataRow, date );
            _name = SetName( dataRow, date );
            _day = SetDay( dataRow, date );
            _data = _day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="dataRow">The data.</param>
        /// <param name="value">The value.</param>
        public Time( DataRow dataRow, string value )
        {
            _date = SetDate( dataRow, value );
            _name = SetName( dataRow, value );
            _day = SetDay( dataRow, value );
            _data = _day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="dataRow">The data.</param>
        /// <param name="column">The column.</param>
        public Time( DataRow dataRow, DataColumn column )
        {
            _date = SetDate( dataRow, column.ColumnName );
            _name = SetName( dataRow, column.ColumnName );
            _day = SetDay( dataRow, dataRow[ column ]?.ToString() );
            _data = _day.ToString();
        }
        
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        private protected EventDate _date;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected DateTime _day;
        
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDay()
        {
            try
            {
                return Verify.DateTime( _day )
                    ? _day
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), _date )
                    ? _date.ToString()
                    : EventDate.NS.ToString();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EventDate.NS.ToString();
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), _date ) 
                    && Verify.EventDate( _date )
                        ? $"{_name} = {_day}"
                        : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        public EventDate GetEventDate()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), _date )
                    ? _date
                    : EventDate.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EventDate.NS;
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
                return !Verify.DateTime( _day )
                    ? _name + " = " + _day
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
                    if( day?.GetValue()?.Equals( _day ) == true
                        && day?.GetName() == _name )
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