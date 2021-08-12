// <copyright file = "Folder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.AccessControl;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FolderBase" />
    /// <seealso cref="IFolder" />
    public class Folder : FolderBase, IFolder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        public Folder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        public Folder( IFile file )
        {
            _dataFile = file;
            _directoryInfo = GetBaseDirectory();
            _folderName = _directoryInfo.Name;
            _folderPath = _directoryInfo.FullName;
            _files = Directory.GetFiles( _folderPath );
            _directorySecurity = _directoryInfo.GetAccessControl();
            _creationDate = _directoryInfo.CreationTime;
            _changedDate = _directoryInfo.LastWriteTime;
        }
        
        /// <summary>
        /// Gets the current directory.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            try
            {
                return Verify.Input( DataPath.CurrentDirectory )
                    ? DataPath.CurrentDirectory
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Creates the specified filepath.
        /// </summary>
        /// <param name="fullName">The filepath.</param>
        /// <returns></returns>
        public static DirectoryInfo Create( string fullName )
        {
            try
            {
                return Verify.Input( fullName ) && !Directory.Exists( fullName )
                    ? Directory.CreateDirectory( fullName )
                    : default( DirectoryInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DirectoryInfo );
            }
        }

        /// <summary>
        /// Deletes the specified folderName.
        /// </summary>
        /// <param name="folderName">The folderName.</param>
        public static void Delete( string folderName )
        {
            try
            {
                if( Verify.Input( folderName )
                    && Directory.Exists( folderName ) )
                {
                    Directory.Delete( folderName, true );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the sub folder.
        /// </summary>
        /// <param name="folderName">The folderName.</param>
        /// <returns></returns>
        public DirectoryInfo CreateSubDirectory( string folderName )
        {
            if( string.IsNullOrEmpty( folderName ) )
            {
                return default( DirectoryInfo );
            }

            if( Verify.Input( folderName )
                && Directory.Exists( folderName ) )
            {
                Directory.Delete( folderName );
            }

            try
            {
                return Verify.Input( folderName ) 
                    && !Directory.Exists( folderName )
                        ? _directoryInfo?.CreateSubdirectory( folderName )
                        : default( DirectoryInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DirectoryInfo );
            }
        }

        /// <summary>
        /// Gets the path data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPath> GetDataPaths()
        {
            try
            {
                var _paths = _files
                    ?.Select( fd => new DataPath( fd ) )
                    ?.ToArray();

                return _paths?.Any() == true
                    ? _paths
                    : default( DataPath[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IPath> );
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFile> GetDataFiles()
        {
            try
            {
                var _paths = _files
                    ?.Select( f => new DataPath( f ) )
                    ?.ToArray();

                var _data = _paths
                    ?.Select( d => new DataFile( d ) )
                    ?.ToArray();

                return Verify.Input( _data )
                    ? _data
                    : default( DataFile[ ] );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IEnumerable<IFile> );
            }
        }

        /// <summary>
        /// Moves the specified folderpath.
        /// </summary>
        /// <param name="fullName">The folderpath.</param>
        public void Move( string fullName )
        {
            try
            {
                if( Verify.Input( fullName )
                    && !Directory.Exists( fullName ) )
                {
                    _directoryInfo?.MoveTo( fullName );
                }
                else if( Verify.Input( fullName )
                    && Directory.Exists( fullName ) )
                {
                    Directory.CreateDirectory( fullName );
                    _directoryInfo?.MoveTo( fullName );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Zips the specified filepath.
        /// </summary>
        /// <param name="destinationPath">The filepath.</param>
        public void Zip( string destinationPath )
        {
            try
            {
                if( Verify.Input( destinationPath ) )
                {
                    ZipFile.CreateFromDirectory( _folderPath, destinationPath );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="zipPath">The zipPath.</param>
        public void UnZip( string zipPath )
        {
            try
            {
                if( Verify.Input( zipPath )
                    && File.Exists( zipPath ) )
                {
                    ZipFile.ExtractToDirectory( zipPath, _folderPath );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the access control.
        /// </summary>
        /// <param name="security">The security.</param>
        public void SetAccessControl( DirectorySecurity security )
        {
            if( security != null )
            {
                try
                {
                    _directoryInfo?.SetAccessControl( security );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
