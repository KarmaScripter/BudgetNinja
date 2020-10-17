// <copyright file = "PrcBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class PrcBase : ISource
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected virtual Source Source { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected virtual DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected virtual IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        private protected virtual IElement Level { get; set; }

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected virtual IElement BFY { get; set; }

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private protected virtual IElement RpioCode { get; set; }

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected virtual IElement FundCode { get; set; }

        /// <summary>
        /// Gets or sets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        private protected virtual IElement AhCode { get; set; }

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        private protected virtual IElement OrgCode { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected virtual IElement AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        private protected virtual IElement BocCode { get; set; }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected virtual IElement RcCode { get; set; }

        /// <summary>
        /// Gets or sets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        private protected virtual IElement ActivityCode { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        public string GetField( DataRow data, Field field )
        {
            if( data != null
                && Verify.Field( field ) )
            {
                try
                {
                    return data.GetField( field );
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
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the budget lwvel.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetLevel()
        {
            try
            {
                return Verify.Input( Level?.GetValue() )
                    ? Level
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetBFY()
        {
            try
            {
                return Verify.Input( BFY?.GetValue() )
                    ? BFY
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the rpio code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetRpioCode()
        {
            try
            {
                return Verify.Input( RpioCode?.GetValue() )
                    ? RpioCode
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the ah code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetAhCode()
        {
            try
            {
                return Verify.Element( AhCode )
                    ? AhCode
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
        public virtual IElement GetFundCode()
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
        /// Gets the org code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetOrgCode()
        {
            try
            {
                return Verify.Element( OrgCode )
                    ? OrgCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetAccountCode()
        {
            try
            {
                return Verify.Element( AccountCode )
                    ? AccountCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetRcCode()
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
        /// Gets the boc code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetBocCode()
        {
            try
            {
                return Verify.Element( BocCode )
                    ? BocCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the activity code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetActivityCode()
        {
            try
            {
                return Verify.Element( ActivityCode )
                    ? ActivityCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
