
namespace Geometry;
  

abstract class GeometricFigure
{
    public string? Name { get; set; }
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public override string ToString()
    {
        return $"{Name,-13} => Area.....: {GetArea():N5}    Perimeter: {GetPerimeter():N5}";
    }
}


class Circle : GeometricFigure
{
    protected double _r;
    public double R => _r;

    public Circle(string name, double r)
    {
        Name = name;
        _r = r;
        ValidateR();
    }

    public override double GetArea() => Math.PI * _r * _r;
    public override double GetPerimeter() => 2 * Math.PI * _r;

    public void ValidateR()
    {
        if (_r <= 0)
        {
            throw new ArgumentException("El radio del círculo debe ser mayor que 0.");
        }
    }
}

class Square : GeometricFigure
{
     protected double _a;

    public Square(string name, double a)
    {
        Name = name;
        _a = a;
    }

    public override double GetArea() => _a * _a;
    public override double GetPerimeter() => 4 * _a;

    public void ValidateA()
    {
        if (_a <= 0)
        {
            throw new ArgumentException("El lado del cuadrado debe ser mayor que 0.");
        }
    }

}

class Rhombus : Square
{
    protected double _d1, _d2;

    public Rhombus(string name, double a, double d1, double d2) : base(name, a)
    {
        _d1 = d1;
        _d2 = d2;
    }

    public override double GetArea() => (_d1 * _d2) / 2;
    public override double GetPerimeter() => 4 * _a;

    public void ValidateD1()
    {
        if (_d1 <= 0)
        {
            throw new ArgumentException("La diagonal D1 del rombo debe ser mayor que 0.");
        }
    }

    public void ValidateD2()
    {
        if (_d2 <= 0)
        {
            throw new ArgumentException("La diagonal D2 del rombo debe ser mayor que 0.");
        }
    }

}

class Kite : Rhombus
{
     protected double _b;

    public Kite(string name, double a, double d1, double d2, double b) : base(name, a, d1, d2)
    {
        _b = b;
    }

    public override double GetArea() => (_d1 * _d2) / 2;

    public override double GetPerimeter() => 2 * (_a + _b);

    public void ValidateB()
    {
        if (_b <= 0)
        {
            throw new ArgumentException("El lado B del cometa debe ser mayor que 0.");
        }
    }

}

class Rectangle : Square
{
    protected double _b;

    public Rectangle(string name, double a, double b) : base(name, a)
    {
        _b = b;
    }

    public override double GetArea() => _a * _b;
    public override double GetPerimeter() => 2 * (_a + _b);

    public void ValidateB()
    {
        if (_a <= 0 || _b <= 0)
        {
            throw new ArgumentException("Los lados del rectángulo deben ser mayores que 0.");
        }
    }

}

class Parallelogram : Rectangle
{
    protected double _h;
    public Parallelogram(string name, double a, double b, double h) : base(name, a, b)
    {
        _h = h;
    }

    public override double GetArea() => _b * _h;
    public override double GetPerimeter() => 2 * (_a + _b);

    public void ValidateH()
    {
        if (_a <= 0 || _b <= 0)
        {
            throw new ArgumentException("Los lados del paralelogramo deben ser mayores que 0.");
        }

        if (_h <= 0)
        {
            throw new ArgumentException("La altura del paralelogramo debe ser mayor que 0.");
        }
    }

}

class Triangle : Rectangle
{
    protected double _h, _c;

    public Triangle(string name, double a, double b, double c, double h) : base(name, a, b)
    {
        Name = name;
        
        _c = c;
        _h = h;
    }

    public override double GetArea() => _b * _h/ 2;

    public override double GetPerimeter() => _a + _b + _c;

    public void ValidateC()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
        {
            throw new ArgumentException("Los lados del triángulo deben ser mayores que 0.");
        }

        if ((_a + _b <= _c) || (_a + _c <= _b) || (_b + _c <= _a))
        {
            throw new ArgumentException("La suma de dos lados del triángulo debe ser mayor que el tercer lado.");
        }
    }

    public void ValidateH()
    {
        if (_h <= 0)
        {
            throw new ArgumentException("La altura del triángulo debe ser mayor que 0.");
        }
    }

}

class Trapeze : Triangle
{
     protected double _d;

    public Trapeze(string name, double a, double b, double c, double h, double d) : base(name, a, b, c, h )
    {
        _d = d;
        
    }

    public override double GetArea() => ((_b + _d) * _h) / 2;

    public override double GetPerimeter() => _a + _b + _c + _d;

    public void ValidateD()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0 || _d <= 0)
        {
            throw new ArgumentException("Todos los lados del trapecio deben ser mayores que 0.");
        }

        if (_h <= 0)
        {
            throw new ArgumentException("La altura del trapecio debe ser mayor que 0.");
        }
    }

}
