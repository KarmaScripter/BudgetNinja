// // <copyright file = "Allocation.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Allocation : AllocationData, IAllocation
    {
        // ****************************************************************************************************************************
        // *********************************************   CONSTRUCTORS ***************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Allocation"/> class.
        /// </summary>
        public Allocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Allocation"/> class.
        /// </summary>
        /// <param name = "authority" >
        /// The authority.
        /// </param>
        public Allocation( IAuthority authority )
        {
            Authority = authority;
            BudgetFiscalYear = Authority?.GetBudgetFiscalYear();
            Data = Authority?.ToDictionary();
            Funds = GetFunds();
            ProgramResultCodes = GetProgramResultsCodes();
            FullTimeEquivalents = GetFullTimeEquivalents();
            Organizations = GetOrganizations();
            AllowanceHolders = GetAllowanceHolders();
            Accounts = GetAccounts();
            ObjectClasses = GetBudgetObjectClasses();
        }

        // ****************************************************************************************************************************
        // *************************************************   PROPERTIES   ***********************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected IAuthority Authority { get; }

        // ****************************************************************************************************************************
        // ************************************************  METHODS   ****************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAuthority GetAuthority()
        {
            try
            {
                return Authority ?? default( Authority );
            }
            catch( Exception ex )
            {
                Allocation.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Filters the specified numeric.
        /// </summary>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <param name = "filter" >
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> FilterData( Numeric numeric, string filter )
        {
            if( Data.Any()
                && Enum.IsDefined( typeof( Numeric ), numeric )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = GetData()
                        ?.Where( p => p.Field<string>( $"{numeric}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return query?.Any() == true
                        ? query
                        : default;
                }
                catch( Exception ex )
                {
                    Allocation.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateTotal( IEnumerable<DataRow> data )
        {
            if( Verify.Input( data )
                && data?.HasNumeric() == true )
            {
                try
                {
                    var total = data.Sum( p => p.Field<double>( $"{Numeric.Amount}" ) );

                    return total > 0.0d
                        ? total
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Allocation.Fail( ex );
                    return default;
                }
            }

            return 0.0d;
        }
    }
}
