namespace _2Hand.Views;

public partial class CustomerView : UserControl, IThemeable
{
    public CustomerView()
    {
        InitializeComponent();
        for (var index = 0; index < 4; index++)
        {
            historyPanel.Controls.Add(CreateTransactionCard($"Hóa đơn #{index + 1}", index + 1));
        }
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

    private void Layout_SizeChanged(object? sender, EventArgs e)
    {
        layout.SplitterDistance = (int)(layout.Width * 0.4);
    }

    private void InitializeComponent()
    {

    }

    private Control CreateTransactionCard(string title, int itemCount)
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
            Text = title,
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
