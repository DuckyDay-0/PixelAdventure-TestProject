using Godot;
using System;

public partial class BananasCollectable : Area2D
{
	Levelmanager levelManager;
	AnimatedSprite2D animatedSprite;
	bool isBananaCollected = false;

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		levelManager = GetNode<Levelmanager>("%Levelmanager");
		animatedSprite = GetNode<AnimatedSprite2D>("bananaAnimation");

		//connect the animation_finished signal so we can detect when the prev animation have finished
        animatedSprite.Connect("animation_finished", new Callable(this, nameof(OnAnimationFinished)));


    }

    public void OnBodyEntered(Node body)
	{
		if (body.Name == "player")
		{
			GD.Print("Getting Banana");
			levelManager.GetBanana();
			isBananaCollected = true;
			animatedSprite.Play("collected");			
        }
	}

	public void OnAnimationFinished()
	{
		//If banana is collected delete the node and reset the the IsBananaCollected
		if (isBananaCollected == true)
		{
			GD.Print("Collected banana");
			QueueFree();
			isBananaCollected = false;
		}
	}
}
