// <copyright file = "IFile.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;
    using System.Threading;

    public interface IFile
    {
        /// <summary>
        /// Transfers the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        void Transfer( DirectoryInfo folder );

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified search]; otherwise, <c>false</c>.
        /// </returns>
        bool Contains( string search );

        /// <summary>
        /// Searches the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        IEnumerable<FileInfo> Search( string pattern );

        /// <summary>Returns a string that
        /// represents the current object.
        /// </summary>
        /// <returns>A string that represents
        /// the current object.
        /// </returns>
        string ToString();

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetFullName();

        /// <summary>
        /// Gets the data path.
        /// </summary>
        /// <returns></returns>
        IPath GetDataPath();

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns></returns>
        string GetFileExtension();

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <returns></returns>
        string GetFilePath();

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        string GetInput();

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <returns></returns>
        string GetPathRoot();

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns></returns>
        string GetFileName();

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns></returns>
        EXT GetExtension();

        /// <summary>
        /// Gets the length of the file.
        /// </summary>
        /// <returns></returns>
        long GetLength();

        /// <summary>
        /// Moves the specified destination.
        /// </summary>
        /// <param name="filepath">The destination.</param>
        void Move( string filepath );

        /// <summary>
        /// Copies the specified filepath.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        void Copy( string filepath );

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the file information.
        /// </summary>
        /// <returns></returns>
        FileInfo GetFileInfo();

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <returns></returns>
        IFolder GetParentFolder();

        /// <summary>
        /// Gets the file security.
        /// </summary>
        /// <returns></returns>
        FileSecurity GetFileSecurity();

        /// <summary>
        /// Gets the file attributes.
        /// </summary>
        /// <returns></returns>
        FileAttributes GetFileAttributes();

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
        /// Gets the base stream.
        /// </summary>
        /// <returns></returns>
        FileStream GetBaseStream();
    }
}
