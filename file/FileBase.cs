// <copyright file = "FileBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Security.AccessControl;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public abstract class FileBase
    {
        /// <summary>
        /// The path
        /// </summary>
        public IPath Path { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has parent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has parent { get; set; } otherwise, <c>false</c>.
        /// </value>
        public bool HasParent { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.p/// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the lengeth.
        /// </summary>
        /// <value>
        /// The lengeth.
        /// </value>
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        public FileSecurity FileSecurity { get; set; }
        
        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            var _input = Path?.GetFullPath();

            if( Verify.Input( _input ) )
            {
                try
                {
                    return File.Exists( _input )
                        ? _input
                        : string.Empty;
                }
                catch( IOException ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <returns></returns>
        public string GetPathRoot()
        {
            try
            {
                var _root = Path?.GetPathRoot();

                return Verify.Input( _root )
                    ? _root
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            try
            {
                var name = Path?.GetFileName();

                return Verify.Input( name )
                    ? name
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns></returns>
        public EXT GetExtension()
        {
            try
            {
                var _extension = Path?.GetFileExtension();

                return Verify.Input( _extension )
                    ? (EXT)Enum.Parse( typeof( EXT ), _extension )
                    : default( EXT );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return EXT.NS;
            }
        }

        /// <summary>
        /// Gets the length of the file.
        /// </summary>
        /// <returns></returns>
        public long GetLength()
        {
            try
            {
                return FileInfo.Length > 0
                    ? FileInfo.Length
                    : 0;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Moves the specified destination.
        /// </summary>
        /// <param name="filePath">The destination.</param>
        public void Move( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    FileInfo?.MoveTo( filePath );
                }
                catch( IOException ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Copies the specified filePath.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        public void Copy( string filePath )
        {
            try
            {
                if( Verify.Input( filePath )
                    && !File.Exists( filePath ) )
                {
                    FileInfo.CopyTo( filePath );
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            try
            {
                var _file = Path?.GetFullName();

                if( Verify.Input( _file )
                    && File.Exists( _file ) )
                {
                    File.Delete( _file );
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the file information.
        /// </summary>
        /// <returns></returns>
        public FileInfo GetFileInfo()
        {
            try
            {
                return Verify.Input( FileInfo?.Name ) 
                    && File.Exists( FileInfo?.FullName )
                        ? FileInfo
                        : default( FileInfo );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( FileInfo );
            }
        }
        
        /// <summary>
        /// Determines whether [has parent folder].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has parent folder]; otherwise, <c>false</c>.
        /// </returns>
        private protected bool CheckParent()
        {
            try
            {
                return Verify.Input( FileInfo?.DirectoryName ) 
                    && Directory.Exists( FileInfo?.DirectoryName );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Gets the file security.
        /// </summary>
        /// <returns></returns>
        public FileSecurity GetFileSecurity()
        {
            try
            {
                return FileSecurity ?? default( FileSecurity );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( FileSecurity );
            }
        }

        /// <summary>
        /// Gets the file attributes.
        /// </summary>
        /// <returns></returns>
        public FileAttributes GetFileAttributes()
        {
            try
            {
                return Verify.Element( Attributes )
                    ? Attributes
                    : default( FileAttributes );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( FileAttributes );
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
        /// Gets the base stream.
        /// </summary>
        /// <returns></returns>
        public FileStream GetBaseStream()
        {
            try
            {
                var _file = Path?.GetFullPath();

                return Verify.Input( _file ) 
                    && File.Exists( _file )
                        ? new FileInfo( _file )?.Create()
                        : default( FileStream );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FileStream );
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
