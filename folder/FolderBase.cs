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
        /// Gets or sets the data file.
        /// </summary>
        /// <value>
        /// The data file.
        /// </value>
        private protected IFile _dataFile;

        /// <summary>
        /// The base stream
        /// </summary>
        private protected DirectoryInfo _directoryInfo;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string _fileName;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string _folderName;

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <value>
        /// The folder path.
        /// </value>
        private protected string _folderPath;

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        private protected IEnumerable<string> _files;

        /// <summary>
        /// Gets the file security.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        private protected DirectorySecurity _directorySecurity;

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        private protected DateTime _creationDate;

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        private protected DateTime _changedDate;
        
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetFolderName()
        {
            try
            {
                return Verify.Input( _folderName )
                    ? _folderName
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
                return Verify.Input( _folderPath )
                    ? _folderPath
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
                var _file = _dataFile
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
                return Verify.DateTime( _creationDate ) 
                    ? _creationDate 
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
                return Verify.DateTime( _changedDate )
                    ? _changedDate
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
                return _files?.Any() == true
                    ? _files
                    : default( IEnumerable<string> );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
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
                var _enumerable = _directoryInfo?.EnumerateFiles( _folderPath );

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
                var _folders = _directoryInfo?.GetDirectories();

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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
