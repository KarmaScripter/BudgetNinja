// <copyright file="Goal.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

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
    public sealed class Goal : IGoal, IProgramElement, ISource
    {
        // **************************************************************************************************************************
        // ****************************************************     FIELDS    *******************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source Source = Source.Goals;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.GoalId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Goal( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.GoalId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Goal( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.GoalId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Goal"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Goal( string code )
        {
            Record = new DataBuilder( Source, GetArgs( code ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.GoalId );
            Name = new Element( Record, Field.Name );
            Code = new Element( Record, Field.Code );
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Data { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private IElement Code { get; }

        /// <summary>
        /// Gets the goal identifier.
        /// </summary>
        /// <value>
        /// The goal identifier.
        /// </value>
        private IKey ID { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private IElement Name { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Element( Code )
                    ? Code?.GetValue()
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
                    return default;
                }
            }

            return default;
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
                        [ "Code" ] = goal.ToString()
                    };
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
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
        /// Gets the code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( Code?.GetValue() )
                    ? Code
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( Name?.GetValue() )
                    ? Name
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return default;
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
                return Verify.Source( Source )
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
        private static void Fail( Exception ex )
        {
            using var error = new StaticError( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}