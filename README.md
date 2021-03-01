# Edu

* ### **Abstract Factory**
Customer company produces cars. The vehicle equipment consists of different types of engines, different wheel diameters and different suspensions. There are three types of configuration: economy, standard and extra. Implement a class that returns the desired set of parts, depending on the type of configuration.

##

* ### **Adapter**
You have class, which return list of books in XML format. And you have another class, which accept list of books in json format and return oldest book from the list. Implement class, which will help to use xml list of book as a provider of data for second class.
```
class Library
    method getBooksXML()

class BooksAnalyzer
    method getOldestBook(json booksList)
```
##

* ### **Facade**
You have next classes:
```
class VideoFile
    consturctor(string filename)

class MPEG4Codec implements Codec
    consturctor()

class OGGCodec implements Codec
    consturctor()

class VideoCoverter
    consturctor()
    method convert(VideoFile file, Codec codec)
```
Implement class that will provide simple interface with one method
```
class SimpleConverter
    methdod convert(string filename, string format)
```
##

* ### **Proxy**
You have a class that receives yesterday's exchange rate from an external resource.
```
interface IYesterdayRate
    method getRate()

class YesterdayRate implements IYesterdayRate
    method getRate()
```
Implement a class with the same interface that will cache the results of queries to an external resource?
##

* ### **Singleton**
Implement the class to work with the database. The class must be able to open a connection, execute queries and close the connection. Note that opening a connection is a long operation and you need to open a connection to the database, only once for the entire application.
