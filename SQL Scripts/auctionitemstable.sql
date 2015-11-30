drop table auctionitemstable;
CREATE TABLE [dbo].[auctionitemstable] (
    [itemType]       VARCHAR (5)   NOT NULL,
    [itemNumber]     INT           IDENTITY (1, 1) NOT NULL,
    [category]       VARCHAR (50)  NULL,
    [itemDesc]       VARCHAR (200) NULL,
    [designer]       VARCHAR (50)  NULL,
    [estimatedValue] VARCHAR (50)  NULL,
    [minBid]         VARCHAR (50)  NULL,
    [angelPrice]     VARCHAR (50)  NULL,
    [itemImagePath]  VARCHAR (200) NULL,
    [purchasePrice]  VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([itemType] ASC, [itemNumber] ASC)
);