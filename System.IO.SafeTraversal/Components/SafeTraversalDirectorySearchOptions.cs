namespace System.IO.SafeTraversal
{
    /// <summary>
    /// This is composite option class to specify more than one search criteria for directories searching.
    /// If you don't specify all options, they will be set to their default values.
    /// </summary>
    public class SafeTraversalDirectorySearchOptions
    {
        /// <summary>
        /// Get or set directory name option. Default null.
        /// </summary>
        public SearchDirectoryByNameOption DirectoryNameOption { get; set; } = null;
        /// <summary>
        /// Get or set regular expression pattern. Default null.
        /// </summary>
        public SearchDirectoryByRegularExpressionOption RegularExpressionOption { get; set; } = null;
        /// <summary>
        /// Get or set date option. Default null.
        /// </summary>
        public SearchDirectoryByDateOption DateOption { get; set; } = null;
        /// <summary>
        /// Get or set directoriy attributes option. Default 0.
        /// </summary>
        public FileAttributes DirectoryAttributes { get; set; } = 0;
    }
}
