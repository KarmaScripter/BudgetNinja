// <copyright file="Reprogramming.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// Shifting funds within an appropriation or fund account to use them for purposes
    /// other than those contemplated at the time of appropriation; it is the shifting
    /// of funds from one object class to another within an appropriation or from one
    /// program activity to another. While a transfer of funds involves shifting funds
    /// from one account to another, reprogramming involves shifting funds within an
    /// account. (For a distinction, see Transfer). Generally agencies may shift funds
    /// within an appropriation or fund account as part of their duty to manage their
    /// funds. Unlike transfers, agencies may reprogram without additional statutory
    /// authority. Nevertheless, reprogramming often involves some form of notification
    /// to the congressional appropriations committees, authorizing committees, or
    /// both. Sometimes committee oversight of reprogramming actions is prescribed by
    /// statute and requires formal notification of one or more committees before a
    /// reprogramming action may be implemented.
    /// </summary>
    /// <seealso cref = "ProgramResultsCode"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "IReprogramming"/>
    /// <seealso cref = "ISource"/>
    public class Reprogramming : ProgramResultsCode, ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.Transfers;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reprogramming"/> class.
        /// </summary>
        public Reprogramming()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reprogramming"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Reprogramming( IQuery query )
            : base( query )
        {
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.TransferId );
            DocType = new Element( Record, Field.DocType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            Purpose = new Element( Record, Field.Purpose );
            FromTo = new Element( Record, Field.FromTo );
            Date = DateTime.Parse( Record[ $"{Field.DocumentNumber}" ].ToString() );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reprogramming"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public Reprogramming( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.TransferId );
            DocType = new Element( Record, Field.DocType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            Purpose = new Element( Record, Field.Purpose );
            FromTo = new Element( Record, Field.FromTo );
            Date = DateTime.Parse( Record?[ $"{Field.DocumentNumber}" ].ToString() );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reprogramming"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Reprogramming( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.TransferId );
            DocType = new Element( Record, Field.DocType );
            DocumentNumber = new Element( Record, Field.DocumentNumber );
            Purpose = new Element( Record, Field.Purpose );
            FromTo = new Element( Record, Field.FromTo );
            Date = DateTime.Parse( Record[ $"{Field.DocumentNumber}" ].ToString() );
            Amount = GetAmount();
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the transfer identifier.
        /// </summary>
        /// <value>
        /// The transfer identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        private DateTime Date { get; }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        private IElement DocType { get; }

        /// <summary>
        /// Gets from to.
        /// </summary>
        /// <value>
        /// From to.
        /// </value>
        private IElement FromTo { get; }

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        private IElement DocumentNumber { get; }

        /// <summary>
        /// Gets the purpose.
        /// </summary>
        /// <value>
        /// The purpose.
        /// </value>
        private IElement Purpose { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the transfer identifier.
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
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Element( DocumentNumber )
                    ? DocumentNumber.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetDate()
        {
            try
            {
                return Verify.DateTime( Date )
                    ? Date
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentType()
        {
            try
            {
                return Verify.Element( DocType )
                    ? DocType
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets from to.
        /// </summary>
        /// <returns>
        /// </returns>
        public FromTo GetFromTo()
        {
            try
            {
                return Verify.Input( FromTo.GetValue() )
                    ? (FromTo)Enum.Parse( typeof( FromTo ), FromTo.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
        /// Gets the purpose.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPurpose()
        {
            try
            {
                return Verify.Element( Purpose )
                    ? Purpose
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Implements the GetSource member of the ISource interface.
        /// </summary>
        /// <returns>
        /// </returns>
        Source ISource.GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }
    }
}