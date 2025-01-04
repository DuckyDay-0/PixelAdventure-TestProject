using Godot;
using System;

public partial class Checkpoint : Area2D
{

    AnimatedSprite2D animatedSprite;
    bool isCheckpointActive = false;
    public override void _Ready()
    {

        Connect("body_entered", new Callable(this, nameof(onCheckpointBodyEntered)));

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
}
