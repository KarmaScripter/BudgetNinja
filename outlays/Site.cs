// // <copyright file = "Site.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
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
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Sites;

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
            _records = new Builder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.SiteId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _dcn = new Element( _records, Field.DCN );
            EpaSiteId = new Element( _records, Field.EpaSiteId );
            SiteName = new Element( _records, Field.SiteName );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            SiteProjectName = new Element( _records, Field.SiteProjectName );
            City = new Element( _records, Field.City );
            District = new Element( _records, Field.District );
            County = new Element( _records, Field.County );
            StateCode = new Element( _records, Field.StateCode );
            StateName = new Element( _records, Field.StateName );
            StreetAddressLine1 = new Element( _records, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( _records, Field.StreetAddressLine2 );
            ZipCode = new Element( _records, Field.ZipCode );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            LastActionDate = new Time( _records, EventDate.LastActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Site( IBuilder builder )
            : base( builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.SiteId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _dcn = new Element( _records, Field.DCN );
            EpaSiteId = new Element( _records, Field.EpaSiteId );
            SiteName = new Element( _records, Field.SiteName );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            SiteProjectName = new Element( _records, Field.SiteProjectName );
            City = new Element( _records, Field.City );
            District = new Element( _records, Field.District );
            County = new Element( _records, Field.County );
            StateCode = new Element( _records, Field.StateCode );
            StateName = new Element( _records, Field.StateName );
            StreetAddressLine1 = new Element( _records, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( _records, Field.StreetAddressLine2 );
            ZipCode = new Element( _records, Field.ZipCode );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            LastActionDate = new Time( _records, EventDate.LastActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Site"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Site( DataRow dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.SiteId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _dcn = new Element( _records, Field.DCN );
            EpaSiteId = new Element( _records, Field.EpaSiteId );
            SiteName = new Element( _records, Field.SiteName );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            SiteProjectName = new Element( _records, Field.SiteProjectName );
            City = new Element( _records, Field.City );
            District = new Element( _records, Field.District );
            County = new Element( _records, Field.County );
            StateCode = new Element( _records, Field.StateCode );
            StateName = new Element( _records, Field.StateName );
            StreetAddressLine1 = new Element( _records, Field.StreetAddressLine1 );
            StreetAddressLine2 = new Element( _records, Field.StreetAddressLine2 );
            ZipCode = new Element( _records, Field.ZipCode );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            LastActionDate = new Time( _records, EventDate.LastActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the Superfund identifier.
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
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
                return Verify.Map( _data )
                    ? _data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}
