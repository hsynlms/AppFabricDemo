1.What is the AppFabricDemo class?
=============
The AppFabricDemo class provides you manage cache servers, regions, objects in caches. Included lots of methods which you need. This tiny class makes your work easy while developing AppFabric ASP.NET applications. Do not need to write more code.

2.How it works?
=============
There are many methods in the class. Just specify your cache servers with host and port information and then connect them. After this, use the methods with correct parameters to do anything what you want. If something goes wrong because of parameters or anything else, AppFabricDemo class throws an exception.

3.How to use?
=============
A sample usage below. Check it out.
AppFabric demo = new AppFabric("localhost", 22233);
3 overloaded constructors have been implemented. Lets choose one of them to do first connection your server.

3.1.Constructors
AppFabricDemo class provides you 3 overloaded constructors.
First one, just put the host name/ip (string) and its port number (integer) as parameter.
Second one, create a DataCacheServerEndpoint variable, set host name/IP and port number and put the variable as parameter.
Third one, create a List<DataCacheServerEndpoint> and put your server names/IPs and their ports for each items. And put it to the construction parameter.

3.2.Getting data from your cache server
AppFabricDemo class makes getting data from the servers very simple and functional. 3 overloaded methods are ready in the class. No more code required, just call a method to do this action. Here is a sample:
demo.GetData("name", "AppFabric");
First parameter is your unique Key and the second one is your Value. Value could be CLR objects, or any variable and your Binary data.
For other overloaded method's parameters could be different.

3.3.Adding data to your cache server
Another method is add data. We made this very simple and functional. 6 overloaded methods are ready in the class. No more code required, just call a method to do this action. Here is a sample:
demo.SetData("job", "developer");
First parameter is your Key, required for adding data to the cache server. Second one is your Value. Key must be unique. You could not identify existing key name again.
For other overloaded method's parameters could be different.

3.4.Update existing data
6 overloaded methods implemented for updating existing data. Select one of them to do this action. A sample is below:
demo.PutData("job", "artist");
First parameter is your unique Key and the second one is your new Value.
For other overloaded method's parameters could be different.

3.5.Remove data from the server
3 overlaoded methods are ready for use. Just pick one amoung them. Here is a sample:
demo.RemoveEntry("job");
There is just one parameter, it is your unique Key.
For other overloaded method's parameters could be different.

3.6.GetObjects
This method provides you get all objects from the specific region. You can filter this action with getting data by the tags. Here is a sample:
demo.GetObjects("user");
Region Name is only needed parameter to get all objects.
For other overloaded method's parameters could be different.

3.7.ClearRegions
It clears all regions data. Check this usage sample:
demo.ClearRegions();
There is no any required parameter to use this method.

3.8.ClearRegion
It removes all data from specified region. Here is a sample:
demo.ClearRegion("account");
The only required parameter is Region Name.

3.9.Remove specific region from the cache server
It removes specified region from the cache server. Here is a sample:
demo.RemoveRegion("catalog");
The only required parameter is Region Name.

3.10.Remove all regions from the cache server
RemoveRegions is a method that removes all regions in the connected cache server. It has no parameter. Here is a usage sample:
demo.RemoveRegions();

3.11.Create a region in the cache server
It is a method that you can create region in the cache server. 2 overloaded methods are ready to do the action.
demo.CreateRegion("product");
First parameter is Region Name which is required to entitle the region.
For other overloaded method's parameters could be different.
