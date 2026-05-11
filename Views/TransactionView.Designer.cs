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
        headerPanel = new Panel();
        nameInput = new TextBox();
        phoneInput = new TextBox();
        cartGrid = new DataGridView();
        footerPanel = new Panel();
        transferButton = new Button();
        cashButton = new Button();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        headerPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cartGrid).BeginInit();
        footerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.Controls.Add(nameInput);
        headerPanel.Controls.Add(phoneInput);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(10);
        headerPanel.Size = new Size(911, 200);
        headerPanel.TabIndex = 2;
        // 
        // nameInput
        // 
        nameInput.Dock = DockStyle.Top;
        nameInput.Font = new Font("Segoe UI", 20F);
        nameInput.Location = new Point(10, 62);
        nameInput.Name = "nameInput";
        nameInput.PlaceholderText = "Tên khách hàng";
        nameInput.Size = new Size(891, 52);
        nameInput.TabIndex = 0;
        // 
        // phoneInput
        // 
        phoneInput.Dock = DockStyle.Top;
        phoneInput.Font = new Font("Segoe UI", 20F);
        phoneInput.Location = new Point(10, 10);
        phoneInput.Name = "phoneInput";
        phoneInput.PlaceholderText = "Số điện thoại";
        phoneInput.Size = new Size(891, 52);
        phoneInput.TabIndex = 1;
        // 
        // cartGrid
        // 
        cartGrid.AllowUserToAddRows = false;
        cartGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        cartGrid.ColumnHeadersHeight = 29;
        cartGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
        cartGrid.Dock = DockStyle.Fill;
        cartGrid.Font = new Font("Segoe UI", 20F);
        cartGrid.Location = new Point(0, 200);
        cartGrid.Name = "cartGrid";
        cartGrid.RowHeadersWidth = 51;
        cartGrid.RowTemplate.Height = 72;
        cartGrid.Size = new Size(911, 332);
        cartGrid.TabIndex = 0;
        // 
        // footerPanel
        // 
        footerPanel.Controls.Add(transferButton);
        footerPanel.Controls.Add(cashButton);
        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Location = new Point(0, 532);
        footerPanel.Name = "footerPanel";
        footerPanel.Padding = new Padding(10);
        footerPanel.Size = new Size(911, 160);
        footerPanel.TabIndex = 1;
        // 
        // transferButton
        // 
        transferButton.Dock = DockStyle.Right;
        transferButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        transferButton.Location = new Point(401, 10);
        transferButton.Name = "transferButton";
        transferButton.Size = new Size(260, 140);
        transferButton.TabIndex = 0;
        transferButton.Text = "Chuyển khoản";
        // 
        // cashButton
        // 
        cashButton.Dock = DockStyle.Right;
        cashButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        cashButton.Location = new Point(661, 10);
        cashButton.Name = "cashButton";
        cashButton.Size = new Size(240, 140);
        cashButton.TabIndex = 1;
        cashButton.Text = "Tiền mặt";
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "Sản phẩm";
        dataGridViewTextBoxColumn1.MinimumWidth = 6;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Số lượng";
        dataGridViewTextBoxColumn2.MinimumWidth = 6;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Đơn giá";
        dataGridViewTextBoxColumn3.MinimumWidth = 6;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "Thành tiền";
        dataGridViewTextBoxColumn4.MinimumWidth = 6;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        // 
        // TransactionView
        // 
        Controls.Add(cartGrid);
        Controls.Add(footerPanel);
        Controls.Add(headerPanel);
        Name = "TransactionView";
        Size = new Size(911, 692);
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cartGrid).EndInit();
        footerPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
}
