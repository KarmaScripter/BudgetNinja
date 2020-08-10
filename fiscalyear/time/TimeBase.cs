// // <copyright file = "TimeBase.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "UnitBase"/>
    /// <seealso cref = "IUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class TimeBase : Unit
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
                && Enum.GetNames( typeof( Date ) )?.Contains( name ) == true )
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
                && Enum.GetNames( typeof( Date ) )?.Contains( name ) == true )
            {
                try
                {
                    var columns = datarow.Table?.GetColumnNames();

                    return columns?.Contains( name ) == true
                        ? name
                        : Date.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Date.NS.ToString();
                }
            }

            return Date.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( Date date )
        {
            try
            {
                return Verify.Date( date )
                    ? date.ToString()
                    : Date.NS.ToString();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Date.NS.ToString();
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
        private protected string SetName( DataRow datarow, Date date )
        {
            if( Verify.Row( datarow )
                && Verify.Date( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    return names?.Contains( date.ToString() ) == true
                        ? date.ToString()
                        : Date.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Date.NS.ToString();
                }
            }

            return Date.NS.ToString();
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Date SetDate( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( Date ) )?.Contains( name ) == true )
            {
                try
                {
                    var date = (Date)Enum.Parse( typeof( Date ), name );

                    return Enum.IsDefined( typeof( Date ), date )
                        ? date
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Date.NS;
                }
            }

            return Date.NS;
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
        private protected Date SetDate( DataRow datarow, string name )
        {
            if( datarow != null
                && Verify.Input( name ) )
            {
                try
                {
                    var date = (Date)Enum.Parse( typeof( Date ), name );
                    var columns = datarow.Table?.GetColumnNames();

                    if( columns?.Any() == true
                        && columns?.Contains( $"{date}" ) == true )
                    {
                        return Enum.GetNames( typeof( Date ) )?.Contains( $"{date}" ) == true
                            ? date
                            : Date.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Date.NS;
                }
            }

            return Date.NS;
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
        private protected Date SetDate( DataRow datarow, Date date )
        {
            if( datarow != null
                && Verify.Date( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    if( names?.Any() == true )
                    {
                        return names?.Contains( date.ToString() ) == true
                            ? date
                            : Date.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Date.NS;
                }
            }

            return Date.NS;
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
                && Enum.GetNames( typeof( Date ) )?.Contains( column ) == true )
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
        private protected DateTime SetDay( DataRow datarow, Date date )
        {
            if( datarow != null
                && Verify.Date( date ) )
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
                && Enum.GetNames( typeof( Date ) )?.Contains( column ) == true )
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
        private protected string SetValue( DataRow datarow, Date date )
        {
            if( datarow != null
                && Verify.Date( date ) )
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
