namespace System.IO.SafeTraversal
{
    /// <summary>
    /// An option class to specify more than one search criteria.
    /// </summary>
    public class SafeTraversalFileSearchOptions
    {
        /// <summary>
        /// Gets/sets file name option.
        /// </summary>
        public SearchFileByNameOption FileNameOption { get; set; }
        /// <summary>
        /// Gets/sets extension.
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Gets/sets file attributes.
        /// </summary>
        public FileAttributes FileAttributes { get; set; }
        /// <summary>
        /// Gets/sets common size enumeration.
        /// </summary>
        public CommonSize CommonSize { get; set; }
        /// <summary>
        /// Gets/sets size option.
        /// </summary>
        public SearchFileBySizeOption SizeOption { get; set; }
        /// <summary>
        /// Gets/sets size range option.
        /// </summary>
        public SearchFileBySizeRangeOption SizeRangeOption { get; set; }
        /// <summary>
        /// Gets/sets date option.
        /// </summary>
        public SearchFileByDateOption DateOption { get; set; }
        /// <summary>
        /// Gets/sets date range option.
        /// </summary>
        public SearchFileByDateRangeOption DateRangeOption { get; set; }
        /// <summary>
        /// Gets/sets regular expression option.
        /// </summary>
        public SearchFileByRegularExpressionOption RegularExpressionOption { get; set; }
    }
}
