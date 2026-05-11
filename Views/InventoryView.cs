namespace _2Hand.Views;

public partial class InventoryView : UserControl, IThemeable
{
    public InventoryView()
    {
        InitializeComponent();
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var panelBackground = darkMode ? Color.FromArgb(40, 40, 48) : Color.FromArgb(245, 245, 245);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

        BackColor = background;
        layout.BackColor = background;
        headerPanel.BackColor = background;
        cardsPanel.BackColor = background;
        formPanel.BackColor = panelBackground;

        searchBox.BackColor = panelBackground;
        searchBox.ForeColor = foreground;
        sampleButton.BackColor = Color.FromArgb(149, 165, 166);
        sampleButton.ForeColor = Color.White;
        addButton.BackColor = Color.FromArgb(52, 152, 219);
        addButton.ForeColor = Color.White;
        foreach (var input in new[] { nameInput, priceInput, quantityInput, imageInput })
        {
            input.BackColor = background;
            input.ForeColor = foreground;
        }
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

    private void SampleButton_Click(object? sender, EventArgs e)
    {
        ShowSample();
    }

    private void SearchBox_TextChanged(object? sender, EventArgs e)
    {
        FilterCards();
    }

    private void Layout_SizeChanged(object? sender, EventArgs e)
    {
        layout.SplitterDistance = (int)(layout.Width * 0.7);
    }

    private void FilterCards()
    {
        var query = searchBox.Text.Trim();
        foreach (Control card in cardsPanel.Controls)
        {
            if (card.Tag is not string name)
            {
                card.Visible = true;
                continue;
            }

    private async void AddButton_Click(object? sender, EventArgs e)
    {
        await AddProductAsync();
    }

            card.Visible = string.IsNullOrWhiteSpace(query) || name.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }

    private async Task AddProductAsync()
    {
        if (!decimal.TryParse(priceInput.Text, out var price))
        {
            return;
        }

        if (!int.TryParse(quantityInput.Text, out var quantity))
        {
            return;
        }

        var product = new Models.Product
        {
            Name = nameInput.Text.Trim(),
            Price = price,
            Quantity = quantity,
            ImagePath = string.IsNullOrWhiteSpace(imageInput.Text) ? null : imageInput.Text.Trim()
        };

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return;
        }

        using var context = Data.DbContextFactory.Create();
        var service = new Services.ProductService(context);
        await service.AddAsync(product);
        cardsPanel.Controls.Add(CreateProductCard(product));
        nameInput.Clear();
        priceInput.Clear();
        quantityInput.Clear();
        imageInput.Clear();
    }

    private Control CreateProductCard(Models.Product product)
    {
        var card = new Panel
        {
            Width = 240,
            Height = 300,
            Margin = new Padding(8),
            Padding = new Padding(8)
        };
        card.Tag = product.Name;

        var image = new PictureBox
        {
            Width = 220,
            Height = 200,
            Dock = DockStyle.Top,
            SizeMode = PictureBoxSizeMode.Zoom
        };
        var imagePath = string.IsNullOrWhiteSpace(product.ImagePath)
            ? Path.Combine(AppContext.BaseDirectory, "rand", "item_placeholder.jpg")
            : product.ImagePath;
        if (File.Exists(imagePath))
        {
            image.Image = CenterCropSquare(Image.FromFile(imagePath), image.Width, image.Height);
        }

        var nameLabel = new Label
        {
            Text = product.Name,
            Dock = DockStyle.Top,
            Height = 40,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold)
        };

        var priceLabel = new Label
        {
            Text = $"{product.Price:n0} đ",
            Dock = DockStyle.Top,
            Height = 32,
            Font = new Font("Segoe UI", 12F, FontStyle.Regular)
        };

        card.Controls.Add(priceLabel);
        card.Controls.Add(nameLabel);
        card.Controls.Add(image);
        return card;
    }

    private TextBox CreateFormInput(string placeholder)
    {
        return new TextBox
        {
            Dock = DockStyle.Top,
            Height = 60,
            Font = new Font("Segoe UI", 18F, FontStyle.Regular),
            PlaceholderText = placeholder,
            Margin = new Padding(0, 0, 0, 10)
        };
    }

    private static Image CenterCropSquare(Image source, int width, int height)
    {
        var size = Math.Min(source.Width, source.Height);
        var cropArea = new Rectangle(
            (source.Width - size) / 2,
            (source.Height - size) / 2,
            size,
            size);

        var target = new Bitmap(width, height);
        using var graphics = Graphics.FromImage(target);
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(source, new Rectangle(0, 0, width, height), cropArea, GraphicsUnit.Pixel);
        return target;
    }
}
