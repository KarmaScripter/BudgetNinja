// <copyright file = "Awards.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    #region

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Awards : Supplemental
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public Awards( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.AwardsId );
            FundCode = new Element( Record, Field.FundCode );
            BOC = new Element( Record, Field.BocCode );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Awards( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.AwardsId );
            FundCode = new Element( Record, Field.FundCode );
            BOC = new Element( Record, Field.BocCode );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the awards identifier.
        /// </summary>
        /// <value>
        /// The awards identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.Awards;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        private protected override IElement Type { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
        /// Gets the awards data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( Data ) )
            {
                try
                {
                    var query = new Builder( Source, Data )?.GetData();

                    return query?.Any() == true
                        ? query
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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
