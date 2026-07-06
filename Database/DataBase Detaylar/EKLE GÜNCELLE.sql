CREATE PROCEDURE sp_OgrenciEkleGuncelle @TCNo CHAR(11),@Ad NVARCHAR(50),@Soyad NVARCHAR(50),@Telefon NVARCHAR(20),@KayitTarihi DATETIME
AS
BEGIN
 BEGIN TRY
   IF EXISTS (SELECT * FROM Ogrenci WHERE TCNo = @TCNo)
   BEGIN
     UPDATE Ogrenci SET Ad = @Ad,Soyad = @Soyad,Telefon = @Telefon,KayitTarihi = @KayitTarihi WHERE TCNo = @TCNo;
   END		
   ELSE			
   BEGIN			
      INSERT INTO Ogrenci (Ad, Soyad, TCNo, Telefon, KayitTarihi)	VALUES (@Ad, @Soyad, @TCNo, @Telefon, @KayitTarihi);		
   END			
 END TRY		
  BEGIN CATCH	
   PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();	
  END CATCH
END	
		
EXEC sp_OgrenciEkleGuncelle @TCNo = '12345673301',@Ad = 'semih',@Soyad = 'Yamaç',@Telefon = '05559612233',@KayitTarihi = '2025-03-02';

    
CREATE PROCEDURE sp_EgitmenEkleGuncelle @Ad NVARCHAR(50),@Soyad NVARCHAR(50),@Brans NVARCHAR(50),@Telefon NVARCHAR(20)                
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT * FROM Egitmen WHERE Ad = @Ad AND Soyad = @Soyad AND Brans = @Brans)
    BEGIN
        UPDATE Egitmen SET Telefon = @Telefon WHERE Ad = @Ad AND Soyad = @Soyad AND Brans = @Brans;              
    END
    ELSE
    BEGIN
        INSERT INTO Egitmen (Ad, Soyad, Brans, Telefon) VALUES (@Ad, @Soyad, @Brans, @Telefon);
        
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END

EXEC sp_EgitmenEkleGuncelle @Ad = 'Ahmet',@Soyad = 'Yamaç',@Brans = 'Direksiyon',@Telefon = '05556943562';
 
 
CREATE PROCEDURE sp_DersEkleGuncelle @DersAdi NVARCHAR(100),@DersTuru NVARCHAR(50),@EgitmenID INT         
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT * FROM Ders WHERE DersAdi = @DersAdi AND DersTuru = @DersTuru)
    BEGIN
        UPDATE Ders SET EgitmenID = @EgitmenID WHERE DersAdi = @DersAdi AND DersTuru = @DersTuru;              
    END
    ELSE
    BEGIN
        INSERT INTO Ders (DersAdi, DersTuru, EgitmenID) VALUES (@DersAdi, @DersTuru, @EgitmenID);       
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END

EXEC sp_DersEkleGuncelle @DersAdi = 'Trafik Kurallarý',@DersTuru = 'Teorik',@EgitmenID = 2;

CREATE PROCEDURE sp_OgrenciDersEkleGuncelle @OgrenciID INT,@DersID INT,@KatilimTarihi DATETIME          
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT * FROM OgrenciDers WHERE OgrenciID = @OgrenciID AND DersID = @DersID)
    BEGIN
        UPDATE OgrenciDers SET KatilimTarihi = @KatilimTarihi WHERE OgrenciID = @OgrenciID AND DersID = @DersID;              
    END
    ELSE
    BEGIN
        INSERT INTO OgrenciDers (OgrenciID, DersID, KatilimTarihi) VALUES (@OgrenciID, @DersID, @KatilimTarihi);       
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END;

EXEC sp_OgrenciDersEkleGuncelle @OgrenciID = 1,@DersID = 3,@KatilimTarihi = '2025-05-10';

CREATE PROCEDURE sp_OdemeEkleGuncelle @OgrenciID INT,@Tutar DECIMAL(10,2),@Aciklama NVARCHAR(200)            
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT * FROM Odeme WHERE OgrenciID = @OgrenciID)
    BEGIN
        UPDATE Odeme SET Tutar = @Tutar, OdemeTarihi = GETDATE() WHERE OgrenciID = @OgrenciID ;                
    END
    ELSE
    BEGIN
        INSERT INTO Odeme (OgrenciID, Tutar, OdemeTarihi, Aciklama) VALUES (@OgrenciID, @Tutar, GETDATE(), @Aciklama);       
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END

EXEC sp_OdemeEkleGuncelle @OgrenciID = 1, @Tutar = 3000.00, @Aciklama = 'Ýlk Taksit';


 CREATE PROCEDURE sp_SinavEkleGuncelle @OgrenciID INT,@SinavTuru NVARCHAR(50),@Sonuc NVARCHAR(20)            
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT 1 FROM Sinav WHERE OgrenciID = @OgrenciID AND SinavTuru = @SinavTuru)
    BEGIN
        UPDATE Sinav SET Sonuc = @Sonuc, SinavTarihi = GETDATE() WHERE OgrenciID = @OgrenciID AND SinavTuru = @SinavTuru;                
    END
    ELSE
    BEGIN
        INSERT INTO Sinav (OgrenciID, SinavTuru, SinavTarihi, Sonuc) VALUES (@OgrenciID, @SinavTuru, GETDATE(), @Sonuc);        
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END

EXEC sp_SinavEkleGuncelle @OgrenciID = 1,@SinavTuru = 'Yazýlý',@Sonuc = 'geçti';
EXEC sp_SinavEkleGuncelle @OgrenciID = 1,@SinavTuru = 'sürüþ',@Sonuc = 'geçti';

CREATE PROCEDURE sp_AracEkleGuncelle @Plaka NVARCHAR(20),@Marka NVARCHAR(50),@Model NVARCHAR(50),@KullanilanDersID INT           
AS
BEGIN
BEGIN TRY
    IF EXISTS (SELECT 1 FROM Arac WHERE Plaka = @Plaka)
    BEGIN
        UPDATE Arac SET Marka = @Marka,Model = @Model,KullanilanDersID = @KullanilanDersID WHERE Plaka = @Plaka;                                       
    END
    ELSE
    BEGIN
        INSERT INTO Arac (Plaka, Marka, Model, KullanilanDersID) VALUES (@Plaka, @Marka, @Model, @KullanilanDersID);       
    END
END TRY
BEGIN CATCH
    PRINT 'Hata oluþtu: ' + ERROR_MESSAGE();
END CATCH
END

EXEC sp_AracEkleGuncelle @Plaka = '48F5629',@Marka = 'volkswagen',@Model = 'polo',@KullanilanDersID='3';    
   
    

     

        
    
    
     
     
    	  
    
    		
	


	

