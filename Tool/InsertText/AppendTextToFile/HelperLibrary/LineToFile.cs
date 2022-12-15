using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppendTextToFile
{
    public static class LineToFile
    {
        public static void UpdateText(List<string> projects)
        {
            foreach(string project in projects)
            {
                AddLine(project);
            }
        }

        public static void AddLine(string file)
        {
            try
            {


                var packageCodeAnalysisMetrics = @"Microsoft.CodeAnalysis.Metrics";

                var lines = File.ReadLines(file).ToList();

                // if package is already added just ignore it

                foreach (var f in lines)
                {
                    if(lines.Contains(packageCodeAnalysisMetrics))
                    {
                        return;
                    }
                }
                
                // find the Item Group end line number
                int lineNumberEndofItemGroup = 0;

                var compareString = "</ItemGroup>";

                for (int i = 0; i < lines.Count; i++)
                {
                    
                    if (lines[i].Contains(compareString))
                        lineNumberEndofItemGroup = i + 1;
                }

                var insertText = @"  <ItemGroup>
    <PackageReference Include=""Microsoft.CodeAnalysis.Metrics"" Version=""*"" />
  </ItemGroup>";

                if (lineNumberEndofItemGroup != 0)
                {
                    lines.Insert(lineNumberEndofItemGroup, insertText);
                    // File.Delete(file);
                    File.WriteAllLines(file, lines);
                }

              //  Console.WriteLine($"{lines.Count().ToString()} lines found.");
            }
            catch (UnauthorizedAccessException uAEx)
            {
                MessageBox.Show(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                MessageBox.Show(pathEx.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
