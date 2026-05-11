using FontAwesome.Sharp;

namespace _2Hand.Views;

public class MainForm : Form
{
    private readonly Panel sidebar;
    private readonly Panel header;
    private readonly Panel content;
    private readonly Label titleLabel;
    private readonly IconButton dashboardButton;
    private readonly IconButton inventoryButton;
    private readonly IconButton customerButton;
    private readonly IconButton transactionButton;
    private readonly Dictionary<string, UserControl> views = new();
    private bool darkMode = true;

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Text = "2Hand Management";
        Width = 1800;
        Height = 1000;
        MinimumSize = new Size(1600, 900);

        sidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 280,
            Padding = new Padding(10)
        };

        header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 120,
            Padding = new Padding(20)
        };

        content = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };

        titleLabel = new Label
        {
            Text = "Tổng quan",
            Dock = DockStyle.Fill,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 32F, FontStyle.Bold)
        };

        dashboardButton = CreateSidebarButton("Tổng quan", IconChar.ChartPie);
        inventoryButton = CreateSidebarButton("Kho", IconChar.BoxesStacked);
        customerButton = CreateSidebarButton("Khách", IconChar.UserGroup);
        transactionButton = CreateSidebarButton("Giao dịch", IconChar.Receipt);

        dashboardButton.Click += (_, _) => ShowView("dashboard");
        inventoryButton.Click += (_, _) => ShowView("inventory");
        customerButton.Click += (_, _) => ShowView("customer");
        transactionButton.Click += (_, _) => ShowView("transaction");

        sidebar.Controls.Add(transactionButton);
        sidebar.Controls.Add(customerButton);
        sidebar.Controls.Add(inventoryButton);
        sidebar.Controls.Add(dashboardButton);

        header.Controls.Add(titleLabel);

        Controls.Add(content);
        Controls.Add(header);
        Controls.Add(sidebar);

        views["dashboard"] = new DashboardView();
        views["inventory"] = new InventoryView();
        views["customer"] = new CustomerView();
        views["transaction"] = new TransactionView();

        ApplyTheme();
        ShowView("dashboard");
    }

    private IconButton CreateSidebarButton(string text, IconChar icon)
    {
        return new IconButton
        {
            Text = text,
            Dock = DockStyle.Top,
            Height = 90,
            IconChar = icon,
            IconColor = Color.White,
            IconSize = 28,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            TextAlign = ContentAlignment.MiddleLeft,
            ImageAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(20, 0, 0, 0),
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat
        };
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
        _ = darkMode ? Color.FromArgb(52, 152, 219) : Color.FromArgb(41, 128, 185);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

        BackColor = background;
        sidebar.BackColor = panelBackground;
        header.BackColor = panelBackground;
        content.BackColor = background;

        titleLabel.ForeColor = foreground;
        _ = accent;

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
        }
    }
}
