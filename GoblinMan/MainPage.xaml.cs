using GoblinMan.Models;

namespace GoblinMan;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        PopulateList();
    }

    private async void PopulateList()
    {
        List<Goblin> people = await App.GoblinRepo.GetGoblins();
        for (int i = 0; i < people.Count; i++)
        {
            stack.Children.Add(ViewItemBuilder(people[i]));
        }
    }

	private Button ViewItemBuilder (Goblin goblin)
	{
		Button item = new();
        string type = goblin.IsCreature ? "Creature" : "Hazard";
        item.Text = $"{goblin.Name} ({type} {goblin.Level})";
		Label nameLabel = new(){ Text = goblin.Name, FontAttributes = FontAttributes.Bold};


        item.Clicked +=
            async (sender, e) =>
            {
                await Shell.Current.GoToAsync($"goblindetails?goblin={goblin.Id}");
            };
        
		return item;
	}

}

