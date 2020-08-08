// <copyright file="Application.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System.Diagnostics.CodeAnalysis;
    using static System.Windows.Forms.Application;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    // ***************************************************************************************************************************
    // ****************************************************  DELEGATES  **********************************************************
    // ***************************************************************************************************************************

    /// <summary>
    ///
    /// </summary>
    /// <param name = "data" >
    /// The data.
    /// </param>
    /// <param name = "column" >
    /// The column.
    /// </param>
    /// <param name = "filter" >
    /// The filter.
    /// </param>
    /// <returns>
    /// </returns>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate IEnumerable<DataRow> DataDelegate( IEnumerable<DataRow> data, Field column,
        string filter );

    /// <summary>
    ///
    /// </summary>
    /// <param name = "table" >
    /// The table.
    /// </param>
    /// <param name = "column" >
    /// The column.
    /// </param>
    /// <param name = "filter" >
    /// The filter.
    /// </param>
    /// <returns>
    /// </returns>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate DataTable TableDelegate( DataTable table, Field[] column, string[] filter );

    /// <summary>
    ///
    /// </summary>
    /// <param name = "data" >
    /// The data.
    /// </param>
    /// <param name = "column" >
    /// The column.
    /// </param>
    /// <returns>
    /// </returns>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate IEnumerable<string> FieldDelegate( IEnumerable<DataRow> data, Field column );

    /// <summary>
    ///
    /// </summary>
    /// <param name = "source" >
    /// The source.
    /// </param>
    /// <param name = "provider" >
    /// The provider.
    /// </param>
    /// <param name = "dict" >
    /// The dictionary.
    /// </param>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate void InsertDelegate( Source source, Provider provider, Dictionary<string, object> dict );

    /// <summary>
    ///
    /// </summary>
    /// <param name = "source" >
    /// The source.
    /// </param>
    /// <param name = "provider" >
    /// The provider.
    /// </param>
    /// <param name = "dict" >
    /// The dictionary.
    /// </param>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate void UpdateDelegate( Source source, Provider provider, Dictionary<string, object> dict );

    /// <summary>
    ///
    /// </summary>
    /// <param name = "source" >
    /// The source.
    /// </param>
    /// <param name = "provider" >
    /// The provider.
    /// </param>
    /// <param name = "dict" >
    /// The dictionary.
    /// </param>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public delegate void DeleteDelegate( Source source, Provider provider, Dictionary<string, object> dict );

    // ***************************************************************************************************************************
    // ***************************************       APPLICATION ENTRY POINT METHOD (MAIN)    ************************************
    // ***************************************************************************************************************************

    /// <summary>
    ///
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [ STAThread ]
        private static void Main()
        {
            SetCompatibleTextRenderingDefault( false );
            EnableVisualStyles();
        }
    }
}
