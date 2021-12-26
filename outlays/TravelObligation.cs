// <copyright file = "TravelObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class TravelObligation : TravelData
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } =  Source.TravelObligations;

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
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
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
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
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
