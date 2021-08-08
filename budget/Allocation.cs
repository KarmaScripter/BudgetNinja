// <copyright file = "Allocation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Allocation : AllocationData, IAllocation
    {
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
            _authority = authority;
            _budgetFiscalYear = _authority?.GetBudgetFiscalYear();
            _data = _authority?.ToDictionary();
            _funds = GetFunds();
            _programResultCodes = GetProgramResultsCodes();
            _fullTimeEquivalents = GetFullTimeEquivalents();
            _organizations = GetOrganizations();
            _allowanceHolders = GetAllowanceHolders();
            _accounts = GetAccounts();
            _objectClasses = GetBudgetObjectClasses();
        }

        /// <summary>
        /// Gets or sets the dataRow.
        /// </summary>
        /// <value>
        /// The dataRow.
        /// </value>
        private readonly IAuthority _authority;
        
        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAuthority GetAuthority()
        {
            try
            {
                return _authority ?? default( Authority );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAuthority );
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
            if( _data?.Any() == true
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
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculateTotal( IEnumerable<DataRow> dataRow )
        {
            if( Verify.Input( dataRow )
                && dataRow?.HasNumeric() == true )
            {
                try
                {
                    var _sum = dataRow.Sum( p => p.Field<double>( $"{Numeric.Amount}" ) );

                    return _sum > 0.0d
                        ? _sum
                        : 0.0d;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( double );
                }
            }

            return 0.0d;
        }
    }
}
