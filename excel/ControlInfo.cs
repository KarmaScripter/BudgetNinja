// <copyright file = "ControlInfo.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class ControlInfo
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        private protected static Source Source { get; } = Source.ControlNumbers;

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private protected IElement RPIO { get; set; }

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected IElement RcCode { get; set; }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected IElement BFY { get; set; }

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected IElement FundCode { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the responsibility center code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetResponsibilityCenterCode()
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
        /// Gets the rpio code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRpioCode()
        {
            try
            {
                return Verify.Element( RPIO )
                    ? RPIO
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFundCode()
        {
            try
            {
                return Verify.Element( FundCode )
                    ? FundCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetBFY()
        {
            try
            {
                return Verify.Element( BFY )
                    ? BFY
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the dictionary that can be used arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Args )
                    ? Args
                    : default;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default;
            }
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
