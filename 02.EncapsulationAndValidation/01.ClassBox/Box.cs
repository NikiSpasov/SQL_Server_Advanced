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
        set => this.length = value;
    }

    public double Width
    {
        get => this.width;
        set => this.width = value;
    }

    public double Height
    {
        get => height;
        set => this.height = value;
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

