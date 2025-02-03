using Godot;
using System;

public partial class FruitCollectable : Area2D
{
	[Export]
	string animationName = "";

	AnimatedSprite2D animatedSprite;
	Transition transition;
	bool isFruitCollected = false;

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		animatedSprite = GetNode<AnimatedSprite2D>("fruitAnimation");

		//connect the animation_finished signal so we can detect when the prev animation have finished
        animatedSprite.Connect("animation_finished", new Callable(this, nameof(OnAnimationFinished)));

		if (HasAnimation(animationName))
		{
			animatedSprite.Animation = animationName;
			animatedSprite.Play(animationName);
		}
    }

	 

	public bool HasAnimation(string animationName)
	{
		var animations = animatedSprite.SpriteFrames.GetAnimationNames();

		foreach (var anim in animations)
		{
			if (anim == animationName)
			{
				return true;
			}
			
		}

		return false;
	}

    public void OnBodyEntered(Node body)
	{
		if (body.Name == "player")
		{
			GD.Print("Getting Fruit");
			Global.Instance.IncFruitCounter();
			Global.Instance.GetFruit();
            isFruitCollected = true;
			animatedSprite.Play("collected");			
        }
	}

	public void OnAnimationFinished()
	{
		//If the fruit is collected delete the node and reset the IsBananaCollected
		if (isFruitCollected == true)
		{
			GD.Print("Collected fruit");
			QueueFree();
            isFruitCollected = false;
		}
	}

   
}
