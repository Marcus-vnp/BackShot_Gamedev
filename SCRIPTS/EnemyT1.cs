using Godot;
using System;

public partial class EnemyT1 : CharacterBody2D
{
	public float direction; // direção do inimigo
	public Godot.Vector2 speed = new Godot.Vector2(0, 0); // velocidade do inimigo
	public override void _Ready()
	{
		direction = 1f;
	}

	public override void _Process(double delta)
	{
		if (IsOnFloor())
		{
			speed.X = direction;
			speed.Y = 0;
		}
		else
		{
			speed.Y = 1;
			speed.X = 0;
		}

		this.Velocity += speed;
		MoveAndSlide();
	}

}
