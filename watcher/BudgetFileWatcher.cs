// <copyright file = "BudgetFileWatcher.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FileSystemWatcher" />
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    public class BudgetFileWatcher : FileSystemWatcher
    {
        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetFileWatcher"/> class.
        /// </summary>
        public BudgetFileWatcher()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetFileWatcher"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public BudgetFileWatcher( string filepath )
        {
            FilePath = new DataPath( filepath );
            FileName = FilePath.GetFileName();
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private string FileName { get; }

        /// <summary>
        /// Gets the data path.
        /// </summary>
        /// <value>
        /// The data path.
        /// </value>
        private IPath FilePath { get; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            try
            {
                return Verify.Input( FileName )
                    ? FileName
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            try
            {
                return Verify.Input( FilePath?.GetFullPath() )
                    ? FilePath?.GetFullPath()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the file extenstion.
        /// </summary>
        /// <returns></returns>
        public string GetFileExtenstion()
        {
            try
            {
                return Verify.Input( FilePath?.GetFileExtension() )
                    ? FilePath?.GetFileExtension()
                    : string.Empty;
            }
            catch( Exception ex )
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
            error?.SetText();
            error?.ShowDialog();
        }

        // **************************************************************************************************************************
        // ********************************************      EVENT HANDLERS   *******************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Called when [file changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnChanged( object sender, EventArgs e )
        {
            try
            {
                using var message = new Message( "NOT YET IMPLEMENTED" );
                message.ShowDialog();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [file created].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnCreated( object sender, EventArgs e )
        {
            try
            {
                using var message = new Message( "NOT YET IMPLEMENTED" );
                message.ShowDialog();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [file deleted].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnDeleted( object sender, EventArgs e )
        {
            try
            {
                using var message = new Message( "NOT YET IMPLEMENTED" );
                message.ShowDialog();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [file error].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnError( object sender, EventArgs e )
        {
            try
            {
                using var message = new Message( "NOT YET IMPLEMENTED" );
                message.ShowDialog();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [file renamed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnRenamed( object sender, EventArgs e )
        {
            try
            {
                using var message = new Message( "NOT YET IMPLEMENTED" );
                message.ShowDialog();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }
    }
}
