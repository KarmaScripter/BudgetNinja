// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class FileReader
    {
        /// <summary>
        /// The data file
        /// </summary>
        private protected readonly IFile _dataFile;

        /// <summary>
        /// The file information
        /// </summary>
        private protected readonly FileInfo _fileInfo;

        /// <summary>
        /// The file stream
        /// </summary>
        private protected FileStream _fileStream;

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
            _dataFile = file;
            _fileInfo = _dataFile.GetFileInfo();
        }

        /// <summary>
        /// Reads all text.
        /// </summary>
        /// <returns></returns>
        public string ReadAllText()
        {
            try
            {
                var _file = _fileInfo?.FullName;

                if( _file != null )
                {
                    var _stream = File.ReadAllText( _file );

                    return Verify.Input( _stream )
                        ? _stream
                        : string.Empty;
                }

                return string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Reads all lines.
        /// </summary>
        /// <returns></returns>
        public string[ ] ReadAllLines()
        {
            try
            {
                var _file = _fileInfo?.FullName;

                if( _file != null )
                {
                    var _stream = File.ReadAllLines( _file );

                    return _stream?.Any() == true
                        ? _stream
                        : default( string[ ] );
                }

                return default( string[ ] );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Reads all bytes.
        /// </summary>
        /// <returns></returns>
        public byte[ ] ReadAllBytes()
        {
            try
            {
                var _file = _fileInfo?.FullName;

                if( Verify.Input( _file ) )
                {
                    var _stream = File.ReadAllBytes( _file );

                    return _stream?.Any() == true
                        ? _stream
                        : default( byte[ ] );
                }

                return default( byte[ ] );
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default( byte[ ] );
            }
        }

        /// <summary>
        /// Reads to end.
        /// </summary>
        /// <returns></returns>
        public string ReadToEnd()
        {
            try
            {
                using var _reader = _fileInfo?.OpenText();
                var _result = _reader?.ReadToEnd();

                return Verify.Input( _result )
                    ? _result
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
                var _bytes = File.ReadAllBytes( _fileInfo.FullName );
                var _length = _bytes.Length;
                using var _stream = new GZipStream( _fileStream, CompressionMode.Decompress );
                _stream?.Read( _bytes, 0, _length );
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
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}