# Finance Tracker

Finance Tracker is a personal finance management application developed in C# that uses an SQL database for data storage.

## Technologies Used
- **C# (.NET Framework)** – Main programming language.  
- **SQL (MS SQL Server)** – Stores income, expenses, and transaction categories.  
- **Entity Framework** – ORM for database operations.  
- **BCrypt** – Secure password hashing.  
- **Windows Forms / WPF** – User interface.  

## Database Structure

The database `DataBase.mdf` consists of three main tables:

### **dbo.Accounts**
Stores information about user financial accounts.
- **Id** *(Primary Key, int)* – Unique account identifier.
- **BankName** *(nvarchar)* – Bank name.
- **Name** *(nvarchar)* – Account owner’s name.
- **Money** *(decimal)* – Account balance.
- **IsChoose** *(bit)* – Indicates if the account is currently selected.

### **dbo.Categories**
Stores different transaction categories.
- **Id** *(Primary Key, int)* – Unique category identifier.
- **Name** *(nvarchar)* – Category name.

### **dbo.Transactions**
Stores financial transactions.
- **Id** *(Primary Key, int)* – Unique transaction identifier.
- **Date** *(datetime)* – Transaction date.
- **Category** *(Foreign Key → dbo.Categories.Id, int)* – Transaction category.
- **Payee** *(nvarchar)* – Recipient of the payment.
- **Amount** *(decimal)* – Transaction amount.
- **Account** *(Foreign Key → dbo.Accounts.Id, int)* – Associated account.

## Features
- Add, edit, and delete income and expenses.  
- Categorize transactions.  
- Secure authentication with bcrypt.  
- Financial data analysis and reports.  

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Lertrex/Finance-Tracker.git
   ```
2. Open the project in **Visual Studio**.  
3. Configure the database connection.  
4. Build and run the application.  

## License
This project is licensed under the MIT License.
