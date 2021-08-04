// <copyright file = "FileBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

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
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

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
        private protected string FileName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        private protected string FullName { get; set; }

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        private protected DateTime ChangedDate { get; set; }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        private protected FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has parent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has parent; otherwise, <c>false</c>.
        /// </value>
        public bool HasParent { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        private protected DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the lengeth.
        /// </summary>
        /// <value>
        /// The lengeth.
        /// </value>
        private protected long Length { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        private protected FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        private protected FileSecurity Security { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            var input = _path?.GetFullPath();

            if( Verify.Input( input ) )
            {
                try
                {
                    return File.Exists( input )
                        ? input
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
                var root = _path?.GetPathRoot();

                return Verify.Input( root )
                    ? root
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
                var ext = _path?.GetFileExtension();

                return Verify.Input( ext )
                    ? (EXT)Enum.Parse( typeof( EXT ), ext )
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
        /// <param name="filepath">The destination.</param>
        public void Move( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    FileInfo?.MoveTo( filepath );
                }
                catch( IOException ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Copies the specified filepath.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public void Copy( string filepath )
        {
            try
            {
                if( Verify.Input( filepath )
                    && !File.Exists( filepath ) )
                {
                    FileInfo.CopyTo( filepath );
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
                return Verify.Input( FileInfo?.Name ) && File.Exists( FileInfo?.FullName )
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
                return Verify.Input( FileInfo?.DirectoryName ) && Directory.Exists( FileInfo?.DirectoryName );
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
                return Attributes;
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
                return CreationDate;
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
                return ChangedDate;
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
                var file = _path?.GetFullPath();

                return Verify.Input( file ) && File.Exists( file )
                    ? new FileInfo( file )?.Create()
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
