using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    public static class DirectoryInfoExtensions
    {
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
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path)
        {
            return new SafeTraversal().TraverseFiles(path);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, commonSize);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions);
        }

        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions);
        }


        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path)
        {
            
            return new SafeTraversal().TraverseDirectories(path);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, attributes);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions);
        }
        #endregion

        #region WITH_LOGGING_SYNCHRONOUS
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, out List<string> errorLog)
        {
            
            return new SafeTraversal().TraverseFiles(path, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, commonSize, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions, out errorLog);
        }

        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern, out errorLog);
        }
        public static IEnumerable<FileInfo> TraverseFiles(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions, out errorLog);
        }


        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, attributes, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern, out errorLog);
        }
        public static IEnumerable<DirectoryInfo> TraverseDirectories(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            return new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions, out errorLog);
        }
        #endregion

        #region NO_LOGGING_ASYNCHRONOUS
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path)
        {

            return Task.Run(() => new SafeTraversal().TraverseFiles(path));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, commonSize));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByName));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySize));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileBySizeRange));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDate));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByDateRange));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, searchFileByRegularExpressionPattern));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, searchOption, fileSearchOptions));
        }

        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, commonSize));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByName));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySize));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileBySizeRange));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDate));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByDateRange));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, searchFileByRegularExpressionPattern));
        }
        public static Task<IEnumerable<FileInfo>> TraverseFilesAsync(this DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseFiles(path, fileSafetyChecking, searchOption, fileSearchOptions));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, attributes));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, date, dateComparisonType));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByName));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, searchDirectoryByRegularExpressionPattern));
        }
        public static Task<IEnumerable<DirectoryInfo>> TraverseDirectoriesAsync(this DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            return Task.Run(() => new SafeTraversal().TraverseDirectories(path, searchOption, directorySearchOptions));
        }

        #endregion
    }
}
