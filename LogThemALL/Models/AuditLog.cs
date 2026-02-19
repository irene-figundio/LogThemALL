using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace LogThemALL.Models;

public enum AuditEventType { Unknown = 0, Authentication, Authorization, Create, Read, Update, Delete, Execute, Export, Import, Error, ConfigurationChange }

public enum AuditSeverity { Trace = 0, Info, Warning, Error, Critical }

public enum AuditOutcome { Unknown = 0, Success, Failure, Denied }

public class AuditLog
{
    // --- Identità / correlazione ---
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset TimestampUtc { get; set; } = DateTimeOffset.UtcNow;
    public string? CorrelationId { get; set; }
    public string? RequestId { get; set; }
    public string? TraceId { get; set; }
    public string? SpanId { get; set; }

    // --- Classificazione evento ---
    public AuditEventType EventType { get; set; } = AuditEventType.Unknown;
    public AuditSeverity Severity { get; set; } = AuditSeverity.Info;
    public AuditOutcome Outcome { get; set; } = AuditOutcome.Unknown;
    public string? EventName { get; set; }
    public string? Category { get; set; }
    public string? Message { get; set; }

    // --- Attore (chi compie l’azione) ---
    public AuditActor Actor { get; set; } = new();

    // --- Target (su cosa agisce) ---
    public AuditTarget? Target { get; set; }

    // --- Richiesta HTTP (se applicabile) ---
    public AuditHttpContext? Http { get; set; }

    // --- Dati & cambiamenti ---
    public JsonDocument? Before { get; set; }
    public JsonDocument? After { get; set; }
    public List<AuditChange>? Changes { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public JsonDocument? Metadata { get; set; }

    // --- Performance / diagnostica ---
    public long? DurationMs { get; set; }
    public string? Host { get; set; }
    public string? ServiceName { get; set; }
    public string? ServiceVersion { get; set; }
    public string? Environment { get; set; } // dev/stage/prod

    // --- Errori (se Outcome Failure/Error) ---
    public AuditError? Error { get; set; }

    // --- Multi-tenant (opzionale) ---
    public string? TenantId { get; set; }

    // --- Conformità / privacy (opzionale) ---
    public bool IsRedacted { get; set; } = true;
    public int SchemaVersion { get; set; } = 1;
}

public class AuditActor
{
    public string? UserId { get; set; }
    public string? Username { get; set; }
    public List<string>? Roles { get; set; }
    public string? ActorType { get; set; } = "User";
    public string? ClientId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public AuditImpersonation? Impersonation { get; set; }
}

public class AuditImpersonation
{
    public string? ImpersonatorUserId { get; set; }
    public string? ImpersonatorUsername { get; set; }
    public string? Reason { get; set; }
}

public class AuditTarget
{
    public string? ResourceType { get; set; }
    public string? ResourceId { get; set; }
    public string? ResourceKey { get; set; }
    public string? Action { get; set; }
}

public class AuditHttpContext
{
    public string? Method { get; set; }
    public string? Path { get; set; }
    public string? QueryString { get; set; }
    public string? RouteTemplate { get; set; }
    public int? StatusCode { get; set; }
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Forwarded { get; set; }
    public long? RequestBodySize { get; set; }
    public long? ResponseBodySize { get; set; }
    public string? Protocol { get; set; }
}

public class AuditChange
{
    public string? Field { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public bool IsSensitive { get; set; }
    public string? Operation { get; set; }
}

public class AuditError
{
    public string? ExceptionType { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Code { get; set; }
    public JsonDocument? Details { get; set; }
}

public static class AuditFactory
{
    public static AuditLog FromHttpContext(
        HttpContext ctx,
        AuditEventType type,
        string? eventName = null,
        AuditOutcome outcome = AuditOutcome.Unknown,
        AuditSeverity severity = AuditSeverity.Info,
        string? serviceName = null)
    {
        var activity = Activity.Current;
        var audit = new AuditLog
        {
            EventType = type,
            EventName = eventName,
            Outcome = outcome,
            Severity = severity,
            TraceId = activity?.TraceId.ToString(),
            SpanId = activity?.SpanId.ToString(),
            CorrelationId = ctx.TraceIdentifier,
            RequestId = ctx.TraceIdentifier,
            Host = Environment.MachineName,
            ServiceName = serviceName,
            Http = new AuditHttpContext
            {
                Method = ctx.Request.Method,
                Path = ctx.Request.Path.Value,
                QueryString = ctx.Request.QueryString.HasValue ? ctx.Request.QueryString.Value : null,
                Protocol = ctx.Request.Protocol
            },
            Actor = new AuditActor
            {
                UserId = ctx.User?.FindFirst("sub")?.Value
                         ?? ctx.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Username = ctx.User?.Identity?.Name,
                IpAddress = ctx.Connection.RemoteIpAddress?.ToString(),
                UserAgent = ctx.Request.Headers.TryGetValue("User-Agent", out var ua) ? ua.ToString() : null
            }
        };

        return audit;
    }
}
