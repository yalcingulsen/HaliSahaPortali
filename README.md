# Halı Saha Rezervasyon Portalı

BLM4581 Ağ Tabanlı Teknolojiler ve Uygulamaları dönem projesi.
ASP.NET Core MVC, Entity Framework Core ve PostgreSQL ile geliştirilmiştir.

## Gereksinimler

- .NET 10 SDK
- PostgreSQL

## Kurulum

1. Depoyu klonlayın ve proje klasörüne girin:

   ```
   cd HaliSahaPortali/HaliSahaPortali
   ```

2. Veritabanı bağlantısını user-secrets ile ayarlayın (şifre depoda tutulmaz):

   ```
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=HaliSahaDb;Username=postgres;Password=SIFRENIZ"
   ```

3. Admin hesabı (admin@halisaha.com) için şifreyi de user-secrets ile ayarlayın:

   ```
   dotnet user-secrets set "AdminSifre" "GucluBirSifre1!"
   ```

4. Proje araçlarını (dotnet-ef) kurun:

   ```
   dotnet tool restore
   ```

5. Migration'ları uygulayarak veritabanını oluşturun:

   ```
   dotnet ef database update
   ```

6. Uygulamayı çalıştırın:

   ```
   dotnet run
   ```

## Roller

- **Admin:** Yönetici panelinden tesis ve saha ekler, düzenler, siler. Uygulama ilk açıldığında admin@halisaha.com hesabı otomatik oluşturulur.
- **Kullanici:** Siteye kayıt olan herkese otomatik verilir.

## Veritabanı Tabloları

- Tesisler: halı saha tesisleri
- Sahalar: tesislere ait sahalar (Tesis 1 - N Saha)
- Rezervasyonlar: sahalara yapılan 1 saatlik rezervasyonlar (Saha 1 - N Rezervasyon)
- Yorumlar: tesislere yapılan puan ve yorumlar (Tesis 1 - N Yorum)
- AspNetUsers, AspNetRoles: Identity kullanıcı ve rol tabloları
