using System.Collections.Generic;
using System.Linq;

namespace System.IO.SafeTraversal
{
    public partial class SafeTraversal
    {
        #region NO_LOGGING
        private void TraverseFilesCoreNoLogging( string path,
                                                 List<string> files,
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
                            foreach (string file in Directory.GetFiles(path))
                            {
                                try
                                {
                                    if (filter(new FileInfo(file)))
                                        files.Add(file);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (string file in Directory.GetFiles(path))
                            {
                                files.Add(file);
                            }
                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<string> queueDirectoryStr = new Queue<string>();
                    queueDirectoryStr.Enqueue(path);
                    if (filter != null)
                    {
                        while (queueDirectoryStr.Count > 0)
                        {
                            string currentDirectory = queueDirectoryStr.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (string file in Directory.GetFiles(currentDirectory))
                                {
                                    try
                                    {
                                        if (filter(new FileInfo(file)))
                                        {
                                            files.Add(file);
                                        }
                                    }
                                    catch { }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectoryStr.Enqueue(subDir);
                                }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryStr.Count > 0)
                        {
                            string currentDirectory = queueDirectoryStr.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (string file in Directory.GetFiles(currentDirectory))
                                {
                                    try
                                    {
                                        files.Add(file);
                                    }
                                    catch { }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectoryStr.Enqueue(subDir);
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void TraverseDirectoriesCoreNoLogging( string path,
                                                       List<string> directories,
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
                            foreach (string dir in Directory.GetDirectories(path))
                            {
                                try
                                {

                                    if (filter(new DirectoryInfo(dir)))
                                        directories.Add(dir);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (string dir in Directory.GetDirectories(path))
                            {
                                directories.Add(dir);
                            }
                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<string> queueDirectory = new Queue<string>();
                    queueDirectory.Enqueue(path);
                    if (filter != null)
                    {
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();

                            try
                            {

                                if (filter(new DirectoryInfo(currentDirectory)))
                                    directories.Add(currentDirectory);
                            }
                            catch { }

                            foreach (string subDir in Directory.GetDirectories(currentDirectory))
                            {
                                queueDirectory.Enqueue(subDir);
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();
                            directories.Add(currentDirectory);

                            foreach (string subDir in Directory.GetDirectories(currentDirectory))
                            {
                                queueDirectory.Enqueue(subDir);
                            }
                        }
                    }
                    break;
            }
        }
        //for files
        private IEnumerable<string> PrivateTraverseFiles(string path)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreNoLogging(path, files, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreNoLogging(path, files, searchOption, null);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, CommonSize commonSize)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
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
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByRange == null)
                throw new ArgumentNullException(nameof(searchFileByRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileByRange.LowerBoundSize, searchFileByRange.UpperBoundSize, searchFileByRange.SizeType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);

            TraverseFilesCoreNoLogging(path, files, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
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
        private IEnumerable<string> PrivateTraverseFiles(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            TraverseFilesCoreNoLogging(path, files, searchOption, filter);
            return files;
        }
        //for dirs
        private IEnumerable<string> PrivateTraverseDirs(string path)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreNoLogging(path, dirs, SearchOption.TopDirectoryOnly, null);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, null);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption, FileAttributes attributes)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByAttributes(dirInfo, attributes);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByDate(dirInfo, date, dateComparisonType);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchDirectoryByName == null)
                throw new ArgumentNullException(nameof(searchDirectoryByName));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            StringComparison stringComparison = searchDirectoryByName.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByName(dirInfo, searchDirectoryByName.Name, stringComparison);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchDirectoryByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchDirectoryByRegularExpressionPattern));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByPattern(dirInfo, searchDirectoryByRegularExpressionPattern.Pattern);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirs(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (directorySearchOptions == null)
                throw new ArgumentNullException(nameof(directorySearchOptions));
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => TranslateDirOptions(dirInfo, directorySearchOptions);
            TraverseDirectoriesCoreNoLogging(path, dirs, searchOption, filter);
            return dirs;
        }

        #endregion

        #region WITH_LOGGING
        private void TraverseFilesCoreWithLogging(  string path,
                                                    List<string> files,
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
                            foreach (string file in Directory.GetFiles(path))
                            {
                                try
                                {
                                    if (filter(new FileInfo(file)))
                                        files.Add(file);
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
                            foreach (string file in Directory.GetFiles(path))
                            {
                                files.Add(file);
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
                    Queue<string> queueDirectory = new Queue<string>();
                    queueDirectory.Enqueue(path);
                    if (filter != null)
                    {
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (string file in Directory.GetFiles(currentDirectory))
                                {
                                    try
                                    {
                                        if (filter(new FileInfo(file)))
                                        {
                                            files.Add(file);
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
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectory.Enqueue(subDir);
                                }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (string file in Directory.GetFiles(currentDirectory))
                                {

                                    files.Add(file);
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
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectory.Enqueue(subDir);
                                }
                            }
                        }
                    }
                    break;
            }



        }
        private void TraverseDirectoriesCoreWithLogging(string path,
                                                        List<string> directories,
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
                            foreach (string dir in Directory.GetDirectories(path))
                            {
                                try
                                {

                                    if (filter(new DirectoryInfo(dir)))
                                        directories.Add(dir);
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
                            foreach (string dir in Directory.GetDirectories(path))
                            {
                                directories.Add(dir);
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
                    Queue<string> queueDirectory = new Queue<string>();
                    queueDirectory.Enqueue(path);
                    if (filter != null)
                    {
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();

                            try
                            {

                                if (filter(new DirectoryInfo(currentDirectory)))
                                    directories.Add(currentDirectory);
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
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectory.Enqueue(subDir);
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
                        while (queueDirectory.Count > 0)
                        {
                            string currentDirectory = queueDirectory.Dequeue();
                            directories.Add(currentDirectory);
                            try
                            {
                                foreach (string subDir in Directory.GetDirectories(currentDirectory))
                                {
                                    queueDirectory.Enqueue(subDir);
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
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, out List<string> errorLog)
        {

            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreWithLogging(path, files, errorLog, SearchOption.TopDirectoryOnly, null);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, null);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, CommonSize commonSize, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByCommonSize(fileInfo, commonSize);
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileByNameOption searchFileByName, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByName == null)
                throw new ArgumentNullException(nameof(searchFileByName));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
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
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileBySizeOption searchFileBySize, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileBySize == null)
                throw new ArgumentNullException(nameof(searchFileBySize));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchBySize(fileInfo, searchFileBySize.Size, searchFileBySize.SizeType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileBySizeRangeOption searchFileByRange, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByRange == null)
                throw new ArgumentNullException(nameof(searchFileByRange));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchBySizeRange(fileInfo, searchFileByRange.LowerBoundSize, searchFileByRange.UpperBoundSize, searchFileByRange.SizeType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileByDateOption searchFileByDate, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByDate == null)
                throw new ArgumentNullException(nameof(searchFileByDate));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!

            Func<FileInfo, bool> filter = (fileInfo) => MatchByDate(fileInfo, searchFileByDate.Date, searchFileByDate.DateComparisonType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileByDateRangeOption searchFileByDateRange, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByDateRange == null)
                throw new ArgumentNullException(nameof(searchFileByDateRange));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => MatchByDateRange(fileInfo, searchFileByDateRange.LowerBoundDate, searchFileByDateRange.UpperBoundDate, searchFileByDateRange.DateComparisonType);

            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);

            return files;
        }
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SearchFileByRegularExpressionOption searchFileByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchFileByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchFileByRegularExpressionPattern));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
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
        private IEnumerable<string> PrivateTraverseFilesWithLogging(string path, SearchOption searchOption, SafeTraversalFileSearchOptions fileSearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (fileSearchOptions == null)
                throw new ArgumentNullException(nameof(fileSearchOptions));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetFiles(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> files = new List<string>();
            if (!pathIsSafe)
                return files; //returns empty if path is not safe!
            Func<FileInfo, bool> filter = (fileInfo) => TranslateFileOptions(fileInfo, fileSearchOptions);
            TraverseFilesCoreWithLogging(path, files, errorLog, searchOption, filter);
            return files;
        }
        //for dirs
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, SearchOption.TopDirectoryOnly, null);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, null);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, FileAttributes attributes, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByAttributes(dirInfo, attributes);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, DateTime date, DateComparisonType dateComparisonType, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByDate(dirInfo, date, dateComparisonType);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, SearchDirectoryByNameOption searchDirectoryByName, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchDirectoryByName == null)
                throw new ArgumentNullException(nameof(searchDirectoryByName));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            StringComparison stringComparison = searchDirectoryByName.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByName(dirInfo, searchDirectoryByName.Name, stringComparison);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, SearchDirectoryByRegularExpressionOption searchDirectoryByRegularExpressionPattern, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (searchDirectoryByRegularExpressionPattern == null)
                throw new ArgumentNullException(nameof(searchDirectoryByRegularExpressionPattern));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => MatchDirByPattern(dirInfo, searchDirectoryByRegularExpressionPattern.Pattern);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }
        private IEnumerable<string> PrivateTraverseDirsWithLogging(string path, SearchOption searchOption, SafeTraversalDirectorySearchOptions directorySearchOptions, out List<string> errorLog)
        {
            //perform initial checking
            if (Directory.Exists(path))
                throw new DirectoryNotFoundException();
            if (directorySearchOptions == null)
                throw new ArgumentNullException(nameof(directorySearchOptions));
            errorLog = null;
            bool pathIsSafe = false;
            try
            {
                //initial checking for unauthorized access path
                Directory.GetDirectories(path).Any();
                pathIsSafe = true;
            }
            catch { pathIsSafe = false; }
            List<string> dirs = new List<string>();
            if (!pathIsSafe)
                return dirs; //returns empty if path is not safe!
            Func<DirectoryInfo, bool> filter = (dirInfo) => TranslateDirOptions(dirInfo, directorySearchOptions);
            TraverseDirectoriesCoreWithLogging(path, dirs, errorLog, searchOption, filter);
            return dirs;
        }


        #endregion
    }
}
