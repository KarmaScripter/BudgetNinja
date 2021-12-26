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
        public Source Source { get; } = Source.Activity;

        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <value>
        /// The dataRow.
        /// </value>
        public DataRow Record { get;  }

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>
        /// The activity identifier.
        /// </value>
        public IKey ID { get;  }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public IElement Code { get;  }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public IElement Name { get;  }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get;  }

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ActivityId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Activity( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.ActivityId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
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
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.ActivityId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Activity"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Activity( string code )
        {
            Record = new DataBuilder( Source, GetArgs( code ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ActivityId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }
        
        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( string code )
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
        /// A <see cref = "T:System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Input( Name?.GetValue() ) )
            {
                try
                {
                    return Name?.GetValue();
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

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
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
        /// Gets the activity code.
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
        /// Gets the name of the activity.
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
                return Validate.Source( Source )
                    ? Source
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
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
