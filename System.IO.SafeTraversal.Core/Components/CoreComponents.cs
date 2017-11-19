using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace System.IO.SafeTraversal.Core
{
    public partial class SafeTraversal
    {
        enum SizeConverterType
        {
            LowerBound,
            UpperBound
        }
        #region FILE
        private long SizeConverter(double size, SizeType type, SizeConverterType converterType)
        {
            try
            {
                double result = 0;
                int power = 0;
                power = (int)type;
                if (size == 0)
                    size = +1;
                switch (converterType)
                {
                    case SizeConverterType.LowerBound:
                        result = Math.Floor(((size - 1) * Math.Pow(1024, power)));
                        break;
                    case SizeConverterType.UpperBound:
                        result = Math.Ceiling(((size + 1) * Math.Pow(1024, power)));
                        break;
                }
                if (result >= (double)long.MaxValue)
                    return -1;
                return Convert.ToInt64(result);
            }
            catch { return -1; }
        }
        private static long SizeConverterEx(double size, SizeType type, SizeConverterType converterType)
        {
            try
            {
                double result = 0;
                int power = 0;
                power = (int)type;
                if (size == 0)
                    size = +1;
                switch (converterType)
                {
                    case SizeConverterType.LowerBound:
                        result = Math.Floor(((size - 1) * Math.Pow(1024, power)));
                        break;
                    case SizeConverterType.UpperBound:
                        result = Math.Ceiling(((size + 1) * Math.Pow(1024, power)));
                        break;
                }
                if (result >= (double)long.MaxValue)
                    return -1;
                return Convert.ToInt64(result);
            }
            catch { return -1; }
        }

        private bool MatchBySize(FileInfo fileInfo, double size, SizeType sizeType)
        {
            long lowerBound = SizeConverter(size, sizeType, SizeConverterType.LowerBound);

            if (lowerBound < 0)
                return false;

            long upperBound = SizeConverter(size, sizeType, SizeConverterType.UpperBound);

            if (upperBound < 0)
                return false;

            return (fileInfo.Length >= lowerBound && fileInfo.Length <= upperBound);
        }
        private static bool MatchBySizeEx(FileInfo fileInfo, double size, SizeType sizeType)
        {
            long lowerBound = SizeConverterEx(size, sizeType, SizeConverterType.LowerBound);

            if (lowerBound < 0)
                return false;

            long upperBound = SizeConverterEx(size, sizeType, SizeConverterType.UpperBound);

            if (upperBound < 0)
                return false;

            return (fileInfo.Length >= lowerBound && fileInfo.Length <= upperBound);
        }

        private bool MatchBySizeRange(FileInfo fileInfo, double lowerBoundSize, double upperBoundSize, SizeType sizeType)
        {
            lowerBoundSize++;
            if (lowerBoundSize < 0)
                return false;
            if (upperBoundSize < 0)
                return false;
            if (lowerBoundSize >= upperBoundSize)
                return false;
            long lowerBound = SizeConverter(lowerBoundSize, sizeType, SizeConverterType.LowerBound);
            if (lowerBound < 0)
                return false;
            long upperBound = SizeConverter(upperBoundSize, sizeType, SizeConverterType.UpperBound);
            if (upperBound < 0)
                return false;
            return (fileInfo.Length >= lowerBound && fileInfo.Length <= upperBound);
        }
        private static bool MatchBySizeRangeEx(FileInfo fileInfo, double lowerBoundSize, double upperBoundSize, SizeType sizeType)
        {
            lowerBoundSize++;
            if (lowerBoundSize < 0)
                return false;
            if (upperBoundSize < 0)
                return false;
            if (lowerBoundSize >= upperBoundSize)
                return false;
            long lowerBound = SizeConverterEx(lowerBoundSize, sizeType, SizeConverterType.LowerBound);
            if (lowerBound < 0)
                return false;
            long upperBound = SizeConverterEx(upperBoundSize, sizeType, SizeConverterType.UpperBound);
            if (upperBound < 0)
                return false;
            return (fileInfo.Length >= lowerBound && fileInfo.Length <= upperBound);
        }

        private bool MatchByDate(FileInfo fileInfo, DateTime dateTime, DateComparisonType comparisonType)
        {
            DateTime fileInfoDate = new DateTime();
            switch (comparisonType)
            {
                case DateComparisonType.CreationDate:
                    fileInfoDate = fileInfo.CreationTime.Date;
                    break;
                case DateComparisonType.LastModificationDate:
                    fileInfoDate = fileInfo.LastWriteTime.Date;
                    break;
                case DateComparisonType.LastAccessDate:
                    fileInfoDate = fileInfo.LastAccessTime.Date;
                    break;
            }
            return DateTime.Equals(fileInfoDate.Date, dateTime.Date);
        }
        private static bool MatchByDateEx(FileInfo fileInfo, DateTime dateTime, DateComparisonType comparisonType)
        {
            DateTime fileInfoDate = new DateTime();
            switch (comparisonType)
            {
                case DateComparisonType.CreationDate:
                    fileInfoDate = fileInfo.CreationTime.Date;
                    break;
                case DateComparisonType.LastModificationDate:
                    fileInfoDate = fileInfo.LastWriteTime.Date;
                    break;
                case DateComparisonType.LastAccessDate:
                    fileInfoDate = fileInfo.LastAccessTime.Date;
                    break;
            }
            return DateTime.Equals(fileInfoDate.Date, dateTime.Date);
        }

        private bool MatchByDateRange(FileInfo fileInfo, DateTime lowerBoundDate, DateTime upperBoundDate, DateComparisonType comparisonType)
        {
            DateTime fileInfoDate = new DateTime();
            switch (comparisonType)
            {
                case DateComparisonType.CreationDate:
                    fileInfoDate = fileInfo.CreationTime.Date;
                    break;
                case DateComparisonType.LastModificationDate:
                    fileInfoDate = fileInfo.LastWriteTime.Date;
                    break;
                case DateComparisonType.LastAccessDate:
                    fileInfoDate = fileInfo.LastAccessTime.Date;
                    break;
            }
            return (fileInfoDate >= lowerBoundDate.Date && fileInfoDate <= upperBoundDate.Date);
        }
        private static bool MatchByDateRangeEx(FileInfo fileInfo, DateTime lowerBoundDate, DateTime upperBoundDate, DateComparisonType comparisonType)
        {
            DateTime fileInfoDate = new DateTime();
            switch (comparisonType)
            {
                case DateComparisonType.CreationDate:
                    fileInfoDate = fileInfo.CreationTime.Date;
                    break;
                case DateComparisonType.LastModificationDate:
                    fileInfoDate = fileInfo.LastWriteTime.Date;
                    break;
                case DateComparisonType.LastAccessDate:
                    fileInfoDate = fileInfo.LastAccessTime.Date;
                    break;
            }
            return (fileInfoDate >= lowerBoundDate.Date && fileInfoDate <= upperBoundDate.Date);
        }

        private bool MatchByPattern(FileInfo fileInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(Path.GetFileNameWithoutExtension(fileInfo.Name), pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }
        private static bool MatchByPatternEx(FileInfo fileInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(Path.GetFileNameWithoutExtension(fileInfo.Name), pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }

        private bool MatchByPatternWithExtension(FileInfo fileInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(fileInfo.Name, pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }
        private static bool MatchByPatternWithExtensionEx(FileInfo fileInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(fileInfo.Name, pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }

        private bool MatchByExtension(FileInfo fileInfo, string extension)
        {
            extension = Regex.Match(extension, @"(\.)?\w+").Value;
            if (!extension.StartsWith("."))
                extension = "." + extension;
            return fileInfo.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase);
        }
        private static bool MatchByExtensionEx(FileInfo fileInfo, string extension)
        {
            extension = Regex.Match(extension, @"(\.)?\w+").Value;
            if (!extension.StartsWith("."))
                extension = "." + extension;
            return fileInfo.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool MatchByAttributes(FileInfo fileInfo, FileAttributes fileAttributes)
        {
            return fileInfo.Attributes == fileAttributes;
        }
        private static bool MatchByAttributesEx(FileInfo fileInfo, FileAttributes fileAttributes)
        {
            return fileInfo.Attributes == fileAttributes;
        }

        private bool MatchByName(FileInfo fileInfo, string keyword, StringComparison stringComparison)
        {
            return Path.GetFileNameWithoutExtension(fileInfo.Name).Equals(keyword, stringComparison);
        }
        private static bool MatchByNameEx(FileInfo fileInfo, string keyword, StringComparison stringComparison)
        {
            return Path.GetFileNameWithoutExtension(fileInfo.Name).Equals(keyword, stringComparison);
        }

        private bool MatchByNameWithExtension(FileInfo fileInfo, string keyword, StringComparison stringComparison)
        {
            return fileInfo.Name.Equals(keyword, stringComparison);
        }
        private static bool MatchByNameWithExtensionEx(FileInfo fileInfo, string keyword, StringComparison stringComparison)
        {
            return fileInfo.Name.Equals(keyword, stringComparison);
        }

        private bool MatchByCommonSize(FileInfo fileInfo, CommonSize commonSize)
        {
            switch (commonSize)
            {
                case CommonSize.Empty:
                    return fileInfo.Length == 0;
                case CommonSize.Tiny:
                    return MatchBySizeRange(fileInfo, 1, 10, SizeType.KiloBytes);
                case CommonSize.Small:
                    return MatchBySizeRange(fileInfo, 11, 100, SizeType.KiloBytes);
                case CommonSize.Medium:
                    return MatchBySizeRange(fileInfo, 101, 1000, SizeType.KiloBytes);
                case CommonSize.Large:
                    return MatchBySizeRange(fileInfo, 2, 16, SizeType.MegaBytes);
                case CommonSize.Huge:
                    return MatchBySizeRange(fileInfo, 17, 128, SizeType.MegaBytes);
                default:
                    return fileInfo.Length > SizeConverter(129, SizeType.MegaBytes, SizeConverterType.LowerBound);
            }
        }
        private static bool MatchByCommonSizeEx(FileInfo fileInfo, CommonSize commonSize)
        {
            switch (commonSize)
            {
                case CommonSize.Empty:
                    return fileInfo.Length == 0;
                case CommonSize.Tiny:
                    return MatchBySizeRangeEx(fileInfo, 1, 10, SizeType.KiloBytes);
                case CommonSize.Small:
                    return MatchBySizeRangeEx(fileInfo, 11, 100, SizeType.KiloBytes);
                case CommonSize.Medium:
                    return MatchBySizeRangeEx(fileInfo, 101, 1000, SizeType.KiloBytes);
                case CommonSize.Large:
                    return MatchBySizeRangeEx(fileInfo, 2, 16, SizeType.MegaBytes);
                case CommonSize.Huge:
                    return MatchBySizeRangeEx(fileInfo, 17, 128, SizeType.MegaBytes);
                default:
                    return fileInfo.Length > SizeConverterEx(129, SizeType.MegaBytes, SizeConverterType.LowerBound);
            }
        }


        #endregion

        #region DIRECTORY
        private bool MatchDirByName(DirectoryInfo directoryInfo, string keyword, StringComparison stringComparison)
        {
            return directoryInfo.Name.Equals(keyword, stringComparison);
        }
        private static bool MatchDirByNameEx(DirectoryInfo directoryInfo, string keyword, StringComparison stringComparison)
        {
            return directoryInfo.Name.Equals(keyword, stringComparison);
        }

        private bool MatchDirByDate(DirectoryInfo directoryInfo, DateTime date, DateComparisonType dateComparisonType)
        {
            DateTime dirInfoDate = new DateTime();
            switch (dateComparisonType)
            {
                case DateComparisonType.CreationDate:
                    dirInfoDate = directoryInfo.CreationTime;
                    break;
                case DateComparisonType.LastAccessDate:
                    dirInfoDate = directoryInfo.LastAccessTime;
                    break;
                case DateComparisonType.LastModificationDate:
                    dirInfoDate = directoryInfo.LastWriteTime;
                    break;
            }
            return DateTime.Equals(dirInfoDate.Date, date.Date);
        }
        private static bool MatchDirByDateEx(DirectoryInfo directoryInfo, DateTime date, DateComparisonType dateComparisonType)
        {
            DateTime dirInfoDate = new DateTime();
            switch (dateComparisonType)
            {
                case DateComparisonType.CreationDate:
                    dirInfoDate = directoryInfo.CreationTime;
                    break;
                case DateComparisonType.LastAccessDate:
                    dirInfoDate = directoryInfo.LastAccessTime;
                    break;
                case DateComparisonType.LastModificationDate:
                    dirInfoDate = directoryInfo.LastWriteTime;
                    break;
            }
            return DateTime.Equals(dirInfoDate.Date, date.Date);
        }

        private bool MatchDirByAttributes(DirectoryInfo directoryInfo, FileAttributes fileAttributes = FileAttributes.Directory)
        {
            return directoryInfo.Attributes == fileAttributes;
        }
        private static bool MatchDirByAttributesEx(DirectoryInfo directoryInfo, FileAttributes fileAttributes = FileAttributes.Directory)
        {
            return directoryInfo.Attributes == fileAttributes;
        }

        private bool MatchDirByPattern(DirectoryInfo directoryInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(directoryInfo.Name, pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }
        private static bool MatchDirByPatternEx(DirectoryInfo directoryInfo, string pattern)
        {
            bool result = false;
            try
            {
                result = Regex.IsMatch(directoryInfo.Name, pattern, RegexOptions.Compiled);
            }
            catch { result = false; }
            return result;
        }

        #endregion

        #region FILE OPTIONS
        private bool TranslateFileOptions(FileInfo fileInfo, SafeTraversalFileSearchOptions options)
        {
            Queue<bool> queueResult = new Queue<bool>();
            if (options.FileNameOption != null)
            {
                StringComparison stringComparison = options.FileNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queueResult.Enqueue(options.FileNameOption.IncludeExtension ?
                    MatchByNameWithExtension(fileInfo, options.FileNameOption.Name, stringComparison) :
                    MatchByName(fileInfo, options.FileNameOption.Name, stringComparison));
            }
            if (!String.IsNullOrEmpty(options.Extension))
            {
                queueResult.Enqueue(MatchByExtension(fileInfo, options.Extension));
            }
            if (options.FileAttributes != 0)
            {
                queueResult.Enqueue(MatchByAttributes(fileInfo, options.FileAttributes));
            }
            if (options.CommonSize != 0)
            {
                queueResult.Enqueue(MatchByCommonSize(fileInfo, options.CommonSize));
            }
            if (options.SizeOption != null)
            {
                queueResult.Enqueue(MatchBySize(fileInfo, options.SizeOption.Size, options.SizeOption.SizeType));
            }
            if (options.SizeRangeOption != null)
            {
                queueResult.Enqueue(MatchBySizeRange(fileInfo, options.SizeRangeOption.LowerBoundSize, options.SizeRangeOption.UpperBoundSize, options.SizeRangeOption.SizeType));
            }
            if (options.DateOption != null)
            {
                queueResult.Enqueue(MatchByDate(fileInfo, options.DateOption.Date, options.DateOption.DateComparisonType));
            }
            if (options.DateRangeOption != null)
            {
                queueResult.Enqueue(MatchByDateRange(fileInfo, options.DateRangeOption.LowerBoundDate, options.DateRangeOption.UpperBoundDate, options.DateRangeOption.DateComparisonType));
            }
            if (options.RegularExpressionOption != null)
            {
                queueResult.Enqueue(options.RegularExpressionOption.IncludeExtension ?
                    MatchByPatternWithExtension(fileInfo, options.RegularExpressionOption.Pattern) :
                    MatchByPattern(fileInfo, options.RegularExpressionOption.Pattern));
            }

            if (queueResult.Count == 0)
                return false;
            bool result = true;
            while (queueResult.Count > 0)
            {
                bool r = queueResult.Dequeue();
                result = result && r;
                if (!result)
                    break;

            }
            return result;
        }
        private static bool TranslateFileOptionsEx(FileInfo fileInfo, SafeTraversalFileSearchOptions options)
        {
            Queue<bool> queueResult = new Queue<bool>();
            if (options.FileNameOption != null)
            {
                StringComparison stringComparison = options.FileNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queueResult.Enqueue(options.FileNameOption.IncludeExtension ?
                    MatchByNameWithExtensionEx(fileInfo, options.FileNameOption.Name, stringComparison) :
                    MatchByNameEx(fileInfo, options.FileNameOption.Name, stringComparison));
            }
            if (!String.IsNullOrEmpty(options.Extension))
            {
                queueResult.Enqueue(MatchByExtensionEx(fileInfo, options.Extension));
            }
            if (options.FileAttributes != 0)
            {
                queueResult.Enqueue(MatchByAttributesEx(fileInfo, options.FileAttributes));
            }
            if (options.CommonSize != 0)
            {
                queueResult.Enqueue(MatchByCommonSizeEx(fileInfo, options.CommonSize));
            }
            if (options.SizeOption != null)
            {
                queueResult.Enqueue(MatchBySizeEx(fileInfo, options.SizeOption.Size, options.SizeOption.SizeType));
            }
            if (options.SizeRangeOption != null)
            {
                queueResult.Enqueue(MatchBySizeRangeEx(fileInfo, options.SizeRangeOption.LowerBoundSize, options.SizeRangeOption.UpperBoundSize, options.SizeRangeOption.SizeType));
            }
            if (options.DateOption != null)
            {
                queueResult.Enqueue(MatchByDateEx(fileInfo, options.DateOption.Date, options.DateOption.DateComparisonType));
            }
            if (options.DateRangeOption != null)
            {
                queueResult.Enqueue(MatchByDateRangeEx(fileInfo, options.DateRangeOption.LowerBoundDate, options.DateRangeOption.UpperBoundDate, options.DateRangeOption.DateComparisonType));
            }
            if (options.RegularExpressionOption != null)
            {
                queueResult.Enqueue(options.RegularExpressionOption.IncludeExtension ?
                    MatchByPatternWithExtensionEx(fileInfo, options.RegularExpressionOption.Pattern) :
                    MatchByPatternEx(fileInfo, options.RegularExpressionOption.Pattern));
            }

            if (queueResult.Count == 0)
                return false;
            bool result = true;
            while (queueResult.Count > 0)
            {
                bool r = queueResult.Dequeue();
                result = result && r;
                if (!result)
                    break;

            }
            return result;
        }

        #endregion

        #region DIR OPTIONS
        private bool TranslateDirOptions(DirectoryInfo directoryInfo, SafeTraversalDirectorySearchOptions options)
        {
            Queue<bool> queueResult = new Queue<bool>();
            if (options.DirectoryNameOption != null)
            {
                StringComparison stringComparison = options.DirectoryNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queueResult.Enqueue(MatchDirByName(directoryInfo, options.DirectoryNameOption.Name, stringComparison));
            }
            queueResult.Enqueue(MatchDirByAttributes(directoryInfo, options.DirectoryAttributes));
            if (options.DateOption != null)
                queueResult.Enqueue(MatchDirByDate(directoryInfo, options.DateOption.Date, options.DateOption.DateComparisonType));
            if (options.RegularExpressionOption != null)
                queueResult.Enqueue(MatchDirByPattern(directoryInfo, options.RegularExpressionOption.Pattern));
            if (queueResult.Count == 0)
                return false;
            bool result = true;
            while (queueResult.Count > 0)
            {
                bool r = queueResult.Dequeue();
                result = result && queueResult.Dequeue();
                if (!result)
                    break;
            }
            return result;
        }
        private static bool TranslateDirOptionsEx(DirectoryInfo directoryInfo, SafeTraversalDirectorySearchOptions options)
        {
            Queue<bool> queueResult = new Queue<bool>();


            if (options.DirectoryNameOption != null)
            {
                StringComparison stringComparison = options.DirectoryNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queueResult.Enqueue(MatchDirByNameEx(directoryInfo, options.DirectoryNameOption.Name, stringComparison));
            }
            queueResult.Enqueue(MatchDirByAttributesEx(directoryInfo, options.DirectoryAttributes));
            if (options.DateOption != null)
                queueResult.Enqueue(MatchDirByDateEx(directoryInfo, options.DateOption.Date, options.DateOption.DateComparisonType));
            if (options.RegularExpressionOption != null)
                queueResult.Enqueue(MatchDirByPatternEx(directoryInfo, options.RegularExpressionOption.Pattern));
            if (queueResult.Count == 0)
                return false;
            bool result = true;
            while (queueResult.Count > 0)
            {
                bool r = queueResult.Dequeue();
                result = result && queueResult.Dequeue();
                if (!result)
                    break;
            }
            return result;
        }

        #endregion
    }
}
