using Godot;
using System;

public partial class Killzone : Area2D
{
    Timer timer;
    Player player;
    Vector2 playerRespwanPosition;

    [Export]
    string scenePath;


    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        player = GetNode<Player>("/root/Level_3/player");
    }
    private void _on_body_entered(Node2D body)
    {
        //get the player current position(where the checkpoint is)
        playerRespwanPosition = player.respawnPosition;
        timer.WaitTime = 0.2f;
        GD.Print("Dead");
        Engine.TimeScale = 0.2;
        timer.Start();
    }

    private void _on_timer_timeout()
    {
        //reset the TimeScale and if the player exists in the current scene assign him the current
        //position(where the checkpoint is)
        Engine.TimeScale = 1;
        if (player != null)
        {
            player.SetRespawnPosition(playerRespwanPosition);
            player.Respawn();
        }
    }
}
