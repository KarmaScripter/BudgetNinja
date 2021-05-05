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
    public abstract class BudgetNumber : ControlInfo, ISource
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the builder.
        /// </summary>
        /// <value>
        /// The builder.
        /// </value>
        private DataBuilder Builder { get; set; }

        /// <summary>
        /// Gets the control number identifier.
        /// </summary>
        /// <value>
        /// The control number identifier.
        /// </value>
        private protected IKey ID { get; set; }

        /// <summary>
        /// Gets the date issued.
        /// </summary>
        /// <value>
        /// The date issued.
        /// </value>
        private protected ITime DateIssued { get; set; }

        /// <summary>
        /// Gets the region control number.
        /// </summary>
        /// <value>
        /// The region control number.
        /// </value>
        private protected IElement RegionControlNumber { get; set; }

        /// <summary>
        /// Gets the name of the division.
        /// </summary>
        /// <value>
        /// The name of the division.
        /// </value>
        private protected IElement DivisionName { get; set; }

        /// <summary>
        /// Gets the fund control number.
        /// </summary>
        /// <value>
        /// The fund control number.
        /// </value>
        private protected IElement FundControlNumber { get; set; }

        /// <summary>
        /// Gets the division control number.
        /// </summary>
        /// <value>
        /// The division control number.
        /// </value>
        private protected IElement DivisionControlNumber { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the date issued.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetDateIssued()
        {
            try
            {
                return Verify.Time( DateIssued )
                    ? DateIssued
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the fund count.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFundCount()
        {
            if( Verify.Element( FundCode ) )
            {
                try
                {
                    var funds = Builder?.GetData()
                        ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( FundCode?.GetValue() ) )
                        ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( BFY?.GetValue() ) )
                        ?.Where( p => p.Field<string>( $"{Field.RcCode}" ).Equals( RcCode?.GetValue() ) )
                        ?.Select( p => p )
                        ?.Distinct();

                    return funds?.Any() == true
                        ? new Element( Record, funds.Count().ToString() )
                        : Element.Default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Element.Default;
                }
            }

            return default;
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
                var fundcontrolnumber = GetFundCount().GetValue();
                var number = int.Parse( fundcontrolnumber ) + 1;

                return int.Parse( fundcontrolnumber ) > 0
                    ? new Element( Record, number.ToString() )
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
                var division = Builder?.GetData()
                    ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( BFY?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.RcCode}" ).Equals( RcCode?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( FundCode?.GetValue() ) )
                    ?.Select( p => p )
                    ?.Distinct();

                var count = division?.Count();

                return count > 0
                    ? new Element( Record, count.ToString() )
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
                var number = GetDivisionControlNumber();
                var count = int.Parse( number.GetValue() ) + 1;

                return Verify.Element( number )
                    ? new Element( Record, count.ToString() )
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
                var rpio = Builder?.GetData()
                    ?.Where( p => p.Field<string>( $"{Field.RpioCode}" ).Equals( RPIO?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.BFY}" ).Equals( BFY?.GetValue() ) )
                    ?.Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( FundCode?.GetValue() ) )
                    ?.Select( p => p )
                    ?.Distinct();

                var count = rpio?.Count();
                var region = count + 1;

                return count > 0
                    ? new Element( Record, region.ToString() )
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
                var count = int.Parse( RegionControlNumber.GetValue() ) + 1;

                return count > 0
                    ? new Element( Record, count.ToString() )
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
    }
}
