﻿CREATE TABLE [dbo].[barang] (
    [kodebarang] VARCHAR (10)  NOT NULL,
    [namabarang] VARCHAR (100) NOT NULL,
    [satuan]     VARCHAR (20)  NOT NULL,
    [harga]      BIGINT        NOT NULL,
    [stok]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([kodebarang] ASC)
);
