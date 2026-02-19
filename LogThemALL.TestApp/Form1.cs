using LogThemALL.Models;
using LogThemALL.Services;
using System.Text.Json;

namespace LogThemALL.TestApp
{
    public partial class Form1 : Form
    {
        private readonly IAuditService _auditService;
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Master;Trusted_Connection=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            _auditService = new AuditService(_connectionString, "TestWinForm");
        }

        private async void btnLog_Click(object sender, EventArgs e)
        {
            var log = new AuditLog
            {
                EventName = "WinForm.TestEvent",
                Message = "This is a test log from Windows Form",
                Severity = AuditSeverity.Info,
                EventType = AuditEventType.Execute,
                Outcome = AuditOutcome.Success,
                Environment = "Development"
            };

            await _auditService.LogAsync(log);
            MessageBox.Show("Log saved!");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var logs = await _auditService.SearchAsync(new LogSearchCriteria
            {
                ServiceName = "TestWinForm"
            });

            dataGridView1.DataSource = logs;
        }
    }
}
