-- -- Note flowers
-- CREATE TABLE flowers(
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,
--   PRIMARY KEY(id)
-- );

-- -- NOte boquets
-- CREATE TABLE bouquets(
--   id INT NOT NULL AUTO_INCREMENT,
-- name VARCHAR(255) NOT NULL,
-- description VARCHAR(255),
--   PRIMARY KEY(id)
-- );

-- ALTER TABLE bouquets
-- ADD price DECIMAL(8,2);

-- NOTE flowerbouquets  (reference other tables)
-- CREATE TABLE flowerbouquets(
--   id INT NOT NULL AUTO_INCREMENT,
--   flowerId INT NOT NULL,
--   bouquetId INT NOT NULL,
--   PRIMARY KEY(id),

--   FOREIGN KEY (flowerId)
--     REFERENCES flowers(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (bouquetId)
--     REFERENCES bouquets(id)
--     ON DELETE CASCADE
-- );


-- INSERT INTO flowers (name, price) VALUES ('red rose', .56);
-- INSERT INTO flowers (name, price) VALUES ('yellow rose', .57);
-- INSERT INTO flowers (name, price) VALUES ('pink rose', .58);
-- INSERT INTO flowers (name, price) VALUES ('white rose', .59);
-- INSERT INTO flowers (name, price) VALUES ('baby breath', .60);
-- INSERT INTO flowers (name, price) VALUES ('yellow tulip', .65);

-- INSERT INTO bouquets (name, description, price) VALUES("I am Sorry", "I messed up flowers", 19.99)
-- INSERT INTO bouquets (name, description, price) VALUES ("I Love You", "A dozen red roses", 21.99);
-- INSERT INTO bouquets (name, description, price) VALUES ("Just Friends", "A Mixture of roses", 17.99);

-- -- NOTE I am sorry boquet with 6 pink roses
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 1);
-- -- NOTE I love you with 6 red roses
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 2);
-- -- NOTE Different flowers in Just Friends
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (1, 3);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (2, 3);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (3, 3);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (4, 3);
-- INSERT INTO flowerbouquets (flowerId, bouquetId) VALUES (5, 3);



--  -- NOTE Get data
-- SELECT * FROM flowers;
-- SELECT * FROM bouquets;
-- SELECT * FROM flowerbouquets;
-- NOTE Get flowers in bouquet

-- SELECT f.* FROM flowerbouquets fb
-- INNER JOIN flowers f ON f.id = fb.flowerId
-- WHERE bouquetId = 3;

-- NOTE Get all boquets that have a flower in them
-- SELECT * FROM flowerbouquets fb
-- INNER JOIN bouquets b ON b.id = fb.bouquetId
-- WHERE flowerId = 5;

-- CREATE INDEX getFlowers ON flowerbouquets (bouquetId);