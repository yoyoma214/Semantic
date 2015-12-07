using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Sparqls.Base;
using CodeHelper.Core.Parse.ParseResults.Sparqls.KeyWords;
using CodeHelper.Core.Parse.ParseResults.Sparqls.Functions;


namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class QLTypes
    {
        public Dictionary<String, BaseFunction> Funcations { get; set; }
        public Dictionary<String, BaseKeyWord> KeyWords { get; set; }

        private QLTypes()
        {
            this.Funcations = new Dictionary<string, BaseFunction>();
            this.KeyWords = new Dictionary<string, BaseKeyWord>();
            Init();
        }

        private static QLTypes instance = new QLTypes();

        public static QLTypes Instance()
        {
            return instance;
        }

        private void Init()
        {            
            #region 关键字            
            this.AddKeyWord(new As());
            this.AddKeyWord(new Asc());
            this.AddKeyWord(new Ask());
            this.AddKeyWord(new BaseN());
            this.AddKeyWord(new BindN());
            this.AddKeyWord(new By());
            this.AddKeyWord(new ClearN());
            this.AddKeyWord(new Construct());
            this.AddKeyWord(new CopyN());
            this.AddKeyWord(new CreateN());
            this.AddKeyWord(new Data());
            this.AddKeyWord(new Default());
            this.AddKeyWord(new Delete());
            this.AddKeyWord(new Desc());
            this.AddKeyWord(new Describe());
            this.AddKeyWord(new DropN());
            this.AddKeyWord(new Exists());
            this.AddKeyWord(new FilterN());
            this.AddKeyWord(new From());
            this.AddKeyWord(new Graph());
            this.AddKeyWord(new Group());
            this.AddKeyWord(new Having());
            this.AddKeyWord(new Insert());
            this.AddKeyWord(new Into());
            this.AddKeyWord(new Limit());
            this.AddKeyWord(new LoadN());
            this.AddKeyWord(new Minus());
            this.AddKeyWord(new MoveN());
            this.AddKeyWord(new Named());
            this.AddKeyWord(new Offset());
            this.AddKeyWord(new Optional());
            this.AddKeyWord(new Order());
            this.AddKeyWord(new PrefixN());
            this.AddKeyWord(new Reduced());
            this.AddKeyWord(new Select());
            this.AddKeyWord(new Service());
            this.AddKeyWord(new Silent());
            this.AddKeyWord(new To());
            this.AddKeyWord(new Undef());
            this.AddKeyWord(new Union());
            this.AddKeyWord(new Using());
            this.AddKeyWord(new Values());
            this.AddKeyWord(new Where());
            this.AddKeyWord(new With());
            #endregion

            #region 函数
            this.AddFunction(new Abs());
            this.AddFunction(new Bnode());
            this.AddFunction(new Bound());
            this.AddFunction(new Cell());
            this.AddFunction(new Coalesc());
            this.AddFunction(new Concat());
            this.AddFunction(new Contains());
            this.AddFunction(new DataType());
            this.AddFunction(new Day());
            this.AddFunction(new Encode_for_uri());
            this.AddFunction(new Floor());
            this.AddFunction(new Hours());
            this.AddFunction(new If());
            this.AddFunction(new IriN());
            this.AddFunction(new IsBlank());
            this.AddFunction(new IsIri());
            this.AddFunction(new IsLiteral());
            this.AddFunction(new IsNumber());
            this.AddFunction(new IsUri());
            this.AddFunction(new Lang());
            this.AddFunction(new Langmatches());
            this.AddFunction(new Lcase());
            this.AddFunction(new Md5());
            this.AddFunction(new Minutes());
            this.AddFunction(new Month());
            this.AddFunction(new Now());
            this.AddFunction(new Rand());
            this.AddFunction(new Regex());
            this.AddFunction(new Replace());
            this.AddFunction(new Round());
            this.AddFunction(new SameTerm());
            this.AddFunction(new Seconds());
            this.AddFunction(new Sha1());
            this.AddFunction(new Sha256());
            this.AddFunction(new Sha384());
            this.AddFunction(new Sha512());
            this.AddFunction(new Str());
            this.AddFunction(new StrAfter());
            this.AddFunction(new StrBefore());
            this.AddFunction(new StrDT());
            this.AddFunction(new StrEnds());
            this.AddFunction(new StrLang());
            this.AddFunction(new StrLen());
            this.AddFunction(new StrStarts());
            this.AddFunction(new StrUUID());
            this.AddFunction(new Substr());
            this.AddFunction(new Timezone());
            this.AddFunction(new Tz());
            this.AddFunction(new Ucase());
            this.AddFunction(new UriN());
            this.AddFunction(new UUID());
            this.AddFunction(new Year());            
            #endregion
        }

        private void AddKeyWord(BaseKeyWord keyWord)
        {
            this.KeyWords.Add(keyWord.Name, keyWord);
        }

        private void AddFunction(BaseFunction funcation)
        {
            this.Funcations.Add(funcation.Name, funcation);
        }

        public List<String> AllKeyWords()
        {
            var rslt = this.KeyWords.Keys.ToList();
            rslt.Sort();
            return rslt;
        }

        public List<String> AllFunctions()
        {
            var rslt = this.Funcations.Keys.ToList();
            rslt.Sort();
            return rslt;
        }
    }
}
