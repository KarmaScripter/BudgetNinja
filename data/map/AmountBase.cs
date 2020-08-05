﻿// <copyright file="AmountBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Linq;
    using System.Threading;

    public abstract class AmountBase : Unit
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected double Funding { get; set; }

        /// <summary>
        /// Gets the original.
        /// </summary>
        /// <value>
        /// The original.
        /// </value>
        private protected double Initial { get; set; }

        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        private protected double Delta { get; set; }

        /// <summary>
        /// Gets or sets the numeric.
        /// </summary>
        /// <value>
        /// The numeric.
        /// </value>
        private protected Numeric Numeric { get; set; } = Numeric.Amount;

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "colname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( string colname )
        {
            if( Verify.Input( colname )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( colname ) == true )
            {
                try
                {
                    return Verify.Input( colname )
                        ? colname
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "colname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( DataRow datarow, string colname )
        {
            if( datarow != null
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( colname ) == true )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    return names?.Contains( colname ) == true
                        ? colname
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( Numeric numeric )
        {
            if( Verify.Numeric( numeric ) )
            {
                try
                {
                    return Verify.Numeric( numeric )
                        ? numeric.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( DataRow datarow, Numeric numeric )
        {
            if( datarow != null
                && Verify.Numeric( numeric ) )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    return names?.Contains( numeric.ToString() ) == true
                        ? numeric.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Numeric GetNumeric( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( name ) == true )
            {
                try
                {
                    var numeric = (Numeric)Enum.Parse( typeof( Numeric ), name );

                    return !Enum.IsDefined( typeof( Numeric ), numeric )
                        ? numeric
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Numeric GetNumeric( DataRow data, string name )
        {
            if( data != null
                && Verify.Input( name ) )
            {
                try
                {
                    var numeric = (Numeric)Enum.Parse( typeof( Numeric ), name );
                    var names = data?.Table?.GetColumnNames();

                    if( names?.Any() == true )
                    {
                        return names?.Contains( $"{numeric}" ) == true
                            ? numeric
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Numeric GetNumeric( Numeric numeric )
        {
            try
            {
                return Verify.Numeric( numeric )
                    ? numeric
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Numeric GetNumeric( DataRow data, Numeric numeric )
        {
            if( data != null
                && Verify.Numeric( numeric ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    return columns.Contains( numeric.ToString() )
                        ? numeric
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetValue( string value )
        {
            try
            {
                if( Verify.Input( value )
                    && Enum.GetNames( typeof( Numeric ) ).Contains( value ) )
                {
                    Data = value;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetValue( DataRow data, string value )
        {
            if( data != null
                && Verify.Input( value )
                && Enum.GetNames( typeof( Numeric ) ).Contains( value ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    return columns.Contains( value )
                        ? data[ value ].ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetValue( DataRow data, Numeric numeric )
        {
            if( data != null
                && Verify.Numeric( numeric ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    return columns.Contains( numeric.ToString() )
                        ? data[ $"{numeric}" ].ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// </returns>
        public double GetFunding()
        {
            try
            {
                return Funding;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetAmount()
        {
            try
            {
                var amount = GetFunding();

                return amount != default
                    ? new Amount( amount )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}