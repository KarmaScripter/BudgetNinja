// <copyright file="ExpenseBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class ExpenseBase : PrcBase, IExpenseBase
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <value>
        /// The original action date.
        /// </value>
        private protected virtual ITime OriginalActionDate { get; set; }

        /// <summary>
        /// Gets or sets the hr org code.
        /// </summary>
        /// <value>
        /// The hr org code.
        /// </value>
        private protected virtual IElement HrOrgCode { get; set; }

        /// <summary>
        /// Gets or sets the work code.
        /// </summary>
        /// <value>
        /// The work code.
        /// </value>
        private protected virtual IElement WorkCode { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        private protected virtual ExpenseType Type { get; set; }

        /// <summary>
        /// Gets or sets the pay period.
        /// </summary>
        /// <value>
        /// The pay period.
        /// </value>
        private protected virtual IElement PayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the commitments.
        /// </summary>
        /// <value>
        /// The commitments.
        /// </value>
        private protected virtual IAmount Commitments { get; set; }

        /// <summary>
        /// Gets or sets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        private protected virtual IAmount OpenCommitments { get; set; }

        /// <summary>
        /// Gets or sets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        private protected virtual IAmount ULO { get; set; }

        /// <summary>
        /// Gets or sets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        private protected virtual IAmount Obligations { get; set; }

        /// <summary>
        /// Gets or sets the deobligations.
        /// </summary>
        /// <value>
        /// The deobligations.
        /// </value>
        private protected virtual IAmount Deobligations { get; set; }

        /// <summary>
        /// Gets or sets the expenditures.
        /// </summary>
        /// <value>
        /// The expenditures.
        /// </value>
        private protected virtual IAmount Expenditures { get; set; }

        /// <summary>
        /// Gets the available balance.
        /// </summary>
        /// <value>
        /// The available balance.
        /// </value>
        private protected virtual IAmount Balance { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual ITime GetOriginalActionDate()
        {
            try
            {
                return Verify.Input( OriginalActionDate.GetValue() )
                    ? OriginalActionDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
        private protected virtual void SetExpenseType( ExpenseType expense )
        {
            try
            {
                if( Enum.IsDefined( typeof( ExpenseType ), expense ) )
                {
                    switch( expense )
                    {
                        case ExpenseType.Obligation:
                        {
                            Obligations = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.Commitment:
                        {
                            Commitments = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.OpenCommitment:
                        {
                            OpenCommitments = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.ULO:
                        {
                            ULO = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.Deobligation:
                        {
                            Deobligations = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.All:
                        {
                            Obligations = new Amount( Record, Numeric.Obligations );
                            Deobligations = new Amount( Record, Numeric.Obligations );
                            Commitments = new Amount( Record, Numeric.Obligations );
                            OpenCommitments = new Amount( Record, Numeric.Obligations );
                            ULO = new Amount( Record, Numeric.Obligations );
                            break;
                        }

                        case ExpenseType.NS:
                            break;

                        case ExpenseType.Expenditure:
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
        public virtual ExpenseType GetExpenseType()
        {
            try
            {
                return Enum.IsDefined( typeof( ExpenseType ), Type.ToString() )
                    ? Type
                    : ExpenseType.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ExpenseType.NS;
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
                return Verify.Input( PayPeriod?.GetValue() )
                    ? PayPeriod
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( HrOrgCode?.GetValue() )
                    ? HrOrgCode
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( WorkCode?.GetValue() )
                    ? WorkCode
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Commitments?.GetFunding() > -1
                    ? Commitments
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return OpenCommitments?.GetFunding() > -1
                    ? OpenCommitments
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Obligations?.GetFunding() > -1
                    ? Obligations
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Deobligations?.GetFunding() > -1.0
                    ? Deobligations
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
                return ULO?.GetFunding() > -1
                    ? ULO
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Expenditures?.GetFunding() > -1
                    ? Expenditures
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the available balance.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetAvailableBalance()
        {
            try
            {
                return Balance?.GetFunding() > -1
                    ? Balance
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}