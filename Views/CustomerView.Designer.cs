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
        components = new System.ComponentModel.Container();
        layout = new SplitContainer();
        customerList = new ListView();
        historyPanel = new FlowLayoutPanel();
        SuspendLayout();

        Dock = DockStyle.Fill;

        layout.Dock = DockStyle.Fill;
        layout.SplitterDistance = 520;
        layout.Panel1MinSize = 420;
        layout.Panel2MinSize = 600;
        layout.SizeChanged += Layout_SizeChanged;

        customerList.Dock = DockStyle.Fill;
        customerList.View = View.Details;
        customerList.FullRowSelect = true;
        customerList.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
        customerList.Columns.Add("Tên", 220);
        customerList.Columns.Add("SĐT", 160);

        historyPanel.Dock = DockStyle.Fill;
        historyPanel.AutoScroll = true;
        historyPanel.Padding = new Padding(10);

        layout.Panel1.Controls.Add(customerList);
        layout.Panel2.Controls.Add(historyPanel);

        Controls.Add(layout);

        ResumeLayout(false);
    }
}
