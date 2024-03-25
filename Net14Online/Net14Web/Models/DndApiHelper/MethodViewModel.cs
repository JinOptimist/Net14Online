namespace Net14Web.Models.DndApiHelper
{
    public class MethodViewModel
    {
        public string Name { get; set; }
        public MethodType MethodType { get; set; }
        public List<ParameterViewModel> Parameters { get; set; }
    }
}