using FontAwesome.Sharp;

namespace _2Hand.Views;

public partial class MainForm : Form
{
    private readonly Dictionary<string, UserControl> views = new();
    private bool darkMode = true;

    public MainForm()
    {
        InitializeComponent();
        views["dashboard"] = new DashboardView();
        views["inventory"] = new InventoryView();
        views["customer"] = new CustomerView();
        views["transaction"] = new TransactionView();

        ApplyTheme();
        ShowView("dashboard");
    }

    private void ShowView(string key)
    {
        if (!views.TryGetValue(key, out var view))
        {
            return;
        }

        foreach (Control existing in content.Controls)
        {
            existing.Visible = false;
        }

        if (!content.Controls.Contains(view))
        {
            view.Dock = DockStyle.Fill;
            content.Controls.Add(view);
        }

        view.Visible = true;
        titleLabel.Text = key switch
        {
            "dashboard" => "Tổng quan",
            "inventory" => "Kho hàng",
            "customer" => "Khách hàng",
            "transaction" => "Giao dịch",
            _ => titleLabel.Text
        };
    }

    private void ApplyTheme()
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var panelBackground = darkMode ? Color.FromArgb(32, 32, 36) : Color.FromArgb(240, 240, 240);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

        BackColor = background;
        sidebar.BackColor = panelBackground;
        header.BackColor = panelBackground;
        content.BackColor = background;

        titleLabel.ForeColor = foreground;
        foreach (var button in new[] { dashboardButton, inventoryButton, customerButton, transactionButton })
        {
            button.BackColor = panelBackground;
            button.ForeColor = foreground;
            button.FlatAppearance.BorderSize = 0;
        }

        foreach (var view in views.Values)
        {
            if (view is IThemeable themeable)
            {
                themeable.ApplyTheme(darkMode);
            }

    private void DashboardButton_Click(object? sender, EventArgs e) => ShowView("dashboard");

    private void InventoryButton_Click(object? sender, EventArgs e) => ShowView("inventory");

    private void CustomerButton_Click(object? sender, EventArgs e) => ShowView("customer");

    private void TransactionButton_Click(object? sender, EventArgs e) => ShowView("transaction");
        }
    }
}
