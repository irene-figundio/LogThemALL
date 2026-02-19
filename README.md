# LogThemALL

`LogThemALL` è una libreria .NET Core avanzata per il logging e l'audit, progettata per essere facilmente integrata in WebAPI e altre applicazioni .NET. Offre una soluzione robusta per il tracciamento delle attività, la diagnostica degli errori e la conformità normativa.

## Caratteristiche principali

- **Database Dinamico**: Crea automaticamente un database SQL Server separato per ogni servizio (es: `AuditLog_CustomerAPI`, `AuditLog_OrderAPI`), garantendo isolamento e scalabilità.
- **Modello di Audit Avanzato**:
  - **Attore**: Chi ha compiuto l'azione (UserId, IpAddress, UserAgent, Impersonificazione).
  - **Target**: Su cosa è stata compiuta l'azione (Risorsa, ID, Azione).
  - **Contesto HTTP**: Dettagli completi della richiesta (Metodo, Path, StatusCode, Headers).
  - **Dati & Cambiamenti**: Snapshot "Before/After" e lista granulare dei cambiamenti.
  - **Diagnostica**: TraceID, SpanID e DurationMs per il distributed tracing.
- **Operazioni CRUD Complete**: Metodi per creare, leggere, aggiornare ed eliminare i log di audit.
- **Ricerca & Auditing Avanzato**: Motore di ricerca flessibile basato su criteri multipli (Periodo, Tipo Evento, TenantId, StatusCode, etc.).
- **Integrazione Plug-and-Play**: Estensioni per `IServiceCollection` e factory per `HttpContext`.
- **Storage Moderno**: Utilizza le funzionalità JSON native di SQL Server tramite Entity Framework Core per memorizzare dati strutturati complessi in modo efficiente.

## Installazione

Aggiungi il riferimento al progetto `LogThemALL.csproj` alla tua soluzione. Assicurati di avere installato i pacchetti NuGet necessari:
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.Data.SqlClient`

## Utilizzo

### 1. Registrazione del servizio

In `Program.cs` o `Startup.cs` della tua WebAPI:

```csharp
using LogThemALL;

// Registra il servizio di audit
builder.Services.AddAdvancedLogging(
    connectionString: "Server=tuo_server;Database=Master;Trusted_Connection=True;TrustServerCertificate=True",
    serviceName: "MiaWebAPI"
);
```

### 2. Logging da un Controller WebAPI

Utilizza `AuditFactory.FromHttpContext` per generare automaticamente un log pre-popolato con i dati della richiesta:

```csharp
[HttpPost]
public async Task<IActionResult> CreateOrder(Order order, [FromServices] IAuditService auditService)
{
    // ... logica di business ...

    var auditLog = AuditFactory.FromHttpContext(
        HttpContext,
        AuditEventType.Create,
        eventName: "Order.Create",
        outcome: AuditOutcome.Success,
        serviceName: "MiaWebAPI"
    );

    auditLog.Message = $"Ordine {order.Id} creato correttamente";
    auditLog.TenantId = "Client_001";

    await auditService.LogAsync(auditLog);

    return Ok();
}
```

### 3. Ricerca Avanzata (Auditing)

Filtra i log utilizzando `LogSearchCriteria`:

```csharp
var criteria = new LogSearchCriteria
{
    FromUtc = DateTimeOffset.UtcNow.AddDays(-30),
    ToUtc = DateTimeOffset.UtcNow,
    EventType = AuditEventType.Error,
    TenantId = "Client_001",
    HttpStatusCode = 500
};

var errorLogs = await auditService.SearchAsync(criteria);
```

## Progetto di Test (Windows Forms)

La soluzione include `LogThemALL.TestApp`, un'applicazione Windows Forms "Production Ready" per il test esaustivo della DLL.

### Funzionalità del Test Tool:
- **Configurazione Dinamica**: Cambia stringa di connessione e nome servizio a runtime.
- **CRUD Tester**: Pannello per creare log manuali, aggiornarli o eliminarli.
- **API Simulator**: Genera istantaneamente log complessi che simulano richieste WebAPI reali (completi di Actor, HttpContext e Target).
- **Audit Explorer**: Interfaccia di ricerca avanzata con filtri su date, utenti, tipi di evento, tenant e codici di stato HTTP.

## Requisiti Tecnici
- .NET 9.0 o superiore.
- SQL Server (supporta colonne JSON).
- Windows Forms (solo per il progetto di test).
