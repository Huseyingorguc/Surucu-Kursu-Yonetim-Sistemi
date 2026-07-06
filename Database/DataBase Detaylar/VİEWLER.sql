CREATE VIEW v_OgrenciSonOdeme AS
SELECT 
    O.OgrenciID,
    O.Ad + ' ' + O.Soyad AS OgrenciAdSoyad,
    P.Tutar,
    P.OdemeTarihi,
    P.Aciklama
FROM Ogrenci O JOIN  Odeme P ON O.OgrenciID = P.OgrenciID
WHERE  P.OdemeTarihi = (SELECT MAX(OdemeTarihi) FROM Odeme WHERE OgrenciID = O.OgrenciID);    
   
CREATE VIEW v_AracDersEgitmen AS
SELECT 
    A.Plaka,
    A.Marka,
    A.Model,
    D.DersAdi,
    E.Ad + ' ' + E.Soyad AS EgitmenAdSoyad
FROM Arac A JOIN  Ders D ON A.KullanilanDersID = D.DersID JOIN Egitmen E ON D.EgitmenID = E.EgitmenID;
   

CREATE VIEW v_EgitmenDersleri AS
SELECT 
    E.EgitmenID,
    E.Ad + ' ' + E.Soyad AS EgitmenAdi,
    E.Brans,
    D.DersID,
    D.DersAdi,
    D.DersTuru
FROM Egitmen E INNER JOIN  Ders D ON E.EgitmenID = D.EgitmenID;
    

   

 
    

