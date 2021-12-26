// <copyright file = "ProgramBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public abstract class ProgramBase
    {
        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets the program project identifier.
        /// </summary>
        /// <value>
        /// The program project identifier.
        /// </value>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public IElement Code { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public IElement Name { get; set; }

        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        public IElement Definition { get; set; }

        /// <summary>
        /// Gets the laws.
        /// </summary>
        /// <value>
        /// The laws.
        /// </value>
        public IElement Laws { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public IElement Title { get; set; }

        /// <summary>
        /// Gets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        public IElement Narrative { get; set; }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        public IElement ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the name of the program area.
        /// </summary>
        /// <value>
        /// The name of the program area.
        /// </value>
        public IElement ProgramAreaName { get; set; }
        
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
