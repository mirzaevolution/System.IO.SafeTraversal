namespace System.IO.SafeTraversal
{

    /// <summary>
    /// This is composite option class to specify more than one search criteria.
    /// If you don't specify all options, they will be set to their default values.
    /// </summary>
    public class SafeTraversalFileSearchOptions
    {
        /// <summary>
        /// Get or set file name option. Default null.
        /// </summary>
        public SearchFileByNameOption FileNameOption { get; set; } = null;
        /// <summary>
        /// Get or set extension. Default empty.
        /// </summary>
        public string Extension { get; set; } = String.Empty;
        /// <summary>
        /// Get or set file attributes. Default 0.
        /// </summary>
        public FileAttributes FileAttributes { get; set; } = 0;
        /// <summary>
        /// Get or set common size enumeration. Default 0.
        /// </summary>
        public CommonSize CommonSize { get; set; } = 0;
        /// <summary>
        /// Get or set size option. Default null.
        /// </summary>
        public SearchFileBySizeOption SizeOption { get; set; } = null;
        /// <summary>
        /// Get or set size range option. Default null.
        /// </summary>
        public SearchFileBySizeRangeOption SizeRangeOption { get; set; } = null;
        /// <summary>
        /// Get or set date option. Default null.
        /// </summary>
        public SearchFileByDateOption DateOption { get; set; } = null;
        /// <summary>
        /// Get or set date range option. Default null.
        /// </summary>
        public SearchFileByDateRangeOption DateRangeOption { get; set; } = null;
        /// <summary>
        /// Get or set regular expression option. Default null.
        /// </summary>
        public SearchFileByRegularExpressionOption RegularExpressionOption { get; set; } = null;
    }
}
