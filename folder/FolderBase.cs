// <copyright file = "FolderBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.AccessControl;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public abstract class FolderBase
    {
        /// <summary>
        /// Gets or sets the Data file.
        /// </summary>
        /// <value>
        /// The Data file.
        /// </value>
        public IFile DataFile { get; set; }

        /// <summary>
        /// The base stream
        /// </summary>
        public DirectoryInfo DirectoryInfo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string FolderName { get; set; }

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <value>
        /// The folder path.
        /// </value>
        public string FolderPath { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public IEnumerable<string> Files { get; set; }

        /// <summary>
        /// Gets the file security.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public DirectorySecurity DirectorySecurity { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        public DateTime ChangeDate { get; set; }
        
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
                return default( string );
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
                return default( string );
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
                var _file = DataFile
                    ?.GetFileInfo()
                    ?.Directory;

                return Verify.Input( _file?.FullName )
                    ? Directory.CreateDirectory( _file?.FullName )
                    : default( DirectoryInfo );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( DirectoryInfo );
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
                return Verify.DateTime( CreationDate ) 
                    ? CreationDate 
                    : default( DateTime );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( DateTime );
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
                return Verify.DateTime( ChangeDate )
                    ? ChangeDate
                    : default( DateTime );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( DateTime );
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
                    : default( IEnumerable<string> );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetStreamData()
        {
            try
            {
                var _enumerable = DirectoryInfo?.EnumerateFiles( FolderPath );

                return Verify.Sequence(  _enumerable )
                    ? _enumerable
                    : default( IEnumerable<FileInfo> );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IEnumerable<FileInfo> );
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
                var _folders = Enum.GetNames( typeof( Environment.SpecialFolder ) );

                return _folders?.Any() == true
                    ? _folders
                    : default( string[ ] );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
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
                var _folders = DirectoryInfo?.GetDirectories();

                return _folders?.Any() != true
                    ? _folders
                    : default( DirectoryInfo[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DirectoryInfo> );
            }
        }

        /// <summary>
        /// Creats the zip file.
        /// </summary>
        /// <param name="sourcePath">The sourcePath.</param>
        /// <param name="destinationPath">The destinationPath.</param>
        public static void CreateZipFile( string sourcePath, string destinationPath )
        {
            try
            {
                if( Verify.Input( destinationPath )
                    && Verify.Input( sourcePath ) )
                {
                    ZipFile.CreateFromDirectory( sourcePath, destinationPath );
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
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
