﻿// <copyright file = "Supplemental.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Budget authority provided in an appropriations act in addition to regular or
    /// continuing appropriations already provided. Supplemental appropriations
    /// generally are made to cover emergencies, such as disaster relief, or other
    /// needs deemed too urgent to be postponed until the enactment of next year's
    /// regular appropriations act.
    /// </summary>
    /// <seealso cref = "ProgramResultsCode"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISupplemental"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public abstract class Supplemental : ProgramResultsCode, ISupplemental
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } =  Source.Supplemental;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public IElement Type { get; set; }

        /// <summary>
        /// Gets or sets the boc.
        /// </summary>
        /// <value>
        /// The boc.
        /// </value>
        public IElement BOC { get; set; }
        
        /// <summary>
        /// Gets the type of the supplemental.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSupplementalType()
        {
            try
            {
                return Verify.Input( Type?.GetValue() )
                    ? Type
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the Data builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Verify.Map( Data )
                    ? new Builder( Source, Data )
                    : default( Builder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBuilder );
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
                return Type + Amount?.GetFunding().ToString( "c" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetName()
        {
            try
            {
                return Enum.IsDefined( typeof( AwardType ), Type )
                    ? new Element( Record, Field.Type )
                    : default( Element );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
    }
}
