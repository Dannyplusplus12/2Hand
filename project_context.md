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
- Inventory split layout with add form, sample data rendering, and search filter
- Customer transaction cards with dropdown details

## Pending Tasks
- Wire up UI views with data, CRUD, and navigation actions
- Implement transactions workflow with cart, validation, payment popup, and stock deduction in a transaction
- Add dashboard metrics and recent transactions navigation
