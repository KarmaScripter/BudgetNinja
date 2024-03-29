﻿// <copyright file = "BudgetObjectClasses.cs" company = "Terry D. Eppler">
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

    /// <summary>
    /// Object classes are categories in a classification system that presents
    /// obligations by the items or services purchased by the Federal Government. The
    /// object classes present obligations according to their initial purpose, not the
    /// end product or service. Major object classes are divided into smaller classes
    /// known as Finance Object Classes. EPA uses the categories defined by the values
    /// of the ObjectClasses enumeration.
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
        private readonly IEnumerable<string> Codes = new[]
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
        public Source Source { get; } =  Source.BudgetObjectClass;

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get; set; } 

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; } 

        /// <summary>
        /// Gets the budget object class identifier.
        /// </summary>
        /// <value>
        /// The budget object class identifier.
        /// </value>
        public IKey ID { get; set; } 

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public IElement Code { get; set; } 

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public IElement Name { get; set; } 

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public BOC Category { get; set; } 

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
            Record = new DataBuilder( Source, SetArgs( boc ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.BudgetObjectClassId );
            Name = new Element( Record, Field.BudgetObjectClassName );
            Code = new Element( Record, Field.BudgetObjectClassCode );
            Category = boc;
            Data = Record?.ToDictionary();
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
            Record = new DataBuilder( Source, SetArgs( code ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.BudgetObjectClassId );
            Name = new Element( Record, Field.BudgetObjectClassName );
            Code = new Element( Record, Field.BudgetObjectClassCode );
            Category = (BOC)Enum.Parse( typeof( BOC ), Name.GetValue() );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public BudgetObjectClass( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.BudgetObjectClassId );
            Name = new Element( Record, Field.BudgetObjectClassName );
            Code = new Element( Record, Field.BudgetObjectClassCode );
            Category = (BOC)Enum.Parse( typeof( BOC ), Name.GetValue() );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The database.
        /// </param>
        public BudgetObjectClass( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.BudgetObjectClassId );
            Name = new Element( Record, Field.BudgetObjectClassName );
            Code = new Element( Record, Field.BudgetObjectClassCode );
            Category = (BOC)Enum.Parse( typeof( BOC ), Name.GetValue() );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The Data.
        /// </param>
        public BudgetObjectClass( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.BudgetObjectClassId );
            Name = new Element( Record, Field.BudgetObjectClassName );
            Code = new Element( Record, Field.BudgetObjectClassCode );
            Category = (BOC)Enum.Parse( typeof( BOC ), Name.GetValue() );
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
            if( Verify.Input( Code.GetValue() ) )
            {
                try
                {
                    return Code.GetValue();
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
                return Verify.Map( Data )
                    ? Data
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
        /// The ProgramResultCodes.
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
                && Codes.Contains( code ) )
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
                && Codes.Contains( boc.ToString() ) )
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
        /// Gets the budget object class code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( Code?.GetValue() ) 
                    && Code?.GetValue()?.Length < 3
                        ? Code
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
                return Verify.Input( Name?.GetValue() )
                    ? Name
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
                return Verify.Input( Name?.GetValue() ) 
                    && Enum.IsDefined( typeof( BOC ), Name?.GetValue() )
                        ? (BOC)Enum.Parse( typeof( BOC ), Name?.GetValue() )
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
                return Validate.Source( Source )
                    ? Source
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
