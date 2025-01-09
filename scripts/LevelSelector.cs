using Godot;
using System;

public partial class LevelSelector : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        GetNode<Button>("GoBackButton").Connect("pressed", new Callable(this, nameof(OnGoBackButton)));

        GetNode<Button>("GridContainer/startLevel").Connect("pressed", new Callable(this, nameof(OnStartLevelButton)));
        GetNode<Button>("GridContainer/level_1").Connect("pressed", new Callable(this, nameof(OnLevel_1Button)));
        GetNode<Button>("GridContainer/level_2").Connect("pressed", new Callable(this, nameof(OnLevel_2Button)));
        GetNode<Button>("GridContainer/level_3").Connect("pressed", new Callable(this, nameof(OnLevel_3Button)));
        GetNode<Button>("GridContainer/level_4").Connect("pressed", new Callable(this, nameof(OnLevel_4Button)));

    }

    private void ChangeScene(string scenePath)
    {
        

        Node currentScene = GetTree().CurrentScene;

        if (currentScene != null)
        {
            currentScene.CallDeferred("queue_free");
        }
        
        var newScene = GetTree().ChangeSceneToFile(scenePath);
        //var newScene = ResourceLoader.Load<PackedScene>($"{scenePath}").Instantiate();

        //Node currentScene = GetTree().CurrentScene;
        //GetTree().Ch
        //GetTree().Root.CallDeferred("add_child", newScene);

        //currentScene.CallDeferred("queue_free");

        //GD.Print("End of Change Scene");
    }


    private void OnGoBackButton()
    {
        GetTree().ChangeSceneToFile("res://scenes/MenuScenes/MainMenu.tscn");
    }

    private void OnStartLevelButton() 
    {
        GetTree().ChangeSceneToFile("res://start.tscn");        
    }

    private void OnLevel_1Button() 
    {
        GetTree().ChangeSceneToFile("res://scenes/level_1.tscn");
    }

    private void OnLevel_2Button()
    {
        GetTree().ChangeSceneToFile("res://scenes/level_2.tscn");       
    }

    private void OnLevel_3Button()
    {
        GetTree().ChangeSceneToFile("res://scenes/level_3.tscn");       
    }

    private void OnLevel_4Button()
    {
        GetTree().ChangeSceneToFile("res://scenes/level_4.tscn");
    }
}
