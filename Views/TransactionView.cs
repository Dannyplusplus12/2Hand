namespace _2Hand.Views;

public partial class TransactionView : UserControl, IThemeable
{
    private List<Models.Product> products = new();
    private Models.Customer? selectedCustomer;
    private List<Models.Product> filteredProducts = new();

    public TransactionView()
    {
        InitializeComponent();
        Load += async (_, _) => await LoadProductsAsync();
        phoneInput.TextChanged += PhoneInput_TextChanged;
        cartGrid.CellEndEdit += CartGrid_CellEndEdit;
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = Color.White;
        var panelBackground = Color.FromArgb(245, 245, 245);
        var foreground = Color.FromArgb(30, 30, 30);

        BackColor = background;
        headerPanel.BackColor = background;
        footerPanel.BackColor = background;
        cartGrid.BackgroundColor = background;
        cartGrid.ForeColor = foreground;

        phoneInput.BackColor = panelBackground;
        phoneInput.ForeColor = foreground;
        nameInput.BackColor = panelBackground;
        nameInput.ForeColor = foreground;

        cashButton.BackColor = Color.FromArgb(52, 152, 219);
        cashButton.ForeColor = Color.White;
        transferButton.BackColor = Color.FromArgb(39, 174, 96);
        transferButton.ForeColor = Color.White;

        searchPanel.BackColor = background;
        productPanel.BackColor = background;
        searchBox.BackColor = panelBackground;
        searchBox.ForeColor = foreground;
    }

    private async void transferButton_Click(object sender, EventArgs e)
    {
        await CheckoutAsync("transfer");
    }

    private async void cashButton_Click(object sender, EventArgs e)
    {
        await CheckoutAsync("cash");
    }


    private async Task LoadProductsAsync()
    {
        using var context = Data.DbContextFactory.Create();
        var service = new Services.ProductService(context);
        products = await service.GetAllAsync();
        filteredProducts = products.ToList();
        RenderProductCards();
    }

    private void RenderProductCards()
    {
        productPanel.Controls.Clear();
        foreach (var product in filteredProducts)
        {
            productPanel.Controls.Add(CreateProductCard(product));
        }
    }

    private void SearchBox_TextChanged(object? sender, EventArgs e)
    {
        var query = searchBox.Text.Trim();
        filteredProducts = string.IsNullOrWhiteSpace(query)
            ? products.ToList()
            : products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        RenderProductCards();
    }

    private async void PhoneInput_TextChanged(object? sender, EventArgs e)
    {
        var phone = phoneInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(phone))
        {
            selectedCustomer = null;
            nameInput.Text = string.Empty;
            return;
        }

        using var context = Data.DbContextFactory.Create();
        var service = new Services.CustomerService(context);
        selectedCustomer = await service.FindByPhoneAsync(phone);
        if (selectedCustomer != null)
        {
            nameInput.Text = selectedCustomer.FullName;
        }
    }

    private void CartGrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        if (!int.TryParse(cartGrid.Rows[e.RowIndex].Cells[1].Value?.ToString(), out var quantity))
        {
            cartGrid.Rows[e.RowIndex].Cells[1].Value = 1;
            quantity = 1;
        }

        var productName = cartGrid.Rows[e.RowIndex].Cells[0].Value?.ToString();
        var product = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            return;
        }

        if (quantity > product.Quantity)
        {
            cartGrid.Rows[e.RowIndex].Cells[1].Value = product.Quantity;
            quantity = product.Quantity;
        }

        cartGrid.Rows[e.RowIndex].Cells[2].Value = product.Price;
        cartGrid.Rows[e.RowIndex].Cells[3].Value = product.Price * quantity;
    }

    private async Task CheckoutAsync(string method)
    {
        if (selectedCustomer == null)
        {
            var name = nameInput.Text.Trim();
            var phone = phoneInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                return;
            }

            using var context = Data.DbContextFactory.Create();
            var customerService = new Services.CustomerService(context);
            selectedCustomer = await customerService.AddAsync(new Models.Customer
            {
                FullName = name,
                Phone = phone
            });
        }

        var items = new List<(int productId, int quantity)>();
        foreach (DataGridViewRow row in cartGrid.Rows)
        {
            var productName = row.Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(productName))
            {
                continue;
            }

            var product = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                continue;
            }

            if (!int.TryParse(row.Cells[1].Value?.ToString(), out var quantity) || quantity <= 0)
            {
                quantity = 1;
            }

            items.Add((product.Id, quantity));
        }

        if (items.Count == 0)
        {
            return;
        }

        using (var context = Data.DbContextFactory.Create())
        {
            var service = new Services.TransactionService(context);
            await service.CheckoutAsync(selectedCustomer.Id, items);
        }

        if (method == "transfer")
        {
            using var dialog = new PaymentDialog();
            dialog.ShowDialog(this);
        }

        MessageBox.Show("Voucher system coming soon", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        cartGrid.Rows.Clear();
        await LoadProductsAsync();
    }

    private Control CreateProductCard(Models.Product product)
    {
        var card = new Panel
        {
            Width = 220,
            Height = 260,
            Margin = new Padding(8),
            Padding = new Padding(8)
        };
        card.Tag = product;

        var image = new PictureBox
        {
            Width = 200,
            Height = 160,
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
            Height = 36,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };

        var priceLabel = new Label
        {
            Text = $"{product.Price:n0} đ",
            Dock = DockStyle.Top,
            Height = 28,
            Font = new Font("Segoe UI", 11F, FontStyle.Regular)
        };

        card.Controls.Add(priceLabel);
        card.Controls.Add(nameLabel);
        card.Controls.Add(image);
        card.Click += (_, _) => AddProductToCart(product);
        foreach (Control child in card.Controls)
        {
            child.Click += (_, _) => AddProductToCart(product);
        }
        return card;
    }

    private void AddProductToCart(Models.Product product)
    {
        foreach (DataGridViewRow row in cartGrid.Rows)
        {
            if (row.Cells[0].Value?.ToString() == product.Name)
            {
                var currentQuantity = Convert.ToInt32(row.Cells[1].Value ?? 1);
                var newQuantity = Math.Min(currentQuantity + 1, product.Quantity);
                row.Cells[1].Value = newQuantity;
                row.Cells[2].Value = product.Price;
                row.Cells[3].Value = product.Price * newQuantity;
                return;
            }
        }

        var rowIndex = cartGrid.Rows.Add();
        var newRow = cartGrid.Rows[rowIndex];
        newRow.Cells[0].Value = product.Name;
        newRow.Cells[1].Value = 1;
        newRow.Cells[2].Value = product.Price;
        newRow.Cells[3].Value = product.Price;
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
