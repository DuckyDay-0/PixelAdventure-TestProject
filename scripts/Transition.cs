using Godot;
using System;

public partial class Transition : CanvasLayer
{
	/// <summary>
	/// The Transition scene is autoloaded,the visibility is controlled manually from here
	/// There is a timer so the scene can change while the animation is playing and not before or after it
	/// The Transition.cs is referenced in the NextLevelArea.cs which is playing the transition scene once the player is on the nextLevelArea
	/// We are getting the next scene path from NextLevelArea.cs and changing of the scene is now happening here and not in nextLevelArea 
	/// </summary>
    private AnimationPlayer animationPlayer;
	private Timer timer;
    [Export]
	private string NextScenePath = "";
	
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		timer = GetNode<Timer>("Timer");
        animationPlayer.Connect("animation_started", new Callable(this, nameof(OnAnimationStarted)));
        timer.Connect("timeout", new Callable(this, nameof(OnTimeout)));

        Visible = false;
        

    }

    private void OnTimeout()
	{
        GetTree().ChangeSceneToFile(NextScenePath);
        Visible = false;
		timer.Stop();
    }

	public void StartTransition(string scenePath)
	{
        NextScenePath = scenePath;

		Visible = true;

		animationPlayer.Play("FadeInOut");
    }

    private void OnAnimationStarted(string animationName)
	{
        GD.Print("Entering for scene change");
		timer.WaitTime = 1f;
		timer.Start();
	}

}
