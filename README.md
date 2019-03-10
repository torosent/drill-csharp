# drill-csharp

C# client for Apache Drill

## How to use

Dynamic response:

```csharp
    var bit = new DrillBit(address);
    var query = new Query<QueryResponse>(bit);
    var result =await query.Execute("select * from dfs.`/tmp/donuts.json` where name= \u0027Cake\u0027");
    foreach (dynamic row in result.Rows)
    {
        var id = row.id.ToString();
    } 
```

Structured response:

```csharp
    var bit = new DrillBit(address);
    var query = new Query<QueryFileResponse>(bit);
    var result = await query.Execute("show files in dfs.`/tmp`");
    foreach (var row in result.Rows)
    {
        var name = row.Name;
    } 
```
