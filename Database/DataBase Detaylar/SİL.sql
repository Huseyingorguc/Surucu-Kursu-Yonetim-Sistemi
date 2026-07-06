CREATE PROCEDURE sp_OgrenciSil  @TCNo NVARCHAR(11) ,@Mesaj NVARCHAR(100) OUTPUT, @Kod INT OUTPUT      
AS
BEGIN
IF EXISTS (SELECT * FROM Ogrenci WHERE TCNo = @TCNo)
BEGIN
    DELETE FROM Ogrenci WHERE TCNo = @TCNo;
    SET @Mesaj = 'Öðrenci baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir öðrenci kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_OgrenciSil @TCNo = 12345673301,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;
SELECT @mesaj AS Mesaj, @kod AS Kod;    
    
 
CREATE PROCEDURE sp_EgitmenSil @Ad NVARCHAR(50),@Soyad NVARCHAR(50),@Mesaj NVARCHAR(100) OUTPUT,@Kod INT OUTPUT       
AS
BEGIN
IF EXISTS (SELECT * FROM Egitmen WHERE Ad = @Ad AND Soyad = @Soyad)
BEGIN
    DELETE FROM Egitmen WHERE  Ad = @Ad AND Soyad = @Soyad;
    SET @Mesaj = 'Eðitmen baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir eðitmen kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_EgitmenSil  @Ad = ahmet,@Soyad=yamaç,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;
SELECT @mesaj AS Mesaj, @kod AS Kod;   

CREATE PROCEDURE sp_DersSil @DersAdi NVARCHAR(100), @DersTuru NVARCHAR(50),@Mesaj NVARCHAR(100) OUTPUT,@Kod INT OUTPUT       
AS
BEGIN
IF EXISTS (SELECT 1 FROM Ders WHERE DersAdi = @DersAdi AND DersTuru = @DersTuru)
BEGIN
    DELETE FROM Ders WHERE DersAdi = @DersAdi AND DersTuru = @DersTuru;
    SET @Mesaj = 'Ders baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir ders kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_DersSil @DersAdi=Sürücü,@DersTuru=Teorik,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;
SELECT @mesaj AS Mesaj, @kod AS Kod;    

CREATE PROCEDURE sp_OgrenciDersSil @OgrenciID INT,@DersID INT,@Mesaj NVARCHAR(100) OUTPUT,@Kod INT OUTPUT               
AS
BEGIN
IF EXISTS (SELECT 1 FROM OgrenciDers WHERE OgrenciID = @OgrenciID AND DersID = @DersID)
BEGIN
    DELETE FROM OgrenciDers WHERE OgrenciID = @OgrenciID AND DersID = @DersID;
    SET @Mesaj = 'Öðrenci ders kaydý baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir öðrenci-ders kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_OgrenciDersSil @OgrenciID = 1,@DersID = 3,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;    
SELECT @mesaj AS Mesaj, @kod AS Kod;     


CREATE PROCEDURE sp_OdemeSil @OdemeID INT,@Mesaj NVARCHAR(100) OUTPUT, @Kod INT OUTPUT          
AS
BEGIN
IF EXISTS (SELECT 1 FROM Odeme WHERE OdemeID = @OdemeID)
BEGIN
    DELETE FROM Odeme WHERE OdemeID = @OdemeID;
    SET @Mesaj = 'Ödeme kaydý baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir ödeme kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_OdemeSil @OdemeID = 1,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT; 
SELECT @mesaj AS Mesaj, @kod AS Kod; 



CREATE PROCEDURE sp_SinavSil @SinavID INT,@Mesaj NVARCHAR(100) OUTPUT,@Kod INT OUTPUT        
AS
BEGIN
IF EXISTS (SELECT 1 FROM Sinav WHERE SinavID = @SinavID)
BEGIN
    DELETE FROM Sinav WHERE SinavID = @SinavID;
    SET @Mesaj = 'Sýnav kaydý baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir sýnav kaydý bulunamadý.';
SET @Kod = 1;
END

DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_SinavSil @SinavID = 1,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;
SELECT @mesaj AS Mesaj, @kod AS Kod;    


CREATE PROCEDURE sp_AracSil @AracID INT,@Mesaj NVARCHAR(100) OUTPUT,@Kod INT OUTPUT           
AS
BEGIN
IF EXISTS (SELECT 1 FROM Arac WHERE AracID = @AracID)
BEGIN
    DELETE FROM Arac WHERE AracID = @AracID;
    SET @Mesaj = 'Araç kaydý baþarýyla silindi.';
    SET @Kod = 0;
    RETURN;
END
SET @Mesaj = 'Böyle bir araç kaydý bulunamadý.';
SET @Kod = 1;
END
  
DECLARE @mesaj NVARCHAR(100), @kod INT;
EXEC sp_AracSil @AracID = 1,@Mesaj = @mesaj OUTPUT,@Kod = @kod OUTPUT;
SELECT @mesaj AS Mesaj, @kod AS Kod;     



    



   

    
    




    
    




    



    
    





