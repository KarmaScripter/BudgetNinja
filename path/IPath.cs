// // <copyright file = "IPath.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    public interface IPath
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetFullName();

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns></returns>
        string GetFileName();

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns></returns>
        string GetFileExtension();

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <returns></returns>
        string GetPathRoot();

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <returns></returns>
        string GetFullPath();

        /// <summary>Returns a string that
        /// represents the current object.
        /// </summary>
        /// <returns>A string that represents
        /// the current object.
        /// </returns>
        string ToString();

        string ChangeExtension( string ext );
    }
}
