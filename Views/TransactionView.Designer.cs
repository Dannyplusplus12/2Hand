namespace _2Hand.Views;

partial class TransactionView
{
    private System.ComponentModel.IContainer components = null;
    private Panel headerPanel;
    private TextBox phoneInput;
    private TextBox nameInput;
    private DataGridView cartGrid;
    private Panel footerPanel;
    private Button cashButton;
    private Button transferButton;

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
        headerPanel = new Panel();
        phoneInput = new TextBox();
        nameInput = new TextBox();
        cartGrid = new DataGridView();
        footerPanel = new Panel();
        cashButton = new Button();
        transferButton = new Button();
        SuspendLayout();

        Dock = DockStyle.Fill;

        headerPanel.Dock = DockStyle.Top;
        headerPanel.Height = 200;
        headerPanel.Padding = new Padding(10);

        phoneInput.Dock = DockStyle.Top;
        phoneInput.Height = 70;
        phoneInput.Font = new Font("Segoe UI", 20F, FontStyle.Regular);
        phoneInput.PlaceholderText = "Số điện thoại";

        nameInput.Dock = DockStyle.Top;
        nameInput.Height = 70;
        nameInput.Font = new Font("Segoe UI", 20F, FontStyle.Regular);
        nameInput.PlaceholderText = "Tên khách hàng";

        headerPanel.Controls.Add(nameInput);
        headerPanel.Controls.Add(phoneInput);

        cartGrid.Dock = DockStyle.Fill;
        cartGrid.AllowUserToAddRows = false;
        cartGrid.RowTemplate.Height = 72;
        cartGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        cartGrid.Font = new Font("Segoe UI", 20F, FontStyle.Regular);
        cartGrid.Columns.Add("Product", "Sản phẩm");
        cartGrid.Columns.Add("Quantity", "Số lượng");
        cartGrid.Columns.Add("Price", "Đơn giá");
        cartGrid.Columns.Add("Total", "Thành tiền");

        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Height = 160;
        footerPanel.Padding = new Padding(10);

        cashButton.Text = "Tiền mặt";
        cashButton.Dock = DockStyle.Right;
        cashButton.Width = 240;
        cashButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        transferButton.Text = "Chuyển khoản";
        transferButton.Dock = DockStyle.Right;
        transferButton.Width = 260;
        transferButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        footerPanel.Controls.Add(transferButton);
        footerPanel.Controls.Add(cashButton);

        Controls.Add(cartGrid);
        Controls.Add(footerPanel);
        Controls.Add(headerPanel);

        ResumeLayout(false);
    }
}
