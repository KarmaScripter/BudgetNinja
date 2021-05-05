// <copyright file = "InformationTechnology.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

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
    public class InformationTechnology : IInformationTechnology, ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source Source = Source.InformationTechnology;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            ProjectName = new Element( Record, Field.ProjectName );
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
            ProjectName = new Element( Record, Field.ProjectName );
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
            ProjectName = new Element( Record, Field.ProjectName );
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
            ProjectName = new Element( Record, Field.ProjectName );
            CostAreaCode = new Element( Record, Field.CostAreaCode );
            CostAreaName = new Element( Record, Field.CostAreaName );
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Data { get; }

        /// <summary>
        /// Gets the information technology identifier.
        /// </summary>
        /// <value>
        /// The information technology identifier.
        /// </value>
        private IKey ID { get; }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private IElement ProjectCode { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private IElement Code { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private IElement Name { get; }

        /// <summary>
        /// Gets the cost area code.
        /// </summary>
        /// <value>
        /// The cost area code.
        /// </value>
        private IElement CostAreaCode { get; }

        /// <summary>
        /// Gets the name of the cost area.
        /// </summary>
        /// <value>
        /// The name of the cost area.
        /// </value>
        private IElement CostAreaName { get; }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        private IElement ProjectName { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                    return default;
                }
            }

            return default;
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
                return Verify.Element( ProjectName )
                    ? ProjectName
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
                    return default;
                }
            }

            return default;
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
                return default;
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
                return Verify.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
