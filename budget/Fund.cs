// <copyright file = "Fund.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    public class Fund : IFund, ISource
    {
        // **************************************************************************************************************************
        // ****************************************************     FIELDS    *******************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source Source = Source.Funds;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        public Fund()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "fundcode" >
        /// The fundcode.
        /// </param>
        public Fund( FundCode fundcode )
        {
            Record = new DataBuilder( Source, GetArgs( fundcode ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.FundId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Title = new Element( Record, Field.Title );
            TreasurySymbol = new Element( Record, Field.TreasurySymbol );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Fund( string code )
        {
            Record = new DataBuilder( Source, GetArgs( code ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.FundId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Title = new Element( Record, Field.Title );
            TreasurySymbol = new Element( Record, Field.TreasurySymbol );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Fund( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.FundId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Title = new Element( Record, Field.Title );
            TreasurySymbol = new Element( Record, Field.TreasurySymbol );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Fund( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.FundId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Title = new Element( Record, Field.Title );
            TreasurySymbol = new Element( Record, Field.TreasurySymbol );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Fund( DataRow data )
            : this()
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.FundId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Title = new Element( Record, Field.Title );
            TreasurySymbol = new Element( Record, Field.TreasurySymbol );
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Data { get; }

        /// <summary>
        /// Gets the treasury symbol.
        /// </summary>
        /// <value>
        /// The treasury symbol.
        /// </value>
        private IElement TreasurySymbol { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private IElement Code { get; }

        /// <summary>
        /// Gets the fund identifier.
        /// </summary>
        /// <value>
        /// The fund identifier.
        /// </value>
        private IKey ID { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private IElement Name { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private IElement Title { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
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
                return Verify.Element( Code )
                    ? Code?.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "fundcode" >
        /// The fundcode.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( string fundcode )
        {
            if( Verify.Input( fundcode )
                && fundcode.Length < 5 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.Code.ToString() ] = fundcode
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );

                    return new Dictionary<string, object>
                    {
                        [ Field.Name.ToString() ] = fundcode
                    };
                }
            }

            if( Verify.Input( fundcode )
                && fundcode.Length > 5 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.Name.ToString() ] = fundcode
                    };
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
        /// Sets the arguments.
        /// </summary>
        /// <param name = "fundcode" >
        /// The fundcode.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( FundCode fundcode )
        {
            try
            {
                return Verify.FundCode( fundcode )
                    ? new Dictionary<string, object>
                    {
                        [ "FundCode" ] = fundcode.ToString()
                    }
                    : default;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the fund identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Element( Code )
                    ? Code
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the fund.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Element( Name )
                    ? Name
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the fund title.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetTitle()
        {
            try
            {
                return Verify.Element( Title )
                    ? Title
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the treasury symbol.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetTreasurySymbol()
        {
            try
            {
                return Verify.Element( TreasurySymbol )
                    ? TreasurySymbol
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFund GetFund()
        {
            try
            {
                return MemberwiseClone() as Fund;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
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
                return Verify.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
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
