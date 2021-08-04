// <copyright file = "Awards.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    #region

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class Awards : Supplemental
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.Awards;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        public Awards()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Awards( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.AwardsId );
            _fundCode = new Element( _record, Field.FundCode );
            _boc = new Element( _record, Field.BocCode );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public Awards( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.AwardsId );
            _fundCode = new Element( _record, Field.FundCode );
            _boc = new Element( _record, Field.BocCode );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Awards( DataRow data )
        {
            _record = data;
            _id = new Key( _record, PrimaryKey.AwardsId );
            _fundCode = new Element( _record, Field.FundCode );
            _boc = new Element( _record, Field.BocCode );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return _type + _amount?.GetFunding().ToString( "c" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the awards data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( _data ) )
            {
                try
                {
                    var query = new Builder( _source, _data )?.GetData();

                    return query?.Any() == true
                        ? query
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
                return Enum.IsDefined( typeof( AwardType ), _type )
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
