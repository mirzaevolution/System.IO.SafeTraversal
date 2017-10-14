
namespace System.IO.SafeTraversal
{
    public enum SizeType
    {
        Bytes = 0,
        KiloBytes = 1,
        MegaBytes = 2,
        GigaBytes = 3,
        TeraBytes = 4,
        PetaBytes = 5
    }
    public enum DateComparisonType
    {
        CreationDate = 1,
        LastModificationDate = 2,
        LastAccessDate = 3
    }
    public enum CommonSize
    {
        Empty = 1,   // 0 KB
        Tiny = 2,    // 0-10 KB
        Small = 3,   // 10-100 KB
        Medium = 4,  // 100 KB - 1 MB
        Large = 5,   // 1 - 16 MB
        Huge = 6,    // 16 - 128 MB
        Gigantic =7  // > 128 MB 
    }
    public sealed class SearchFileByNameOption
    {
        private SearchFileByNameOption() { }
        public SearchFileByNameOption(string name, bool includeExtension = false, bool caseSensitive = false)
        {
            Name = name;
            CaseSensitive = caseSensitive;
            IncludeExtension = includeExtension;
        }
        public string Name { get; private set; }
        public bool CaseSensitive { get; private set; }
        public bool IncludeExtension { get; private set; }
    }
    public sealed class SearchFileBySizeOption
    {
        private SearchFileBySizeOption() { }
        public SearchFileBySizeOption(double size, SizeType sizeType)
        {
            Size = size;
            SizeType = sizeType;
        }
        public double Size { get; private set; } = 0;
        public SizeType SizeType { get; private set; }
    }
    public sealed class SearchFileBySizeRangeOption
    {
        private SearchFileBySizeRangeOption() { }
        public SearchFileBySizeRangeOption(double lowerBoundSize, double upperBoundSize, SizeType sizeType)
        {
            LowerBoundSize = lowerBoundSize;
            UpperBoundSize = upperBoundSize;
            SizeType = sizeType;
        }
        public double LowerBoundSize { get; private set; } = 0;
        public double UpperBoundSize { get; private set; } = 0;
        public SizeType SizeType { get; private set; }
    }
    public sealed class SearchFileByDateOption
    {
        private SearchFileByDateOption() { }
        public SearchFileByDateOption(DateTime date, DateComparisonType dateComparisonType)
        {   
            Date = date;
            DateComparisonType = dateComparisonType;

        }
        public DateTime Date { get; private set; }
        public DateComparisonType DateComparisonType { get; private set; }

    }
    public sealed class SearchFileByDateRangeOption
    {
        private SearchFileByDateRangeOption() { }
        public SearchFileByDateRangeOption(DateTime lowerBoundDate, DateTime upperBoundDate, DateComparisonType dateComparisonType)
        {
            LowerBoundDate = lowerBoundDate;
            UpperBoundDate = upperBoundDate;
            DateComparisonType = dateComparisonType;
        }
        public DateTime LowerBoundDate { get; private set; }
        public DateTime UpperBoundDate { get; private set; }
        public DateComparisonType DateComparisonType { get; private set; }
    }
    public sealed class SearchFileByRegularExpressionOption
    {
        private SearchFileByRegularExpressionOption() { }
        public SearchFileByRegularExpressionOption(string pattern, bool includeExtension = false)
        {
            Pattern = pattern;
            IncludeExtension = includeExtension;
        }
        public string Pattern { get; private set; }
        public bool IncludeExtension { get; private set; }
    }
    public sealed class SearchDirectoryByNameOption
    {
        private SearchDirectoryByNameOption() { }
        public SearchDirectoryByNameOption(string name, bool caseSensitive = false)
        {
            Name = name;
            CaseSensitive = caseSensitive;
        }
        public string Name { get; private set; }
        public bool CaseSensitive { get; private set; }
    }
    public sealed class SearchDirectoryByRegularExpressionOption
    {
        private SearchDirectoryByRegularExpressionOption() { }
        public SearchDirectoryByRegularExpressionOption(string pattern)
        {
            Pattern = pattern;
        }
        public string Pattern { get; private set; }
    }
    public sealed class SearchDirectoryByDateOption
    {
        private SearchDirectoryByDateOption() { }
        public SearchDirectoryByDateOption(DateTime date, DateComparisonType dateComparisonType)
        {
            Date = date;
            DateComparisonType = dateComparisonType;

        }
        public DateTime Date { get; private set; }
        public DateComparisonType DateComparisonType { get; private set; }

    }

    
}
