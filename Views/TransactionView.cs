namespace _2Hand.Views;

public partial class TransactionView : UserControl, IThemeable
{
    private List<Models.Product> products = new();
    private Models.Customer? selectedCustomer;

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
}
