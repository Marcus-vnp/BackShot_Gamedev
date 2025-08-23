using Godot;
using System;

public partial class ProjectilScript : Area2D
{
    public Godot.Vector2 dir = new Godot.Vector2(0, 0);
    public override void _Ready()
    {
        this.BodyEntered += (body) => DeleteMe(body);

    }
    public override void _Process(double delta)
    {
        this.Position += new Godot.Vector2(dir.X, dir.Y);
    }

    private void DeleteMe(Node2D body)
    {
        if (body.Name != "CharacterBody2D")
        {
            if (body.Name == "EnemyBody")
            {
                body.GetParent().QueueFree();
            }
            this.GetParent().QueueFree();               
        }
    }
}
