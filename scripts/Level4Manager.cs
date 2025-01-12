using Godot;
using System;

public partial class Level4Manager : Area2D
{
    CollisionShape2D collisionShape;
    AnimationPlayer animationPlayer;


    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }


    private void OnBodyEntered(Node body)
    {
        if (body.Name == "player")
        { 
            animationPlayer.Play("spikeHead");
        }

    }
}
