# SoftwareVersionManager
Simple filterable list of software versions

# Technologies/Packages
* ASP.NET Core 5
* Vue.js
* Axios JS REST package

# Running the project
Using the Visual Studio Start Debugging (F5) command will immediately load the end-user list view.

# Assumptions
* The implementation assumes that major, minor, and patch components of the version number are always integer.  A real-life customer should be consulted to confirm this before development, as permitting other characters would require us to consult with them on the proper sort order (i.e. if letters are permitted, do letters or numbers come first in the sort order.)
* While the client provided us with classes for the Software and the data access, I am assuming it is fine to modify it for our purposes.  This was to make it easier to decompose and search by the version numbers and represent the Software in a more domain-driven way.  If the client were providing us this code through a NuGet package, we may need to use it as-is and transform it to our own classes as needed.
* I am making the assumption that the number of Softwares will remain small.  If there were a large number of Softwares, it would be more performant to store them in a database with the major, minor, and patch components as separate fields to implement an index on those fields to efficiently search and return only the Software the end user requires.

# Potential improvements
* Implement client-side package management and module bundling (through npm and webpack).
* Add sorting feature to the list.
* Unit test the SoftwareController and the client-side code.
* Decompose the UI list and code into Vue components.
