﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    class SparqlVisitor : SparqlBaseVisitor<int>
    {
        StackUtil stack = new StackUtil();
        public override int VisitQueryUnit([NotNull] SparqlParser.QueryUnitContext context)
        {
            var queryUnit = this.stack.PeekCtx<QueryUnit>();
            queryUnit.Parse(context);

            var queryCtx = context.query();
            if (queryCtx != null)
            {
                queryUnit.Query = new Query();
                this.stack.Push(queryUnit.Query);
                this.Visit(queryCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitQuery([NotNull] SparqlParser.QueryContext context)
        {
            var query = this.stack.PeekCtx<Query>();
            query.Parse(context);

            var prologueCtx = context.prologue();
            if (prologueCtx != null)
            {
                query.Prologue = new Prologue();
                this.stack.Push(query.Prologue);
                this.Visit(prologueCtx);
                this.stack.Pop();
            }

            var selectQueryCtx = context.selectQuery();
            if (selectQueryCtx != null)
            {
                query.SelectQuery = new SelectQuery();
                this.stack.Push(query.SelectQuery);
                this.Visit(selectQueryCtx);
                this.stack.Pop();
            }

            var constructQueryCtx = context.constructQuery();
            if (constructQueryCtx != null)
            {
                query.ConstructQuery = new ConstructQuery();
                this.stack.Push(query.ConstructQuery);
                this.Visit(constructQueryCtx);
                this.stack.Pop();
            }

            var describeQueryCtx = context.describeQuery();
            if (describeQueryCtx != null)
            {
                query.DescribeQuery = new DescribeQuery();
                this.stack.Push(query.DescribeQuery);
                this.Visit(describeQueryCtx);
                this.stack.Pop();
            }

            var askQueryCtx = context.askQuery();
            if (askQueryCtx != null)
            {
                query.AskQuery = new AskQuery();
                this.stack.Push(query.AskQuery);
                this.Visit(askQueryCtx);
                this.stack.Pop();
            }

            var valuesClauseCtx = context.valuesClause();
            if (valuesClauseCtx != null)
            {
                query.ValuesClause = new ValuesClause();
                this.stack.Push(query.ValuesClause);
                this.Visit(valuesClauseCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitUpdateUnit([NotNull] SparqlParser.UpdateUnitContext context)
        {
            var updateUnit = this.stack.PeekCtx<UpdateUnit>();
            updateUnit.Parse(context);

            var updateCtx = context.update();
            if (updateCtx != null)
            {
                updateUnit.Update = new Update();
                this.stack.Push(updateUnit.Update);
                this.Visit(updateCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPrologue([NotNull] SparqlParser.PrologueContext context)
        {
            var prologue = this.stack.PeekCtx<Prologue>();
            prologue.Parse(context);

            var baseDeclCtxs = context.baseDecl();
            foreach (var ctx in baseDeclCtxs)
            {
                var baseDecl = new BaseDecl();
                prologue.BaseDecls.Add(baseDecl);
                this.stack.Push(baseDecl);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var prefixDeclCtxs = context.prefixDecl();
            foreach (var ctx in prefixDeclCtxs)
            {
                var prefixDecl = new PrefixDecl();
                prologue.PrefixDecls.Add(prefixDecl);
                this.stack.Push(prefixDecl);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBaseDecl([NotNull] SparqlParser.BaseDeclContext context)
        {
            var baseDecl = this.stack.PeekCtx<BaseDecl>();
            baseDecl.Parse(context);

            return 0;
        }

        public override int VisitPrefixDecl([NotNull] SparqlParser.PrefixDeclContext context)
        {
            var prefixDecl = this.stack.PeekCtx<PrefixDecl>();
            prefixDecl.Parse(context);

            return 0;
        }

        public override int VisitSelectQuery([NotNull] SparqlParser.SelectQueryContext context)
        {
            var selectQuery = this.stack.PeekCtx<SelectQuery>();
            selectQuery.Parse(context);

            var selectClauseCtx = context.selectClause();
            if (selectClauseCtx != null)
            {
                selectQuery.SelectClause = new SelectClause();
                this.stack.Push(selectQuery.SelectClause);
                this.Visit(selectClauseCtx);
                this.stack.Pop();
            }

            var datasetClauseCtx = context.datasetClause();
            if (datasetClauseCtx != null)
            {
                selectQuery.DatasetClause = new DatasetClause();
                this.stack.Push(selectQuery.DatasetClause);
                this.Visit(datasetClauseCtx);
                this.stack.Pop();
            }

            var whereClauseCtx = context.whereClause();
            if (whereClauseCtx != null)
            {
                selectQuery.WhereClause = new WhereClause();
                this.stack.Push(selectQuery.WhereClause);
                this.Visit(whereClauseCtx);
                this.stack.Pop();
            }

            var solutionModifierCtx = context.solutionModifier();
            if (solutionModifierCtx != null)
            {
                selectQuery.SolutionModifier = new SolutionModifier();
                this.stack.Push(selectQuery.SolutionModifier);
                this.Visit(solutionModifierCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubSelect([NotNull] SparqlParser.SubSelectContext context)
        {
            var subSelect = this.stack.PeekCtx<SubSelect>();
            subSelect.Parse(context);

            var selectClauseCtx = context.selectClause();
            if (selectClauseCtx != null)
            {
                subSelect.SelectClause = new SelectClause();
                this.stack.Push(subSelect.SelectClause);
                this.Visit(selectClauseCtx);
                this.stack.Pop();
            }

            var whereClauseCtx = context.whereClause();
            if (whereClauseCtx != null)
            {
                subSelect.WhereClause = new WhereClause();
                this.stack.Push(subSelect.WhereClause);
                this.Visit(whereClauseCtx);
                this.stack.Pop();
            }

            var solutionModifierCtx = context.solutionModifier();
            if (solutionModifierCtx != null)
            {
                subSelect.SolutionModifier = new SolutionModifier();
                this.stack.Push(subSelect.SolutionModifier);
                this.Visit(solutionModifierCtx);
                this.stack.Pop();
            }

            var valuesClauseCtx = context.valuesClause();
            if (valuesClauseCtx != null)
            {
                subSelect.ValuesClause = new ValuesClause();
                this.stack.Push(subSelect.ValuesClause);
                this.Visit(valuesClauseCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSelectClause([NotNull] SparqlParser.SelectClauseContext context)
        {
            var selectClause = this.stack.PeekCtx<SelectClause>();
            selectClause.Parse(context);

            var varCtxs = context.var();
            foreach (var ctx in varCtxs)
            {
                var var = new Var();
                selectClause.Vars.Add(var);
                this.stack.Push(var);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                selectClause.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConstructQuery([NotNull] SparqlParser.ConstructQueryContext context)
        {
            var constructQuery = this.stack.PeekCtx<ConstructQuery>();
            constructQuery.Parse(context);

            var constructTemplateCtx = context.constructTemplate();
            if (constructTemplateCtx != null)
            {
                constructQuery.ConstructTemplate = new ConstructTemplate();
                this.stack.Push(constructQuery.ConstructTemplate);
                this.Visit(constructTemplateCtx);
                this.stack.Pop();
            }

            var datasetClauseCtxs = context.datasetClause();
            foreach (var ctx in datasetClauseCtxs)
            {
                var datasetClause = new DatasetClause();
                constructQuery.DatasetClauses.Add(datasetClause);
                this.stack.Push(datasetClause);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var whereClauseCtx = context.whereClause();
            if (whereClauseCtx != null)
            {
                constructQuery.WhereClause = new WhereClause();
                this.stack.Push(constructQuery.WhereClause);
                this.Visit(whereClauseCtx);
                this.stack.Pop();
            }

            var solutionModifierCtxs = context.solutionModifier();
            foreach (var ctx in solutionModifierCtxs)
            {
                var solutionModifier = new SolutionModifier();
                constructQuery.SolutionModifiers.Add(solutionModifier);
                this.stack.Push(solutionModifier);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var triplesTemplateCtx = context.triplesTemplate();
            if (triplesTemplateCtx != null)
            {
                constructQuery.TriplesTemplate = new TriplesTemplate();
                this.stack.Push(constructQuery.TriplesTemplate);
                this.Visit(triplesTemplateCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDescribeQuery([NotNull] SparqlParser.DescribeQueryContext context)
        {
            var describeQuery = this.stack.PeekCtx<DescribeQuery>();
            describeQuery.Parse(context);

            var varOrIriCtx = context.varOrIri();
            if (varOrIriCtx != null)
            {
                describeQuery.VarOrIris.VarOrIri = new VarOrIri();
                this.stack.Push(describeQuery.VarOrIri);
                this.Visit(varOrIriCtx);
                this.stack.Pop();
            }

            var datasetClauseCtx = context.datasetClause();
            if (datasetClauseCtx != null)
            {
                describeQuery.DatasetClause = new DatasetClause();
                this.stack.Push(describeQuery.DatasetClause);
                this.Visit(datasetClauseCtx);
                this.stack.Pop();
            }

            var whereClauseCtx = context.whereClause();
            if (whereClauseCtx != null)
            {
                describeQuery.WhereClause = new WhereClause();
                this.stack.Push(describeQuery.WhereClause);
                this.Visit(whereClauseCtx);
                this.stack.Pop();
            }

            var solutionModifierCtx = context.solutionModifier();
            if (solutionModifierCtx != null)
            {
                describeQuery.SolutionModifier = new SolutionModifier();
                this.stack.Push(describeQuery.SolutionModifier);
                this.Visit(solutionModifierCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAskQuery([NotNull] SparqlParser.AskQueryContext context)
        {
            var askQuery = this.stack.PeekCtx<AskQuery>();
            askQuery.Parse(context);

            var datasetClauseCtx = context.datasetClause();
            if (datasetClauseCtx != null)
            {
                askQuery.DatasetClause = new DatasetClause();
                this.stack.Push(askQuery.DatasetClause);
                this.Visit(datasetClauseCtx);
                this.stack.Pop();
            }

            var whereClauseCtx = context.whereClause();
            if (whereClauseCtx != null)
            {
                askQuery.WhereClause = new WhereClause();
                this.stack.Push(askQuery.WhereClause);
                this.Visit(whereClauseCtx);
                this.stack.Pop();
            }

            var solutionModifierCtx = context.solutionModifier();
            if (solutionModifierCtx != null)
            {
                askQuery.SolutionModifier = new SolutionModifier();
                this.stack.Push(askQuery.SolutionModifier);
                this.Visit(solutionModifierCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDatasetClause([NotNull] SparqlParser.DatasetClauseContext context)
        {
            var datasetClause = this.stack.PeekCtx<DatasetClause>();
            datasetClause.Parse(context);

            var defaultGraphClauseCtx = context.defaultGraphClause();
            if (defaultGraphClauseCtx != null)
            {
                datasetClause.DefaultGraphClause = new DefaultGraphClause();
                this.stack.Push(datasetClause.DefaultGraphClause);
                this.Visit(defaultGraphClauseCtx);
                this.stack.Pop();
            }

            var namedGraphClauseCtx = context.namedGraphClause();
            if (namedGraphClauseCtx != null)
            {
                datasetClause.NamedGraphClause = new NamedGraphClause();
                this.stack.Push(datasetClause.NamedGraphClause);
                this.Visit(namedGraphClauseCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDefaultGraphClause([NotNull] SparqlParser.DefaultGraphClauseContext context)
        {
            var defaultGraphClause = this.stack.PeekCtx<DefaultGraphClause>();
            defaultGraphClause.Parse(context);

            var sourceSelectorCtx = context.sourceSelector();
            if (sourceSelectorCtx != null)
            {
                defaultGraphClause.SourceSelector = new SourceSelector();
                this.stack.Push(defaultGraphClause.SourceSelector);
                this.Visit(sourceSelectorCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNamedGraphClause([NotNull] SparqlParser.NamedGraphClauseContext context)
        {
            var namedGraphClause = this.stack.PeekCtx<NamedGraphClause>();
            namedGraphClause.Parse(context);

            var sourceSelectorCtx = context.sourceSelector();
            if (sourceSelectorCtx != null)
            {
                namedGraphClause.SourceSelector = new SourceSelector();
                this.stack.Push(namedGraphClause.SourceSelector);
                this.Visit(sourceSelectorCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSourceSelector([NotNull] SparqlParser.SourceSelectorContext context)
        {
            var sourceSelector = this.stack.PeekCtx<SourceSelector>();
            sourceSelector.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                sourceSelector.Iri = new Iri();
                this.stack.Push(sourceSelector.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitWhereClause([NotNull] SparqlParser.WhereClauseContext context)
        {
            var whereClause = this.stack.PeekCtx<WhereClause>();
            whereClause.Parse(context);

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                whereClause.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(whereClause.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSolutionModifier([NotNull] SparqlParser.SolutionModifierContext context)
        {
            var solutionModifier = this.stack.PeekCtx<SolutionModifier>();
            solutionModifier.Parse(context);

            var groupClauseCtx = context.groupClause();
            if (groupClauseCtx != null)
            {
                solutionModifier.GroupClause = new GroupClause();
                this.stack.Push(solutionModifier.GroupClause);
                this.Visit(groupClauseCtx);
                this.stack.Pop();
            }

            var havingClauseCtx = context.havingClause();
            if (havingClauseCtx != null)
            {
                solutionModifier.HavingClause = new HavingClause();
                this.stack.Push(solutionModifier.HavingClause);
                this.Visit(havingClauseCtx);
                this.stack.Pop();
            }

            var orderClauseCtx = context.orderClause();
            if (orderClauseCtx != null)
            {
                solutionModifier.OrderClause = new OrderClause();
                this.stack.Push(solutionModifier.OrderClause);
                this.Visit(orderClauseCtx);
                this.stack.Pop();
            }

            var limitOffsetClausesCtx = context.limitOffsetClauses();
            if (limitOffsetClausesCtx != null)
            {
                solutionModifier.LimitOffsetClauses = new LimitOffsetClauses();
                this.stack.Push(solutionModifier.LimitOffsetClauses);
                this.Visit(limitOffsetClausesCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGroupClause([NotNull] SparqlParser.GroupClauseContext context)
        {
            var groupClause = this.stack.PeekCtx<GroupClause>();
            groupClause.Parse(context);

            var groupConditionCtx = context.groupCondition();
            if (groupConditionCtx != null)
            {
                groupClause.GroupCondition = new GroupCondition();
                this.stack.Push(groupClause.GroupCondition);
                this.Visit(groupConditionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGroupCondition([NotNull] SparqlParser.GroupConditionContext context)
        {
            var groupCondition = this.stack.PeekCtx<GroupCondition>();
            groupCondition.Parse(context);

            var builtInCallCtx = context.builtInCall();
            if (builtInCallCtx != null)
            {
                groupCondition.BuiltInCall = new BuiltInCall();
                this.stack.Push(groupCondition.BuiltInCall);
                this.Visit(builtInCallCtx);
                this.stack.Pop();
            }

            var functionCallCtx = context.functionCall();
            if (functionCallCtx != null)
            {
                groupCondition.FunctionCall = new FunctionCall();
                this.stack.Push(groupCondition.FunctionCall);
                this.Visit(functionCallCtx);
                this.stack.Pop();
            }

            var expressionCtx = context.expression();
            if (expressionCtx != null)
            {
                groupCondition.Expression = new Expression();
                this.stack.Push(groupCondition.Expression);
                this.Visit(expressionCtx);
                this.stack.Pop();
            }

            var varCtxs = context.var();
            foreach (var ctx in varCtxs)
            {
                var var = new Var();
                groupCondition.Vars.Add(var);
                this.stack.Push(var);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitHavingClause([NotNull] SparqlParser.HavingClauseContext context)
        {
            var havingClause = this.stack.PeekCtx<HavingClause>();
            havingClause.Parse(context);

            var havingConditionCtx = context.havingCondition();
            if (havingConditionCtx != null)
            {
                havingClause.HavingCondition = new HavingCondition();
                this.stack.Push(havingClause.HavingCondition);
                this.Visit(havingConditionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitHavingCondition([NotNull] SparqlParser.HavingConditionContext context)
        {
            var havingCondition = this.stack.PeekCtx<HavingCondition>();
            havingCondition.Parse(context);

            var constraintCtx = context.constraint();
            if (constraintCtx != null)
            {
                havingCondition.Constraint = new Constraint();
                this.stack.Push(havingCondition.Constraint);
                this.Visit(constraintCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitOrderClause([NotNull] SparqlParser.OrderClauseContext context)
        {
            var orderClause = this.stack.PeekCtx<OrderClause>();
            orderClause.Parse(context);

            var orderConditionCtx = context.orderCondition();
            if (orderConditionCtx != null)
            {
                orderClause.OrderCondition = new OrderCondition();
                this.stack.Push(orderClause.OrderCondition);
                this.Visit(orderConditionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitOrderCondition([NotNull] SparqlParser.OrderConditionContext context)
        {
            var orderCondition = this.stack.PeekCtx<OrderCondition>();
            orderCondition.Parse(context);

            var brackettedExpressionCtx = context.brackettedExpression();
            if (brackettedExpressionCtx != null)
            {
                orderCondition.BrackettedExpression = new BrackettedExpression();
                this.stack.Push(orderCondition.BrackettedExpression);
                this.Visit(brackettedExpressionCtx);
                this.stack.Pop();
            }

            var constraintCtx = context.constraint();
            if (constraintCtx != null)
            {
                orderCondition.Constraint = new Constraint();
                this.stack.Push(orderCondition.Constraint);
                this.Visit(constraintCtx);
                this.stack.Pop();
            }

            var varCtx = context.var();
            if (varCtx != null)
            {
                orderCondition.Var = new Var();
                this.stack.Push(orderCondition.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLimitOffsetClauses([NotNull] SparqlParser.LimitOffsetClausesContext context)
        {
            var limitOffsetClauses = this.stack.PeekCtx<LimitOffsetClauses>();
            limitOffsetClauses.Parse(context);

            var limitClauseCtxs = context.limitClause();
            foreach (var ctx in limitClauseCtxs)
            {
                var limitClause = new LimitClause();
                limitOffsetClauses.LimitClauses.Add(limitClause);
                this.stack.Push(limitClause);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var offsetClauseCtxs = context.offsetClause();
            foreach (var ctx in offsetClauseCtxs)
            {
                var offsetClause = new OffsetClause();
                limitOffsetClauses.OffsetClauses.Add(offsetClause);
                this.stack.Push(offsetClause);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLimitClause([NotNull] SparqlParser.LimitClauseContext context)
        {
            var limitClause = this.stack.PeekCtx<LimitClause>();
            limitClause.Parse(context);

            return 0;
        }

        public override int VisitOffsetClause([NotNull] SparqlParser.OffsetClauseContext context)
        {
            var offsetClause = this.stack.PeekCtx<OffsetClause>();
            offsetClause.Parse(context);

            return 0;
        }

        public override int VisitValuesClause([NotNull] SparqlParser.ValuesClauseContext context)
        {
            var valuesClause = this.stack.PeekCtx<ValuesClause>();
            valuesClause.Parse(context);

            var dataBlockCtx = context.dataBlock();
            if (dataBlockCtx != null)
            {
                valuesClause.DataBlock = new DataBlock();
                this.stack.Push(valuesClause.DataBlock);
                this.Visit(dataBlockCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitUpdate([NotNull] SparqlParser.UpdateContext context)
        {
            var update = this.stack.PeekCtx<Update>();
            update.Parse(context);

            var prologueCtx = context.prologue();
            if (prologueCtx != null)
            {
                update.Prologue = new Prologue();
                this.stack.Push(update.Prologue);
                this.Visit(prologueCtx);
                this.stack.Pop();
            }

            var update1Ctx = context.update1();
            if (update1Ctx != null)
            {
                update.Update1 = new Update1();
                this.stack.Push(update.Update1);
                this.Visit(update1Ctx);
                this.stack.Pop();
            }

            var updateCtx = context.update();
            if (updateCtx != null)
            {
                update.Update = new Update();
                this.stack.Push(update.Update);
                this.Visit(updateCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitUpdate1([NotNull] SparqlParser.Update1Context context)
        {
            var update1 = this.stack.PeekCtx<Update1>();
            update1.Parse(context);

            var loadCtx = context.load();
            if (loadCtx != null)
            {
                update1.Load = new Load();
                this.stack.Push(update1.Load);
                this.Visit(loadCtx);
                this.stack.Pop();
            }

            var clearCtx = context.clear();
            if (clearCtx != null)
            {
                update1.Clear = new Clear();
                this.stack.Push(update1.Clear);
                this.Visit(clearCtx);
                this.stack.Pop();
            }

            var dropCtx = context.drop();
            if (dropCtx != null)
            {
                update1.Drop = new Drop();
                this.stack.Push(update1.Drop);
                this.Visit(dropCtx);
                this.stack.Pop();
            }

            var addCtx = context.add();
            if (addCtx != null)
            {
                update1.Add = new Add();
                this.stack.Push(update1.Add);
                this.Visit(addCtx);
                this.stack.Pop();
            }

            var moveCtx = context.move();
            if (moveCtx != null)
            {
                update1.Move = new Move();
                this.stack.Push(update1.Move);
                this.Visit(moveCtx);
                this.stack.Pop();
            }

            var copyCtx = context.copy();
            if (copyCtx != null)
            {
                update1.Copy = new Copy();
                this.stack.Push(update1.Copy);
                this.Visit(copyCtx);
                this.stack.Pop();
            }

            var createCtx = context.create();
            if (createCtx != null)
            {
                update1.Create = new Create();
                this.stack.Push(update1.Create);
                this.Visit(createCtx);
                this.stack.Pop();
            }

            var insertDataCtx = context.insertData();
            if (insertDataCtx != null)
            {
                update1.InsertData = new InsertData();
                this.stack.Push(update1.InsertData);
                this.Visit(insertDataCtx);
                this.stack.Pop();
            }

            var deleteDataCtx = context.deleteData();
            if (deleteDataCtx != null)
            {
                update1.DeleteData = new DeleteData();
                this.stack.Push(update1.DeleteData);
                this.Visit(deleteDataCtx);
                this.stack.Pop();
            }

            var deleteWhereCtx = context.deleteWhere();
            if (deleteWhereCtx != null)
            {
                update1.DeleteWhere = new DeleteWhere();
                this.stack.Push(update1.DeleteWhere);
                this.Visit(deleteWhereCtx);
                this.stack.Pop();
            }

            var modifyCtx = context.modify();
            if (modifyCtx != null)
            {
                update1.Modify = new Modify();
                this.stack.Push(update1.Modify);
                this.Visit(modifyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitLoad([NotNull] SparqlParser.LoadContext context)
        {
            var load = this.stack.PeekCtx<Load>();
            load.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                load.Iri = new Iri();
                this.stack.Push(load.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            var graphRefCtx = context.graphRef();
            if (graphRefCtx != null)
            {
                load.GraphRef = new GraphRef();
                this.stack.Push(load.GraphRef);
                this.Visit(graphRefCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitClear([NotNull] SparqlParser.ClearContext context)
        {
            var clear = this.stack.PeekCtx<Clear>();
            clear.Parse(context);

            var graphRefAllCtx = context.graphRefAll();
            if (graphRefAllCtx != null)
            {
                clear.GraphRefAll = new GraphRefAll();
                this.stack.Push(clear.GraphRefAll);
                this.Visit(graphRefAllCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDrop([NotNull] SparqlParser.DropContext context)
        {
            var drop = this.stack.PeekCtx<Drop>();
            drop.Parse(context);

            var graphRefAllCtx = context.graphRefAll();
            if (graphRefAllCtx != null)
            {
                drop.GraphRefAll = new GraphRefAll();
                this.stack.Push(drop.GraphRefAll);
                this.Visit(graphRefAllCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitCreate([NotNull] SparqlParser.CreateContext context)
        {
            var create = this.stack.PeekCtx<Create>();
            create.Parse(context);

            var graphRefCtx = context.graphRef();
            if (graphRefCtx != null)
            {
                create.GraphRef = new GraphRef();
                this.stack.Push(create.GraphRef);
                this.Visit(graphRefCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAdd([NotNull] SparqlParser.AddContext context)
        {
            var add = this.stack.PeekCtx<Add>();
            add.Parse(context);

            var graphOrDefaultCtxs = context.graphOrDefault();
            foreach (var ctx in graphOrDefaultCtxs)
            {
                var graphOrDefault = new GraphOrDefault();
                add.GraphOrDefaults.Add(graphOrDefault);
                this.stack.Push(graphOrDefault);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitMove([NotNull] SparqlParser.MoveContext context)
        {
            var move = this.stack.PeekCtx<Move>();
            move.Parse(context);

            var graphOrDefaultCtxs = context.graphOrDefault();
            foreach (var ctx in graphOrDefaultCtxs)
            {
                var graphOrDefault = new GraphOrDefault();
                move.GraphOrDefaults.Add(graphOrDefault);
                this.stack.Push(graphOrDefault);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitCopy([NotNull] SparqlParser.CopyContext context)
        {
            var copy = this.stack.PeekCtx<Copy>();
            copy.Parse(context);

            var graphOrDefaultCtxs = context.graphOrDefault();
            foreach (var ctx in graphOrDefaultCtxs)
            {
                var graphOrDefault = new GraphOrDefault();
                copy.GraphOrDefaults.Add(graphOrDefault);
                this.stack.Push(graphOrDefault);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInsertData([NotNull] SparqlParser.InsertDataContext context)
        {
            var insertData = this.stack.PeekCtx<InsertData>();
            insertData.Parse(context);

            var quadDataCtx = context.quadData();
            if (quadDataCtx != null)
            {
                insertData.QuadData = new QuadData();
                this.stack.Push(insertData.QuadData);
                this.Visit(quadDataCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDeleteData([NotNull] SparqlParser.DeleteDataContext context)
        {
            var deleteData = this.stack.PeekCtx<DeleteData>();
            deleteData.Parse(context);

            var quadDataCtx = context.quadData();
            if (quadDataCtx != null)
            {
                deleteData.QuadData = new QuadData();
                this.stack.Push(deleteData.QuadData);
                this.Visit(quadDataCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDeleteWhere([NotNull] SparqlParser.DeleteWhereContext context)
        {
            var deleteWhere = this.stack.PeekCtx<DeleteWhere>();
            deleteWhere.Parse(context);

            var quadPatternCtx = context.quadPattern();
            if (quadPatternCtx != null)
            {
                deleteWhere.QuadPattern = new QuadPattern();
                this.stack.Push(deleteWhere.QuadPattern);
                this.Visit(quadPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitModify([NotNull] SparqlParser.ModifyContext context)
        {
            var modify = this.stack.PeekCtx<Modify>();
            modify.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                modify.Iri = new Iri();
                this.stack.Push(modify.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            var deleteClauseCtx = context.deleteClause();
            if (deleteClauseCtx != null)
            {
                modify.DeleteClause = new DeleteClause();
                this.stack.Push(modify.DeleteClause);
                this.Visit(deleteClauseCtx);
                this.stack.Pop();
            }

            var insertClauseCtxs = context.insertClause();
            foreach (var ctx in insertClauseCtxs)
            {
                var insertClause = new InsertClause();
                modify.InsertClauses.Add(insertClause);
                this.stack.Push(insertClause);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var usingClauseCtx = context.usingClause();
            if (usingClauseCtx != null)
            {
                modify.UsingClause = new UsingClause();
                this.stack.Push(modify.UsingClause);
                this.Visit(usingClauseCtx);
                this.stack.Pop();
            }

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                modify.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(modify.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDeleteClause([NotNull] SparqlParser.DeleteClauseContext context)
        {
            var deleteClause = this.stack.PeekCtx<DeleteClause>();
            deleteClause.Parse(context);

            var quadPatternCtx = context.quadPattern();
            if (quadPatternCtx != null)
            {
                deleteClause.QuadPattern = new QuadPattern();
                this.stack.Push(deleteClause.QuadPattern);
                this.Visit(quadPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInsertClause([NotNull] SparqlParser.InsertClauseContext context)
        {
            var insertClause = this.stack.PeekCtx<InsertClause>();
            insertClause.Parse(context);

            var quadPatternCtx = context.quadPattern();
            if (quadPatternCtx != null)
            {
                insertClause.QuadPattern = new QuadPattern();
                this.stack.Push(insertClause.QuadPattern);
                this.Visit(quadPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitUsingClause([NotNull] SparqlParser.UsingClauseContext context)
        {
            var usingClause = this.stack.PeekCtx<UsingClause>();
            usingClause.Parse(context);

            var iriCtxs = context.iri();
            foreach (var ctx in iriCtxs)
            {
                var iri = new Iri();
                usingClause.Iris.Add(iri);
                this.stack.Push(iri);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphOrDefault([NotNull] SparqlParser.GraphOrDefaultContext context)
        {
            var graphOrDefault = this.stack.PeekCtx<GraphOrDefault>();
            graphOrDefault.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                graphOrDefault.Iri = new Iri();
                this.stack.Push(graphOrDefault.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphRef([NotNull] SparqlParser.GraphRefContext context)
        {
            var graphRef = this.stack.PeekCtx<GraphRef>();
            graphRef.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                graphRef.Iri = new Iri();
                this.stack.Push(graphRef.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphRefAll([NotNull] SparqlParser.GraphRefAllContext context)
        {
            var graphRefAll = this.stack.PeekCtx<GraphRefAll>();
            graphRefAll.Parse(context);

            var graphRefCtx = context.graphRef();
            if (graphRefCtx != null)
            {
                graphRefAll.GraphRef = new GraphRef();
                this.stack.Push(graphRefAll.GraphRef);
                this.Visit(graphRefCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitQuadPattern([NotNull] SparqlParser.QuadPatternContext context)
        {
            var quadPattern = this.stack.PeekCtx<QuadPattern>();
            quadPattern.Parse(context);

            var quadsCtx = context.quads();
            if (quadsCtx != null)
            {
                quadPattern.Quads = new Quads();
                this.stack.Push(quadPattern.Quads);
                this.Visit(quadsCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitQuadData([NotNull] SparqlParser.QuadDataContext context)
        {
            var quadData = this.stack.PeekCtx<QuadData>();
            quadData.Parse(context);

            var quadsCtx = context.quads();
            if (quadsCtx != null)
            {
                quadData.Quads = new Quads();
                this.stack.Push(quadData.Quads);
                this.Visit(quadsCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitQuads([NotNull] SparqlParser.QuadsContext context)
        {
            var quads = this.stack.PeekCtx<Quads>();
            quads.Parse(context);

            var triplesTemplateCtxs = context.triplesTemplate();
            foreach (var ctx in triplesTemplateCtxs)
            {
                var triplesTemplate = new TriplesTemplate();
                quads.TriplesTemplates.Add(triplesTemplate);
                this.stack.Push(triplesTemplate);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var quadsNotTriplesCtxs = context.quadsNotTriples();
            foreach (var ctx in quadsNotTriplesCtxs)
            {
                var quadsNotTriples = new QuadsNotTriples();
                quads.QuadsNotTripless.Add(quadsNotTriples);
                this.stack.Push(quadsNotTriples);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitQuadsNotTriples([NotNull] SparqlParser.QuadsNotTriplesContext context)
        {
            var quadsNotTriples = this.stack.PeekCtx<QuadsNotTriples>();
            quadsNotTriples.Parse(context);

            var varOrIriCtx = context.varOrIri();
            if (varOrIriCtx != null)
            {
                quadsNotTriples.VarOrIri = new VarOrIri();
                this.stack.Push(quadsNotTriples.VarOrIri);
                this.Visit(varOrIriCtx);
                this.stack.Pop();
            }

            var triplesTemplateCtx = context.triplesTemplate();
            if (triplesTemplateCtx != null)
            {
                quadsNotTriples.TriplesTemplate = new TriplesTemplate();
                this.stack.Push(quadsNotTriples.TriplesTemplate);
                this.Visit(triplesTemplateCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTriplesTemplate([NotNull] SparqlParser.TriplesTemplateContext context)
        {
            var triplesTemplate = this.stack.PeekCtx<TriplesTemplate>();
            triplesTemplate.Parse(context);

            var triplesSameSubjectCtx = context.triplesSameSubject();
            if (triplesSameSubjectCtx != null)
            {
                triplesTemplate.TriplesSameSubject = new TriplesSameSubject();
                this.stack.Push(triplesTemplate.TriplesSameSubject);
                this.Visit(triplesSameSubjectCtx);
                this.stack.Pop();
            }

            var triplesTemplateCtx = context.triplesTemplate();
            if (triplesTemplateCtx != null)
            {
                triplesTemplate.TriplesTemplate = new TriplesTemplate();
                this.stack.Push(triplesTemplate.TriplesTemplate);
                this.Visit(triplesTemplateCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGroupGraphPattern([NotNull] SparqlParser.GroupGraphPatternContext context)
        {
            var groupGraphPattern = this.stack.PeekCtx<GroupGraphPattern>();
            groupGraphPattern.Parse(context);

            var subSelectCtx = context.subSelect();
            if (subSelectCtx != null)
            {
                groupGraphPattern.SubSelect = new SubSelect();
                this.stack.Push(groupGraphPattern.SubSelect);
                this.Visit(subSelectCtx);
                this.stack.Pop();
            }

            var groupGraphPatternSubCtx = context.groupGraphPatternSub();
            if (groupGraphPatternSubCtx != null)
            {
                groupGraphPattern.GroupGraphPatternSub = new GroupGraphPatternSub();
                this.stack.Push(groupGraphPattern.GroupGraphPatternSub);
                this.Visit(groupGraphPatternSubCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGroupGraphPatternSub([NotNull] SparqlParser.GroupGraphPatternSubContext context)
        {
            var groupGraphPatternSub = this.stack.PeekCtx<GroupGraphPatternSub>();
            groupGraphPatternSub.Parse(context);

            var triplesBlockCtxs = context.triplesBlock();
            foreach (var ctx in triplesBlockCtxs)
            {
                var triplesBlock = new TriplesBlock();
                groupGraphPatternSub.TriplesBlocks.Add(triplesBlock);
                this.stack.Push(triplesBlock);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var graphPatternNotTriplesCtxs = context.graphPatternNotTriples();
            foreach (var ctx in graphPatternNotTriplesCtxs)
            {
                var graphPatternNotTriples = new GraphPatternNotTriples();
                groupGraphPatternSub.GraphPatternNotTripless.Add(graphPatternNotTriples);
                this.stack.Push(graphPatternNotTriples);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTriplesBlock([NotNull] SparqlParser.TriplesBlockContext context)
        {
            var triplesBlock = this.stack.PeekCtx<TriplesBlock>();
            triplesBlock.Parse(context);

            var triplesSameSubjectPathCtx = context.triplesSameSubjectPath();
            if (triplesSameSubjectPathCtx != null)
            {
                triplesBlock.TriplesSameSubjectPath = new TriplesSameSubjectPath();
                this.stack.Push(triplesBlock.TriplesSameSubjectPath);
                this.Visit(triplesSameSubjectPathCtx);
                this.stack.Pop();
            }

            var triplesBlockCtx = context.triplesBlock();
            if (triplesBlockCtx != null)
            {
                triplesBlock.TriplesBlock = new TriplesBlock();
                this.stack.Push(triplesBlock.TriplesBlock);
                this.Visit(triplesBlockCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphPatternNotTriples([NotNull] SparqlParser.GraphPatternNotTriplesContext context)
        {
            var graphPatternNotTriples = this.stack.PeekCtx<GraphPatternNotTriples>();
            graphPatternNotTriples.Parse(context);

            var groupOrUnionGraphPatternCtx = context.groupOrUnionGraphPattern();
            if (groupOrUnionGraphPatternCtx != null)
            {
                graphPatternNotTriples.GroupOrUnionGraphPattern = new GroupOrUnionGraphPattern();
                this.stack.Push(graphPatternNotTriples.GroupOrUnionGraphPattern);
                this.Visit(groupOrUnionGraphPatternCtx);
                this.stack.Pop();
            }

            var optionalGraphPatternCtx = context.optionalGraphPattern();
            if (optionalGraphPatternCtx != null)
            {
                graphPatternNotTriples.OptionalGraphPattern = new OptionalGraphPattern();
                this.stack.Push(graphPatternNotTriples.OptionalGraphPattern);
                this.Visit(optionalGraphPatternCtx);
                this.stack.Pop();
            }

            var minusGraphPatternCtx = context.minusGraphPattern();
            if (minusGraphPatternCtx != null)
            {
                graphPatternNotTriples.MinusGraphPattern = new MinusGraphPattern();
                this.stack.Push(graphPatternNotTriples.MinusGraphPattern);
                this.Visit(minusGraphPatternCtx);
                this.stack.Pop();
            }

            var graphGraphPatternCtx = context.graphGraphPattern();
            if (graphGraphPatternCtx != null)
            {
                graphPatternNotTriples.GraphGraphPattern = new GraphGraphPattern();
                this.stack.Push(graphPatternNotTriples.GraphGraphPattern);
                this.Visit(graphGraphPatternCtx);
                this.stack.Pop();
            }

            var serviceGraphPatternCtx = context.serviceGraphPattern();
            if (serviceGraphPatternCtx != null)
            {
                graphPatternNotTriples.ServiceGraphPattern = new ServiceGraphPattern();
                this.stack.Push(graphPatternNotTriples.ServiceGraphPattern);
                this.Visit(serviceGraphPatternCtx);
                this.stack.Pop();
            }

            var filterCtx = context.filter();
            if (filterCtx != null)
            {
                graphPatternNotTriples.Filter = new Filter();
                this.stack.Push(graphPatternNotTriples.Filter);
                this.Visit(filterCtx);
                this.stack.Pop();
            }

            var bindCtx = context.bind();
            if (bindCtx != null)
            {
                graphPatternNotTriples.Bind = new Bind();
                this.stack.Push(graphPatternNotTriples.Bind);
                this.Visit(bindCtx);
                this.stack.Pop();
            }

            var inlineDataCtx = context.inlineData();
            if (inlineDataCtx != null)
            {
                graphPatternNotTriples.InlineData = new InlineData();
                this.stack.Push(graphPatternNotTriples.InlineData);
                this.Visit(inlineDataCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitOptionalGraphPattern([NotNull] SparqlParser.OptionalGraphPatternContext context)
        {
            var optionalGraphPattern = this.stack.PeekCtx<OptionalGraphPattern>();
            optionalGraphPattern.Parse(context);

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                optionalGraphPattern.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(optionalGraphPattern.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphGraphPattern([NotNull] SparqlParser.GraphGraphPatternContext context)
        {
            var graphGraphPattern = this.stack.PeekCtx<GraphGraphPattern>();
            graphGraphPattern.Parse(context);

            var varOrIriCtx = context.varOrIri();
            if (varOrIriCtx != null)
            {
                graphGraphPattern.VarOrIri = new VarOrIri();
                this.stack.Push(graphGraphPattern.VarOrIri);
                this.Visit(varOrIriCtx);
                this.stack.Pop();
            }

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                graphGraphPattern.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(graphGraphPattern.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitServiceGraphPattern([NotNull] SparqlParser.ServiceGraphPatternContext context)
        {
            var serviceGraphPattern = this.stack.PeekCtx<ServiceGraphPattern>();
            serviceGraphPattern.Parse(context);

            var varOrIriCtx = context.varOrIri();
            if (varOrIriCtx != null)
            {
                serviceGraphPattern.VarOrIri = new VarOrIri();
                this.stack.Push(serviceGraphPattern.VarOrIri);
                this.Visit(varOrIriCtx);
                this.stack.Pop();
            }

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                serviceGraphPattern.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(serviceGraphPattern.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBind([NotNull] SparqlParser.BindContext context)
        {
            var bind = this.stack.PeekCtx<Bind>();
            bind.Parse(context);

            var expressionCtx = context.expression();
            if (expressionCtx != null)
            {
                bind.Expression = new Expression();
                this.stack.Push(bind.Expression);
                this.Visit(expressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInlineData([NotNull] SparqlParser.InlineDataContext context)
        {
            var inlineData = this.stack.PeekCtx<InlineData>();
            inlineData.Parse(context);

            var dataBlockCtx = context.dataBlock();
            if (dataBlockCtx != null)
            {
                inlineData.DataBlock = new DataBlock();
                this.stack.Push(inlineData.DataBlock);
                this.Visit(dataBlockCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataBlock([NotNull] SparqlParser.DataBlockContext context)
        {
            var dataBlock = this.stack.PeekCtx<DataBlock>();
            dataBlock.Parse(context);

            var inlineDataOneVarCtx = context.inlineDataOneVar();
            if (inlineDataOneVarCtx != null)
            {
                dataBlock.InlineDataOneVar = new InlineDataOneVar();
                this.stack.Push(dataBlock.InlineDataOneVar);
                this.Visit(inlineDataOneVarCtx);
                this.stack.Pop();
            }

            var inlineDataFullCtx = context.inlineDataFull();
            if (inlineDataFullCtx != null)
            {
                dataBlock.InlineDataFull = new InlineDataFull();
                this.stack.Push(dataBlock.InlineDataFull);
                this.Visit(inlineDataFullCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInlineDataOneVar([NotNull] SparqlParser.InlineDataOneVarContext context)
        {
            var inlineDataOneVar = this.stack.PeekCtx<InlineDataOneVar>();
            inlineDataOneVar.Parse(context);

            var dataBlockValueCtx = context.dataBlockValue();
            if (dataBlockValueCtx != null)
            {
                inlineDataOneVar.DataBlockValue = new DataBlockValue();
                this.stack.Push(inlineDataOneVar.DataBlockValue);
                this.Visit(dataBlockValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInlineDataFull([NotNull] SparqlParser.InlineDataFullContext context)
        {
            var inlineDataFull = this.stack.PeekCtx<InlineDataFull>();
            inlineDataFull.Parse(context);

            var dataBlockValueCtxs = context.dataBlockValue();
            foreach (var ctx in dataBlockValueCtxs)
            {
                var dataBlockValue = new DataBlockValue();
                inlineDataFull.DataBlockValues.Add(dataBlockValue);
                this.stack.Push(dataBlockValue);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataBlockValue([NotNull] SparqlParser.DataBlockValueContext context)
        {
            var dataBlockValue = this.stack.PeekCtx<DataBlockValue>();
            dataBlockValue.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                dataBlockValue.Iri = new Iri();
                this.stack.Push(dataBlockValue.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitMinusGraphPattern([NotNull] SparqlParser.MinusGraphPatternContext context)
        {
            var minusGraphPattern = this.stack.PeekCtx<MinusGraphPattern>();
            minusGraphPattern.Parse(context);

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                minusGraphPattern.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(minusGraphPattern.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGroupOrUnionGraphPattern([NotNull] SparqlParser.GroupOrUnionGraphPatternContext context)
        {
            var groupOrUnionGraphPattern = this.stack.PeekCtx<GroupOrUnionGraphPattern>();
            groupOrUnionGraphPattern.Parse(context);

            var groupGraphPatternCtxs = context.groupGraphPattern();
            foreach (var ctx in groupGraphPatternCtxs)
            {
                var groupGraphPattern = new GroupGraphPattern();
                groupOrUnionGraphPattern.GroupGraphPatterns.Add(groupGraphPattern);
                this.stack.Push(groupGraphPattern);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitFilter([NotNull] SparqlParser.FilterContext context)
        {
            var filter = this.stack.PeekCtx<Filter>();
            filter.Parse(context);

            var constraintCtx = context.constraint();
            if (constraintCtx != null)
            {
                filter.Constraint = new Constraint();
                this.stack.Push(filter.Constraint);
                this.Visit(constraintCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConstraint([NotNull] SparqlParser.ConstraintContext context)
        {
            var constraint = this.stack.PeekCtx<Constraint>();
            constraint.Parse(context);

            var brackettedExpressionCtx = context.brackettedExpression();
            if (brackettedExpressionCtx != null)
            {
                constraint.BrackettedExpression = new BrackettedExpression();
                this.stack.Push(constraint.BrackettedExpression);
                this.Visit(brackettedExpressionCtx);
                this.stack.Pop();
            }

            var builtInCallCtx = context.builtInCall();
            if (builtInCallCtx != null)
            {
                constraint.BuiltInCall = new BuiltInCall();
                this.stack.Push(constraint.BuiltInCall);
                this.Visit(builtInCallCtx);
                this.stack.Pop();
            }

            var functionCallCtx = context.functionCall();
            if (functionCallCtx != null)
            {
                constraint.FunctionCall = new FunctionCall();
                this.stack.Push(constraint.FunctionCall);
                this.Visit(functionCallCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitFunctionCall([NotNull] SparqlParser.FunctionCallContext context)
        {
            var functionCall = this.stack.PeekCtx<FunctionCall>();
            functionCall.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                functionCall.Iri = new Iri();
                this.stack.Push(functionCall.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitArgList([NotNull] SparqlParser.ArgListContext context)
        {
            var argList = this.stack.PeekCtx<ArgList>();
            argList.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                argList.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitExpressionList([NotNull] SparqlParser.ExpressionListContext context)
        {
            var expressionList = this.stack.PeekCtx<ExpressionList>();
            expressionList.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                expressionList.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConstructTemplate([NotNull] SparqlParser.ConstructTemplateContext context)
        {
            var constructTemplate = this.stack.PeekCtx<ConstructTemplate>();
            constructTemplate.Parse(context);

            var constructTriplesCtx = context.constructTriples();
            if (constructTriplesCtx != null)
            {
                constructTemplate.ConstructTriples = new ConstructTriples();
                this.stack.Push(constructTemplate.ConstructTriples);
                this.Visit(constructTriplesCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConstructTriples([NotNull] SparqlParser.ConstructTriplesContext context)
        {
            var constructTriples = this.stack.PeekCtx<ConstructTriples>();
            constructTriples.Parse(context);

            var triplesSameSubjectCtx = context.triplesSameSubject();
            if (triplesSameSubjectCtx != null)
            {
                constructTriples.TriplesSameSubject = new TriplesSameSubject();
                this.stack.Push(constructTriples.TriplesSameSubject);
                this.Visit(triplesSameSubjectCtx);
                this.stack.Pop();
            }

            var constructTriplesCtx = context.constructTriples();
            if (constructTriplesCtx != null)
            {
                constructTriples.ConstructTriples = new ConstructTriples();
                this.stack.Push(constructTriples.ConstructTriples);
                this.Visit(constructTriplesCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTriplesSameSubject([NotNull] SparqlParser.TriplesSameSubjectContext context)
        {
            var triplesSameSubject = this.stack.PeekCtx<TriplesSameSubject>();
            triplesSameSubject.Parse(context);

            var varOrTermCtx = context.varOrTerm();
            if (varOrTermCtx != null)
            {
                triplesSameSubject.VarOrTerm = new VarOrTerm();
                this.stack.Push(triplesSameSubject.VarOrTerm);
                this.Visit(varOrTermCtx);
                this.stack.Pop();
            }

            var propertyListNotEmptyCtx = context.propertyListNotEmpty();
            if (propertyListNotEmptyCtx != null)
            {
                triplesSameSubject.PropertyListNotEmpty = new PropertyListNotEmpty();
                this.stack.Push(triplesSameSubject.PropertyListNotEmpty);
                this.Visit(propertyListNotEmptyCtx);
                this.stack.Pop();
            }

            var triplesNodeCtx = context.triplesNode();
            if (triplesNodeCtx != null)
            {
                triplesSameSubject.TriplesNode = new TriplesNode();
                this.stack.Push(triplesSameSubject.TriplesNode);
                this.Visit(triplesNodeCtx);
                this.stack.Pop();
            }

            var propertyListCtx = context.propertyList();
            if (propertyListCtx != null)
            {
                triplesSameSubject.PropertyList = new PropertyList();
                this.stack.Push(triplesSameSubject.PropertyList);
                this.Visit(propertyListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPropertyList([NotNull] SparqlParser.PropertyListContext context)
        {
            var propertyList = this.stack.PeekCtx<PropertyList>();
            propertyList.Parse(context);

            var propertyListNotEmptyCtx = context.propertyListNotEmpty();
            if (propertyListNotEmptyCtx != null)
            {
                propertyList.PropertyListNotEmpty = new PropertyListNotEmpty();
                this.stack.Push(propertyList.PropertyListNotEmpty);
                this.Visit(propertyListNotEmptyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPropertyListNotEmpty([NotNull] SparqlParser.PropertyListNotEmptyContext context)
        {
            var propertyListNotEmpty = this.stack.PeekCtx<PropertyListNotEmpty>();
            propertyListNotEmpty.Parse(context);

            var verbCtxs = context.verb();
            foreach (var ctx in verbCtxs)
            {
                var verb = new Verb();
                propertyListNotEmpty.Verbs.Add(verb);
                this.stack.Push(verb);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var objectListCtxs = context.objectList();
            foreach (var ctx in objectListCtxs)
            {
                var objectList = new ObjectList();
                propertyListNotEmpty.ObjectLists.Add(objectList);
                this.stack.Push(objectList);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVerb([NotNull] SparqlParser.VerbContext context)
        {
            var verb = this.stack.PeekCtx<Verb>();
            verb.Parse(context);

            var varOrIriCtx = context.varOrIri();
            if (varOrIriCtx != null)
            {
                verb.VarOrIri = new VarOrIri();
                this.stack.Push(verb.VarOrIri);
                this.Visit(varOrIriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectList([NotNull] SparqlParser.ObjectListContext context)
        {
            var objectList = this.stack.PeekCtx<ObjectList>();
            objectList.Parse(context);

            var object_Ctxs = context.object_();
            foreach (var ctx in object_Ctxs)
            {
                var object_ = new Object();
                objectList.Objects.Add(object_);
                this.stack.Push(object_);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObject([NotNull] SparqlParser.ObjectContext context)
        {
            var object_ = this.stack.PeekCtx<Object>();
            object_.Parse(context);

            var graphNodeCtx = context.graphNode();
            if (graphNodeCtx != null)
            {
                object_.GraphNode = new GraphNode();
                this.stack.Push(object_.GraphNode);
                this.Visit(graphNodeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTriplesSameSubjectPath([NotNull] SparqlParser.TriplesSameSubjectPathContext context)
        {
            var triplesSameSubjectPath = this.stack.PeekCtx<TriplesSameSubjectPath>();
            triplesSameSubjectPath.Parse(context);

            var varOrTermCtx = context.varOrTerm();
            if (varOrTermCtx != null)
            {
                triplesSameSubjectPath.VarOrTerm = new VarOrTerm();
                this.stack.Push(triplesSameSubjectPath.VarOrTerm);
                this.Visit(varOrTermCtx);
                this.stack.Pop();
            }

            var propertyListPathNotEmptyCtx = context.propertyListPathNotEmpty();
            if (propertyListPathNotEmptyCtx != null)
            {
                triplesSameSubjectPath.PropertyListPathNotEmpty = new PropertyListPathNotEmpty();
                this.stack.Push(triplesSameSubjectPath.PropertyListPathNotEmpty);
                this.Visit(propertyListPathNotEmptyCtx);
                this.stack.Pop();
            }

            var triplesNodePathCtx = context.triplesNodePath();
            if (triplesNodePathCtx != null)
            {
                triplesSameSubjectPath.TriplesNodePath = new TriplesNodePath();
                this.stack.Push(triplesSameSubjectPath.TriplesNodePath);
                this.Visit(triplesNodePathCtx);
                this.stack.Pop();
            }

            var propertyListPathCtx = context.propertyListPath();
            if (propertyListPathCtx != null)
            {
                triplesSameSubjectPath.PropertyListPath = new PropertyListPath();
                this.stack.Push(triplesSameSubjectPath.PropertyListPath);
                this.Visit(propertyListPathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPropertyListPath([NotNull] SparqlParser.PropertyListPathContext context)
        {
            var propertyListPath = this.stack.PeekCtx<PropertyListPath>();
            propertyListPath.Parse(context);

            var propertyListPathNotEmptyCtx = context.propertyListPathNotEmpty();
            if (propertyListPathNotEmptyCtx != null)
            {
                propertyListPath.PropertyListPathNotEmpty = new PropertyListPathNotEmpty();
                this.stack.Push(propertyListPath.PropertyListPathNotEmpty);
                this.Visit(propertyListPathNotEmptyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPropertyListPathNotEmpty([NotNull] SparqlParser.PropertyListPathNotEmptyContext context)
        {
            var propertyListPathNotEmpty = this.stack.PeekCtx<PropertyListPathNotEmpty>();
            propertyListPathNotEmpty.Parse(context);

            var verbPathCtxs = context.verbPath();
            foreach (var ctx in verbPathCtxs)
            {
                var verbPath = new VerbPath();
                propertyListPathNotEmpty.VerbPaths.Add(verbPath);
                this.stack.Push(verbPath);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var verbSimpleCtxs = context.verbSimple();
            foreach (var ctx in verbSimpleCtxs)
            {
                var verbSimple = new VerbSimple();
                propertyListPathNotEmpty.VerbSimples.Add(verbSimple);
                this.stack.Push(verbSimple);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var objectListPathCtx = context.objectListPath();
            if (objectListPathCtx != null)
            {
                propertyListPathNotEmpty.ObjectListPath = new ObjectListPath();
                this.stack.Push(propertyListPathNotEmpty.ObjectListPath);
                this.Visit(objectListPathCtx);
                this.stack.Pop();
            }

            var objectListCtxs = context.objectList();
            foreach (var ctx in objectListCtxs)
            {
                var objectList = new ObjectList();
                propertyListPathNotEmpty.ObjectLists.Add(objectList);
                this.stack.Push(objectList);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVerbPath([NotNull] SparqlParser.VerbPathContext context)
        {
            var verbPath = this.stack.PeekCtx<VerbPath>();
            verbPath.Parse(context);

            var pathCtx = context.path();
            if (pathCtx != null)
            {
                verbPath.Path = new Path();
                this.stack.Push(verbPath.Path);
                this.Visit(pathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVerbSimple([NotNull] SparqlParser.VerbSimpleContext context)
        {
            var verbSimple = this.stack.PeekCtx<VerbSimple>();
            verbSimple.Parse(context);

            var varCtx = context.var();
            if (varCtx != null)
            {
                verbSimple.Var = new Var();
                this.stack.Push(verbSimple.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectListPath([NotNull] SparqlParser.ObjectListPathContext context)
        {
            var objectListPath = this.stack.PeekCtx<ObjectListPath>();
            objectListPath.Parse(context);

            var objectPathCtxs = context.objectPath();
            foreach (var ctx in objectPathCtxs)
            {
                var objectPath = new ObjectPath();
                objectListPath.ObjectPaths.Add(objectPath);
                this.stack.Push(objectPath);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPath([NotNull] SparqlParser.ObjectPathContext context)
        {
            var objectPath = this.stack.PeekCtx<ObjectPath>();
            objectPath.Parse(context);

            var graphNodePathCtx = context.graphNodePath();
            if (graphNodePathCtx != null)
            {
                objectPath.GraphNodePath = new GraphNodePath();
                this.stack.Push(objectPath.GraphNodePath);
                this.Visit(graphNodePathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPath([NotNull] SparqlParser.PathContext context)
        {
            var path = this.stack.PeekCtx<Path>();
            path.Parse(context);

            var pathAlternativeCtx = context.pathAlternative();
            if (pathAlternativeCtx != null)
            {
                path.PathAlternative = new PathAlternative();
                this.stack.Push(path.PathAlternative);
                this.Visit(pathAlternativeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathAlternative([NotNull] SparqlParser.PathAlternativeContext context)
        {
            var pathAlternative = this.stack.PeekCtx<PathAlternative>();
            pathAlternative.Parse(context);

            var pathSequenceCtxs = context.pathSequence();
            foreach (var ctx in pathSequenceCtxs)
            {
                var pathSequence = new PathSequence();
                pathAlternative.PathSequences.Add(pathSequence);
                this.stack.Push(pathSequence);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathSequence([NotNull] SparqlParser.PathSequenceContext context)
        {
            var pathSequence = this.stack.PeekCtx<PathSequence>();
            pathSequence.Parse(context);

            var pathEltOrInverseCtxs = context.pathEltOrInverse();
            foreach (var ctx in pathEltOrInverseCtxs)
            {
                var pathEltOrInverse = new PathEltOrInverse();
                pathSequence.PathEltOrInverses.Add(pathEltOrInverse);
                this.stack.Push(pathEltOrInverse);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathElt([NotNull] SparqlParser.PathEltContext context)
        {
            var pathElt = this.stack.PeekCtx<PathElt>();
            pathElt.Parse(context);

            var pathPrimaryCtx = context.pathPrimary();
            if (pathPrimaryCtx != null)
            {
                pathElt.PathPrimary = new PathPrimary();
                this.stack.Push(pathElt.PathPrimary);
                this.Visit(pathPrimaryCtx);
                this.stack.Pop();
            }

            var pathModCtx = context.pathMod();
            if (pathModCtx != null)
            {
                pathElt.PathMod = new PathMod();
                this.stack.Push(pathElt.PathMod);
                this.Visit(pathModCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathEltOrInverse([NotNull] SparqlParser.PathEltOrInverseContext context)
        {
            var pathEltOrInverse = this.stack.PeekCtx<PathEltOrInverse>();
            pathEltOrInverse.Parse(context);

            var pathEltCtxs = context.pathElt();
            foreach (var ctx in pathEltCtxs)
            {
                var pathElt = new PathElt();
                pathEltOrInverse.PathElts.Add(pathElt);
                this.stack.Push(pathElt);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathMod([NotNull] SparqlParser.PathModContext context)
        {
            var pathMod = this.stack.PeekCtx<PathMod>();
            pathMod.Parse(context);

            return 0;
        }

        public override int VisitPathPrimary([NotNull] SparqlParser.PathPrimaryContext context)
        {
            var pathPrimary = this.stack.PeekCtx<PathPrimary>();
            pathPrimary.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                pathPrimary.Iri = new Iri();
                this.stack.Push(pathPrimary.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            var pathNegatedPropertySetCtx = context.pathNegatedPropertySet();
            if (pathNegatedPropertySetCtx != null)
            {
                pathPrimary.PathNegatedPropertySet = new PathNegatedPropertySet();
                this.stack.Push(pathPrimary.PathNegatedPropertySet);
                this.Visit(pathNegatedPropertySetCtx);
                this.stack.Pop();
            }

            var pathCtx = context.path();
            if (pathCtx != null)
            {
                pathPrimary.Path = new Path();
                this.stack.Push(pathPrimary.Path);
                this.Visit(pathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathNegatedPropertySet([NotNull] SparqlParser.PathNegatedPropertySetContext context)
        {
            var pathNegatedPropertySet = this.stack.PeekCtx<PathNegatedPropertySet>();
            pathNegatedPropertySet.Parse(context);

            var pathOneInPropertySetCtxs = context.pathOneInPropertySet();
            foreach (var ctx in pathOneInPropertySetCtxs)
            {
                var pathOneInPropertySet = new PathOneInPropertySet();
                pathNegatedPropertySet.PathOneInPropertySets.Add(pathOneInPropertySet);
                this.stack.Push(pathOneInPropertySet);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPathOneInPropertySet([NotNull] SparqlParser.PathOneInPropertySetContext context)
        {
            var pathOneInPropertySet = this.stack.PeekCtx<PathOneInPropertySet>();
            pathOneInPropertySet.Parse(context);

            var iriCtxs = context.iri();
            foreach (var ctx in iriCtxs)
            {
                var iri = new Iri();
                pathOneInPropertySet.Iris.Add(iri);
                this.stack.Push(iri);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInteger([NotNull] SparqlParser.IntegerContext context)
        {
            var integer = this.stack.PeekCtx<Integer>();
            integer.Parse(context);

            return 0;
        }

        public override int VisitTriplesNode([NotNull] SparqlParser.TriplesNodeContext context)
        {
            var triplesNode = this.stack.PeekCtx<TriplesNode>();
            triplesNode.Parse(context);

            var collectionCtx = context.collection();
            if (collectionCtx != null)
            {
                triplesNode.Collection = new Collection();
                this.stack.Push(triplesNode.Collection);
                this.Visit(collectionCtx);
                this.stack.Pop();
            }

            var blankNodePropertyListCtx = context.blankNodePropertyList();
            if (blankNodePropertyListCtx != null)
            {
                triplesNode.BlankNodePropertyList = new BlankNodePropertyList();
                this.stack.Push(triplesNode.BlankNodePropertyList);
                this.Visit(blankNodePropertyListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBlankNodePropertyList([NotNull] SparqlParser.BlankNodePropertyListContext context)
        {
            var blankNodePropertyList = this.stack.PeekCtx<BlankNodePropertyList>();
            blankNodePropertyList.Parse(context);

            var propertyListNotEmptyCtx = context.propertyListNotEmpty();
            if (propertyListNotEmptyCtx != null)
            {
                blankNodePropertyList.PropertyListNotEmpty = new PropertyListNotEmpty();
                this.stack.Push(blankNodePropertyList.PropertyListNotEmpty);
                this.Visit(propertyListNotEmptyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTriplesNodePath([NotNull] SparqlParser.TriplesNodePathContext context)
        {
            var triplesNodePath = this.stack.PeekCtx<TriplesNodePath>();
            triplesNodePath.Parse(context);

            var collectionPathCtx = context.collectionPath();
            if (collectionPathCtx != null)
            {
                triplesNodePath.CollectionPath = new CollectionPath();
                this.stack.Push(triplesNodePath.CollectionPath);
                this.Visit(collectionPathCtx);
                this.stack.Pop();
            }

            var blankNodePropertyListPathCtx = context.blankNodePropertyListPath();
            if (blankNodePropertyListPathCtx != null)
            {
                triplesNodePath.BlankNodePropertyListPath = new BlankNodePropertyListPath();
                this.stack.Push(triplesNodePath.BlankNodePropertyListPath);
                this.Visit(blankNodePropertyListPathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBlankNodePropertyListPath([NotNull] SparqlParser.BlankNodePropertyListPathContext context)
        {
            var blankNodePropertyListPath = this.stack.PeekCtx<BlankNodePropertyListPath>();
            blankNodePropertyListPath.Parse(context);

            var propertyListPathNotEmptyCtx = context.propertyListPathNotEmpty();
            if (propertyListPathNotEmptyCtx != null)
            {
                blankNodePropertyListPath.PropertyListPathNotEmpty = new PropertyListPathNotEmpty();
                this.stack.Push(blankNodePropertyListPath.PropertyListPathNotEmpty);
                this.Visit(propertyListPathNotEmptyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitCollection([NotNull] SparqlParser.CollectionContext context)
        {
            var collection = this.stack.PeekCtx<Collection>();
            collection.Parse(context);

            var graphNodeCtx = context.graphNode();
            if (graphNodeCtx != null)
            {
                collection.GraphNode = new GraphNode();
                this.stack.Push(collection.GraphNode);
                this.Visit(graphNodeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitCollectionPath([NotNull] SparqlParser.CollectionPathContext context)
        {
            var collectionPath = this.stack.PeekCtx<CollectionPath>();
            collectionPath.Parse(context);

            var graphNodePathCtx = context.graphNodePath();
            if (graphNodePathCtx != null)
            {
                collectionPath.GraphNodePath = new GraphNodePath();
                this.stack.Push(collectionPath.GraphNodePath);
                this.Visit(graphNodePathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphNode([NotNull] SparqlParser.GraphNodeContext context)
        {
            var graphNode = this.stack.PeekCtx<GraphNode>();
            graphNode.Parse(context);

            var varOrTermCtx = context.varOrTerm();
            if (varOrTermCtx != null)
            {
                graphNode.VarOrTerm = new VarOrTerm();
                this.stack.Push(graphNode.VarOrTerm);
                this.Visit(varOrTermCtx);
                this.stack.Pop();
            }

            var triplesNodeCtx = context.triplesNode();
            if (triplesNodeCtx != null)
            {
                graphNode.TriplesNode = new TriplesNode();
                this.stack.Push(graphNode.TriplesNode);
                this.Visit(triplesNodeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitGraphNodePath([NotNull] SparqlParser.GraphNodePathContext context)
        {
            var graphNodePath = this.stack.PeekCtx<GraphNodePath>();
            graphNodePath.Parse(context);

            var varOrTermCtx = context.varOrTerm();
            if (varOrTermCtx != null)
            {
                graphNodePath.VarOrTerm = new VarOrTerm();
                this.stack.Push(graphNodePath.VarOrTerm);
                this.Visit(varOrTermCtx);
                this.stack.Pop();
            }

            var triplesNodePathCtx = context.triplesNodePath();
            if (triplesNodePathCtx != null)
            {
                graphNodePath.TriplesNodePath = new TriplesNodePath();
                this.stack.Push(graphNodePath.TriplesNodePath);
                this.Visit(triplesNodePathCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVarOrTerm([NotNull] SparqlParser.VarOrTermContext context)
        {
            var varOrTerm = this.stack.PeekCtx<VarOrTerm>();
            varOrTerm.Parse(context);

            var varCtx = context.var();
            if (varCtx != null)
            {
                varOrTerm.Var = new Var();
                this.stack.Push(varOrTerm.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            var graphTermCtx = context.graphTerm();
            if (graphTermCtx != null)
            {
                varOrTerm.GraphTerm = new GraphTerm();
                this.stack.Push(varOrTerm.GraphTerm);
                this.Visit(graphTermCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVarOrIri([NotNull] SparqlParser.VarOrIriContext context)
        {
            var varOrIri = this.stack.PeekCtx<VarOrIri>();
            varOrIri.Parse(context);

            var varCtx = context.var();
            if (varCtx != null)
            {
                varOrIri.Var = new Var();
                this.stack.Push(varOrIri.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                varOrIri.Iri = new Iri();
                this.stack.Push(varOrIri.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVar([NotNull] SparqlParser.VarContext context)
        {
            var var = this.stack.PeekCtx<Var>();
            var.Parse(context);

            return 0;
        }

        public override int VisitGraphTerm([NotNull] SparqlParser.GraphTermContext context)
        {
            var graphTerm = this.stack.PeekCtx<GraphTerm>();
            graphTerm.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                graphTerm.Iri = new Iri();
                this.stack.Push(graphTerm.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            var rDFLiteralCtx = context.rDFLiteral();
            if (rDFLiteralCtx != null)
            {
                graphTerm.RDFLiteral = new RDFLiteral();
                this.stack.Push(graphTerm.RDFLiteral);
                this.Visit(rDFLiteralCtx);
                this.stack.Pop();
            }

            var numericLiteralCtx = context.numericLiteral();
            if (numericLiteralCtx != null)
            {
                graphTerm.NumericLiteral = new NumericLiteral();
                this.stack.Push(graphTerm.NumericLiteral);
                this.Visit(numericLiteralCtx);
                this.stack.Pop();
            }

            var booleanLiteralCtx = context.booleanLiteral();
            if (booleanLiteralCtx != null)
            {
                graphTerm.BooleanLiteral = new BooleanLiteral();
                this.stack.Push(graphTerm.BooleanLiteral);
                this.Visit(booleanLiteralCtx);
                this.stack.Pop();
            }

            var blankNodeCtx = context.blankNode();
            if (blankNodeCtx != null)
            {
                graphTerm.BlankNode = new BlankNode();
                this.stack.Push(graphTerm.BlankNode);
                this.Visit(blankNodeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitExpression([NotNull] SparqlParser.ExpressionContext context)
        {
            var expression = this.stack.PeekCtx<Expression>();
            expression.Parse(context);

            var conditionalOrExpressionCtx = context.conditionalOrExpression();
            if (conditionalOrExpressionCtx != null)
            {
                expression.ConditionalOrExpression = new ConditionalOrExpression();
                this.stack.Push(expression.ConditionalOrExpression);
                this.Visit(conditionalOrExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConditionalOrExpression([NotNull] SparqlParser.ConditionalOrExpressionContext context)
        {
            var conditionalOrExpression = this.stack.PeekCtx<ConditionalOrExpression>();
            conditionalOrExpression.Parse(context);

            var conditionalAndExpressionCtxs = context.conditionalAndExpression();
            foreach (var ctx in conditionalAndExpressionCtxs)
            {
                var conditionalAndExpression = new ConditionalAndExpression();
                conditionalOrExpression.ConditionalAndExpressions.Add(conditionalAndExpression);
                this.stack.Push(conditionalAndExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConditionalAndExpression([NotNull] SparqlParser.ConditionalAndExpressionContext context)
        {
            var conditionalAndExpression = this.stack.PeekCtx<ConditionalAndExpression>();
            conditionalAndExpression.Parse(context);

            var valueLogicalCtxs = context.valueLogical();
            foreach (var ctx in valueLogicalCtxs)
            {
                var valueLogical = new ValueLogical();
                conditionalAndExpression.ValueLogicals.Add(valueLogical);
                this.stack.Push(valueLogical);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitValueLogical([NotNull] SparqlParser.ValueLogicalContext context)
        {
            var valueLogical = this.stack.PeekCtx<ValueLogical>();
            valueLogical.Parse(context);

            var relationalExpressionCtx = context.relationalExpression();
            if (relationalExpressionCtx != null)
            {
                valueLogical.RelationalExpression = new RelationalExpression();
                this.stack.Push(valueLogical.RelationalExpression);
                this.Visit(relationalExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRelationalExpression([NotNull] SparqlParser.RelationalExpressionContext context)
        {
            var relationalExpression = this.stack.PeekCtx<RelationalExpression>();
            relationalExpression.Parse(context);

            var numericExpressionCtxs = context.numericExpression();
            foreach (var ctx in numericExpressionCtxs)
            {
                var numericExpression = new NumericExpression();
                relationalExpression.NumericExpressions.Add(numericExpression);
                this.stack.Push(numericExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var expressionListCtxs = context.expressionList();
            foreach (var ctx in expressionListCtxs)
            {
                var expressionList = new ExpressionList();
                relationalExpression.ExpressionLists.Add(expressionList);
                this.stack.Push(expressionList);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNumericExpression([NotNull] SparqlParser.NumericExpressionContext context)
        {
            var numericExpression = this.stack.PeekCtx<NumericExpression>();
            numericExpression.Parse(context);

            var additiveExpressionCtx = context.additiveExpression();
            if (additiveExpressionCtx != null)
            {
                numericExpression.AdditiveExpression = new AdditiveExpression();
                this.stack.Push(numericExpression.AdditiveExpression);
                this.Visit(additiveExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAdditiveExpression([NotNull] SparqlParser.AdditiveExpressionContext context)
        {
            var additiveExpression = this.stack.PeekCtx<AdditiveExpression>();
            additiveExpression.Parse(context);

            var multiplicativeExpressionCtxs = context.multiplicativeExpression();
            foreach (var ctx in multiplicativeExpressionCtxs)
            {
                var multiplicativeExpression = new MultiplicativeExpression();
                additiveExpression.MultiplicativeExpressions.Add(multiplicativeExpression);
                this.stack.Push(multiplicativeExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var additiveExpressionMultiCtxs = context.additiveExpressionMulti();
            foreach (var ctx in additiveExpressionMultiCtxs)
            {
                var additiveExpressionMulti = new AdditiveExpressionMulti();
                additiveExpression.AdditiveExpressionMultis.Add(additiveExpressionMulti);
                this.stack.Push(additiveExpressionMulti);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitMultiplicativeExpression([NotNull] SparqlParser.MultiplicativeExpressionContext context)
        {
            var multiplicativeExpression = this.stack.PeekCtx<MultiplicativeExpression>();
            multiplicativeExpression.Parse(context);

            var unaryExpressionCtx = context.unaryExpression();
            if (unaryExpressionCtx != null)
            {
                multiplicativeExpression.UnaryExpression = new UnaryExpression();
                this.stack.Push(multiplicativeExpression.UnaryExpression);
                this.Visit(unaryExpressionCtx);
                this.stack.Pop();
            }

            var multiplicativeExpressionItemCtxs = context.multiplicativeExpressionItem();
            foreach (var ctx in multiplicativeExpressionItemCtxs)
            {
                var multiplicativeExpressionItem = new MultiplicativeExpressionItem();
                multiplicativeExpression.MultiplicativeExpressionItems.Add(multiplicativeExpressionItem);
                this.stack.Push(multiplicativeExpressionItem);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAdditiveExpressionMulti([NotNull] SparqlParser.AdditiveExpressionMultiContext context)
        {
            var additiveExpressionMulti = this.stack.PeekCtx<AdditiveExpressionMulti>();
            additiveExpressionMulti.Parse(context);

            var numericLiteralPositiveCtx = context.numericLiteralPositive();
            if (numericLiteralPositiveCtx != null)
            {
                additiveExpressionMulti.NumericLiteralPositive = new NumericLiteralPositive();
                this.stack.Push(additiveExpressionMulti.NumericLiteralPositive);
                this.Visit(numericLiteralPositiveCtx);
                this.stack.Pop();
            }

            var numericLiteralNegativeCtx = context.numericLiteralNegative();
            if (numericLiteralNegativeCtx != null)
            {
                additiveExpressionMulti.NumericLiteralNegative = new NumericLiteralNegative();
                this.stack.Push(additiveExpressionMulti.NumericLiteralNegative);
                this.Visit(numericLiteralNegativeCtx);
                this.stack.Pop();
            }

            var multiplicativeExpressionItemCtxs = context.multiplicativeExpressionItem();
            foreach (var ctx in multiplicativeExpressionItemCtxs)
            {
                var multiplicativeExpressionItem = new MultiplicativeExpressionItem();
                additiveExpressionMulti.MultiplicativeExpressionItems.Add(multiplicativeExpressionItem);
                this.stack.Push(multiplicativeExpressionItem);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitMultiplicativeExpressionItem([NotNull] SparqlParser.MultiplicativeExpressionItemContext context)
        {
            var multiplicativeExpressionItem = this.stack.PeekCtx<MultiplicativeExpressionItem>();
            multiplicativeExpressionItem.Parse(context);

            var unaryExpressionCtxs = context.unaryExpression();
            foreach (var ctx in unaryExpressionCtxs)
            {
                var unaryExpression = new UnaryExpression();
                multiplicativeExpressionItem.UnaryExpressions.Add(unaryExpression);
                this.stack.Push(unaryExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitUnaryExpression([NotNull] SparqlParser.UnaryExpressionContext context)
        {
            var unaryExpression = this.stack.PeekCtx<UnaryExpression>();
            unaryExpression.Parse(context);

            var primaryExpressionCtxs = context.primaryExpression();
            foreach (var ctx in primaryExpressionCtxs)
            {
                var primaryExpression = new PrimaryExpression();
                unaryExpression.PrimaryExpressions.Add(primaryExpression);
                this.stack.Push(primaryExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPrimaryExpression([NotNull] SparqlParser.PrimaryExpressionContext context)
        {
            var primaryExpression = this.stack.PeekCtx<PrimaryExpression>();
            primaryExpression.Parse(context);

            var brackettedExpressionCtx = context.brackettedExpression();
            if (brackettedExpressionCtx != null)
            {
                primaryExpression.BrackettedExpression = new BrackettedExpression();
                this.stack.Push(primaryExpression.BrackettedExpression);
                this.Visit(brackettedExpressionCtx);
                this.stack.Pop();
            }

            var builtInCallCtx = context.builtInCall();
            if (builtInCallCtx != null)
            {
                primaryExpression.BuiltInCall = new BuiltInCall();
                this.stack.Push(primaryExpression.BuiltInCall);
                this.Visit(builtInCallCtx);
                this.stack.Pop();
            }

            var iriOrFunctionCtx = context.iriOrFunction();
            if (iriOrFunctionCtx != null)
            {
                primaryExpression.IriOrFunction = new IriOrFunction();
                this.stack.Push(primaryExpression.IriOrFunction);
                this.Visit(iriOrFunctionCtx);
                this.stack.Pop();
            }

            var rDFLiteralCtx = context.rDFLiteral();
            if (rDFLiteralCtx != null)
            {
                primaryExpression.RDFLiteral = new RDFLiteral();
                this.stack.Push(primaryExpression.RDFLiteral);
                this.Visit(rDFLiteralCtx);
                this.stack.Pop();
            }

            var numericLiteralCtx = context.numericLiteral();
            if (numericLiteralCtx != null)
            {
                primaryExpression.NumericLiteral = new NumericLiteral();
                this.stack.Push(primaryExpression.NumericLiteral);
                this.Visit(numericLiteralCtx);
                this.stack.Pop();
            }

            var booleanLiteralCtx = context.booleanLiteral();
            if (booleanLiteralCtx != null)
            {
                primaryExpression.BooleanLiteral = new BooleanLiteral();
                this.stack.Push(primaryExpression.BooleanLiteral);
                this.Visit(booleanLiteralCtx);
                this.stack.Pop();
            }

            var varCtx = context.var();
            if (varCtx != null)
            {
                primaryExpression.Var = new Var();
                this.stack.Push(primaryExpression.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBrackettedExpression([NotNull] SparqlParser.BrackettedExpressionContext context)
        {
            var brackettedExpression = this.stack.PeekCtx<BrackettedExpression>();
            brackettedExpression.Parse(context);

            var expressionCtx = context.expression();
            if (expressionCtx != null)
            {
                brackettedExpression.Expression = new Expression();
                this.stack.Push(brackettedExpression.Expression);
                this.Visit(expressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBuiltInCall([NotNull] SparqlParser.BuiltInCallContext context)
        {
            var builtInCall = this.stack.PeekCtx<BuiltInCall>();
            builtInCall.Parse(context);

            var aggregateCtx = context.aggregate();
            if (aggregateCtx != null)
            {
                builtInCall.Aggregate = new Aggregate();
                this.stack.Push(builtInCall.Aggregate);
                this.Visit(aggregateCtx);
                this.stack.Pop();
            }

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                builtInCall.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var varCtx = context.var();
            if (varCtx != null)
            {
                builtInCall.Var = new Var();
                this.stack.Push(builtInCall.Var);
                this.Visit(varCtx);
                this.stack.Pop();
            }

            var expressionListCtxs = context.expressionList();
            foreach (var ctx in expressionListCtxs)
            {
                var expressionList = new ExpressionList();
                builtInCall.ExpressionLists.Add(expressionList);
                this.stack.Push(expressionList);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var substringExpressionCtx = context.substringExpression();
            if (substringExpressionCtx != null)
            {
                builtInCall.SubstringExpression = new SubstringExpression();
                this.stack.Push(builtInCall.SubstringExpression);
                this.Visit(substringExpressionCtx);
                this.stack.Pop();
            }

            var strReplaceExpressionCtx = context.strReplaceExpression();
            if (strReplaceExpressionCtx != null)
            {
                builtInCall.StrReplaceExpression = new StrReplaceExpression();
                this.stack.Push(builtInCall.StrReplaceExpression);
                this.Visit(strReplaceExpressionCtx);
                this.stack.Pop();
            }

            var regexExpressionCtx = context.regexExpression();
            if (regexExpressionCtx != null)
            {
                builtInCall.RegexExpression = new RegexExpression();
                this.stack.Push(builtInCall.RegexExpression);
                this.Visit(regexExpressionCtx);
                this.stack.Pop();
            }

            var existsFuncCtx = context.existsFunc();
            if (existsFuncCtx != null)
            {
                builtInCall.ExistsFunc = new ExistsFunc();
                this.stack.Push(builtInCall.ExistsFunc);
                this.Visit(existsFuncCtx);
                this.stack.Pop();
            }

            var notExistsFuncCtx = context.notExistsFunc();
            if (notExistsFuncCtx != null)
            {
                builtInCall.NotExistsFunc = new NotExistsFunc();
                this.stack.Push(builtInCall.NotExistsFunc);
                this.Visit(notExistsFuncCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRegexExpression([NotNull] SparqlParser.RegexExpressionContext context)
        {
            var regexExpression = this.stack.PeekCtx<RegexExpression>();
            regexExpression.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                regexExpression.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubstringExpression([NotNull] SparqlParser.SubstringExpressionContext context)
        {
            var substringExpression = this.stack.PeekCtx<SubstringExpression>();
            substringExpression.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                substringExpression.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitStrReplaceExpression([NotNull] SparqlParser.StrReplaceExpressionContext context)
        {
            var strReplaceExpression = this.stack.PeekCtx<StrReplaceExpression>();
            strReplaceExpression.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                strReplaceExpression.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitExistsFunc([NotNull] SparqlParser.ExistsFuncContext context)
        {
            var existsFunc = this.stack.PeekCtx<ExistsFunc>();
            existsFunc.Parse(context);

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                existsFunc.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(existsFunc.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNotExistsFunc([NotNull] SparqlParser.NotExistsFuncContext context)
        {
            var notExistsFunc = this.stack.PeekCtx<NotExistsFunc>();
            notExistsFunc.Parse(context);

            var groupGraphPatternCtx = context.groupGraphPattern();
            if (groupGraphPatternCtx != null)
            {
                notExistsFunc.GroupGraphPattern = new GroupGraphPattern();
                this.stack.Push(notExistsFunc.GroupGraphPattern);
                this.Visit(groupGraphPatternCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAggregate([NotNull] SparqlParser.AggregateContext context)
        {
            var aggregate = this.stack.PeekCtx<Aggregate>();
            aggregate.Parse(context);

            var expressionCtxs = context.expression();
            foreach (var ctx in expressionCtxs)
            {
                var expression = new Expression();
                aggregate.Expressions.Add(expression);
                this.stack.Push(expression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var string_Ctx = context.string_();
            if (string_Ctx != null)
            {
                aggregate.String = new String();
                this.stack.Push(aggregate.String);
                this.Visit(string_Ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitIriOrFunction([NotNull] SparqlParser.IriOrFunctionContext context)
        {
            var iriOrFunction = this.stack.PeekCtx<IriOrFunction>();
            iriOrFunction.Parse(context);

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                iriOrFunction.Iri = new Iri();
                this.stack.Push(iriOrFunction.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            var argListCtx = context.argList();
            if (argListCtx != null)
            {
                iriOrFunction.ArgList = new ArgList();
                this.stack.Push(iriOrFunction.ArgList);
                this.Visit(argListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRDFLiteral([NotNull] SparqlParser.RDFLiteralContext context)
        {
            var rDFLiteral = this.stack.PeekCtx<RDFLiteral>();
            rDFLiteral.Parse(context);

            var string_Ctx = context.string_();
            if (string_Ctx != null)
            {
                rDFLiteral.String = new String();
                this.stack.Push(rDFLiteral.String);
                this.Visit(string_Ctx);
                this.stack.Pop();
            }

            var iriCtx = context.iri();
            if (iriCtx != null)
            {
                rDFLiteral.Iri = new Iri();
                this.stack.Push(rDFLiteral.Iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNumericLiteral([NotNull] SparqlParser.NumericLiteralContext context)
        {
            var numericLiteral = this.stack.PeekCtx<NumericLiteral>();
            numericLiteral.Parse(context);

            var numericLiteralUnsignedCtx = context.numericLiteralUnsigned();
            if (numericLiteralUnsignedCtx != null)
            {
                numericLiteral.NumericLiteralUnsigned = new NumericLiteralUnsigned();
                this.stack.Push(numericLiteral.NumericLiteralUnsigned);
                this.Visit(numericLiteralUnsignedCtx);
                this.stack.Pop();
            }

            var numericLiteralPositiveCtx = context.numericLiteralPositive();
            if (numericLiteralPositiveCtx != null)
            {
                numericLiteral.NumericLiteralPositive = new NumericLiteralPositive();
                this.stack.Push(numericLiteral.NumericLiteralPositive);
                this.Visit(numericLiteralPositiveCtx);
                this.stack.Pop();
            }

            var numericLiteralNegativeCtx = context.numericLiteralNegative();
            if (numericLiteralNegativeCtx != null)
            {
                numericLiteral.NumericLiteralNegative = new NumericLiteralNegative();
                this.stack.Push(numericLiteral.NumericLiteralNegative);
                this.Visit(numericLiteralNegativeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNumericLiteralUnsigned([NotNull] SparqlParser.NumericLiteralUnsignedContext context)
        {
            var numericLiteralUnsigned = this.stack.PeekCtx<NumericLiteralUnsigned>();
            numericLiteralUnsigned.Parse(context);

            return 0;
        }

        public override int VisitNumericLiteralPositive([NotNull] SparqlParser.NumericLiteralPositiveContext context)
        {
            var numericLiteralPositive = this.stack.PeekCtx<NumericLiteralPositive>();
            numericLiteralPositive.Parse(context);

            return 0;
        }

        public override int VisitNumericLiteralNegative([NotNull] SparqlParser.NumericLiteralNegativeContext context)
        {
            var numericLiteralNegative = this.stack.PeekCtx<NumericLiteralNegative>();
            numericLiteralNegative.Parse(context);

            return 0;
        }

        public override int VisitBooleanLiteral([NotNull] SparqlParser.BooleanLiteralContext context)
        {
            var booleanLiteral = this.stack.PeekCtx<BooleanLiteral>();
            booleanLiteral.Parse(context);

            return 0;
        }

        public override int VisitString([NotNull] SparqlParser.StringContext context)
        {
            var string_ = this.stack.PeekCtx<String>();
            string_.Parse(context);

            return 0;
        }

        public override int VisitIri([NotNull] SparqlParser.IriContext context)
        {
            var iri = this.stack.PeekCtx<Iri>();
            iri.Parse(context);

            var prefixedNameCtx = context.prefixedName();
            if (prefixedNameCtx != null)
            {
                iri.PrefixedName = new PrefixedName();
                this.stack.Push(iri.PrefixedName);
                this.Visit(prefixedNameCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPrefixedName([NotNull] SparqlParser.PrefixedNameContext context)
        {
            var prefixedName = this.stack.PeekCtx<PrefixedName>();
            prefixedName.Parse(context);

            return 0;
        }

        public override int VisitBlankNode([NotNull] SparqlParser.BlankNodeContext context)
        {
            var blankNode = this.stack.PeekCtx<BlankNode>();
            blankNode.Parse(context);

            return 0;
        }

    }
}
