# The Revenue Recognition Problem

The code in this repository is a C# adaption of Martin Fowler's Java code samples in the book [Patterns of Enterprise Application Architecture](https://martinfowler.com/books/eaa.html), illustrating various design patterns (domain model, table module, transaction script, service layer, money) on a real-world problem (revenue recognition). I re-wrote this code as an exercise for myself in using these design patterns.

Martin Fowler writes:

> Revenue recognition is a common problem in business systems. It's all about when you can actually count the money you receive on your books. A simple case might be to collect the whole amount immediately, but often it has to be split up in parts that can be collected over a time period.

> The rules for revenue recognition are many, various and volatile. Some are set by regulation, some by professional standards, and some by
company policy. Revenue recognition ends up being quite a complex problem.

> This example code deals with a company that sells three kinds of products: word processors, databases and spreadsheets. According to the rules, when you sign a contract for a word processor you can book all the revenue right away. If it's a spreadsheet, you can book one-third today, one-third in sixty days and one-third in ninety days. If it's a database, you can book one-third today, one-third in thirty days, and one-third in sixty days.
