# Ever.y

Ever.y is a fluent API job scheduling engine for .NET.

## Examples

```c#
Ever.y().Second.Do(() => Console.WriteLine("Every second"));
Ever.y(2).Days.At(15, 00).Do(() => Console.WriteLine("Every 2 days at 15:00"));
Ever.y(3).rd(Fri.day).OfTheMonth.At(16, 30).Do(() => Console.WriteLine("Every 3rd Friday of the month at 16:30"));
```

```c#
class MyClass { public string MyProp { get; set; } }
//...
Action<Job<MyClass>> job = (j) => Console.WriteLine($"My job has metadata: {job.Metadata.MyProp}");
var metadata = new MyClass { MyProp = "Hello World!" };

Ever.y(Thurs.day).At(4, 00).Do(job, metadata); // Every Thursday at 04:00, do job
```
