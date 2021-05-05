// <copyright file = "AccountBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

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
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        private protected IKey ID { get; set; }

        /// <summary>
        /// Gets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        private protected IElement NpmCode { get; set; }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected IElement Code { get; set; }

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private protected IElement ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected IElement ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the goal code.
        /// </summary>
        /// <value>
        /// The goal code.
        /// </value>
        private protected IElement GoalCode { get; set; }

        /// <summary>
        /// Gets the objective code.
        /// </summary>
        /// <value>
        /// The objective code.
        /// </value>
        private protected IElement ObjectiveCode { get; set; }

        /// <summary>
        /// Gets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        private protected IElement ActivityCode { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Data { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                    : default;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error.SetText();
            error.ShowDialog();
        }
    }
}
