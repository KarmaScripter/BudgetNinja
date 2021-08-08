﻿// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.IMetric" />
    /// <seealso cref="BudgetExecution.IDataFilter" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "BadListLineBreaks" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public abstract class MetricBase : IMetric, IDataFilter
    {
        /// <summary>
        /// The field
        /// </summary>
        private protected Field _field;

        /// <summary>
        /// The numeric
        /// </summary>
        private protected Numeric _numeric;

        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The data
        /// </summary>
        private protected IEnumerable<DataRow> _data;

        /// <summary>
        /// The total
        /// </summary>
        private protected double _total;

        /// <summary>
        /// The average
        /// </summary>
        private protected double _average;

        /// <summary>
        /// The statistics
        /// </summary>
        private protected IDictionary<string, IEnumerable<double>> _statistics;

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <returns></returns>
        public Field GetField()
        {
            try
            {
                return _field;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Field );
            }
        }

        /// <summary>
        /// Gets the numeric.
        /// </summary>
        /// <returns></returns>
        public Numeric GetNumeric()
        {
            try
            {
                return Validate.Numeric( _numeric ) 
                    ? _numeric 
                    : default( Numeric );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Numeric );
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataRow> GetData()
        {
            try
            {
                return Verify.Rows( _data )
                    ? _data
                    : default( IEnumerable<DataRow> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataRow> );
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<DataRow> FilterData( Field field, string filter )
        {
            if( Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var _query = _data
                        ?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return _query?.Any() == true
                        ? _query
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the codes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetCodes( IEnumerable<DataRow> data, Field field )
        {
            if( data.Any()
                && Verify.Input( $"{field}" ) )
            {
                try
                {
                    var _query = data
                        ?.Select( p => p.Field<string>( $"{field}" ) )
                        ?.Distinct()
                        ?.ToArray();

                    return _query.Length > 0
                        ? _query
                        : default( string[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public int GetCount( IEnumerable<DataRow> data, Numeric numeric = Numeric.Amount )
        {
            if( data.Any() )
            {
                try
                {
                    var _select = data
                        ?.Where( p => p.Field<double>( $"{numeric}" ) != 0.0D )
                        ?.Select( p => p );

                    return _select.Any()
                        ? _select.Count()
                        : default( int );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// Calculates the totals.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public double CalculateTotals( IEnumerable<DataRow> data, Numeric numeric = Numeric.Amount )
        {
            if( data?.Any() == true )
            {
                try
                {
                    var _select = data
                        ?.Select( p => p.Field<double>( $"{numeric}" ) );

                    return _select.Any() && _select?.Sum() > 0
                        ? _select.Sum()
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( double );
        }

        /// <summary>
        /// Calculates the totals.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public IDictionary<string, double> CalculateTotals( IEnumerable<DataRow> data, Field field, 
            Numeric numeric = Numeric.Amount )
        {
            if( data?.Any() == true
                && Enum.IsDefined( typeof( Field ), field )
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, double>();
                    var _codes = GetCodes( data, field );

                    if( _codes.Any() )
                    {
                        foreach( var filter in _codes )
                        {
                            var _query = data.Filter( field.ToString(), filter )
                                ?.Sum( p => p.Field<double>( $"{numeric}" ) );

                            if( _query > 0.0d )
                            {
                                _dictionary?.Add( filter, double.Parse( _query?.ToString() ) );
                            }
                        }

                        return _dictionary?.Any() == true
                            ? _dictionary
                            : default( Dictionary<string, double> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, double> );
                }
            }

            return default( IDictionary<string, double> );
        }

        /// <summary>
        /// Calculates the average.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        private protected double CalculateAverage( IEnumerable<DataRow> data, Numeric numeric = Numeric.Amount )
        {
            if( data?.Any() == true
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _query = data
                        .Where( p => p.Field<double>( $"{numeric}" ) != 0.0 )
                        ?.Select( p => p.Field<double>( $"{numeric}" ) )
                        ?.Average();

                    return _query > 0d
                        ? double.Parse( _query?.ToString() )
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return 0.0d;
                }
            }

            return 0.0d;
        }

        /// <summary>
        /// Calculates the averages.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public IDictionary<string, double> CalculateAverages( IEnumerable<DataRow> data, Field field,
            Numeric numeric = Numeric.Amount )
        {
            if( data?.Any() == true
                && Enum.IsDefined( typeof( Field ), field )
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, double>();
                    var _filters = GetCodes( data, field );

                    if( _filters.Any() )
                    {
                        foreach( var filter in _filters )
                        {
                            var _query = data?.Filter( field.ToString(), filter );

                            if( _query?.Any() == true )
                            {
                                var _value = CalculateAverage( _query, numeric );

                                if( _value > 0.0d )
                                {
                                    _dictionary?.Add( filter, _value );
                                }
                            }
                        }

                        return _dictionary.Any()
                            ? _dictionary
                            : default( Dictionary<string, double> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, double> );
                }
            }

            return default( IDictionary<string, double> );
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}