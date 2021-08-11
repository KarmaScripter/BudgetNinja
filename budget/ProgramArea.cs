// <copyright file = "ProgramArea.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class ProgramArea : IProgramArea, IProgramElement, ISource
    {
        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <value>
        /// The dataRow.
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
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the program area identifier.
        /// </summary>
        /// <value>
        /// The program area identifier.
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
        /// The source
        /// </summary>
        private const Source _source = Source.ProgramAreas;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramArea"/> class.
        /// </summary>
        public ProgramArea()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramArea"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public ProgramArea( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramAreaId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramArea"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public ProgramArea( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramAreaId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramArea"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public ProgramArea( DataRow dataRow )
            : this()
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ProgramAreaId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramArea"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public ProgramArea( string code )
        {
            _record = new DataBuilder( _source, SetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramAreaId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
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
            if( Verify.Input( code ) )
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

            return default( IDictionary<string, object> );
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
                    ? _code.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
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
        /// Gets the program area identifier.
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
        /// Gets the program area code.
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
        /// Gets the name of the program area.
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
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramArea GetProgramArea()
        {
            try
            {
                return MemberwiseClone() as ProgramArea;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ProgramArea );
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
        private static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
