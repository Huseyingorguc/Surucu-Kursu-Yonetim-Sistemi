CREATE PROCEDURE sp_OgrenciListele
AS
BEGIN
    SELECT OgrenciID, TCNo, Ad, Soyad, Telefon, KayitTarihi 
    FROM Ogrenci
END


CREATE PROCEDURE sp_EgitmenListele
AS
BEGIN
    SELECT EgitmenID, Ad, Soyad, Brans, Telefon
    FROM Egitmen
END

CREATE PROCEDURE sp_DersListele
AS
BEGIN
SELECT 
    D.DersID, 
    D.DersAdi, 
    D.DersTuru, 
    E.Ad AS EgitmenAd, 
    E.Soyad AS EgitmenSoyad
FROM 
    Ders D
INNER JOIN 
    Egitmen E ON D.EgitmenID = E.EgitmenID
END

CREATE PROCEDURE sp_OgrenciDersListele
AS
BEGIN
    SELECT O.OgrenciID, O.Ad, O.Soyad, D.DersAdi, D.DersTuru
    FROM Ogrenci O
    INNER JOIN OgrenciDers OD ON O.OgrenciID = OD.OgrenciID
    INNER JOIN Ders D ON OD.DersID = D.DersID
    ORDER BY O.OgrenciID;
END
select*from ogrenci

CREATE PROCEDURE sp_OdemeListele
AS
BEGIN
SELECT 
    o.OdemeID,
    o.OgrenciID,
    CONCAT(ogr.Ad, ' ', ogr.Soyad) AS OgrenciAdiSoyadi,
    o.Tutar,
    o.OdemeTarihi,
    o.Aciklama
FROM 
    Odeme o
INNER JOIN 
    Ogrenci ogr ON o.OgrenciID = ogr.OgrenciID
ORDER BY 
    o.OdemeTarihi DESC;
END


CREATE PROCEDURE sp_SinavListele
AS
BEGIN
SELECT 
    s.SinavID,
    o.OgrenciID,
    o.Ad + ' ' + o.Soyad AS OgrenciAdi,
    s.SinavTuru,
    s.SinavTarihi,
    s.Sonuc
FROM 
    Sinav s
INNER JOIN 
    Ogrenci o ON s.OgrenciID = o.OgrenciID
ORDER BY 
    s.SinavTarihi DESC;
END

select*from Sinav