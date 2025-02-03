using Godot;
using System;

public partial class Global : Node
{
	public static Global Instance { get; private set; }
	public string selectedCharacter = "frog";
	public int deathCounter { get; set; } = 0;
	public int fruitCounter { get; set; } = 0;
	Transition transition;
	public Player PlayerInstance { get; set; }
	
	public override void _Ready()
	{
		Instance = this;

	}

	public void IncDeathCounter()
	{ 
		deathCounter++;
	}

	public void IncFruitCounter()
	{ 
		fruitCounter++;
	}

    public void GetFruit()
    {
        int currentFruit = Global.Instance.fruitCounter;
        GD.Print("Before the If Fruit " + currentFruit);
        if (currentFruit == 8)
        {
            GD.Print("Entering the level");
            CallDeferred(nameof(ChangeScene));
        }
    }


    private void ChangeScene()
    {
        transition = GetTree().Root.GetNode<Transition>("Transition");

        transition.StartTransition("res://scenes/level_2.tscn");
    }
}
