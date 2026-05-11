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
        components = new System.ComponentModel.Container();
        layout = new SplitContainer();
        headerPanel = new Panel();
        searchBox = new TextBox();
        sampleButton = new Button();
        cardsPanel = new FlowLayoutPanel();
        leftPanel = new Panel();
        formPanel = new Panel();
        formTitle = new Label();
        nameInput = new TextBox();
        priceInput = new TextBox();
        quantityInput = new TextBox();
        imageInput = new TextBox();
        addButton = new Button();
        SuspendLayout();

        Dock = DockStyle.Fill;

        layout.Dock = DockStyle.Fill;
        layout.SplitterDistance = 980;
        layout.Panel1MinSize = 800;
        layout.Panel2MinSize = 380;
        layout.SizeChanged += Layout_SizeChanged;

        headerPanel.Dock = DockStyle.Top;
        headerPanel.Height = 120;
        headerPanel.Padding = new Padding(10);

        searchBox.Dock = DockStyle.Fill;
        searchBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        searchBox.PlaceholderText = "Tìm kiếm sản phẩm";
        searchBox.TextChanged += SearchBox_TextChanged;

        sampleButton.Text = "Sample";
        sampleButton.Dock = DockStyle.Right;
        sampleButton.Width = 180;
        sampleButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        sampleButton.Click += SampleButton_Click;

        headerPanel.Controls.Add(searchBox);
        headerPanel.Controls.Add(sampleButton);

        cardsPanel.Dock = DockStyle.Fill;
        cardsPanel.AutoScroll = true;
        cardsPanel.Padding = new Padding(10);

        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Controls.Add(cardsPanel);
        leftPanel.Controls.Add(headerPanel);

        formPanel.Dock = DockStyle.Fill;
        formPanel.Padding = new Padding(20);

        formTitle.Text = "Thêm sản phẩm";
        formTitle.Dock = DockStyle.Top;
        formTitle.Height = 60;
        formTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        nameInput.Dock = DockStyle.Top;
        nameInput.Height = 60;
        nameInput.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        nameInput.PlaceholderText = "Tên sản phẩm";
        nameInput.Margin = new Padding(0, 0, 0, 10);

        priceInput.Dock = DockStyle.Top;
        priceInput.Height = 60;
        priceInput.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        priceInput.PlaceholderText = "Giá";
        priceInput.Margin = new Padding(0, 0, 0, 10);

        quantityInput.Dock = DockStyle.Top;
        quantityInput.Height = 60;
        quantityInput.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        quantityInput.PlaceholderText = "Số lượng";
        quantityInput.Margin = new Padding(0, 0, 0, 10);

        imageInput.Dock = DockStyle.Top;
        imageInput.Height = 60;
        imageInput.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        imageInput.PlaceholderText = "Đường dẫn ảnh";
        imageInput.Margin = new Padding(0, 0, 0, 10);

        addButton.Text = "Thêm";
        addButton.Dock = DockStyle.Top;
        addButton.Height = 60;
        addButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        addButton.Click += AddButton_Click;

        formPanel.Controls.Add(addButton);
        formPanel.Controls.Add(imageInput);
        formPanel.Controls.Add(quantityInput);
        formPanel.Controls.Add(priceInput);
        formPanel.Controls.Add(nameInput);
        formPanel.Controls.Add(formTitle);

        layout.Panel1.Controls.Add(leftPanel);
        layout.Panel2.Controls.Add(formPanel);

        Controls.Add(layout);

        ResumeLayout(false);
    }
}
