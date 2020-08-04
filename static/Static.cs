// <copyright file = "Static.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "NotAccessedVariable" ) ]
    [ SuppressMessage( "ReSharper", "CompareNonConstrainedGenericWithNull" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    public static class Static
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The current directory
        /// </summary>
        public static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        /// <summary>
        /// The base directory
        /// </summary>
        public static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// The connection string
        /// </summary>
        public static readonly ConnectionStringSettingsCollection ConnectionString =
            ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// Gets the type of the SQL.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetSqlType( this Type type )
        {
            try
            {
                type = Nullable.GetUnderlyingType( type ) ?? type;

                switch( type.Name )
                {
                    case "String":
                    case "Boolean":
                        return "Text";

                    case "DateTime":
                        return "Date";

                    case "Int32":
                        return "Double";

                    case "Decimal":
                        return "Currency";

                    default:
                        return type.Name;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">connection</exception>
        public static IDbCommand CreateCommand( this IDbConnection connection, string sql )
        {
            try
            {
                if( connection == null )
                {
                    throw new ArgumentNullException( nameof( connection ) );
                }

                var retval = connection?.CreateCommand();
                retval.CommandText = sql;

                return Verify.Input( retval?.CommandText )
                    ? retval
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery( this IDbConnection connection, string sql )
        {
            try
            {
                using var command = connection.CreateCommand( sql );
                return command.ExecuteNonQuery();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Converts to logstring.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static string ToLogString( this Exception ex, string message )
        {
            try
            {
                var msg = new StringBuilder();

                if( Verify.Input( message ) )
                {
                    msg.Append( message );
                    msg.Append( Environment.NewLine );
                }

                if( ex != null )
                {
                    var orgex = ex;
                    msg.Append( "Exception:" );
                    msg.Append( Environment.NewLine );

                    while( orgex != null )
                    {
                        msg.Append( orgex.Message );
                        msg.Append( Environment.NewLine );
                        orgex = orgex.InnerException;
                    }

                    if( ex.Data != null )
                    {
                        foreach( var i in ex.Data )
                        {
                            msg.Append( "Data :" );
                            msg.Append( i );
                            msg.Append( Environment.NewLine );
                        }
                    }

                    if( ex.StackTrace != null )
                    {
                        msg.Append( "StackTrace:" );
                        msg.Append( Environment.NewLine );
                        msg.Append( ex.StackTrace );
                        msg.Append( Environment.NewLine );
                    }

                    if( ex.Source != null )
                    {
                        msg.Append( "Source:" );
                        msg.Append( Environment.NewLine );
                        msg.Append( ex.Source );
                        msg.Append( Environment.NewLine );
                    }

                    if( ex.TargetSite != null )
                    {
                        msg.Append( "TargetSite:" );
                        msg.Append( Environment.NewLine );
                        msg.Append( ex.TargetSite );
                        msg.Append( Environment.NewLine );
                    }

                    var baseexception = ex.GetBaseException();

                    if( baseexception != null )
                    {
                        msg.Append( "BaseException:" );
                        msg.Append( Environment.NewLine );
                        msg.Append( ex.GetBaseException() );
                    }
                }

                return msg.ToString();
            }
            catch( Exception e )
            {
                Fail( e );
                return default;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <param name="nvm">The NVM.</param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary( this NameValueCollection nvm )
        {
            try
            {
                var dict = new Dictionary<string, object>();

                if( nvm != null )
                {
                    foreach( var key in nvm.AllKeys )
                    {
                        dict.Add( key, nvm[ key ] );
                    }
                }

                return dict;
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
        public static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}