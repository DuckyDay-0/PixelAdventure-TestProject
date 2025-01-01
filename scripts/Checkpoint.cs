using Godot;
using System;

public partial class Checkpoint : Area2D
{
    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(onCheckpointBodyEntered)));
    }

    private void onCheckpointBodyEntered(Node body)
    {
        if (body is Player player)
        {
            player.SetRespawnPosition(GlobalPosition);
            GD.Print("Checkpoint mate");
        }
    }
}
