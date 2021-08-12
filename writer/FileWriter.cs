// <copyright file = "FileWriter.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class FileWriter
    {
        /// <summary>
        /// The file
        /// </summary>
        private protected readonly IFile _dataFile;
        
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        private protected readonly FileStream _fileStream;

        /// <summary>
        /// The file information
        /// </summary>
        private protected readonly FileInfo _fileInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        public FileWriter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        public FileWriter( IFile file )
        {
            _dataFile = file;
            _fileStream = _dataFile.GetBaseStream();
            _fileInfo = _dataFile.GetFileInfo();
        }

        /// <summary>
        /// Reads all text.
        /// </summary>
        public void WriteAllText()
        {
            try
            {
                var _path = _fileInfo.FullName;
                var _writer = File.ReadAllText( _path );

                if( Verify.Input( _path )
                    && Verify.Input( _writer ) )
                {
                    File.WriteAllText( _fileInfo.FullName, _writer );
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Reads all lines.
        /// </summary>
        public void WriteAllLines()
        {
            try
            {
                var _file = _fileInfo?.FullName;

                if( Verify.Input( _file ) )
                {
                    var text = File.ReadAllLines( _file );

                    if( text?.Any() == true )
                    {
                        File.WriteAllLines( _file, text );
                    }
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Reads all bytes.
        /// </summary>
        public void WriteAllBytes()
        {
            try
            {
                var _path = _fileInfo?.FullName;

                if( Verify.Input( _path ) )
                {
                    var stream = File.ReadAllBytes( _path );

                    if( stream?.Any() == true )
                    {
                        File.WriteAllBytes( _path, stream );
                    }
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Overwrites the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public static void Overwrite( string source, string destination )
        {
            if( Verify.Input( source )
                && Verify.Input( destination ) )
            {
                if( File.Exists( destination ) )
                {
                    File.Delete( destination );
                }

                try
                {
                    File.Move( source, destination );
                }
                catch( IOException ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Writes the binary.
        /// </summary>
        /// <param name="data">The data.</param>
        public void WriteData( ref byte[ ] data )
        {
            try
            {
                using var _stream = _fileInfo?.Create();
                _stream?.Write( data, 0, data.Length );
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Appends the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void AppendText( string text )
        {
            if( Verify.Input( text ) )
            {
                try
                {
                    using var _writer = _fileInfo?.AppendText();
                    _writer?.Write( text );
                }
                catch( IOException ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Compresses this instance.
        /// </summary>
        public void Compress()
        {
            try
            {
                var _bytes = File.ReadAllBytes( _fileInfo.FullName );

                if( _bytes?.Any() == true )
                {
                    var _length = _bytes.Length;
                    using var _stream = new GZipStream( _fileStream, CompressionMode.Compress );
                    _stream?.Write( _bytes, 0, _length );
                }
            }
            catch( IOException ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the memory stream.
        /// </summary>
        /// <returns></returns>
        public void WriteToMemory()
        {
            try
            {
                var _bytes = File.ReadAllBytes( _dataFile.GetFilePath() );

                if( _bytes?.Any() == true )
                {
                    var _stream = new MemoryStream( _bytes );
                    _stream?.Read( _bytes, 0, _bytes.Length );
                }
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
