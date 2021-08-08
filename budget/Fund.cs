// <copyright file = "Fund.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    public class Fund : IFund, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.Funds;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private readonly DataRow _record;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _data;

        /// <summary>
        /// Gets the treasury symbol.
        /// </summary>
        /// <value>
        /// The treasury symbol.
        /// </value>
        private readonly IElement _treasurySymbol;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the fund identifier.
        /// </summary>
        /// <value>
        /// The fund identifier.
        /// </value>
        private readonly IKey _id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private readonly IElement _name;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private readonly IElement _title;

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
            _record = new DataBuilder( _source, GetArgs( fundcode ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.FundId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _treasurySymbol = new Element( _record, Field.TreasurySymbol );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Fund( string code )
        {
            _record = new DataBuilder( _source, GetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.FundId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _treasurySymbol = new Element( _record, Field.TreasurySymbol );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Fund( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.FundId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _treasurySymbol = new Element( _record, Field.TreasurySymbol );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Fund"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Fund( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.FundId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _treasurySymbol = new Element( _record, Field.TreasurySymbol );
            _data = _record?.ToDictionary();
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
            _record = data;
            _id = new Key( _record, PrimaryKey.FundId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _treasurySymbol = new Element( _record, Field.TreasurySymbol );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( _data )
                    ? _data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
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
                return Verify.Element( _code )
                    ? _code?.GetValue()
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
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
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
                return Validate.FundCode( fundcode )
                    ? new Dictionary<string, object>
                    {
                        [ "FundCode" ] = fundcode.ToString()
                    }
                    : default( Dictionary<string, object> );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
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
                return Verify.Key( _id )
                    ? _id
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
                return Verify.Element( _code )
                    ? _code
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
                return Verify.Element( _name )
                    ? _name
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
                return Verify.Element( _title )
                    ? _title
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
                return Verify.Element( _treasurySymbol )
                    ? _treasurySymbol
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
                return default( IFund );
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
                return Validate.Source( _source )
                    ? _source
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
