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
        public new Source Source { get; } =  Source.Awards;

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.AwardsId );
            FundCode = new Element( Record, Field.FundCode );
            BOC = new Element( Record, Field.BocCode );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The databuilder.
        /// </param>
        public Awards( IBuilder dataBuilder )
        {
            Record = dataBuilder?.GetRecord();
            ID = new Key( Record, PrimaryKey.AwardsId );
            FundCode = new Element( Record, Field.FundCode );
            BOC = new Element( Record, Field.BocCode );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Awards( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.AwardsId );
            FundCode = new Element( Record, Field.FundCode );
            BOC = new Element( Record, Field.BocCode );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
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
                return Type + Amount?.GetFunding().ToString( "c" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the awards dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( Data ) )
            {
                try
                {
                    var _rows = new Builder( Source, Data )
                        ?.GetData();

                    return _rows?.Any() == true
                        ? _rows
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
                return Verify.Key( ID )
                    ? ID
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
                return Enum.IsDefined( typeof( AwardType ), Type )
                    ? Type
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
