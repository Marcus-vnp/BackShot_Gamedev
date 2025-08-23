using Godot;
using System;

public partial class TimerWalkEnemyT1 : Timer
{
    private EnemyT1 enemy;
    public override void _Ready()
    {
        enemy = this.GetParent<EnemyT1>();
        this.Timeout += () => ChangeDirection();
    }

    private void ChangeDirection()
    {
        enemy.direction = enemy.direction * -1;
        enemy.Velocity = enemy.Velocity / 2;

        GD.Print("TROCOU");
    }

}
