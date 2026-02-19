using LogThemALL.Models;
using LogThemALL.Services;
using System.Data;

namespace LogThemALL.TestApp
{
    public partial class Form1 : Form
    {
        private IAuditService? _auditService;
        private AuditLog? _selectedLog;

        public Form1()
        {
            InitializeComponent();
            PopulateEnums();
            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;
        }

        private void PopulateEnums()
        {
            cmbEventType.DataSource = Enum.GetValues(typeof(AuditEventType));
            cmbSeverity.DataSource = Enum.GetValues(typeof(AuditSeverity));
            cmbOutcome.DataSource = Enum.GetValues(typeof(AuditOutcome));

            var searchEventTypes = new List<object> { "Tutti" };
            searchEventTypes.AddRange(Enum.GetValues(typeof(AuditEventType)).Cast<object>());
            cmbSearchEventType.DataSource = searchEventTypes;
        }

        private void btnInitService_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtConnectionString.Text) || string.IsNullOrWhiteSpace(txtServiceName.Text))
                {
                    MessageBox.Show("Inserire stringa di connessione e nome servizio.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _auditService = new AuditService(txtConnectionString.Text, txtServiceName.Text);
                MessageBox.Show("Servizio inizializzato con successo!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore inizializzazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (_auditService == null) { MessageBox.Show("Inizializzare il servizio prima!"); return; }

            try
            {
                var log = new AuditLog
                {
                    EventName = txtEventName.Text,
                    Message = txtLogMessage.Text,
                    EventType = (AuditEventType)(cmbEventType.SelectedItem ?? AuditEventType.Unknown),
                    Severity = (AuditSeverity)(cmbSeverity.SelectedItem ?? AuditSeverity.Info),
                    Outcome = (AuditOutcome)(cmbOutcome.SelectedItem ?? AuditOutcome.Unknown),
                    TimestampUtc = DateTimeOffset.UtcNow,
                    Environment = "Test"
                };

                await _auditService.LogAsync(log);
                MessageBox.Show("Log creato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore creazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSimulateApiLog_Click(object sender, EventArgs e)
        {
            if (_auditService == null) { MessageBox.Show("Inizializzare il servizio prima!"); return; }

            try
            {
                var log = new AuditLog
                {
                    EventName = "Orders.Create",
                    Message = "Simulated API Order Creation",
                    EventType = AuditEventType.Create,
                    Severity = AuditSeverity.Info,
                    Outcome = AuditOutcome.Success,
                    TimestampUtc = DateTimeOffset.UtcNow,
                    Environment = "Production",
                    ServiceName = txtServiceName.Text,
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestId = Guid.NewGuid().ToString(),
                    TenantId = "TENANT_ABC_123",
                    Actor = new AuditActor
                    {
                        UserId = "user-api-sim",
                        Username = "api_user",
                        IpAddress = "192.168.1.100",
                        UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Simulation"
                    },
                    Http = new AuditHttpContext
                    {
                        Method = "POST",
                        Path = "/api/v1/orders",
                        StatusCode = 201,
                        Protocol = "HTTP/1.1",
                        RequestBodySize = 1024
                    },
                    Target = new AuditTarget
                    {
                        ResourceType = "Order",
                        Action = "Create"
                    }
                };

                await _auditService.LogAsync(log);
                MessageBox.Show("Log API simulato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore simulazione API: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_auditService == null || _selectedLog == null) { MessageBox.Show("Selezionare un log dalla griglia e inizializzare il servizio!"); return; }

            try
            {
                _selectedLog.EventName = txtEventName.Text;
                _selectedLog.Message = txtLogMessage.Text;
                _selectedLog.EventType = (AuditEventType)(cmbEventType.SelectedItem ?? AuditEventType.Unknown);
                _selectedLog.Severity = (AuditSeverity)(cmbSeverity.SelectedItem ?? AuditSeverity.Info);
                _selectedLog.Outcome = (AuditOutcome)(cmbOutcome.SelectedItem ?? AuditOutcome.Unknown);

                await _auditService.UpdateAsync(_selectedLog);
                MessageBox.Show("Log aggiornato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore aggiornamento: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_auditService == null || _selectedLog == null) { MessageBox.Show("Selezionare un log dalla griglia!"); return; }

            try
            {
                var confirm = MessageBox.Show("Sei sicuro di voler eliminare il log selezionato?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    await _auditService.DeleteAsync(_selectedLog.Id);
                    MessageBox.Show("Log eliminato!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore eliminazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (_auditService == null) { MessageBox.Show("Inizializzare il servizio!"); return; }

            try
            {
                var criteria = new LogSearchCriteria();

                if (!string.IsNullOrWhiteSpace(txtSearchUserId.Text))
                    criteria.UserId = txtSearchUserId.Text;

                if (cmbSearchEventType.SelectedIndex > 0)
                    criteria.EventType = (AuditEventType)(cmbSearchEventType.SelectedItem ?? AuditEventType.Unknown);

                if (!string.IsNullOrWhiteSpace(txtSearchTenantId.Text))
                    criteria.TenantId = txtSearchTenantId.Text;

                if (int.TryParse(txtSearchStatusCode.Text, out int statusCode))
                    criteria.HttpStatusCode = statusCode;

                criteria.FromUtc = new DateTimeOffset(dtpFrom.Value.Date);
                criteria.ToUtc = new DateTimeOffset(dtpTo.Value.Date.AddDays(1).AddTicks(-1));

                var results = await _auditService.SearchAsync(criteria);
                dataGridView1.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore ricerca: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RefreshGrid()
        {
            if (_auditService == null) return;
            dataGridView1.DataSource = await _auditService.GetAllAsync();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _selectedLog = dataGridView1.SelectedRows[0].DataBoundItem as AuditLog;

                if (_selectedLog != null)
                {
                    txtEventName.Text = _selectedLog.EventName;
                    txtLogMessage.Text = _selectedLog.Message;
                    cmbEventType.SelectedItem = _selectedLog.EventType;
                    cmbSeverity.SelectedItem = _selectedLog.Severity;
                    cmbOutcome.SelectedItem = _selectedLog.Outcome;
                }
            }
        }
    }
}
