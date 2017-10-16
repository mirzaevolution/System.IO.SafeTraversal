# System.IO.SafeTraversal v1.1.0


A Feature-Rich and UnauthorizedAccessException-Free Traversal Library for files and directories for .NET framework 4.5 above. This library guarantees no exception will be thrown while traversing certain path either for files or sub directories. This library is motivated by default .NET files/directories where when we traverse directories to get files or folders and we hit unauthorized access folder, an exception will be thrown and traversal will complete unexpectedly. So far, we have to define our own logic to traverse files and folders using default methods that .NET offers. Therefore, instead of repeating the task, we offer complete library for traversal with added features in secure way. Utilizing default methods for traversal in System.IO, we wrapped everything nicely into a complete library called **System.IO.SafeTraversal**.

Core features that we offer:
* Support Traversal that returns IEnumerable of FileInfo, DirectoryInfo and string objects.
* No exception will be thrown during traversal either because of UnauthorizedAccessException or other exceptions (Except if you pass in invalid parameters to certain method).
* Support logging mechanism using List of string to inspect any error occured during traversal.
* Support top level and all directories scanning.
* Support extension methods for DirectoryInfo class.
* Support parents traversal in DirectoryInfo extension method.
* Support totally safe Files Traversal mechanism for NTFS file system by utilizing Access Control Type checking. Traversal will be slower than default option, but the result (IEnumerable of FileInfo) can be used directly for IO Operations. Ensuring no Deny access within the result of traversal.
* Support synchronous and asynchronous traversal operations (Only for IEnumerable of FileInfo and DirectoryInfo).

Advanced filtering features:
* Filter by name with case sensitive and include extension properties.
* Filter by common size. It's like windows explorer size filtering. (Empty, Tiny, Small,...Gigantic).
* Filter by defined size. You can pass any unit that you want. Such as Bytes, KiloBytes .... PetaBytes.
* Filter by defined size range. You can pass any unit that you want. Such as Bytes, KiloBytes .... PetaBytes.
* Filter by date. Based on creation date, modified date, last access date.
* Filter by date range. Based on creation date, modified date, last access date too.
* Filter by .NET Regular Expression pattern. With option, include extension or not.
* Filter by composite option. It's multiple search criteria. You can combine to search based on date, size, regex pattern, extension, name and so on.
* Filter by FileAttributes.

-----

### Target Framework
**.NET Framework 4.5** Above.

Dependencies:
* System.IO;
* System.Collections.Generic;
* System.Security.AccessControl;
* System.Security.Principal;
* System.Threading.Tasks;
* System.Linq;
* System.Text.RegularExpressions;


### License
[GNU General Public License v3.0](https://github.com/mirzaevolution/System.IO.SafeTraversal/blob/master/LICENSE)


Best Regards,

**Mirza Ghulam Rasyid**

