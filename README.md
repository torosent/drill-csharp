# drill-csharp

C# client for Apache Drill

## How to use

```csharp
    var bit = new DrillBit(address);
    var query = new Query(bit);
    var result = query.Execute("select * from dfs.`/tmp/donuts.json` where name= \u0027Cake\u0027").Result;
    foreach (dynamic row in result.Rows)
    {
        var id = row.id.ToString();
    } 
```

