namespace System.IO.SafeTraversal.Core
{
    /// <summary>
    /// An option class to specify more than one search criteria for directories searching.
    /// </summary>
    public class SafeTraversalDirectorySearchOptions
    {
        /// <summary>
        /// Gets/sets directory name option.
        /// </summary>
        public SearchDirectoryByNameOption DirectoryNameOption { get; set; }
        /// <summary>
        /// Gets/sets regular expression pattern.
        /// </summary>
        public SearchDirectoryByRegularExpressionOption RegularExpressionOption { get; set; }
        /// <summary>
        /// Gets/sets date option.
        /// </summary>
        public SearchDirectoryByDateOption DateOption { get; set; }
        /// <summary>
        /// Gets/sets directory attributes option.
        /// </summary>
        public FileAttributes DirectoryAttributes { get; set; } = FileAttributes.Directory;
    }
}
