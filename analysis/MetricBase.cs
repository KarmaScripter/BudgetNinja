// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
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
        public Field Field { get; set; }

        /// <summary>
        /// The numeric
        /// </summary>
        public Numeric Numeric { get; set; }

        /// <summary>
        /// The count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The dataRow
        /// </summary>
        public IEnumerable<DataRow> Data { get; set; }

        /// <summary>
        /// The total
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// The average
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// The statistics
        /// </summary>
        public IDictionary<string, IEnumerable<double>> Statistics { get; set; }

        /// <summary>
        /// Gets the dataRow.
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
                    var _query = Data
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetCodes( IEnumerable<DataRow> dataRow, Field field )
        {
            if( dataRow.Any()
                && Verify.Input( $"{field}" ) )
            {
                try
                {
                    var _query = dataRow
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public int GetCount( IEnumerable<DataRow> dataRow, Numeric numeric = Numeric.Amount )
        {
            if( dataRow.Any() )
            {
                try
                {
                    var _select = dataRow
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public double CalculateTotals( IEnumerable<DataRow> dataRow, Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true )
            {
                try
                {
                    var _select = dataRow
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="field">The field.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public IDictionary<string, double> CalculateTotals( IEnumerable<DataRow> dataRow, Field field, 
            Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Enum.IsDefined( typeof( Field ), field )
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, double>();
                    var _codes = GetCodes( dataRow, field );

                    if( _codes.Any() )
                    {
                        foreach( var filter in _codes )
                        {
                            var _query = dataRow.Filter( field.ToString(), filter )
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        private protected double CalculateAverage( IEnumerable<DataRow> dataRow, Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _query = dataRow
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
        /// <param name="dataRow">The dataRow.</param>
        /// <param name="field">The field.</param>
        /// <param name="numeric">The numeric.</param>
        /// <returns></returns>
        public IDictionary<string, double> CalculateAverages( IEnumerable<DataRow> dataRow, Field field,
            Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Enum.IsDefined( typeof( Field ), field )
                && Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, double>();
                    var _filters = GetCodes( dataRow, field );

                    if( _filters.Any() )
                    {
                        foreach( var filter in _filters )
                        {
                            var _query = dataRow?.Filter( field.ToString(), filter );

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
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}