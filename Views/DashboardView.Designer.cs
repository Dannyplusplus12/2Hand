namespace _2Hand.Views;

partial class DashboardView
{
    private System.ComponentModel.IContainer components = null;
    private FlowLayoutPanel cardsPanel;
    private Panel recentPanel;
    private ListView recentTransactions;
    private Panel revenueCard;
    private Panel stockCard;
    private Panel lowStockCard;
    private Label revenueLabel;
    private Label stockLabel;
    private Label lowStockLabel;
    private Label revenueTitle;
    private Label stockTitle;
    private Label lowStockTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cardsPanel = new FlowLayoutPanel();
        recentPanel = new Panel();
        recentTransactions = new ListView();
        revenueCard = new Panel();
        stockCard = new Panel();
        lowStockCard = new Panel();
        revenueLabel = new Label();
        stockLabel = new Label();
        lowStockLabel = new Label();
        revenueTitle = new Label();
        stockTitle = new Label();
        lowStockTitle = new Label();
        SuspendLayout();

        Dock = DockStyle.Fill;

        cardsPanel.Dock = DockStyle.Top;
        cardsPanel.Height = 320;
        cardsPanel.AutoScroll = false;
        cardsPanel.FlowDirection = FlowDirection.LeftToRight;
        cardsPanel.WrapContents = false;
        cardsPanel.Padding = new Padding(10);

        revenueCard.Width = 560;
        revenueCard.Height = 280;
        revenueCard.Margin = new Padding(10);
        revenueCard.Padding = new Padding(20);

        revenueTitle.Text = "Doanh thu tháng này";
        revenueTitle.Dock = DockStyle.Top;
        revenueTitle.Height = 70;
        revenueTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        revenueLabel.Text = "0 đ";
        revenueLabel.Dock = DockStyle.Fill;
        revenueLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
        revenueLabel.TextAlign = ContentAlignment.MiddleLeft;

        revenueCard.Controls.Add(revenueLabel);
        revenueCard.Controls.Add(revenueTitle);

        stockCard.Width = 560;
        stockCard.Height = 280;
        stockCard.Margin = new Padding(10);
        stockCard.Padding = new Padding(20);

        stockTitle.Text = "Tổng tồn kho";
        stockTitle.Dock = DockStyle.Top;
        stockTitle.Height = 70;
        stockTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        stockLabel.Text = "0";
        stockLabel.Dock = DockStyle.Fill;
        stockLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
        stockLabel.TextAlign = ContentAlignment.MiddleLeft;

        stockCard.Controls.Add(stockLabel);
        stockCard.Controls.Add(stockTitle);

        lowStockCard.Width = 560;
        lowStockCard.Height = 280;
        lowStockCard.Margin = new Padding(10);
        lowStockCard.Padding = new Padding(20);

        lowStockTitle.Text = "Cảnh báo hết hàng";
        lowStockTitle.Dock = DockStyle.Top;
        lowStockTitle.Height = 70;
        lowStockTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

        lowStockLabel.Text = "0";
        lowStockLabel.Dock = DockStyle.Fill;
        lowStockLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
        lowStockLabel.TextAlign = ContentAlignment.MiddleLeft;

        lowStockCard.Controls.Add(lowStockLabel);
        lowStockCard.Controls.Add(lowStockTitle);

        cardsPanel.Controls.Add(revenueCard);
        cardsPanel.Controls.Add(stockCard);
        cardsPanel.Controls.Add(lowStockCard);

        recentPanel.Dock = DockStyle.Fill;
        recentPanel.Padding = new Padding(10);

        recentTransactions.Dock = DockStyle.Fill;
        recentTransactions.View = View.Details;
        recentTransactions.FullRowSelect = true;
        recentTransactions.Font = new Font("Segoe UI", 20F, FontStyle.Regular);
        recentTransactions.Columns.Add("Khách hàng", 260);
        recentTransactions.Columns.Add("SĐT", 200);
        recentTransactions.Columns.Add("Tổng tiền", 200);
        recentTransactions.Columns.Add("Ngày", 240);

        recentPanel.Controls.Add(recentTransactions);

        Controls.Add(recentPanel);
        Controls.Add(cardsPanel);

        ResumeLayout(false);
    }
}
