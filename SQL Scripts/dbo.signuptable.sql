﻿CREATE TABLE [dbo].[signuptable] (
    [firstname]      VARCHAR (50)  NULL,
    [lastname]       VARCHAR (50)  NULL,
    [address]        VARCHAR (200) NULL,
    [city]           VARCHAR (50)  NULL,
    [country]        VARCHAR (50)  NULL,
    [state]          VARCHAR (50)  NULL,
    [zip]            VARCHAR (10)  NULL,
    [homePhone]      VARCHAR (50)  NULL,
    [cellPhone]      VARCHAR (50)  NULL,
    [email]          VARCHAR (50)  NULL,
    [password]       VARCHAR (50)  NULL,
    [imagePath]      VARCHAR (200) NULL,
    [enableTextMsg] VARCHAR(50) NULL, 
    [subscribeEmail] VARCHAR(50) NULL, 
    FOREIGN KEY ([email]) REFERENCES [dbo].[signintable] ([email])
);
