\# Sürücü Kursu Yönetim Sistemi 🚗📝



Bu proje, bir sürücü kursunun günlük operasyonel süreçlerini (Araç, Ders ve Eğitmen yönetimi) dijitalleştirmek ve kolayca yönetmek amacıyla geliştirilmiş bir \*\*C# Windows Forms\*\* masaüstü uygulamasıdır. Arka planda \*\*SQL Server\*\* ilişkisel veritabanı mimarisi kullanılmıştır.



\## 🚀 Öne Çıkan Özellikler



\* \*\*Araç Yönetimi:\*\* Sürücü kursuna ait araçların eklenmesi, güncellenmesi, silinmesi ve hangi ders için tahsis edildiğinin yönetilmesi.

\* \*\*Ders Yönetimi:\*\* Teorik derslerin ve direksiyon (sürüş) derslerinin eğitmen eşleştirmeleriyle birlikte sisteme kaydedilmesi.

\* \*\*Eğitmen Yönetimi:\*\* Kurs bünyesindeki eğitmenlerin branş (Sürüş/Teorik) ve iletişim bilgileriyle takibi.

\* \*\*Gelişmiş Veritabanı Mimarisi:\*\* \* Veri güvenliği ve performans için tüm CRUD işlemleri \*\*Stored Procedure (Saklı Yordamlar)\*\* üzerinden yürütülür.

&#x20;   \* Araç ve eğitmen silme/güncelleme işlemleri arka planda otomatik olarak loglanır (`AracLog`, `EgitmenLog`).

&#x20;   \* Karmaşık veri birleştirmeleri (Araç-Ders-Eğitmen ilişkisi) SQL \*\*View\*\* yapıları kullanılarak tek tıkla listelenir.



\## 🛠️ Kullanılan Teknolojiler ve Diller



\* \*\*Programlama Dili:\*\* C# (.NET Framework 4.8)

\* \*\*Arayüz Teknolojisi:\*\* Windows Forms (WinForms)

\* \*\*Veritabanı:\*\* MS SQL Server \& ADO.NET (SqlDataAdapter, SqlCommand)

\* \*\*ORM / Altyapı:\*\* Entity Framework 6 \& SQLite entegrasyon desteği (App.config altyapısı hazır)



\## 🔧 Nasıl Çalıştırılır?



1\.  Bu depoyu bilgisayarınıza indirin (clone).

2\.  `App.config` dosyasındaki `connectionString` alanını kendi yerel SQL Server (`Data Source=...`) bilgilerinize göre güncelleyin.

3\.  SQL Server üzerinde `SurucuKursuDB` isimli bir veritabanı oluşturun ve gerekli tabloları, trigger'ları, view'ları ve stored procedure'leri (`sp\_AracEkleGuncelle`, `sp\_DersEkleGuncelle` vb.) tanımlayın.

4\.  Projeyi \*\*Visual Studio\*\* ile açarak `Start` butonuna basın.

