using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LumenWorks.Framework.IO.Csv;
using CsvHelper;
//我的第二次更改
namespace MyCsv
{
  public class Foo
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var records = new List<Foo>
      {
          new Foo { Id = 1, Name = "one" },
          new Foo { Id = 2, Name = "two" },
      };
      using (var writer = new StreamWriter("E:\\data.csv"))
      using (var csv = new CsvWriter(writer))
      {
        csv.WriteRecords(records);
      }

      using (var reader = new StreamReader("E:\\data.csv"))
      using (var csv = new CsvReader(reader))
      {
        var record2 = csv.GetRecords<Foo>();
        foreach (var v in record2)
        {
          Console.WriteLine(v.Id+"\t"+v.Name);
        }
      }
      
      Console.ReadKey();
      
    }
  }

}
