# Ever.y

Ever.y is a fluent API job scheduling engine for .NET.

## Examples

```c#
Action job = () => Console.WriteLine("Hello world!");

Ever.y().Second.Do(job); // Every second, do 'job'
Ever.y(2).Days.At(15, 00).Do(job); // Every 2 days at 15:00, do 'job'
```

```c#
class MyClass { public string MyProp { get; set; } }
//...
Action<Job<MyClass>> job = (job) => Console.WriteLine($"My job has metadata: {job.Metadata.MyProp}");
var metadata = new MyClass { MyProp = "Hello World!" };

Ever.y(DayOfWeek.Thursday).At(4, 00).Do(job, metadata);
```
