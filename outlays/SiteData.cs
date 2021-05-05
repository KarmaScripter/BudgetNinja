// <copyright file = "SiteData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Obligation" />
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class SiteData : Obligation
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteData"/> class.
        /// </summary>
        /// <inheritdoc />
        public SiteData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteData"/> class.
        /// </summary>
        /// <param name="query"></param>
        public SiteData( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteData"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        public SiteData( IBuilder db )
            : base( db )
        {
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the epa site identifier.
        /// </summary>
        /// <value>
        /// The epa site identifier.
        /// </value>
        private protected IElement EpaSiteId { get; set; }

        /// <summary>
        /// Gets the name of the site.
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        private protected IElement SiteName { get; set; }

        /// <summary>
        /// Gets the name of the site project.
        /// </summary>
        /// <value>
        /// The name of the site project.
        /// </value>
        private protected IElement SiteProjectName { get; set; }

        /// <summary>
        /// Gets the state code.
        /// </summary>
        /// <value>
        /// The state code.
        /// </value>
        private protected IElement StateCode { get; set; }

        /// <summary>
        /// Gets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        private protected IElement StateName { get; set; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        private protected IElement City { get; set; }

        /// <summary>
        /// Gets the district.
        /// </summary>
        /// <value>
        /// The district.
        /// </value>
        private protected IElement District { get; set; }

        /// <summary>
        /// Gets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        private protected IElement County { get; set; }

        /// <summary>
        /// Gets the street address line1.
        /// </summary>
        /// <value>
        /// The street address line1.
        /// </value>
        private protected IElement StreetAddressLine1 { get; set; }

        /// <summary>
        /// Gets the street address line2.
        /// </summary>
        /// <value>
        /// The street address line2.
        /// </value>
        private protected IElement StreetAddressLine2 { get; set; }

        /// <summary>
        /// Gets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        private protected IElement ZipCode { get; set; }

        /// <summary>
        /// Gets the last action date.
        /// </summary>
        /// <value>
        /// The last action date.
        /// </value>
        private protected ITime LastActionDate { get; set; }
    }
}
