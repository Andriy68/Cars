using Microsoft.EntityFrameworkCore.Migrations;

namespace DATA.Migrations
{
    public partial class SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @"CREATE PROCEDURE GetCars
                        AS
                        SELECT* FROM Cars
                        GO

                        CREATE PROCEDURE GetCar @Id int
                        AS
                        SELECT* FROM Cars WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddCar @Price int, @SellerID int
                        AS
                        INSERT INTO Cars(Price, SellerID) VALUES(@Price, @SellerID)
                        GO

                        CREATE PROCEDURE EditCar @Id int, @Price int, @SellerID int
                        AS
                        UPDATE Cars
                        SET Price = @Price, SellerID = @SellerID
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteCar @Id int
                        AS
                        DELETE FROM Cars
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetDescs
                        AS
                        SELECT* FROM Descriptions
                        GO

                        CREATE PROCEDURE GetDesc @Id int
                        AS
                        SELECT* FROM Descriptions
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddDesc @Brand nvarchar(MAX), @Color nvarchar(MAX), @CarID int
                        AS
                        INSERT INTO Descriptions(Brand, Color, CarID) VALUES(@Brand, @Color, @CarID)
                        GO

                        CREATE PROCEDURE EditDesc @Id int, @Brand nvarchar(MAX), @Color nvarchar(MAX), @CarID int
                        AS
                        UPDATE Descriptions
                        SET Brand = @Brand, Color = @Color, CarID = @CarID
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteDesc @Id int
                        AS
                        DELETE FROM Descriptions
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetCustomers
                        AS
                        SELECT* FROM Customers
                        GO

                        CREATE PROCEDURE GetCustomer @Id int
                        AS
                        SELECT* FROM Customers
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddCustomer @NameSurname nvarchar(MAX), @Contacts nvarchar(MAX)
                        AS
                        INSERT INTO Customers(NameSurname, Contacts) VALUES(@NameSurname, @Contacts)
                        GO

                        CREATE PROCEDURE EditCustomer @Id int, @NameSurname nvarchar(MAX), @Contacts nvarchar(MAX)
                        AS
                        UPDATE Customers
                        SET NameSurname = @NameSurname, Contacts = @Contacts
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteCustomer @Id int
                        AS
                        DELETE FROM Customers
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetOrders
                        AS
                        SELECT* FROM Orders
                        GO

                        CREATE PROCEDURE GetOrder @Id int
                        AS
                        SELECT* FROM Orders
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddOrder @CarID int, @CustomerID int
                        AS
                        INSERT INTO Orders(CarID, CustomerID) VALUES(@CarID, @CustomerID)
                        GO

                        CREATE PROCEDURE EditOrder @Id int, @CarID int, @CustomerID int
                        AS
                        UPDATE Orders
                        SET CarID = @CarID, CustomerID = @CustomerID
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteOrder @Id int
                        AS
                        DELETE FROM Orders
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetSellers
                        AS
                        SELECT* FROM Sellers
                        GO

                        CREATE PROCEDURE GetSeller @Id int
                        AS
                        SELECT* FROM Sellers
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddSeller @Contacts nvarchar(MAX)
                        AS
                        INSERT INTO Sellers(Contacts) VALUES(@Contacts)
                        GO

                        CREATE PROCEDURE EditSeller @Id int, @Contacts nvarchar(MAX)
                        AS
                        UPDATE Sellers
                        SET Contacts = @Contacts
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteSellers @Id int
                        AS
                        DELETE FROM Sellers
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetWorkers
                        AS
                        SELECT* FROM Workers
                        GO

                        CREATE PROCEDURE GetWorker @Id int
                        AS
                        SELECT* FROM Workers
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddWorker @NameSurname nvarchar(MAX), @Salary int
                        AS
                        INSERT INTO Workers(NameSurname, Salary) VALUES(@NameSurname, @Salary)
                        GO

                        CREATE PROCEDURE EditWorker @Id int, @NameSurname nvarchar(MAX), @Salary int
                        AS
                        UPDATE Workers
                        SET NameSurname = @NameSurname, Salary = @Salary
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteWorker @Id int
                        AS
                        DELETE FROM Workers
                        WHERE Id = @Id
                        GO";

            migrationBuilder.Sql(query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
