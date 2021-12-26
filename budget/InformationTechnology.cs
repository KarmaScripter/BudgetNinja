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
        public Source Source { get; } = Source.InformationTechnology;
        
        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get;  }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get;  }

        /// <summary>
        /// Gets the information technology identifier.
        /// </summary>
        /// <value>
        /// The information technology identifier.
        /// </value>
        public IKey ID { get;  }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        public IElement ProjectCode { get;  }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public IElement Code { get;  }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public IElement Name { get;  }

        /// <summary>
        /// Gets the cost area code.
        /// </summary>
        /// <value>
        /// The cost area code.
        /// </value>
        public IElement CostAreaCode { get;  }

        /// <summary>
        /// Gets the name of the cost area.
        /// </summary>
        /// <value>
        /// The name of the cost area.
        /// </value>
        public IElement CostAreaName { get;  }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value> 
        private IElement ProgramProjectName { get;  }

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
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.InformationTechnologyId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProgramProjectName = new Element( Record, Field.ProjectName );
            CostAreaCode = new Element( Record, Field.CostAreaCode );
            CostAreaName = new Element( Record, Field.CostAreaName );
            Data = Record?.ToDictionary();
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
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.InformationTechnologyId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProgramProjectName = new Element( Record, Field.ProjectName );
            CostAreaCode = new Element( Record, Field.CostAreaCode );
            CostAreaName = new Element( Record, Field.CostAreaName );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "data" >
        /// </param>
        public InformationTechnology( DataRow data )
            : this()
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.InformationTechnologyId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProgramProjectName = new Element( Record, Field.ProjectName );
            CostAreaCode = new Element( Record, Field.CostAreaCode );
            CostAreaName = new Element( Record, Field.CostAreaName );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "InformationTechnology"/> class.
        /// </summary>
        /// <param name = "itcode" >
        /// The itcode.
        /// </param>
        public InformationTechnology( string itcode )
        {
            Record = new DataBuilder( Source, GetArgs( itcode ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.InformationTechnologyId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            ProjectCode = new Element( Record, Field.ProjectCode );
            ProgramProjectName = new Element( Record, Field.ProjectName );
            CostAreaCode = new Element( Record, Field.CostAreaCode );
            CostAreaName = new Element( Record, Field.CostAreaName );
            Data = Record?.ToDictionary();
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
                return Verify.Element( ProjectCode )
                    ? ProjectCode
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
                return Verify.Element( ProgramProjectName )
                    ? ProgramProjectName
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
                return Verify.Element( CostAreaCode )
                    ? CostAreaCode
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
                return Verify.Element( CostAreaName )
                    ? CostAreaName
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
            if( Verify.Element( Name )
                && Verify.Element( Code )
                && Verify.Key( ID ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ PrimaryKey.InformationTechnologyId.ToString() ] = ID.GetIndex(),
                        [ Field.Name.ToString() ] = Name.GetValue(),
                        [ Field.Code.ToString() ] = Code.GetValue()
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
                return Verify.Key( ID )
                    ? ID
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
                return Verify.Element( Code )
                    ? Code
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
                return Verify.Element( Name )
                    ? Name
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
                return Validate.Source( Source )
                    ? Source
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
            if( Code != null
                && Verify.Input( Code.GetValue() ) )
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
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
