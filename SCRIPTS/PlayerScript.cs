using Godot;
using System;

public partial class PlayerScript : Node2D
{
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("mouse_left_click")) // Quando clicar com o botão esquerdo, pega as coordenadas do mouse
        {
            GD.Print(GetViewport().GetMousePosition());
        }
    }
}
