using Godot;
using System;

public partial class Checkpoint : Area2D
{
    CollisionShape2D collisionShape;
    AnimatedSprite2D animatedSprite;
    bool isCheckpointActive = false;

    public override void _Ready()
    {

        Connect("body_entered", new Callable(this, nameof(onCheckpointBodyEntered)));

        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        animatedSprite = GetNode<AnimatedSprite2D>("flagAnimation");
        animatedSprite.Connect("animation_finished", new Callable(this, nameof(onAnimationFinished)));


        animatedSprite.Play("checkpointNoFlag");
        GD.Print("noFlag");
    }

    private void onCheckpointBodyEntered(Node body)
    {
        if (body is Player player)
        {
            player.SetRespawnPosition(GlobalPosition);
            GD.Print("Checkpoint mate");

            isCheckpointActive = true;
            animatedSprite.Play("checkpointFlagOut");
            IsCheckpointActive();
            GD.Print("Flag Out");
        }
     

    }

    private void onAnimationFinished()
    {
        GD.Print("onAnimation");

        if (isCheckpointActive)
        {
            animatedSprite.Play("checkpointFlagIdle", -1, true);
            GD.Print("FlagIdle");

        }
    }

    private void IsCheckpointActive()
    {
        if (isCheckpointActive == true)
        {
            collisionShape.CallDeferred("set_disabled", true);
        }
        else
        {
            collisionShape.CallDeferred("set_disabled", false);
        }
    }
}
