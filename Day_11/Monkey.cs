namespace Day_11
{
    class Monkey
    {
        public int Id { get; set; }

        public List<int> Items { get; set; } = new();

        public string TextOperation { get; set; } = default!;

        public int Divider { get; set; }

        public List<int> ThrowToMonkey { get; set; } = new();

        public int InspectedItems { get; set; } = 0;
    }
}
