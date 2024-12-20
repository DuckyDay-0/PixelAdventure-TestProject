using Godot;
using System;

public partial class NextLevelArea : Area2D
{
    [Export]
    string scenePath = "";
    public override void _Ready()
    {
        //Connect the signal
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    private void OnBodyEntered(Node body)
    {
        if (body.Name == "player")
        {
            //load the new scene
            var newLevel = ResourceLoader.Load<PackedScene>($"{scenePath}").Instantiate();

            //Get the first node(current Scene)
            Node currentScene = GetTree().Root.GetChild(0);

            //Add the new scene to the root
            GetTree().Root.CallDeferred("add_child", newLevel);

            //Remove the current scene and free the queue
            currentScene.CallDeferred("queue_free");

            GD.Print("Yes");

        }
    }
}