// <copyright file = "TimeBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.UnitBase" />
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class TimeBase : UnitBase
    {
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private protected string GetDate( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    return Verify.Input( name )
                        ? name
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private protected string GetDate( DataRow dataRow, string name )
        {
            if( dataRow != null
                && Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var _columns = dataRow.Table?.GetColumnNames();

                    return _columns?.Contains( name ) == true
                        ? name
                        : EventDate.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EventDate.NS.ToString();
                }
            }

            return EventDate.NS.ToString();
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private protected string GetDate( EventDate date )
        {
            try
            {
                return Verify.EventDate( date )
                    ? date.ToString()
                    : EventDate.NS.ToString();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EventDate.NS.ToString();
            }
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private protected string GetDate( DataRow dataRow, EventDate date )
        {
            if( Verify.Row( dataRow )
                && Verify.EventDate( date ) )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    return _names?.Contains( date.ToString() ) == true
                        ? date.ToString()
                        : EventDate.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EventDate.NS.ToString();
                }
            }

            return EventDate.NS.ToString();
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private protected EventDate SetDate( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var _date = (EventDate)Enum.Parse( typeof( EventDate ), name );

                    return Enum.IsDefined( typeof( EventDate ), _date )
                        ? _date
                        : default( EventDate );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EventDate.NS;
                }
            }

            return EventDate.NS;
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private protected EventDate SetDate( DataRow dataRow, string name )
        {
            if( dataRow != null
                && Verify.Input( name ) )
            {
                try
                {
                    var _date = (EventDate)Enum.Parse( typeof( EventDate ), name );
                    var _columns = dataRow.Table?.GetColumnNames();

                    if( _columns?.Any() == true
                        && _columns?.Contains( $"{_date}" ) == true )
                    {
                        return Enum.GetNames( typeof( EventDate ) )?.Contains( $"{_date}" ) == true
                            ? _date
                            : EventDate.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EventDate.NS;
                }
            }

            return EventDate.NS;
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private protected virtual EventDate SetDate( DataRow dataRow, EventDate date )
        {
            if( dataRow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    if( _names?.Any() == true )
                    {
                        return _names?.Contains( date.ToString() ) == true
                            ? date
                            : EventDate.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EventDate.NS;
                }
            }

            return EventDate.NS;
        }

        /// <summary>
        /// Sets the day.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private protected DateTime SetDay( string value )
        {
            try
            {
                return Verify.Input( value )
                    ? DateTime.Parse( value )
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
            }
        }

        /// <summary>
        /// Sets the day.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        private protected DateTime SetDay( DataRow dataRow, string column )
        {
            if( dataRow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    var _timeString = dataRow[ column ]?.ToString();

                    return _names?.Contains( column ) == true && Verify.Input( _timeString )
                        ? DateTime.Parse( _timeString )
                        : default( DateTime );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DateTime );
                }
            }

            return default( DateTime );
        }

        /// <summary>
        /// Sets the day.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private protected DateTime SetDay( DataRow dataRow, EventDate date )
        {
            if( dataRow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var value = dataRow[ $"{date}" ]?.ToString();

                    return DateTime.Parse( value ) != null
                        ? DateTime.Parse( value )
                        : default( DateTime );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DateTime );
                }
            }

            return default( DateTime );
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private protected string SetValue( string value )
        {
            try
            {
                return Verify.Input( value )
                    ? value
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        private protected string SetValue( DataRow dataRow, string column )
        {
            if( dataRow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();
                    var _input = dataRow[ column ]?.ToString();

                    return _names?.Contains( column ) == true && Verify.Input( _input )
                        ? dataRow[ column ].ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private protected string SetValue( DataRow dataRow, EventDate date )
        {
            if( dataRow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var _timeString = dataRow[ $"{date}" ]?.ToString();

                    return DateTime.Parse( _timeString ) != null
                        ? dataRow[ $"{date}" ]?.ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }
    }
}