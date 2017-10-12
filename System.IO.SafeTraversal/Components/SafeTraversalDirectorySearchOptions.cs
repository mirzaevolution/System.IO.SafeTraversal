using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    public class SafeTraversalDirectorySearchOptions
    {
        public SearchDirectoryByNameOption DirectoryNameOption { get; set; } = null;
        public SearchDirectoryByRegularExpressionOption RegularExpressionOption { get; set; } = null;
        public DateTime? CreationDate { get; set; } = null;
        public FileAttributes DirectoryAttributes { get; set; } = 0;
    }
}
