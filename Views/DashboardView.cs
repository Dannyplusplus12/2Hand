namespace _2Hand.Views;

public class DashboardView : UserControl, IThemeable
{
    private readonly FlowLayoutPanel cardsPanel;
    private readonly Panel recentPanel;
    private readonly Label revenueLabel;
    private readonly Label stockLabel;
    private readonly Label lowStockLabel;
    private readonly ListView recentTransactions;

    public DashboardView()
    {
        Dock = DockStyle.Fill;
        cardsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 320,
            AutoScroll = false,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(10)
        };

        revenueLabel = CreateCard("Doanh thu tháng này", "0 đ");
        stockLabel = CreateCard("Tổng tồn kho", "0");
        lowStockLabel = CreateCard("Cảnh báo hết hàng", "0");

        cardsPanel.Controls.Add(revenueLabel.Parent);
        cardsPanel.Controls.Add(stockLabel.Parent);
        cardsPanel.Controls.Add(lowStockLabel.Parent);

        recentPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10)
        };

        recentTransactions = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Regular)
        };
        recentTransactions.Columns.Add("Khách hàng", 260);
        recentTransactions.Columns.Add("SĐT", 200);
        recentTransactions.Columns.Add("Tổng tiền", 200);
        recentTransactions.Columns.Add("Ngày", 240);

        recentPanel.Controls.Add(recentTransactions);
        Controls.Add(recentPanel);
        Controls.Add(cardsPanel);
    }

    private Label CreateCard(string title, string value)
    {
        var panel = new Panel
        {
            Width = 520,
            Height = 260,
            Margin = new Padding(10),
            Padding = new Padding(20)
        };

        var titleLabel = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 60,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold)
        };

        var valueLabel = new Label
        {
            Text = value,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 28F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft
        };

        panel.Controls.Add(valueLabel);
        panel.Controls.Add(titleLabel);
        return valueLabel;
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var cardBackground = darkMode ? Color.FromArgb(40, 40, 48) : Color.FromArgb(245, 245, 245);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

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
        }
    }
}
