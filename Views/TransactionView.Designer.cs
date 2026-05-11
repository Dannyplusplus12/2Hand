namespace _2Hand.Views;

partial class TransactionView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer layout;
    private Panel leftPanel;
    private Panel searchPanel;
    private TextBox searchBox;
    private FlowLayoutPanel productPanel;
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
        layout = new SplitContainer();
        leftPanel = new Panel();
        productPanel = new FlowLayoutPanel();
        searchPanel = new Panel();
        searchBox = new TextBox();
        headerPanel = new Panel();
        nameInput = new TextBox();
        phoneInput = new TextBox();
        cartGrid = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        footerPanel = new Panel();
        transferButton = new Button();
        cashButton = new Button();
        ((System.ComponentModel.ISupportInitialize)layout).BeginInit();
        layout.Panel1.SuspendLayout();
        layout.Panel2.SuspendLayout();
        layout.SuspendLayout();
        leftPanel.SuspendLayout();
        searchPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cartGrid).BeginInit();
        footerPanel.SuspendLayout();
        SuspendLayout();

        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";

        layout.Panel1.Controls.Add(leftPanel);
        layout.Panel2.Controls.Add(cartGrid);
        layout.Panel2.Controls.Add(footerPanel);
        layout.Panel2.Controls.Add(headerPanel);
        layout.Panel1MinSize = 520;
        layout.Panel2MinSize = 520;
        layout.SplitterDistance = 520;
        layout.Size = new Size(911, 692);
        layout.TabIndex = 0;

        leftPanel.Controls.Add(productPanel);
        leftPanel.Controls.Add(searchPanel);
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Location = new Point(0, 0);
        leftPanel.Name = "leftPanel";
        leftPanel.Size = new Size(520, 692);
        leftPanel.TabIndex = 0;

        productPanel.AutoScroll = true;
        productPanel.Dock = DockStyle.Fill;
        productPanel.Location = new Point(0, 80);
        productPanel.Name = "productPanel";
        productPanel.Padding = new Padding(10);
        productPanel.Size = new Size(520, 612);
        productPanel.TabIndex = 0;

        searchPanel.Controls.Add(searchBox);
        searchPanel.Dock = DockStyle.Top;
        searchPanel.Location = new Point(0, 0);
        searchPanel.Name = "searchPanel";
        searchPanel.Padding = new Padding(10);
        searchPanel.Size = new Size(520, 80);
        searchPanel.TabIndex = 1;

        searchBox.Dock = DockStyle.Fill;
        searchBox.Font = new Font("Segoe UI", 16F);
        searchBox.Location = new Point(10, 10);
        searchBox.Name = "searchBox";
        searchBox.PlaceholderText = "Tìm kiếm sản phẩm";
        searchBox.Size = new Size(500, 43);
        searchBox.TabIndex = 0;
        searchBox.TextChanged += SearchBox_TextChanged;

        headerPanel.Controls.Add(nameInput);
        headerPanel.Controls.Add(phoneInput);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(10);
        headerPanel.Size = new Size(387, 160);
        headerPanel.TabIndex = 2;
        // 
        // nameInput
        // 
        nameInput.Dock = DockStyle.Top;
        nameInput.Font = new Font("Segoe UI", 16F);
        nameInput.Location = new Point(10, 54);
        nameInput.Name = "nameInput";
        nameInput.PlaceholderText = "Tên khách hàng";
        nameInput.Size = new Size(367, 43);
        nameInput.TabIndex = 0;
        // 
        // phoneInput
        // 
        phoneInput.Dock = DockStyle.Top;
        phoneInput.Font = new Font("Segoe UI", 16F);
        phoneInput.Location = new Point(10, 10);
        phoneInput.Name = "phoneInput";
        phoneInput.PlaceholderText = "Số điện thoại";
        phoneInput.Size = new Size(367, 43);
        phoneInput.TabIndex = 1;
        // 
        // cartGrid
        // 
        cartGrid.AllowUserToAddRows = true;
        cartGrid.AllowUserToDeleteRows = true;
        cartGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        cartGrid.ColumnHeadersHeight = 60;
        cartGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
        cartGrid.Dock = DockStyle.Fill;
        cartGrid.Font = new Font("Segoe UI", 20F);
        cartGrid.Location = new Point(0, 160);
        cartGrid.Name = "cartGrid";
        cartGrid.RowHeadersWidth = 51;
        cartGrid.RowTemplate.Height = 72;
        cartGrid.Size = new Size(387, 372);
        cartGrid.TabIndex = 0;
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
        // footerPanel
        // 
        footerPanel.Controls.Add(transferButton);
        footerPanel.Controls.Add(cashButton);
        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Location = new Point(0, 532);
        footerPanel.Name = "footerPanel";
        footerPanel.Padding = new Padding(10);
        footerPanel.Size = new Size(387, 160);
        footerPanel.TabIndex = 1;
        // 
        // transferButton
        // 
        transferButton.Dock = DockStyle.Right;
        transferButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        transferButton.Location = new Point(127, 10);
        transferButton.Name = "transferButton";
        transferButton.Size = new Size(140, 140);
        transferButton.TabIndex = 0;
        transferButton.Text = "Chuyển khoản";
        transferButton.Click += transferButton_Click;
        // 
        // cashButton
        // 
        cashButton.Dock = DockStyle.Right;
        cashButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        cashButton.Location = new Point(267, 10);
        cashButton.Name = "cashButton";
        cashButton.Size = new Size(110, 140);
        cashButton.TabIndex = 1;
        cashButton.Text = "Tiền mặt";
        cashButton.Click += cashButton_Click;
        // 
        // TransactionView
        // 
        Controls.Add(layout);
        Name = "TransactionView";
        Size = new Size(911, 692);
        layout.Panel1.ResumeLayout(false);
        layout.Panel2.ResumeLayout(false);
        layout.Panel2.PerformLayout();
        layout.Panel1.ResumeLayout(false);
        layout.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)layout).EndInit();
        layout.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        searchPanel.ResumeLayout(false);
        searchPanel.PerformLayout();
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
