# ControlDeHabitos2

**ControlDeHabitos2** es una aplicación de escritorio que permite a los usuarios registrar, editar y eliminar hábitos, con seguimiento por semana y fecha límite opcional. El sistema cuenta con autenticación de usuarios e interfaz gráfica desarrollada en WinForms, consumiendo una API RESTful hecha en ASP.NET Core.

---

## 🛠 Tecnologías utilizadas

- **Frontend:** WinForms (.NET 8)
- **Backend:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Base de Datos:** SQL Server
- **Control de versiones:** Git y GitHub

---

## 🧠 Funcionalidades principales

- Registro e inicio de sesión de usuarios.
- Agregar, editar, eliminar y ver hábitos.
- Asociar hábitos a un usuario.
- Persistencia en base de datos con EF Core.
- Arquitectura en capas siguiendo principios **SOLID**.

---

## 📂 Estructura del proyecto

## 📂 Estructura del proyecto

ControlDeHabitos2  
├── ControlDeHabitos2.API  # Backend API (ASP.NET Core)  
│   ├── Controllers         # Controladores (Usuarios, Hábitos)  
│   ├── Data                # DbContext y configuración  
│   ├── Interfaces          # Interfaces de repositorio y servicio  
│   ├── Migrations          # Migraciones de la base de datos  
│   ├── Models              # Entidades de dominio  
│   ├── Repositories        # Repositorios concretos  
│   └── Services            # Lógica de negocio  
│  
└── ControlDeHabitos2.Desktop  # Frontend (WinForms)  
    ├── Form1.cs            # Pantalla principal con pestañas  
    ├── LoginForm.cs        # Pantalla de login  
    ├── RegisterForm.cs     # Pantalla de registro  
    └── Sesion.cs           # Clase para mantener sesión activa

## 📊 Diagrama de negocio

El flujo del sistema está representado mediante un diagrama de pantallas e interacciones visuales:

📌 [Ver Diagrama de negocio (Draw.io)](https://drive.google.com/file/d/1wBm1IwAUTGDnX3gxO0SSQf_DL4vkI7l1/view?usp=sharing)

> ✅ El usuario puede:
> - Registrarse con nombre y contraseña.
> - Iniciar sesión.
> - Crear nuevos hábitos.
> - Ver, editar y eliminar sus hábitos.

## 🏗️ Diagrama de arquitectura

La estructura del sistema se organiza por capas y está representada en el siguiente diagrama:

🔗 [Ver Diagrama de arquitectura (Draw.io)](https://drive.google.com/file/d/1zbc0DPmFVQ18EAmphA5jFHCBjcdrcuVa/view?usp=sharing)

✅ El proyecto se divide en:

- **ControlDeHabitos2.Desktop** (Frontend - WinForms):
  > Aplicación de escritorio que permite al usuario interactuar con el sistema (crear, ver y editar hábitos, iniciar/cerrar sesión, etc.).

- **ControlDeHabitos2.API** (Backend - ASP.NET Core Web API):
  - `Controllers`: gestionan las solicitudes HTTP.
  - `Services`: contienen la lógica de negocio.
  - `Repositories`: se encargan del acceso a la base de datos usando Entity Framework Core.
  - `Models`: definen las entidades y estructuras de datos.
  - `Data`: contiene la configuración del contexto de la base de datos y las migraciones.

Esta arquitectura sigue el patrón de capas, lo que facilita el mantenimiento, escalabilidad y testeo del sistema.

## 🚀 Cómo ejecutar el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/tobiaszarlenga/ControlDeHabitos2.git
cd ControlDeHabitos2.API
dotnet ef database update
dotnet run
```
Ejecutar el frontend (WinForms):
Abrí la solución ControlDeHabitos2.sln en Visual Studio.
Establecé el proyecto ControlDeHabitos2.Desktop como predeterminado.
Ejecutalo con F5 o desde el botón "Iniciar".


✍️ Autor
Tobias Zarlenga – Estudiante de Programación 3
Proyecto académico: Control de Hábitos con arquitectura de capas y persistencia de datos
📄 Licencia
Uso educativo. No apto para producción.
