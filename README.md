# House-Of-Jordan

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
