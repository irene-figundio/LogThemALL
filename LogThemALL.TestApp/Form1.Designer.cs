namespace LogThemALL.TestApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.btnInitService = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnString = new System.Windows.Forms.Label();
            this.tabCRUD = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtLogMessage = new System.Windows.Forms.TextBox();
            this.lblLogMessage = new System.Windows.Forms.Label();
            this.cmbOutcome = new System.Windows.Forms.ComboBox();
            this.lblOutcome = new System.Windows.Forms.Label();
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearchEventType = new System.Windows.Forms.Label();
            this.cmbSearchEventType = new System.Windows.Forms.ComboBox();
            this.txtSearchUserId = new System.Windows.Forms.TextBox();
            this.lblSearchUserId = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabCRUD.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabCRUD);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 200);
            this.tabControl1.TabIndex = 0;
            //
            // tabConfig
            //
            this.tabConfig.Controls.Add(this.btnInitService);
            this.tabConfig.Controls.Add(this.txtServiceName);
            this.tabConfig.Controls.Add(this.lblServiceName);
            this.tabConfig.Controls.Add(this.txtConnectionString);
            this.tabConfig.Controls.Add(this.lblConnString);
            this.tabConfig.Location = new System.Drawing.Point(4, 24);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(792, 172);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "Configurazione";
            this.tabConfig.UseVisualStyleBackColor = true;
            //
            // btnInitService
            //
            this.btnInitService.Location = new System.Drawing.Point(10, 110);
            this.btnInitService.Name = "btnInitService";
            this.btnInitService.Size = new System.Drawing.Size(150, 23);
            this.btnInitService.TabIndex = 4;
            this.btnInitService.Text = "Inizializza Servizio";
            this.btnInitService.UseVisualStyleBackColor = true;
            this.btnInitService.Click += new System.EventHandler(this.btnInitService_Click);
            //
            // txtServiceName
            //
            this.txtServiceName.Location = new System.Drawing.Point(10, 75);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(300, 23);
            this.txtServiceName.TabIndex = 3;
            this.txtServiceName.Text = "TestWinForm";
            //
            // lblServiceName
            //
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(10, 57);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(79, 15);
            this.lblServiceName.TabIndex = 2;
            this.lblServiceName.Text = "Nome Servizio";
            //
            // txtConnectionString
            //
            this.txtConnectionString.Location = new System.Drawing.Point(10, 27);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(700, 23);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Text = "Server=(localdb)\\mssqllocaldb;Database=Master;Trusted_Connection=True;TrustServerCertificate=True";
            //
            // lblConnString
            //
            this.lblConnString.AutoSize = true;
            this.lblConnString.Location = new System.Drawing.Point(10, 9);
            this.lblConnString.Name = "lblConnString";
            this.lblConnString.Size = new System.Drawing.Size(104, 15);
            this.lblConnString.TabIndex = 0;
            this.lblConnString.Text = "Stringa Connessione";
            //
            // tabCRUD
            //
            this.tabCRUD.Controls.Add(this.btnDelete);
            this.tabCRUD.Controls.Add(this.btnUpdate);
            this.tabCRUD.Controls.Add(this.btnCreate);
            this.tabCRUD.Controls.Add(this.txtLogMessage);
            this.tabCRUD.Controls.Add(this.lblLogMessage);
            this.tabCRUD.Controls.Add(this.cmbOutcome);
            this.tabCRUD.Controls.Add(this.lblOutcome);
            this.tabCRUD.Controls.Add(this.cmbSeverity);
            this.tabCRUD.Controls.Add(this.lblSeverity);
            this.tabCRUD.Controls.Add(this.cmbEventType);
            this.tabCRUD.Controls.Add(this.lblEventType);
            this.tabCRUD.Controls.Add(this.txtEventName);
            this.tabCRUD.Controls.Add(this.lblEventName);
            this.tabCRUD.Location = new System.Drawing.Point(4, 24);
            this.tabCRUD.Name = "tabCRUD";
            this.tabCRUD.Padding = new System.Windows.Forms.Padding(3);
            this.tabCRUD.Size = new System.Drawing.Size(792, 172);
            this.tabCRUD.TabIndex = 1;
            this.tabCRUD.Text = "Gestione Log (CRUD)";
            this.tabCRUD.UseVisualStyleBackColor = true;
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(210, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Elimina Selez.";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(110, 130);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Aggiorna";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnCreate
            //
            this.btnCreate.Location = new System.Drawing.Point(10, 130);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Crea";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // txtLogMessage
            //
            this.txtLogMessage.Location = new System.Drawing.Point(330, 75);
            this.txtLogMessage.Multiline = true;
            this.txtLogMessage.Name = "txtLogMessage";
            this.txtLogMessage.Size = new System.Drawing.Size(400, 45);
            this.txtLogMessage.TabIndex = 9;
            //
            // lblLogMessage
            //
            this.lblLogMessage.AutoSize = true;
            this.lblLogMessage.Location = new System.Drawing.Point(330, 57);
            this.lblLogMessage.Name = "lblLogMessage";
            this.lblLogMessage.Size = new System.Drawing.Size(63, 15);
            this.lblLogMessage.TabIndex = 8;
            this.lblLogMessage.Text = "Messaggio";
            //
            // cmbOutcome
            //
            this.cmbOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutcome.FormattingEnabled = true;
            this.cmbOutcome.Location = new System.Drawing.Point(170, 75);
            this.cmbOutcome.Name = "cmbOutcome";
            this.cmbOutcome.Size = new System.Drawing.Size(150, 23);
            this.cmbOutcome.TabIndex = 7;
            //
            // lblOutcome
            //
            this.lblOutcome.AutoSize = true;
            this.lblOutcome.Location = new System.Drawing.Point(170, 57);
            this.lblOutcome.Name = "lblOutcome";
            this.lblOutcome.Size = new System.Drawing.Size(35, 15);
            this.lblOutcome.TabIndex = 6;
            this.lblOutcome.Text = "Esito";
            //
            // cmbSeverity
            //
            this.cmbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeverity.FormattingEnabled = true;
            this.cmbSeverity.Location = new System.Drawing.Point(10, 75);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(150, 23);
            this.cmbSeverity.TabIndex = 5;
            //
            // lblSeverity
            //
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Location = new System.Drawing.Point(10, 57);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(48, 15);
            this.lblSeverity.TabIndex = 4;
            this.lblSeverity.Text = "Gravità";
            //
            // cmbEventType
            //
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(330, 27);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(150, 23);
            this.cmbEventType.TabIndex = 3;
            //
            // lblEventType
            //
            this.lblEventType.AutoSize = true;
            this.lblEventType.Location = new System.Drawing.Point(330, 9);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(76, 15);
            this.lblEventType.TabIndex = 2;
            this.lblEventType.Text = "Tipo Evento";
            //
            // txtEventName
            //
            this.txtEventName.Location = new System.Drawing.Point(10, 27);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(300, 23);
            this.txtEventName.TabIndex = 1;
            //
            // lblEventName
            //
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(10, 9);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(78, 15);
            this.lblEventName.TabIndex = 0;
            this.lblEventName.Text = "Nome Evento";
            //
            // tabSearch
            //
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Controls.Add(this.lblSearchEventType);
            this.tabSearch.Controls.Add(this.cmbSearchEventType);
            this.tabSearch.Controls.Add(this.txtSearchUserId);
            this.tabSearch.Controls.Add(this.lblSearchUserId);
            this.tabSearch.Location = new System.Drawing.Point(4, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(792, 172);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Ricerca Audit";
            this.tabSearch.UseVisualStyleBackColor = true;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(10, 110);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Esegui Ricerca";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // lblSearchEventType
            //
            this.lblSearchEventType.AutoSize = true;
            this.lblSearchEventType.Location = new System.Drawing.Point(10, 57);
            this.lblSearchEventType.Name = "lblSearchEventType";
            this.lblSearchEventType.Size = new System.Drawing.Size(76, 15);
            this.lblSearchEventType.TabIndex = 3;
            this.lblSearchEventType.Text = "Tipo Evento";
            //
            // cmbSearchEventType
            //
            this.cmbSearchEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchEventType.FormattingEnabled = true;
            this.cmbSearchEventType.Location = new System.Drawing.Point(10, 75);
            this.cmbSearchEventType.Name = "cmbSearchEventType";
            this.cmbSearchEventType.Size = new System.Drawing.Size(200, 23);
            this.cmbSearchEventType.TabIndex = 2;
            //
            // txtSearchUserId
            //
            this.txtSearchUserId.Location = new System.Drawing.Point(10, 27);
            this.txtSearchUserId.Name = "txtSearchUserId";
            this.txtSearchUserId.Size = new System.Drawing.Size(200, 23);
            this.txtSearchUserId.TabIndex = 1;
            //
            // lblSearchUserId
            //
            this.lblSearchUserId.AutoSize = true;
            this.lblSearchUserId.Location = new System.Drawing.Point(10, 9);
            this.lblSearchUserId.Name = "lblSearchUserId";
            this.lblSearchUserId.Size = new System.Drawing.Size(46, 15);
            this.lblSearchUserId.TabIndex = 0;
            this.lblSearchUserId.Text = "User ID";
            //
            // dataGridView1
            //
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(800, 244);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "LogThemALL Advanced Testing Tool";
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.tabCRUD.ResumeLayout(false);
            this.tabCRUD.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabCRUD;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblConnString;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnInitService;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.ComboBox cmbSeverity;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.ComboBox cmbOutcome;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.TextBox txtLogMessage;
        private System.Windows.Forms.Label lblLogMessage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSearchUserId;
        private System.Windows.Forms.TextBox txtSearchUserId;
        private System.Windows.Forms.Label lblSearchEventType;
        private System.Windows.Forms.ComboBox cmbSearchEventType;
        private System.Windows.Forms.Button btnSearch;
    }
}
