# Project Context

## Structure
- Models
- Data
- Services
- Views
- Assets

## Database Schema
- Products: Id, Name, Description, Price, Quantity, ImagePath
- Customers: Id, FullName, Phone, Address
- Transactions: Id, CustomerId, CreatedAt, TotalAmount
- TransactionItems: Id, TransactionId, ProductId, Quantity, UnitPrice

## Implemented Services
- ProductService
- CustomerService
- TransactionService
- DbContextFactory for SQLite 2hand_data.db

## Implemented Utilities
- SampleDataGenerator for UI test data

## Implemented UI
- MainForm shell with sidebar and simplified header
- Dashboard, Inventory, Customer, Transaction view scaffolds
- Inventory split layout with add form, CRUD list, and search filter
- Customer list with transaction history cards
- Transaction view checkout workflow and payment popup
- Dashboard metrics and recent transactions

## Pending Tasks
- Wire up remaining UI views with data and navigation actions
