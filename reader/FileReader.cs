// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class FileReader
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The file
        /// </summary>
        private readonly IFile DataFile;

        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        public FileReader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        public FileReader( IFile file )
        {
            DataFile = file;
            FileInfo = DataFile.GetFileInfo();
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets the file stream.
        /// </summary>
        /// <value>
        /// The file stream.
        /// </value>
        private protected FileStream FileStream { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Reads all text.
        /// </summary>
        /// <returns></returns>
        public string ReadAllText()
        {
            try
            {
                var file = FileInfo?.FullName;

                if( file != null )
                {
                    var stream = File.ReadAllText( file );

                    return Verify.Input( stream )
                        ? stream
                        : string.Empty;
                }

                return string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Reads all lines.
        /// </summary>
        /// <returns></returns>
        public string[] ReadAllLines()
        {
            try
            {
                var file = FileInfo?.FullName;

                if( file != null )
                {
                    var stream = File.ReadAllLines( file );

                    return stream?.Any() == true
                        ? stream
                        : default;
                }

                return default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Reads all bytes.
        /// </summary>
        /// <returns></returns>
        public byte[] ReadAllBytes()
        {
            try
            {
                var file = FileInfo?.FullName;

                if( Verify.Input( file ) )
                {
                    var stream = File.ReadAllBytes( file );

                    return stream?.Any() == true
                        ? stream
                        : default;
                }

                return default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns></returns>
        public string ReadToEnd()
        {
            try
            {
                using var streamreader = FileInfo?.OpenText();
                var result = streamreader?.ReadToEnd();

                return Verify.Input( result )
                    ? result
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Des the compress.
        /// </summary>
        public void DeCompress()
        {
            try
            {
                var binarydata = File.ReadAllBytes( FileInfo.FullName );
                var length = binarydata.Length;
                using var zipper = new GZipStream( FileStream, CompressionMode.Decompress );
                zipper?.Read( binarydata, 0, length );
            }
            catch( IOException ex )
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
            using var error = new StaticError( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}