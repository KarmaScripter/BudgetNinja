// <copyright file = "TravelData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class TravelData : Obligation
    {
        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        private protected IElement _destination;

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        private protected IElement _firstName;

        /// <summary>
        /// Gets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        private protected IElement _middleName;

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        private protected IElement _lastName;

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        private protected IElement _email;

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected ITime _startDate;

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected ITime _endDate;

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
    }
}
