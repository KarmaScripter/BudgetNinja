// <copyright file = "_timeOff.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class TimeOff : Supplemental
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.TimeOff;

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        public TimeOff()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public TimeOff( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.TimeOffId );
            _fundCode = new Element( _records, Field.FundCode );
            _amount = new Amount( _records, Numeric.Amount );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The databuilder.
        /// </param>
        public TimeOff( IBuilder dataBuilder )
        {
            _records = dataBuilder?.GetRecord();
            _id = new Key( _records, PrimaryKey.TimeOffId );
            _fundCode = new Element( _records, Field.FundCode );
            _amount = new Amount( _records, Numeric.Amount );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public TimeOff( DataRow dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.TimeOffId );
            _fundCode = new Element( _records, Field.FundCode );
            _amount = new Amount( _records, Numeric.Amount );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( _data ) )
            {
                try
                {
                    var _rows = new DataBuilder( _source, _data )
                        ?.GetData();

                    return Verify.Input( _rows )
                        ? _rows
                        : default( IEnumerable<DataRow> );
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
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
