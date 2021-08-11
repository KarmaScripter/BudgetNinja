// <copyright file = "Goal.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "IGoal"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Goal : IGoal, IProgramElement, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.Goals;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        public Goal()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Goal( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.GoalId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Goal( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.GoalId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Goal( DataRow dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.GoalId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Goal( string code )
        {
            _record = new DataBuilder( _source, GetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.GoalId );
            _name = new Element( _record, Field.Name );
            _code = new Element( _record, Field.Code );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        private protected readonly DataRow _record;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected readonly IDictionary<string, object> _data;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected readonly IElement _code;

        /// <summary>
        /// Gets the goal identifier.
        /// </summary>
        /// <value>
        /// The goal identifier.
        /// </value>
        private protected readonly IKey _id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected readonly IElement _name;
        
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
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Element( _code )
                    ? _code?.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
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

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "goal" >
        /// The goal.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs( int goal )
        {
            if( goal > 0
                && goal < 5 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ "_code" ] = goal.ToString()
                    };
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Gets the identifier.
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
        /// Gets the code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( _code?.GetValue() )
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
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                return Verify.Input( _name?.GetValue() )
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
        /// Gets the goal.
        /// </summary>
        /// <returns>
        /// </returns>
        public IGoal GetGoal()
        {
            try
            {
                return MemberwiseClone() as Goal;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IGoal );
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
