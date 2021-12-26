// <copyright file = "IFolder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;

    /// <summary>
    /// 
    /// </summary>
    public interface IFolder
    {
        // ***************************************************************************************************************************
        // ****************************************************    MEMBERS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Creates the sub directory.
        /// </summary>
        /// <param name="folderName">The folderName.</param>
        /// <returns></returns>
        DirectoryInfo CreateSubDirectory( string folderName );

        /// <summary>
        /// Gets the path Data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPath> GetDataPaths();

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IFile> GetDataFiles();

        /// <summary>
        /// Moves the specified fullName.
        /// </summary>
        /// <param name="fullName">The fullName.</param>
        void Move( string fullName );

        /// <summary>
        /// Sets the access control.
        /// </summary>
        /// <param name="security">The security.</param>
        void SetAccessControl( DirectorySecurity security );

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetFolderName();

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <returns></returns>
        string GetFolderPath();

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <returns></returns>
        DateTime GetCreationDate();

        /// <summary>
        /// Gets the changed date.
        /// </summary>
        /// <returns></returns>
        DateTime GetChangedDate();

        /// <summary>
        /// Zips the specified destinationPath.
        /// </summary>
        /// <param name="destinationPath">The destinationPath.</param>
        void Zip( string destinationPath );

        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="zipPath">The zipPath.</param>
        void UnZip( string zipPath );

        /// <summary>
        /// Gets the special folders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetSpecialFolders();

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetFileNames();

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<FileInfo> GetStreamData();

        /// <summary>
        /// Gets the sub folders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DirectoryInfo> GetSubFolders();
    }
}
