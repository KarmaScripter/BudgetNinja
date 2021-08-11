// <copyright file = "InformationTechnology.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IInformationTechnology"/>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class InformationTechnology : IInformationTechnology, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.InformationTechnology;
        
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
        private IDictionary<string, object> _data;

        /// <summary>
        /// Gets the information technology identifier.
        /// </summary>
        /// <value>
        /// The information technology identifier.
        /// </value>
        private readonly IKey _id;

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private readonly IElement _projectCode;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private readonly IElement _name;

        /// <summary>
        /// Gets the cost area code.
        /// </summary>
        /// <value>
        /// The cost area code.
        /// </value>
        private readonly IElement _costAreaCode;

        /// <summary>
        /// Gets the name of the cost area.
        /// </summary>
        /// <value>
        /// The name of the cost area.
        /// </value>
        private readonly IElement _costAreaName;

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        private protected readonly IElement _projectName;

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        public InformationTechnology()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public InformationTechnology( IQuery query )
        {
            _record = new Builder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.InformationTechnologyId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectName = new Element( _record, Field.ProjectName );
            _costAreaCode = new Element( _record, Field.CostAreaCode );
            _costAreaName = new Element( _record, Field.CostAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public InformationTechnology( IBuilder builder )
            : this()
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.InformationTechnologyId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectName = new Element( _record, Field.ProjectName );
            _costAreaCode = new Element( _record, Field.CostAreaCode );
            _costAreaName = new Element( _record, Field.CostAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "data" >
        /// </param>
        public InformationTechnology( DataRow data )
            : this()
        {
            _record = data;
            _id = new Key( _record, PrimaryKey.InformationTechnologyId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectName = new Element( _record, Field.ProjectName );
            _costAreaCode = new Element( _record, Field.CostAreaCode );
            _costAreaName = new Element( _record, Field.CostAreaName );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "itcode" >
        /// The itcode.
        /// </param>
        public InformationTechnology( string itcode )
        {
            _record = new DataBuilder( _source, GetArgs( itcode ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.InformationTechnologyId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _projectCode = new Element( _record, Field.ProjectCode );
            _projectName = new Element( _record, Field.ProjectName );
            _costAreaCode = new Element( _record, Field.CostAreaCode );
            _costAreaName = new Element( _record, Field.CostAreaName );
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
        /// Gets the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectCode()
        {
            try
            {
                return Verify.Element( _projectCode )
                    ? _projectCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectName()
        {
            try
            {
                return Verify.Element( _projectName )
                    ? _projectName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the cost area code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCostAreaCode()
        {
            try
            {
                return Verify.Element( _costAreaCode )
                    ? _costAreaCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the cost area.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCostAreaName()
        {
            try
            {
                return Verify.Element( _costAreaName )
                    ? _costAreaName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            if( Verify.Element( _name )
                && Verify.Element( _code )
                && Verify.Key( _id ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ PrimaryKey.InformationTechnologyId.ToString() ] = _id.GetIndex(),
                        [ Field.Name.ToString() ] = _name.GetValue(),
                        [ Field.Code.ToString() ] = _code.GetValue()
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
        /// Gets the information technology identifier.
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
        /// Gets the information technology code.
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
        /// Gets the name of the information technology.
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
        /// Gets it code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IInformationTechnology GetItCode()
        {
            try
            {
                return MemberwiseClone() as InformationTechnology;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IInformationTechnology );
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
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
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
            if( _code != null
                && Verify.Input( _code.GetValue() ) )
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
