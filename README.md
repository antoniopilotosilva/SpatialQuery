# Spatial Query

Spatial Query is a programming exercise around a WebAPI for some common geographical calculations and queries, like calculating distances or areas, or locating features of given attributes near or inside some geographical shape. The initial idea was specified in the "Distance between two points - level I.docx" document, on specifications folder, but after implementing the basis I went ahead and elaborated more.

The classes around the extra development are not implemented, that are just placeholders to ilustrate how the development would proceed. Additional projects would be created, e.g. SpatialQueries.Strategies.Areas to implement the calculation of areas, or SpatialQueries.Strategies.Locator to implement the querying of features within specified distance of a given shape (usually called buffers). The later would include SQL queries to some repository, like a database, containing the coordinates, category and other attributes of the features to locate. An intermediate project SpatialQueries.Strategies.Buffers would be required by the Locator to generate the buffers accordingly the given shape. And etc., etc.

The majority of the classes are very small, as I believe classes should be small and doing little bits. If a class requires more than one or two "page down" and it's meaning cannot be understood by its name, and the names of properties and methods, then that class is probably doing more than one thing, thus increasing the maintenance effort and the probability of bugs.

The exception handling is on the controllers, on the SpatialQuery.WebAPI, which is the layer liaisoning with the client. Again, I don't believe in catch for exceptions at many levels, except when really doing something when catching the exception, like retrying, applying a workaround or resorting to a fallback. Big no to log exceptions and throw it again, unless that happens on the final layer and some logging is advised.  