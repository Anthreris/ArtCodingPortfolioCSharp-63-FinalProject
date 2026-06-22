SELECT * FROM artprojects ORDER BY SortOrder;

-- INSERT INTO artprojects (Title, Description, ImagePath, SortOrder, IsHidden)
-- VALUES ("Basenji Pastel Sketch", "Oil Pastel dog sketch stylized as a superhero", "C:\Users\Garrett Chitwood\Desktop\Images for Art & Coding Portfolio\Basenji Pastel Sketch.jpg", 1, 0);

-- create the database itself
-- CREATE DATABASE ArtCodingPortfolio;
-- set the default schema (database)
 -- USE ArtCodingPortfolio;
-- CREATE TABLE ArtProjects (
 -- ArtPieceID INT NOT NULL AUTO_INCREMENT,
 -- Title VARCHAR(255) NOT NULL,
 -- Description TEXT,
 -- ImagePath VARCHAR(500),
 -- DateAdded DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
 -- SortOrder INT NOT NULL DEFAULT 0,
 -- IsHidden TINYINT(1) NOT NULL DEFAULT 0,
 -- PRIMARY KEY (ArtPieceID)
-- );

-- CREATE TABLE CodeProjects (
-- CodeProjectID INT NOT NULL AUTO_INCREMENT,
-- Title VARCHAR(255) NOT NULL,
-- Description TEXT,
-- TechStack VARCHAR(255),
-- GitHubUrl VARCHAR(500),
-- DateAdded DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
-- SortOrder INT NOT NULL DEFAULT 0,
-- IsHidden TINYINT(1) NOT NULL DEFAULT 0,
-- PRIMARY KEY (CodeProjectID)
-- );