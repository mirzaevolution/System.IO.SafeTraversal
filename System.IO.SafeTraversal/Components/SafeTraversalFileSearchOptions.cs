namespace System.IO.SafeTraversal
{

    
    public class SafeTraversalFileSearchOptions
    {
        public SearchFileByNameOption FileNameOption { get; set; } = null;
        public string Extension { get; set; } = String.Empty;
        public FileAttributes FileAttributes { get; set; } = 0;
        public CommonSize CommonSize { get; set; } = 0;
        public SearchFileBySizeOption SizeOption { get; set; } = null;
        public SearchFileBySizeRangeOption SizeRangeOption { get; set; } = null;
        public SearchFileByDateOption DateOption { get; set; } = null;
        public SearchFileByDateRangeOption DateRangeOption { get; set; } = null;
        public SearchFileByRegularExpressionOption RegularExpressionOption { get; set; } = null;
    }
}
