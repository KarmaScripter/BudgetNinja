// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public abstract class FolderBase
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the data file.
        /// </summary>
        /// <value>
        /// The data file.
        /// </value>
        private protected IFile DataFile;

        /// <summary>
        /// The base stream
        /// </summary>
        private protected DirectoryInfo DirectoryInfo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string FileName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string FolderName { get; set; }

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <value>
        /// The folder path.
        /// </value>
        private protected string FolderPath { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        private protected IEnumerable<string> Files { get; set; }

        /// <summary>
        /// Gets the file security.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        private protected DirectorySecurity DirectorySecurity { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        private protected DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        private protected DateTime ChangedDate { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetFolderName()
        {
            try
            {
                return Verify.Input( FolderName )
                    ? FolderName
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <returns></returns>
        public string GetFolderPath()
        {
            try
            {
                return Verify.Input( FolderPath )
                    ? FolderPath
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <returns></returns>
        private protected DirectoryInfo GetBaseDirectory()
        {
            try
            {
                var file = DataFile?.GetFileInfo()?.Directory;

                return Verify.Input( file?.FullName )
                    ? Directory.CreateDirectory( file?.FullName )
                    : default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <returns></returns>
        public DateTime GetCreationDate()
        {
            try
            {
                return CreationDate;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the changed date.
        /// </summary>
        /// <returns></returns>
        public DateTime GetChangedDate()
        {
            try
            {
                return ChangedDate;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetFileNames()
        {
            try
            {
                return Files?.Any() == true
                    ? Files
                    : default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetStreamData()
        {
            try
            {
                var data = DirectoryInfo?.EnumerateFiles( FolderPath );

                return Verify.Input( data )
                    ? data
                    : default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the special folders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSpecialFolders()
        {
            try
            {
                var folders = Enum.GetNames( typeof( Environment.SpecialFolder ) );

                return folders?.Any() == true
                    ? folders
                    : default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the sub folders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DirectoryInfo> GetSubFolders()
        {
            try
            {
                var folders = DirectoryInfo?.GetDirectories();

                return folders?.Any() != true
                    ? folders
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Creats the zip file.
        /// </summary>
        /// <param name="sourcepath">The sourcepath.</param>
        /// <param name="destinationpath">The destinationpath.</param>
        public static void CreateZipFile( string sourcepath, string destinationpath )
        {
            try
            {
                if( Verify.Input( destinationpath )
                    && Verify.Input( sourcepath ) )
                {
                    ZipFile.CreateFromDirectory( sourcepath, destinationpath );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fails the specified ex.
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