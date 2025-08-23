using Godot;
using System;
using System.Threading;

public partial class TimerShot : Godot.Timer
{
    private PlayerBodyScript playerBody; // armazena o Objeto do Player
    public override void _Ready()
    {
        playerBody = this.GetParent<PlayerBodyScript>(); // pega o objeto do player 
        this.Timeout += () => ToShoot(); // chama a função ToShoot() quando o timer acaba
    }
    private void ToShoot()
    {
        playerBody.CanShoot = true; // pega a variavel CanShoot do player e torna verdadeira
        this.Stop(); // para o timer
    }
}