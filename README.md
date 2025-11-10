
![.NET Full Stack](https://img.shields.io/badge/Full%20Stack-.NET%208%20%7C%20Razor%20Pages%20%7C%20EF%20Core-blueviolet?style=for-the-badge)
![Azure App Service](https://img.shields.io/badge/Deployed-Azure%20App%20Service%20(Free%20Tier)-lightblue?logo=microsoftazure&style=for-the-badge)
![SQLite](https://img.shields.io/badge/Database-SQLite-lightgrey?logo=sqlite&style=for-the-badge)
![CSharp](https://img.shields.io/badge/Language-C%23-239120?logo=csharp&logoColor=white&style=for-the-badge)
![EntityFramework](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-green?style=for-the-badge)
![VisualStudio](https://img.shields.io/badge/IDE-Visual%20Studio%20Code-blue?logo=visualstudiocode&style=for-the-badge)

# 📊 Math Lab Tutoring Tracker

**Summary**  
A full-stack **.NET 8 web app** for managing **math tutoring lab check-ins and visit analytics**.  
Students submit check-ins, while staff access a secure **Admin Dashboard** to view data, export reports, and measure impact.

🌐 **Live Demo**

[![🟢 Student Check-In](https://img.shields.io/badge/Launch%20App-Student%20Check--In-success?style=for-the-badge)](https://tutoringtracker-eddie-lab.azurewebsites.net/CheckIn)
[![🔐 Admin Login](https://img.shields.io/badge/Access%20Dashboard-Admin%20Login-blue?style=for-the-badge)](https://tutoringtracker-eddie-lab.azurewebsites.net/AdminLogin)

**Admin Access Code:** `MathLab2025`  
*(Demo credentials for interviewer access — cookie expires automatically after login.)*  
**Student ID's:** `S1001` `S1002` `S1003`

> Hosted on **Azure App Service (Free Tier)** – initial load may take a few seconds due to cold start.

---

🎥 **Demo Preview**

![Tutoring Tracker Demo](demo.gif)

*(Shows student check-in and admin dashboard live on Azure)*

---

## ⚙️ Tech Stack

**Frontend:** ASP.NET Core Razor Pages • Bootstrap UI  
**Backend:** .NET 8 • C# • Entity Framework Core  
**Database:** SQLite (local dev) → Azure-ready  
**Hosting:** Azure App Service (Linux, Free Tier)  
**Tooling:** Azure CLI • Kudu • VS Code • GitHub  

---

## 🎯 1️⃣ Context

College tutoring labs need quick, reliable data capture for:
- Student attendance & course tracking  
- Evidence of support for accreditation/funding  
- Reduced paper or spreadsheet errors  

This project replaces manual systems with a simple, web-based form + analytics dashboard.

---

## 🧩 2️⃣ Implementation

- **Architecture:** Razor Pages + EF Core (code-first).  
- **Models:** `Student`, `Course`, `Visit` linked via `AppDbContext`.  
- **Admin Security:** Cookie-based login protecting dashboard + CSV export.  
- **Deployment:** Published via Azure CLI; runtime adjusted to `.NET 8` after initial PHP container issue.  
- **Troubleshooting:** Used Azure **Log Streaming** + **Kudu Bash** to inspect container behavior and confirm DLL deployment paths.

**OOP Concepts:**  
Encapsulation through models, separation of concerns, and clean page model structure for each feature.

---

## 🚀 3️⃣ Impact

- Demonstrates **end-to-end full-stack ownership** — backend, frontend, database, and deployment.  
- Real-world fit for **higher-ed data tracking** and **student success analytics**.  
- Shows applied skills in **refactoring**, **logging**, and **platform diagnostics**.  
- Deployed, functional demo on Azure App Service (Free Tier).

---

## 🧠 Next Steps

- Add course filters + visual analytics to admin dashboard  
- Integrate campus SSO (OpenID Connect)  
- Scale from Free Tier → **Basic/Standard App Service Plan** to enable autoscaling and multi-instance redundancy.  
- Add **Azure Front Door** or **Traffic Manager** for high availability across regions.  
- Implement **Network Security Groups**, **Azure Firewall**, and **Managed Identity** for defense-in-depth.  
- Apply **RBAC** and **Private Endpoints** for secure service-to-service communication.  
- Migrate to **Azure SQL Database** for resilient, scalable data storage.

---

## 💻 Run Locally

```bash
dotnet restore
dotnet build
dotnet run
