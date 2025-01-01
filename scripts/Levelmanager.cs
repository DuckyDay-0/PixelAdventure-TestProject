using Godot;
using System;

public partial class Levelmanager : Node
{

	//int bananasNeeded = 7;
	
	int currentFruit = 0;
	
   
	public void GetFruit()
	{
        currentFruit += 1;
		GD.Print("Before the If Fruit " + currentFruit);
		if (currentFruit == 8)
		{
			GD.Print("Entering the level");
			var newLevel = ResourceLoader.Load<PackedScene>("res://scenes/level_2.tscn").Instantiate();
			Node currentScene = GetTree().Root.GetChild(0);

			GetTree().Root.CallDeferred("add_child", newLevel);
			currentScene.CallDeferred("queue_free");
		}
	}
}
