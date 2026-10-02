using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const int PlayerState = 0; 

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		string[] movement = ["move_left", "move_right", "move_up", "move_down"];

		Vector2 direction = Input.GetVector(movement[0], movement[1], movement[2], movement[3]);
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		bool keyPressed = false;
		for (int i = 0; i < movement.Length; i++) {
			if (Input.IsActionJustReleased(movement[i]))
			{
				animation.Stop();
				animation.Animation = movement[i];
				animation.Frame = animation.SpriteFrames.GetFrameCount(movement[i]) - 1;
			} 
			if (Input.IsActionPressed(movement[i]))
			{
				keyPressed = true;
			}
		}
		
		int b = 0;
		switch(b) {
			case 0:

			case 1:

			case 2:

			case 3:

			default:
				break;
		}
		if (Input.IsActionPressed(movement[0])) {
			animation.Play(movement[0]);
		}
		
	}
}
