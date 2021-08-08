// <copyright file = "AllowanceHolder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Generally, an organized set of activities directed toward a common purpose or
    /// goal that an agency undertakes or proposes to carry out its responsibilities.
    /// Because the term has many uses in practice, it does not have a well-defined,
    /// standard meaning in the legislative process. It is used to describe an agency’s
    /// mission, functions, activities, services, projects, and processes. An Allowance
    /// Hoder is also an element within a budget account. For annually appropriated
    /// accounts, the Office of Management and Budget (OMB) and agencies identify PPAs
    /// by reference to committee reports and budget justifications; for permanent
    /// appropriations, OMB and agencies identify Allowance Hoders by the program and
    /// financing schedules that the President provides in the “Detailed Budget
    /// Estimates” in the budget submission for the relevant fiscal year. Program
    /// activity structures are intended to provide a meaningful representation of the
    /// operations financed by a specific budget account—usually by project, activity,
    /// or organization. 31 U.S.C. 1514 provides that agency allotments will be
    /// established at the highest practical level. At the EPA, OMB apportions the
    /// appropriated funds to the EPA OB Director as the agency’s single Allowance
    /// Holder. Note there is a separate allotment for every appropriation (Treasury
    /// account symbol) for every fiscal year. The OB Director retains the original
    /// signed apportionment documents on behalf of the agency. This is the agency’s
    /// formal designation regarding “Administrative Subdivisions of _funds.” The agency
    /// does not have sub-allotments. The one restriction on the agency’s allotment is
    /// that it cannot exceed the amount of the apportionment. At the Regional level,
    /// Allowance Holder's further divide the Agency's funding with the Regional
    /// Administrator being identified as the primary regional Allowance Holder.
    /// </summary>
    /// <seealso cref = "IAllowanceHolder"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IAllowanceHolder"/>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Local" ) ]
    public class AllowanceHolder : IAllowanceHolder, IProgramElement, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private protected readonly Source _source = Source.AllowanceHolders;

        /// <summary>
        /// Gets or sets the dict.
        /// </summary>
        /// <value>
        /// The dict.
        /// </value>
        private readonly DataRow _record;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _data;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the allowance holder identifier.
        /// </summary>
        /// <value>
        /// The allowance holder identifier.
        /// </value>
        private readonly IKey _id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private readonly IElement _name;

        /// <summary>
        /// Initializes a new instance of the <see cref = "AllowanceHolder"/> class.
        /// </summary>
        public AllowanceHolder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AllowanceHolder"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The dataBuilder.
        /// </param>
        public AllowanceHolder( IBuilder dataBuilder )
        {
            _record = dataBuilder?.GetRecord();
            _id = new Key( _record, PrimaryKey.AllowanceHolderId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AllowanceHolder"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public AllowanceHolder( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.AllowanceHolderId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AllowanceHolder"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public AllowanceHolder( DataRow data )
            : this()
        {
            _record = data;
            _id = new Key( _record, PrimaryKey.AllowanceHolderId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AllowanceHolder"/> class.
        /// </summary>
        /// <param name = "ahcode" >
        /// The ahcode.
        /// </param>
        public AllowanceHolder( string ahcode )
        {
            _record = new DataBuilder( _source, SetArgs( ahcode ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.AllowanceHolderId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( string code )
        {
            if( Verify.Input( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = code
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:_system.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Input( _code.GetValue() ) )
            {
                try
                {
                    return _code.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
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

        /// <summary>
        /// Gets the allowance holder identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
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
        /// Gets the allowance holder code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( _code.GetValue() )
                    ? _code
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the name of the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Input( _name.GetValue() )
                    ? _name
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAllowanceHolder GetAllowanceHolder()
        {
            try
            {
                return MemberwiseClone() as AllowanceHolder;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAllowanceHolder );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
