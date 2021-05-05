// <copyright file = "TimeBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "UnitBase"/>
    /// <seealso cref = "IUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class TimeBase : UnitBase
    {
        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( string name )
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
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( DataRow datarow, string name )
        {
            if( datarow != null
                && Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var columns = datarow.Table?.GetColumnNames();

                    return columns?.Contains( name ) == true
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
        /// Sets the name.
        /// </summary>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( EventDate date )
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
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( DataRow datarow, EventDate date )
        {
            if( Verify.Row( datarow )
                && Verify.EventDate( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    return names?.Contains( date.ToString() ) == true
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
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected EventDate SetDate( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var date = (EventDate)Enum.Parse( typeof( EventDate ), name );

                    return Enum.IsDefined( typeof( EventDate ), date )
                        ? date
                        : default;
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
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected EventDate SetDate( DataRow datarow, string name )
        {
            if( datarow != null
                && Verify.Input( name ) )
            {
                try
                {
                    var date = (EventDate)Enum.Parse( typeof( EventDate ), name );
                    var columns = datarow.Table?.GetColumnNames();

                    if( columns?.Any() == true
                        && columns?.Contains( $"{date}" ) == true )
                    {
                        return Enum.GetNames( typeof( EventDate ) )?.Contains( $"{date}" ) == true
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
        /// Sets the date.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected EventDate SetDate( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    if( names?.Any() == true )
                    {
                        return names?.Contains( date.ToString() ) == true
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
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
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
        /// Sets the value.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "column" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected DateTime SetDay( DataRow datarow, string column )
        {
            if( datarow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();
                    var value = datarow[ column ]?.ToString();

                    return names?.Contains( column ) == true && Verify.Input( value )
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
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected DateTime SetDay( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var value = datarow[ $"{date}" ]?.ToString();

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
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
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
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetValue( DataRow datarow, string column )
        {
            if( datarow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();
                    var value = datarow[ column ]?.ToString();

                    return names?.Contains( column ) == true && Verify.Input( value )
                        ? datarow[ column ].ToString()
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
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetValue( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var value = datarow[ $"{date}" ]?.ToString();

                    return DateTime.Parse( value ) != null
                        ? datarow[ $"{date}" ]?.ToString()
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
