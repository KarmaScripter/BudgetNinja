// <copyright file = "DataMetric.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using LinqStatistics;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "MetricBase"/>
    /// <seealso cref = "IDataMetric"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class DataMetric : MetricBase, IDataMetric
    {
        /// <summary>
        /// Gets the variance.
        /// </summary>
        /// <value>
        /// The variance.
        /// </value>
        public double Variance { get; set; }

        /// <summary>
        /// Gets the deviation.
        /// </summary>
        /// <value>
        /// The deviation.
        /// </value>
        public double Deviation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataMetric"/> class.
        /// </summary>
        public DataMetric()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataMetric"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        public DataMetric( IEnumerable<DataRow> dataRow, Numeric numeric = Numeric.Amount )
        {
            Data = dataRow;
            Field = Field.NS;
            Numeric = numeric;
            Count = Data.Count();
            Total = CalculateTotals( Data, Numeric );
            Average = CalculateAverage( Data, Numeric );
            Variance = CalculateVariance( Data, Numeric );
            Deviation = CalculateDeviation( Data, Numeric );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataMetric"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        public DataMetric( IEnumerable<DataRow> dataRow, Field field, Numeric numeric = Numeric.Amount )
        {
            Field = field;
            Numeric = numeric;
            Data = dataRow;
            Count = Data.Count();
            Total = CalculateTotals( Data, Numeric );
            Average = CalculateAverage( Data, Numeric );
            Variance = CalculateVariance( Data, Numeric );
            Deviation = CalculateDeviation( Data, Numeric );
            Statistics = CalculateStatistics( Data, Field, Numeric );
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                var _source = Data
                    ?.Select( r => r )
                    ?.FirstOrDefault();

                var _name = _source
                    ?.Table
                    ?.TableName;

                return Verify.Input( _name )
                    ? _source != null
                        ? (Source)Enum.Parse( typeof( Source ), _name )
                        : Source.NS
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Calculates the deviation.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateDeviation( IEnumerable<DataRow> dataRow, Numeric numeric )
        {
            if( dataRow?.Any() == true
                && dataRow.HasNumeric()
                && GetCount( dataRow, numeric ) > 30 )
            {
                try
                {
                    var _query = dataRow
                        ?.Where( p => p.Field<double>( $"{numeric}" ) != 0d )
                        ?.StandardDeviation( p => p.Field<double>( $"{numeric}" ) );

                    return _query > 0.0d
                        ? double.Parse( _query.ToString() )
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return 0.0d;
                }
            }

            return default( double );
        }

        /// <summary>
        /// Calculates the standard deviations.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateDeviations( IEnumerable<DataRow> dataRow, Field field,
            Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Validate.Field( field )
                && Validate.Numeric( numeric ) )

            {
                if( dataRow?.Count() < 30 )
                {
                    return 0.0d;
                }

                if( dataRow.Count() > 30 )
                {
                    try
                    {
                        var _query = dataRow
                            ?.Where( p => p.Field<double>( $"{numeric}" ) != 0d )
                            ?.StandardDeviation( p => p.Field<double>( $"{numeric}" ) );

                        return _query > 0.0d
                            ? double.Parse( _query.ToString() )
                            : 0.0d;
                    }
                    catch( Exception ex )
                    {
                        Fail( ex );
                        return 0.0d;
                    }
                }
            }

            return default( double );
        }

        /// <summary>
        /// Calculates the variance.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateVariance( IEnumerable<DataRow> dataRow, Numeric numeric )
        {
            if( dataRow?.Any() == true
                && dataRow.HasNumeric()
                && GetCount( dataRow, numeric ) > 30 )
            {
                var _table = dataRow.CopyToDataTable();

                try
                {
                    var _query = _table?.AsEnumerable()
                        ?.Where( p => p.Field<double>( $"{numeric}" ) != 0d )
                        ?.Variance( p => p.Field<double>( $"{numeric}" ) );

                    return _query > 0.0d
                        ? double.Parse( _query.ToString() )
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return 0.0d;
                }
            }

            return default( double );
        }

        /// <summary>
        /// Calculates the statistics.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, IEnumerable<double>> CalculateStatistics()
        {
            try
            {
                return Statistics;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, IEnumerable<double>> );
            }
        }

        /// <summary>
        /// Calculates the variances.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateVariances( IEnumerable<DataRow> dataRow, Field field,
            Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Validate.Field( field )
                && Validate.Numeric( numeric ) )
            {
                var _table = dataRow.CopyToDataTable();

                try
                {
                    var _query = _table?.AsEnumerable()
                        ?.Where( p => p.Field<double>( $"{numeric}" ) != 0d )
                        ?.Variance( p => p.Field<double>( $"{numeric}" ) );

                    return _query > 0.0d
                        ? double.Parse( _query.ToString() )
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return 0.0d;
                }
            }

            return default( double );
        }

        /// <summary>
        /// Calculates the statistics.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        [ SuppressMessage( "ReSharper", "BadListLineBreaks" ) ]
        public IEnumerable<double> CalculateStatistics( IEnumerable<DataRow> dataRow, Numeric numeric )
        {
            if( dataRow?.Any() == true 
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var _metrics = new[ ]
                    {
                        GetCount( dataRow, numeric ),
                        CalculateTotals( dataRow, numeric ),
                        CalculateAverage( dataRow, numeric ),
                        CalculateTotals( dataRow, numeric ) / GetCount( dataRow, numeric ),
                        CalculateDeviation( dataRow, numeric ),
                        CalculateVariance( dataRow, numeric )
                    };

                    return _metrics.Any()
                        ? _metrics
                        : default( double[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<double> );
                }
            }

            return default( IEnumerable<double> );
        }

        /// <summary>
        /// Calculates the statistics.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, IEnumerable<double>> CalculateStatistics( IEnumerable<DataRow> dataRow,
            Field field, Numeric numeric = Numeric.Amount )
        {
            if( dataRow?.Any() == true
                && Validate.Field( field )
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, IEnumerable<double>>();
                    var _codes = GetCodes( dataRow, field );

                    if( _codes?.Any() == true )
                    {
                        foreach( var filter in _codes )
                        {
                            var _select = dataRow
                                ?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                                ?.Select( p => p );

                            if( CalculateTotals( _select, numeric ) > 0 )
                            {
                                _dictionary.Add( filter, CalculateStatistics( _select, numeric )?.ToArray() );
                            }
                        }

                        return _dictionary?.Count > 0.0
                            ? _dictionary
                            : default( Dictionary<string, IEnumerable<double>> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, IEnumerable<double>> );
                }
            }

            return default( IDictionary<string, IEnumerable<double>> );
        }
    }
}
