CREATE TABLE Products (
	Id INT PRIMARY KEY,
	Name TEXT
);

INSERT INTO Products
VALUES
	(1, 'p1'),
	(2, 'p2'),
	(3, 'p3');

CREATE TABLE Categories (
	Id INT PRIMARY KEY,
	Name TEXT
);

INSERT INTO Categories
VALUES
	(1, 'c1'),
	(2, 'c2'),
	(3, 'c3');

CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO ProductCategories
VALUES
	(1, 1),
	(1, 3),
	(2, 2);

SELECT P.Name, C.Name
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON PC.CategoryId = C.Id;