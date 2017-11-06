public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }

    public int Weight
    {
        get => this.weight;
        private set => this.weight = value;
    }

    public string Type
    {
        get => this.type;
        private set => this.type = value;
    }
}

