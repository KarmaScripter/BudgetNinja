﻿// <copyright file = "Vendor.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

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
    /// <seealso cref = "IVendor"/>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "IVendor"/>
    /// <seealso cref = "IDataBuilder"/>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Vendor : VendorData, IVendor
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } = Source.Vendors;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Vendor"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Vendor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Vendor"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Vendor( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.VendorId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            DunsNumber = new Element( Record, Field.DunsNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DocPrefix = new Element( Record, Field.DocumentType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Amount = new Amount( Record, Numeric.Amount );
            Expended = new Amount( Record, Numeric.Expended );
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Vendor"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Vendor( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.VendorId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            DunsNumber = new Element( Record, Field.DunsNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DocPrefix = new Element( Record, Field.DocumentType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Amount = new Amount( Record, Numeric.Amount );
            Expended = new Amount( Record, Numeric.Expended );
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Vendor"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Vendor( DataRow datarow )
            : this()
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.VendorId );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            DunsNumber = new Element( Record, Field.DunsNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DocPrefix = new Element( Record, Field.DocumentType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Amount = new Amount( Record, Numeric.Amount );
            Expended = new Amount( Record, Numeric.Expended );
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the vendor identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the vendor code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Element( Code )
                    ? Code
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the vendor.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Element( Name )
                    ? Name
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Element( Name )
                    ? Name?.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the duns number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDunsNumber()
        {
            try
            {
                return Verify.Element( DunsNumber )
                    ? DunsNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentNumber()
        {
            try
            {
                return Verify.Element( DocumentNumber )
                    ? DocumentNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Time( StartDate )
                    ? StartDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
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
                return Verify.Time( EndDate )
                    ? EndDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
            }
        }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetClosedDate()
        {
            try
            {
                return Verify.Time( ClosedDate )
                    ? ClosedDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
            }
        }

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetExpended()
        {
            try
            {
                return Verify.Amount( Expended )
                    ? Expended
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the unliquidated obligation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetUnliquidatedObligation()
        {
            try
            {
                return Verify.Amount( ULO )
                    ? ULO
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
