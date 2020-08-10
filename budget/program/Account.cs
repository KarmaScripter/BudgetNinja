// // <copyright file = "Account.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Account : AccountBase, IAccount, ISource
    {
        // *************************************************************************************************************************
        // ****************************************************     FIELDS    ******************************************************
        // *************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source Source = Source.Accounts;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.AccountId );
            Code = new Element( Record, Field.Code );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            GoalCode = new Element( Record, Field.GoalCode );
            ObjectiveCode = new Element( Record, Field.ObjectiveCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Account( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.AccountId );
            Code = new Element( Record, Field.Code );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            GoalCode = new Element( Record, Field.GoalCode );
            ObjectiveCode = new Element( Record, Field.ObjectiveCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Account( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.AccountId );
            Code = new Element( Record, Field.Code );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            GoalCode = new Element( Record, Field.GoalCode );
            ObjectiveCode = new Element( Record, Field.ObjectiveCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Account"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public Account( string code )
        {
            Record = new DataBuilder( Account.Source, GetArgs( code ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.AccountId );
            Code = new Element( Record, Field.Code );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            GoalCode = new Element( Record, Field.GoalCode );
            ObjectiveCode = new Element( Record, Field.ObjectiveCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                return default;
            }
        }

        /// <summary>
        /// Gets the activity
        /// </summary>
        /// <returns>
        /// </returns>
        public IActivity GetActivity()
        {
            if( Verify.Input( ActivityCode.GetValue() ) )
            {
                try
                {
                    var dict = new Dictionary<string, object>
                    {
                        [ $"{Field.ActivityCode}" ] = ActivityCode.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.Activity, Provider.SQLite );
                    var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new Activity( query ) ?? default;
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
        /// Gets the national program code.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.NpmCode}" ] = NpmCode
                };

                var connection = new ConnectionBuilder( Source.NationalPrograms, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new NationalProgram( query ) ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = GoalCode
                };

                var connection = new ConnectionBuilder( Source.Goals, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Goal( query ) ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = ObjectiveCode
                };

                var connection = new ConnectionBuilder( Source.Objectives, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Objective( query ) ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = ProgramProjectCode
                };

                var connection = new ConnectionBuilder( Source.ProgramProjects, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new ProgramProject( query ) ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = ProgramAreaCode
                };

                var connection = new ConnectionBuilder( Source.ProgramAreas, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, dict, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new ProgramArea( query ) ?? default;
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
                return Verify.Input( Code?.GetValue() )
                    ? Code?.GetValue()
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
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Account.Source )
                    ? Account.Source
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
                var name = GetProgramProject()?.GetName();

                return Verify.Input( name?.GetValue() )
                    ? name
                    : default;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
