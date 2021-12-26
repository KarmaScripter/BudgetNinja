// <copyright file = "Objective.cs" company = "Terry D. Eppler">
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
    public class Objective : IObjective, IProgramElement, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.Objectives;

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
        /// Gets the objective identifier.
        /// </summary>
        /// <value>
        /// The objective identifier.
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
        /// Initializes a new instance of the <see cref = "Objective"/> class.
        /// </summary>
        public Objective()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Objective"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Objective( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ObjectiveId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Objective"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Objective( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ObjectiveId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Objective"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Objective( DataRow dataRow )
            : this()
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ObjectiveId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Objective"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Objective( string code )
        {
            _record = new DataBuilder( _source, SetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ObjectiveId );
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
            if( Verify.Element( _code ) )
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
        /// Gets the objective identifier.
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
        /// Gets the objective code.
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
        /// Gets the name of the objective.
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
        /// Gets the objective.
        /// </summary>
        /// <returns>
        /// </returns>
        public IObjective GetObjective()
        {
            try
            {
                return MemberwiseClone() as Objective;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IObjective );
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
