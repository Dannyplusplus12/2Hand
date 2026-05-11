namespace _2Hand.Views;

partial class CustomerView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer layout;
    private ListView customerList;
    private FlowLayoutPanel historyPanel;
    private Panel customerHeaderPanel;
    private Button addCustomerButton;

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
        layout = new SplitContainer();
        customerList = new ListView();
        historyPanel = new FlowLayoutPanel();
        customerHeaderPanel = new Panel();
        addCustomerButton = new Button();
        ((System.ComponentModel.ISupportInitialize)layout).BeginInit();
        layout.Panel1.SuspendLayout();
        layout.Panel2.SuspendLayout();
        layout.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        // 
        // layout.Panel1
        // 
        layout.Panel1.Controls.Add(customerList);
        layout.Panel1.Controls.Add(customerHeaderPanel);
        layout.Panel1MinSize = 420;
        // 
        // layout.Panel2
        // 
        layout.Panel2.Controls.Add(historyPanel);
        layout.Panel2MinSize = 600;
        layout.Size = new Size(911, 692);
        layout.SplitterDistance = 121;
        layout.TabIndex = 0;
        layout.SizeChanged += Layout_SizeChanged;
        // 
        // customerList
        // 
        customerList.Dock = DockStyle.Fill;
        customerList.Font = new Font("Segoe UI", 14F);
        customerList.FullRowSelect = true;
        customerList.Location = new Point(0, 60);
        customerList.Name = "customerList";
        customerList.Size = new Size(420, 632);
        customerList.TabIndex = 0;
        customerList.UseCompatibleStateImageBehavior = false;
        customerList.View = View.Details;
        customerList.Columns.Add("Tên", 220);
        customerList.Columns.Add("SĐT", 160);
        customerList.SelectedIndexChanged += CustomerList_SelectedIndexChanged;
        customerList.DoubleClick += CustomerList_DoubleClick;

        customerHeaderPanel.Dock = DockStyle.Top;
        customerHeaderPanel.Location = new Point(0, 0);
        customerHeaderPanel.Name = "customerHeaderPanel";
        customerHeaderPanel.Padding = new Padding(8);
        customerHeaderPanel.Size = new Size(420, 60);
        customerHeaderPanel.TabIndex = 2;

        addCustomerButton.Dock = DockStyle.Right;
        addCustomerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        addCustomerButton.Location = new Point(312, 8);
        addCustomerButton.Name = "addCustomerButton";
        addCustomerButton.Size = new Size(100, 44);
        addCustomerButton.TabIndex = 0;
        addCustomerButton.Text = "Thêm";
        addCustomerButton.UseVisualStyleBackColor = true;
        addCustomerButton.Click += AddCustomerButton_Click;

        customerHeaderPanel.Controls.Add(addCustomerButton);
        // 
        // historyPanel
        // 
        historyPanel.AutoScroll = true;
        historyPanel.Dock = DockStyle.Fill;
        historyPanel.Location = new Point(0, 0);
        historyPanel.Name = "historyPanel";
        historyPanel.Padding = new Padding(10);
        historyPanel.Size = new Size(25, 100);
        historyPanel.TabIndex = 0;
        // 
        // CustomerView
        // 
        Controls.Add(layout);
        Name = "CustomerView";
        Size = new Size(911, 692);
        layout.Panel1.ResumeLayout(false);
        customerHeaderPanel.ResumeLayout(false);
        layout.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)layout).EndInit();
        layout.ResumeLayout(false);
        ResumeLayout(false);
    }
}
