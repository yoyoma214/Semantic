﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.Antlrs
{
    public class RuleInfo
    {
        public string Rule { get; set; }

        public string ENBF { get; set; }

        public bool IsList { get; set; }

        //public List<Or> Ors { get; set; }
    }

    //public class And
    //{
    //    public List<RuleInfo> RuleInfos { get; set; }
    //}

    //public class Or
    //{
    //    public List<And> Ands { get; set; }
    //}

    public class GrammarSpec : TokenPair
    {
        public GrammarType GrammarType { get; set; }
        public Id Id { get; set; }
        public List<PrequelConstruct> PrequelConstructs { get; set; }
        public Rules Rules { get; set; }
        public List<ModeSpec> ModeSpecs { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }

        public static String GrammarName { get; set; }

        public GrammarSpec()
        {
            this.ModeSpecs = new List<ModeSpec>();
            this.PrequelConstructs = new List<PrequelConstruct>();
            this.Errors = new List<ParseErrorInfo>();
            
        }

        public void Parse()
        {
            GrammarName = this.Id.TOKEN_REF;

            Rules.Parse();
        }

        public void Wise()
        {
            Rules.Wise();
        }

        public void GenJava(IndentStringBuilder builder)
        {
            //foreach (var rule in this.Rules)
            //{
            //    rule.g
            //}
            Rules.GenJava(builder);
        }

        public void GenVisitJava(IndentStringBuilder builder)
        {
            //foreach (var rule in this.Rules)
            //{
            //    rule.g
            //}
            builder.AppendFormatLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace CodeHelper.Core.Parse.ParseResults.{0}s",GenHelper.GetClassName(this.Id.TOKEN_REF));
            builder.IncreaseIndentLine("{");            
            builder.AppendFormatLine("class {0}Visitor : {0}BaseVisitor<int>",GenHelper.GetClassName(this.Id.TOKEN_REF));
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("StackUtil stack = new StackUtil();");
            Rules.GenVisitJava(builder);
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }
    }

    public class GrammarType : TokenPair
    {
        public string Text { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class PrequelConstruct : TokenPair
    {
        public OptionsSpec OptionsSpec { get; set; }
        public DelegateGrammars DelegateGrammars { get; set; }
        public TokensSpec TokensSpec { get; set; }
        public Action Action { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class OptionsSpec : TokenPair
    {
        public List<Option> Options { get; set; }

        public OptionsSpec()
        {
            this.Options = new List<Option>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Option : TokenPair
    {
        public Id Id { get; set; }
        public OptionValue OptionValue { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class OptionValue : TokenPair
    {
        public string STRING_LITERAL { get; set; }
        public string ACTION { get; set; }
        public string INT { get; set; }

        public List<Id> Ids { get; set; }
        public OptionValue()
        {
            this.Ids = new List<Id>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class DelegateGrammars : TokenPair
    {
        public List<DelegateGrammar> DelegateGrammars0 { get; set; }
        public DelegateGrammars()
        {
            this.DelegateGrammars0 = new List<DelegateGrammar>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class DelegateGrammar : TokenPair
    {
        public List<Id> Ids { get; set; }
        public DelegateGrammar()
        {
            this.Ids = new List<Id>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class TokensSpec : TokenPair
    {
        public List<Id> Ids { get; set; }
        public TokensSpec()
        {
            this.Ids = new List<Id>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Action : TokenPair
    {
        public ActionScopeName ActionScopeName { get; set; }
        public Id Id
        {
            get;
            set;
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ActionScopeName : TokenPair
    {
        public Id Id { get; set; }
        public string LEXER { get; set; }
        public string PARSER { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ModeSpec : TokenPair
    {
        public Id Id { get; set; }
        public List<LexerRule> LexerRules { get; set; }

        public ModeSpec()
        {
            this.LexerRules = new List<LexerRule>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Rules : TokenPair
    {
        public List<RuleSpec> RuleSpecs { get; set; }

        public Rules()
        {
            this.RuleSpecs = new List<RuleSpec>();
        }

        public void Parse()
        {
            foreach (var rule in this.RuleSpecs)
            {
                rule.Parse();
            }
        }

        public void Wise()
        {
            foreach (var rule in this.RuleSpecs)
            {
                rule.Wise();
            }
        }

        public void GenJava(IndentStringBuilder builder)
        {
            foreach (var rule in this.RuleSpecs)
            {
                rule.GenJava(builder);
            }
        }

        public void GenVisitJava(IndentStringBuilder builder)
        {
            foreach (var rule in this.RuleSpecs)
            {
                rule.GenVisitJava(builder);
            }
        }
    }

    public class RuleSpec : TokenPair
    {
        public ParserRuleSpec ParserRuleSpec { get; set; }
        public LexerRule LexerRule { get; set; }

        public void Parse()
        {
            if (ParserRuleSpec != null)
                ParserRuleSpec.Parse();
        }

        public void Wise()
        {
            if (ParserRuleSpec != null)
                ParserRuleSpec.Wise();
        }

        public void GenJava(IndentStringBuilder builder)
        {
            this.ParserRuleSpec.GenJava(builder);
        }

        public void GenVisitJava(IndentStringBuilder builder)
        {
            if (ParserRuleSpec != null)
                this.ParserRuleSpec.GenVisitJava(builder);
        }
    }

    public class ParserRuleSpec : TokenPair
    {
        public string RULE_REF { get; set; }
        public RuleModifiers RuleModifiers { get; set; }
        public RuleReturns RuleReturns { get; set; }
        public ThrowsSpec ThrowsSpec { get; set; }
        public LocalsSpec LocalsSpec { get; set; }
        public List<RulePrequel> RulePrequels { get; set; }
        public RuleBlock RuleBlock { get; set; }
        public ExceptionGroup ExceptionGroup { get; set; }

        public List<RuleInfo> RuleInfos { get; set; }

        public ParserRuleSpec()
        {
            this.RuleInfos = new List<RuleInfo>();
        }

        public void Parse()
        {
            this.RuleBlock.Parse(this.RuleInfos);
        }

        public void Wise()
        {
            for(var i = 0 ; i < RuleInfos.Count ; i ++)
            {
                if (RuleInfos[i].ENBF != null && "*+".Contains(RuleInfos[i].ENBF))
                    RuleInfos[i].IsList = true;

                for (var j = i + 1; j < RuleInfos.Count; j++)
                {
                    if (RuleInfos[i].Rule == RuleInfos[j].Rule)
                    {
                        if (RuleInfos[j].ENBF != null && "*+".Contains(RuleInfos[j].ENBF))
                        {
                            RuleInfos[i].IsList = true;
                            RuleInfos.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            RuleInfos[i].IsList = true;
                            RuleInfos.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
        }

        public void GenJava(IndentStringBuilder builder)
        {
            //RuleBlock.GenJava(builder);

            builder.AppendFormatLine("public class {0} : TokenPair", GenHelper.GetClassName(this.RULE_REF));
            builder.IncreaseIndentLine("{");
            foreach (var rule in this.RuleInfos)
            {
                if (rule.IsList)
                {
                    builder.AppendFormatLine("public List<{0}> {0}s", rule.Rule);
                    builder.AppendLine("{get;set;}");
                }
                else
                {
                    builder.AppendFormatLine("public {0} {0}", GenHelper.GetClassName(rule.Rule));
                    builder.AppendLine("{get;set;}");
                }
            }
            builder.Decrease("}");
            builder.AppendLine();
            builder.AppendLine();
        }

        public void GenVisitJava(IndentStringBuilder builder)
        {
            //this.ParserRuleSpec.GenVisitJava(builder);          
            var ruleVar = GenHelper.GetVarName(this.RULE_REF);
            var ruleClazz =  GenHelper.GetClassName(this.RULE_REF);
            builder.AppendFormatLine("public override int Visit{0}([NotNull] {1}Parser.{0}Context context)",
                ruleClazz , GenHelper.GetClassName(GrammarSpec.GrammarName));
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("var {0} = this.stack.PeekCtx<{1}>();", ruleVar, ruleClazz);
            builder.AppendFormatLine("{0}.Parse(context);", GenHelper.GetVarName(this.RULE_REF));
            builder.AppendLine();

            foreach (var rule in this.RuleInfos)
            {
                var subRuleVar = GenHelper.GetVarName(rule.Rule);
                var subRuleClazz = GenHelper.GetClassName(rule.Rule);

                if (rule.IsList)
                {
                    builder.AppendFormatLine("var {0}Ctxs = context.{0}();", subRuleVar);
                    builder.AppendFormatLine("foreach(var ctx in {0}Ctxs)", subRuleVar);
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormatLine("var {0} = new {1}();",subRuleVar, subRuleClazz);
                    builder.AppendFormatLine("{0}.{1}s.Add({2});", ruleVar,subRuleClazz, subRuleVar);
                    builder.AppendFormatLine("this.stack.Push({0});", subRuleVar);
                    builder.AppendFormatLine("this.Visit(ctx);", subRuleVar);
                    builder.AppendFormatLine("this.stack.Pop();");
                    builder.Decrease("}");
                }
                else
                {
                    builder.AppendFormatLine("var {0}Ctx = context.{0}();", subRuleVar);
                    builder.AppendFormatLine("if ({0}Ctx != null)", subRuleVar);
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormatLine("{0}.{1} = new {1}();", ruleVar, subRuleClazz);
                    builder.AppendFormatLine("this.stack.Push({0}.{1});", ruleVar, subRuleClazz);
                    builder.AppendFormatLine("this.Visit({0}Ctx);", subRuleVar);
                    builder.AppendFormatLine("this.stack.Pop();");
                    builder.Decrease("}");
                }
                builder.AppendLine();
                builder.AppendLine();
            }
            builder.AppendLine("return 0;");
            builder.Decrease("}");
            builder.AppendLine();
            builder.AppendLine();
        }
    }

    public class ExceptionGroup : TokenPair
    {
        public List<ExceptionHandler> ExceptionHandlers { get; set; }
        public FinallyClause FinallyClause { get; set; }

        public ExceptionGroup()
        {
            this.ExceptionHandlers = new List<ExceptionHandler>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ExceptionHandler : TokenPair
    {
        public string ARG_ACTION { get; set; }
        public string ACTION { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class FinallyClause : TokenPair
    {
        public string ACTION { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RulePrequel : TokenPair
    {
        public OptionsSpec OptionsSpec { get; set; }
        public RuleAction RuleAction { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RuleReturns : TokenPair
    {
        public string ARG_ACTION { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ThrowsSpec : TokenPair
    {
        public List<Id> Ids { get; set; }
        public ThrowsSpec()
        {
            this.Ids = new List<Id>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class LocalsSpec : TokenPair
    {
        public string Text { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RuleAction : TokenPair
    {
        public Id Id { get; set; }
        public string ACTION { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RuleModifiers : TokenPair
    {
        public List<RuleModifier> RuleModifiers0 { get; set; }
        public RuleModifiers()
        {
            this.RuleModifiers0 = new List<RuleModifier>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RuleModifier : TokenPair
    {
        public string Text { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {

        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class RuleBlock : TokenPair
    {
        public RuleAltList RuleAltList { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            this.RuleAltList.Parse(ruleInfos);
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {
            this.RuleAltList.GenJava(builder);
        }
    }

    public class RuleAltList : TokenPair
    {
        public List<LabeledAlt> LabeledAlts { get; set; }

        public RuleAltList()
        {
            this.LabeledAlts = new List<LabeledAlt>();
        }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            foreach (var alt in this.LabeledAlts)
            {
                alt.Parse(ruleInfos);
            }
        }

        public void Wise()
        {

        }

        public void GenJava(IndentStringBuilder builder)
        {
            foreach (var alt in this.LabeledAlts)
            {
                alt.GenJava(builder);
            }
        }
    }


    public class LabeledAlt : TokenPair
    {
        public Alternative Alternative { get; set; }
        public Id Id { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            this.Alternative.Parse(ruleInfos);
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {
            this.Alternative.GenJava(builder);
        }
    }

    public class LexerRule : TokenPair
    {
        public LexerRuleBlock LexerRuleBlock { get; set; }

        public string Text { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class LexerRuleBlock : TokenPair
    {
        public LexerAltList LexerAltList { get; set; }
    }

    public class LexerAltList : TokenPair
    {
        public List<LexerAlt> LexerAlts { get; set; }

        public LexerAltList()
        {
            this.LexerAlts = new List<LexerAlt>();
        }

    }

    public class LexerAlt : TokenPair
    {
        public LexerElements LexerElements { get; set; }
        public LexerCommands LexerCommands { get; set; }
    }


    public class LexerElements : TokenPair
    {
        public List<LexerElement> LexerElements0 { get; set; }

        public LexerElements()
        {
            this.LexerElements0 = new List<LexerElement>();
        }
    }

    public class LexerElement : TokenPair
    {
        public LabeledLexerElement LabeledLexerElement { get; set; }
        public LexerAtom LexerAtom { get; set; }
        public LexerBlock LexerBlock { get; set; }

        public EbnfSuffix EbnfSuffix { get; set; }

    }

    public class LabeledLexerElement : TokenPair
    {
        public Id Id { get; set; }

        public LexerAtom LexerAtom { get; set; }

        public Block Block { get; set; }

    }


    public class LexerBlock : TokenPair
    {
        public LexerAltList LexerAltList { get; set; }
    }

    public class LexerCommands : TokenPair
    {
        public List<LexerCommand> LexerCommands0 { get; set; }
        
        public LexerCommands()
        {
            this.LexerCommands0 = new List<LexerCommand>();
        }
    }

    public class LexerCommand : TokenPair
    {
        public LexerCommandName LexerCommandName { get; set; }
        public LexerCommandExpr LexerCommandExpr { get; set; }
    }

    public class LexerCommandName : TokenPair
    {
        public Id Id { get; set; }
        public string Mode { get; set; }
    }

    public class LexerCommandExpr : TokenPair
    {
        public Id Id { get; set; }
        public string INT { get; set; }
    }

    public class AltList : TokenPair
    {
        public List<Alternative> Alternatives { get; set; }

        public AltList()
        {
            this.Alternatives = new List<Alternative>();
        }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            foreach (var alt in this.Alternatives)
                alt.Parse(ruleInfos);
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }


    public class Alternative : TokenPair
    {
        public ElementOptions ElementOptions { get; set; }

        public List<Element> Elements { get; set; }

        public Alternative()
        {
            this.Elements = new List<Element>();
        }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            foreach (var element in this.Elements)
            {
                element.Parse(ruleInfos);
            }
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {
            foreach (var element in this.Elements)
            {
                element.GenJava(builder);
            }
        }
    }

    public class Element : TokenPair
    {
        public LabeledElement LabeledElement { get; set; }
        public Atom Atom { get; set; }
        public EbnfSuffix EbnfSuffix { get; set; }

        public Ebnf Ebnf { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            if (Ebnf != null)
            {
                this.Ebnf.Parse(ruleInfos);
            }
            if (LabeledElement != null)
            {
                LabeledElement.Parse(ruleInfos);
            }
            if (Atom != null)
            {
                Atom.Parse(ruleInfos);
            }
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class LabeledElement : TokenPair
    {
        public Id Id { get; set; }

        public string ASSIGN { get; set; }
        public string PLUS_ASSIGN { get; set; }
        public Atom Atom { get; set; }
        public Block Block { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            if (Atom != null)
                Atom.Parse(ruleInfos);
            if (Block != null)
                Block.Parse(ruleInfos);
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }


    public class Ebnf : TokenPair
    {
        public Block Block { get; set; }
        public BlockSuffix BlockSuffix { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            if (Block != null)
            {
                var rules = new List<RuleInfo>();

                Block.Parse(rules);

                foreach (var rule in rules)
                {
                    if (BlockSuffix != null)
                        rule.ENBF = BlockSuffix.GeEbnf();
                }

                ruleInfos.AddRange(rules);
            }

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
    public class BlockSuffix : TokenPair
    {
        public EbnfSuffix EbnfSuffix { get; set; }

        public string GeEbnf()
        {
            return EbnfSuffix.STAR + EbnfSuffix.PLUS + string.Join("", EbnfSuffix.QUESTIONS);
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class EbnfSuffix : TokenPair
    {
        public List<string> QUESTIONS { get; set; }
        public string STAR { get; set; }
        public string PLUS { get; set; }

        public EbnfSuffix()
        {
            this.QUESTIONS = new List<string>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }


    public class LexerAtom : TokenPair
    {
        public Range Range { get; set; }
        public Terminal Terminal { get; set; }
        public NotSet NotSet { get; set; }

        public string RULE_REF { get; set; }
        public string LEXER_CHAR_SET { get; set; }

        public string DOT { get; set; }
        public ElementOptions ElementOptions { get; set; }
        //public string Text { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {

        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Atom : TokenPair
    {
        public Range Range { get; set; }
        public Terminal Terminal { get; set; }

        //public string RULE_REF { get; set; }
        public Ruleref Ruleref { get; set; }
        public NotSet NotSet { get; set; }
        //public string LEXER_CHAR_SET { get; set; }

        //public string DOT { get; set; }
        public ElementOptions ElementOptions { get; set; }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            if (Ruleref != null)
            {
                var ruleInfo = new RuleInfo();
                ruleInfo.Rule = this.Ruleref.RULE_REF;
                ruleInfo.ENBF = "1";
                ruleInfos.Add(ruleInfo);
            }
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }


    public class NotSet : TokenPair
    {
        public SetElement SetElement { get; set; }
        public BlockSet BlockSet { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
    public class BlockSet : TokenPair
    {
        public List<SetElement> SetElements { get; set; }
        public List<string> ORS { get; set; }

        public BlockSet()
        {
            this.SetElements = new List<SetElement>();
            this.ORS = new List<string>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
    public class SetElement : TokenPair
    {
        public string TOKEN_REF { get; set; }
        public ElementOptions ElementOptions { get; set; }
        public string STRING_LITERAL { get; set; }
        public Range Range { get; set; }
        public string LEXER_CHAR_SET { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
    public class Block : TokenPair
    {
        public OptionsSpec OptionsSpec { get; set; }
        public List<RuleAction> RuleActions { get; set; }
        public AltList AltList { get; set; }

        public Block()
        {
            this.RuleActions = new List<RuleAction>();
        }

        public void Parse(List<RuleInfo> ruleInfos)
        {
            if (AltList != null)
                AltList.Parse(ruleInfos);
            
        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
    public class Ruleref : TokenPair
    {
        public string RULE_REF { get; set; }
        public string ARG_ACTION { get; set; }
        public ElementOptions ElementOptions { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Range : TokenPair
    {
        public List<string> STRING_LITERALS { get; set; }
        public string RANGE { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Terminal : TokenPair
    {
        public string TOKEN_REF { get; set; }
        public string STRING_LITERAL { get; set; }
        public ElementOptions ElementOptions { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ElementOptions : TokenPair
    {
        public List<ElementOption> ElementOptions0 { get; set; }
        public ElementOptions()
        {
            this.ElementOptions0 = new List<ElementOption>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class ElementOption : TokenPair
    {
        public List<Id> Ids { get; set; }
        public string STRING_LITERAL { get; set; }

        public ElementOption()
        {
            this.Ids = new List<Id>();
        }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }

    public class Id : TokenPair
    {
        public string RULE_REF { get; set; }
        public string TOKEN_REF { get; set; }

        public void Parse()
        {

        }

        public void Wise()
        {
        }

        public void GenJava(IndentStringBuilder builder)
        {

        }
    }
}
