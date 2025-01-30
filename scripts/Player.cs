using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -300.0f;
	public Vector2 respawnPosition;

	public Label deathLabel;
	public Vector2 deathCounterOffset = new Vector2(10, 10);//the position of the counter above the players head

	public bool canDoubleJump = true;

	AnimatedSprite2D animatedSprite;
	//CharacterSelector playerSelector;

	private string defCharacterPrefix;

	public override void _Ready()
	{
		deathLabel = GetNode<Label>("DeathCounter/Label");
		UpdateDeathCounterUI();

		//Initialize the respwn position at the players starting position
		respawnPosition = Position;
		
		defCharacterPrefix = Global.Instance.selectedCharacter;
		UpdateCharacter(defCharacterPrefix);
	}


	public void UpdateCharacter(string chosenCharacter)
	{

        defCharacterPrefix = chosenCharacter;
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite.Play($"{defCharacterPrefix}Idle"); // Reset to idle animation of the chosen character
        GD.Print($"Character chosen: {defCharacterPrefix}");
    }
	public void SetRespawnPosition(Vector2 newPosition)
	{
		respawnPosition = newPosition;
	}

	public void Respawn()
	{
		if (IsInstanceValid(this))
		{
			Position = respawnPosition;

			Global.Instance.IncDeathCounter();
			UpdateDeathCounterUI();
		}
		else
		{
			GD.PrintErr("Cannot respawn, Player instance is not valid.");
		}
	}

	public void UpdateDeathCounterUI()
	{
		deathLabel.Text = $"{Global.Instance.deathCounter}";
	}

	public override void _PhysicsProcess(double delta)
	{
		GetNode<Node2D>("DeathCounter").Position = deathCounterOffset;
		Vector2 velocity = Velocity;
		
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (IsOnFloor() && Input.IsActionJustPressed("jump"))
		{
			velocity.Y = JumpVelocity;
			canDoubleJump = true;
		}
		if (!IsOnFloor() && Input.IsActionJustPressed("jump") && canDoubleJump)
		{
			canDoubleJump = false;
			velocity.Y = JumpVelocity;			
			
		}
		
		//Handles the Animation
		var direction = Input.GetAxis("left", "right");
		if (IsOnFloor())
		{
			if (direction == 0)
			{
				animatedSprite.Play($"{defCharacterPrefix}Idle");
			}
			else
			{
				animatedSprite.Play($"{defCharacterPrefix}Run");
			}
		}

		
		//Handles the sprite flip
		if (direction > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if(direction < 0)
		{
			animatedSprite.FlipH = true;
		}

        //Handles the Jump animation
        if (!IsOnFloor() && canDoubleJump == true)
        {
            animatedSprite.Play($"{defCharacterPrefix}Jump");
        }
		if (!IsOnFloor() && canDoubleJump == false)
		{
			animatedSprite.Play($"{defCharacterPrefix}DoubleJump");		
		}
		
		//Handles the movement
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		//GoToMenuButton
		if (Input.IsActionJustPressed("GoToMenuButton"))
		{
			GD.Print("Escape");
			//GetTree().ChangeSceneToFile("res://scenes/MenuScenes/MainMenu.tscn");
		}

		Velocity = velocity;
		MoveAndSlide();
	}


}
