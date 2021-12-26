// <copyright file = "AccountBase.cs" company = "Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class AccountBase
    {
        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        public IElement NpmCode { get; set; }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public IElement Code { get; set; }

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        public IElement ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        public IElement ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the goal code.
        /// </summary>
        /// <value>
        /// The goal code.
        /// </value>
        public IElement GoalCode { get; set; }

        /// <summary>
        /// Gets the objective code.
        /// </summary>
        /// <value>
        /// The objective code.
        /// </value>
        public IElement ObjectiveCode { get; set; }

        /// <summary>
        /// Gets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        public IElement ActivityCode { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; }
        
        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> GetArgs( string code )
        {
            if( Verify.Input( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{ Field.Code }" ] = code
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
        /// Gets the account identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCode()
        {
            try
            {
                return Verify.Input( Code?.GetValue() )
                    ? Code
                    : default( IElement );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( IElement );
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
            _error.ShowDialog();
        }
    }
}
