using System;
using System.Collections.Generic;

abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with Radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with Width {Width} and Height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        // Implementation of scaling for Triangle
    }
}

class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void MoveAll(int x, int y)
    {
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage:
        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 8, Height = 12 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        Group group = new Group { X = 70, Y = 80 };
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);
        group.AddPrimitive(triangle);

        GraphicsEditor editor = new GraphicsEditor();
        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        editor.DrawAll();

        editor.MoveAll(5, 5);
        editor.ScaleAll(1.5f);

        editor.DrawAll();
    }
}
