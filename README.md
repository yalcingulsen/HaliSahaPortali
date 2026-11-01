\# Halı Saha Rezervasyon Portalı



BLM4581 Ağ Tabanlı Teknolojiler ve Uygulamaları dönem projesi.

ASP.NET Core MVC, Entity Framework Core ve PostgreSQL ile geliştirilmiştir.



\## Gereksinimler

\- .NET 10 SDK

\- PostgreSQL



\## Kurulum

1\. Depoyu klonlayın ve proje klasörüne girin:

&#x20;  cd HaliSahaPortali/HaliSahaPortali

2\. Veritabanı bağlantısını user-secrets ile ayarlayın (şifre depoda tutulmaz):

&#x20;  dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=HaliSahaDb;Username=postgres;Password=SIFRENIZ"

3\. Proje araçlarını (dotnet-ef) kurun:

&#x20;  dotnet tool restore

4\. Migration'ları uygulayarak veritabanını oluşturun:

&#x20;  dotnet ef database update

5\. Uygulamayı çalıştırın:

&#x20;  dotnet run



\## Veritabanı Tabloları

\- Tesisler: halı saha tesisleri

\- Sahalar: tesislere ait sahalar (Tesis 1 - N Saha)

\- Rezervasyonlar: sahalara yapılan 1 saatlik rezervasyonlar (Saha 1 - N Rezervasyon)

\- Yorumlar: tesislere yapılan puan ve yorumlar (Tesis 1 - N Yorum)

