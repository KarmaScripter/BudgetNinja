// <copyright file = "Account.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Account : AccountBase, IAccount, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source _source = Source.Accounts;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Account( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.AccountId );
            _code = new Element( _record, Field.Code );
            _npmCode = new Element( _record, Field.NpmCode );
            _programProjectCode = new Element( _record, Field.ProgramProjectCode );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _goalCode = new Element( _record, Field.GoalCode );
            _objectiveCode = new Element( _record, Field.ObjectiveCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The dataBuilder.
        /// </param>
        public Account( IBuilder dataBuilder )
        {
            _record = dataBuilder?.GetRecord();
            _id = new Key( _record, PrimaryKey.AccountId );
            _code = new Element( _record, Field.Code );
            _npmCode = new Element( _record, Field.NpmCode );
            _programProjectCode = new Element( _record, Field.ProgramProjectCode );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _goalCode = new Element( _record, Field.GoalCode );
            _objectiveCode = new Element( _record, Field.ObjectiveCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Account( DataRow dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.AccountId );
            _code = new Element( _record, Field.Code );
            _npmCode = new Element( _record, Field.NpmCode );
            _programProjectCode = new Element( _record, Field.ProgramProjectCode );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _goalCode = new Element( _record, Field.GoalCode );
            _objectiveCode = new Element( _record, Field.ObjectiveCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Account( string code )
        {
            _record = new DataBuilder( _source, GetArgs( code ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.AccountId );
            _code = new Element( _record, Field.Code );
            _npmCode = new Element( _record, Field.NpmCode );
            _programProjectCode = new Element( _record, Field.ProgramProjectCode );
            _programAreaCode = new Element( _record, Field.ProgramAreaCode );
            _goalCode = new Element( _record, Field.GoalCode );
            _objectiveCode = new Element( _record, Field.ObjectiveCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAccount GetAccount()
        {
            try
            {
                return MemberwiseClone() as Account;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAccount );
            }
        }

        /// <summary>
        /// Gets the activity
        /// </summary>
        /// <returns>
        /// </returns>
        public IActivity GetActivity()
        {
            if( Verify.Input( _activityCode.GetValue() ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.ActivityCode}" ] = _activityCode.GetValue()
                    };

                    var _connection = new ConnectionBuilder( Source.Activity, Provider.SQLite );
                    var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                    using var _query = new Query( _connection, _statement );
                    return new Activity( _query ) ?? default( Activity );
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IActivity );
                }
            }

            return default( IActivity );
        }

        /// <summary>
        /// Gets the national program code.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.NpmCode}" ] = _npmCode
                };

                var _connection = new ConnectionBuilder( Source.NationalPrograms, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new NationalProgram( _query ) ?? default( NationalProgram );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( INationalProgram );
            }
        }

        /// <summary>
        /// Gets the goal code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IGoal GetGoal()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _goalCode
                };

                var _connection = new ConnectionBuilder( Source.Goals, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new Goal( _query ) ?? default( Goal );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IGoal );
            }
        }

        /// <summary>
        /// Gets the objective code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IObjective GetObjective()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _objectiveCode
                };

                var _connection = new ConnectionBuilder( Source.Objectives, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new Objective( _query ) ?? default( Objective );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IObjective );
            }
        }

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramProject GetProgramProject()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _programProjectCode
                };

                var _connection = new ConnectionBuilder( Source.ProgramProjects, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new ProgramProject( _query ) ?? default( ProgramProject );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramProject );
            }
        }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramArea GetProgramArea()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _programAreaCode
                };

                var _connection = new ConnectionBuilder( Source.ProgramAreas, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new ProgramArea( _query ) ?? default( ProgramArea );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramArea );
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
                return Verify.Input( _code?.GetValue() )
                    ? _code?.GetValue()
                    : string.Empty;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return string.Empty;
            }
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
        /// Gets the name of the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetName()
        {
            try
            {
                var _name = GetProgramProject()
                    ?.GetName();

                return Verify.Input( _name?.GetValue() )
                    ? _name
                    : default( IElement );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
    }
}
