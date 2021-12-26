// <copyright file = "NationalProgram.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "INationalProgram"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class NationalProgram : INationalProgram, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.NationalPrograms;

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
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
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private readonly IElement _title;

        /// <summary>
        /// Gets the national program identifier.
        /// </summary>
        /// <value>
        /// The national program identifier.
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
        /// Gets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private readonly IElement _rpioCode;

        /// <summary>
        /// Initializes a new instance of the <see cref = "NationalProgram"/> class.
        /// </summary>
        public NationalProgram()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "NationalProgram"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public NationalProgram( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.NationalProgramId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _rpioCode = new Element( _record, Field.RpioCode );
            _title = new Element( _record, Field.Title );
            _data = _record?.ToDictionary();
            NPM = (NPM)Enum.Parse( typeof( NPM ), _code.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "NationalProgram"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public NationalProgram( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.NationalProgramId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _rpioCode = new Element( _record, Field.RpioCode );
            _title = new Element( _record, Field.Title );
            _data = _record?.ToDictionary();
            NPM = (NPM)Enum.Parse( typeof( NPM ), _code.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "NationalProgram"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public NationalProgram( DataRow dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.NationalProgramId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _rpioCode = new Element( _record, Field.RpioCode );
            _title = new Element( _record, Field.Title );
            _data = _record?.ToDictionary();
            NPM = (NPM)Enum.Parse( typeof( NPM ), _code.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "NationalProgram"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public NationalProgram( string code )
        {
            _record = new DataBuilder( _source, GetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.NationalProgramId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _rpioCode = new Element( _record, Field.RpioCode );
            _title = new Element( _record, Field.Title );
            _data = _record?.ToDictionary();
            NPM = (NPM)Enum.Parse( typeof( NPM ), _code.GetValue() );
        }
        
        /// <summary>
        /// Gets or sets the NPM.
        /// </summary>
        /// <value>
        /// The NPM.
        /// </value>
        public NPM NPM { get; set; }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( string code )
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
        /// Gets the rpio code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRpioCode()
        {
            try
            {
                return Verify.Input( _rpioCode?.GetValue() )
                    ? _rpioCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
        /// Gets the NPM.
        /// </summary>
        /// <returns>
        /// </returns>
        public NPM GetNpm()
        {
            try
            {
                return Validate.NPM( NPM )
                    ? NPM
                    : NPM.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return NPM.NS;
            }
        }

        /// <summary>
        /// Gets the national program identifier.
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
        /// Gets the national program code.
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
        /// Gets the name of the national program.
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
        /// Gets the national program office.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNationalProgramOffice()
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
        /// Gets the national program.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                return MemberwiseClone() as INationalProgram;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( INationalProgram );
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
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
