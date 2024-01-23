CREATE TABLE [dbo].[pembelian] (
    [kode]       VARCHAR (10) NOT NULL,
    [kodebarang] VARCHAR (10) NOT NULL,
    [jumlah]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([kode] ASC)
);

