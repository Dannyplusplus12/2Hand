namespace _2Hand.Views;

public class EditCustomerForm : Form
{
    private readonly TextBox nameInput;
    private readonly TextBox phoneInput;
    private readonly TextBox addressInput;
    private readonly Button saveButton;
    private readonly Button cancelButton;

    public Models.Customer Customer { get; private set; }

    public EditCustomerForm(Models.Customer customer)
    {
        Customer = new Models.Customer
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        };

        Text = customer.Id == 0 ? "Thêm khách" : "Sửa khách";
        StartPosition = FormStartPosition.CenterParent;
        Width = 520;
        Height = 420;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 5,
            Padding = new Padding(20)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

        nameInput = CreateInput(Customer.FullName);
        phoneInput = CreateInput(Customer.Phone);
        addressInput = CreateInput(Customer.Address ?? string.Empty);

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
        layout.Controls.Add(CreateLabel("SĐT"), 0, 1);
        layout.Controls.Add(phoneInput, 1, 1);
        layout.Controls.Add(CreateLabel("Địa chỉ"), 0, 2);
        layout.Controls.Add(addressInput, 1, 2);
        layout.Controls.Add(saveButton, 0, 3);
        layout.Controls.Add(cancelButton, 1, 3);

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
        var name = nameInput.Text.Trim();
        var phone = phoneInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
        {
            return;
        }

        Customer = new Models.Customer
        {
            Id = Customer.Id,
            FullName = name,
            Phone = phone,
            Address = string.IsNullOrWhiteSpace(addressInput.Text) ? null : addressInput.Text.Trim()
        };

        DialogResult = DialogResult.OK;
        Close();
    }
}
