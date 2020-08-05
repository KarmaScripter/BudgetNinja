// <copyright file="UnitBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class UnitBase 
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected object Data { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected string Value { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected virtual string GetName( string name )
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

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected object GetData( object data )
        {
            try
            {
                return Verify.Input( data?.ToString() )
                    ? data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private protected string GetValue( object data )
        {
            try
            {
                return Verify.Input( data?.ToString() )
                    ? data?.ToString()
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
        /// <param name = "unit" >
        /// The element.
        /// </param>
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
        public virtual bool IsEqual( IUnit unit )
        {
            if( Verify.Ref( unit ) )
            {
                try
                {
                    return unit.GetName()?.Equals( Name ) == true
                        && unit.GetValue()?.Equals( Value ) == true;
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