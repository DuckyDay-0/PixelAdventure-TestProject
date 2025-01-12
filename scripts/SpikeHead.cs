using Godot;
using System;

public partial class SpikeHead : Node2D
{
    Timer timer;
    Timer blinkTimer;
    AnimatedSprite2D animatedSprite;
    

    private bool isIdle = true;
    public override void _Ready()
    {
        timer = GetNode<Timer>("AnimatableBody2D/Timer");
        blinkTimer = GetNode<Timer>("AnimatableBody2D/blinkTimer");
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatableBody2D/AnimatedSprite2D");

        timer.Connect("timeout", new Callable(this, nameof(OnTimeout)));
        blinkTimer.Connect("timeout", new Callable(this, nameof(OnBlinkTimeout)));

        animatedSprite.Play("Idle", -1, true);
        timer.WaitTime = 2f;
        timer.Start();
    }


    private void OnBlinkTimeout()
    { 
        animatedSprite.Play("Idle");
        GD.Print("Blink");  
    }
    private void OnTimeout()
    {
        GD.Print("OnTimeout");
        blinkTimer.WaitTime = 0.3f;
        blinkTimer.Start();
        animatedSprite.Play("Blink");
    }


}
