namespace _2Hand.Views;

partial class CustomerView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer layout;
    private ListView customerList;
    private FlowLayoutPanel historyPanel;

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
        customerList.Location = new Point(0, 0);
        customerList.Name = "customerList";
        customerList.Size = new Size(121, 100);
        customerList.TabIndex = 0;
        customerList.UseCompatibleStateImageBehavior = false;
        customerList.View = View.Details;
        customerList.Columns.Add("Tên", 220);
        customerList.Columns.Add("SĐT", 160);
        customerList.SelectedIndexChanged += CustomerList_SelectedIndexChanged;
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
        layout.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)layout).EndInit();
        layout.ResumeLayout(false);
        ResumeLayout(false);
    }
}
