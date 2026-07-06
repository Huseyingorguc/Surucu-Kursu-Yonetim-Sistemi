CREATE TABLE AracLog (
LogID INT PRIMARY KEY IDENTITY(1,1),
AracID INT,
Plaka NVARCHAR(20),
Marka NVARCHAR(50),
Model NVARCHAR(50),
KullanilanDersID INT,
IslemTuru NVARCHAR(10),
IslemTarihi DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_AracSil
ON Arac AFTER DELETE AS
BEGIN
    INSERT INTO AracLog (AracID, Plaka, Marka, Model, KullanilanDersID, IslemTuru)
    SELECT AracID, Plaka, Marka, Model, KullanilanDersID, 'Sil' FROM deleted;   
END

CREATE TRIGGER trg_AracGuncelle
ON Arac AFTER UPDATE AS
BEGIN
    INSERT INTO AracLog (AracID, Plaka, Marka, Model, KullanilanDersID, IslemTuru)
    SELECT AracID, Plaka, Marka, Model, KullanilanDersID, 'Guncelle'
    FROM deleted;
END


CREATE TABLE OgrenciLog (
LogID INT PRIMARY KEY IDENTITY(1,1),
OgrenciID INT,
Ad NVARCHAR(50),
Soyad NVARCHAR(50),
TCNo CHAR(11),
Telefon NVARCHAR(20),
KayitTarihi DATETIME,
Islem NVARCHAR(10), 
IslemTarihi DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_OgrenciSil
ON Ogrenci AFTER DELETE AS
BEGIN
    INSERT INTO OgrenciLog (OgrenciID, Ad, Soyad, TCNo, Telefon, KayitTarihi, Islem)
    SELECT OgrenciID, Ad, Soyad, TCNo, Telefon, KayitTarihi, 'SIL'
    FROM deleted;
END

CREATE TRIGGER trg_OgrenciGuncelle
ON Ogrenci AFTER UPDATE AS
BEGIN
    INSERT INTO OgrenciLog (OgrenciID, Ad, Soyad, TCNo, Telefon, KayitTarihi, Islem)
    SELECT OgrenciID, Ad, Soyad, TCNo, Telefon, KayitTarihi, 'GUNCELLE'
    FROM deleted;
END


CREATE TABLE EgitmenLog
(
LogID INT PRIMARY KEY IDENTITY(1,1),
EgitmenID INT,
Ad NVARCHAR(50),
Soyad NVARCHAR(50),
Brans NVARCHAR(50),
Telefon NVARCHAR(20),
Islem NVARCHAR(20),
IslemTarihi DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_EgitmenSil
ON Egitmen FOR DELETE AS
BEGIN
    INSERT INTO EgitmenLog (EgitmenID, Ad, Soyad, Brans, Telefon, Islem, IslemTarihi)
    SELECT EgitmenID, Ad, Soyad, Brans, Telefon, 'SIL', GETDATE()
    FROM DELETED;
END;

CREATE TRIGGER trg_EgitmenGuncelle
ON Egitmen FOR UPDATE AS
BEGIN
    INSERT INTO EgitmenLog (EgitmenID, Ad, Soyad, Brans, Telefon, Islem, IslemTarihi)
    SELECT EgitmenID, Ad, Soyad, Brans, Telefon, 'GUNCELLE', GETDATE()
    FROM DELETED;
END;

CREATE TABLE OdemeLog
(
LogID INT PRIMARY KEY IDENTITY(1,1),
OdemeID INT,
OgrenciID INT,
Tutar DECIMAL(10,2),
OdemeTarihi DATETIME,
Aciklama NVARCHAR(200),
Islem NVARCHAR(20),
IslemTarihi DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_OdemeSil
ON Odeme FOR DELETE AS
BEGIN
    INSERT INTO OdemeLog (OdemeID, OgrenciID, Tutar, OdemeTarihi, Aciklama, Islem, IslemTarihi)
    SELECT OdemeID, OgrenciID, Tutar, OdemeTarihi, Aciklama, 'SIL', GETDATE()
    FROM DELETED;
END;

CREATE TRIGGER trg_OdemeGuncelle
ON Odeme FOR UPDATE AS
BEGIN
    INSERT INTO OdemeLog (OdemeID, OgrenciID, Tutar, OdemeTarihi, Aciklama, Islem, IslemTarihi)
    SELECT OdemeID, OgrenciID, Tutar, OdemeTarihi, Aciklama, 'GUNCELLE', GETDATE()
    FROM DELETED;
END;
