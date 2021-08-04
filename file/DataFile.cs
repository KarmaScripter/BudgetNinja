// <copyright file = "_dataFile.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
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
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FileBase" />
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class DataFile : FileBase, IFile
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFile"/> class.
        /// </summary>
        public DataFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFile"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public DataFile( string input )
        {
            _path = new DataPath( input );
            FileInfo = new FileInfo( _path.GetFullPath() );
            FullName = FileInfo.FullName;
            HasParent = CheckParent();
            Length = FileInfo.Length;
            Attributes = FileInfo.Attributes;
            Security = FileInfo.GetAccessControl();
            CreationDate = FileInfo.CreationTime;
            ChangedDate = FileInfo.LastWriteTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFile"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public DataFile( IPath path )
        {
            _path = path;
            FileInfo = new FileInfo( _path.GetFullPath() );
            FullName = FileInfo.FullName;
            HasParent = CheckParent();
            Length = FileInfo.Length;
            Attributes = FileInfo.Attributes;
            Security = FileInfo.GetAccessControl();
            CreationDate = FileInfo.CreationTime;
            ChangedDate = FileInfo.LastWriteTime;
        }

        // ***************************************************************************************************************************
        // ****************************************************    MEMBERS    ********************************************************
        // ***************************************************************************************************************************

        public static FileInfo Create( string filepath )
        {
            try
            {
                return Verify.Input( filepath )
                    ? new FileInfo( filepath )
                    : default( FileInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FileInfo );
            }
        }

        /// <summary>
        /// Transfers the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public void Transfer( DirectoryInfo folder )
        {
            // Check if the target directory exists, if not, create it.
            if( !Directory.Exists( folder.FullName ) )
            {
                Directory.CreateDirectory( folder.FullName );
            }

            try
            {
                foreach( var fileinfo in folder?.GetFiles() )
                {
                    Directory.Move( fileinfo.FullName, folder.Name );
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified search]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains( string search )
        {
            try
            {
                var path = _path?.GetFullPath();

                if( Verify.Input( path )
                    && File.Exists( path ) )
                {
                    using var reader = new StreamReader( path );
                    var text = reader?.ReadLine();
                    var result = false;

                    while( text == string.Empty )
                    {
                        if( Regex.IsMatch( text, search ) )
                        {
                            result = true;
                            break;
                        }

                        text = reader.ReadLine();
                    }

                    return result;
                }

                return false;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Searches the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> Search( string pattern )
        {
            if( Verify.Input( pattern ) )
            {
                try
                {
                    var path = _path?.GetFullPath();

                    if( Verify.Input( path )
                        && File.Exists( path ) )
                    {
                        var files = Directory.EnumerateFiles( path, pattern );
                        var data = new List<FileInfo>();

                        foreach( var file in files )
                        {
                            data.Add( new FileInfo( file ) );
                        }

                        return Verify.Input( data )
                            ? data
                            : default( List<FileInfo> );
                    }
                }
                catch( IOException ex )
                {
                    Fail( ex );
                    return default( IEnumerable<FileInfo> );
                }
            }

            return default( IEnumerable<FileInfo> );
        }

        /// <summary>Returns a string that
        /// represents the current object.
        /// </summary>
        /// <returns>A string that represents
        /// the current object.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( FullName )
                    ? FullName
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            try
            {
                return Verify.Input( FullName )
                    ? FullName
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the data path.
        /// </summary>
        /// <returns></returns>
        public IPath GetDataPath()
        {
            try
            {
                return File.Exists( _path?.GetFullPath() )
                    ? _path
                    : default( IPath );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IPath );
            }
        }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            try
            {
                var ext = _path?.GetFileExtension();

                return Verify.Input( ext )
                    ? ext
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            try
            {
                var path = _path?.GetFullPath();

                return Verify.Input( path )
                    ? path
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
        public IFolder GetParentFolder()
        {
            try
            {
                return CheckParent()
                    ? new Folder( this )
                    : default( Folder );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( IFolder );
            }
        }

        /// <summary>
        /// Browses this instance.
        /// </summary>
        /// <returns></returns>
        public static IFile Browse()
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                var file = new DataFile( dialog?.FileName );

                return File.Exists( file?.GetFilePath() )
                    ? file
                    : default( DataFile );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IFile );
            }
        }
    }
}
