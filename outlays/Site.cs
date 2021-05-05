// // <copyright file = "Site.cs" company = "Terry D. Eppler">
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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class Site : SiteData
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Site()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Site( IQuery query )
            : base( query )
        {
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.SiteId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            DCN = new Element( Record, Field.DCN );
            EpaSiteId = new Element( Record, Field.EpaSiteId );
            SiteName = new Element( Record, Field.SiteName );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            SiteProjectName = new Element( Record, Field.SiteProjectName );
            City = new Element( Record, Field.City );
            District = new Element( Record, Field.District );
            County = new Element( Record, Field.County );
            StateCode = new Element( Record, Field.StateCode );
            StateName = new Element( Record, Field.StateName );
            StreetAddressLine1 = new Element( Record, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( Record, Field.StreetAddressLine2 );
            ZipCode = new Element( Record, Field.ZipCode );
            OriginalActionDate = new Time( Record, EventDate.OriginalActionDate );
            LastActionDate = new Time( Record, EventDate.LastActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The builder.
        /// </param>
        public Site( IBuilder db )
            : base( db )
        {
            Record = db?.GetRecord();
            ID = new Key( Record, PrimaryKey.SiteId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            DCN = new Element( Record, Field.DCN );
            EpaSiteId = new Element( Record, Field.EpaSiteId );
            SiteName = new Element( Record, Field.SiteName );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            SiteProjectName = new Element( Record, Field.SiteProjectName );
            City = new Element( Record, Field.City );
            District = new Element( Record, Field.District );
            County = new Element( Record, Field.County );
            StateCode = new Element( Record, Field.StateCode );
            StateName = new Element( Record, Field.StateName );
            StreetAddressLine1 = new Element( Record, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( Record, Field.StreetAddressLine2 );
            ZipCode = new Element( Record, Field.ZipCode );
            OriginalActionDate = new Time( Record, EventDate.OriginalActionDate );
            LastActionDate = new Time( Record, EventDate.LastActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Site( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.SiteId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            DCN = new Element( Record, Field.DCN );
            EpaSiteId = new Element( Record, Field.EpaSiteId );
            SiteName = new Element( Record, Field.SiteName );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            SiteProjectName = new Element( Record, Field.SiteProjectName );
            City = new Element( Record, Field.City );
            District = new Element( Record, Field.District );
            County = new Element( Record, Field.County );
            StateCode = new Element( Record, Field.StateCode );
            StateName = new Element( Record, Field.StateName );
            StreetAddressLine1 = new Element( Record, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( Record, Field.StreetAddressLine2 );
            ZipCode = new Element( Record, Field.ZipCode );
            OriginalActionDate = new Time( Record, EventDate.OriginalActionDate );
            LastActionDate = new Time( Record, EventDate.LastActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.Sites;

        /// <summary>
        /// Gets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the Superfund identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the epa site identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEpaSiteId()
        {
            try
            {
                return Verify.Input( EpaSiteId?.GetValue() )
                    ? EpaSiteId
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the site.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSiteName()
        {
            try
            {
                return Verify.Input( SiteName?.GetValue() )
                    ? SiteName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the site project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSiteProjectName()
        {
            try
            {
                return Verify.Input( SiteProjectName?.GetValue() )
                    ? SiteProjectName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCity()
        {
            try
            {
                return Verify.Input( City?.GetValue() )
                    ? City
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the congressional district.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCongressionalDistrict()
        {
            try
            {
                return Verify.Input( District?.GetValue() )
                    ? District
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the county.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCounty()
        {
            try
            {
                return Verify.Input( County?.GetValue() )
                    ? County
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the state code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStateCode()
        {
            try
            {
                return Verify.Input( StateCode?.GetName() )
                    ? StateCode
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the state.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStateName()
        {
            try
            {
                return Verify.Input( StateName?.GetValue() )
                    ? StateName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the street address.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStreetAddress()
        {
            try
            {
                return Verify.Input( StreetAddressLine1?.GetName() )
                    ? StreetAddressLine1
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the zip code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetZipCode()
        {
            try
            {
                return Verify.Input( District?.GetValue() )
                    ? District
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the last action date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetLastActionDate()
        {
            try
            {
                return Verify.Input( LastActionDate?.GetValue() )
                    ? LastActionDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
