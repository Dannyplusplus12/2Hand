namespace _2Hand.Views;

public class TransactionView : UserControl, IThemeable
{
    private readonly Panel headerPanel;
    private readonly TextBox phoneInput;
    private readonly TextBox nameInput;
    private readonly DataGridView cartGrid;
    private readonly Panel footerPanel;
    private readonly Button cashButton;
    private readonly Button transferButton;

    public TransactionView()
    {
        Dock = DockStyle.Fill;

        headerPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 200,
            Padding = new Padding(10)
        };

        phoneInput = new TextBox
        {
            Dock = DockStyle.Top,
            Height = 70,
            Font = new Font("Segoe UI", 20F, FontStyle.Regular),
            PlaceholderText = "Số điện thoại"
        };

        nameInput = new TextBox
        {
            Dock = DockStyle.Top,
            Height = 70,
            Font = new Font("Segoe UI", 20F, FontStyle.Regular),
            PlaceholderText = "Tên khách hàng"
        };

        headerPanel.Controls.Add(nameInput);
        headerPanel.Controls.Add(phoneInput);

        cartGrid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AllowUserToAddRows = false,
            RowTemplate = { Height = 72 },
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 20F, FontStyle.Regular)
        };
        cartGrid.Columns.Add("Product", "Sản phẩm");
        cartGrid.Columns.Add("Quantity", "Số lượng");
        cartGrid.Columns.Add("Price", "Đơn giá");
        cartGrid.Columns.Add("Total", "Thành tiền");

        footerPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 160,
            Padding = new Padding(10)
        };

        cashButton = new Button
        {
            Text = "Tiền mặt",
            Dock = DockStyle.Right,
            Width = 240,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold)
        };

        transferButton = new Button
        {
            Text = "Chuyển khoản",
            Dock = DockStyle.Right,
            Width = 260,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold)
        };

        footerPanel.Controls.Add(transferButton);
        footerPanel.Controls.Add(cashButton);

        Controls.Add(cartGrid);
        Controls.Add(footerPanel);
        Controls.Add(headerPanel);
    }

    public void ApplyTheme(bool darkMode)
    {
        var background = darkMode ? Color.FromArgb(24, 24, 28) : Color.White;
        var panelBackground = darkMode ? Color.FromArgb(40, 40, 48) : Color.FromArgb(245, 245, 245);
        var foreground = darkMode ? Color.White : Color.FromArgb(30, 30, 30);

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
}
