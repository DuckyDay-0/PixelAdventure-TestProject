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
			CallDeferred(nameof (ChangeScene));
		}
	}

	private void ChangeScene()
	{
		GetTree().ChangeSceneToFile("res://scenes/level_2.tscn");
	}
}
