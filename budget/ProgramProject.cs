// <copyright file = "ProgramProject.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class ProgramProject : ProgramBase, IProgramProject, IProgramElement, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.ProgramProjects;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramProject"/> class.
        /// </summary>
        public ProgramProject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramProject"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public ProgramProject( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramProjectId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _definition = new Element( _record, Field.Definition );
            _laws = new Element( _record, Field.Laws );
            _narrative = new Element( _record, Field.Narrative );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _programAreaName = new Element( _record, Field.ProgramAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramProject"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The dataBuilder.
        /// </param>
        public ProgramProject( IBuilder dataBuilder )
        {
            _record = dataBuilder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramProjectId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _definition = new Element( _record, Field.Definition );
            _laws = new Element( _record, Field.Laws );
            _narrative = new Element( _record, Field.Narrative );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _programAreaName = new Element( _record, Field.ProgramAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramProject"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public ProgramProject( DataRow dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ProgramProjectId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _definition = new Element( _record, Field.Definition );
            _laws = new Element( _record, Field.Laws );
            _narrative = new Element( _record, Field.Narrative );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _programAreaName = new Element( _record, Field.ProgramAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramProject"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public ProgramProject( string code )
        {
            _record = new DataBuilder( _source, GetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProgramProjectId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _title = new Element( _record, Field.Title );
            _definition = new Element( _record, Field.Definition );
            _laws = new Element( _record, Field.Laws );
            _narrative = new Element( _record, Field.Narrative );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _programAreaName = new Element( _record, Field.ProgramAreaName );
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
        /// Gets the definition.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDefinition()
        {
            try
            {
                return Verify.Element( _definition )
                    ? _definition
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the laws.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetLaws()
        {
            try
            {
                return Verify.Element( _laws )
                    ? _laws
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the title.
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
        /// Gets the narrative.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNarrative()
        {
            try
            {
                return Verify.Element( _narrative )
                    ? _narrative
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProgramAreaCode()
        {
            try
            {
                return Verify.Element( _programAreaName )
                    ? _programAreaCode
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
        public IElement GetProgramAreaName()
        {
            try
            {
                return Verify.Element( _programAreaName )
                    ? _programAreaName
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
        /// Gets the program project identifier.
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
        /// Gets the program project code.
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
        /// Gets the name of the program project.
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
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramProject GetProgramProject()
        {
            return MemberwiseClone() as ProgramProject;
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
    }
}
