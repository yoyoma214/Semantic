﻿namespace Antlr4.Runtime.Tree.Xpath
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Atn;
    using Antlr4.Runtime.Misc;
    using DFA = Antlr4.Runtime.Dfa.DFA;

    [System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
    [System.CLSCompliant(false)]
    public partial class XPathLexer : Lexer
    {
        public const int
            TokenRef = 1, RuleRef = 2, Anywhere = 3, Root = 4, Wildcard = 5, Bang = 6, ID = 7, String = 8;
        public static string[] modeNames = {
		"DEFAULT_MODE"
	};

        public static readonly string[] tokenNames = {
		"'\\u0000'", "'\\u0001'", "'\\u0002'", "'\\u0003'", "'\\u0004'", "'\\u0005'", 
		"'\\u0006'", "'\\u0007'", "'\b'"
	};
        public static readonly string[] ruleNames = {
		"Anywhere", "Root", "Wildcard", "Bang", "ID", "NameChar", "NameStartChar", 
		"String"
	};


        public XPathLexer(ICharStream input)
            : base(input)
        {
            _interp = new LexerATNSimulator(this, _ATN);
        }

        public override string GrammarFileName { get { return "XPathLexer.g4"; } }

        public override string[] TokenNames { get { return tokenNames; } }

        public override string[] RuleNames { get { return ruleNames; } }

        public override string[] ModeNames { get { return modeNames; } }

        public override string SerializedAtn { get { return _serializedATN; } }

        public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex)
        {
            switch (ruleIndex)
            {
                case 4: ID_action(_localctx, actionIndex); break;
            }
        }
        private void ID_action(RuleContext _localctx, int actionIndex)
        {
            switch (actionIndex)
            {
                case 0:
                    string text = Text;
                    if (char.IsUpper(text[0])) Type = TokenRef;
                    else Type = RuleRef;
                    break;
            }
        }

        public static readonly string _serializedATN =
            "\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\n\x34\b\x1\x4\x2" +
            "\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4" +
            "\t\t\t\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x5\x3\x5\x3\x6\x3" +
            "\x6\a\x6\x1F\n\x6\f\x6\xE\x6\"\v\x6\x3\x6\x3\x6\x3\a\x3\a\x5\a(\n\a\x3" +
            "\b\x3\b\x3\t\x3\t\a\t.\n\t\f\t\xE\t\x31\v\t\x3\t\x3\t\x3/\x2\x2\n\x3\x2" +
            "\x5\x5\x2\x6\a\x2\a\t\x2\b\v\x2\t\r\x2\x2\xF\x2\x2\x11\x2\n\x3\x2\x4\a" +
            "\x2\x32;\x61\x61\xB9\xB9\x302\x371\x2041\x2042\xF\x2\x43\\\x63|\xC2\xD8" +
            "\xDA\xF8\xFA\x301\x372\x37F\x381\x2001\x200E\x200F\x2072\x2191\x2C02\x2FF1" +
            "\x3003\xD801\xF902\xFDD1\xFDF2\xFFFF\x34\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2" +
            "\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\x11\x3\x2" +
            "\x2\x2\x3\x13\x3\x2\x2\x2\x5\x16\x3\x2\x2\x2\a\x18\x3\x2\x2\x2\t\x1A\x3" +
            "\x2\x2\x2\v\x1C\x3\x2\x2\x2\r\'\x3\x2\x2\x2\xF)\x3\x2\x2\x2\x11+\x3\x2" +
            "\x2\x2\x13\x14\a\x31\x2\x2\x14\x15\a\x31\x2\x2\x15\x4\x3\x2\x2\x2\x16" +
            "\x17\a\x31\x2\x2\x17\x6\x3\x2\x2\x2\x18\x19\a,\x2\x2\x19\b\x3\x2\x2\x2" +
            "\x1A\x1B\a#\x2\x2\x1B\n\x3\x2\x2\x2\x1C \x5\xF\b\x2\x1D\x1F\x5\r\a\x2" +
            "\x1E\x1D\x3\x2\x2\x2\x1F\"\x3\x2\x2\x2 \x1E\x3\x2\x2\x2 !\x3\x2\x2\x2" +
            "!#\x3\x2\x2\x2\" \x3\x2\x2\x2#$\b\x6\x2\x2$\f\x3\x2\x2\x2%(\x5\xF\b\x2" +
            "&(\t\x2\x2\x2\'%\x3\x2\x2\x2\'&\x3\x2\x2\x2(\xE\x3\x2\x2\x2)*\t\x3\x2" +
            "\x2*\x10\x3\x2\x2\x2+/\a)\x2\x2,.\v\x2\x2\x2-,\x3\x2\x2\x2.\x31\x3\x2" +
            "\x2\x2/\x30\x3\x2\x2\x2/-\x3\x2\x2\x2\x30\x32\x3\x2\x2\x2\x31/\x3\x2\x2" +
            "\x2\x32\x33\a)\x2\x2\x33\x12\x3\x2\x2\x2\x6\x2 \'/\x3\x3\x6\x2";
        public static readonly ATN _ATN =
            new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
    }
}
