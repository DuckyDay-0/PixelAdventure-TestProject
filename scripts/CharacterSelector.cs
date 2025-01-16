using Godot;
using System;

public partial class CharacterSelector : Control
{
    Player player;

	public override void _Ready()
	{
        GetNode<Button>("GoBackButton").Connect("pressed", new Callable(this, nameof(OnGoBackButton)));
        GetNode<Button>("GridContainer/MaskedDude").Connect("pressed", new Callable(this, nameof(OnMaskedDude)));
        GetNode<Button>("GridContainer/PinkMan").Connect("pressed", new Callable(this, nameof(OnPinkMan)));
        GetNode<Button>("GridContainer/VirtualGuy").Connect("pressed", new Callable(this, nameof(OnVirtualGuy)));
        GetNode<Button>("GridContainer/NinjaFrog").Connect("pressed", new Callable(this, nameof(OnNinjaFrog)));
    }


    private void OnGoBackButton()
    {
        GetTree().ChangeSceneToFile("res://scenes/MenuScenes/MainMenu.tscn");
    }

    public void OnMaskedDude()
    {
        Global.Instance.selectedCharacter = "maskedDude";
        GoBackToMainMenu();        
    }

    public void OnPinkMan()
    {
        Global.Instance.selectedCharacter = "pinkMan";
        GoBackToMainMenu();
    }

    public void OnVirtualGuy() 
    {
        Global.Instance.selectedCharacter = "virtualGuy";
        GoBackToMainMenu();
    }

    public void OnNinjaFrog() 
    {
        Global.Instance.selectedCharacter = "frog";
        GoBackToMainMenu();
    }
    private void GoBackToMainMenu()
    {
        GetTree().ChangeSceneToFile("res://scenes/MenuScenes/MainMenu.tscn");
    }
}
