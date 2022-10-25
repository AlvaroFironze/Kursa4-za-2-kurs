
using System.Xml.Linq;
namespace Logging
{
    public class Logger
    {
        String.Join('_', String.Join('_',DateTime.Now.ToString().Split('.')).Split(':'));
        string config = string.Join("\\", System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Take(System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Length - 3)) + "\\"; 
        /// <summary>
        /// Gets or sets permission for log-levels less or equal Debug. Default = false.
        /// </summary>
        /// <returns>if it is allowed to write low-level logs </returns>
        public bool DoDebug { get; set; } = false; 
        string txtPath;
        /// <summary>
        /// Initializes a new instace of <see cref="Logger"/> class
        /// </summary>
       public Logger()
        {
            if (System.IO.File.Exists(config +"configuration.config"))
            {
                var doc = XDocument.Load(config + "configuration.config"); 
                
                /*Txt*/txtPath = doc.Root.Element("txt").Element("add").Attribute("path").Value;/*Txt*/
                
                
            } 
            else
            {
                var res = new XDocument(new XDeclaration("1.0", "utf - 8", "no"));
                res.Add(new XElement("configuration"/*Txt*/, new XElement("txt", new XElement("add", new XAttribute("path", config))) /*Txt*/));
                res.Save(config + "configuration.config");
                var doc = XDocument.Load(config + "configuration.config");
                
                /*Txt*/txtPath = doc.Root.Element("txt").Element("add").Attribute("path").Value;/*Txt*/
                
                
            }
        } 
                
        /// <summary> 
        /// Writes a log entry with level Fatal. 
        /// </summary> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        public void Fatal(params object[] massage) 
        { 
            GoLog("FATAL", ConsoleColor.Red, massage); 
        }  
        /// <summary> 
        /// Writes a log entry with level Error. 
        /// </summary> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        public void Error(params object[] massage) 
        { 
            GoLog("ERROR", ConsoleColor.Red, massage); 
        }  
        /// <summary> 
        /// Writes a log entry with level Warn. 
        /// </summary> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        public void Warn(params object[] massage) 
            { 
                GoLog("WARN", ConsoleColor.Yellow, massage); 
            }  
        /// <summary> 
        /// Writes a log entry with level Info. 
        /// </summary> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        public void Info(params object[] massage) 
            { 
                GoLog("INF0", ConsoleColor.White, massage); 
            } 
        /// <summary> 
        /// When <see cref="DoDebug"/>= true, Writes a log entry with level All. 
        /// </summary> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        public void All(params object[] massage) 
        { 
            if (DoDebug) 
            { 
                GoLog("All", ConsoleColor.White, massage); 
            } 
        } 
        /// <summary> 
        /// Writes a log entry from public methods to destination. 
        /// </summary> 
        /// <param name="color">Color for Console for logging-level.</param> 
        /// <param name="level">Name of log-level.</param> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        private void GoLog(string level, ConsoleColor color, params object[] massage) 
        { 
            DateTime date = DateTime.Now; 
            Console.Write(date.ToString() + " "); 
            Console.ForegroundColor = color; 
            Console.Write(level); 
            Console.ResetColor(); 
            if (massage != null) 
            { 
                foreach (var obj in massage) 
                { 
                    Console.Write(" " + obj.ToString()); 
                } 
            } 
            Console.WriteLine(); 
             
            /*Text*/ToText(date, level, massage);/*Text*/ 
            
             

        } 
        /// <summary> 
        /// Writes a log to Text file. 
        /// </summary> 
        /// <param name="date">Date, when a log was created.</param> 
        /// <param name="level">Name of log-level.</param> 
        /// <param name="massage">The initial content of the log. Must contain .ToString().</param> 
        private void ToText(DateTime date, string level, params object[] massage) 
        { 
            System.IO.File.AppendAllText(txtPath + "logs_" + date1 + ".txt", date.ToString() + " " + level); 
            if (massage != null) 
            { 
                foreach (var obj in massage) 
                { 
                    System.IO.File.AppendAllText(txtPath + "logs_" + date1 + ".txt" , " " + obj.ToString()); 
                } 

            } 
            System.IO.File.AppendAllText(txtPath + "logs_" + date1 + ".txt", "\r\n "); 
        }
    }
}