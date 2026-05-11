namespace _2Hand.Views;

public class InventoryView : UserControl, IThemeable
{
    private readonly SplitContainer layout;
    private readonly FlowLayoutPanel cardsPanel;
    private readonly TextBox searchBox;
    private readonly Button sampleButton;
    private readonly Panel headerPanel;
    private readonly Panel formPanel;
    private readonly TextBox nameInput;
    private readonly TextBox priceInput;
    private readonly TextBox quantityInput;
    private readonly TextBox imageInput;
    private readonly Button addButton;

    public InventoryView()
    {
        Dock = DockStyle.Fill;

        layout = new SplitContainer
        {
            Dock = DockStyle.Fill,
            SplitterDistance = 980,
            Panel1MinSize = 800,
            Panel2MinSize = 380
        };
        layout.SizeChanged += (_, _) => layout.SplitterDistance = (int)(layout.Width * 0.7);

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

        cardsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10)
        };
        searchBox.TextChanged += (_, _) => FilterCards();

        var leftPanel = new Panel
        {
            Dock = DockStyle.Fill
        };
        leftPanel.Controls.Add(cardsPanel);
        leftPanel.Controls.Add(headerPanel);

        formPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };

        var formTitle = new Label
        {
            Text = "Thêm sản phẩm",
            Dock = DockStyle.Top,
            Height = 60,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold)
        };

        nameInput = CreateFormInput("Tên sản phẩm");
        priceInput = CreateFormInput("Giá");
        quantityInput = CreateFormInput("Số lượng");
        imageInput = CreateFormInput("Đường dẫn ảnh");

        addButton = new Button
        {
            Text = "Thêm",
            Dock = DockStyle.Top,
            Height = 60,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold)
        };
        addButton.Click += async (_, _) => await AddProductAsync();

        formPanel.Controls.Add(addButton);
        formPanel.Controls.Add(imageInput);
        formPanel.Controls.Add(quantityInput);
        formPanel.Controls.Add(priceInput);
        formPanel.Controls.Add(nameInput);
        formPanel.Controls.Add(formTitle);

        layout.Panel1.Controls.Add(leftPanel);
        layout.Panel2.Controls.Add(formPanel);

        Controls.Add(layout);
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
            Width = 300,
            Height = 360,
            Margin = new Padding(10),
            Padding = new Padding(10)
        };
        card.Tag = product.Name;

        var image = new PictureBox
        {
            Width = 260,
            Height = 240,
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
