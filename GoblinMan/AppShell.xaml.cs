namespace GoblinMan;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("goblindetails", typeof(DetailPage));
    }
}
