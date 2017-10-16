
namespace System.IO.SafeTraversal
{
    /// <summary>
    /// Enumeration that is used for size convertion.
    /// </summary>
    public enum SizeType
    {
        Bytes = 0, 
        KiloBytes = 1,
        MegaBytes = 2,
        GigaBytes = 3,
        TeraBytes = 4,
        PetaBytes = 5
    }
    /// <summary>
    /// Used for Date/Date Range filtering.
    /// </summary>
    public enum DateComparisonType
    {
        CreationDate = 1,
        LastModificationDate = 2,
        LastAccessDate = 3
    }
    /// <summary>
    /// This enumeration depicts Windows Explorer size filtering.
    /// You can filter result based on certain size.
    /// </summary>
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
        /// Filename to search.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Get case sensitive property.
        /// </summary>
        public bool CaseSensitive { get; private set; }
        /// <summary>
        /// Get include extension property.
        /// </summary>
        public bool IncludeExtension { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on their sizes.
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
        /// Get size in double.
        /// </summary>
        public double Size { get; private set; } = 0;
        /// <summary>
        /// Get size type that specifies what kind of unit that you want to use.
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
        /// Get lower bound size in double.
        /// </summary>
        public double LowerBoundSize { get; private set; } = 0;
        /// <summary>
        /// Get upper bound size in double.
        /// </summary>
        public double UpperBoundSize { get; private set; } = 0;
        /// <summary>
        /// Get size type that specifies what kind of unit that you want to use.
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
        /// <param name="date">Date only. No time used.</param>
        /// <param name="dateComparisonType">Date comparison type.</param>
        public SearchFileByDateOption(DateTime date, DateComparisonType dateComparisonType)
        {   
            Date = date;
            DateComparisonType = dateComparisonType;

        }
        /// <summary>
        /// Get date property.
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Get date comparison type.
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
        /// Get lower bound date property.
        /// </summary>
        public DateTime LowerBoundDate { get; private set; }
        /// <summary>
        /// Get upper bound date property.
        /// </summary>
        public DateTime UpperBoundDate { get; private set; }
        /// <summary>
        /// Get date comparison type property.
        /// </summary>
        public DateComparisonType DateComparisonType { get; private set; }
    }
    /// <summary>
    /// Option class for searching files based on .NET regular expression pattern against their names.
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
        /// Get pattern property.
        /// </summary>
        public string Pattern { get; private set; }
        /// <summary>
        /// Get include extension property.
        /// </summary>
        public bool IncludeExtension { get; private set; }
    }
    /// <summary>
    /// Option class for searching directories based on their names.
    /// </summary>
    public sealed class SearchDirectoryByNameOption
    {
        private SearchDirectoryByNameOption() { }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">Common name.</param>
        /// <param name="caseSensitive">Set to true/false to specify whether or not case sensitiveness is used.</param>
        public SearchDirectoryByNameOption(string name, bool caseSensitive = false)
        {
            Name = name;
            CaseSensitive = caseSensitive;
        }
        /// <summary>
        /// Get name property.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Get case sensitive property.
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
        /// Get pattern property.
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
        /// Get date property.
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Get date comparison type.
        /// </summary>
        public DateComparisonType DateComparisonType { get; private set; }

    }

    
}
