namespace _2Hand.Views;

public class CustomerView : UserControl, IThemeable
{
    private readonly SplitContainer layout;
    private readonly ListView customerList;
    private readonly FlowLayoutPanel historyPanel;

    public CustomerView()
    {
        Dock = DockStyle.Fill;

        layout = new SplitContainer
        {
            Dock = DockStyle.Fill,
            SplitterDistance = 520
        };

        customerList = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Regular)
        };
        customerList.Columns.Add("Tên", 220);
        customerList.Columns.Add("SĐT", 160);

        historyPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10)
        };

        layout.Panel1.Controls.Add(customerList);
        layout.Panel2.Controls.Add(historyPanel);
        Controls.Add(layout);
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
}
