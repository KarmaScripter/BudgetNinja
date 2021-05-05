// <copyright file = "FileWriter.cs" company = "Terry D. Eppler">
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
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        public FileWriter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="datafile">The file.</param>
        public FileWriter( IFile datafile )
        {
            DataFile = datafile;
            FileStream = DataFile.GetBaseStream();
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
        private protected FileStream FileStream { get; set; }

        private protected FileInfo FileInfo { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Reads all text.
        /// </summary>
        public void WriteAllText()
        {
            try
            {
                var path = FileInfo.FullName;
                var writer = File.ReadAllText( path );

                if( Verify.Input( path )
                    && Verify.Input( writer ) )
                {
                    File.WriteAllText( FileInfo.FullName, writer );
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
                var file = FileInfo?.FullName;

                if( Verify.Input( file ) )
                {
                    var text = File.ReadAllLines( file );

                    if( text?.Any() == true )
                    {
                        File.WriteAllLines( file, text );
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
                var path = FileInfo?.FullName;

                if( Verify.Input( path ) )
                {
                    var stream = File.ReadAllBytes( path );

                    if( stream?.Any() == true )
                    {
                        File.WriteAllBytes( path, stream );
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
        public void WriteData( ref byte[] data )
        {
            try
            {
                using var filestream = FileInfo?.Create();
                filestream?.Write( data, 0, data.Length );
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
                    using var streamwriter = FileInfo?.AppendText();
                    streamwriter?.Write( text );
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
                var binarydata = File.ReadAllBytes( FileInfo.FullName );

                if( binarydata?.Any() == true )
                {
                    var length = binarydata.Length;
                    using var zipper = new GZipStream( FileStream, CompressionMode.Compress );
                    zipper?.Write( binarydata, 0, length );
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
                var binarydata = File.ReadAllBytes( DataFile.GetFilePath() );

                if( binarydata?.Any() == true )
                {
                    var stream = new MemoryStream( binarydata );
                    stream?.Read( binarydata, 0, binarydata.Length );
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
