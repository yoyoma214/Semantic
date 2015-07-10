using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace CodeHelper.Core.Parse.ParseResults.Antlrs
{
    class Antlr4Visitor : ANTLRv4ParserBaseVisitor<int>
    {
        StackUtil stack = new StackUtil();

        public GrammarSpec Root = new GrammarSpec();

        public override int VisitRuleSpec([NotNull] ANTLRv4Parser.RuleSpecContext context) {
            var ruleSpec = this.stack.PeekCtx<RuleSpec>();
            ruleSpec.Parse(context);

            var range = context.parserRuleSpec();
            if (range != null)
            {
                ruleSpec.ParserRuleSpec = new ParserRuleSpec();
                this.stack.Push(ruleSpec.ParserRuleSpec);
                this.Visit(range);
                this.stack.Pop();
            }

            var lexerRule = context.lexerRule();
            if (lexerRule != null)
            {
                ruleSpec.LexerRule = new LexerRule();
                this.stack.Push(ruleSpec.LexerRule);
                this.Visit(lexerRule);
                this.stack.Pop();
            }

            return 0;
        }
        
        public override int VisitAtom([NotNull] ANTLRv4Parser.AtomContext context) {
            var atom = this.stack.PeekCtx<Atom>();
            atom.Parse(context);

            var range = context.range();
            if (range != null)
            {
                atom.Range = new Range();
                this.stack.Push(atom.Range);
                this.Visit(range);
                this.stack.Pop();
            }

            var terminal = context.terminal();
            if (terminal != null)
            {
                atom.Terminal = new Terminal();
                this.stack.Push(atom.Terminal);
                this.Visit(terminal);
                this.stack.Pop();
            }

            var ruleref = context.ruleref();
            if (ruleref != null)
            {
                atom.Ruleref = new Ruleref();
                this.stack.Push(atom.Ruleref);
                this.Visit(ruleref);
                this.stack.Pop();
            }

            var notSet = context.notSet();
            if (range != null)
            {
                atom.NotSet = new NotSet();
                this.stack.Push(atom.NotSet);
                this.Visit(notSet);
                this.stack.Pop();
            }

            var elementOptions = context.elementOptions();
            if (elementOptions != null)
            {
                atom.ElementOptions = new ElementOptions();
                this.stack.Push(atom.ElementOptions);
                this.Visit(elementOptions);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitRuleBlock([NotNull] ANTLRv4Parser.RuleBlockContext context) {

            var ruleBlock = this.stack.PeekCtx<RuleBlock>();
            ruleBlock.Parse(context);

            var ruleAltList = context.ruleAltList();
            if (ruleAltList != null)
            {
                ruleBlock.RuleAltList = new RuleAltList();
                this.stack.Push(ruleBlock.RuleAltList);
                this.Visit(ruleAltList);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNotSet([NotNull] ANTLRv4Parser.NotSetContext context) {

            var notSet = this.stack.PeekCtx<NotSet>();
            notSet.Parse(context);

            var setElement = context.setElement();
            if (setElement != null)
            {
                notSet.SetElement = new SetElement();
                this.stack.Push(notSet.SetElement);
                this.Visit(setElement);
                this.stack.Pop();
            }

            var blockSet = context.blockSet();
            if (blockSet != null)
            {
                notSet.BlockSet = new BlockSet();
                this.stack.Push(notSet.BlockSet);
                this.Visit(blockSet);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitLexerCommands([NotNull] ANTLRv4Parser.LexerCommandsContext context)
        {
            return 0;
        }

        public override int VisitLexerAltList([NotNull] ANTLRv4Parser.LexerAltListContext context) {
            var lexerAltList = this.stack.PeekCtx<LexerAltList>();
            lexerAltList.Parse(context);

            var lexerAltCtxs = context.lexerAlt();
            foreach (var ctx in lexerAltCtxs)
            {
                var lexerAlt = new LexerAlt();
                lexerAltList.LexerAlts.Add(lexerAlt);
                this.stack.Push(lexerAlt);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitRuleModifier([NotNull] ANTLRv4Parser.RuleModifierContext context)
        {
            var ruleModifier = this.stack.PeekCtx<RuleModifier>();
            ruleModifier.Parse(context);

            ruleModifier.Text = context.GetText();

            return 0;

        }

        public override int VisitRuleAltList([NotNull] ANTLRv4Parser.RuleAltListContext context) {

            var ruleAltList = this.stack.PeekCtx<RuleAltList>();
            ruleAltList.Parse(context);

            var labeledAlts = context.labeledAlt();
            foreach (var ctx in labeledAlts)
            {
                var labeledAlt = new LabeledAlt();
                ruleAltList.LabeledAlts.Add(labeledAlt);
                this.stack.Push(labeledAlt);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitTerminal([NotNull] ANTLRv4Parser.TerminalContext context) {

            var terminal = this.stack.PeekCtx<Terminal>();
            terminal.Parse(context);

            if (context.TOKEN_REF() != null)
                terminal.TOKEN_REF = context.TOKEN_REF().GetText();

            if (context.STRING_LITERAL() != null)
                terminal.STRING_LITERAL = context.STRING_LITERAL().GetText();

            var elementOptions = context.elementOptions();
            if (elementOptions != null)
            {
                terminal.ElementOptions = new ElementOptions();
                this.stack.Push(terminal.ElementOptions);
                this.Visit(elementOptions);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLexerCommand([NotNull] ANTLRv4Parser.LexerCommandContext context)
        {
            return 0;
        }

        public override int VisitThrowsSpec([NotNull] ANTLRv4Parser.ThrowsSpecContext context)
        {
            return 0;
        }

        public override int VisitLocalsSpec([NotNull] ANTLRv4Parser.LocalsSpecContext context)
        {
            return 0;
        }

        public override int VisitAction([NotNull] ANTLRv4Parser.ActionContext context) {

            var action = this.stack.PeekCtx<Action>();
            action.Parse(context);          

            return 0;
        }

        public override int VisitModeSpec([NotNull] ANTLRv4Parser.ModeSpecContext context) {
            return 0;
        }

        public override int VisitOption([NotNull] ANTLRv4Parser.OptionContext context) {

            var option = this.stack.PeekCtx<Option>();
            option.Parse(context);

            var id = context.id();
            if (id != null)
            {
                option.Id = new Id();
                this.stack.Push(option.Id);
                this.Visit(id);
                this.stack.Pop();
            }

            var optionValueCtx = context.optionValue();
            if (optionValueCtx != null)
            {
                option.OptionValue = new OptionValue();
                this.stack.Push(option.OptionValue);
                this.Visit(optionValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitElement([NotNull] ANTLRv4Parser.ElementContext context) {

            var element = this.stack.PeekCtx<Element>();
            element.Parse(context);

            var labeledElement = context.labeledElement();
            if (labeledElement != null)
            {
                element.LabeledElement = new LabeledElement();
                this.stack.Push(element.LabeledElement);
                this.Visit(labeledElement);
                this.stack.Pop();
            }

            var ebnfSuffix = context.ebnfSuffix();
            if (ebnfSuffix != null)
            {
                element.EbnfSuffix = new EbnfSuffix();
                this.stack.Push(element.EbnfSuffix);
                this.Visit(ebnfSuffix);
                this.stack.Pop();
            }


            var atom = context.atom();
            if (atom != null)
            {
                element.Atom = new Atom();
                this.stack.Push(element.Atom);
                this.Visit(atom);
                this.stack.Pop();
            }

            var ebnf = context.ebnf();
            if (ebnf != null)
            {
                element.Ebnf = new Ebnf();
                this.stack.Push(element.Ebnf);
                this.Visit(ebnf);
                this.stack.Pop();
            }

            //if (context.ACTION() != null)
            //    element.ACTION = context.ACTION().GetText();

            //if (context.QUESTION() != null)
            //    element.QUESTION = context.QUESTION().GetText();

            return 0;
        }

        public override int VisitElementOptions([NotNull] ANTLRv4Parser.ElementOptionsContext context) {
            return 0;
        }

        public override int VisitLexerElement([NotNull] ANTLRv4Parser.LexerElementContext context) {
            var lexerElement = this.stack.PeekCtx<LexerElement>();
            lexerElement.Parse(context);

            var labeledLexerElementCtx = context.labeledLexerElement();
            if (labeledLexerElementCtx != null)
            {
                lexerElement.LabeledLexerElement = new LabeledLexerElement();
                this.stack.Push(lexerElement.LabeledLexerElement);
                this.Visit(labeledLexerElementCtx);
                this.stack.Pop();
            }

            var lexerAtomCtx = context.labeledLexerElement();
            if (lexerAtomCtx != null)
            {
                lexerElement.LabeledLexerElement = new LabeledLexerElement();
                this.stack.Push(lexerElement.LabeledLexerElement);
                this.Visit(lexerAtomCtx);
                this.stack.Pop();
            }

            var lexerBlockCtx = context.labeledLexerElement();
            if (lexerBlockCtx != null)
            {
                lexerElement.LexerBlock = new LexerBlock();
                this.stack.Push(lexerElement.LexerBlock);
                this.Visit(lexerBlockCtx);
                this.stack.Pop();
            }

            var ebnfSuffixCtx = context.ebnfSuffix();
            if (ebnfSuffixCtx != null)
            {
                lexerElement.EbnfSuffix = new EbnfSuffix();
                this.stack.Push(lexerElement.EbnfSuffix);
                this.Visit(ebnfSuffixCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitParserRuleSpec([NotNull] ANTLRv4Parser.ParserRuleSpecContext context) {
            
            var parserRuleSpec = this.stack.PeekCtx<ParserRuleSpec>();
            parserRuleSpec.Parse(context);

            parserRuleSpec.RULE_REF = context.RULE_REF().GetText();

            var ruleModifiers = context.ruleModifiers();
            if (ruleModifiers != null)
            {
                parserRuleSpec.RuleModifiers = new RuleModifiers();
                this.stack.Push(parserRuleSpec.RuleModifiers);
                this.Visit(ruleModifiers);
                this.stack.Pop();
            }

            var ruleReturns = context.ruleReturns();
            if (ruleReturns != null)
            {
                parserRuleSpec.RuleReturns = new RuleReturns();
                this.stack.Push(parserRuleSpec.RuleReturns);
                this.Visit(ruleReturns);
                this.stack.Pop();
            }

            var throwsSpec = context.throwsSpec();
            if (throwsSpec != null)
            {
                parserRuleSpec.ThrowsSpec = new ThrowsSpec();
                this.stack.Push(parserRuleSpec.ThrowsSpec);
                this.Visit(throwsSpec);
                this.stack.Pop();
            }

            var localsSpec = context.localsSpec();
            if (localsSpec != null)
            {
                parserRuleSpec.LocalsSpec = new LocalsSpec();
                this.stack.Push(parserRuleSpec.LocalsSpec);
                this.Visit(localsSpec);
                this.stack.Pop();
            }

            var rulePrequels = context.rulePrequel();
            foreach (var ctx in rulePrequels)
            {
                var rulePrequel = new RulePrequel();
                parserRuleSpec.RulePrequels.Add(rulePrequel);
                this.stack.Push(rulePrequel);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var ruleBlock = context.ruleBlock();
            if (ruleBlock != null)
            {
                parserRuleSpec.RuleBlock = new RuleBlock();
                this.stack.Push(parserRuleSpec.RuleBlock);
                this.Visit(ruleBlock);
                this.stack.Pop();
            }

            var exceptionGroup = context.exceptionGroup();
            if (exceptionGroup != null)
            {
                parserRuleSpec.ExceptionGroup = new ExceptionGroup();
                this.stack.Push(parserRuleSpec.ExceptionGroup);
                this.Visit(exceptionGroup);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAlternative([NotNull] ANTLRv4Parser.AlternativeContext context) {
            var alternative = this.stack.PeekCtx<Alternative>();
            alternative.Parse(context);

            var elementOptions = context.elementOptions();
            if (elementOptions != null)
            {
                alternative.ElementOptions = new ElementOptions();
                this.stack.Push(alternative.ElementOptions);
                this.Visit(elementOptions);
                this.stack.Pop();
            }

            var elements = context.element();
            foreach (var ctx in elements)
            {
                var element = new Element();
                alternative.Elements.Add(element);
                this.stack.Push(element);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGrammarType([NotNull] ANTLRv4Parser.GrammarTypeContext context) {
            var grammarType = this.stack.PeekCtx<GrammarType>();
            grammarType.Parse(context);

            grammarType.Text = context.GetText();
            return 0;
        }

        public override int VisitRuleAction([NotNull] ANTLRv4Parser.RuleActionContext context) {

            var ruleAction = this.stack.PeekCtx<RuleAction>();
            ruleAction.Parse(context);

            var id = context.id();
            if (id != null)
            {
                ruleAction.Id = new Id();
                this.stack.Push(ruleAction.Id);
                this.Visit(id);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEbnfSuffix([NotNull] ANTLRv4Parser.EbnfSuffixContext context) {
            var ebnfSuffix = this.stack.PeekCtx<EbnfSuffix>();
            ebnfSuffix.Parse(context);

            if (context.STAR() != null)
                ebnfSuffix.STAR = context.STAR().GetText();

            if (context.PLUS() != null)
                ebnfSuffix.PLUS = context.PLUS().GetText();

            foreach (var ctx in context.QUESTION())
            {
                ebnfSuffix.QUESTIONS.Add(ctx.GetText());
            }

            return 0;
        }

        public override int VisitRulePrequel([NotNull] ANTLRv4Parser.RulePrequelContext context) {

            var rulePrequel = this.stack.PeekCtx<RulePrequel>();
            rulePrequel.Parse(context);

            var optionsSpec = context.optionsSpec();
            if (optionsSpec != null)
            {
                rulePrequel.OptionsSpec = new OptionsSpec();
                this.stack.Push(rulePrequel.OptionsSpec);
                this.Visit(optionsSpec);
                this.stack.Pop();
            }

            var ruleAction = context.ruleAction();
            if (ruleAction != null)
            {
                rulePrequel.RuleAction = new RuleAction();
                this.stack.Push(rulePrequel.RuleAction);
                this.Visit(ruleAction);
                this.stack.Pop();
            }
            
            return 0;
        }

        public override int VisitExceptionGroup([NotNull] ANTLRv4Parser.ExceptionGroupContext context) {
            var exceptionGroup = this.stack.PeekCtx<ExceptionGroup>();
            exceptionGroup.Parse(context);

            var exceptionHandlers = context.exceptionHandler();
            foreach (var ctx in exceptionHandlers)
            {
                var exceptionHandler = new ExceptionHandler();
                exceptionGroup.ExceptionHandlers.Add(exceptionHandler);
                this.stack.Push(exceptionHandler);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var finallyClause = context.finallyClause();
            if (finallyClause != null)
            {
                exceptionGroup.FinallyClause = new FinallyClause();
                this.stack.Push(exceptionGroup.FinallyClause);
                this.Visit(finallyClause);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLexerBlock([NotNull] ANTLRv4Parser.LexerBlockContext context) {
            return 0;
        }

        public override int VisitSetElement([NotNull] ANTLRv4Parser.SetElementContext context) {
            var setElement = this.stack.PeekCtx<SetElement>();
            setElement.Parse(context);

            if (context.TOKEN_REF() != null)
                setElement.TOKEN_REF = context.TOKEN_REF().GetText();

            if (context.STRING_LITERAL() != null)
                setElement.STRING_LITERAL = context.STRING_LITERAL().GetText();

            if (context.LEXER_CHAR_SET() != null)
                setElement.LEXER_CHAR_SET = context.LEXER_CHAR_SET().GetText();

            var elementOptions = context.elementOptions();
            if (elementOptions != null)
            {
                setElement.ElementOptions = new ElementOptions();
                this.stack.Push(setElement.ElementOptions);
                this.Visit(elementOptions);
                this.stack.Pop();
            }

            var range = context.range();
            if (range != null)
            {
                setElement.Range = new Range();
                this.stack.Push(setElement.Range);
                this.Visit(range);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBlockSet([NotNull] ANTLRv4Parser.BlockSetContext context) {
            var blockSet = this.stack.PeekCtx<BlockSet>();
            blockSet.Parse(context);

            var setElements = context.setElement();
            foreach (var ctx in setElements)
            {
                var setElement = new SetElement();
                blockSet.SetElements.Add(setElement);
                this.stack.Push(setElement);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitActionScopeName([NotNull] ANTLRv4Parser.ActionScopeNameContext context) {
            return 0;
        }
        public override int VisitLabeledAlt([NotNull] ANTLRv4Parser.LabeledAltContext context) {
            var labeledAlt = this.stack.PeekCtx<LabeledAlt>();
            labeledAlt.Parse(context);

            var alternative = context.alternative();
            if (alternative != null)
            {
                labeledAlt.Alternative = new Alternative();
                this.stack.Push(labeledAlt.Alternative);
                this.Visit(alternative);
                this.stack.Pop();
            }

            var id = context.id();
            if (id != null)
            {
                labeledAlt.Id = new Id();
                this.stack.Push(id);
                this.Visit(id);
                this.stack.Pop();
            }
            return 0;

        }

        public override int VisitLexerAtom([NotNull] ANTLRv4Parser.LexerAtomContext context) {

            var lexerAtom = this.stack.PeekCtx<LexerAtom>();
            lexerAtom.Parse(context);

            var rangeCtx = context.range();
            if (rangeCtx != null)
            {
                var range = new Range();
                lexerAtom.Range = range;
                this.stack.Push(range);
                this.Visit(rangeCtx);
                this.stack.Pop();
            }

            var terminalCtx = context.terminal();
            if (terminalCtx != null)
            {
                var terminal = new Terminal();
                lexerAtom.Terminal = terminal;
                this.stack.Push(terminal);
                this.Visit(terminalCtx);
                this.stack.Pop();
            }

            var notSetCtx = context.terminal();
            if (notSetCtx != null)
            {
                var notSet = new NotSet();
                lexerAtom.NotSet = notSet;
                this.stack.Push(notSet);
                this.Visit(notSetCtx);
                this.stack.Pop();
            }

            var elementOptionsCtx = context.terminal();
            if (elementOptionsCtx != null)
            {
                var elementOptions = new ElementOptions();
                lexerAtom.ElementOptions = elementOptions;
                this.stack.Push(elementOptions);
                this.Visit(elementOptionsCtx);
                this.stack.Pop();
            }

            if (context.RULE_REF() != null)
                lexerAtom.RULE_REF = context.RULE_REF().ToString();
            if (context.LEXER_CHAR_SET() != null)
                lexerAtom.LEXER_CHAR_SET = context.LEXER_CHAR_SET().ToString();
            if (context.DOT() != null)
                lexerAtom.DOT = context.DOT().ToString();

            return 0;
        }

        public override int VisitLabeledElement([NotNull] ANTLRv4Parser.LabeledElementContext context) {

            var labeledElement = this.stack.PeekCtx<LabeledElement>();
            labeledElement.Parse(context);

            var idCtx = context.id();
            if (idCtx != null)
            {
                labeledElement.Id = new Id();
                this.stack.Push(labeledElement.Id);
                this.Visit(idCtx);
                this.stack.Pop();
            }

            var atomCtx = context.atom();
            if (atomCtx != null)
            {
                labeledElement.Atom= new Atom();
                this.stack.Push(labeledElement.Atom);
                this.Visit(atomCtx);
                this.stack.Pop();
            }

            var blockCtx = context.block();
            if (blockCtx != null)
            {
                labeledElement.Block = new Block();
                this.stack.Push(labeledElement.Block);
                this.Visit(blockCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLexerRuleBlock([NotNull] ANTLRv4Parser.LexerRuleBlockContext context) {
            var lexerRuleBlock = this.stack.PeekCtx<LexerRuleBlock>();
            lexerRuleBlock.Parse(context);

            var lexerAltListCtx = context.lexerAltList();
            if (lexerAltListCtx != null)
            {
                lexerRuleBlock.LexerAltList = new LexerAltList();
                this.stack.Push(lexerRuleBlock.LexerAltList);
                this.Visit(lexerAltListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitFinallyClause([NotNull] ANTLRv4Parser.FinallyClauseContext context) {
            return 0;
        }

        public override int VisitGrammarSpec([NotNull] ANTLRv4Parser.GrammarSpecContext context) {

            Root.Parse(context);
            this.stack.Push(Root);

            var grammarType = context.grammarType();
            if (grammarType != null)
            {
                Root.GrammarType = new GrammarType();
                this.stack.Push(Root.GrammarType);
                this.VisitGrammarType(grammarType);
                this.stack.Pop();
            }

            var id = context.id();
            if (id != null)
            {
                Root.Id = new Id();
                this.stack.Push(Root.Id);
                this.VisitId(id);
                this.stack.Pop();
            }

            var prequelConstructs = context.prequelConstruct();

            foreach (var ctx in prequelConstructs)
            {
                var prequelConstruct = new PrequelConstruct();
                Root.PrequelConstructs.Add(prequelConstruct);
                this.stack.Push(prequelConstruct);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var rules = context.rules();
            if (rules != null)
            {
                Root.Rules = new Rules();
                this.stack.Push(Root.Rules);
                this.Visit(rules);
                this.stack.Pop();
            }

            var modeSpecs = context.modeSpec();
            foreach (var ctx in modeSpecs)
            {
                var modeSpec = new ModeSpec();
                Root.ModeSpecs.Add(modeSpec);
                this.stack.Push(modeSpec);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDelegateGrammar([NotNull] ANTLRv4Parser.DelegateGrammarContext context) {

            var delegateGrammar = this.stack.PeekCtx<DelegateGrammar>();
            delegateGrammar.Parse(context);

            var ids = context.id();
            foreach (var ctx in ids)
            {
                var id = new Id();
                delegateGrammar.Ids.Add(id);
                this.stack.Push(id);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitLexerElements([NotNull] ANTLRv4Parser.LexerElementsContext context) {
            var lexerElements = this.stack.PeekCtx<LexerElements>();
            lexerElements.Parse(context);

            var ss = context.lexerElement();
            foreach (var ctx in ss)
            {
                var lexerElement = new LexerElement();
                lexerElements.LexerElements0.Add(lexerElement);
                this.stack.Push(lexerElement);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRange([NotNull] ANTLRv4Parser.RangeContext context) {

            var range = this.stack.PeekCtx<Range>();
            range.Parse(context);

            if (context.STRING_LITERAL() != null)
            {
                foreach (var ctx in context.STRING_LITERAL())
                {
                    range.STRING_LITERALS.Add(ctx.GetText());
                }
            }

            if (context.RANGE() != null)
                range.RANGE = context.RANGE().GetText();

            return 0;
        }

        public override int VisitLexerCommandName([NotNull] ANTLRv4Parser.LexerCommandNameContext context) {
            var lexerCommandName = this.stack.PeekCtx<LexerCommandName>();
            lexerCommandName.Parse(context);

            var idCtx = context.id();
            if (idCtx != null)
            {
                lexerCommandName.Id = new Id();
                this.stack.Push(lexerCommandName.Id);
                this.Visit(idCtx);
                this.stack.Pop();
            }

            if (context.MODE() != null)
                lexerCommandName.Mode = context.MODE().GetText();

            return 0;
        }

        public override int VisitBlock([NotNull] ANTLRv4Parser.BlockContext context) {
            
            var block = this.stack.PeekCtx<Block>();
            block.Parse(context);

            var optionsSpec = context.optionsSpec();
            if (optionsSpec != null)
            {
                block.OptionsSpec = new OptionsSpec();
                this.stack.Push(block.OptionsSpec);
                this.Visit(optionsSpec);
                this.stack.Pop();
            }

            var ruleActionCtxs = context.ruleAction();
            foreach (var ctx in ruleActionCtxs)
            {
                var ruleAction = new RuleAction();
                block.RuleActions.Add(ruleAction);
                this.stack.Push(ruleAction);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var altList = context.altList();
            if (altList != null)
            {
                block.AltList = new AltList();
                this.stack.Push(block.AltList);
                this.Visit(altList);
                this.stack.Pop();
            }


            return 0;

        }

        public override int VisitLexerRule([NotNull] ANTLRv4Parser.LexerRuleContext context) {
            var lexerRule = this.stack.PeekCtx<LexerRule>();
            lexerRule.Parse(context);

         
            var lexerRuleBlockCtx = context.lexerRuleBlock();
            if (lexerRuleBlockCtx != null)
            {
                lexerRule.LexerRuleBlock = new LexerRuleBlock();
                this.stack.Push(lexerRule.LexerRuleBlock);
                this.Visit(lexerRuleBlockCtx);
                this.stack.Pop();
            }

            lexerRule.Text = context.GetText();

            return 0;
        }

        public override int VisitLabeledLexerElement([NotNull] ANTLRv4Parser.LabeledLexerElementContext context) {
            var labeledLexerElement = this.stack.PeekCtx<LabeledLexerElement>();
            labeledLexerElement.Parse(context);


            var idCtx = context.id();
            if (idCtx != null)
            {
                labeledLexerElement.Id = new Id();
                this.stack.Push(labeledLexerElement.Id);
                this.Visit(idCtx);
                this.stack.Pop();
            }

            var lexerAtomCtx = context.id();
            if (lexerAtomCtx != null)
            {
                labeledLexerElement.LexerAtom = new LexerAtom();
                this.stack.Push(labeledLexerElement.LexerAtom);
                this.Visit(lexerAtomCtx);
                this.stack.Pop();
            }

            var blockCtx = context.block();
            if (blockCtx != null)
            {
                labeledLexerElement.Block = new Block();
                this.stack.Push(labeledLexerElement.Block);
                this.Visit(blockCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDelegateGrammars([NotNull] ANTLRv4Parser.DelegateGrammarsContext context) {

            var delegateGrammars = this.stack.PeekCtx<DelegateGrammars>();
            delegateGrammars.Parse(context);

            var delegateGrammarCtxs = context.delegateGrammar();
            foreach (var ctx in delegateGrammarCtxs)
            {
                var delegateGrammar = new DelegateGrammar();
                delegateGrammars.DelegateGrammars0.Add(delegateGrammar);
                this.stack.Push(delegateGrammar);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRuleref([NotNull] ANTLRv4Parser.RulerefContext context) {

            var ruleref = this.stack.PeekCtx<Ruleref>();
            ruleref.Parse(context);

            if (context.ARG_ACTION() != null)
                ruleref.ARG_ACTION = context.ARG_ACTION().GetText();

            if (context.RULE_REF() != null)
                ruleref.RULE_REF = context.RULE_REF().GetText();

            var elementOptions = context.elementOptions();
            if (elementOptions != null)
            {
                ruleref.ElementOptions = new ElementOptions();
                this.stack.Push(ruleref.ElementOptions);
                this.Visit(elementOptions);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBlockSuffix([NotNull] ANTLRv4Parser.BlockSuffixContext context) {
            var blockSuffix = this.stack.PeekCtx<BlockSuffix>();
            blockSuffix.Parse(context);

            var ebnfSuffix = context.ebnfSuffix();
            if (ebnfSuffix != null)
            {
                blockSuffix.EbnfSuffix = new EbnfSuffix();
                this.stack.Push(blockSuffix.EbnfSuffix);
                this.Visit(ebnfSuffix);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitId([NotNull] ANTLRv4Parser.IdContext context) {
            var id = this.stack.PeekCtx<Id>();
            id.Parse(context);

            if (context.RULE_REF() != null)
                id.RULE_REF = context.RULE_REF().GetText();

            if (context.TOKEN_REF() != null)
                id.TOKEN_REF = context.TOKEN_REF().GetText();

            return 0;
        }

        public override int VisitElementOption([NotNull] ANTLRv4Parser.ElementOptionContext context) {
            var elementOption = this.stack.PeekCtx<ElementOption>();
            elementOption.Parse(context);

            var ids = context.id();
            foreach (var ctx in ids)
            {
                var id = new Id();
                elementOption.Ids.Add(id);
                this.stack.Push(id);
                this.Visit(ctx);
                this.stack.Pop();
            }

            if (context.STRING_LITERAL() != null)
                elementOption.STRING_LITERAL = context.STRING_LITERAL().GetText();

            return 0;
        }

        public override int VisitExceptionHandler([NotNull] ANTLRv4Parser.ExceptionHandlerContext context) {
            var exceptionHandler = this.stack.PeekCtx<ExceptionHandler>();
            exceptionHandler.Parse(context);

            if (context.ARG_ACTION() != null)
                exceptionHandler.ARG_ACTION = context.ARG_ACTION().GetText();

            if (context.ACTION() != null)
                exceptionHandler.ACTION = context.ACTION().GetText();

            return 0;
        }

        public override int VisitTokensSpec([NotNull] ANTLRv4Parser.TokensSpecContext context)
        {
            var tokensSpec = this.stack.PeekCtx<TokensSpec>();
            tokensSpec.Parse(context);

            var ids = context.id();
            foreach (var ctx in ids)
            {
                var id = new Id();
                tokensSpec.Ids.Add(id);
                this.stack.Push(id);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRuleReturns([NotNull] ANTLRv4Parser.RuleReturnsContext context) {

            var ruleReturns = this.stack.PeekCtx<RuleReturns>();
            ruleReturns.Parse(context);

            if (context.ARG_ACTION() != null)
            {
                ruleReturns.ARG_ACTION = context.ARG_ACTION().GetText();
            }

            return 0;
        }

        public override int VisitOptionsSpec([NotNull] ANTLRv4Parser.OptionsSpecContext context) {
            
            var optionsSpec = this.stack.PeekCtx<OptionsSpec>();
            optionsSpec.Parse(context);

            var options = context.option();
            foreach (var ctx in options)
            {
                var option = new Option();
                optionsSpec.Options.Add(option);
                this.stack.Push(option);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitPrequelConstruct([NotNull] ANTLRv4Parser.PrequelConstructContext context) {

            var prequelConstruct = this.stack.PeekCtx<PrequelConstruct>();
            prequelConstruct.Parse(context);

            var optionsSpecCtx = context.optionsSpec();
            if (optionsSpecCtx != null)
            {
                var optionsSpec = new OptionsSpec();
                prequelConstruct.OptionsSpec = optionsSpec;
                this.stack.Push(optionsSpec);
                this.Visit(optionsSpecCtx);
                this.stack.Pop();
            }

            var delegateGrammarsCtx = context.delegateGrammars();
            if (delegateGrammarsCtx != null)
            {
                var delegateGrammars = new DelegateGrammars();
                prequelConstruct.DelegateGrammars = delegateGrammars;
                this.stack.Push(delegateGrammars);
                this.Visit(delegateGrammarsCtx);
                this.stack.Pop();
            }

            var tokensSpecCtx = context.tokensSpec();
            if (tokensSpecCtx != null)
            {
                var tokensSpec = new TokensSpec();
                prequelConstruct.TokensSpec = tokensSpec;
                this.stack.Push(tokensSpec);
                this.Visit(tokensSpecCtx);
                this.stack.Pop();
            }

            var actionCtx = context.action();
            if (actionCtx != null)
            {
                var action = new Action();
                prequelConstruct.Action = action;
                this.stack.Push(action);
                this.Visit(actionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAltList([NotNull] ANTLRv4Parser.AltListContext context) {
            var altList = this.stack.PeekCtx<AltList>();
            altList.Parse(context);

            var alternatives = context.alternative();
            foreach (var ctx in alternatives)
            {
                var alternative = new Alternative();
                altList.Alternatives.Add(alternative);
                this.stack.Push(alternative);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitRules([NotNull] ANTLRv4Parser.RulesContext context) {
            var rules = this.stack.PeekCtx<Rules>();
            rules.Parse(context);

            var ruleSpecs = context.ruleSpec();
            foreach (var ctx in ruleSpecs)
            {
                var ruleSpec = new RuleSpec();
                rules.RuleSpecs.Add(ruleSpec);
                this.stack.Push(ruleSpec);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitOptionValue([NotNull] ANTLRv4Parser.OptionValueContext context)
        {
            var optionValue = this.stack.PeekCtx<OptionValue>();
            optionValue.Parse(context);

            var ids = context.id();
            foreach (var ctx in ids)
            {
                var id = new Id();
                optionValue.Ids.Add(id);
                this.stack.Push(id);
                this.Visit(ctx);
                this.stack.Pop();
            }

            if (context.STRING_LITERAL() != null)
                optionValue.STRING_LITERAL = context.STRING_LITERAL().GetText();

            if (context.ACTION() != null)
                optionValue.ACTION = context.ACTION().GetText();

            if (context.INT() != null)
                optionValue.INT = context.INT().GetText();

            return 0;
        }

        public override int VisitLexerAlt([NotNull] ANTLRv4Parser.LexerAltContext context) {

            var lexerAlt = this.stack.PeekCtx<LexerAlt>();
            lexerAlt.Parse(context);

            var lexerElementsCtx = context.lexerElements();
            if (lexerElementsCtx != null)
            {
                lexerAlt.LexerElements = new LexerElements();
                this.stack.Push(lexerAlt.LexerElements);
                this.Visit(lexerElementsCtx);
                this.stack.Pop();
            }

            var lexerCommandsCtx = context.lexerCommands();
            if (lexerCommandsCtx != null)
            {
                lexerAlt.LexerCommands = new LexerCommands();
                this.stack.Push(lexerAlt.LexerCommands);
                this.Visit(lexerCommandsCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRuleModifiers([NotNull] ANTLRv4Parser.RuleModifiersContext context) {
            var ruleModifiers = this.stack.PeekCtx<RuleModifiers>();
            ruleModifiers.Parse(context);

            var ruleModifierCtxs = context.ruleModifier();
            foreach (var ctx in ruleModifierCtxs)
            {
                var ruleModifier = new RuleModifier();
                ruleModifiers.RuleModifiers0.Add(ruleModifier);
                this.stack.Push(ruleModifier);
                this.Visit(ctx);
                this.stack.Pop();
            }
            return 0;            
        }

        public override int VisitEbnf([NotNull] ANTLRv4Parser.EbnfContext context) {

            var ebnf = this.stack.PeekCtx<Ebnf>();
            ebnf.Parse(context);

            var block = context.block();
            if (block != null)
            {
                ebnf.Block = new Block();
                this.stack.Push(ebnf.Block);
                this.Visit(block);
                this.stack.Pop();
            }

            var blockSuffix = context.blockSuffix();
            if (blockSuffix != null)
            {
                ebnf.BlockSuffix = new BlockSuffix();
                this.stack.Push(ebnf.BlockSuffix);
                this.Visit(blockSuffix);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLexerCommandExpr([NotNull] ANTLRv4Parser.LexerCommandExprContext context) {

            var lexerCommandExpr = this.stack.PeekCtx<LexerCommandExpr>();
            lexerCommandExpr.Parse(context);

            var idCtx = context.id();
            if (idCtx != null)
            {
                lexerCommandExpr.Id = new Id();
                this.stack.Push(lexerCommandExpr.Id);
                this.Visit(idCtx);
                this.stack.Pop();
            }

            if (context.INT() != null)
                lexerCommandExpr.INT = context.INT().GetText();

            return 0;
        }
    }
}
