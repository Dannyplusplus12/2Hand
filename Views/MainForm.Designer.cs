using FontAwesome.Sharp;

namespace _2Hand.Views;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel sidebar;
    private Panel header;
    private Panel content;
    private Label titleLabel;
    private IconButton dashboardButton;
    private IconButton inventoryButton;
    private IconButton customerButton;
    private IconButton transactionButton;

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
        sidebar = new Panel();
        transactionButton = new IconButton();
        customerButton = new IconButton();
        inventoryButton = new IconButton();
        dashboardButton = new IconButton();
        header = new Panel();
        titleLabel = new Label();
        content = new Panel();
        sidebar.SuspendLayout();
        header.SuspendLayout();
        SuspendLayout();
        // 
        // sidebar
        // 
        sidebar.Controls.Add(transactionButton);
        sidebar.Controls.Add(customerButton);
        sidebar.Controls.Add(inventoryButton);
        sidebar.Controls.Add(dashboardButton);
        sidebar.Dock = DockStyle.Left;
        sidebar.Location = new Point(0, 0);
        sidebar.Name = "sidebar";
        sidebar.Padding = new Padding(10);
        sidebar.Size = new Size(280, 953);
        sidebar.TabIndex = 2;
        // 
        // transactionButton
        // 
        transactionButton.Dock = DockStyle.Top;
        transactionButton.FlatStyle = FlatStyle.Flat;
        transactionButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        transactionButton.IconChar = IconChar.Receipt;
        transactionButton.IconColor = Color.White;
        transactionButton.IconFont = IconFont.Auto;
        transactionButton.IconSize = 28;
        transactionButton.ImageAlign = ContentAlignment.MiddleLeft;
        transactionButton.Location = new Point(10, 280);
        transactionButton.Name = "transactionButton";
        transactionButton.Padding = new Padding(20, 0, 0, 0);
        transactionButton.Size = new Size(260, 90);
        transactionButton.TabIndex = 0;
        transactionButton.Text = "Giao dịch";
        transactionButton.TextAlign = ContentAlignment.MiddleLeft;
        transactionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        transactionButton.Click += TransactionButton_Click;
        // 
        // customerButton
        // 
        customerButton.Dock = DockStyle.Top;
        customerButton.FlatStyle = FlatStyle.Flat;
        customerButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        customerButton.IconChar = IconChar.UserFriends;
        customerButton.IconColor = Color.White;
        customerButton.IconFont = IconFont.Auto;
        customerButton.IconSize = 28;
        customerButton.ImageAlign = ContentAlignment.MiddleLeft;
        customerButton.Location = new Point(10, 190);
        customerButton.Name = "customerButton";
        customerButton.Padding = new Padding(20, 0, 0, 0);
        customerButton.Size = new Size(260, 90);
        customerButton.TabIndex = 1;
        customerButton.Text = "Khách";
        customerButton.TextAlign = ContentAlignment.MiddleLeft;
        customerButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        customerButton.Click += CustomerButton_Click;
        // 
        // inventoryButton
        // 
        inventoryButton.Dock = DockStyle.Top;
        inventoryButton.FlatStyle = FlatStyle.Flat;
        inventoryButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        inventoryButton.IconChar = IconChar.BoxesStacked;
        inventoryButton.IconColor = Color.White;
        inventoryButton.IconFont = IconFont.Auto;
        inventoryButton.IconSize = 28;
        inventoryButton.ImageAlign = ContentAlignment.MiddleLeft;
        inventoryButton.Location = new Point(10, 100);
        inventoryButton.Name = "inventoryButton";
        inventoryButton.Padding = new Padding(20, 0, 0, 0);
        inventoryButton.Size = new Size(260, 90);
        inventoryButton.TabIndex = 2;
        inventoryButton.Text = "Kho";
        inventoryButton.TextAlign = ContentAlignment.MiddleLeft;
        inventoryButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        inventoryButton.Click += InventoryButton_Click;
        // 
        // dashboardButton
        // 
        dashboardButton.Dock = DockStyle.Top;
        dashboardButton.FlatStyle = FlatStyle.Flat;
        dashboardButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        dashboardButton.IconChar = IconChar.PieChart;
        dashboardButton.IconColor = Color.White;
        dashboardButton.IconFont = IconFont.Auto;
        dashboardButton.IconSize = 28;
        dashboardButton.ImageAlign = ContentAlignment.MiddleLeft;
        dashboardButton.Location = new Point(10, 10);
        dashboardButton.Name = "dashboardButton";
        dashboardButton.Padding = new Padding(20, 0, 0, 0);
        dashboardButton.Size = new Size(260, 90);
        dashboardButton.TabIndex = 3;
        dashboardButton.Text = "Tổng quan";
        dashboardButton.TextAlign = ContentAlignment.MiddleLeft;
        dashboardButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        dashboardButton.Click += DashboardButton_Click;
        // 
        // header
        // 
        header.Controls.Add(titleLabel);
        header.Dock = DockStyle.Top;
        header.Location = new Point(280, 0);
        header.Name = "header";
        header.Padding = new Padding(20);
        header.Size = new Size(1502, 120);
        header.TabIndex = 1;
        // 
        // titleLabel
        // 
        titleLabel.Dock = DockStyle.Fill;
        titleLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
        titleLabel.Location = new Point(20, 20);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(1462, 80);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Tổng quan";
        titleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // content
        // 
        content.Dock = DockStyle.Fill;
        content.Location = new Point(280, 120);
        content.Name = "content";
        content.Padding = new Padding(20);
        content.Size = new Size(1502, 833);
        content.TabIndex = 0;
        // 
        // MainForm
        // 
        ClientSize = new Size(1782, 953);
        Controls.Add(content);
        Controls.Add(header);
        Controls.Add(sidebar);
        MinimumSize = new Size(1600, 900);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "2Hand Management";
        sidebar.ResumeLayout(false);
        header.ResumeLayout(false);
        ResumeLayout(false);
    }
}
