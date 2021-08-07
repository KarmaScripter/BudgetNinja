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
        private protected DataRow _records;

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected IKey _id;

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        private protected IElement _level;

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected IElement _bfy;

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private protected IElement _rpioCode;

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected IElement _fundCode;

        /// <summary>
        /// Gets or sets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        private protected IElement _ahCode;

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        private protected IElement _orgCode;

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected IElement _accountCode;

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        private protected IElement _bocCode;

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected IElement _rcCode;

        /// <summary>
        /// Gets or sets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        private protected IElement _activityCode;
        
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
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
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
                return Verify.Input( _level?.GetValue() )
                    ? _level
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
                return Verify.Input( _bfy?.GetValue() )
                    ? _bfy
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
                return Verify.Input( _rpioCode?.GetValue() )
                    ? _rpioCode
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
                return Verify.Element( _ahCode )
                    ? _ahCode
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
                return Verify.Element( _fundCode )
                    ? _fundCode
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
                return Verify.Element( _orgCode )
                    ? _orgCode
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
                return Verify.Element( _accountCode )
                    ? _accountCode
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
        /// Gets the boc code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetBocCode()
        {
            try
            {
                return Verify.Element( _bocCode )
                    ? _bocCode
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
                return Verify.Element( _activityCode )
                    ? _activityCode
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
