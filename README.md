# Notification System

A simple and extensible **Notification System** built with **ASP.NET Core (.NET 8)**.

Supports sending notifications via **Email**, **SMS**, **Push**, and is easily extendable to new channels (e.g. WhatsApp, Telegram) without modifying existing code.

---

## Features
- Strategy-based notification senders
- Plugin-style architecture (auto-discovery via DI)
- Async/await support
- Logging with `ILogger<T>`
- Swagger UI for testing
- SOLID-compliant and testable design

---

## Run
```bash
dotnet restore
dotnet run
