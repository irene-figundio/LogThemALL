using System;

namespace LogThemALL.Models;

public class LogSearchCriteria
{
    public DateTimeOffset? FromUtc { get; set; }
    public DateTimeOffset? ToUtc { get; set; }
    public AuditEventType? EventType { get; set; }
    public AuditSeverity? Severity { get; set; }
    public AuditOutcome? Outcome { get; set; }
    public string? ServiceName { get; set; }
    public string? CorrelationId { get; set; }
    public string? UserId { get; set; }
    public string? EventName { get; set; }
    public string? TenantId { get; set; }
    public int? HttpStatusCode { get; set; }
}
