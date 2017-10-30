using System;
using System.Text;

public class Box
{

    private double length;
    private double width;
    private double height;
    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get => this.length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {

        get => this.height;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    private double AreaCalculated()
    {
        return (2 * Length * Height) + (2 * Width * Height);
    }

    private double VolumeCalculated()
    {
        return (Height * Width * Length);
    }

    private double SurfaceAreaCalculated()
    {
        return (2 * Length * Width)
               + (2 * Length * Height)
               + (2 * Width * Height);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Surface Area - {this.SurfaceAreaCalculated():0.00}");
        sb.AppendLine($"Lateral Surface Area - {this.AreaCalculated():0.00}");
        sb.AppendLine($"Volume - {this.VolumeCalculated():0.00}");

        return sb.ToString().Trim();
    }

}