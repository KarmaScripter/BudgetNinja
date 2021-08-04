// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.IPath" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class DataPath : IPath
    {
        /// <summary>The full name</summary>
        private protected readonly string _fullName;

        /// <summary>The file name</summary>
        private protected readonly string _fileName;

        /// <summary>The full path</summary>
        private protected readonly string _fullPath;

        /// <summary>The file extension</summary>
        private protected readonly string _fileExtension;

        /// <summary>The path root</summary>
        private protected readonly string _pathRoot;

        /// <summary>The input</summary>
        private protected readonly string _input;

        /// <summary>The current directory</summary>
        readonly public static string CurrentDirectory = Directory.GetCurrentDirectory();

        /// <summary>The base directory</summary>
        readonly public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>The connection string</summary>
        readonly public static ConnectionStringSettingsCollection ConnectionString =
            ConfigurationManager.ConnectionStrings;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPath"/> class.
        /// </summary>
        public DataPath()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPath"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public DataPath( string input )
        {
            _input = input;
            _fullName = Path.GetFileNameWithoutExtension( _input );
            _fileName = Path.GetFileName( _input );
            _fullPath = Path.GetFullPath( _input );
            _fileExtension = Path.GetExtension( _input );
            _pathRoot = Path.GetPathRoot( _input );
        }
        
        /// <summary>Gets the name.</summary>
        /// <returns></returns>
        public string GetFullName()
        {
            try
            {
                return Verify.Input( _fullName )
                    ? _fullName
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>Gets the name of the file.</summary>
        /// <returns></returns>
        public string GetFileName()
        {
            try
            {
                return Verify.Input( _fileName )
                    ? _fileName
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>Gets the extension.</summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            try
            {
                return Verify.Input( _fileExtension )
                    ? _fileExtension
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>Gets the root.</summary>
        /// <returns></returns>
        public string GetPathRoot()
        {
            try
            {
                return Verify.Input( _pathRoot )
                    ? _pathRoot
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>Gets the full path.</summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            try
            {
                return Verify.Input( _fullPath )
                    ? _fullPath
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>Changes the extension.</summary>
        /// <param name="ext">The ext.</param>
        /// <returns></returns>
        public string ChangeExtension( string ext )
        {
            try
            {
                return Verify.Input( ext ) && Enum.GetNames( typeof( EXT ) ).Contains( ext )
                    ? Path.ChangeExtension( _fullPath, ext )
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>Combines the specified first.</summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static string Combine( string first, string second )
        {
            try
            {
                return Verify.Input( first ) && Verify.Input( second )
                    ? Path.Combine( first, second )
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( _fullPath )
                    ? _fullPath
                    : string.Empty;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>Fails the specified ex.</summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}