namespace ManagementCompany.Models.Info
{
    public class MethodViewModel
    {
        public string Name { get; set; }
        public MethodType MethodType { get; set; }
        public UserType UserType { get; set; }
        public List<ParameterViewModel> Parameters { get; set; }
    }
}
