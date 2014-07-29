CREATE TABLE Products(ID int primary key, Name varchar, Type varchar)
CREATE TABLE Contracts(ID int primary key, Product int, Revenue decimal, DateSigned date)
CREATE TABLE RevenueRecognitions(Contract int, Amount decimal, RecognizedOn date, PRIMARY KEY(Contract, jRecognizedOn))