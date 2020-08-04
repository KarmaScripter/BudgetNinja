// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    public class TravelData : Obligation
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelData"/> class.
        /// </summary>
        /// <inheritdoc />
        public TravelData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelData"/> class.
        /// </summary>
        /// <param name="query"></param>
        public TravelData( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelData"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public TravelData( IBuilder builder )
            : base( builder )
        {
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        private protected IElement Destination { get; set; }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        private protected IElement FirstName { get; set; }

        /// <summary>
        /// Gets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        private protected IElement MiddleName { get; set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        private protected IElement LastName { get; set; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        private protected IElement Email { get; set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected ITime StartDate { get; set; }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected ITime EndDate { get; set; }
    }
}