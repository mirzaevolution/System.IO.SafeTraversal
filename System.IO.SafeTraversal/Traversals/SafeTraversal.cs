using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    /// <summary>
    /// Core class to perform all traversal operations.
    /// </summary>
    public partial class SafeTraversal
    {
        #region NO_LOGGING_SYNCHRONOUS
        /// <summary>
        /// Traverse files within a path directly (top level only) and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path)
        {
            return PrivateTraverseFiles(path);
        }

        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption)
        {
            return PrivateTraverseFiles(path, searchOption);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return PrivateTraverseFiles(path, searchOption, commonSize);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByName);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileBySize);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileBySizeRange);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByDate);
        }


        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByDateRange);
        }

        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)        {
            return PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
        }

        /// <summary>
        /// Traverse files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOption' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return PrivateTraverseFiles(path, searchOption, fileSearchOptions);
        }


        /// <summary>
        /// Traverse files within a path securely. It'll scan top level directory only.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking)
        {
            return PrivateTraverseFiles(path,fileSafetyChecking);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            return PrivateTraverseFiles(path,fileSafetyChecking, searchOption);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, commonSize);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return PrivateTraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions);
        }

        /// <summary>
        /// Traverse top level directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path)
        {
            return PrivateTraverseDirs(path);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption)
        {
            return PrivateTraverseDirs(path, searchOption);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="attributes">Search directories based on certain FileAttributes enumeration.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return PrivateTraverseDirs(path, searchOption, attributes);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="date">Search directories by specified date (Date Only).</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return PrivateTraverseDirs(path, searchOption, date,dateComparisonType);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByName">Search directories by name.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByName' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return PrivateTraverseDirs(path, searchOption, searchDirectoryByName);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByRegularExpressionPattern">Search directories by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByRegularExpressionPattern' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern);
        }
        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="directorySearchOptions">Composite option. Used for multiple search criteria.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'directorySearchOptions' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return PrivateTraverseDirs(path, searchOption, directorySearchOptions);
        }
        #endregion

        #region WITH_LOGGING_SYNCHRONOUS
        /// <summary>
        /// Traverse files within a top level path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, commonSize, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByName, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySize, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySizeRange, out errorLog);
        }


        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDate, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDateRange, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, fileSearchOptions, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely. It'll scan top level directory only.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, commonSize, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileByName, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileBySize, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileBySizeRange, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileByDate, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileByDateRange, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }

        /// <summary>
        /// Traverse files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, fileSafetyChecking, searchOption, fileSearchOptions, out errorLog);
        }

        /// <summary>
        /// Traverse top level directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="attributes">Search directories based on certain FileAttributes enumeration.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, attributes, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="date">Search directories by specified date (Date Only).</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, date, dateComparisonType, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByName">Search directories by name.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByName' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByName, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByRegularExpressionPattern">Search directories by using .NET regular expression pattern.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByRegularExpressionPattern' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="directorySearchOptions">Composite option. Used for multiple search criteria.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'directorySearchOptions' is null.</exception>
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, directorySearchOptions, out errorLog);
        }
        #endregion

        #region NO_LOGGING_ASYNCHRONOUS
        /// <summary>
        /// Traverse files within a path (top level only) asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path)
        {
            
            return Task.Run(() => PrivateTraverseFiles(path));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(()=> PrivateTraverseFiles(path, searchOption));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, commonSize));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByName));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileBySize));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileBySizeRange));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByDate));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByDateRange));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, fileSearchOptions));
        }


        /// <summary>
        /// Traverse files within a path asynchronously and securely. It'll scan top level directory only.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking,SearchOption searchOption)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, commonSize));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize));
        }


        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern));
        }

        /// <summary>
        /// Traverse files within a path asynchronously and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. Specifying file safety checking to true will filter all files that are totally
        /// safe for IO operations but will take more time to complete.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="fileSafetyChecking">True to filter files that are totally safe for IO Operations (Slower). Otherwise false (Faster).</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => PrivateTraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions));
        }


        /// <summary>
        /// Traverse top level directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path)
        {
            return Task.Run(() => PrivateTraverseDirs(path));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="attributes">Search directories based on certain FileAttributes enumeration.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, attributes));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="date">Search directories by specified date (Date Only).</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, date, dateComparisonType));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByName">Search directories by name.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByName' is null.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, searchDirectoryByName));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByRegularExpressionPattern">Search directories by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByRegularExpressionPattern' is null.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return Task.Run(()=> PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="directorySearchOptions">Composite option. Used for multiple search criteria.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'directorySearchOptions' is null.</exception>
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return Task.Run(()=> PrivateTraverseDirs(path, searchOption, directorySearchOptions));
        }

        #endregion


        #region STATIC_NO_LOGGING

        /// <summary>
        /// Get files within a path (top level directory only) securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path)
        {
           return new SafeTraversal().PrivateTraverseFiles(path);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, commonSize);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByName);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileBySize);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileBySizeRange);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByDate);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByDateRange);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
        }

        /// <summary>
        /// Get files within a path securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, fileSearchOptions);
        }

        /// <summary>
        /// Get top level directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path)
        {
            return new SafeTraversal().PrivateTraverseDirs(path);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="attributes">Search directories based on certain FileAttributes enumeration.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, FileAttributes attributes)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, attributes);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="date">Search directories by specified date (Date Only).</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, date, dateComparisonType);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByName">Search directories by name.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByName' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, searchDirectoryByName);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByRegularExpressionPattern">Search directories by using .NET regular expression pattern.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByRegularExpressionPattern' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="directorySearchOptions">Composite option. Used for multiple search criteria.</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'directorySearchOptions' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, directorySearchOptions);
        }
        #endregion

        #region STATIC_WITH_LOGGING
        /// <summary>
        /// Get files within a path (top level directory only) securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="commonSize">A windows explorer-like size scanning option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, commonSize, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByName">Search files by filename.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByName' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByName, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySize">Search files by specified size.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySize' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySize, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileBySizeRange">Search files by certain size range.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileBySizeRange' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySizeRange, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDate">Search files by specified date option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDate' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDate, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByDateRange">Search files by certain date range option.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByDateRange' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDateRange, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchFileByRegularExpressionPattern">Search files by using .NET regular expression pattern.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchFileByRegularExpressionPattern' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }

        /// <summary>
        /// Get files within a path securely. 
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="fileSearchOptions">Composite option for multiple search criteria.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'fileSearchOptions' is null.</exception>
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, fileSearchOptions, out errorLog);
        }

        /// <summary>
        /// Get top level directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="attributes">Search directories based on certain FileAttributes enumeration.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, attributes, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="date">Search directories by specified date (Date Only).</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, date, dateComparisonType, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByName">Search directories by name.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByName' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByName, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="searchDirectoryByRegularExpressionPattern">Search directories by using .NET regular expression pattern.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'searchDirectoryByRegularExpressionPattern' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
        }

        /// <summary>
        /// Get directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process. It also supports error log to inspect any error occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <param name="directorySearchOptions">Composite option. Used for multiple search criteria.</param>
        /// <param name="errorLog">Supply error log as list of string to log any error during scanning process</param>
        /// <returns>IEnumerable of string object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">'directorySearchOptions' is null.</exception>
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, directorySearchOptions, out errorLog);
        }
        #endregion

        #region SAFE_FILE_CHECKER
        /// <summary>
        /// Safe file is a file that doesn't have Deny Access Control Type. 
        /// If a file returns true when being checked, then that file is ready
        /// for IO operation. Or at least Open Read operation.
        /// </summary>
        /// <param name="filename">Filename.</param>
        /// <returns>True/False regarding file's state. True means file is ready for IO operation. Otherwise false.</returns>
        public static bool IsSafeFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"{filename} doesn't exist");
            FileSecurity accessControl = File.GetAccessControl(filename);
            AuthorizationRuleCollection authorizationRules = accessControl.GetAccessRules(true, true, typeof(NTAccount));
            if (authorizationRules.Count == 0)
                return false;
            bool safe = true;
            int length = authorizationRules.Count;
            for(int i=0;i<length;i++)
            {
                FileSystemAccessRule fileSystemAccessRule = (FileSystemAccessRule)authorizationRules[i];
                if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
                {
                    safe = false;
                    break;
                }
            }
            return safe;
        }
        /// <summary>
        /// Safe file is a file that doesn't have Deny Access Control Type. 
        /// If a file returns true when being checked, then that file is ready
        /// for IO operation. Or at least Open Read operation.
        /// </summary>
        /// <param name="fileInfo">Filename in FileInfo type.</param>
        /// <returns>True/False regarding file's state. True means file is ready for IO operation. Otherwise false.</returns>
        public bool IsSafeFile(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                throw new FileNotFoundException($"{fileInfo.FullName} doesn't exist");
            FileSecurity accessControl = fileInfo.GetAccessControl();
            AuthorizationRuleCollection authorizationRules = accessControl.GetAccessRules(true, true, typeof(NTAccount));
            if (authorizationRules.Count == 0)
                return false;
            bool safe = true;
            int length = authorizationRules.Count;
            for (int i = 0; i < length; i++)
            {
                FileSystemAccessRule fileSystemAccessRule = (FileSystemAccessRule)authorizationRules[i];
                if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
                {
                    safe = false;
                    break;
                }
            }
            return safe;
        }
        #endregion
    }
}

