namespace Net14Web.Services.ApiServices.Dtos.LifeScore
{
    public class RootDto
    {
        public string get { get; set; }
        public List<object> parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public List<Response> response { get; set; }
    }
}
public class Country
{
    public int id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public string flag { get; set; }
}

public class Response
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string logo { get; set; }
    public Country country { get; set; }
    public List<Season> seasons { get; set; }
}

public class Season
{
    public int season { get; set; }
    public bool current { get; set; }
    public string start { get; set; }
    public string end { get; set; }
}
