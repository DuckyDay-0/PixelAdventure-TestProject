using Godot;
using System;

public partial class Fire : Area2D
{
    CollisionShape2D killzoneColider;
    Timer timer;
    Timer fireTimer;
    AnimatedSprite2D animatedSprite;

    Killzone killzone;
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        fireTimer = GetNode<Timer>("FireTimer");

        timer.Connect("timeout", new Callable(this, nameof(OnTimer)));
        fireTimer.Connect("timeout", new Callable(this, nameof(OnFireTimer)));

        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        killzone = GetNode<Killzone>("killzone");
        killzoneColider = killzone.GetNode<CollisionShape2D>("CollisionShape2D");

        //animatedSprite.Connect("frame_changed", new Callable(this, nameof(OnFrameChanged)));

        animatedSprite.Play("fireIdle", -1, true);
        killzoneColider.Disabled = true;
    }


    public void OnBodyEntered(Node2D body)
    {
        GD.Print("OnBodyEntered");
        if (body.Name == "player")
        {
            GD.Print("fireHit");
            animatedSprite.Play("fireHit");
        }
        timer.WaitTime = 1f;
        timer.Start();
    }

    //half a sec before activation
    //Handles animation for when there is fire and when there is not 
    private void OnTimer()
    {
        GD.Print("timerOut");
        animatedSprite.Play("fireOn");
        timer.Stop();

        fireTimer.WaitTime = 2f;
        fireTimer.Start();

        EnableKillzoneCollider();
    }

    private void OnFireTimer()
    {
        GD.Print("OnFireTimer");
        animatedSprite.Play("fireIdle", -1, true);
        killzoneColider.Disabled = true;

        animatedSprite.Stop();
    }


    private void EnableKillzoneCollider()
    {
        killzoneColider.Disabled = false;
    }
}
