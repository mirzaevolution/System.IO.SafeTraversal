using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    /// <summary>
    /// Core class to perform all traversal operations within DirectoryInfo class.
    /// </summary>
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// Find all parents all the way up to root (ie: C:\ or D:\) from current path.
        /// </summary>
        /// <param name="path">Valid path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo representing all parents. Null if current path is a root.</returns>
        public static IEnumerable<DirectoryInfo> FindParents(this DirectoryInfo path)
        {
            
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            while (path.Parent != null)
            {
                yield return new DirectoryInfo(path.Parent.Name);
                path = path.Parent;
            }
        }

        #region NO_LOGGING_SYNCHRONOUS
        /// <summary>
        /// Traverse files within a path directly (top level only) and securely.
        /// No exception will be thrown if scanner hits unauthorized access path/folder or other errors occured
        /// during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of FileInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path)
        {
            return new SafeTraversal().TraverseFiles(path);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, commonSize);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions);
        }

        /// <summary>
        /// Traverse top level directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path)
        {
            
            return new SafeTraversal().TraverseDirectories(path);
        }

        /// <summary>
        /// Traverse directories securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, attributes);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, out List<string> errorLog)
        {
            
            return new SafeTraversal().TraverseFiles(path, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, commonSize, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern, out errorLog);
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, attributes, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
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
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions, out errorLog);
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, commonSize));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern));
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
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions));
        }

        /// <summary>
        /// Traverse top level directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path));
        }

        /// <summary>
        /// Traverse directories asynchronously and securely. No exception will be thrown when hits unauthorized 
        /// access path/folder or other errors occured during scanning process.
        /// </summary>
        /// <param name="path">Target path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <param name="searchOption">Scanning scope. Specifying All directories will scan entire sub directories also.</param>
        /// <returns>IEnumerable of DirectoryInfo object. Empty if path being passed in is an unauthorized path.</returns>
        /// <exception cref="DirectoryNotFoundException">'path' doesn't exist.</exception>
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption));
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
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, attributes));
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
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType));
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
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName));
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
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern));
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
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions));
        }

        #endregion
    }
}
