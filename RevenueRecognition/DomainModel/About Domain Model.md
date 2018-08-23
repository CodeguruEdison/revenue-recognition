# Domain Model

## How it Works

- A Domain Model mingles data and process
- A simple Domain Model looks very much like the database design
- A rich Domain Model can look different from the database design, with inheritance, strategies and other patterns
- A rich Domain Model is better for more complex logic, but is harder to map to the database
- A simple Domain Model can use Active Record
- A rich Domain Model requires Data Mapper
- We want the minimum of coupling from the Domain Model to other layers

## When to Use It

- When you have complicated and everchanging business rules involving validation, calculations and derivations
- For simpler problems, use Transaction Script
- Beware: learning how to design and use a Domain Model is a significant exercise
- When using Domain Model, also consider using Service Layer to give your Domain Model a more distinct API
