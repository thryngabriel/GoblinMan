namespace GoblinMan;

public partial class App : Application
{
    public static GoblinRepository GoblinRepo { get; private set; }
	public App(GoblinRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		GoblinRepo = repo;
	}
}
