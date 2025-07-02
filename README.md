# HepsiApi - Onion Architecture & CQRS

🚀 **.NET 9.0** ile geliştirilmiş modern web API projesi - Onion Architecture ve CQRS design pattern kullanılarak oluşturulmuş, ölçeklenebilir ve sürdürülebilir bir e-ticaret API uygulaması.

## 📋 İçindekiler

- Özellikler
- Mimari
- Teknolojiler
- Kurulum
- Proje Yapısı
- Kullanım
- API Endpoints

## ✨ Özellikler

- **🧅 Onion Architecture**: Temiz mimari prensiplerine uygun katmanlar arası bağımlılık yönetimi
- **⚡ CQRS Pattern**: Command Query Responsibility Segregation ile ayrılmış okuma/yazma işlemleri
- **🎯 MediatR**: Request/Response pattern implementasyonu
- **🔄 AutoMapper**: Object-to-object mapping
- **📊 Entity Framework Core**: SQL Server ile modern ORM çözümü
- **🛡️ FluentValidation**: Güçlü validasyon kuralları
- **🔐 JWT Authentication**: Token tabanlı kimlik doğrulama sistemi
- **📮 Redis Cache**: Yüksek performanslı caching çözümü
- **📖 Swagger/OpenAPI**: Otomatik API dokümantasyonu
- **🎲 Bogus**: Test verisi üretimi

## 🏗️ Mimari

Bu proje **Onion Architecture** prensiplerine uygun olarak geliştirilmiştir:

```
┌─────────────────────────────────────┐
│           Presentation              │
│         (HepsiApi.WEBAPI)           │
├─────────────────────────────────────┤
│             Core                    │
│  ┌─────────────────────────────┐    │
│  │    HepsiApi.Application     │    │
│  │      (CQRS & Handlers)      │    │
│  ├─────────────────────────────┤    │
│  │      HepsiApi.Domain        │    │
│  │    (Entities & Rules)       │    │
│  ├─────────────────────────────┤    │
│  │      HepsiApi.Mapper        │    │
│  │    (AutoMapper Profiles)    │    │
│  └─────────────────────────────┘    │
├─────────────────────────────────────┤
│           Infrastructure            │
│  ┌─────────────────────────────┐    │
│  │   HepsiApi.Persistence      │    │
│  │   (EF Core & Database)      │    │
│  ├─────────────────────────────┤    │
│  │   HepsiApi.Infrastructure   │    │
│  │     (Redis, JWT)           │    │
│  └─────────────────────────────┘    │
└─────────────────────────────────────┘
```

## 🛠️ Teknolojiler

### Core Technologies

- **.NET 9.0** - Latest framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 9.0** - ORM with SQL Server
- **MediatR 12.5.0** - CQRS implementation

### Authentication & Security

- **JWT Bearer Authentication** - Token-based authentication
- **System.IdentityModel.Tokens.Jwt 8.12.1** - JWT token handling

### Data & Validation

- **FluentValidation 12.0.0** - Input validation
- **AutoMapper 14.0.0** - Object-to-object mapping
- **Bogus 35.6.3** - Test data generation

### Caching & Tools

- **StackExchange.Redis 2.8.41** - Redis caching

### Documentation & Tools

- **Swagger/OpenAPI** - API documentation
- **Microsoft.EntityFrameworkCore.Tools** - EF migrations

## 🚀 Kurulum

### Gereksinimler

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB yeterli)
- [Redis Server](https://redis.io/download) (opsiyonel, caching için)

### Adımlar

1. **Repository'yi klonlayın**

   ```bash
   git clone https://github.com/sbrakb/HepsiApi-OnionCQRS.git
   cd HepsiApi-OnionCQRS
   ```

2. **Bağımlılıkları yükleyin**

   ```bash
   dotnet restore
   ```

3. **Connection string'i güncelleyin**

   ```json
   // Presentation/HepsiApi.WEBAPI/appsettings.json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HepsiApiDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
     }
   }
   ```

4. **Database migration'larını çalıştırın**

   ```bash
   dotnet ef database update --project Infrastructure/HepsiApi.Persistence --startup-project Presentation/HepsiApi.WEBAPI
   ```

5. **Uygulamayı başlatın**

   ```bash
   dotnet run --project Presentation/HepsiApi.WEBAPI
   ```

6. **Swagger UI'ya erişin**
   ```
   https://localhost:5001/swagger
   ```

## 📁 Proje Yapısı

```
HepsiApi/
├── Core/
│   ├── HepsiApi.Domain/                # Domain Layer
│   │   ├── Entities/                   # Domain entities
│   │   └── Common/                     # Domain base classes
│   │
│   ├── HepsiApi.Application/           # Application Layer
│   │   ├── Features/                   # Feature-based organization
│   │   │   ├── Products/               # Product operations
│   │   │   │   ├── Commands/           # Create, Update, Delete
│   │   │   │   │   ├── CreateProduct/
│   │   │   │   │   ├── UpdateProduct/
│   │   │   │   │   └── DeleteProducts/
│   │   │   │   ├── Queries/            # Read operations
│   │   │   │   │   └── GetAllProducts/
│   │   │   │   ├── Rules/              # Business rules
│   │   │   │   └── Exceptions/         # Product-specific exceptions
│   │   │   │
│   │   │   ├── Brands/                 # Brand operations
│   │   │   │   ├── Commands/
│   │   │   │   │   └── CreateBrand/
│   │   │   │   └── Queries/
│   │   │   │       └── GetAllBrands/
│   │   │   │
│   │   │   └── Auth/                   # Authentication operations
│   │   │       ├── Commands/
│   │   │       │   ├── Login/
│   │   │       │   ├── Register/
│   │   │       │   ├── RefreshToken/
│   │   │       │   ├── Revoke/
│   │   │       │   └── RevokeAll/
│   │   │       ├── Queries/
│   │   │       ├── Rules/
│   │   │       └── Exceptions/
│   │   │
│   │   ├── Interfaces/                 # Application interfaces
│   │   │   ├── Repositories/           # Repository contracts
│   │   │   ├── UnitOfWorks/           # Unit of Work contract
│   │   │   ├── Tokens/                # Token service contract
│   │   │   ├── RedisCache/             # Cache service contract
│   │   │   └── AutoMapper/             # Mapper contract
│   │   │
│   │   ├── Behaviors/                  # MediatR behaviors
│   │   ├── Bases/                      # Base classes
│   │   ├── DTOs/                       # Data Transfer Objects
│   │   └── Exceptions/                 # Application exceptions
│   │
│   └── HepsiApi.Mapper/                # Mapping Layer
│       └── AutoMapper/                 # AutoMapper profiles
│
├── Infrastructure/
│   ├── HepsiApi.Persistence/           # Data Access Layer
│   │   └── (EF Core, DbContext, Repositories)
│   │
│   └── HepsiApi.Infrastructure/        # External Services Layer
│       └── (Redis, JWT, SendGrid implementations)
│
└── Presentation/
    └── HepsiApi.WEBAPI/                # API Layer
        └── (Controllers, Middleware, Startup)
```

## 📱 Kullanım

### API Base URL

```
Development: https://localhost:5001/api
```

### Authentication Flow

```bash
# Register
POST /api/auth/register
{
  "email": "user@example.com",
  "password": "Password123!",
  "confirmPassword": "Password123!"
}

# Login
POST /api/auth/login
{
  "email": "user@example.com",
  "password": "Password123!"
}

# Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "...",
  "expiration": "2024-12-31T23:59:59Z"
}
```

### Headers

```
Content-Type: application/json
Authorization: Bearer {your-jwt-token}
```

## 🔗 API Endpoints

### Authentication

```http
POST   /api/auth/register          # Kullanıcı kaydı
POST   /api/auth/login             # Giriş yap
POST   /api/auth/refresh-token     # Token yenile
POST   /api/auth/revoke            # Token iptal et
POST   /api/auth/revoke-all        # Tüm tokenları iptal et
```

### Products

```http
GET    /api/products               # Tüm ürünleri listele
POST   /api/products               # Yeni ürün oluştur
PUT    /api/products/{id}          # Ürünü güncelle
DELETE /api/products/{id}          # Ürünü sil
```

### Brands

```http
GET    /api/brands                 # Tüm markaları listele
POST   /api/brands                 # Yeni marka oluştur
```

## 🔧 Konfigürasyon

### appsettings.json örneği

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HepsiApiDb;Trusted_Connection=true;"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key",
    "Issuer": "HepsiApi",
    "Audience": "HepsiApi-Users",
    "ExpireMinutes": 60
  },
  "RedisSettings": {
    "ConnectionString": "localhost:6379"
  }
}
```

## 🧪 Test Verisi

Proje **Bogus** kütüphanesi kullanarak otomatik test verisi üretimi yapabilir. Seed data için migration'lar sırasında otomatik veri oluşturulur.

## 🚀 Deployment

### Migration Komutları

```bash
# Migration oluştur
dotnet ef migrations add InitialCreate --project Infrastructure/HepsiApi.Persistence --startup-project Presentation/HepsiApi.WEBAPI

# Veritabanını güncelle
dotnet ef database update --project Infrastructure/HepsiApi.Persistence --startup-project Presentation/HepsiApi.WEBAPI
```

### Production Deployment

1. Connection string'i production veritabanına güncelleyin
2. JWT secret key'ini güvenli bir değerle değiştirin
3. Redis connection string'ini ayarlayın

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 📞 İletişim

**Proje Sahibi**: [sbrakb](https://github.com/sbrakb)

**Proje Linki**: [https://github.com/sbrakb/HepsiApi-OnionCQRS](https://github.com/sbrakb/HepsiApi-OnionCQRS)

---

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
