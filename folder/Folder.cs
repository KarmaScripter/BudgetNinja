// // <copyright file = "Folder.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FolderBase" />
    /// <seealso cref="IFolder" />
    public class Folder : FolderBase, IFolder
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

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
            ChangedDate = DirectoryInfo.LastWriteTime;
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
                Folder.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Creates the specified filepath.
        /// </summary>
        /// <param name="fullname">The filepath.</param>
        /// <returns></returns>
        public static DirectoryInfo Create( string fullname )
        {
            try
            {
                return Verify.Input( fullname ) && !Directory.Exists( fullname )
                    ? Directory.CreateDirectory( fullname )
                    : default;
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Deletes the specified foldername.
        /// </summary>
        /// <param name="foldername">The foldername.</param>
        public static void Delete( string foldername )
        {
            try
            {
                if( Verify.Input( foldername )
                    && Directory.Exists( foldername ) )
                {
                    Directory.Delete( foldername, true );
                }
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
            }
        }

        /// <summary>
        /// Creates the sub folder.
        /// </summary>
        /// <param name="foldername">The foldername.</param>
        /// <returns></returns>
        public DirectoryInfo CreateSubDirectory( string foldername )
        {
            if( string.IsNullOrEmpty( foldername ) )
            {
                return default;
            }

            if( Verify.Input( foldername )
                && Directory.Exists( foldername ) )
            {
                Directory.Delete( foldername );
            }

            try
            {
                return Verify.Input( foldername ) && !Directory.Exists( foldername )
                    ? DirectoryInfo?.CreateSubdirectory( foldername )
                    : default;
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
                return default;
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
                var paths = Files?.Select( fd => new DataPath( fd ) )?.ToArray();

                return paths?.Any() == true
                    ? paths
                    : default;
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
                return default;
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
                var paths = Files?.Select( f => new DataPath( f ) )?.ToArray();
                var data = paths?.Select( d => new DataFile( d ) )?.ToArray();

                return Verify.Input( data )
                    ? data
                    : default;
            }
            catch( IOException ex )
            {
                Folder.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Moves the specified folderpath.
        /// </summary>
        /// <param name="fullname">The folderpath.</param>
        public void Move( string fullname )
        {
            try
            {
                if( Verify.Input( fullname )
                    && !Directory.Exists( fullname ) )
                {
                    DirectoryInfo?.MoveTo( fullname );
                }
                else if( Verify.Input( fullname )
                    && Directory.Exists( fullname ) )
                {
                    Directory.CreateDirectory( fullname );
                    DirectoryInfo?.MoveTo( fullname );
                }
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
            }
        }

        /// <summary>
        /// Zips the specified filepath.
        /// </summary>
        /// <param name="destinationpath">The filepath.</param>
        public void Zip( string destinationpath )
        {
            try
            {
                if( Verify.Input( destinationpath ) )
                {
                    ZipFile.CreateFromDirectory( FolderPath, destinationpath );
                }
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
            }
        }

        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="zippath">The zippath.</param>
        public void UnZip( string zippath )
        {
            try
            {
                if( Verify.Input( zippath )
                    && File.Exists( zippath ) )
                {
                    ZipFile.ExtractToDirectory( zippath, FolderPath );
                }
            }
            catch( Exception ex )
            {
                Folder.Fail( ex );
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
                    Folder.Fail( ex );
                }
            }
        }
    }
}
