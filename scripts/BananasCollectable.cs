using Godot;
using System;

public partial class BananasCollectable : Area2D
{
	Levelmanager levelManager;
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		levelManager = GetNode<Levelmanager>("%Levelmanager");
	}

	public void OnBodyEntered(Node body)
	{
		if (body.Name == "player")
		{
			GD.Print("Getting Banana");
			levelManager.GetBanana();
			QueueFree();
		}
	}

}
