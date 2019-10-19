# Assignment 3: Simple REST Service

You need to implement a REST Service. The service should implement simple CRUD operation for the model class Book (Task 1), ie the 5 default methods that come with the template.

The REST service must have a static list of books in the controller.

Be aware of Book Do not have an ID, but you must use Isbn13 as a unique identification of a book, ie. you need to modify some of the CRUD methods to use string isbn13 instead of int id.
