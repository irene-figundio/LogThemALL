# LogThemALL

`LogThemALL` è una libreria .NET Core avanzata per il logging e l'audit, progettata per essere facilmente integrata in WebAPI e altre applicazioni .NET.

## Caratteristiche principali

- **Database Dinamico**: Crea automaticamente un database SQL Server separato per ogni servizio, nominato come `AuditLog_<NomeServizio>`.
- **Modello di Audit Avanzato**: Supporta il tracciamento dettagliato di attori, target, contesto HTTP, cambiamenti di dati e performance.
- **Operazioni CRUD**: Supporto completo per la creazione, lettura, aggiornamento e eliminazione dei log di audit.
- **Ricerca Avanzata**: Metodi di ricerca flessibili per filtrare i log per data, tipo di evento, severità, esito, utente e altro.
- **Integrazione Semplice**: Estensioni per `IServiceCollection` per una registrazione rapida.
- **Storage Efficiente**: Utilizza le funzionalità JSON di SQL Server per memorizzare dati strutturati complessi.

## Installazione

Aggiungi il riferimento al progetto `LogThemALL.csproj` alla tua soluzione.

## Utilizzo

### 1. Registrazione del servizio

In `Program.cs` o `Startup.cs` della tua WebAPI:

```csharp
builder.Services.AddAdvancedLogging(
    connectionString: "Server=tuo_server;Database=Master;Trusted_Connection=True;",
    serviceName: "MiaAPI"
);
```

### 2. Logging di un evento da HttpContext

La libreria fornisce una factory per popolare i dati comuni direttamente dal contesto HTTP:

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
        serviceName: "MiaAPI"
    );

    auditLog.Message = $"Ordine {order.Id} creato con successo";

    await auditService.LogAsync(auditLog);

    return Ok();
}
```

### 3. Ricerca dei Log (Auditing)

Puoi effettuare ricerche mirate sui log esistenti:

```csharp
var criteria = new LogSearchCriteria
{
    FromUtc = DateTimeOffset.UtcNow.AddDays(-7),
    EventType = AuditEventType.Error,
    UserId = "user-123"
};

var logs = await auditService.SearchAsync(criteria);
```

### 4. Operazioni CRUD manuali

```csharp
// Recupero per ID
var log = await auditService.GetByIdAsync(guid);

// Eliminazione
await auditService.DeleteAsync(guid);
```

## Struttura del Database

La libreria utilizza Entity Framework Core per gestire lo schema. I campi complessi come `Actor`, `Http`, `Target`, `Changes` e `Error` sono mappati come colonne JSON per massima flessibilità.

Il database viene creato automaticamente alla prima operazione di logging se non esiste.
