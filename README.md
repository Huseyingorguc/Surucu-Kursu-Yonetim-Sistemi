# Sürücü Kursu Yönetim Sistemi 🚗📝

Bu proje, bir sürücü kursunun günlük operasyonel süreçlerini (Araç, Ders ve Eğitmen yönetimi) dijitalleştirmek ve kolayca yönetmek amacıyla geliştirilmiş bir **C# Windows Forms** masaüstü uygulamasıdır. Arka planda **SQL Server** ilişkisel veritabanı mimarisi kullanılmıştır.

---

## 🚀 Öne Çıkan Özellikler

* **Öğrenci & Kayıt Yönetimi:** Kursa kayıt olan yeni kursiyerlerin kimlik, ehliyet sınıfı ve iletişim bilgileriyle sisteme eklenmesi, takibi.
* **Ödeme Yönetimi:** Kursiyerlerin taksit ve toplam ödeme dengelerinin finansal olarak izlenmesi.
* **Araç Yönetimi:** Sürücü kursuna ait araçların eklenmesi, güncellenmesi, silinmesi ve hangi ders için tahsis edildiğinin yönetilmesi.
* **Ders Yönetimi:** Teorik derslerin ve direksiyon (sürüş) derslerinin eğitmen eşleştirmeleriyle birlikte sisteme kaydedilmesi.
* **Eğitmen Yönetimi:** Kurs bünyesindeki eğitmenlerin branş (Sürüş/Teorik) ve iletişim bilgileriyle takibi.
* **Sınav Yönetimi:** Kursiyerlerin teorik ve direksiyon sınav tarihlerinin, aldıkları puanların ve başarı durumlarının merkezi takibi.
* **Gelişmiş Veritabanı Mimarisi:** 
  * Veri güvenliği ve performans için tüm CRUD işlemleri **Stored Procedure (Saklı Yordamlar)** üzerinden yürütülür.
  * Araç ve eğitmen silme/güncelleme işlemleri arka planda otomatik olarak loglanır (`AracLog`, `EgitmenLog`).
  * Karmaşık veri birleştirmeleri (Araç-Ders-Eğitmen ilişkisi) SQL **View** yapıları kullanılarak tek tıkla listelenir.

---

## 📸 Uygulama Ekran Görüntüleri

### 1. Giriş Paneli
Sistem yöneticilerinin ve eğitmenlerin veritabanı kimlik doğrulaması ile yönetim paneline güvenli erişim sağladığı ekran.
![Giriş Paneli](Screenshots/Giri%C5%9F%20Paneli.png)

### 2. Öğrenci Yönetimi
Kursa yeni başlayan kursiyerlerin tüm kişisel ve ehliyet sınıfı bilgilerinin kaydedildiği ve listelendiği alan.
![Öğrenci Yönetimi](Screenshots/%C3%96%C4%9Frenci%20Y%C3%B6netimi.png)

### 3. Ödeme Yönetimi
Öğrencilerin kurs ücreti ödemelerini, kalan borç bakiyelerini ve makbuz kayıtlarını içeren finansal takip ekranı.
![Ödeme Yönetimi](Screenshots/%C3%96deme%20Y%C3%B6netimi.png)

### 4. Öğrenci Ders Yönetimi
Hangi öğrencinin, hangi tarihte, hangi eğitmen eşliğinde derse katılacağını gösteren bireysel planlama paneli.
![Öğrenci Ders Yönetimi](Screenshots/%C3%96%C4%9Frenci%20Ders%20Y%C3%B6netimi.png)

### 5. Ders Yönetimi
Kurs takvimindeki genel teorik derslerin ve direksiyon eğitim saatlerinin tanımlandığı arayüz.
![Ders Yönetimi](Screenshots/Ders%20Y%C3%B6netimi.png)

### 6. Eğitmen Yönetimi
Sürücü kursunda görev yapan direksiyon ve teorik ders eğitmenlerinin branş ve iletişim bilgilerinin yönetildiği alan.
![Eğitmen Yönetimi](Screenshots/E%C4%9Fitmen%20Y%C3%B6netimi.png)

### 7. Araç Yönetimi
Eğitimlerde ve direksiyon sınavlarında kullanılan aktif araç filosunun marka, model, plaka ve müsaitlik durumu takibi.
![Araç Yönetimi](Screenshots/Ara%C3%A7%20Y%C3%B6netimi.png)

### 8. Sınav Yönetimi
Kursiyerlerin sınav giriş bilgileri ile teorik ve pratik sınav sonuçlarının, başarı puanlarının girildiği panel.
![Sınav Yönetimi](Screenshots/S%C4%B1nav%20Y%C3%B6netimi.png)

---

## 🛠️ Kullanılan Teknolojiler ve Diller

* **Programlama Dili:** C# (.NET Framework 4.8)
* **Arayüz Teknolojisi:** Windows Forms (WinForms)
* **Veri Bağlantısı:** ADO.NET (SqlDataAdapter, SqlCommand)
* **Veritabanı:** MS SQL Server (Stored Procedure, Trigger, View Desteği ile)
* **ORM / Altyapı:** Entity Framework 6 & SQLite entegrasyon desteği (App.config altyapısı hazır)

---

## 🔧 Veritabanı Kurulumu (.BAK Yöntemi)

1. SQL Server Management Studio (SSMS) uygulamasını açın.
2. **Databases** sekmesine sağ tıklayıp **Restore Database...** seçeneğini seçin.
3. **Device** kısmından projedeki `Database/SurucuKursuDB.bak` dosyasını göstererek veritabanını tüm tablo, view ve procedure'leriyle birlikte geri yükleyin.

---

## 🔧 Nasıl Çalıştırılır?

1. Bu depoyu bilgisayarınıza indirin (clone).
2. `App.config` dosyasındaki `connectionString` alanını kendi yerel SQL Server (`Data Source=...`) bilgilerinize göre güncelleyin.
3. Projeyi **Visual Studio** ile açarak `Start` butonuna basın veya `F5` tuşunu kullanın.