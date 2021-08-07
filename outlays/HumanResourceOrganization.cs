// <copyright file = "HumanResourceOrganization.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IHumanResourceOrganization"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MissingBlankLines" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class HumanResourceOrganization : IHumanResourceOrganization, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private readonly static Source _source = Source.HumanResourceOrganizations;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceOrganization"/>
        /// class.
        /// </summary>
        public HumanResourceOrganization()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public HumanResourceOrganization( IQuery query )
        {
            _records = new Builder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.HumanResourceOrganizationId );
            _name = new Element( _records, Field.Name );
            _code = new Element( _records, Field.Code );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public HumanResourceOrganization( IBuilder builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.HumanResourceOrganizationId );
            _name = new Element( _records, Field.Name );
            _code = new Element( _records, Field.Code );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public HumanResourceOrganization( DataRow data )
        {
            _records = data;
            _id = new Key( _records, PrimaryKey.HumanResourceOrganizationId );
            _name = new Element( _records, Field.Name );
            _code = new Element( _records, Field.Code );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private readonly DataRow _records;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _args;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the human resource organization identifier.
        /// </summary>
        /// <value>
        /// The human resource organization identifier.
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
        /// Gets the human resource organization identifier.
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
        /// Gets the human resource organization code.
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
        /// Gets the name of the human resource organization.
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
        /// Gets the human resource organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IHumanResourceOrganization GetHumanResourceOrganization()
        {
            try
            {
                return MemberwiseClone() as HumanResourceOrganization;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( HumanResourceOrganization );
            }
        }

        /// <summary>
        /// Gets the human resource organizations.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IHumanResourceOrganization> GetHumanResourceOrganizations()
        {
            if( Verify.Map( _args ) )
            {
                try
                {
                    var _rows = new Builder( _source, _args )
                        ?.GetData()
                        ?.Select( r => r );

                    var _select = _rows
                        ?.Select( h => new HumanResourceOrganization( h ) );

                    return _select?.Any() == true
                        ? _select
                        : default( IEnumerable<HumanResourceOrganization> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IHumanResourceOrganization> );
                }
            }

            return default( IEnumerable<IHumanResourceOrganization> );
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
                return _args.Any()
                    ? _args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "hrOrgCode" >
        /// The hrOrgCode.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( string hrOrgCode )
        {
            if( Verify.Input( hrOrgCode ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = hrOrgCode
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
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
