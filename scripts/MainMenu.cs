using Godot;
using System;

public partial class MainMenu : Control
{
	
	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/StartButton").Connect("pressed", new Callable (this, nameof(OnButtonStart)));
        GetNode<Button>("VBoxContainer/ExitButton").Connect("pressed", new Callable(this, nameof(OnExitButton)));

    }

	private void OnExitButton()
	{
		GetTree().Quit();
    }

    private void OnButtonStart()
	{
        var newLevel = ResourceLoader.Load<PackedScene>("res://start.tscn").Instantiate();
		Node currentScene = GetTree().Root.GetChild(0);
		GetTree().Root.CallDeferred("add_child", newLevel);

		currentScene.CallDeferred("queue_free");
    }
}
