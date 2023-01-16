using GoblinMan.Models;
namespace GoblinMan;

[QueryProperty(nameof(CurrGoblinId), "goblin")]
public partial class DetailPage : ContentPage
{
    int currGoblinId;
    public int CurrGoblinId
    {
        get => currGoblinId;
        set
        {
            currGoblinId = value;
            UpdateDetailsUI(currGoblinId);
        }
    }

    public DetailPage()
	{
		
		InitializeComponent();
	}

    private async void UpdateDetailsUI(int id)
    {
        Goblin currGoblin = await App.GoblinRepo.GetGoblinById(id);
        detailLabel.Text = $"Clicked Item {currGoblin.Name}";
    }
}