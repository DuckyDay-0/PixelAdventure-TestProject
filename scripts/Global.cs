using Godot;
using System;

public partial class Global : Node
{
	public static Global Instance { get; private set; }
	public string selectedCharacter = "frog";
	public int deathCounter { get; set; } = 0;

	public Player PlayerInstance { get; set; }
	public override void _Ready()
	{
		Instance = this;

		
	}

	public void IncDeathCounter()
	{ 
		deathCounter++;
	}

	
}
