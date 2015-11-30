drop table TempBidder;
CREATE TABLE TempBidder
(
bidId int IDENTITY (1, 1),
email VARCHAR(50),
itemId VARCHAR(50) ,
winningStatus VARCHAR(50),
paymentStatus VARCHAR(50),
bidAmount VARCHAR(50),
phoneNum VARCHAR(50),
PRIMARY KEY (bidId)
);



INSERT INTO TempBidder
VALUES ('nivedita.mits@gmail.com','CT9','Under Process','No',500,'3097505527');



INSERT INTO TempBidder
VALUES ('nivedita.mits@gmail.com','CT10','Under Process','No',500,'3097505527');


INSERT INTO TempBidder
VALUES ('nikunj.ratnaparkhi@gmail.com','G7','Under Process','No',5000,'3097505527');