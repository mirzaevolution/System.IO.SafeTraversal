using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    public partial class SafeTraversal
    {
        #region NO_LOGGING_SYNCHRONOUS
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path)
        {
            return PrivateTraverseFiles(path);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption)
        {
            return PrivateTraverseFiles(path, searchOption);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return PrivateTraverseFiles(path, searchOption, commonSize);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByName);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileBySize);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByRange);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByDate);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return PrivateTraverseFiles(path, searchOption, searchFileByDateRange);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)        {
            return PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return PrivateTraverseFiles(path, searchOption, fileSearchOptions);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path)
        {
            return PrivateTraverseDirs(path);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption)
        {
            return PrivateTraverseDirs(path, searchOption);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return PrivateTraverseDirs(path, searchOption, attributes);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return PrivateTraverseDirs(path, searchOption, date,dateComparisonType);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return PrivateTraverseDirs(path, searchOption, searchDirectoryByName);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return PrivateTraverseDirs(path, searchOption, directorySearchOptions);
        }
        #endregion

        #region WITH_LOGGING_SYNCHRONOUS
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, commonSize, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByName, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySize, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRange, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDate, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDateRange, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }
        public IEnumerable<FileInfo> TraverseFiles(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return PrivateTraverseFilesWithLogging(path, searchOption, fileSearchOptions, out errorLog);
        }

        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, attributes, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, date, dateComparisonType, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByName, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
        }
        public IEnumerable<DirectoryInfo> TraverseDirectories(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return PrivateTraverseDirsWithLogging(path, searchOption, directorySearchOptions, out errorLog);
        }
        #endregion

        #region NO_LOGGING_ASYNCHRONOUS
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path)
        {
            return Task.Run(() => PrivateTraverseFiles(path));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(()=> PrivateTraverseFiles(path, searchOption));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, commonSize));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByName));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileBySize));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByRange));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByDate));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByDateRange));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern));
        }
        public Task<IEnumerable<FileInfo>> TraverseFilesAsync(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => PrivateTraverseFiles(path, searchOption, fileSearchOptions));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path)
        {
            return Task.Run(() => PrivateTraverseDirs(path));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, attributes));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, date, dateComparisonType));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return Task.Run(() => PrivateTraverseDirs(path, searchOption, searchDirectoryByName));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return Task.Run(()=> PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern));
        }
        public Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return Task.Run(()=> PrivateTraverseDirs(path, searchOption, directorySearchOptions));
        }

        #endregion


        #region STATIC_NO_LOGGING
        public static IEnumerable<string> GetFiles(string path)
        {
           return new SafeTraversal().PrivateTraverseFiles(path);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, commonSize);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByName);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileBySize);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByRange);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByDate);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByDateRange);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().PrivateTraverseFiles(path, searchOption, fileSearchOptions);
        }

        public static IEnumerable<string> GetDirectories(string path)
        {
            return new SafeTraversal().PrivateTraverseDirs(path);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, FileAttributes attributes)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, attributes);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, date, dateComparisonType);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, searchDirectoryByName);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, searchDirectoryByRegularExpressionPattern);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return new SafeTraversal().PrivateTraverseDirs(path, searchOption, directorySearchOptions);
        }
        #endregion

        #region STATIC_WITH_LOGGING
        public static IEnumerable<string> GetFiles(string path, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, commonSize, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByName, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileBySize, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRange, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDate, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByDateRange, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }
        public static IEnumerable<string> GetFiles(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseFilesWithLogging(path, searchOption, fileSearchOptions, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, attributes, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, date, dateComparisonType, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByName, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
        }
        public static IEnumerable<string> GetDirectories(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().PrivateTraverseDirsWithLogging(path, searchOption, directorySearchOptions, out errorLog);
        }
        #endregion
    }
}

