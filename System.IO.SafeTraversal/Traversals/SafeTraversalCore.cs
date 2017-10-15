using System.Collections.Generic;
using System.Linq;

namespace System.IO.SafeTraversal
{
    public partial class SafeTraversal
    {

        #region NO_LOGGING
        private void TraverseFilesCoreNoLogging(DirectoryInfo directoryInfo,
                                                 List<FileInfo> files,
                                                 SearchOption searchOption,
                                                 Func<FileInfo, bool> filter)
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {

                                if (filter(fileInfos[i]))
                                    files.Add(fileInfos[i]);
                            }
                        }
                        else
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for (long i = 0; i < length; i++)
                            {
                                files.Add(fileInfos[i]);
                            }

                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {
                                    if (filter(fileInfos[i]))
                                    {
                                        files.Add(fileInfos[i]);
                                    }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for (long i = 0; i < length; i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {

                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {

                                    files.Add(fileInfos[i]);
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for(long i=0;i<length;i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    break;
            }
        }
        private void TraverseFilesCoreNoLoggingSafe(DirectoryInfo directoryInfo,
                                                 List<FileInfo> files,
                                                 SearchOption searchOption,
                                                 Func<FileInfo, bool> filter)
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {
                                if (IsSafeFile(fileInfos[i]))
                                {
                                    if (filter(fileInfos[i]))
                                        files.Add(fileInfos[i]);
                                }
                            }
                        }
                        else
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {
                                if (IsSafeFile(fileInfos[i]))
                                {
                                    files.Add(fileInfos[i]);
                                }
                            }

                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {

                                    if (IsSafeFile(fileInfos[i]))
                                    {
                                        if (filter(fileInfos[i]))
                                            files.Add(fileInfos[i]);
                                    }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                try
                                {
                                   
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for (long i = 0; i < length; i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for (long i = 0; i < length; i++)
                                {
                                    if (IsSafeFile(fileInfos[i]))
                                    {
                                        files.Add(fileInfos[i]);
                                    }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for (long i = 0; i < length; i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    break;
            }
        }
        private void TraverseDirectoriesCoreNoLogging(DirectoryInfo directoryInfo,
                                                       List<DirectoryInfo> directories,
                                                       SearchOption searchOption,
                                                       Func<DirectoryInfo, bool> filter)
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:

                    if (filter != null)
                    {
                        try
                        {

                            DirectoryInfo[] dirInfos = directoryInfo.GetDirectories();
                            long length = dirInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {

                                if (filter(dirInfos[i]))
                                    directories.Add(dirInfos[i]);
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            DirectoryInfo[] dirInfos = directoryInfo.GetDirectories();
                            long length = dirInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {
                                directories.Add(dirInfos[i]);
                            }
                        }
                        catch { }
                    }
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            if (filter(currentDirectoryInfo))
                                directories.Add(currentDirectoryInfo);
                            try
                            {
                                DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                long length = subDirInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            directories.Add(currentDirectoryInfo);
                            try
                            {
                                DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                long length = subDirInfos.LongLength;
                                for (long i = 0; i < length; i++)
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                }
                            }
                            catch { }
                        }
                    }
                    break;
            }
        }
        //for files - unsafe
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreNoLogging(path, files, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreNoLogging(path, files, searchOption, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            StringComparison stringComparison = searchFileByName.CaseSensitive ?
                StringComparison.InvariantCulture :
                StringComparison.InvariantCultureIgnoreCase;

            if (searchFileByName.IncludeExtension)
                filter = (fileInfo) => MatchByNameWithExtension(fileInfo, searchFileByName.Name, stringComparison);
            else
                filter = (fileInfo) => MatchByName(fileInfo, searchFileByName.Name, stringComparison);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySizeRange == null)
                throw new ArgumentNullException(nameof(searchFileBySizeRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileBySizeRange.LowerBoundSize, searchFileBySizeRange.UpperBoundSize, searchFileBySizeRange.SizeType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            if (searchFileByRegularExpressionPattern.IncludeExtension)
                filter = (fileInfo) => MatchByPatternWithExtension(fileInfo, searchFileByRegularExpressionPattern.Pattern);
            else
                filter = (fileInfo) => MatchByPattern(fileInfo, searchFileByRegularExpressionPattern.Pattern);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }

        //for files - safe
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            if (fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, SearchOption.TopDirectoryOnly, null);
            else
                TraverseFilesCoreNoLogging(path, files, SearchOption.TopDirectoryOnly, null);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, null);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            StringComparison stringComparison = searchFileByName.CaseSensitive ?
                StringComparison.InvariantCulture :
                StringComparison.InvariantCultureIgnoreCase;

            if (searchFileByName.IncludeExtension)
                filter = (fileInfo) => MatchByNameWithExtension(fileInfo, searchFileByName.Name, stringComparison);
            else
                filter = (fileInfo) => MatchByName(fileInfo, searchFileByName.Name, stringComparison);
            if (fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRange == null)
                throw new ArgumentNullException(nameof(searchFileByRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileByRange.LowerBoundSize, searchFileByRange.UpperBoundSize, searchFileByRange.SizeType);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            if (searchFileByRegularExpressionPattern.IncludeExtension)
                filter = (fileInfo) => MatchByPatternWithExtension(fileInfo, searchFileByRegularExpressionPattern.Pattern);
            else
                filter = (fileInfo) => MatchByPattern(fileInfo, searchFileByRegularExpressionPattern.Pattern);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            if(fileSafetyChecking)
                TraverseFilesCoreNoLoggingSafe(path, files, searchOption, filter);
            else
                TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }


        //for dirs
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreNoLogging(path, dirs, SearchOption.TopDirectoryOnly, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByAttributes(dirInfo, attributes);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByDate(dirInfo, date, dateComparisonType);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByName == null)
                throw new ArgumentNullException(nameof(searchDirectoryByName));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            StringComparison stringComparison = searchDirectoryByName.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByName(dirInfo, searchDirectoryByName.Name, stringComparison);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchDirectoryByRegularExpressionPattern));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByPattern(dirInfo, searchDirectoryByRegularExpressionPattern.Pattern);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (directorySearchOptions == null)
                throw new ArgumentNullException(nameof(directorySearchOptions));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => TranslateDirOptions(dirInfo, directorySearchOptions);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }

        #endregion

        #region WITH_LOGGING
        private void TraverseFilesCoreWithLogging(DirectoryInfo directoryInfo,
                                           List<FileInfo> files,
                                           List<string> errors,
                                           SearchOption searchOption,
                                           Func<FileInfo, bool> filter)
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    if (filter != null)
                    {
                        try
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.Length;
                            for(long i=0; i<length; i++)
                            {
                                if (filter(fileInfos[i]))
                                    files.Add(fileInfos[i]);
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }
                    else
                    {
                        try
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.Length;
                            for (long i = 0; i < length; i++)
                            {
                                files.Add(fileInfos[i]);
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }

                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {
                                    if (filter(fileInfos[i]))
                                    {
                                        files.Add(fileInfos[i]);
                                    }
                                }
                                scanSubDir = true;
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for(long i=0;i<length;i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch (UnauthorizedAccessException ex)
                                {
                                    scanSubDir = false;
                                    errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                                }
                                catch (Exception ex)
                                {
                                    scanSubDir = false;
                                    errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                                }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {

                                    files.Add(fileInfos[i]);
                                }
                                scanSubDir = true;
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for(long i=0;i<length;i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch (UnauthorizedAccessException ex)
                                {

                                    errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                                }
                                catch (Exception ex)
                                {
                                    errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                                }
                            }
                        }
                    }
                    break;
            }



        }

        private void TraverseFilesCoreWithLoggingSafe(DirectoryInfo directoryInfo,
                                          List<FileInfo> files,
                                          List<string> errors,
                                          SearchOption searchOption,
                                          Func<FileInfo, bool> filter)
        {
            
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    if (filter != null)
                    {
                        try
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for(long i=0;i<length; i++)
                            {
                                if (IsSafeFile(fileInfos[i]))
                                {
                                    if (filter(fileInfos[i]))
                                        files.Add(fileInfos[i]);
                                }
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }
                    else
                    {
                        try
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();
                            long length = fileInfos.LongLength;
                            for (long i = 0; i < length; i++)
                            {
                                if(IsSafeFile(fileInfos[i]))
                                    files.Add(fileInfos[i]);
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }

                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for (long i = 0; i < length; i++)
                                {
                                    if (IsSafeFile(fileInfos[i]))
                                    {
                                        if (filter(fileInfos[i]))
                                            files.Add(fileInfos[i]);
                                    }
                                }
                                scanSubDir = true;
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for(long i=0;i<length;i++) 
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch (UnauthorizedAccessException ex)
                                {
                                    scanSubDir = false;
                                    errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                                }
                                catch (Exception ex)
                                {
                                    scanSubDir = false;
                                    errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                                }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                FileInfo[] fileInfos = currentDirectoryInfo.GetFiles();
                                long length = fileInfos.LongLength;
                                for (long i = 0; i < length; i++)
                                {
                                    if(IsSafeFile(fileInfos[i]))
                                        files.Add(fileInfos[i]);
                                }
                                scanSubDir = true;
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                scanSubDir = false;
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                            if (scanSubDir)
                            {
                                try
                                {
                                    DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                    long length = subDirInfos.LongLength;
                                    for (long i = 0; i < length; i++)
                                    {
                                        queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                    }
                                }
                                catch (UnauthorizedAccessException ex)
                                {

                                    errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                                }
                                catch (Exception ex)
                                {
                                    errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                                }
                            }
                        }
                    }
                    break;
            }



        }

        private void TraverseDirectoriesCoreWithLogging(DirectoryInfo directoryInfo,
                                                       List<DirectoryInfo> directories,
                                                       List<string> errors,
                                                       SearchOption searchOption,
                                                       Func<DirectoryInfo, bool> filter)
        {

            
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    if (filter != null)
                    {
                        try
                        {
                            DirectoryInfo[] dirInfos = directoryInfo.GetDirectories();
                            long length = dirInfos.LongLength;
                            for(long i=0;i<length;i++)
                            {
                                if (filter(dirInfos[i]))
                                    directories.Add(dirInfos[i]);
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {

                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }
                    else
                    {
                        try
                        {
                            DirectoryInfo[] dirInfos = directoryInfo.GetDirectories();
                            long length = dirInfos.LongLength;
                            for (long i = 0; i < length; i++)
                            {
                                directories.Add(dirInfos[i]);
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {

                            errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                        }
                    }

                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            if (filter(currentDirectoryInfo))
                                directories.Add(currentDirectoryInfo);

                            try
                            {
                                DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                long length = subDirInfos.LongLength;
                                for(long i=0;i<length;i++)
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                }
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            directories.Add(currentDirectoryInfo);
                            try
                            {
                                DirectoryInfo[] subDirInfos = currentDirectoryInfo.GetDirectories();
                                long length = subDirInfos.LongLength;
                                for (long i = 0; i < length; i++)
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfos[i]);
                                }
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }
                        }
                    }
                    break;
            }
        }


        //for files - unsafe
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, out List<string> errorLog)
        {

            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreWithLogging(path, files, errorLog, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            StringComparison stringComparison = searchFileByName.CaseSensitive ?
                StringComparison.InvariantCulture :
                StringComparison.InvariantCultureIgnoreCase;

            if (searchFileByName.IncludeExtension)
                filter = (fileInfo) => MatchByNameWithExtension(fileInfo, searchFileByName.Name, stringComparison);
            else
                filter = (fileInfo) => MatchByName(fileInfo, searchFileByName.Name, stringComparison);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySizeRange == null)
                throw new ArgumentNullException(nameof(searchFileBySizeRange));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileBySizeRange.LowerBoundSize, searchFileBySizeRange.UpperBoundSize, searchFileBySizeRange.SizeType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            if (searchFileByRegularExpressionPattern.IncludeExtension)
                filter = (fileInfo) => MatchByPatternWithExtension(fileInfo, searchFileByRegularExpressionPattern.Pattern);
            else
                filter = (fileInfo) => MatchByPattern(fileInfo, searchFileByRegularExpressionPattern.Pattern);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }

        //for files - safe
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, out List<string> errorLog)
        {

            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, SearchOption.TopDirectoryOnly, null);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, null);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            StringComparison stringComparison = searchFileByName.CaseSensitive ?
                StringComparison.InvariantCulture :
                StringComparison.InvariantCultureIgnoreCase;

            if (searchFileByName.IncludeExtension)
                filter = (fileInfo) => MatchByNameWithExtension(fileInfo, searchFileByName.Name, stringComparison);
            else
                filter = (fileInfo) => MatchByName(fileInfo, searchFileByName.Name, stringComparison);

            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);
            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileBySizeRangeOption searchFileBySizeRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySizeRange == null)
                throw new ArgumentNullException(nameof(searchFileBySizeRange));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileBySizeRange.LowerBoundSize, searchFileBySizeRange.UpperBoundSize, searchFileBySizeRange.SizeType);
            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);

            if(fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);
            if (fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = null;

            if (searchFileByRegularExpressionPattern.IncludeExtension)
                filter = (fileInfo) => MatchByPatternWithExtension(fileInfo, searchFileByRegularExpressionPattern.Pattern);
            else
                filter = (fileInfo) => MatchByPattern(fileInfo, searchFileByRegularExpressionPattern.Pattern);

            if (fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);


            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, bool fileSafetyChecking, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetFiles().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<FileInfo> files = new List<FileInfo>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            if (fileSafetyChecking)
                TraverseFilesCoreWithLoggingSafe(path, files, errorLog, searchOption, filter);
            else
                TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        
        //for dirs
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, SearchOption.TopDirectoryOnly, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByAttributes(dirInfo, attributes);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByDate(dirInfo, date, dateComparisonType);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByName == null)
                throw new ArgumentNullException(nameof(searchDirectoryByName));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            StringComparison stringComparison = searchDirectoryByName.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByName(dirInfo, searchDirectoryByName.Name, stringComparison);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchDirectoryByRegularExpressionPattern));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByPattern(dirInfo, searchDirectoryByRegularExpressionPattern.Pattern);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (directorySearchOptions == null)
                throw new ArgumentNullException(nameof(directorySearchOptions));
            errorLog = new List<string>();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                path.GetDirectories().Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => TranslateDirOptions(dirInfo, directorySearchOptions);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }


        #endregion
    }
}
