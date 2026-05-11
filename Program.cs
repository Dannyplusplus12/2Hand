namespace _2Hand
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using var _ = Data.DbContextFactory.Create();
            Application.Run(new Views.MainForm());
        }
    }
}