// <copyright file = "PrcBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class PrcBase 
    {
        /// <summary>
        /// Gets or sets the dataRow.
        /// </summary>
        /// <value>
        /// The dataRow.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the ProgramResultCodes identifier.
        /// </summary>
        /// <value>
        /// The ProgramResultCodes identifier.
        /// </value>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        public IElement BudgetLevel { get; set; }

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public IElement BFY { get; set; }

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        public IElement RpioCode { get; set; }

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        public IElement FundCode { get; set; }

        /// <summary>
        /// Gets or sets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        public IElement AhCode { get; set; }

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        public IElement OrgCode { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public IElement AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        public IElement BocCode { get; set; }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public IElement RcCode { get; set; }

        /// <summary>
        /// Gets or sets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        public IElement ActivityCode { get; set; }
        
        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        public string GetField( DataRow dataRow, Field field )
        {
            if( dataRow != null
                && Validate.Field( field ) )
            {
                try
                {
                    return dataRow.GetField( field );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( string );
                }
            }

            return default( string );
        }

        /// <summary>
        /// Gets the ProgramResultCodes identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
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
                return Verify.Input( BudgetLevel?.GetValue() )
                    ? BudgetLevel
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
