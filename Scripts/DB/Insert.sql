-- Insert into Products Table.
INSERT INTO "Products" ("CreatedOn", "UpdatedOn", "Name", "Description", "Price", "IsTaxable", "IsArchived") 
VALUES
(NOW(), NOW(), '10 LB Dark Roast', '10 LB bag of dark roast coffee beans', 100, true, false),
(NOW(), NOW(), '30 LB Dark Roast', '30 LB bag of dark roast coffee beans', 280, true, false),
(NOW(), NOW(), '50 LB Dark Roast', '50 LB bag of dark roast coffee beans', 450, true, false),
(NOW(), NOW(), '10 LB Light Roast', '10 LB bag of light roast coffee beans', 80, true, false),
(NOW(), NOW(), '30 LB Light Roast', '30 LB bag of light roast coffee beans', 260, true, false),
(NOW(), NOW(), '50 LB Light Roast', '50 LB bag of light roast coffee beans', 430, true, false);


-- Insert into Products Table.
INSERT INTO "ProductInventories" ("CreatedOn", "UpdatedOn", "QuantityOnHand", "IdealQuantity", "ProductId") 
VALUES
(NOW(), NOW(), 20, 24, 1),
(NOW(), NOW(), 12, 20, 2),
(NOW(), NOW(), 16, 20, 3),
(NOW(), NOW(), 9, 12, 4),
(NOW(), NOW(), 24, 12, 5),
(NOW(), NOW(), 0, 8, 6);