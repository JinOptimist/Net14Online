// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var http = new HttpClient();
http.BaseAddress = new Uri("https://localhost:7163/");

var responseObj = await http.GetAsync("Dnd/CoinPlusOne?heroId=4");
var responseString = await responseObj.Content.ReadAsStringAsync();

Console.WriteLine(responseString);
