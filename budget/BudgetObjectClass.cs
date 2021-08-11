// <copyright file = "BudgetObjectClass.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

// ReSharper disable All

namespace BudgetExecution
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Object classes are categories in a classification system that presents
    /// obligations by the items or services purchased by the Federal Government. The
    /// object classes present obligations according to their initial purpose, not the
    /// end product or service. Major object classes are divided into smaller classes
    /// known as Finance Object Classes. EPA uses the categories defined by the values
    /// of the BOC enumeration.
    /// </summary>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "IBudgetObjectClass"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IBudgetObjectClass"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class BudgetObjectClass : IProgramElement, IBudgetObjectClass, ISource
    {
        /// <summary>
        /// The codes
        /// </summary>
        private readonly IEnumerable<string> _codes = new[]
        {
            "10",
            "17",
            "21",
            "28",
            "36",
            "37",
            "38",
            "41"
        };
        
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.BudgetObjectClass;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow _dataRow;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> _data;

        /// <summary>
        /// Gets the budget object class identifier.
        /// </summary>
        /// <value>
        /// The budget object class identifier.
        /// </value>
        private IKey _id;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private IElement _code;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private IElement _name;

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public BOC _category;

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        public BudgetObjectClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "boc" >
        /// The code.
        /// </param>
        public BudgetObjectClass( BOC boc )
            : this()
        {
            _dataRow = new DataBuilder( _source, SetArgs( boc ) )?.GetRecord();
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _name = new Element( _dataRow, Field.BudgetObjectClassName );
            _code = new Element( _dataRow, Field.BudgetObjectClassCode );
            _category = boc;
            _data = _dataRow?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public BudgetObjectClass( string code )
            : this()
        {
            _dataRow = new DataBuilder( _source, SetArgs( code ) )?.GetRecord();
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _name = new Element( _dataRow, Field.BudgetObjectClassName );
            _code = new Element( _dataRow, Field.BudgetObjectClassCode );
            _category = (BOC)Enum.Parse( typeof( BOC ), _name.GetValue() );
            _data = _dataRow?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public BudgetObjectClass( IQuery query )
        {
            _dataRow = new DataBuilder( query )?.GetRecord();
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _name = new Element( _dataRow, Field.BudgetObjectClassName );
            _code = new Element( _dataRow, Field.BudgetObjectClassCode );
            _category = (BOC)Enum.Parse( typeof( BOC ), _name.GetValue() );
            _data = _dataRow?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The database.
        /// </param>
        public BudgetObjectClass( IBuilder builder )
        {
            _dataRow = builder?.GetRecord();
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _name = new Element( _dataRow, Field.BudgetObjectClassName );
            _code = new Element( _dataRow, Field.BudgetObjectClassCode );
            _category = (BOC)Enum.Parse( typeof( BOC ), _name.GetValue() );
            _data = _dataRow?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The data.
        /// </param>
        public BudgetObjectClass( DataRow dataRow )
        {
            _dataRow = dataRow;
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _id = new Key( _dataRow, PrimaryKey.BudgetObjectClassId );
            _name = new Element( _dataRow, Field.BudgetObjectClassName );
            _code = new Element( _dataRow, Field.BudgetObjectClassCode );
            _category = (BOC)Enum.Parse( typeof( BOC ), _name.GetValue() );
            _data = _dataRow?.ToDictionary();
        }
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Input( _code.GetValue() ) )
            {
                try
                {
                    return _code.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
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
        /// Gets the value.
        /// </summary>
        /// <param name = "prc" >
        /// The PRC.
        /// </param>
        /// <returns>
        /// </returns>
        public double GetValue( IProgramResultsCode prc )
        {
            try
            {
                var amount = prc?.GetAmount();

                return amount?.GetFunding() > -1
                    ? amount.GetFunding()
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1D;
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( string code )
        {
            if( Verify.Input( code )
                && code.Length == 2
                && _codes.Contains( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = code
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }
            else if( Verify.Input( code )
                && code.Length > 2
                && Enum.GetNames( typeof( BOC ) ).Contains( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Name}" ] = code
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
        /// <param name = "boc" >
        /// The boc.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( BOC boc )
        {
            if( Verify.Input( boc.ToString() )
                && boc.ToString().Length == 2
                && _codes.Contains( boc.ToString() ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.Code.ToString() ] = boc.ToString()
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
        /// Gets the budget object class identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
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
        /// Gets the budget object class code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( _code?.GetValue() ) 
                    && _code?.GetValue()?.Length < 3
                        ? _code
                        : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the name of the budget object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Input( _name?.GetValue() )
                    ? _name
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the budget object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetObjectClass GetBudgetObjectClass()
        {
            return MemberwiseClone() as BudgetObjectClass;
        }

        /// <summary>
        /// Gets the budget object class category.
        /// </summary>
        /// <returns>
        /// </returns>
        public BOC GetBudgetObjectClassCategory()
        {
            try
            {
                return Verify.Input( _name?.GetValue() ) 
                    && Enum.IsDefined( typeof( BOC ), _name?.GetValue() )
                        ? (BOC)Enum.Parse( typeof( BOC ), _name?.GetValue() )
                        : BOC.NS;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( BOC );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        Source ISource.GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            Fail( ex );
        }
    }
}
