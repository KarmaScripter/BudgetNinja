// <copyright file = "Verify.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Verify : Validate
    {
        // ***************************************************************************************************************************
        // ****************************************************    METHODS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Datas the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Table<T>( T input )
            where T : IListSource
        {
            if( !input?.ContainsListCollection == true )
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
        /// Rows the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Row<T>( T input )
            where T : DataRow
        {
            if( !input?.ItemArray?.Any() == true )
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
        /// Inputs the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Input( object input )
        {
            if( string.IsNullOrEmpty( input?.ToString() ) )
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
        /// Inputs the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Rows<T>( T input ) 
            where T : IEnumerable<DataRow>
        {
            if( !input?.Any() == true )
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
        /// Maps the specified map.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public static bool Map( IMap map )
        {
            if( map?.Count <= 0 )
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
        /// Keys the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool Key( IKey key )
        {
            if( key?.GetIndex() <= 0 )
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
        /// Amounts the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static bool Amount( IAmount amount )
        {
            if( amount?.GetFunding() <= 0 )
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
        /// Elements the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static bool Element( IElement element )
        {
            if( string.IsNullOrEmpty( element?.GetValue() ) )
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
        /// Maps the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Map<T>( T input ) 
            where T : IDictionary<string, object>
        {
            if( !input?.Any() == true )
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
        /// Determines whether the specified input is bindable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is bindable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBindable<T>( T input )
            where T : IBindingList
        {
            if( input?.IsEmpty() == true )
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
        /// Sequences the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Sequence<T>( IEnumerable<T> input )
        {
            if( input?.Any() == true )
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
        /// Determines whether [is image format] [the specified imageformat].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imageformat">The imageformat.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is image format] [the specified imageformat]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool ImageFormat<T>( T imageformat ) where T : struct
        {
            if( !Enum.IsDefined( typeof( ImageFormat ), imageformat ) )
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
        /// Determines whether [is image size] [the specified imagesize].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imagesize">The imagesize.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is image size] [the specified imagesize]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool ImageSize<T>( T imagesize ) where T : struct
        {
            if( !Enum.IsDefined( typeof( ImageSizer ), imagesize ) )
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
        /// Determines whether [is transfer type] [the specified transfer].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="transfer">The transfer.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is transfer type] [the specified transfer]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool TransferType<T>( T transfer ) where T : struct
        {
            if( !Enum.IsDefined( typeof( TransferType ), transfer ) )
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
        /// Determines whether the specified source is authority.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified source is authority; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsAuthority<T>( T source ) where T : struct
        {
            var input = (Source)Enum.Parse( typeof( Source ), source.ToString() );

            if( !Enum.IsDefined( typeof( Source ), source )
                || !Resource.AuthoritySources.Contains( input ) )
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
        /// Determines whether the specified source is division.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified source is division; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsDivision<T>( T source ) where T : struct
        {
            var input = (Source)Enum.Parse( typeof( Source ), source.ToString() );

            if( !Enum.IsDefined( typeof( Source ), source )
                || !Resource.DivisionSources.Contains( input ) )
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
        /// Determines whether the specified source is supplemental.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified source is supplemental; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsSupplemental<T>( T source ) where T : struct
        {
            if( Enum.IsDefined( typeof( Source ), source ) )
            {
                var input = (Source)Enum.Parse( typeof( Source ), source.ToString() );
                return Resource.SupplementalSources.Contains( input );
            }
            else
            {
                Fail( new ArgumentException() );
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified source is outlay.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified source is outlay; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsOutlay<T>( T source ) where T : struct
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
        /// Determines whether [is date time] [the specified date].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="date">The date.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is date time] [the specified date]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool DateTime<T>( T date ) where T : struct
        {
            if( !System.DateTime.TryParse( date.ToString(), out _ ) )
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
        /// Dates the specified date.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool Date<T>( T date ) where T : struct
        {
            if( !Enum.IsDefined( typeof( Date ), date ) )
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
        /// Determines whether [is time data] [the specified date].
        /// </summary>
        /// <param name = "time" > </param>
        /// <returns>
        /// <c> true </c>
        /// if [is time data] [the specified date]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool Time( ITime time ) 
        {
            if( string.IsNullOrEmpty( time.GetName() ) )
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
        /// Nots the null.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool Ref( object input )
        {
            if( input == null )
            {
                Fail( new ArgumentException() );
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}