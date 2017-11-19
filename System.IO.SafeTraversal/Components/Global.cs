namespace System.IO.SafeTraversal
{
    /// <summary>
    /// Enumeration that is used for size convertion.
    /// </summary>
    public enum SizeType
    {
        /// <summary>
        /// Power(1024,0)
        /// </summary>
        Bytes = 0,
        /// <summary>
        /// Power(1024,1)
        /// </summary>
        KiloBytes = 1,
        /// <summary>
        /// Power(1024,2)
        /// </summary>
        MegaBytes = 2,
        /// <summary>
        /// Power(1024,3)
        /// </summary>
        GigaBytes = 3,
        /// <summary>
        /// Power(1024,4)
        /// </summary>
        TeraBytes = 4,
        /// <summary>
        /// Power(1024,5)
        /// </summary>
        PetaBytes = 5
    }
    /// <summary>
    /// Enumeration for Date/Date Range filtering.
    /// </summary>
    public enum DateComparisonType
    {
        /// <summary>
        /// Filter based on creation date
        /// </summary>
        CreationDate = 1,
        /// <summary>
        /// Filter based on last modification date
        /// </summary>
        LastModificationDate = 2,
        /// <summary>
        /// Filter based on last access date
        /// </summary>
        LastAccessDate = 3
    }
    /// <summary>
    /// Enumeration that depicts Windows Explorer size filtering.
    /// </summary>
    public enum CommonSize
    {
        /// <summary>
        /// 0 KB
        /// </summary>
        Empty = 1,
        /// <summary>
        /// 0 - 10 KB
        /// </summary>
        Tiny = 2,
        /// <summary>
        /// 10-100 KB
        /// </summary>
        Small = 3,
        /// <summary>
        /// 100 KB - 1 MB
        /// </summary>
        Medium = 4,
        /// <summary>
        /// 1 - 16 MB
        /// </summary>
        Large = 5,
        /// <summary>
        /// 16 - 128 MB
        /// </summary>
        Huge = 6,
        /// <summary>
        /// > 128 MB 
        /// </summary>
        Gigantic = 7
    }
    /// <summary>
    /// Option class for searching files based on filename, extension and case sensitiveness.
    /// </summary>
    public sealed class SearchFileByNameOption
    {
        private SearchFileByNameOption() { }
        /// <summary>
        /// Default constructor for SearchFileByNameOption.
        /// </summary>
        /// <param name="name">Filename.</param>
        /// <param name="includeExtension">Default to false. Specifying true to include extension in search algorithm.</param>
        /// <param name="caseSensitive">Turn case sensitive/insensitive mode.</param>
        public SearchFileByNameOption(string name, bool includeExtension = false, bool caseSensitive = false)
        {
            Name = name;
            CaseSensitive = caseSensitive;
            IncludeExtension = includeExtension;
        }
        /// <summary>
        /// Gets name used for filtering.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets status for case sensitivity.
        /// </summary>
        public bool CaseSensitive { get; private set; }
        /// <summary>
        /// Gets status whether or not extension is included in search.
        /// </summary>
        public bool IncludeExtension { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on size.
    /// </summary>
    public sealed class SearchFileBySizeOption
    {
        private SearchFileBySizeOption() { }
        /// <summary>
        /// Default constructor for instantiating SearchFileBySizeOption class.
        /// </summary>
        /// <param name="size">Preferred Size.</param>
        /// <param name="sizeType">Size type.</param>
        public SearchFileBySizeOption(double size, SizeType sizeType)
        {
            Size = size;
            SizeType = sizeType;
        }
        /// <summary>
        /// Gets size in double.
        /// </summary>
        public double Size { get; private set; } = 0;
        /// <summary>
        /// Gets size type that specifies unit.
        /// </summary>
        public SizeType SizeType { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on defined size range.
    /// </summary>
    public sealed class SearchFileBySizeRangeOption
    {
        private SearchFileBySizeRangeOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="lowerBoundSize">Lower bound size.</param>
        /// <param name="upperBoundSize">Upper bound size.</param>
        /// <param name="sizeType">Size type.</param>
        public SearchFileBySizeRangeOption(double lowerBoundSize, double upperBoundSize, SizeType sizeType)
        {
            LowerBoundSize = lowerBoundSize;
            UpperBoundSize = upperBoundSize;
            SizeType = sizeType;
        }
        /// <summary>
        /// Gets lower bound size in double.
        /// </summary>
        public double LowerBoundSize { get; private set; } = 0;
        /// <summary>
        /// Gets upper bound size in double.
        /// </summary>
        public double UpperBoundSize { get; private set; } = 0;
        /// <summary>
        /// Gets size type that specifies unit.
        /// </summary>
        public SizeType SizeType { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on date in specified comparison type.
    /// </summary>
    public sealed class SearchFileByDateOption
    {
        private SearchFileByDateOption() { }
        /// <summary>
        /// Default constructor for instantiating this class.
        /// </summary>
        /// <param name="date">Date only. No time is used.</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        public SearchFileByDateOption(DateTime date, DateComparisonType dateComparisonType)
        {
            Date = date;
            DateComparisonType = dateComparisonType;

        }
        /// <summary>
        /// Gets date that is used for filtering.
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Gets date comparison type.
        /// </summary>
        public DateComparisonType DateComparisonType { get; private set; }

    }
    /// <summary>
    /// Option class for searching files based on date range in specified date comparison type.
    /// </summary>
    public sealed class SearchFileByDateRangeOption
    {
        private SearchFileByDateRangeOption() { }
        /// <summary>
        /// Default constructor for instantiating this class.
        /// </summary>
        /// <param name="lowerBoundDate">Lower bound date. Please, specifiy in date format only.</param>
        /// <param name="upperBoundDate">Upper bound date. Please, specifiy in date format only,</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        public SearchFileByDateRangeOption(DateTime lowerBoundDate, DateTime upperBoundDate, DateComparisonType dateComparisonType)
        {
            LowerBoundDate = lowerBoundDate;
            UpperBoundDate = upperBoundDate;
            DateComparisonType = dateComparisonType;
        }
        /// <summary>
        /// Gets lower bound date.
        /// </summary>
        public DateTime LowerBoundDate { get; private set; }
        /// <summary>
        /// Gets upper bound date.
        /// </summary>
        public DateTime UpperBoundDate { get; private set; }
        /// <summary>
        /// Gets date comparison type.
        /// </summary>
        public DateComparisonType DateComparisonType { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on .NET regular expression pattern.
    /// </summary>
    public sealed class SearchFileByRegularExpressionOption
    {
        private SearchFileByRegularExpressionOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pattern">Valid .NET regular expression pattern.</param>
        /// <param name="includeExtension">True/False to specify whether or not extension is included in pattern matching.</param>
        public SearchFileByRegularExpressionOption(string pattern, bool includeExtension = false)
        {
            Pattern = pattern;
            IncludeExtension = includeExtension;
        }
        /// <summary>
        /// Gets regular expression pattern.
        /// </summary>
        public string Pattern { get; private set; }
        /// <summary>
        /// Gets status whether or not extension is included in search.
        /// </summary>
        public bool IncludeExtension { get; private set; }
    }
    /// <summary>
    /// Option class for searching directories based on name.
    /// </summary>
    public sealed class SearchDirectoryByNameOption
    {
        private SearchDirectoryByNameOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">Specified name.</param>
        /// <param name="caseSensitive">Set to true/false to specify whether or not case sensitiveness is used.</param>
        public SearchDirectoryByNameOption(string name, bool caseSensitive = false)
        {
            Name = name;
            CaseSensitive = caseSensitive;
        }
        /// <summary>
        /// Gets name used for filtering.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets status for case sensitivity.
        /// </summary>
        public bool CaseSensitive { get; private set; }
    }
    /// <summary>
    /// Option class for searching directories based on .NET regular expression pattern.
    /// </summary>
    public sealed class SearchDirectoryByRegularExpressionOption
    {
        private SearchDirectoryByRegularExpressionOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pattern">Valid .NET regular expression pattern.</param>
        public SearchDirectoryByRegularExpressionOption(string pattern)
        {
            Pattern = pattern;
        }
        /// <summary>
        /// Gets regular expression pattern.
        /// </summary>
        public string Pattern { get; private set; }
    }
    /// <summary>
    /// Option class for searching directories based on date.
    /// </summary>
    public sealed class SearchDirectoryByDateOption
    {
        private SearchDirectoryByDateOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="date">Date only.</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        public SearchDirectoryByDateOption(DateTime date, DateComparisonType dateComparisonType)
        {
            Date = date;
            DateComparisonType = dateComparisonType;

        }
        /// <summary>
        /// Gets date specified for filtering.
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Gets date comparison type.
        /// </summary>
        public DateComparisonType DateComparisonType { get; private set; }

    }

}
