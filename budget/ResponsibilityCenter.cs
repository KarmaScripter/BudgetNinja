// <copyright file = "ResponsibilityCenter.cs" company = "Terry D. Eppler">
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

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class ResponsibilityCenter : IResponsibilityCenter, IProgramElement, ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        private static readonly Source Source = Source.ResponsibilityCenters;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        public ResponsibilityCenter()
        {
        }

        public ResponsibilityCenter( IQuery query )
            : this()
        {
            Record = new DataBuilder( query )?.GetRecord();
            ResponsibilityCenterId = new Key( Record, PrimaryKey.ResponsibilityCenterId );
            Name = new Element( Record, Field.Name );
            RcCode = new Element( Record, Field.RcCode );
            Data = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name.GetValue() );
        }

        public ResponsibilityCenter( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ResponsibilityCenterId = new Key( Record, PrimaryKey.ResponsibilityCenterId );
            Name = new Element( Record, Field.Name );
            RcCode = new Element( Record, Field.RcCode );
            Data = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name.GetValue() );
        }

        public ResponsibilityCenter( DataRow data )
            : this()
        {
            Record = data;
            ResponsibilityCenterId = new Key( Record, PrimaryKey.ResponsibilityCenterId );
            Name = new Element( Record, Field.Name );
            RcCode = new Element( Record, Field.RcCode );
            Data = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name.GetValue() );
        }

        public ResponsibilityCenter( string rccode )
            : this()
        {
            Record = new DataBuilder( Source, SetArgs( rccode ) )?.GetRecord();
            ResponsibilityCenterId = new Key( Record, PrimaryKey.ResponsibilityCenterId );
            Name = new Element( Record, Field.Name );
            RcCode = new Element( Record, Field.RcCode );
            Data = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name.GetValue() );
        }

        // ***************************************************************************************************************************
        // ************************************************  PROPERTIES **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
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
        /// Gets the responsibility center identifier.
        /// </summary>
        /// <value>
        /// The responsibility center identifier.
        /// </value>
        private IKey ResponsibilityCenterId { get; }

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private IElement RcCode { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private IElement Name { get; }

        /// <summary>
        /// Gets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        public RC RC { get; }

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
                    return default;
                }
            }

            return default;
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
                return Verify.Element( RcCode )
                    ? RcCode.GetValue()
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
                return Verify.Map( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        // ***************************************************************************************************************************
        // ******************************************* INTERFACE IMPLIMENTATIONS *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the responsibility center identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( ResponsibilityCenterId )
                    ? ResponsibilityCenterId
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
                return Verify.Element( RcCode )
                    ? RcCode
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
                return default;
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
                return Verify.Source( Source )
                    ? Source
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
