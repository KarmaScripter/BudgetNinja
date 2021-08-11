// <copyright file = "FullTimeEquivalent.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Full-time equivalent (FTE) or whole time equivalent (WTE) is a
    /// unit that indicates the workload of an employed person (or student) in a way
    /// that makes workloads or class loads comparable across various contexts.
    /// FullTimeEquivalent is often used to measure a worker's or student's involvement
    /// in a project, or to track cost reductions in an organization. An
    /// FullTimeEquivalent of 1.0 is equivalent to a full-time worker or student, while
    /// an FullTimeEquivalent of 0.5 signals half of a full work or school load.
    /// </summary>
    /// <seealso cref = "ProgramResultsCode"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class FullTimeEquivalent : ProgramResultsCode, IFullTimeEquivalent
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.FTE;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.FullTimeEquivalent"/> class.
        /// </summary>
        public FullTimeEquivalent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public FullTimeEquivalent( IQuery query )
            : base( query )
        {
            _id = new Key( _records, PrimaryKey.PrcId );
            _amount = new Amount( _records, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public FullTimeEquivalent( IBuilder builder )
            : base( builder )
        {
            _id = new Key( _records, PrimaryKey.PrcId );
            _amount = new Amount( _records, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public FullTimeEquivalent( DataRow dataRow )
            : base( dataRow )
        {
            _id = new Key( _records, PrimaryKey.PrcId );
            _amount = new Amount( _records, Numeric.Amount );
        }
        
        /// <summary>
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
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
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return _amount.GetFunding() > -1.0
                    ? _amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
