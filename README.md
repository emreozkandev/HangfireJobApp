# 🛠️ HangfireJobApp - .NET 8 Background Job Uygulaması

Bu proje, .NET 8 ve [Hangfire](https://www.hangfire.io/) kullanarak zamanlanmış arka plan görevlerinin (background jobs) nasıl yazıldığını ve çalıştırıldığını gösteren örnek bir uygulamadır.

## 🚀 Özellikler

- ✅ .NET 8 ile geliştirilmiş
- ✅ Hangfire kullanarak arka plan job'ları çalıştırma
- ✅ SQL Server ile kalıcı job saklama
- ✅ Cron tabanlı zamanlama (örneğin: 3 dakikada bir)
- ✅ Hangfire Dashboard üzerinden job yönetimi ve takibi
- ✅ Parametreli job çağrıları
- ✅ Web tabanlı minimal API entegrasyonu

---

## 🧰 Kullanılan Teknolojiler

- .NET 8
- Hangfire
- SQL Server
- C#
- Minimal API

---

## ⚙️ Kurulum

### 1. Bağımlılıkları yükle

```bash
dotnet restore


2. SQL Server bağlantısını ayarla

appsettings.json veya Program.cs içindeki connection string’i kendi SQL Server bilgilerine göre güncelle:

"Server=localhost;Database=HangfireDb;Trusted_Connection=True;"

SQL Server'ın kurulu ve çalışıyor olması gerekir.



3. Uygulamayı çalıştır
dotnet run
Uygulama açıldığında Hangfire Dashboard aşağıdaki adresten erişilebilir olacaktır:


📁 HangfireJobApp
├── Program.cs
├── appsettings.json
└── README.md

---

Hazırsan bu `README.md` dosyasını projeye ekleyebilirsin.  
İstersen terminalden şu komutla oluşturabilirsin:

```bash
echo "# README" > README.md
