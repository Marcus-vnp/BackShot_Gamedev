using Godot;
using System;

public partial class ShotgunScript : Node2D
{
	// variavel do Node do Player
	private Node2D playerNode;
	// variavel do Node CharacterBody
	private CharacterBody2D playerBody;
	// variavel do Sprite da Shotgun
	private Sprite2D spriteNode;
	private Godot.Vector2 mouseCoords;
	public override void _Ready()
	{
		// pegando o Node do player
		playerNode = this.GetParent<Node2D>();
		// pegando o Sprite da shotgun
		spriteNode = this.GetChild<Sprite2D>(0);
		// pegando o CharacterBody do player
		playerBody = playerNode.GetChild<CharacterBody2D>(0);
	}

	public override void _Process(double delta)
	{
		// pegando o CharacterBody do player
		// pegando as coordenadas do mouse
		mouseCoords = GetGlobalMousePosition();
		this.Position = playerBody.Position;
		LookAt(mouseCoords);

		if (GetDir(this.Position, mouseCoords).X == 1)
			spriteNode.FlipV = true;
		else
			spriteNode.FlipV = false;
	}
	private Godot.Vector2 GetDir(Godot.Vector2 cord1, Godot.Vector2 cord2)
	{
		Godot.Vector2 dirCoord = new Godot.Vector2(0, 0);

		if (cord1.X - cord2.X > 0)
		{
			dirCoord.X = 1;
		}
		else
		{
			dirCoord.X = -1;
		}
		if (cord1.Y - cord2.Y > 0)
		{
			dirCoord.Y = 1;
		}
		else
		{
			dirCoord.Y = -1;
		}
		// Vai retornar a direção em relação da cord1
		return dirCoord;
	}
}
