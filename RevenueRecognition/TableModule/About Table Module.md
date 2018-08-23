# Table Module

## How it Works

- Organizes domain logic with one class per table in the database
- Easy integration with relational database
- A single instance of a class contains the various procedures that will act on the data
- Primary distinction with Domain Model is that Domain Model will have one object per table record,
  whereas Table Module will have one object to handle all rows.
- Allows you to package data and behavior together and at the same time play to the strengths of a relational database
- A Table Module object has no notion of an identity
- Normally use Table Module with a backing data structure that's table-oriented (.NET DataSet, DataTable)
- Gives you and explicit method-based interface that acts on the data
- You can have Table Modules for interesting queries and views in the database as well as for tables
- Table Module may be an instance or a collection of static methods
- May include queries as factory methods or use Table Data Gateway
- With Table Data Gateway, first use gateway to assemble data in Record Set,
  then create Table Module with Record Set as an argument. There may be a chain
  of Table Modules operating on the Record Set and passing it on.

## When to Use It

- When working on table-oriented data
- Not too complex domain logic
- Example use: Microsoft COM designs, where Record Set is the primary repository of data in an application
- If objects in Domain Model and database tables are similar, use Domain Model and Active Record instead
