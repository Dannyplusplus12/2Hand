namespace _2Hand.Views;

public partial class DashboardView : UserControl, IThemeable
{
    public DashboardView()
    {
        InitializeComponent();
        Load += async (_, _) => await LoadMetricsAsync();
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = Color.White;
        var cardBackground = Color.FromArgb(245, 245, 245);
        var foreground = Color.FromArgb(30, 30, 30);

        BackColor = background;
        cardsPanel.BackColor = background;
        recentPanel.BackColor = background;
        recentTransactions.BackColor = cardBackground;
        recentTransactions.ForeColor = foreground;

        foreach (Control card in cardsPanel.Controls)
        {
            card.BackColor = cardBackground;
            foreach (Control label in card.Controls)
            {
                label.ForeColor = foreground;
                label.BackColor = cardBackground;
            }

    private async Task LoadMetricsAsync()
    {
        using var context = Data.DbContextFactory.Create();
        var service = new Services.TransactionService(context);
        var summary = await service.GetDashboardSummaryAsync();
        revenueLabel.Text = $"{summary.MonthRevenue:n0} đ";
        stockLabel.Text = summary.TotalStock.ToString();
        lowStockLabel.Text = summary.LowStockCount.ToString();

        recentTransactions.Items.Clear();
        foreach (var transaction in summary.RecentTransactions)
        {
            var item = new ListViewItem(transaction.CustomerName);
            item.SubItems.Add(transaction.CustomerPhone);
            item.SubItems.Add($"{transaction.TotalAmount:n0} đ");
            item.SubItems.Add(transaction.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
            item.Tag = transaction.CustomerId;
            recentTransactions.Items.Add(item);
        }

        recentTransactions.DoubleClick += (_, _) => OpenCustomerFromRecent();
    }

    private void OpenCustomerFromRecent()
    {
        if (recentTransactions.SelectedItems.Count == 0)
        {
            return;
        }

        var selected = recentTransactions.SelectedItems[0];
        if (FindForm() is MainForm mainForm && selected.Tag is int customerId)
        {
            mainForm.NavigateToCustomer(customerId);
        }
    }
        }
    }

}
