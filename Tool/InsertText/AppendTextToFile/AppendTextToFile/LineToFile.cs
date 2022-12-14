using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppendTextToFile
{
    public static class LineToFile
    {
        public static void AddLine()
        {
            try
            {
                // Set a variable to the My Documents path.
                string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // from file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories)

                var file = @"TestApp.csproj";

                var text = @"abc";

                var lines = File.ReadLines(file).ToList();


                foreach (var f in lines)
                {
                    if(lines.Contains(text))
                    {
                        return;
                    }
                }

                int index = 0;

                var compareString = "</ItemGroup>";

                for (int i = 0; i < lines.Count; i++)
                {
                    
                    if (lines[i].Contains(compareString))
                        index = i + 1;
                }

                var insertText = @"  <ItemGroup>
    <PackageReference Include=""com.github.akovac35.Logging.Testing"" Version=""*"" />
  </ItemGroup>";

                if (index != 0)
                {
                    lines.Insert(index, insertText);
                    // File.Delete(file);
                    File.WriteAllLines(file, lines);
                }

                Console.WriteLine($"{lines.Count().ToString()} lines found.");
            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }
        }
    }
    
}
