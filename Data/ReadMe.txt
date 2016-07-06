This project is designed to initialize and build the database with all necessary mappings and constraints.

I. Classes
	1. Contain all files necessary to correctly build mapped in the diagram without constraints

II. Context
	1. Contains the main context of the database
	2. Builds database
	3. Builds all migrations in migrations folder.

III. Mappings
	1. Contains all Fluent API mappings for each class
		A. Organized by class name
	2. Contains all restrictions

IV. Migrations
	1. Contains all migrations to correclty build database
		A. Configuration.cs seeds data from resources
		B. Configuration.cs sets seed indentity to zero for multiple tables.

V. Resources
	1. Contains seed data
		A. Organized by class name
		B. Must be 'csv' files.