using Godot;
using System;

public partial class Fire : Area2D
{
    CollisionShape2D killzoneColider;
    CollisionShape2D fireDetector;

    Timer timer;
    Timer fireTimer;
    AnimatedSprite2D animatedSprite;

    Killzone killzone;
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        fireTimer = GetNode<Timer>("FireTimer");
        killzone = GetNode<Killzone>("killzone");
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        killzoneColider = killzone.GetNode<CollisionShape2D>("CollisionShape2D");
        fireDetector = GetNode<CollisionShape2D>("fireDetector");

        timer.Connect("timeout", new Callable(this, nameof(OnTimer)));
        fireTimer.Connect("timeout", new Callable(this, nameof(OnFireTimer)));
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));


        animatedSprite.Play("fireIdle", -1, true);
        killzoneColider.Disabled = true;
        fireDetector.Disabled = false;
    }

    //Handle when the animation to start and when the timer for the animation timer to start
    public void OnBodyEntered(Node2D body)
    {
        if (body.Name == "player")
        {
            GD.Print("fireHit");
            animatedSprite.Play("fireHit");
        }
        timer.WaitTime = 0.7f;
        timer.Start();
        fireDetector.CallDeferred("set_disabled", true);
    }

    //half a sec before activation
    //Handles animation for when there is fire and when there is not
    //and for when the killzone animation to start
    private void OnTimer()
    {
        animatedSprite.Play("fireOn");
        timer.Stop();

        fireTimer.WaitTime = 1f;
        fireTimer.Start();

        killzoneColider.Disabled = false;
    }

    private void OnFireTimer()
    {
        animatedSprite.Play("fireIdle", -1, true);
        killzoneColider.Disabled = true;

        animatedSprite.Stop();
        fireDetector.CallDeferred("set_disabled", false);
    }



}
