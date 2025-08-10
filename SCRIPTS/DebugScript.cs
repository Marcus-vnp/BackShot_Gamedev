using Godot;
using System;

public partial class DebugScript : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Restart"))
            GetTree().ReloadCurrentScene();
    }

}
