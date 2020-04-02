-- MongoDB : SQL   -->  Collection  :  Table
-- id VARCHAR(255) NOT NULL UNIQUE,

-- NOTE Burgers table
-- CREATE TABLE burgers
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR (255) NOT NULL,
--   description VARCHAR (255) NOT NULL,
--   price   DECIMAL (5,2),

--   PRIMARY KEY(id)
-- )

-- POSTs
-- INSERT INTO burgers 
-- ( name, description, price)
-- VALUES ("MarkBurg", "Extra Cheesy", 7.54);

-- INSERT INTO burgers
--   ( name, description, price)
-- VALUES
--   ("ZackBurg", "Extra Cheesy w/ bacon", 7.54);
--   INSERT INTO burgers
--   ( name, description, price)
-- VALUES
--   ("DarrylBurg", "All the meats", 7.54);

-- Get
-- SELECT * FROM burgers;

-- GetbyID
-- SELECT * FROM burgers WHERE id = 2;

-- SELECT * FROM burgers
-- WHERE name = "MarkBurg";

-- NOTE without WHERE statement will remove all burgers from table
-- Delete
-- DELETE FROM burgers WHERE id=2;

-- NOTE danger zone
-- DROP TABLE burgers

-- PUT
-- NOTE 
-- UPDATE burgers SET name = "Mark Jr" WHERE id=1;

