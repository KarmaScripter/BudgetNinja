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
        private protected IPath _path;

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        private protected string _fileName;

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        private protected string _fullName;

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        private protected DateTime _changedDate;

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        private protected FileInfo _fileInfo;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has parent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has parent; otherwise, <c>false</c>.
        /// </value>
        private protected  bool _hasParent;

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        private protected DateTime _creationDate;

        /// <summary>
        /// Gets or sets the lengeth.
        /// </summary>
        /// <value>
        /// The lengeth.
        /// </value>
        private protected long _length;

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        private protected FileAttributes _attributes;

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        private protected FileSecurity Security { get; set; }
        
        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            var _input = _path?.GetFullPath();

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
                var _root = _path?.GetPathRoot();

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
                var name = _path?.GetFileName();

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
                var _extension = _path?.GetFileExtension();

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
                return _fileInfo.Length > 0
                    ? _fileInfo.Length
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
                    _fileInfo?.MoveTo( filePath );
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
                    _fileInfo.CopyTo( filePath );
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
                var file = _path?.GetFullName();

                if( Verify.Input( file )
                    && File.Exists( file ) )
                {
                    File.Delete( file );
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
                return Verify.Input( _fileInfo?.Name ) 
                    && File.Exists( _fileInfo?.FullName )
                        ? _fileInfo
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
                return Verify.Input( _fileInfo?.DirectoryName ) 
                    && Directory.Exists( _fileInfo?.DirectoryName );
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
                return Security;
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
                return _attributes;
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
                return _creationDate;
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
                return _changedDate;
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
                var _file = _path?.GetFullPath();

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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
