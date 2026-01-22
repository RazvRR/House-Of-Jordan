# House Of Jordan - Sneakers Collection API

API REST pentru gestionarea unei colecții de sneakers Jordan, construit cu ASP.NET Core și Entity Framework Core.

## 📋 Descriere

Aplicația permite:
- Gestionarea brandurilor de sneakers
- Gestionarea utilizatorilor
- Gestionarea sneakers-urilor (adidași)
- Gestionarea wishlist-urilor (lista de dorințe pentru fiecare utilizator)

## 🛠️ Tehnologii

- **.NET 10.0** - Framework principal
- **ASP.NET Core Web API** - API REST
- **Entity Framework Core 10.0.1** - ORM
- **SQLite** - Bază de date
- **Swagger/OpenAPI** - Documentație interactivă
- **Docker** - Containerizare

## 🚀 Cum să rulezi aplicația cu Docker

### Cerințe:
- [Docker Desktop](https://www.docker.com/products/docker-desktop) instalat și pornit

### Pași:

1. **Clonează repository-ul:**
   ```bash
   git clone <repository-url>
   cd House-Of-Jordan
   ```

2. **Pornește aplicația:**
   ```bash
   docker-compose up
   ```

3. **Accesează Swagger UI:**

   Deschide browser-ul la: **http://localhost:5193/swagger**

4. **Oprește aplicația:**

   Apasă `Ctrl+C` în terminal sau rulează:
   ```bash
   docker-compose down
   ```

## 🚀 Cum să rulezi aplicația fără Docker

### Cerințe:
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalat

### Pași:

1. **Navighează în directorul aplicației:**
   ```bash
   cd HouseOfJordan.Api
   ```

2. **Restaurează dependențele:**
   ```bash
   dotnet restore
   ```

3. **Rulează aplicația:**
   ```bash
   dotnet run
   ```

4. **Accesează Swagger UI:**

   Deschide browser-ul la: **http://localhost:5193/swagger**

## 📖 API Endpoints

### Brands
- `GET /api/brands` - Listează toate brandurile
- `GET /api/brands/{id}` - Detalii brand
- `POST /api/brands` - Creează brand nou
- `PUT /api/brands/{id}` - Actualizează brand
- `DELETE /api/brands/{id}` - Șterge brand

### Users
- `GET /api/users` - Listează toți utilizatorii
- `GET /api/users/{id}` - Detalii utilizator
- `POST /api/users` - Creează utilizator nou
- `PUT /api/users/{id}` - Actualizează utilizator
- `DELETE /api/users/{id}` - Șterge utilizator

### Sneakers
- `GET /api/sneakers` - Listează toți sneakers
- `GET /api/sneakers/{id}` - Detalii sneaker
- `POST /api/sneakers` - Creează sneaker nou
- `PUT /api/sneakers/{id}` - Actualizează sneaker
- `DELETE /api/sneakers/{id}` - Șterge sneaker

### Wishlist
- `GET /api/users/{userId}/wishlist` - Wishlist-ul utilizatorului
- `POST /api/users/{userId}/wishlist` - Adaugă în wishlist
- `DELETE /api/users/{userId}/wishlist/{itemId}` - Șterge din wishlist

## 📝 Exemple de Request-uri

### Creează un Brand
```bash
POST /api/brands
Content-Type: application/json

{
  "name": "Nike"
}
```

### Creează un User
```bash
POST /api/users
Content-Type: application/json

{
  "username": "john_doe"
}
```

### Creează un Sneaker
```bash
POST /api/sneakers
Content-Type: application/json

{
  "model": "Air Jordan 1",
  "colorway": "Chicago",
  "year": 1985,
  "price": 170.00,
  "size": "42",
  "brandId": 1,
  "userId": 1
}
```

### Adaugă în Wishlist
```bash
POST /api/users/1/wishlist
Content-Type: application/json

{
  "sneakerId": 1
}
```

## 🗄️ Structura Bazei de Date

### Brands
- `Id` (PK) - Identificator unic
- `Name` (UNIQUE) - Numele brandului

### Users
- `Id` (PK) - Identificator unic
- `Username` (UNIQUE) - Numele utilizatorului

### Sneakers
- `Id` (PK) - Identificator unic
- `Model` - Modelul sneaker-ului
- `Colorway` - Combinația de culori
- `Year` - Anul lansării
- `Price` - Prețul
- `Size` - Mărimea
- `BrandId` (FK) - Referință către Brand
- `UserId` (FK) - Referință către User

### WishlistItems
- `Id` (PK) - Identificator unic
- `UserId` (FK) - Referință către User
- `SneakerId` (FK) - Referință către Sneaker

## 📁 Structura Proiectului

```
HouseOfJordan.Api/
├── Controllers/      # Endpoint-uri API
├── DTOs/            # Data Transfer Objects
├── Models/          # Entități baza de date
├── Services/        # Logica de business
├── Data/            # DbContext
├── Migrations/      # Migrări baza de date
└── Program.cs       # Configurare aplicație
```

## 👨‍💻 Autor

Proiect realizat pentru cursul de Programare Web

**Universitatea Națională de Știință și Tehnologie POLITEHNICA București**  
**Facultatea de Inginerie Industrială și Robotică (FIIR)**  
**Program de studii:** Informatică Industrială  
**Anul 4, Semestrul I** — **Disciplina:** Proiect Inginerie Software 2  

**Proiect:** House Of Jordan  
**Studenți:**  
- Vasile Mihai-Adrian  
- Călugăru Mara – Alexandra  
- Ana Răzvan - Adrian

**Grupa:** 641AB

[House of Jordan - Link GitHub](<https://github.com/RazvRR/House-Of-Jordan>)

**Descriere:**
House Of Jordan este un serviciu WEB cu REST API, dezvoltat în .NET, pentru gestionarea colecțiilor de sneakers. Utilizatorii pot adăuga, modifica și șterge modele, organiza pantofii pe brand și ediții limitate și crea un wishlist. Datele sunt stocate într-o bază relațională, iar API-ul folosește DTO-uri, servicii și deployment în Docker.

---

## Ce conține repository-ul:
Structura principală a proiectului este:

- `HouseOfJordan.Api/`  
  Codul sursă al aplicației .NET (REST API): controllere, servicii, DTO-uri, modele, configurare.
- `docker-compose.yml`  
  Orchestrare pentru rulare locală: API + DB
- `Dockerfile`  
  Imaginea Docker pentru aplicația API.
- `Diagrama_de_activitate.drawio` / `Diagrama_de_activitate.jpg`  
  Diagrama de activitate folosită în documentație.
- `Proiect_IS2.docx`  
  Documentația proiectului (SRS + SDD), în format Word.


## User Stories (rezumat)
- **US1** — Adăugare sneaker în colecție  
- **US2** — Actualizare informații sneaker  
- **US3** — Ștergere sneaker  
- **US4** — Listare colecție sneakers + filtrare  
- **US5** — Administrare branduri (admin)  
- **US6** — Gestionare wishlist  
- **US7** — Căutare sneakers după nume/brand  

---

## Arhitectură (rezumat)
Aplicația urmează o arhitectură pe 3 straturi:
1) **Controllers (API layer)** — gestionează request/response (CRUD endpoints)  
2) **Services (Business layer)** — validări, reguli de business, ownership, unicitate etc.  
3) **Data Access (ORM/DB layer)** — persistență în baza de date

Se utilizează **DTO-uri** pentru separarea entităților interne de datele expuse prin API.

---

## Endpoints (CRUD)
### BrandsController
- `GET    /api/brands` — listare branduri  
- `GET    /api/brands/{id}` — detalii brand  
- `POST   /api/brands` — creare brand  
- `PUT    /api/brands/{id}` — actualizare brand  
- `DELETE /api/brands/{id}` — ștergere brand  

### SneakersController
- `GET    /api/sneakers` — listare sneakers (cu filtrare/căutare dacă e implementată)  
- `GET    /api/sneakers/{id}` — detalii sneaker  
- `POST   /api/sneakers` — creare sneaker  
- `PUT    /api/sneakers/{id}` — actualizare sneaker  
- `DELETE /api/sneakers/{id}` — ștergere sneaker  

### UsersController
- `GET    /api/users` — listare users  
- `GET    /api/users/{id}` — detalii user  
- `POST   /api/users` — creare user  
- `PUT    /api/users/{id}` — actualizare user  
- `DELETE /api/users/{id}` — ștergere user  

### WishlistController
- `GET    /api/users/{userId}/wishlist` — listare wishlist pentru user  
- `POST   /api/users/{userId}/wishlist` — adăugare sneaker în wishlist  
- `DELETE /api/users/{userId}/wishlist/{itemId}` — ștergere item wishlist  
