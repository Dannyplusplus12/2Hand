namespace _2Hand.Views;

public partial class DashboardView : UserControl, IThemeable
{
    public DashboardView()
    {
        InitializeComponent();
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
