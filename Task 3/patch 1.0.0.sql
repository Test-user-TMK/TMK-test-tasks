USE ordersDB;
GO

ALTER TABLE orders
ADD FOREIGN KEY (manufacturer_id) REFERENCES manufacturers(id);
GO

ALTER TABLE orders
ADD FOREIGN KEY (state_id) REFERENCES states(id);
GO

ALTER TABLE positions
ADD FOREIGN KEY (steel_type_id) REFERENCES steel_types(id);
GO

ALTER TABLE positions
ADD FOREIGN KEY (state_id) REFERENCES states(id);
GO

ALTER TABLE positions
ADD FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE;
GO