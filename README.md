# EventReserve

A lightweight event reservation system built with ASP.NET Core (.NET 9) and React.  
It allows users to create, update, and delete reservations through a clean API and simple frontend.

---

## Features

- Create reservations
- Update reservations
- Delete reservations
- In-memory data storage

---

## Tech Stack

**Backend**
- ASP.NET Core (.NET 9)
- Clean Architecture
- In-memory repository

**Frontend**
- React (Vite)
- Tailwind CSS

---

## Project Structure

- EventReserve.Api → API layer  
- EventReserve.Application → business logic  
- EventReserve.Domain → entities  
- EventReserve.Infrastructure → data access  
- EventReserve.Tests → unit tests  
- EventReserve.Client → frontend  

---

## Running the Project

### Backend
```bash
cd EventReserve.Api
dotnet run
```

API:  
http://localhost:5007  

Swagger:  
http://localhost:5007/index.html  

### Frontend
```bash
cd EventReserve.Client
npm install
npm run dev
```

Frontend:  
http://localhost:5173  

---

## Testing
```bash
dotnet test
```

---

## Notes

- Data is stored in memory (resets on restart)
- Designed to meet assessment requirements

---

## Author

Msekeli Mkwibiso
