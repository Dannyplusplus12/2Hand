namespace _2Hand.Views;

public class PaymentDialog : Form
{
    public PaymentDialog()
    {
        Text = "Chuyển khoản";
        StartPosition = FormStartPosition.CenterParent;
        Width = 520;
        Height = 520;

        var image = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom
        };

        var imagePath = Path.Combine(AppContext.BaseDirectory, "rand", "qr_code_placeholder.jpg");
        if (File.Exists(imagePath))
        {
            image.Image = Image.FromFile(imagePath);
        }

        Controls.Add(image);
    }
}
