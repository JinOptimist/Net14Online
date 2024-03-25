// var thread = new Thread();
//var task = new Task();


using SandboxForMultyThreading;

var t = new TaskExample();

Console.WriteLine("Mark 0");

var task1 = new Task(() =>
{
    t.Say1To100("Lera");
});

Console.WriteLine("Mark 1");

var task2 = new Task(() =>
{
    t.Say1To100("Ivan");
});

Console.WriteLine("Mark 2");


task1.Start(); // 5 sec
//task1.Wait();
task2.Start(); // 7 sec
//task2.Wait();
// 5 + 7 = 12 sec

Task.WaitAll(task1, task2); // Max (5, 7) = 7 sec

Console.WriteLine("Mark 3");

//Console.ReadLine();

Task task = t.CalcComplexTextAsync("Olga", 3);
//var text = task.Result;

//string textShort = await t.CalcComplexTextAsync("Olga", 3);
//string textShort2 = await t.CalcComplexTextAsync("Olga", 3);
//string textShort3 = await t.CalcComplexTextAsync("Olga", 3);
//string textShort4 = await t.CalcComplexTextAsync("Olga", 3);

var textShortTask = t.CalcComplexTextAsync("Olga", 3);
var textShort2Task = t.CalcComplexTextAsync("Olga", 3);
var textShort3Task = t.CalcComplexTextAsync("Olga", 3);
var textShort4Task = t.CalcComplexTextAsync("Olga", 3);

Task.WaitAll(textShortTask, textShort2Task, textShort3Task, textShort4Task);

Console.WriteLine("Mark 4");
