using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace System.IO.SafeTraversal
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
        private bool MatchBySizeRange(FileInfo fileInfo, double lowerBoundSize, double upperBoundSize, SizeType sizeType)
        {
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
        private bool MatchByExtension(FileInfo fileInfo, string extension)
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
        private bool MatchByName(FileInfo fileInfo, string keyword, StringComparison stringComparison)
        {
            return Path.GetFileNameWithoutExtension(fileInfo.Name).Equals(keyword, stringComparison);
        }
        private bool MatchByNameWithExtension(FileInfo fileInfo, string keyword, StringComparison stringComparison)
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
                    return MatchBySizeRange(fileInfo, 0, 10, SizeType.KiloBytes);
                case CommonSize.Small:
                    return MatchBySizeRange(fileInfo, 10, 100, SizeType.KiloBytes);
                case CommonSize.Medium:
                    return MatchBySizeRange(fileInfo, 100, 1000, SizeType.KiloBytes);
                case CommonSize.Large:
                    return MatchBySizeRange(fileInfo, 1, 16, SizeType.MegaBytes);
                case CommonSize.Huge:
                    return MatchBySizeRange(fileInfo, 16, 128, SizeType.MegaBytes);
                default:
                    return fileInfo.Length > SizeConverter(129, SizeType.MegaBytes, SizeConverterType.LowerBound);
            }
        }

        #endregion
        
        #region DIRECTORY
        private bool MatchDirByName(DirectoryInfo directoryInfo, string keyword, StringComparison stringComparison)
        {
            return directoryInfo.Name.Equals(keyword, stringComparison);
        }
        private bool MatchDirByDate(DirectoryInfo directoryInfo, DateTime date, DateComparisonType dateComparisonType)
        {
            DateTime dirInfoDate = new DateTime();
            switch(dateComparisonType)
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
        private bool MatchDirByAttributes(DirectoryInfo directoryInfo, FileAttributes fileAttributes)
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
        #endregion

        #region FILE OPTIONS
        private bool TranslateFileOptions(FileInfo fileInfo, SafeTraversalFileSearchOptions options)
        {
            Queue<bool> queue = new Queue<bool>();
         
            if(options.FileNameOption!=null)
            {
                StringComparison stringComparison = options.FileNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queue.Enqueue(options.FileNameOption.IncludeExtension? 
                    MatchByNameWithExtension(fileInfo, options.FileNameOption.Name, stringComparison):
                    MatchByName(fileInfo, options.FileNameOption.Name, stringComparison));
            }
            if (!String.IsNullOrEmpty(options.Extension))
                queue.Enqueue(MatchByExtension(fileInfo, options.Extension));
            if (options.FileAttributes != 0)
                queue.Enqueue(MatchByAttributes(fileInfo, options.FileAttributes));
            if (options.CommonSize != 0)
                queue.Enqueue(MatchByCommonSize(fileInfo, options.CommonSize));
            if (options.SizeOption != null)
                queue.Enqueue(MatchBySize(fileInfo, options.SizeOption.Size, options.SizeOption.SizeType));
            if (options.SizeRangeOption != null)
                queue.Enqueue(MatchBySizeRange(fileInfo, options.SizeRangeOption.LowerBoundSize, options.SizeRangeOption.UpperBoundSize, options.SizeRangeOption.SizeType));
            if (options.DateOption != null)
                queue.Enqueue(MatchByDate(fileInfo, options.DateOption.Date, options.DateOption.DateComparisonType));
            if (options.DateRangeOption != null)
                queue.Enqueue(MatchByDateRange(fileInfo, options.DateRangeOption.LowerBoundDate, options.DateRangeOption.UpperBoundDate, options.DateRangeOption.DateComparisonType));
            if(options.RegularExpressionOption!=null)
            {
                queue.Enqueue(options.RegularExpressionOption.IncludeExtension?
                    MatchByPatternWithExtension(fileInfo, options.RegularExpressionOption.Pattern):
                    MatchByPattern(fileInfo, options.RegularExpressionOption.Pattern));
            }
            
            if (queue.Count == 0)
                return false;
            bool result = true;
            while(queue.Count!=0)
            {
                result = result && queue.Dequeue();
            }
            return result;
        }
        #endregion

        #region DIR OPTIONS
        private bool TranslateDirOptions(DirectoryInfo directoryInfo, SafeTraversalDirectorySearchOptions options)
        {
            Queue<bool> queue = new Queue<bool>();


            if (options.DirectoryNameOption != null)
            {
                StringComparison stringComparison = options.DirectoryNameOption.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
                queue.Enqueue(MatchDirByName(directoryInfo, options.DirectoryNameOption.Name, stringComparison));
            }
            if(options.DirectoryAttributes!=0)
                queue.Enqueue(MatchDirByAttributes(directoryInfo, options.DirectoryAttributes));
            if (options.DateOption != null)
                queue.Enqueue(MatchDirByDate(directoryInfo,options.DateOption.Date,options.DateOption.DateComparisonType));
            if (options.RegularExpressionOption != null)
                queue.Enqueue(MatchDirByPattern(directoryInfo,options.RegularExpressionOption.Pattern));
            if (queue.Count == 0)
                return false;
            bool result = true;
            while(queue.Count!=0)
            {
                result = result && queue.Dequeue();
            }
            return result;
        }
        #endregion
    }
}
