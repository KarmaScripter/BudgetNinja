// <copyright file = "Reprogramming.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class Reprogramming : ProgramResultsCode, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.Transfers;
        
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
            _record = new Builder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.TransferId );
            _docType = new Element( _record, Field.DocType );
            _documentNumber = new Element( _record, Field.DocumentNumber );
            _purpose = new Element( _record, Field.Purpose );
            _fromTo = new Element( _record, Field.FromTo );
            _date = DateTime.Parse( _record[ $"{Field.DocumentNumber}" ].ToString() );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
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
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.TransferId );
            _docType = new Element( _record, Field.DocType );
            _documentNumber = new Element( _record, Field.DocumentNumber );
            _purpose = new Element( _record, Field.Purpose );
            _fromTo = new Element( _record, Field.FromTo );
            _date = DateTime.Parse( _record?[ $"{Field.DocumentNumber}" ].ToString() );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reprogramming"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Reprogramming( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.TransferId );
            _docType = new Element( _record, Field.DocType );
            _documentNumber = new Element( _record, Field.DocumentNumber );
            _purpose = new Element( _record, Field.Purpose );
            _fromTo = new Element( _record, Field.FromTo );
            _date = DateTime.Parse( _record[ $"{Field.DocumentNumber}" ].ToString() );
            _amount = GetAmount();
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        private readonly DateTime _date;

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        private readonly IElement _docType;

        /// <summary>
        /// Gets from to.
        /// </summary>
        /// <value>
        /// From to.
        /// </value>
        private readonly IElement _fromTo;

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        private readonly IElement _documentNumber;

        /// <summary>
        /// Gets the purpose.
        /// </summary>
        /// <value>
        /// The purpose.
        /// </value>
        private readonly IElement _purpose;
        
        /// <summary>
        /// Gets the transfer identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
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
                return Verify.Element( _documentNumber )
                    ? _documentNumber.GetValue()
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
                return Verify.DateTime( _date )
                    ? _date
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
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
                return Verify.Element( _docType )
                    ? _docType
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
                return Verify.Input( _fromTo.GetValue() )
                    ? (FromTo)Enum.Parse( typeof( FromTo ), _fromTo.GetValue() )
                    : default( FromTo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FromTo );
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
                return Verify.Element( _documentNumber )
                    ? _documentNumber
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
                return Verify.Element( _purpose )
                    ? _purpose
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
                return Validate.Source( _source )
                    ? _source
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
