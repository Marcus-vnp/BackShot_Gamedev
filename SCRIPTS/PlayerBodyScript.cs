using Godot;
using System;
using System.Numerics;

public partial class PlayerBodyScript : CharacterBody2D
{
    private const float gravity = 5f; // variavel da gravidade
    private Godot.Vector2 speed = new Godot.Vector2(0, 0); // vetor da velocidade dos movimentos do player
    private Godot.Vector2 mouseCoords = new Godot.Vector2(0, 0); // Posição do mouse (X,Y)
    private Godot.Vector2 ricochet = new Godot.Vector2(100, 50); // Força do ricochete
    private Godot.Vector2 dir; // Direção do ricochete
    public override void _Ready()
    {
        Position = new Godot.Vector2(590, 290); // DELETAR DEPOIS
    }

    public override void _Process(double delta)
    {

        if (IsOnFloor()) // Colisão com o chão
        {
            speed.Y = 0;

            // Reduzindo o Deslize apenas ao chegar no chão
            if (speed.X > 0)
            {
                speed.X -= 1;
            }
            else if (speed.X < 0)
            {
                speed.X += 1;
            }
        }
        else // Aplicação da gravidade
        {
            speed.Y += 2;
        }

        if (IsOnCeiling() && speed.Y < 0) // Reseta a Velocidade ao colidir com o Teto
        {
            speed.Y = 0;
        }

        if (Input.IsActionJustPressed("mouse_left_click")) // Pressiona Botão Esquerdo
        {
            mouseCoords = GetViewport().GetMousePosition(); // Pegando coordenadas do mouse
            dir = GetDir(this.Position, mouseCoords); // Pegando a direção do ricochete
            speed = new Godot.Vector2(0, 0); // resetando a velocidade
            // Aplicando o ricochete
            speed.X = ricochet.X * GetCos(this.Position, mouseCoords, true) * dir.X;
            speed.Y += ricochet.Y * GetCos(this.Position, mouseCoords, false) * dir.Y;
            GD.Print("COS X = ", GetCos(this.Position, mouseCoords, true));
            GD.Print("COS Y = ", GetCos(this.Position, mouseCoords, false));
        }

        // aplicando as variações nos eixos de velocidade (causa tanto a gravidade quanto o ricochete)
        this.Velocity = new Godot.Vector2(speed.X, speed.Y * gravity);
        MoveAndSlide();
    }

    private float GetCos(Godot.Vector2 pCoords, Godot.Vector2 mCoords, bool axle)
    {
        Godot.Vector2 peccaries = pCoords - mCoords; // pegando os catetos
        // declarando variavel da hipotenusa e do cosseno
        int hypotenuse;
        float cos;

        // pegando o módulo dos catetos 
        if (peccaries.X < 0)
        {
            peccaries.X *= -1;
        }
        if (peccaries.Y < 0)
        {
            peccaries.Y *= -1;
        }

        // Pegando a hipotenusa
        hypotenuse = (int) Math.Sqrt((peccaries.X * peccaries.X) + (peccaries.Y * peccaries.Y));

        // definindo o cosseno referente ao eixo
        if (axle)
        {
            cos = peccaries.X / hypotenuse;
        }
        else
        {
            cos = peccaries.Y / hypotenuse;
        }

        return cos;
    }
    // Função para pegar a direção do ricochete
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
