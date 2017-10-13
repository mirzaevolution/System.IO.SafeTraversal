using System.Collections.Generic;
using System.Linq;

namespace System.IO.SafeTraversal
{
    public partial class SafeTraversal
    {
     
        #region NO_LOGGING
        private void TraverseFilesCoreNoLogging( DirectoryInfo directoryInfo,
                                                 List<FileInfo> files, 
                                                 SearchOption searchOption,  
                                                 Func<FileInfo,bool> filter )
        {
            switch(searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                try
                                {
                                    if (filter(fileInfo))
                                        files.Add(fileInfo);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                files.Add(fileInfo);
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
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {
                                    try
                                    {
                                        if (filter(fileInfo))
                                        {
                                            files.Add(fileInfo);
                                        }
                                    }
                                    catch { }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
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
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {

                                    files.Add(fileInfo);
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
                                }
                            }
                        }
                    }
                    break;
            }


         
        }

        private void TraverseDirectoriesCoreNoLogging( DirectoryInfo directoryInfo,
                                                       List<DirectoryInfo> directories,
                                                       SearchOption searchOption,
                                                       Func<DirectoryInfo, bool> filter )
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                try
                                {

                                    if (filter(dirInfo))
                                        directories.Add(dirInfo);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                directories.Add(dirInfo);
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

                            try
                            {
                                
                                if (filter(currentDirectoryInfo))
                                    directories.Add(currentDirectoryInfo);
                            }
                            catch { }

                            foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                            {
                                queueDirectoryInfo.Enqueue(subDirInfo);
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            directories.Add(currentDirectoryInfo);

                            foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                            {
                                queueDirectoryInfo.Enqueue(subDirInfo);
                            }
                        }
                    }
                    break;
            }
        }
        //for files
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
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption,CommonSize commonSize)
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
        private IEnumerable<FileInfo> PrivateTraverseFiles(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
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
        private IEnumerable<DirectoryInfo> PrivateTraverseDirs(DirectoryInfo path,SearchOption searchOption)
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
                    try
                    {
                        if (filter != null)
                        {
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                try
                                {
                                    if (filter(fileInfo))
                                        files.Add(fileInfo);
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
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                files.Add(fileInfo);
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
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {
                                    try
                                    {
                                        if (filter(fileInfo))
                                        {
                                            files.Add(fileInfo);
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
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
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
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {

                                    files.Add(fileInfo);
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
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
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
                    try
                    {
                        if (filter != null)
                        {
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                try
                                {

                                    if (filter(dirInfo))
                                        directories.Add(dirInfo);
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
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                directories.Add(dirInfo);
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
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();

                            try
                            {

                                if (filter(currentDirectoryInfo))
                                    directories.Add(currentDirectoryInfo);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                errors.Add($"Exception: UnauthorizedAccessException, {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                errors.Add($"Exception: {ex.GetType().Name}, {ex.Message}");
                            }

                            try
                            {
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
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
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
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


        //for files
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, out List<string> errorLog)
        {

            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseFilesCoreWithLogging(path, files,errorLog, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, null);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            errorLog = null;
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

            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            errorLog = null;
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
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRange == null)
                throw new ArgumentNullException(nameof(searchFileByRange));
            errorLog = null;
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

            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            errorLog = null;
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

            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            errorLog = null;
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

            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<FileInfo> PrivateTraverseFilesWithLogging(DirectoryInfo path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            errorLog = null;
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
            errorLog = null;
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
            TraverseFilesCoreWithLogging(path, files,errorLog, searchOption, filter);
            return files;
        }

        //for dirs
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, SearchOption.TopDirectoryOnly, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, null);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByName == null)
                throw new ArgumentNullException(nameof(searchDirectoryByName));
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (searchDirectoryByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchDirectoryByRegularExpressionPattern));
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<DirectoryInfo> PrivateTraverseDirsWithLogging(DirectoryInfo path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (!path.Exists)
                throw new DirectoryNotFoundException();
            if (directorySearchOptions == null)
                throw new ArgumentNullException(nameof(directorySearchOptions));
            errorLog = null;
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
            TraverseDirectoriesCoreWithLogging(path, dirs,errorLog, searchOption, filter);
            return dirs;
        }


        #endregion
    }
}
