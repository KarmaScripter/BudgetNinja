// <copyright file="ProgramProject.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public abstract class ProgramBase
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets the program project identifier.
        /// </summary>
        /// <value>
        /// The program project identifier.
        /// </value>
        private protected IKey ID { get; set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected IElement Code { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected IElement Name { get; set; }

        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        private protected IElement Definition { get; set; }

        /// <summary>
        /// Gets the laws.
        /// </summary>
        /// <value>
        /// The laws.
        /// </value>
        private protected IElement Laws { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private protected IElement Title { get; set; }

        /// <summary>
        /// Gets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        private protected IElement Narrative { get; set; }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected IElement ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the name of the program area.
        /// </summary>
        /// <value>
        /// The name of the program area.
        /// </value>
        private protected IElement ProgramAreaName { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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