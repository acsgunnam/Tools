using System.IO;
using System.Windows;

namespace HelperLibrary
{
    public class SolutionsProjects
    {
        public const string projectStart = "Project(\"{";
        public static List<string> GetProjectsFromSolutions(string solutionFileAndPath)
        {
            List<string> result = new List<string>();

            solutionFileAndPath = solutionFileAndPath.Trim().Trim('"');

            if (string.IsNullOrWhiteSpace(solutionFileAndPath))
            {
                return result;
            }

            try
            {



                string solutionPath = Path.GetDirectoryName(solutionFileAndPath);

                var lines = File.ReadAllLines(solutionFileAndPath).ToList();
                foreach (var line in lines)
                {
                    try
                    {

                        if (line.Contains(projectStart))
                        {
                            string[] lineSplit = line.Split(',');
                            string projectPath = lineSplit[1];

                            projectPath = projectPath.Trim().Trim('"');

                            projectPath = projectPath = Path.Combine(solutionPath, projectPath);

                            result.Add(projectPath);
                        }


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            return result;
        }
    }
}
