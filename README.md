# System.IO.SafeTraversal v2.0.0


A Feature-Rich and UnauthorizedAccessException-Free Traversal Library for files and directories for .NET framework 4.5 above. This library guarantees no exception will be thrown while traversing certain path either for files or sub directories. This library is motivated by default .NET files/directories where when we traverse directories to get files or folders and we hit unauthorized access folder, an exception will be thrown and traversal will complete unexpectedly. So far, we have to define our own logic to traverse files and folders using default methods that .NET offers. Therefore, instead of repeating the task, we offer complete library for traversal with added features in secure way. Utilizing default methods for traversal in System.IO, we wrapped everything nicely into a complete library called System.IO.SafeTraversal.

---

**System.IO.SafeTraversal v2.0.0** comes with safer and faster query against file system than previous version (1.1.0). In this version, a few bugs were fixed. Error log will be handed to an event that users can subscribe. Unsafe asynchronous operations have been removed. And supports custom filtering that ensures no exception will be thrown although there's an exception inside custom filter. It also supports .NET Core 2.0.

---

#### Core features that we offer:

* Support Traversal that returns IEnumerable of FileInfo, DirectoryInfo and string objects.
* No exception will be thrown during traversal either because of UnauthorizedAccessException or other exceptions (Except if you pass in invalid parameters to certain method).
* Support logging mechanism using event to inspect any error occured during traversal.
* Support top level and all directories scanning.
* Support extension methods for DirectoryInfo class.
* Support parents traversal for files and folders.
* Support totally safe Files Traversal mechanism for NTFS file system by utilizing Access Control Type checking. Traversal will be slower than default option, but the result (IEnumerable of FileInfo) can be used directly for IO Operations. Ensuring no Deny access within the result of traversal (For .NET framework only. .NET Core does not support this feature).


#### Advanced filtering features:

* Filters by name with case sensitive and include extension properties.
* Filters by common size. It's like windows explorer size filtering. (Empty, Tiny, Small,...Gigantic).
* Filters by defined size. You can pass any unit that you want. Such as Bytes, KiloBytes .... PetaBytes.
* Filters by defined size range. You can pass any unit that you want. Such as Bytes, KiloBytes .... PetaBytes.
* Filters by date. Based on creation date, modified date, last access date.
* Filters by date range. Based on creation date, modified date, last access date too.
* Filters by .NET Regular Expression pattern. With option, include extension or not.
* Filters by composite option. It's multiple search criteria. You can combine to search based on date, size, regex pattern, extension, name and so on.
* Filters by FileAttributes.
* Filters by custom filter. Allowing developers to create custom filter using FileInfo and DirectoryInfo classess. This custom filter is totally safe although you pass an exception inside this filter.


**NOTE: We don't support System.IO.SafeTraversal v1.1.0 anymore. That project was an experimental project. We recommend to use this version (2.0.0) instead of the previous one.**


### License
[GNU General Public License v3.0](https://github.com/mirzaevolution/System.IO.SafeTraversal/blob/master/LICENSE)


### Install from [Nuget.Org](https://www.nuget.org/packages/SafeTraversal/2.0.0)

```
PM> Install-Package SafeTraversal -Version 2.0.0
```
