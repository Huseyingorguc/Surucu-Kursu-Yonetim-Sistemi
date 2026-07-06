CREATE UNIQUE INDEX IX_Arac_Plaka ON Arac(Plaka);

CREATE UNIQUE INDEX IX_Ogrenci_TCNo ON Ogrenci(TCNo);

CREATE INDEX IX_Ogrenci_AdSoyad ON Ogrenci(Ad, Soyad);

CREATE CLUSTERED INDEX IX_OgrenciID ON Ogrenci(OgrenciID);

CREATE NONCLUSTERED INDEX IX_Telefon ON Ogrenci(Telefon);

CREATE NONCLUSTERED INDEX IX_DersAdi_Turu ON Ders(DersAdi, DersTuru);


CREATE UNIQUE INDEX IX_OGR ON ogrenci (telefon)

CREATE UNIQUE INDEX IX_EGIT ON Egitmen (telefon)



