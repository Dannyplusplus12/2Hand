namespace _2Hand.Views;

public class EditProductForm : Form
{
    private readonly TextBox nameInput;
    private readonly TextBox priceInput;
    private readonly TextBox quantityInput;
    private readonly TextBox imageInput;
    private readonly Button saveButton;
    private readonly Button cancelButton;

    public Models.Product Product { get; private set; }

    public EditProductForm(Models.Product product)
    {
        Product = new Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            ImagePath = product.ImagePath
        };

        Text = "Sửa sản phẩm";
        StartPosition = FormStartPosition.CenterParent;
        Width = 520;
        Height = 460;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 6,
            Padding = new Padding(20)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

        nameInput = CreateInput(Product.Name);
        priceInput = CreateInput(Product.Price.ToString("0"));
        quantityInput = CreateInput(Product.Quantity.ToString());
        imageInput = CreateInput(Product.ImagePath ?? string.Empty);

        saveButton = new Button
        {
            Text = "Lưu",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };
        saveButton.Click += (_, _) => Save();

        cancelButton = new Button
        {
            Text = "Hủy",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };
        cancelButton.Click += (_, _) => Close();

        layout.Controls.Add(CreateLabel("Tên"), 0, 0);
        layout.Controls.Add(nameInput, 1, 0);
        layout.Controls.Add(CreateLabel("Giá"), 0, 1);
        layout.Controls.Add(priceInput, 1, 1);
        layout.Controls.Add(CreateLabel("Số lượng"), 0, 2);
        layout.Controls.Add(quantityInput, 1, 2);
        layout.Controls.Add(CreateLabel("Ảnh"), 0, 3);
        layout.Controls.Add(imageInput, 1, 3);
        layout.Controls.Add(saveButton, 0, 4);
        layout.Controls.Add(cancelButton, 1, 4);

        Controls.Add(layout);
    }

    private static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };
    }

    private static TextBox CreateInput(string text)
    {
        return new TextBox
        {
            Text = text,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 12F, FontStyle.Regular)
        };
    }

    private void Save()
    {
        if (!decimal.TryParse(priceInput.Text, out var price))
        {
            return;
        }

        if (!int.TryParse(quantityInput.Text, out var quantity))
        {
            return;
        }

        var name = nameInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        Product = new Models.Product
        {
            Id = Product.Id,
            Name = name,
            Description = Product.Description,
            Price = price,
            Quantity = quantity,
            ImagePath = string.IsNullOrWhiteSpace(imageInput.Text) ? null : imageInput.Text.Trim()
        };

        DialogResult = DialogResult.OK;
        Close();
    }
}
