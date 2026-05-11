namespace _2Hand.Views;

public partial class CustomerView : UserControl, IThemeable
{
    private List<Models.Customer> customers = new();

    public CustomerView()
    {
        InitializeComponent();
        Load += async (_, _) => await LoadCustomersAsync();
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var panelBackground = darkMode ? Color.FromArgb(40, 40, 48) : Color.FromArgb(245, 245, 245);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

        BackColor = background;
        layout.BackColor = background;
        customerList.BackColor = panelBackground;
        customerList.ForeColor = foreground;
        historyPanel.BackColor = background;
    }

    private async Task LoadCustomersAsync()
    {
        using var context = Data.DbContextFactory.Create();
        var service = new Services.CustomerService(context);
        customers = await service.GetAllAsync();
        customerList.Items.Clear();
        foreach (var customer in customers)
        {
            var item = new ListViewItem(customer.FullName)
            {
                Tag = customer
            };
            item.SubItems.Add(customer.Phone);
            customerList.Items.Add(item);
        }
        historyPanel.Controls.Clear();
    }

    private async Task LoadCustomerHistoryAsync(Models.Customer customer)
    {
        using var context = Data.DbContextFactory.Create();
        var service = new Services.TransactionService(context);
        var transactions = await service.GetHistoryAsync(customer.Id);
        historyPanel.Controls.Clear();
        foreach (var transaction in transactions)
        {
            historyPanel.Controls.Add(CreateTransactionCard(transaction));
        }
    }

    private void CustomerList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (customerList.SelectedItems.Count == 0)
        {
            return;
        }

        if (customerList.SelectedItems[0].Tag is Models.Customer customer)
        {
            _ = LoadCustomerHistoryAsync(customer);
        }
    }

    private void Layout_SizeChanged(object? sender, EventArgs e)
    {
        layout.SplitterDistance = (int)(layout.Width * 0.4);
    }


    private Control CreateTransactionCard(Models.Transaction transaction)
    {
        var card = new Panel
        {
            Width = 520,
            Height = 220,
            Margin = new Padding(10),
            Padding = new Padding(16)
        };

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50
        };

        var titleLabel = new Label
        {
            Text = $"Hóa đơn #{transaction.Id} - {transaction.TotalAmount:n0} đ",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold)
        };

        var expandButton = new Button
        {
            Text = "Chi tiết",
            Dock = DockStyle.Right,
            Width = 140,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold)
        };

        var detailGrid = new DataGridView
        {
            Dock = DockStyle.Fill,
            Visible = false,
            AllowUserToAddRows = false,
            RowTemplate = { Height = 60 },
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 18F, FontStyle.Regular)
        };
        detailGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        detailGrid.Columns.Add("Item", "Sản phẩm");
        detailGrid.Columns.Add("Qty", "SL");
        detailGrid.Columns.Add("Price", "Giá");
        for (var i = 0; i < itemCount; i++)
        {
            detailGrid.Rows.Add($"Item {i + 1}", 1, "50.000 đ");
        }

        expandButton.Click += (_, _) => detailGrid.Visible = !detailGrid.Visible;

        header.Controls.Add(expandButton);
        header.Controls.Add(titleLabel);

        card.Controls.Add(detailGrid);
        card.Controls.Add(header);
        return card;
    }
}
