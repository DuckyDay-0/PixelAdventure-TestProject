using Godot;
using System;

public partial class Levelmanager : Node
{

	//int bananasNeeded = 7;
	
	int currentBananas = 0;
	
   
	public void GetBanana()
	{
		currentBananas += 1;
		GD.Print("Before the If Banana " + currentBananas);
		if (currentBananas == 8)
		{
			GD.Print("Entering the level");
			var newLevel = ResourceLoader.Load<PackedScene>("res://scenes/level_2.tscn").Instantiate();
			Node currentScene = GetTree().Root.GetChild(0);

			GetTree().Root.CallDeferred("add_child", newLevel);
			currentScene.CallDeferred("queue_free");
		}
	}
}
