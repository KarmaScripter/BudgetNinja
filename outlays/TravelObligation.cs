// <copyright file = "TravelObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class TravelObligation : TravelData
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "TravelObligation"/> class.
        /// </summary>
        /// <inheritdoc/>
        public TravelObligation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TravelObligation"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public TravelObligation( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.TravelObligationId );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DCN = new Element( Record, Field.DCN );
            FirstName = new Element( Record, Field.FirstName );
            MiddleName = new Element( Record, Field.MiddleName );
            LastName = new Element( Record, Field.LastName );
            Email = new Element( Record, Field.Email );
            Destination = new Element( Record, Field.Destination );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Type = OutlayType.Obligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TravelObligation"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public TravelObligation( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.TravelObligationId );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DCN = new Element( Record, Field.DCN );
            FirstName = new Element( Record, Field.FirstName );
            MiddleName = new Element( Record, Field.MiddleName );
            LastName = new Element( Record, Field.LastName );
            Email = new Element( Record, Field.Email );
            Destination = new Element( Record, Field.Destination );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Type = OutlayType.Obligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TravelObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public TravelObligation( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.TravelObligationId );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DCN = new Element( Record, Field.DCN );
            FirstName = new Element( Record, Field.FirstName );
            MiddleName = new Element( Record, Field.MiddleName );
            LastName = new Element( Record, Field.LastName );
            Email = new Element( Record, Field.Email );
            Destination = new Element( Record, Field.Destination );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Type = OutlayType.Obligation;
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.TravelObligations;

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the travel obligation identifier.
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
        /// Gets the bbfy.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetBBFY()
        {
            try
            {
                return Verify.Input( BFY?.GetValue() )
                    ? BFY
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDestination()
        {
            try
            {
                return Verify.Input( Destination?.GetName() )
                    ? Destination
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFirstName()
        {
            try
            {
                return Verify.Input( FirstName?.GetValue() )
                    ? FirstName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the middle.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetMiddleName()
        {
            try
            {
                return Verify.Input( MiddleName.GetValue() )
                    ? MiddleName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetLastName()
        {
            try
            {
                return Verify.Input( LastName?.GetValue() )
                    ? LastName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmailAddress()
        {
            try
            {
                return Verify.Input( Email?.GetValue() )
                    ? Email
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetStartDate()
        {
            try
            {
                return Verify.Input( StartDate?.GetValue() )
                    ? StartDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetEndDate()
        {
            try
            {
                return Verify.Input( EndDate?.GetValue() )
                    ? EndDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the travel obligation amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Amount?.GetFunding() > -1.0
                    ? Amount
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
