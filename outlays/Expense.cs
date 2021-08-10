// <copyright file = "Expense.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.PrcBase" />
    /// <seealso cref="IExpense" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class Expense : PrcBase, IExpense
    {
        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <value>
        /// The original action date.
        /// </value>
        private protected ITime _originalActionDate;

        /// <summary>
        /// Gets or sets the hr org code.
        /// </summary>
        /// <value>
        /// The hr org code.
        /// </value>
        private protected IElement _hrOrgCode;

        /// <summary>
        /// Gets or sets the work code.
        /// </summary>
        /// <value>
        /// The work code.
        /// </value>
        private protected IElement _workCode;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        private protected OutlayType _type;

        /// <summary>
        /// Gets or sets the pay period.
        /// </summary>
        /// <value>
        /// The pay period.
        /// </value>
        private protected IElement _payPeriod;

        /// <summary>
        /// Gets or sets the commitments.
        /// </summary>
        /// <value>
        /// The commitments.
        /// </value>
        private protected IAmount _commitments;

        /// <summary>
        /// Gets or sets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        private protected IAmount _openCommitments;

        /// <summary>
        /// Gets or sets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        private protected IAmount _ulo;

        /// <summary>
        /// Gets or sets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        private protected IAmount _obligations;

        /// <summary>
        /// Gets or sets the deobligations.
        /// </summary>
        /// <value>
        /// The deobligations.
        /// </value>
        private protected IAmount _deobligations;

        /// <summary>
        /// Gets or sets the expenditures.
        /// </summary>
        /// <value>
        /// The expenditures.
        /// </value>
        private protected IAmount _expenditures;

        /// <summary>
        /// Gets the available balance.
        /// </summary>
        /// <value>
        /// The available balance.
        /// </value>
        private protected IAmount _balance;
        
        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual ITime GetOriginalActionDate()
        {
            try
            {
                return Verify.Input( _originalActionDate.GetValue() )
                    ? _originalActionDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Sets the type of the expense.
        /// </summary>
        /// <param name = "expense" >
        /// The expense.
        /// </param>
        /// <exception cref = "ArgumentOutOfRangeException" >
        /// expense - null
        /// </exception>
        private protected virtual void SetExpenseType( OutlayType expense )
        {
            try
            {
                if( Enum.IsDefined( typeof( OutlayType ), expense ) )
                {
                    switch( expense )
                    {
                        case OutlayType.Obligation:
                        {
                            _obligations = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.Commitment:
                        {
                            _commitments = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.OpenCommitment:
                        {
                            _openCommitments = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.ULO:
                        {
                            _ulo = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.Deobligation:
                        {
                            _deobligations = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.All:
                        {
                            _obligations = new Amount( _records, Numeric.Obligations );
                            _deobligations = new Amount( _records, Numeric.Obligations );
                            _commitments = new Amount( _records, Numeric.Obligations );
                            _openCommitments = new Amount( _records, Numeric.Obligations );
                            _ulo = new Amount( _records, Numeric.Obligations );
                            break;
                        }

                        case OutlayType.NS:
                            break;

                        case OutlayType.Expenditure:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException( nameof( expense ), expense, null );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the type of the expense.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual OutlayType GetExpenseType()
        {
            try
            {
                return Enum.IsDefined( typeof( OutlayType ), _type.ToString() )
                    ? _type
                    : OutlayType.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return OutlayType.NS;
            }
        }

        /// <summary>
        /// Gets the pay period.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetPayPeriod()
        {
            try
            {
                return Verify.Input( _payPeriod?.GetValue() )
                    ? _payPeriod
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the hr org code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetHrOrgCode()
        {
            try
            {
                return Verify.Input( _hrOrgCode?.GetValue() )
                    ? _hrOrgCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetWorkCode()
        {
            try
            {
                return Verify.Input( _workCode?.GetValue() )
                    ? _workCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the commitments.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetCommitments()
        {
            try
            {
                return _commitments?.GetFunding() > -1
                    ? _commitments
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the open commitments.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetOpenCommitments()
        {
            try
            {
                return _openCommitments?.GetFunding() > -1
                    ? _openCommitments
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetObligations()
        {
            try
            {
                return _obligations?.GetFunding() > -1
                    ? _obligations
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetDeobligations()
        {
            try
            {
                return _deobligations?.GetFunding() > -1.0
                    ? _deobligations
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Amount.Default;
            }
        }

        /// <summary>
        /// Gets the unliquidated obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetUnliquidatedObligations()
        {
            try
            {
                return _ulo?.GetFunding() > -1
                    ? _ulo
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the expenditures.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetExpenditures()
        {
            try
            {
                return _expenditures?.GetFunding() > -1
                    ? _expenditures
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the available balance.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetBalance()
        {
            try
            {
                return _balance?.GetFunding() > -1
                    ? _balance
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
