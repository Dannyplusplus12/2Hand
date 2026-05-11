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
- None

## Implemented Utilities
- SampleDataGenerator for UI test data

## Implemented UI
- Inventory sample data button to render mock cards

## Implemented UI
- MainForm shell with sidebar, header, theme, and view switching
- Dashboard, Inventory, Customer, Transaction view scaffolds

## Pending Tasks
- Configure SQLite connection and migrations
- Wire up UI views with data, CRUD, and navigation actions
- Implement product image center-crop handling and placeholders
- Implement transactions workflow with cart, validation, payment popup, and stock deduction in a transaction
- Add dashboard metrics and recent transactions navigation
