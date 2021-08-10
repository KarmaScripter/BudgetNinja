// <copyright file = "ResponsibilityCenter.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class ResponsibilityCenter : IResponsibilityCenter, IProgramElement, ISource
    {
        /// <summary>The source</summary>
        private const Source _source = Source.ResponsibilityCenters;
        
        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        private protected readonly DataRow _record;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected readonly IDictionary<string, object> _data;

        /// <summary>
        /// Gets the responsibility center identifier.
        /// </summary>
        /// <value>
        /// The responsibility center identifier.
        /// </value>
        private protected readonly IKey _responsibilityCenterId;

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected readonly IElement _rcCode;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected readonly IElement _name;

        /// <summary>
        /// Gets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        private protected RC _rc;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ResponsibilityCenter"/> class.
        /// </summary>
        public ResponsibilityCenter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ResponsibilityCenter"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ResponsibilityCenter( IQuery query )
            : this()
        {
            _record = new DataBuilder( query )?.GetRecord();
            _responsibilityCenterId = new Key( _record, PrimaryKey.ResponsibilityCenterId );
            _name = new Element( _record, Field.Name );
            _rcCode = new Element( _record, Field.RcCode );
            _data = _record?.ToDictionary();
            _rc = (RC)Enum.Parse( typeof( RC ), _name.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ResponsibilityCenter"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ResponsibilityCenter( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _responsibilityCenterId = new Key( _record, PrimaryKey.ResponsibilityCenterId );
            _name = new Element( _record, Field.Name );
            _rcCode = new Element( _record, Field.RcCode );
            _data = _record?.ToDictionary();
            _rc = (RC)Enum.Parse( typeof( RC ), _name.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ResponsibilityCenter"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ResponsibilityCenter( DataRow data )
            : this()
        {
            _record = data;
            _responsibilityCenterId = new Key( _record, PrimaryKey.ResponsibilityCenterId );
            _name = new Element( _record, Field.Name );
            _rcCode = new Element( _record, Field.RcCode );
            _data = _record?.ToDictionary();
            _rc = (RC)Enum.Parse( typeof( RC ), _name.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsibilityCenter"/> class.
        /// </summary>
        /// <param name="rccode">The rccode.</param>
        public ResponsibilityCenter( string rccode )
            : this()
        {
            _record = new DataBuilder( _source, SetArgs( rccode ) )?.GetRecord();
            _responsibilityCenterId = new Key( _record, PrimaryKey.ResponsibilityCenterId );
            _name = new Element( _record, Field.Name );
            _rcCode = new Element( _record, Field.RcCode );
            _data = _record?.ToDictionary();
            _rc = (RC)Enum.Parse( typeof( RC ), _name.GetValue() );
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
                return Verify.Element( _rcCode )
                    ? _rcCode.GetValue()
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
        /// Gets the responsibility center identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( _responsibilityCenterId )
                    ? _responsibilityCenterId
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the responsibility center code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Element( _rcCode )
                    ? _rcCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the responsibility center.
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
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResponsibilityCenter GetResponsibilityCenter()
        {
            try
            {
                return MemberwiseClone() as IResponsibilityCenter;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IResponsibilityCenter );
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
