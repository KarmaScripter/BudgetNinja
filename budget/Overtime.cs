// <copyright file = "Overtime.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    #endregion

    /// <summary>
    /// The federal overtime provisions are contained in the Fair Labor Standards Act
    /// (FLSA). Unless exempt, employees covered by the Act must receive overtime pay
    /// for hours worked over 40 in a workweek at a rate not less than time and
    /// one-half their regular rates of pay. There is no limit in the Act on the number
    /// of hours employees aged 16 and older may work in any workweek. The Act does not
    /// require overtime pay for work on Saturdays, Sundays, holidays, or regular days
    /// of rest, unless overtime is worked on such days. The Act applies on a workweek
    /// basis. An employee's workweek is a fixed and regularly recurring period of 168
    /// hours — seven consecutive 24-hour periods. It need not coincide with the
    /// calendar week, but may begin on any day and at any hour of the day. Different
    /// workweeks may be established for different employees or groups of employees.
    /// Averaging of hours over two or more weeks is not permitted. Normally, overtime
    /// pay earned in a particular workweek must be paid on the regular pay day for the
    /// pay period in which the wages were earned.
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class Overtime : Supplemental
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.Overtime;

        /// <summary>
        /// 
        /// </summary>
        public Overtime()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Overtime"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Overtime( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.OvertimeId );
            _fundCode = new Element( _records, Field.FundCode );
            _boc = new Element( _records, Field.BocCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Overtime"/> class.
        /// </summary>
        /// <param name = "databuilder" >
        /// The databuilder.
        /// </param>
        public Overtime( IBuilder databuilder )
        {
            _records = databuilder.GetRecord();
            _id = new Key( _records, PrimaryKey.OvertimeId );
            _fundCode = new Element( _records, Field.FundCode );
            _boc = new Element( _records, Field.BocCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Overtime"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Overtime( DataRow data )
        {
            _records = data;
            _id = new Key( _records, PrimaryKey.OvertimeId );
            _fundCode = new Element( _records, Field.FundCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( _data ) )
            {
                try
                {
                    var _select = new Builder( _source, _data )
                        ?.GetDataTable()
                        ?.AsEnumerable()
                        ?.Where( a => a.Field<string>( $"{Field.Type}" ).Equals( $"{Source.Overtime}" ) )
                        ?.Where( a => a.Field<double>( $"{Numeric.Amount}" ) != 0.0 )
                        ?.Select( a => a );

                    return _select?.Any() == true
                        ? _select
                        : default( EnumerableRowCollection<DataRow> );
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
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetName()
        {
            try
            {
                return Verify.Input( _type?.GetValue() )
                    ? _type
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
    }
}
