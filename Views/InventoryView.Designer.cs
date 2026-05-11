namespace _2Hand.Views;

partial class InventoryView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer layout;
    private FlowLayoutPanel cardsPanel;
    private TextBox searchBox;
    private Button sampleButton;
    private Panel headerPanel;
    private Panel formPanel;
    private TextBox nameInput;
    private TextBox priceInput;
    private TextBox quantityInput;
    private TextBox imageInput;
    private Button addButton;
    private Label formTitle;
    private Panel leftPanel;

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
        cardsPanel = new FlowLayoutPanel();
        headerPanel = new Panel();
        searchBox = new TextBox();
        sampleButton = new Button();
        formPanel = new Panel();
        addButton = new Button();
        imageInput = new TextBox();
        quantityInput = new TextBox();
        priceInput = new TextBox();
        nameInput = new TextBox();
        formTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)layout).BeginInit();
        layout.Panel1.SuspendLayout();
        layout.Panel2.SuspendLayout();
        layout.SuspendLayout();
        leftPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        formPanel.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        // 
        // layout.Panel1
        // 
        layout.Panel1.Controls.Add(leftPanel);
        layout.Panel1MinSize = 800;
        // 
        // layout.Panel2
        // 
        layout.Panel2.Controls.Add(formPanel);
        layout.Panel2MinSize = 380;
        layout.Size = new Size(1189, 692);
        layout.SplitterDistance = 805;
        layout.TabIndex = 0;
        layout.SizeChanged += Layout_SizeChanged;
        // 
        // leftPanel
        // 
        leftPanel.Controls.Add(cardsPanel);
        leftPanel.Controls.Add(headerPanel);
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Location = new Point(0, 0);
        leftPanel.Name = "leftPanel";
        leftPanel.Size = new Size(805, 692);
        leftPanel.TabIndex = 0;
        // 
        // cardsPanel
        // 
        cardsPanel.AutoScroll = true;
        cardsPanel.Dock = DockStyle.Fill;
        cardsPanel.Location = new Point(0, 120);
        cardsPanel.Name = "cardsPanel";
        cardsPanel.Padding = new Padding(10);
        cardsPanel.Size = new Size(805, 572);
        cardsPanel.TabIndex = 0;
        // 
        // headerPanel
        // 
        headerPanel.Controls.Add(searchBox);
        headerPanel.Controls.Add(sampleButton);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(10);
        headerPanel.Size = new Size(805, 120);
        headerPanel.TabIndex = 1;
        // 
        // searchBox
        // 
        searchBox.Dock = DockStyle.Fill;
        searchBox.Font = new Font("Segoe UI", 18F);
        searchBox.Location = new Point(10, 10);
        searchBox.Name = "searchBox";
        searchBox.PlaceholderText = "Tìm kiếm sản phẩm";
        searchBox.Size = new Size(605, 47);
        searchBox.TabIndex = 0;
        searchBox.TextChanged += SearchBox_TextChanged;
        // 
        // sampleButton
        // 
        sampleButton.Dock = DockStyle.Right;
        sampleButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        sampleButton.Location = new Point(615, 10);
        sampleButton.Name = "sampleButton";
        sampleButton.Size = new Size(180, 100);
        sampleButton.TabIndex = 1;
        sampleButton.Text = "Sample";
        sampleButton.Click += SampleButton_Click;
        // 
        // formPanel
        // 
        formPanel.Controls.Add(addButton);
        formPanel.Controls.Add(imageInput);
        formPanel.Controls.Add(quantityInput);
        formPanel.Controls.Add(priceInput);
        formPanel.Controls.Add(nameInput);
        formPanel.Controls.Add(formTitle);
        formPanel.Dock = DockStyle.Fill;
        formPanel.Location = new Point(0, 0);
        formPanel.Name = "formPanel";
        formPanel.Padding = new Padding(20);
        formPanel.Size = new Size(380, 692);
        formPanel.TabIndex = 0;
        // 
        // addButton
        // 
        addButton.Dock = DockStyle.Top;
        addButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        addButton.Location = new Point(20, 268);
        addButton.Name = "addButton";
        addButton.Size = new Size(340, 60);
        addButton.TabIndex = 0;
        addButton.Text = "Thêm";
        addButton.Click += AddButton_Click;
        // 
        // imageInput
        // 
        imageInput.Dock = DockStyle.Top;
        imageInput.Font = new Font("Segoe UI", 18F);
        imageInput.Location = new Point(20, 221);
        imageInput.Margin = new Padding(0, 0, 0, 10);
        imageInput.Name = "imageInput";
        imageInput.PlaceholderText = "Đường dẫn ảnh";
        imageInput.Size = new Size(340, 47);
        imageInput.TabIndex = 1;
        // 
        // quantityInput
        // 
        quantityInput.Dock = DockStyle.Top;
        quantityInput.Font = new Font("Segoe UI", 18F);
        quantityInput.Location = new Point(20, 174);
        quantityInput.Margin = new Padding(0, 0, 0, 10);
        quantityInput.Name = "quantityInput";
        quantityInput.PlaceholderText = "Số lượng";
        quantityInput.Size = new Size(340, 47);
        quantityInput.TabIndex = 2;
        // 
        // priceInput
        // 
        priceInput.Dock = DockStyle.Top;
        priceInput.Font = new Font("Segoe UI", 18F);
        priceInput.Location = new Point(20, 127);
        priceInput.Margin = new Padding(0, 0, 0, 10);
        priceInput.Name = "priceInput";
        priceInput.PlaceholderText = "Giá";
        priceInput.Size = new Size(340, 47);
        priceInput.TabIndex = 3;
        // 
        // nameInput
        // 
        nameInput.Dock = DockStyle.Top;
        nameInput.Font = new Font("Segoe UI", 18F);
        nameInput.Location = new Point(20, 80);
        nameInput.Margin = new Padding(0, 0, 0, 10);
        nameInput.Name = "nameInput";
        nameInput.PlaceholderText = "Tên sản phẩm";
        nameInput.Size = new Size(340, 47);
        nameInput.TabIndex = 4;
        // 
        // formTitle
        // 
        formTitle.Dock = DockStyle.Top;
        formTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        formTitle.Location = new Point(20, 20);
        formTitle.Name = "formTitle";
        formTitle.Size = new Size(340, 60);
        formTitle.TabIndex = 5;
        formTitle.Text = "Thêm sản phẩm";
        // 
        // InventoryView
        // 
        Controls.Add(layout);
        Name = "InventoryView";
        Size = new Size(1189, 692);
        layout.Panel1.ResumeLayout(false);
        layout.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)layout).EndInit();
        layout.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        formPanel.ResumeLayout(false);
        formPanel.PerformLayout();
        ResumeLayout(false);
    }
}
