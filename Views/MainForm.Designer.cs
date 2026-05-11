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
        components = new System.ComponentModel.Container();
        sidebar = new Panel();
        header = new Panel();
        content = new Panel();
        titleLabel = new Label();
        dashboardButton = new IconButton();
        inventoryButton = new IconButton();
        customerButton = new IconButton();
        transactionButton = new IconButton();
        SuspendLayout();

        StartPosition = FormStartPosition.CenterScreen;
        Text = "2Hand Management";
        Width = 1800;
        Height = 1000;
        MinimumSize = new Size(1600, 900);

        sidebar.Dock = DockStyle.Left;
        sidebar.Width = 280;
        sidebar.Padding = new Padding(10);

        header.Dock = DockStyle.Top;
        header.Height = 120;
        header.Padding = new Padding(20);

        content.Dock = DockStyle.Fill;
        content.Padding = new Padding(20);

        titleLabel.Text = "Tổng quan";
        titleLabel.Dock = DockStyle.Fill;
        titleLabel.AutoSize = false;
        titleLabel.TextAlign = ContentAlignment.MiddleLeft;
        titleLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);

        dashboardButton.Text = "Tổng quan";
        dashboardButton.Dock = DockStyle.Top;
        dashboardButton.Height = 90;
        dashboardButton.IconChar = IconChar.ChartPie;
        dashboardButton.IconColor = Color.White;
        dashboardButton.IconSize = 28;
        dashboardButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        dashboardButton.TextAlign = ContentAlignment.MiddleLeft;
        dashboardButton.ImageAlign = ContentAlignment.MiddleLeft;
        dashboardButton.Padding = new Padding(20, 0, 0, 0);
        dashboardButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        dashboardButton.FlatStyle = FlatStyle.Flat;
        dashboardButton.Click += DashboardButton_Click;

        inventoryButton.Text = "Kho";
        inventoryButton.Dock = DockStyle.Top;
        inventoryButton.Height = 90;
        inventoryButton.IconChar = IconChar.BoxesStacked;
        inventoryButton.IconColor = Color.White;
        inventoryButton.IconSize = 28;
        inventoryButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        inventoryButton.TextAlign = ContentAlignment.MiddleLeft;
        inventoryButton.ImageAlign = ContentAlignment.MiddleLeft;
        inventoryButton.Padding = new Padding(20, 0, 0, 0);
        inventoryButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        inventoryButton.FlatStyle = FlatStyle.Flat;
        inventoryButton.Click += InventoryButton_Click;

        customerButton.Text = "Khách";
        customerButton.Dock = DockStyle.Top;
        customerButton.Height = 90;
        customerButton.IconChar = IconChar.UserGroup;
        customerButton.IconColor = Color.White;
        customerButton.IconSize = 28;
        customerButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        customerButton.TextAlign = ContentAlignment.MiddleLeft;
        customerButton.ImageAlign = ContentAlignment.MiddleLeft;
        customerButton.Padding = new Padding(20, 0, 0, 0);
        customerButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        customerButton.FlatStyle = FlatStyle.Flat;
        customerButton.Click += CustomerButton_Click;

        transactionButton.Text = "Giao dịch";
        transactionButton.Dock = DockStyle.Top;
        transactionButton.Height = 90;
        transactionButton.IconChar = IconChar.Receipt;
        transactionButton.IconColor = Color.White;
        transactionButton.IconSize = 28;
        transactionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        transactionButton.TextAlign = ContentAlignment.MiddleLeft;
        transactionButton.ImageAlign = ContentAlignment.MiddleLeft;
        transactionButton.Padding = new Padding(20, 0, 0, 0);
        transactionButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        transactionButton.FlatStyle = FlatStyle.Flat;
        transactionButton.Click += TransactionButton_Click;

        sidebar.Controls.Add(transactionButton);
        sidebar.Controls.Add(customerButton);
        sidebar.Controls.Add(inventoryButton);
        sidebar.Controls.Add(dashboardButton);

        header.Controls.Add(titleLabel);

        Controls.Add(content);
        Controls.Add(header);
        Controls.Add(sidebar);

        ResumeLayout(false);
    }
}
