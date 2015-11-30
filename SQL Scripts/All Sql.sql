drop table signuptable;
drop table signintable;

CREATE TABLE signuptable (
firstname VARCHAR(50), 
lastname VARCHAR(50),
address VARCHAR(200),
city VARCHAR(50),
country VARCHAR(50),
state VARCHAR(50),
zip VARCHAR(10),
homePhone VARCHAR(50),
cellPhone VARCHAR(50),
email VARCHAR(50),
password VARCHAR(50),
imagePath VARCHAR(200),
enableTextMsg VARCHAR(50),
subscribeEmail VARCHAR(50)
); 

CREATE TABLE signintable (email VARCHAR(50) PRIMARY KEY,
 password VARCHAR(50));

--ALTER TABLE signuptable ADD permission varchar(50);
--ALTER TABLE signuptable ADD permission varchar(50);
--ALTER TABLE auctionitemstable ALTER COLUMN angelPrice varchar(50);