// <copyright file = "Validate.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Validate
    {
        // ***************************************************************************************************************************
        // ****************************************************    METHODS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Determines whether the specified field is field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified field is field; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool Field<T>( T field ) where T : struct
        {
            if( !Enum.IsDefined( typeof( Field ), field ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified source is source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified source is source; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool Source<T>( T source ) where T : struct
        {
            if( !Enum.IsDefined( typeof( Source ), source ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified provider is provider.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified provider is provider; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool Provider<T>( T provider ) where T : struct
        {
            if( !Enum.IsDefined( typeof( Provider ), provider ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified NPM is NPM.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="npm">The NPM.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified NPM is NPM; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool NPM<T>( T npm ) where T : struct
        {
            if( !Enum.IsDefined( typeof( NPM ), npm ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified extension is extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extension">The extension.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified extension is extension; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool EXT<T>( T extension ) where T : struct
        {
            if( !Enum.IsDefined( typeof( EXT ), extension ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified boc is boc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="boc">The boc.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified boc is boc; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool BOC<T>( T boc ) where T : struct
        {
            if( !Enum.IsDefined( typeof( BOC ), boc ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified bfy is bfy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bfy">The bfy.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified bfy is bfy; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool BFY<T>( T bfy ) where T : struct
        {
            if( !Enum.IsDefined( typeof( BFY ), bfy ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified rc is rc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rc">The rc.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified rc is rc; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool RC<T>( T rc ) where T : struct
        {
            if( !Enum.IsDefined( typeof( RC ), rc ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Grids the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns></returns>
        public static bool Grid( IGrid grid )
        {
            if( grid.GetColumnCount() > 0
                && grid?.GetRowCount() > 0
                && grid?.GetWorksheet() != null
                && grid?.GetRange() != null )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Availabilities the specified avail.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="avail">The avail.</param>
        /// <returns></returns>
        public static bool Availability<T>( T avail )
        {
            if( !Enum.IsDefined( typeof( Availability ), avail ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether [is chart type] [the specified charttype].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="charttype">The charttype.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is chart type] [the specified charttype]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool ChartType<T>( T charttype ) where T : struct
        {
            if( !Enum.IsDefined( typeof( ChartType ), charttype ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether [is fund code] [the specified fundcode].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fundcode">The fundcode.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is fund code] [the specified fundcode]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool FundCode<T>( T fundcode ) where T : struct
        {
            if( !Enum.IsDefined( typeof( FundCode ), fundcode ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified rpio is rpio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rpio">The rpio.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified rpio is rpio; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool RPIO<T>( T rpio ) where T : struct
        {
            if( !Enum.IsDefined( typeof( RPIO ), rpio ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified stat is stat.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stat">The stat.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified stat is stat; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool STAT<T>( T stat ) where T : struct
        {
            if( !Enum.IsDefined( typeof( STAT ), stat ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether [is primary key] [the specified key].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is primary key] [the specified key]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool PrimaryKey<T>( T key ) where T : struct
        {
            if( !Enum.IsDefined( typeof( PrimaryKey ), key ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified numeric is numeric.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numeric">The numeric.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified numeric is numeric; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool Numeric<T>( T numeric ) where T : struct
        {
            if( !Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether [is image resource] [the specified imageresource].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imageresource">The imageresource.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is image resource] [the specified imageresource]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool ImageResource<T>( T imageresource ) where T : struct
        {
            if( !Enum.IsDefined( typeof( ImageSource ), imageresource ) )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
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