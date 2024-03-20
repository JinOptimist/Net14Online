namespace Net14Web.Models.DndApiHelper
{
    public class ExampleClassWithList
    {
        public string UserName { get; set; }
        public List<int> UserIds { get; set; }
        public int? UserCount { get; set; }
        public List<ExampleV2> Examples { get; set; }
        public bool IsGood { get; set; }
    }

    public class ExampleV2
    {
        public float Coins { get; set; }
        public char CoolSymbol { get; set; }
    }
}
