namespace _2Hand.Views;

public partial class TransactionView : UserControl, IThemeable
{
    public TransactionView()
    {
        InitializeComponent();
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
