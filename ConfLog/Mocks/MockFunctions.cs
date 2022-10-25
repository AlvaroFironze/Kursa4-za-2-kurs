using ConfLog.Interfaces;
using ConfLog.Models;

namespace ConfLog.Mocks
{
    public class MockFunctions : IAllFuncs
    {
        private readonly IFuncType _funcType = new MockFType();
        public IEnumerable<Function> Funcs
        {
            get
            {
                return new List<Function>
                {
                    new Function {
                        name="FATAL",
                        desk="Фатальная ошибка, дело совсем плохо",
                        level=1,
                        isBase=true,
                        code="{i am Fatal}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="ERROR",
                        desk="Ошибка",
                        level=2,
                        isBase=false,
                        code="{i am Error}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="WARN",
                        desk="Предупреждение, не фатально, но что-то не идеально",
                        level=3,
                        isBase=false,
                        code="{i am Warn}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="INFO",
                        desk="Обычное сообщение",
                        level=4,
                        isBase=false,
                        code="{i am Info}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="DEBUG",
                        desk="Дебаг-сообщение, для отладки",
                        level=5,
                        isBase=false,
                        code="{i am Debug}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="TRACE",
                        desk="Сообщение для более точной отладки",
                        level=6,
                        isBase=false,
                        code="{i am trace}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="ALL",
                        desk="Все сообщения",
                        level=7,
                        isBase=false,
                        code="{i am trace}",
                        type=_funcType.AllTypes.First()
                    },
                    new Function {
                        name="Console",
                        desk="Ваши логи будут отображаться в консоли",
                        isBase=true,
                        code="{i am Console}",
                        img="/img/console.jpg",
                        type=_funcType.AllTypes.Last()
                    },
                    new Function {
                        name="Text",
                        desk="Логи будут сохраняться в текстовый файл",
                        isBase=false,
                        code="{i am Console}",
                        img="/img/text.jpg",
                        type=_funcType.AllTypes.Last()
                    },
                    new Function {
                        name="Excel",
                        desk="Ваши логи будут сохранены в Excel",
                        isBase=false,
                        code="{i am Console}",
                        img="/img/excel.png",
                        type=_funcType.AllTypes.Last()
                    },
                    new Function {
                        name="Database",
                        desk="Логи будут сохранены в локальную базу данных",
                        isBase=false,
                        code="{i am Console}",
                        img="/img/db.png",
                        type=_funcType.AllTypes.Last()
                    }

                };
            }
           
        }
        public IEnumerable<Function> getBaseLogFuncs => Funcs.Where(p => p.isBase & p.level != default);
        public IEnumerable<Function> getNonBaseLogFuncs => Funcs.Where(p => !p.isBase & p.level != default);
        public IEnumerable<Function> getBaseFuncs => Funcs.Where(p => p.isBase & p.level == default);
        public IEnumerable<Function> getNonBaseFuncs => Funcs.Where(p => !p.isBase & p.level == default);
        public Function getObjectFunc(int funcId)
        {
            throw new NotImplementedException();
        }
    }
}
