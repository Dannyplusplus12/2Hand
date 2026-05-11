namespace _2Hand.Views;

public class InventoryView : UserControl, IThemeable
{
    private readonly FlowLayoutPanel cardsPanel;
    private readonly TextBox searchBox;
    private readonly Button addButton;
    private readonly Button sampleButton;
    private readonly Panel headerPanel;

    public InventoryView()
    {
        Dock = DockStyle.Fill;

        headerPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 120,
            Padding = new Padding(10)
        };

        searchBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 18F, FontStyle.Regular),
            PlaceholderText = "Tìm kiếm sản phẩm"
        };

        addButton = new Button
        {
            Text = "Thêm",
            Dock = DockStyle.Right,
            Width = 180,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold)
        };

        sampleButton = new Button
        {
            Text = "Sample",
            Dock = DockStyle.Right,
            Width = 180,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold)
        };
        sampleButton.Click += (_, _) => ShowSample();

        headerPanel.Controls.Add(searchBox);
        headerPanel.Controls.Add(sampleButton);
        headerPanel.Controls.Add(addButton);

        cardsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10)
        };

        Controls.Add(cardsPanel);
        Controls.Add(headerPanel);
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var panelBackground = darkMode ? Color.FromArgb(40, 40, 48) : Color.FromArgb(245, 245, 245);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

        BackColor = background;
        headerPanel.BackColor = background;
        cardsPanel.BackColor = background;

        searchBox.BackColor = panelBackground;
        searchBox.ForeColor = foreground;
        addButton.BackColor = Color.FromArgb(52, 152, 219);
        addButton.ForeColor = Color.White;
        sampleButton.BackColor = Color.FromArgb(149, 165, 166);
        sampleButton.ForeColor = Color.White;
    }

    private void ShowSample()
    {
        cardsPanel.Controls.Clear();
        var products = Services.SampleDataGenerator.GenerateProducts(8);
        foreach (var product in products)
        {
            cardsPanel.Controls.Add(CreateProductCard(product));
        }
    }

    private Control CreateProductCard(Models.Product product)
    {
        var card = new Panel
        {
            Width = 280,
            Height = 340,
            Margin = new Padding(10),
            Padding = new Padding(10)
        };

        var image = new PictureBox
        {
            Width = 240,
            Height = 220,
            Dock = DockStyle.Top,
            SizeMode = PictureBoxSizeMode.Zoom,
            Image = Image.FromFile(Path.Combine(AppContext.BaseDirectory, "Assets", "item_placeholder.jpg"))
        };

        var nameLabel = new Label
        {
            Text = product.Name,
            Dock = DockStyle.Top,
            Height = 50,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold)
        };

        var priceLabel = new Label
        {
            Text = $"{product.Price:n0} đ",
            Dock = DockStyle.Top,
            Height = 40,
            Font = new Font("Segoe UI", 14F, FontStyle.Regular)
        };

        card.Controls.Add(priceLabel);
        card.Controls.Add(nameLabel);
        card.Controls.Add(image);
        return card;
    }
}
