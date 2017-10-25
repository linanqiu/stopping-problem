using System.IO;
using System.Linq;
using System.Text;

namespace StoppingProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = "dump.csv";
            var rowCount = 400;
            var columnCount = 20;
            
            var stoppingProblem = new StoppingProblem(9, 99, 0, 1, -1.5, 1.5);
            var output = string.Join("\n",
                from i in Enumerable.Range(0, rowCount)
                let row = string.Join(",",
                    from j in Enumerable.Range(0, columnCount)
                    let rowIndex = rowCount - i
                    let columnIndex = columnCount - j
                    let value = stoppingProblem.GetCost(columnIndex, rowIndex)
                    select value
                )
                select row);
            
            File.WriteAllText(path, output);
        }
    }
}