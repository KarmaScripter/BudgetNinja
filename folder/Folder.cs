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
            DataFile = file;
            DirectoryInfo = GetBaseDirectory();
            FolderName = DirectoryInfo.Name;
            FolderPath = DirectoryInfo.FullName;
            Files = Directory.GetFiles( FolderPath );
            DirectorySecurity = DirectoryInfo.GetAccessControl();
            CreationDate = DirectoryInfo.CreationTime;
            ChangeDate = DirectoryInfo.LastWriteTime;
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
                return Verify.Input( fullName ) 
                    && !Directory.Exists( fullName )
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
                        ? DirectoryInfo?.CreateSubdirectory( folderName )
                        : default( DirectoryInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DirectoryInfo );
            }
        }

        /// <summary>
        /// Gets the path Data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPath> GetDataPaths()
        {
            try
            {
                var _paths = Files
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
        /// Gets the Data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFile> GetDataFiles()
        {
            try
            {
                var _paths = Files
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
                    DirectoryInfo?.MoveTo( fullName );
                }
                else if( Verify.Input( fullName )
                    && Directory.Exists( fullName ) )
                {
                    Directory.CreateDirectory( fullName );
                    DirectoryInfo?.MoveTo( fullName );
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
                    ZipFile.CreateFromDirectory( FolderPath, destinationPath );
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
                    ZipFile.ExtractToDirectory( zipPath, FolderPath );
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
                    DirectoryInfo?.SetAccessControl( security );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
