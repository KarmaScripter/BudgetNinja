// <copyright file = "Activity.cs" company = "Terry D. Eppler">
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
    /// mission, functions, activities, services, projects, and processes. An element
    /// within a budget account. For annually appropriated accounts, the Office of
    /// Management and Budget (OMB) and agencies identify PPAs by reference to
    /// committee reports and budget justifications; for permanent appropriations, OMB
    /// and agencies identify an Activity by the program and financing schedules that
    /// the President provides in the “Detailed Budget Estimates” in the budget
    /// submission for the relevant fiscal year. Program activity structures are
    /// intended to provide a meaningful representation of the operations financed by a
    /// specific budget account—usually by project, activity, or organization.
    /// </summary>
    /// <seealso cref = "IActivity"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IActivity"/>
    /// <seealso cref = "IDataBuilder"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Activity : IActivity, IProgramElement, ISource
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Activity;

        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <value>
        /// The dataRow.
        /// </value>
        private readonly DataRow _record;

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>
        /// The activity identifier.
        /// </value>
        private readonly IKey _id;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private readonly IElement _code;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private readonly IElement _name;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        private Activity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Activity( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ActivityId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Activity( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ActivityId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.Activity"/>
        /// class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Activity( DataRow dataRow )
            : this()
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ActivityId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Activity( string code )
        {
            _record = new DataBuilder( _source, SetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ActivityId );
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
            if( Verify.Input( _name?.GetValue() ) )
            {
                try
                {
                    return _name?.GetValue();
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
        /// Gets the activity identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
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
        /// Gets the activity code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Element( _code )
                    ? _code
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the name of the activity.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Element( _name )
                    ? _name
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <returns>
        /// </returns>
        public IActivity GetActivity()
        {
            try
            {
                return MemberwiseClone() as Activity;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IActivity );
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
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
