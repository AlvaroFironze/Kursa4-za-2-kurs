using ConfLog.Models;

namespace ConfLog
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.FType.Any())
                content.FType.AddRange(FTypes.Select(c => c.Value));

            if (!content.Usings.Any())
                content.Usings.AddRange(Usings.Select(c => c.Value));

            if (!content.Fields.Any())
                content.Fields.AddRange(Fields.Select(c => c.Value));

            if (!content.Constructors.Any()) {
                content.Constructors.AddRange(new Constructor
                {
                    name = "Basic",
                    link = @"
using System.Xml.Linq;",
                    field = @"
        String.Join('_', String.Join('_',DateTime.Now.ToString().Split('.')).Split(':'));
        string config = string.Join(""\\"", System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Take(System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Length - 3)) + ""\\"";",
                    code = @"
        /// <summary>
        /// Initializes a new instace of <see cref=""Logger""/> class
        /// </summary>
       public Logger()
        {
            if (System.IO.File.Exists(config +""configuration.config""))
            {
                var doc = XDocument.Load(config + ""configuration.config""); 
                /*Excel*/excelPath = doc.Root.Element(""excel"").Element(""add"").Attribute(""path"").Value;/*Excel*/
                /*Txt*/txtPath = doc.Root.Element(""txt"").Element(""add"").Attribute(""path"").Value;/*Txt*/
                /*Tcp*/ElasticAdress = doc.Root.Element(""tcp"").Element(""add"").Attribute(""path"").Value.Split(':')[0];/*Tcp*/
                /*Tcp*/ElasticPort = Convert.ToInt16(doc.Root.Element(""tcp"").Element(""add"").Attribute(""path"").Value.Split(':')[1]);/*Tcp*/
            } 
            else
            {
                var res = new XDocument(new XDeclaration(""1.0"", ""utf - 8"", ""no""));
                res.Add(new XElement(""configuration""/*Excel*/, new XElement(""excel"", new XElement(""add"", new XAttribute(""path"", config)))/*Excel*//*Txt*/, new XElement(""txt"", new XElement(""add"", new XAttribute(""path"", config))) /*Txt*//*Tcp*/,new XElement(""tcp"", new XElement(""add"", new XAttribute(""ip"", config))) /*Tcp*/));
                res.Save(config + ""configuration.config"");
                var doc = XDocument.Load(config + ""configuration.config"");
                /*Excel*/excelPath = doc.Root.Element(""excel"").Element(""add"").Attribute(""path"").Value;/*Excel*/
                /*Txt*/txtPath = doc.Root.Element(""txt"").Element(""add"").Attribute(""path"").Value;/*Txt*/
                /*Tcp*/ElasticAdress = doc.Root.Element(""tcp"").Element(""add"").Attribute(""path"").Value.Split(':')[0];/*Tcp*/
                /*Tcp*/ElasticPort = Convert.ToInt16(doc.Root.Element(""tcp"").Element(""add"").Attribute(""path"").Value.Split(':')[1]);/*Tcp*/
            }
        } 
                "


                });
            } 

            if (!content.Functions.Any()) {
                content.AddRange(new Function
                {
                    name = "FATAL",
                    desk = "Фатальная ошибка, дело совсем плохо",
                    level = 1,
                    isBase = true,
                    toUse = "Используйте .Fatal(object[]) чтобы логировать фатальные ошибки",
                    code = @"
        /// <summary> 
        /// Writes a log entry with level Fatal. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Fatal(params object[] massage) 
        { 
            GoLog(""FATAL"", ConsoleColor.Red, massage); 
        } ",
                    type = FTypes["Логирующая"]
                },
                    new Function
                    {
                        name = "ERROR",
                        desk = "Ошибка",
                        level = 2,
                        toUse = "Используйте .Error(object[]) чтобы логировать обработанные исключения",
                        isBase = false,
                        code = @"
        /// <summary> 
        /// Writes a log entry with level Error. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Error(params object[] massage) 
        { 
            GoLog(""ERROR"", ConsoleColor.Red, massage); 
        } ",
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "WARN",
                        desk = "Предупреждение, не фатально, но что-то не идеально",
                        level = 3,
                        isBase = false,
                        toUse= "Используйте .Warn(object[]) чтобы логировать предупреждения об ошибках",
                        code = @"
        /// <summary> 
        /// Writes a log entry with level Warn. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Warn(params object[] massage) 
            { 
                GoLog(""WARN"", ConsoleColor.Yellow, massage); 
            } ",
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "INFO",
                        desk = "Обычное сообщение",
                        level = 4,
                        isBase = false,
                        toUse = "Используйте .Info(object[]) чтобы логировать сообщения",
                        code = @"
        /// <summary> 
        /// Writes a log entry with level Info. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Info(params object[] massage) 
            { 
                GoLog(""INF0"", ConsoleColor.White, massage); 
            }",
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "DEBUG",
                        desk = "Дебаг-сообщение, для отладки",
                        level = 5,
                        isBase = false,
                        toUse = "Используйте .Debug(object[]) чтобы логировать поверхностную отладку",
                        code = @"
        /// <summary> 
        /// When <see cref=""DoDebug""/>= true, Writes a log entry with level Debug. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Debug(params object[] massage) 
            { 
                if (DoDebug) 
                { 
                    GoLog(""DEBUG"", ConsoleColor.Green, massage); 
                } 
            } ",
                        fields = new List<Field> { Fields["DoDebug"] },
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "TRACE",
                        desk = "Сообщение для более точной отладки",
                        level = 6,
                        isBase = false,
                        toUse = "Используйте .Trace(object[]) чтобы логировать глубокую отладку",
                        code = @"
        /// <summary> 
        /// When <see cref=""DoDebug""/>= true, Writes a log entry with level Trace. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void Trace(params object[] massage) 
            { 
                 if (DoDebug) 
                { 
                     GoLog(""TRACE"", ConsoleColor.Cyan, massage); 
                } 
            } ",
                        fields = new List<Field> { Fields["DoDebug"] },
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "ALL",
                        desk = "Все сообщения",
                        level = 7,
                        isBase = false,
                        toUse = "Используйте .All(object[]) чтобы логировать всю информацию",
                        code = @"
        /// <summary> 
        /// When <see cref=""DoDebug""/>= true, Writes a log entry with level All. 
        /// </summary> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        public void All(params object[] massage) 
        { 
            if (DoDebug) 
            { 
                GoLog(""All"", ConsoleColor.White, massage); 
            } 
        }",
                        fields = new List<Field> { Fields["DoDebug"] },
                        type = FTypes["Логирующая"]
                    },
                    new Function
                    {
                        name = "Console",
                        desk = "Ваши логи будут отображаться в консоли",
                        isBase = true,
                        code = @"
        /// <summary> 
        /// Writes a log entry from public methods to destination. 
        /// </summary> 
        /// <param name=""color"">Color for Console for logging-level.</param> 
        /// <param name=""level"">Name of log-level.</param> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        private void GoLog(string level, ConsoleColor color, params object[] massage) 
        { 
            DateTime date = DateTime.Now; 
            Console.Write(date.ToString() + "" ""); 
            Console.ForegroundColor = color; 
            Console.Write(level); 
            Console.ResetColor(); 
            if (massage != null) 
            { 
                foreach (var obj in massage) 
                { 
                    Console.Write("" "" + obj.ToString()); 
                } 
            } 
            Console.WriteLine(); 
            /*Excel*/ToExcel(date, level, massage);/*Excel*/ 
            /*Text*/ToText(date, level, massage);/*Text*/ 
            /*Tcp*/ToTcp(date, level, massage);/*Tcp*/
            /*Db*/ToLocalDb(date, level, massage);/*Db*/ 

        }",
                        img = "/img/console.jpg",
                        type = FTypes["Не Логирующая"]
                    },
                    new Function
                    {
                        name = "Text",
                        desk = "Логи будут сохраняться в текстовый файл",
                        isBase = false,
                        toUse = "Включите в Logstash сбор txt-файлов из вашей папки, чтобы собирать текстовые логи",
                        code = @"
        /// <summary> 
        /// Writes a log to Text file. 
        /// </summary> 
        /// <param name=""date"">Date, when a log was created.</param> 
        /// <param name=""level"">Name of log-level.</param> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        private void ToText(DateTime date, string level, params object[] massage) 
        { 
            System.IO.File.AppendAllText(txtPath + ""logs_"" + date1 + "".txt"", date.ToString() + "" "" + level); 
            if (massage != null) 
            { 
                foreach (var obj in massage) 
                { 
                    System.IO.File.AppendAllText(txtPath + ""logs_"" + date1 + "".txt"" , "" "" + obj.ToString()); 
                } 

            } 
            System.IO.File.AppendAllText(txtPath + ""logs_"" + date1 + "".txt"", ""\r\n ""); 
        }",
                        img = "/img/text.jpg",                        
                        fields = new List<Field> { Fields["txtPath"] },
                        type = FTypes["Не Логирующая"]
                    },
                    new Function
                    {
                        name = "Excel",
                        desk = "Ваши логи будут сохранены в Excel",
                        isBase = false,
                        toUse = "Включите в Logstash сбор Excel-файлов из вашей папки, чтобы собирать табличные логи",
                        code = @"
        /// <summary> 
        /// Writes a log to Excel file. 
        /// </summary> 
        /// <param name=""date"">Date, when a log was created.</param> 
        /// <param name=""level"">Name of log-level.</param> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        private void ToExcel(DateTime date, string level, params object[] massage)
        {
            if (System.IO.File.Exists(excelPath + ""logs_"" + date1 + "".xlsx"" ))
            {
                using (var workbook = new XLWorkbook(excelPath + ""logs_"" + date1 + "".xlsx""))
                {
                    var ws = workbook.Worksheet(1);
                    ws.Cell(ws.LastRowUsed().RowNumber() + 1, 1).Value = date.ToString();
                    ws.Cell(ws.LastRowUsed().RowNumber(), 2).Value = level;
                    int i = 3;
                    foreach (object obj in massage)
                    {
                        ws.Cell(ws.LastRowUsed().RowNumber(), i).Value = obj.ToString();
                        i++;
                    }
                    workbook.Save();
                }
            }
            else
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add(""Logs_"" + date1);
                    ws.Cell(1, 1).Value = date.ToString();
                    ws.Cell(1, 2).Value = level;
                    int i = 3;
                    foreach (object obj in massage)
                    {
                        ws.Cell(1, i).Value = obj.ToString();
                        i++;
                    }
                            workbook.SaveAs(excelPath + ""logs_"" + date1 + "".xlsx"");
                }
            }
        }",
                        img = "/img/excel.png",
                        usings = new List<Using> { Usings["ClosedXML"], Usings["Data"] },
                        fields = new List<Field> { Fields["excelPath"] },
                        type = FTypes["Не Логирующая"]
                    },
                     new Function
                     {
                         name = "Tcp",
                         desk = "Отправим логи боссу в Elastic",
                         isBase = false,
                         toUse = "Включите в Logstash сбор tcp логов из socket, чтобы получать лог-сообщения напрямую",
                         code = @"
        /// <summary> 
        /// Writes a log entry from public methods to destination. 
        /// </summary> 
        /// <param name=""color"">Color for Console for logging-level.</param> 
        /// <param name=""level"">Name of log-level.</param> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        private void ToTcp(DateTime date, string level, params object[] massage)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string message = date.ToString() + separator + level;
            if (massage != null)
            {
                foreach (var obj in massage)
                {
                    message += separator + obj.ToString();
                }
            }
            socket.Connect(ElasticAdress, ElasticPort);
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);
            socket.Close();
        }",
                         img = "/img/elk.png",
                         usings = new List<Using> { Usings["Socket"], Usings["Text"] },
                         fields = new List<Field> { Fields["ElasticAdress"], Fields["ElasticPort"], Fields["separator"] },
                         type = FTypes["Не Логирующая"]
                     },
                    new Function
                    {
                        name = "Database",
                        desk = "Логи будут сохранены в локальную базу данных",
                        isBase = false,
                        toUse = "Включите в Logstash сбор логов из локальной базы данных",
                        code = @"
        /// <summary> 
        /// Writes a log to LoacalDB. 
        /// </summary> 
        /// <param name=""date"">Date, when a log was created.</param> 
        /// <param name=""level"">Name of log-level.</param> 
        /// <param name=""massage"">The initial content of the log. Must contain .ToString().</param> 
        private void ToLocalDb(DateTime date, string level, params object[] massage) 
        { 
            using (LogContext db = new LogContext()) 
            { 
                var progr = db.Progs.Where(p => p.name == ProgName).FirstOrDefault(); 
                if (progr == default) 
                { 
                    progr = new Prog { name = ProgName }; 
                    db.Progs.Add(progr); 
                    db.SaveChanges(); 
                } 
                var log = new Log { date = date, level = level, ProgId=progr }; 
                db.Logs.Add(log); 
                db.SaveChanges(); 
                if (massage != null) 
                { 
                    foreach (var obj in massage) 
                    { 
                        db.Massages.Add(new Massage { massage=obj.ToString(), LogId=log}); 
                    } 
                    db.SaveChanges(); 
                } 
            } 
        } 
    } 
    internal class Log 
    { 
        public virtual Prog ProgId { get; set; } 
        public int Id { get; set; } 
        public DateTime date { get; set; } 
        public string level { get; set; } 
        public List<Massage>? massages { get; set; } 
    } 
    internal class Massage 
    { 
        public int Id { get; set; } 
        public string massage { get; set; } 
        public virtual Log LogId { get; set; } 
    } 
    internal class Prog 
    { 
        public int Id { get; set; } 
        public string name { get; set; } 
        public List<Log>? logs { get; set; } 
    } 
    internal class LogContext : DbContext 
    { 
        public LogContext() : base(""Logs"") 

        { 
        } 
        public DbSet<Prog> Progs { get; set; } 
        public DbSet<Log> Logs { get; set; } 
        public DbSet<Massage> Massages { get; set; } 
    ",
                        img = "/img/db.png",
                        usings = new List<Using> { Usings["EntityFramework"] },
                        fields = new List<Field> { Fields["ProgName"] },
                        type = FTypes["Не Логирующая"]
                    }
                   

                    // new Function
                    // {
                    //     name = "Test",
                    //     desk = "Лttttt",
                    //     isBase = false,
                    //     code = "{i am Console}",
                    //     img = "/img/console.jpg",
                    //     type = FTypes["Не Логирующая"]
                    // }
                );
                    

                
            }
            content.SaveChanges();
        }
        

        private static Dictionary<string, FType> fType;
        public static Dictionary<string,FType> FTypes
        {
            get
            {
                if(fType == null)
                {
                    var list = new FType[]
                    {

                    new FType { functionType = "Логирующая" },
                    new FType { functionType = "Не Логирующая" }
                    };
                    fType = new Dictionary<string, FType>();
                    foreach(FType el in list)
                    {
                        fType.Add(el.functionType, el);
                    }
                    
                }
                return fType;
            }
        }
        private static Dictionary<string, Using> Uusings;
        public static Dictionary<string, Using> Usings
        {
            get
            {
                if (Uusings == null)
                {
                    var list = new Using[]
                    {

                    new Using { name="EntityFramework", code=@"
using System.Data.Entity;" },
                    new Using { name="ClosedXML", code=@"
using ClosedXML.Excel;" },
                    new Using { name="Data", code=@"
using System.Data;" },
                    new Using { name="Socket", code=@"
using System.Net.Sockets;" },
                    new Using { name="Text", code=@"
using System.Text;" }
                    };
                    Uusings = new Dictionary<string, Using>();
                    foreach (Using el in list)
                    {
                        Uusings.Add(el.name, el);
                    }

                }
                return Uusings;
            }
        }
        private static Dictionary<string, Field> fields;
        public static Dictionary<string, Field> Fields
        {
            get
            {
                if (fields == null)
                {
                    var list = new Field[]
                    {

                    new Field { name="DoDebug", code=@"
        /// <summary>
        /// Gets or sets permission for log-levels less or equal Debug. Default = false.
        /// </summary>
        /// <returns>if it is allowed to write low-level logs </returns>
        public bool DoDebug { get; set; } = false;" },
                    new Field { name="ProgName", code=@"
        private string ProgName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;"},
                    new Field { name = "excelPath", code = @"
        string excelPath;" },                    
                    new Field { name = "txtPath", code = @"
        string txtPath;" },
                    new Field { name = "ElasticAdress", code = @"
        string ElasticAdress;"},
                    new Field { name = "ElasticPort", code = @"
        int ElasticPort;"},
                    new Field { name = "separator", code = @"
        string separator = "","";"}
                    };
                fields = new Dictionary<string, Field>();
                    foreach (Field el in list)
                    {
                        fields.Add(el.name, el);
                    }

                }
                return fields;
            }
        }
    }
}
