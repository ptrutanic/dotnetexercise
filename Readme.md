# Project Setup

---

## 🧾 1. Environment Variables

Before running the project, create and populate the `.env` files for both the **client** and **server**.

### ➤ Client (`Abysalto.Mid.Client/.env`)

### ➤ Server (`.env`)

> Replace the example values with your actual configuration.

## 📦 2. Install Dependencies

Install dependencies separately for the frontend and backend.

### ➤ Client

```bash
cd Abysalto.Mid.Client
npm install
```

### ➤ Server

```bash
cd Abysalto.Mid
dotnet restore
```

---

## 🗃 3. Run Database Migrations

Before running the server, make sure the database is ready and then run the migrations:

```bash
dotnet ef database update
```

## 🚀 4. Start the Project

### ➤ Start Frontend

In the `client` directory:

```bash
npm run dev
```

### ➤ Start Backend

In the `server` directory:

```bash
dotnet run
```
