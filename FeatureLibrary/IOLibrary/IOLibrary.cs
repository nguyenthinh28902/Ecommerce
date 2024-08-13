using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureLibrary.IOLibrary
{
    public class IOLibrary
    {
        public static string LoadTemplate(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
