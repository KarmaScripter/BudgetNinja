// <copyright file = "BudgetNumber.cs" company = "Terry D. Eppler">
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
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ControlInfo"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class BudgetNumber : ControlInfo
    {
        /// <summary>
        /// Gets or sets the builder.
        /// </summary>
        /// <value>
        /// The builder.
        /// </value>
        private protected DataBuilder _builder;

        /// <summary>
        /// Gets the control number identifier.
        /// </summary>
        /// <value>
        /// The control number identifier.
        /// </value>
        private protected IKey _id;

        /// <summary>
        /// Gets the date issued.
        /// </summary>
        /// <value>
        /// The date issued.
        /// </value>
        private protected ITime _dateIssued;

        /// <summary>
        /// Gets the region control number.
        /// </summary>
        /// <value>
        /// The region control number.
        /// </value>
        private protected IElement _regionControlNumber;

        /// <summary>
        /// Gets the name of the division.
        /// </summary>
        /// <value>
        /// The name of the division.
        /// </value>
        private protected IElement _divisionName;

        /// <summary>
        /// Gets the fund control number.
        /// </summary>
        /// <value>
        /// The fund control number.
        /// </value>
        private protected IElement _fundControlNumber;

        /// <summary>
        /// Gets the division control number.
        /// </summary>
        /// <value>
        /// The division control number.
        /// </value>
        private protected IElement _divisionControlNumber;
        
        /// <summary>
        /// Gets the date issued.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetDateIssued()
        {
            try
            {
                return Verify.Time( _dateIssued )
                    ? _dateIssued
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the fund count.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFundCount()
        {
            if( Verify.Element( _fundCode ) )
            {
                try
                {
                    var _enumerable = _builder?.GetData()
                        ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( _fundCode?.GetValue() ) )
                        ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( _bfy?.GetValue() ) )
                        ?.Where( p => p.Field<string>( $"{Field.RcCode}" ).Equals( _rcCode?.GetValue() ) )
                        ?.Select( p => p )
                        ?.Distinct();

                    return _enumerable?.Any() == true
                        ? new Element( _record, _enumerable.Count().ToString() )
                        : Element.Default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Element.Default;
                }
            }

            return default( IElement );
        }

        /// <summary>
        /// Gets the fund control number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFundControlNumber()
        {
            try
            {
                var _value = GetFundCount().GetValue();
                var _number = int.Parse( _value ) + 1;

                return int.Parse( _value ) > 0
                    ? new Element( _record, _number.ToString() )
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the division count.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDivisionCount()
        {
            try
            {
                var _enumerable = _builder?.GetData()
                    ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( _bfy?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.RcCode}" ).Equals( _rcCode?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( _fundCode?.GetValue() ) )
                    ?.Select( p => p )
                    ?.Distinct();

                var _count = _enumerable?.Count();

                return _count > 0
                    ? new Element( _record, _count.ToString() )
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the division control number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDivisionControlNumber()
        {
            try
            {
                var _number = GetDivisionControlNumber();
                var _count = int.Parse( _number.GetValue() ) + 1;

                return Verify.Element( _number )
                    ? new Element( _record, _count.ToString() )
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the region count.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRegionCount()
        {
            try
            {
                var _enumerable = _builder?.GetData()
                    ?.Where( p => p.Field<string>( $"{Field.RpioCode}" ).Equals( _rpio?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( _bfy?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( _fundCode?.GetValue() ) )
                    ?.Select( p => p )
                    ?.Distinct();

                var _count = _enumerable?.Count();
                var _region = _count + 1;

                return _count > 0
                    ? new Element( _record, _region.ToString() )
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the region control number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRegionControlNumber()
        {
            try
            {
                var _count = int.Parse( _regionControlNumber.GetValue() ) + 1;

                return _count > 0
                    ? new Element( _record, _count.ToString() )
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }
    }
}
