using Godot;
using System;

public partial class NextLevelArea : Area2D
{


    /// <summary>
    /// Bug Fixed:
    ///When using a singleton/Global script/node ,directly unloading/changing the scene using que_free/free
    ///interferes with the _PhysicsProcess and breaks the engine 
    ///So we are deffering the changes ,and then changing the scene using ChangeSceneToFile(scenePath)
    /// </summary>
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
            CallDeferred(nameof(ChangeScene));
        }
    }

    private void ChangeScene()
    {
        GetTree().ChangeSceneToFile(scenePath);
    }
}