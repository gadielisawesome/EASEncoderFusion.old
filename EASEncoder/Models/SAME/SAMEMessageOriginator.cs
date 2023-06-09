namespace EASEncoder.Models.SAME
{
    public class SAMEMessageOriginator
    {
        public SAMEMessageOriginator(string id, string name, bool broken = false)
        {
            Id = id;
            Name = name;
            Broken = broken;
        }

        public string Id { private set; get; }
        public string Name { private set; get; }
        public bool Broken { private set; get; } = false;
    }
}