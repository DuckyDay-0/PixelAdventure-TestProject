using Godot;
using System;

public partial class Killzone : Area2D
{
    Timer timer;
    private void _on_body_entered(Node2D body)
    {
        timer = GetNode<Timer>("Timer");
        GD.Print("Dead");
        Engine.TimeScale = 0.2;
        timer.Start();
    }

    private void _on_timer_timeout()
    {
        //Because for some reason GetTree().RealoadCurrentScene() was returning null
        //we are manually realoading the current scene

        Engine.TimeScale = 1;
        //load the new scene(which is the current one as well)
        var newLevel = ResourceLoader.Load<PackedScene>("res://scenes/level_2.tscn").Instantiate();

        //Get the first node(current one)
        Node currentScene = GetTree().Root.GetChild(0);

        //Add the new scene to the root(current scene)
        GetTree().Root.CallDeferred("add_child", newLevel);

        //Remove the current scene and free the queue(replace it)
        currentScene.CallDeferred("queue_free");
    }
}
