using Godot;
using System;

public partial class MainMenu : Control
{
	
	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/StartButton").Connect("pressed", new Callable (this, nameof(OnButtonStart)));
		GetNode<Button>("VBoxContainer/LevelsButton").Connect("pressed", new Callable(this, nameof(OnLevelSelectorButton)));
		GetNode<Button>("VBoxContainer/CharacterSelector").Connect("pressed", new Callable(this, nameof(OnCharacterSelector)));
		GetNode<Button>("VBoxContainer/ExitButton").Connect("pressed", new Callable(this, nameof(OnExitButton)));

    }

	public void OnCharacterSelector()
	{
		GetTree().ChangeSceneToFile("res://scenes/MenuScenes/CharacterSelector.tscn");
	}


    private void OnExitButton()
	{
		GetTree().Quit();
    }


	private void OnLevelSelectorButton()
	{
		GetTree().ChangeSceneToFile("res://scenes/MenuScenes/level_selector.tscn");
	}
    private void OnButtonStart()
	{
		GetTree().ChangeSceneToFile("res://start.tscn");
    }

}
