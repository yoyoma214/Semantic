using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Common;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class QueryUnit : TokenPair
    {
        public List<ParseErrorInfo> Errors
        {
            get;
            set;
        }

        public QueryUnit()
        {
            Errors = new List<ParseErrorInfo>();
        }

        public Query Query
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Query != null)
            {
                this.Query.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Query != null)
            {
                this.Query.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Query != null)
            {
                this.Query.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Query != null)
            {
                this.Query.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Query != null)
            {
                this.Query.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Query != null)
            {
                this.Query.BuildOther(context, builder);
            }

        }
    }

    public class Query : TokenPair
    {
        public Query()
        {
        }
        public Prologue Prologue
        { get; set; }
        public SelectQuery SelectQuery
        { get; set; }
        public ConstructQuery ConstructQuery
        { get; set; }
        public DescribeQuery DescribeQuery
        { get; set; }
        public AskQuery AskQuery
        { get; set; }
        public ValuesClause ValuesClause
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Parse(context);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.Parse(context);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.Parse(context);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.Parse(context);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.Parse(context);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Wise(context);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.Wise(context);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.Wise(context);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.Wise(context);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.Wise(context);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Format(context, builder);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.Format(context, builder);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.Format(context, builder);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.Format(context, builder);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.Format(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildQuery(context, builder);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.BuildQuery(context, builder);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.BuildQuery(context, builder);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.BuildQuery(context, builder);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.BuildQuery(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildMock(context, builder);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.BuildMock(context, builder);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.BuildMock(context, builder);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.BuildMock(context, builder);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.BuildMock(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildOther(context, builder);
            }

            if (this.SelectQuery != null)
            {
                this.SelectQuery.BuildOther(context, builder);
            }

            if (this.ConstructQuery != null)
            {
                this.ConstructQuery.BuildOther(context, builder);
            }

            if (this.DescribeQuery != null)
            {
                this.DescribeQuery.BuildOther(context, builder);
            }

            if (this.AskQuery != null)
            {
                this.AskQuery.BuildOther(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildOther(context, builder);
            }

        }
    }

    public class UpdateUnit : TokenPair
    {
        public UpdateUnit()
        {
        }
        public Update Update
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Update != null)
            {
                this.Update.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Update != null)
            {
                this.Update.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Update != null)
            {
                this.Update.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Update != null)
            {
                this.Update.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Update != null)
            {
                this.Update.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Update != null)
            {
                this.Update.BuildOther(context, builder);
            }

        }
    }

    public class Prologue : TokenPair
    {
        public Prologue()
        {
            this.BaseDecls = new List<BaseDecl>();
            this.PrefixDecls = new List<PrefixDecl>();
        }
        public List<BaseDecl> BaseDecls
        { get; set; }
        public List<PrefixDecl> PrefixDecls
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].Parse(context);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].Wise(context);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].Format(context, builder);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.BaseDecls.Count(); i++)
            {
                this.BaseDecls[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.PrefixDecls.Count(); i++)
            {
                this.PrefixDecls[i].BuildOther(context, builder);
            }

        }
    }

    public class BaseDecl : TokenPair
    {
        public BaseDecl()
        {
        }
        public String BASE
        { get; set; }
        public String IRIREF
        { get; set; }

        public void Parse(SparqlContext context)
        {
            if (context.Base != null)
            {
                context.AddError(this, "Base已经重复");
                return;
            }

            context.Base = new Base() { Value = this.IRIREF };
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class PrefixDecl : TokenPair
    {
        public PrefixDecl()
        {
        }
        public String PREFIX
        { get; set; }
        public String PNAMENS
        { get; set; }
        public String IRIREF
        { get; set; }

        public void Parse(SparqlContext context)
        {
            var prefix = new Prefix() { Name = this.PNAMENS, Value = this.IRIREF };

            foreach (var pre in context.Prefixs)
            {
                if (pre.EqualWith(prefix))
                {
                    context.AddError(this, "重复:" + this.PNAMENS);
                    return;
                }
            }

            context.Prefixs.Add(prefix);
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class SelectQuery : TokenPair
    {
        public SelectQuery()
        {
            this.DatasetClauses = new List<DatasetClause>();
        }
        public SelectClause SelectClause
        { get; set; }
        public List<DatasetClause> DatasetClauses
        { get; set; }
        public WhereClause WhereClause
        { get; set; }
        public SolutionModifier SolutionModifier
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Parse(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Parse(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Parse(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Wise(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Wise(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Wise(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Format(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Format(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Format(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildQuery(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildQuery(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildMock(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildMock(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildOther(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildOther(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildOther(context, builder);
            }

        }
    }

    public class SubSelect : TokenPair
    {
        public SubSelect()
        {
        }
        public SelectClause SelectClause
        { get; set; }
        public WhereClause WhereClause
        { get; set; }
        public SolutionModifier SolutionModifier
        { get; set; }
        public ValuesClause ValuesClause
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Parse(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Parse(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Parse(context);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Wise(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Wise(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Wise(context);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.Format(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Format(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Format(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildQuery(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildQuery(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildQuery(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildMock(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildMock(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildMock(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SelectClause != null)
            {
                this.SelectClause.BuildOther(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildOther(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildOther(context, builder);
            }

            if (this.ValuesClause != null)
            {
                this.ValuesClause.BuildOther(context, builder);
            }

        }
    }

    public class SelectClause : TokenPair
    {
        public SelectClause()
        {
            this.Vars = new List<Var>();
            this.Expressions = new List<Expression>();
            this.ASs = new List<String>();
        }
        public String SELECT
        { get; set; }
        public String DISTINCT
        { get; set; }
        public String REDUCED
        { get; set; }
        public List<Var> Vars
        { get; set; }
        public List<Expression> Expressions
        { get; set; }
        public List<String> ASs
        { get; set; }
        public String ALL
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Parse(context);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Wise(context);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Format(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ConstructQuery : TokenPair
    {
        public ConstructQuery()
        {
            this.DatasetClauses = new List<DatasetClause>();
            this.SolutionModifiers = new List<SolutionModifier>();
        }
        public String CONSTRUCT
        { get; set; }
        public ConstructTemplate ConstructTemplate
        { get; set; }
        public List<DatasetClause> DatasetClauses
        { get; set; }
        public WhereClause WhereClause
        { get; set; }
        public List<SolutionModifier> SolutionModifiers
        { get; set; }
        public String WHERE
        { get; set; }
        public TriplesTemplate TriplesTemplate
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.Parse(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Parse(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Parse(context);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].Parse(context);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.Wise(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Wise(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Wise(context);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].Wise(context);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.Format(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Format(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Format(context, builder);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].Format(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildQuery(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].BuildQuery(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildMock(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildMock(context, builder);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].BuildMock(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTemplate != null)
            {
                this.ConstructTemplate.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildOther(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildOther(context, builder);
            }

            for (int i = 0; i < this.SolutionModifiers.Count(); i++)
            {
                this.SolutionModifiers[i].BuildOther(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildOther(context, builder);
            }

        }
    }

    public class DescribeQuery : TokenPair
    {
        public DescribeQuery()
        {
            this.VarOrIris = new List<VarOrIri>();
            this.DatasetClauses = new List<DatasetClause>();
        }
        public String DESCRIBE
        { get; set; }
        public List<VarOrIri> VarOrIris
        { get; set; }
        public String ALL
        { get; set; }
        public List<DatasetClause> DatasetClauses
        { get; set; }
        public WhereClause WhereClause
        { get; set; }
        public SolutionModifier SolutionModifier
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].Parse(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Parse(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Parse(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].Wise(context);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Wise(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Wise(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].Format(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Format(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Format(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildQuery(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildQuery(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildMock(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildMock(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VarOrIris.Count(); i++)
            {
                this.VarOrIris[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildOther(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildOther(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildOther(context, builder);
            }

        }
    }

    public class AskQuery : TokenPair
    {
        public AskQuery()
        {
            this.DatasetClauses = new List<DatasetClause>();
        }
        public String ASK
        { get; set; }
        public List<DatasetClause> DatasetClauses
        { get; set; }
        public WhereClause WhereClause
        { get; set; }
        public SolutionModifier SolutionModifier
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Parse(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Parse(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Wise(context);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Wise(context);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].Format(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.Format(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildQuery(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildQuery(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildMock(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildMock(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DatasetClauses.Count(); i++)
            {
                this.DatasetClauses[i].BuildOther(context, builder);
            }

            if (this.WhereClause != null)
            {
                this.WhereClause.BuildOther(context, builder);
            }

            if (this.SolutionModifier != null)
            {
                this.SolutionModifier.BuildOther(context, builder);
            }

        }
    }

    public class DatasetClause : TokenPair
    {
        public DatasetClause()
        {
        }
        public String FROM
        { get; set; }
        public DefaultGraphClause DefaultGraphClause
        { get; set; }
        public NamedGraphClause NamedGraphClause
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.Parse(context);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.Wise(context);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.Format(context, builder);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.BuildQuery(context, builder);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.BuildMock(context, builder);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DefaultGraphClause != null)
            {
                this.DefaultGraphClause.BuildOther(context, builder);
            }

            if (this.NamedGraphClause != null)
            {
                this.NamedGraphClause.BuildOther(context, builder);
            }

        }
    }

    public class DefaultGraphClause : TokenPair
    {
        public DefaultGraphClause()
        {
        }
        public SourceSelector SourceSelector
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildOther(context, builder);
            }

        }
    }

    public class NamedGraphClause : TokenPair
    {
        public NamedGraphClause()
        {
        }
        public String NAMED
        { get; set; }
        public SourceSelector SourceSelector
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SourceSelector != null)
            {
                this.SourceSelector.BuildOther(context, builder);
            }

        }
    }

    public class SourceSelector : TokenPair
    {
        public SourceSelector()
        {
        }
        public Iri Iri
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

        }
    }

    public class WhereClause : TokenPair
    {
        public WhereClause()
        {
        }
        public String WHERE
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class SolutionModifier : TokenPair
    {
        public SolutionModifier()
        {
        }
        public GroupClause GroupClause
        { get; set; }
        public HavingClause HavingClause
        { get; set; }
        public OrderClause OrderClause
        { get; set; }
        public LimitOffsetClauses LimitOffsetClauses
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.Parse(context);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.Parse(context);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.Parse(context);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.Wise(context);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.Wise(context);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.Wise(context);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.Format(context, builder);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.Format(context, builder);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.Format(context, builder);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.BuildQuery(context, builder);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.BuildQuery(context, builder);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.BuildQuery(context, builder);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.BuildMock(context, builder);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.BuildMock(context, builder);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.BuildMock(context, builder);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupClause != null)
            {
                this.GroupClause.BuildOther(context, builder);
            }

            if (this.HavingClause != null)
            {
                this.HavingClause.BuildOther(context, builder);
            }

            if (this.OrderClause != null)
            {
                this.OrderClause.BuildOther(context, builder);
            }

            if (this.LimitOffsetClauses != null)
            {
                this.LimitOffsetClauses.BuildOther(context, builder);
            }

        }
    }

    public class GroupClause : TokenPair
    {
        public GroupClause()
        {
            this.GroupConditions = new List<GroupCondition>();
        }
        public String GROUP
        { get; set; }
        public String BY
        { get; set; }
        public List<GroupCondition> GroupConditions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupConditions.Count(); i++)
            {
                this.GroupConditions[i].BuildOther(context, builder);
            }

        }
    }

    public class GroupCondition : TokenPair
    {
        public GroupCondition()
        {
            this.Vars = new List<Var>();
        }
        public BuiltInCall BuiltInCall
        { get; set; }
        public FunctionCall FunctionCall
        { get; set; }
        public Expression Expression
        { get; set; }
        public String AS
        { get; set; }
        public List<Var> Vars
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Parse(context);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Parse(context);
            }

            if (this.Expression != null)
            {
                this.Expression.Parse(context);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Wise(context);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Wise(context);
            }

            if (this.Expression != null)
            {
                this.Expression.Wise(context);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Format(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Format(context, builder);
            }

            if (this.Expression != null)
            {
                this.Expression.Format(context, builder);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildQuery(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildQuery(context, builder);
            }

            if (this.Expression != null)
            {
                this.Expression.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildMock(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildMock(context, builder);
            }

            if (this.Expression != null)
            {
                this.Expression.BuildMock(context, builder);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildOther(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildOther(context, builder);
            }

            if (this.Expression != null)
            {
                this.Expression.BuildOther(context, builder);
            }

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildOther(context, builder);
            }

        }
    }

    public class HavingClause : TokenPair
    {
        public HavingClause()
        {
            this.HavingConditions = new List<HavingCondition>();
        }
        public String HAVING
        { get; set; }
        public List<HavingCondition> HavingConditions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.HavingConditions.Count(); i++)
            {
                this.HavingConditions[i].BuildOther(context, builder);
            }

        }
    }

    public class HavingCondition : TokenPair
    {
        public HavingCondition()
        {
        }
        public Constraint Constraint
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildOther(context, builder);
            }

        }
    }

    public class OrderClause : TokenPair
    {
        public OrderClause()
        {
            this.OrderConditions = new List<OrderCondition>();
        }
        public String ORDER
        { get; set; }
        public String BY
        { get; set; }
        public List<OrderCondition> OrderConditions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.OrderConditions.Count(); i++)
            {
                this.OrderConditions[i].BuildOther(context, builder);
            }

        }
    }

    public class OrderCondition : TokenPair
    {
        public OrderCondition()
        {
        }
        public String ASC
        { get; set; }
        public String DESC
        { get; set; }
        public BrackettedExpression BrackettedExpression
        { get; set; }
        public Constraint Constraint
        { get; set; }
        public Var Var
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Parse(context);
            }

            if (this.Constraint != null)
            {
                this.Constraint.Parse(context);
            }

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Wise(context);
            }

            if (this.Constraint != null)
            {
                this.Constraint.Wise(context);
            }

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Format(context, builder);
            }

            if (this.Constraint != null)
            {
                this.Constraint.Format(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildQuery(context, builder);
            }

            if (this.Constraint != null)
            {
                this.Constraint.BuildQuery(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildMock(context, builder);
            }

            if (this.Constraint != null)
            {
                this.Constraint.BuildMock(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildOther(context, builder);
            }

            if (this.Constraint != null)
            {
                this.Constraint.BuildOther(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

        }
    }

    public class LimitOffsetClauses : TokenPair
    {
        public LimitOffsetClauses()
        {
            this.LimitClauses = new List<LimitClause>();
            this.OffsetClauses = new List<OffsetClause>();
        }
        public List<LimitClause> LimitClauses
        { get; set; }
        public List<OffsetClause> OffsetClauses
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].Parse(context);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].Wise(context);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].Format(context, builder);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.LimitClauses.Count(); i++)
            {
                this.LimitClauses[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.OffsetClauses.Count(); i++)
            {
                this.OffsetClauses[i].BuildOther(context, builder);
            }

        }
    }

    public class LimitClause : TokenPair
    {
        public LimitClause()
        {
        }
        public String LIMIT
        { get; set; }
        public String INTEGER
        { get; set; }

        public void Parse(SparqlContext context)
        {

        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class OffsetClause : TokenPair
    {
        public OffsetClause()
        {
        }
        public String OFFSET
        { get; set; }
        public String INTEGER
        { get; set; }

        public void Parse(SparqlContext context)
        {

        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class ValuesClause : TokenPair
    {
        public ValuesClause()
        {
        }
        public String VALUES
        { get; set; }
        public DataBlock DataBlock
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildOther(context, builder);
            }

        }
    }

    public class Update : TokenPair
    {
        public Update()
        {
        }
        public Prologue Prologue
        { get; set; }
        public Update1 Update1
        { get; set; }
        public Update Update0
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Parse(context);
            }

            if (this.Update1 != null)
            {
                this.Update1.Parse(context);
            }

            if (this.Update0 != null)
            {
                this.Update0.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Wise(context);
            }

            if (this.Update1 != null)
            {
                this.Update1.Wise(context);
            }

            if (this.Update0 != null)
            {
                this.Update0.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.Format(context, builder);
            }

            if (this.Update1 != null)
            {
                this.Update1.Format(context, builder);
            }

            if (this.Update0 != null)
            {
                this.Update0.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildQuery(context, builder);
            }

            if (this.Update1 != null)
            {
                this.Update1.BuildQuery(context, builder);
            }

            if (this.Update0 != null)
            {
                this.Update0.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildMock(context, builder);
            }

            if (this.Update1 != null)
            {
                this.Update1.BuildMock(context, builder);
            }

            if (this.Update0 != null)
            {
                this.Update0.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Prologue != null)
            {
                this.Prologue.BuildOther(context, builder);
            }

            if (this.Update1 != null)
            {
                this.Update1.BuildOther(context, builder);
            }

            if (this.Update0 != null)
            {
                this.Update0.BuildOther(context, builder);
            }

        }
    }

    public class Update1 : TokenPair
    {
        public Update1()
        {
        }
        public Load Load
        { get; set; }
        public Clear Clear
        { get; set; }
        public Drop Drop
        { get; set; }
        public Add Add
        { get; set; }
        public Move Move
        { get; set; }
        public Copy Copy
        { get; set; }
        public Create Create
        { get; set; }
        public InsertData InsertData
        { get; set; }
        public DeleteData DeleteData
        { get; set; }
        public DeleteWhere DeleteWhere
        { get; set; }
        public Modify Modify
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Load != null)
            {
                this.Load.Parse(context);
            }

            if (this.Clear != null)
            {
                this.Clear.Parse(context);
            }

            if (this.Drop != null)
            {
                this.Drop.Parse(context);
            }

            if (this.Add != null)
            {
                this.Add.Parse(context);
            }

            if (this.Move != null)
            {
                this.Move.Parse(context);
            }

            if (this.Copy != null)
            {
                this.Copy.Parse(context);
            }

            if (this.Create != null)
            {
                this.Create.Parse(context);
            }

            if (this.InsertData != null)
            {
                this.InsertData.Parse(context);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.Parse(context);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.Parse(context);
            }

            if (this.Modify != null)
            {
                this.Modify.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Load != null)
            {
                this.Load.Wise(context);
            }

            if (this.Clear != null)
            {
                this.Clear.Wise(context);
            }

            if (this.Drop != null)
            {
                this.Drop.Wise(context);
            }

            if (this.Add != null)
            {
                this.Add.Wise(context);
            }

            if (this.Move != null)
            {
                this.Move.Wise(context);
            }

            if (this.Copy != null)
            {
                this.Copy.Wise(context);
            }

            if (this.Create != null)
            {
                this.Create.Wise(context);
            }

            if (this.InsertData != null)
            {
                this.InsertData.Wise(context);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.Wise(context);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.Wise(context);
            }

            if (this.Modify != null)
            {
                this.Modify.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Load != null)
            {
                this.Load.Format(context, builder);
            }

            if (this.Clear != null)
            {
                this.Clear.Format(context, builder);
            }

            if (this.Drop != null)
            {
                this.Drop.Format(context, builder);
            }

            if (this.Add != null)
            {
                this.Add.Format(context, builder);
            }

            if (this.Move != null)
            {
                this.Move.Format(context, builder);
            }

            if (this.Copy != null)
            {
                this.Copy.Format(context, builder);
            }

            if (this.Create != null)
            {
                this.Create.Format(context, builder);
            }

            if (this.InsertData != null)
            {
                this.InsertData.Format(context, builder);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.Format(context, builder);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.Format(context, builder);
            }

            if (this.Modify != null)
            {
                this.Modify.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Load != null)
            {
                this.Load.BuildQuery(context, builder);
            }

            if (this.Clear != null)
            {
                this.Clear.BuildQuery(context, builder);
            }

            if (this.Drop != null)
            {
                this.Drop.BuildQuery(context, builder);
            }

            if (this.Add != null)
            {
                this.Add.BuildQuery(context, builder);
            }

            if (this.Move != null)
            {
                this.Move.BuildQuery(context, builder);
            }

            if (this.Copy != null)
            {
                this.Copy.BuildQuery(context, builder);
            }

            if (this.Create != null)
            {
                this.Create.BuildQuery(context, builder);
            }

            if (this.InsertData != null)
            {
                this.InsertData.BuildQuery(context, builder);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.BuildQuery(context, builder);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.BuildQuery(context, builder);
            }

            if (this.Modify != null)
            {
                this.Modify.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Load != null)
            {
                this.Load.BuildMock(context, builder);
            }

            if (this.Clear != null)
            {
                this.Clear.BuildMock(context, builder);
            }

            if (this.Drop != null)
            {
                this.Drop.BuildMock(context, builder);
            }

            if (this.Add != null)
            {
                this.Add.BuildMock(context, builder);
            }

            if (this.Move != null)
            {
                this.Move.BuildMock(context, builder);
            }

            if (this.Copy != null)
            {
                this.Copy.BuildMock(context, builder);
            }

            if (this.Create != null)
            {
                this.Create.BuildMock(context, builder);
            }

            if (this.InsertData != null)
            {
                this.InsertData.BuildMock(context, builder);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.BuildMock(context, builder);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.BuildMock(context, builder);
            }

            if (this.Modify != null)
            {
                this.Modify.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Load != null)
            {
                this.Load.BuildOther(context, builder);
            }

            if (this.Clear != null)
            {
                this.Clear.BuildOther(context, builder);
            }

            if (this.Drop != null)
            {
                this.Drop.BuildOther(context, builder);
            }

            if (this.Add != null)
            {
                this.Add.BuildOther(context, builder);
            }

            if (this.Move != null)
            {
                this.Move.BuildOther(context, builder);
            }

            if (this.Copy != null)
            {
                this.Copy.BuildOther(context, builder);
            }

            if (this.Create != null)
            {
                this.Create.BuildOther(context, builder);
            }

            if (this.InsertData != null)
            {
                this.InsertData.BuildOther(context, builder);
            }

            if (this.DeleteData != null)
            {
                this.DeleteData.BuildOther(context, builder);
            }

            if (this.DeleteWhere != null)
            {
                this.DeleteWhere.BuildOther(context, builder);
            }

            if (this.Modify != null)
            {
                this.Modify.BuildOther(context, builder);
            }

        }
    }

    public class Load : TokenPair
    {
        public Load()
        {
        }
        public String LOAD
        { get; set; }
        public String SILENT
        { get; set; }
        public Iri Iri
        { get; set; }
        public String INTO
        { get; set; }
        public GraphRef GraphRef
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildOther(context, builder);
            }

        }
    }

    public class Clear : TokenPair
    {
        public Clear()
        {
        }
        public String CLEAR
        { get; set; }
        public String SILENT
        { get; set; }
        public GraphRefAll GraphRefAll
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildOther(context, builder);
            }

        }
    }

    public class Drop : TokenPair
    {
        public Drop()
        {
        }
        public String DROP
        { get; set; }
        public String SILENT
        { get; set; }
        public GraphRefAll GraphRefAll
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRefAll != null)
            {
                this.GraphRefAll.BuildOther(context, builder);
            }

        }
    }

    public class Create : TokenPair
    {
        public Create()
        {
        }
        public String CREATE
        { get; set; }
        public String SILENT
        { get; set; }
        public GraphRef GraphRef
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildOther(context, builder);
            }

        }
    }

    public class Add : TokenPair
    {
        public Add()
        {
            this.GraphOrDefaults = new List<GraphOrDefault>();
        }
        public String ADD
        { get; set; }
        public String SILENT
        { get; set; }
        public List<GraphOrDefault> GraphOrDefaults
        { get; set; }
        public String TO
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildOther(context, builder);
            }

        }
    }

    public class Move : TokenPair
    {
        public Move()
        {
            this.GraphOrDefaults = new List<GraphOrDefault>();
        }
        public String MOVE
        { get; set; }
        public String SILENT
        { get; set; }
        public List<GraphOrDefault> GraphOrDefaults
        { get; set; }
        public String TO
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildOther(context, builder);
            }

        }
    }

    public class Copy : TokenPair
    {
        public Copy()
        {
            this.GraphOrDefaults = new List<GraphOrDefault>();
        }
        public String COPY
        { get; set; }
        public String SILENT
        { get; set; }
        public List<GraphOrDefault> GraphOrDefaults
        { get; set; }
        public String TO
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphOrDefaults.Count(); i++)
            {
                this.GraphOrDefaults[i].BuildOther(context, builder);
            }

        }
    }

    public class InsertData : TokenPair
    {
        public InsertData()
        {
        }
        public String INSERT
        { get; set; }
        public String DATA
        { get; set; }
        public QuadData QuadData
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildOther(context, builder);
            }

        }
    }

    public class DeleteData : TokenPair
    {
        public DeleteData()
        {
        }
        public String DELETE
        { get; set; }
        public String DATA
        { get; set; }
        public QuadData QuadData
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadData != null)
            {
                this.QuadData.BuildOther(context, builder);
            }

        }
    }

    public class DeleteWhere : TokenPair
    {
        public DeleteWhere()
        {
        }
        public String DELETE
        { get; set; }
        public String WHERE
        { get; set; }
        public QuadPattern QuadPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildOther(context, builder);
            }

        }
    }

    public class Modify : TokenPair
    {
        public Modify()
        {
            this.InsertClauses = new List<InsertClause>();
            this.UsingClauses = new List<UsingClause>();
        }
        public String WITH
        { get; set; }
        public Iri Iri
        { get; set; }
        public DeleteClause DeleteClause
        { get; set; }
        public List<InsertClause> InsertClauses
        { get; set; }
        public List<UsingClause> UsingClauses
        { get; set; }
        public String WHERE
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.Parse(context);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].Parse(context);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].Parse(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.Wise(context);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].Wise(context);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].Wise(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.Format(context, builder);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].Format(context, builder);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].Format(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].BuildQuery(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.BuildMock(context, builder);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].BuildMock(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.DeleteClause != null)
            {
                this.DeleteClause.BuildOther(context, builder);
            }

            for (int i = 0; i < this.InsertClauses.Count(); i++)
            {
                this.InsertClauses[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.UsingClauses.Count(); i++)
            {
                this.UsingClauses[i].BuildOther(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class DeleteClause : TokenPair
    {
        public DeleteClause()
        {
        }
        public String DELETE
        { get; set; }
        public QuadPattern QuadPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildOther(context, builder);
            }

        }
    }

    public class InsertClause : TokenPair
    {
        public InsertClause()
        {
        }
        public String INSERT
        { get; set; }
        public QuadPattern QuadPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.QuadPattern != null)
            {
                this.QuadPattern.BuildOther(context, builder);
            }

        }
    }

    public class UsingClause : TokenPair
    {
        public UsingClause()
        {
            this.Iris = new List<Iri>();
        }
        public String USING
        { get; set; }
        public List<Iri> Iris
        { get; set; }
        public String NAMED
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildOther(context, builder);
            }

        }
    }

    public class GraphOrDefault : TokenPair
    {
        public GraphOrDefault()
        {
        }
        public String DEFAULT
        { get; set; }
        public String GRAPH
        { get; set; }
        public Iri Iri
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

        }
    }

    public class GraphRef : TokenPair
    {
        public GraphRef()
        {
        }
        public String GRAPH
        { get; set; }
        public Iri Iri
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

        }
    }

    public class GraphRefAll : TokenPair
    {
        public GraphRefAll()
        {
        }
        public GraphRef GraphRef
        { get; set; }
        public String DEFAULT
        { get; set; }
        public String NAMED
        { get; set; }
        public String ALLFIELD
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphRef != null)
            {
                this.GraphRef.BuildOther(context, builder);
            }

        }
    }

    public class QuadPattern : TokenPair
    {
        public QuadPattern()
        {
        }
        public Quads Quads
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Quads != null)
            {
                this.Quads.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Quads != null)
            {
                this.Quads.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildOther(context, builder);
            }

        }
    }

    public class QuadData : TokenPair
    {
        public QuadData()
        {
        }
        public Quads Quads
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Quads != null)
            {
                this.Quads.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Quads != null)
            {
                this.Quads.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Quads != null)
            {
                this.Quads.BuildOther(context, builder);
            }

        }
    }

    public class Quads : TokenPair
    {
        public Quads()
        {
            this.TriplesTemplates = new List<TriplesTemplate>();
            this.QuadsNotTripless = new List<QuadsNotTriples>();
        }
        public List<TriplesTemplate> TriplesTemplates
        { get; set; }
        public List<QuadsNotTriples> QuadsNotTripless
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].Parse(context);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].Wise(context);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].Format(context, builder);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesTemplates.Count(); i++)
            {
                this.TriplesTemplates[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.QuadsNotTripless.Count(); i++)
            {
                this.QuadsNotTripless[i].BuildOther(context, builder);
            }

        }
    }

    public class QuadsNotTriples : TokenPair
    {
        public QuadsNotTriples()
        {
        }
        public String GRAPH
        { get; set; }
        public VarOrIri VarOrIri
        { get; set; }
        public TriplesTemplate TriplesTemplate
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Parse(context);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Wise(context);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Format(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildQuery(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildMock(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildOther(context, builder);
            }

            if (this.TriplesTemplate != null)
            {
                this.TriplesTemplate.BuildOther(context, builder);
            }

        }
    }

    public class TriplesTemplate : TokenPair
    {
        public TriplesTemplate()
        {
        }
        public TriplesSameSubject TriplesSameSubject
        { get; set; }
        public TriplesTemplate TriplesTemplate0
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Parse(context);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Wise(context);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Format(context, builder);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildQuery(context, builder);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildMock(context, builder);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildOther(context, builder);
            }

            if (this.TriplesTemplate0 != null)
            {
                this.TriplesTemplate0.BuildOther(context, builder);
            }

        }
    }

    public class GroupGraphPattern : TokenPair
    {
        public GroupGraphPattern()
        {
        }
        public SubSelect SubSelect
        { get; set; }
        public GroupGraphPatternSub GroupGraphPatternSub
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.Parse(context);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.Wise(context);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.Format(context, builder);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.BuildQuery(context, builder);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.BuildMock(context, builder);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.SubSelect != null)
            {
                this.SubSelect.BuildOther(context, builder);
            }

            if (this.GroupGraphPatternSub != null)
            {
                this.GroupGraphPatternSub.BuildOther(context, builder);
            }

        }
    }

    public class GroupGraphPatternSub : TokenPair
    {
        public GroupGraphPatternSub()
        {
            this.TriplesBlocks = new List<TriplesBlock>();
            this.GraphPatternNotTripless = new List<GraphPatternNotTriples>();
        }
        public List<TriplesBlock> TriplesBlocks
        { get; set; }
        public List<GraphPatternNotTriples> GraphPatternNotTripless
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].Parse(context);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].Wise(context);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].Format(context, builder);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.TriplesBlocks.Count(); i++)
            {
                this.TriplesBlocks[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.GraphPatternNotTripless.Count(); i++)
            {
                this.GraphPatternNotTripless[i].BuildOther(context, builder);
            }

        }
    }

    public class TriplesBlock : TokenPair
    {
        public TriplesBlock()
        {
        }
        public TriplesSameSubjectPath TriplesSameSubjectPath
        { get; set; }
        public TriplesBlock TriplesBlock0
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.Parse(context);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.Wise(context);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.Format(context, builder);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.BuildQuery(context, builder);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.BuildMock(context, builder);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubjectPath != null)
            {
                this.TriplesSameSubjectPath.BuildOther(context, builder);
            }

            if (this.TriplesBlock0 != null)
            {
                this.TriplesBlock0.BuildOther(context, builder);
            }

        }
    }

    public class GraphPatternNotTriples : TokenPair
    {
        public GraphPatternNotTriples()
        {
        }
        public GroupOrUnionGraphPattern GroupOrUnionGraphPattern
        { get; set; }
        public OptionalGraphPattern OptionalGraphPattern
        { get; set; }
        public MinusGraphPattern MinusGraphPattern
        { get; set; }
        public GraphGraphPattern GraphGraphPattern
        { get; set; }
        public ServiceGraphPattern ServiceGraphPattern
        { get; set; }
        public Filter Filter
        { get; set; }
        public Bind Bind
        { get; set; }
        public InlineData InlineData
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.Parse(context);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.Parse(context);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.Parse(context);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.Parse(context);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.Parse(context);
            }

            if (this.Filter != null)
            {
                this.Filter.Parse(context);
            }

            if (this.Bind != null)
            {
                this.Bind.Parse(context);
            }

            if (this.InlineData != null)
            {
                this.InlineData.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.Wise(context);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.Wise(context);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.Wise(context);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.Wise(context);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.Wise(context);
            }

            if (this.Filter != null)
            {
                this.Filter.Wise(context);
            }

            if (this.Bind != null)
            {
                this.Bind.Wise(context);
            }

            if (this.InlineData != null)
            {
                this.InlineData.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.Format(context, builder);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.Format(context, builder);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.Format(context, builder);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.Format(context, builder);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.Format(context, builder);
            }

            if (this.Filter != null)
            {
                this.Filter.Format(context, builder);
            }

            if (this.Bind != null)
            {
                this.Bind.Format(context, builder);
            }

            if (this.InlineData != null)
            {
                this.InlineData.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.BuildQuery(context, builder);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.BuildQuery(context, builder);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.BuildQuery(context, builder);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.BuildQuery(context, builder);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.BuildQuery(context, builder);
            }

            if (this.Filter != null)
            {
                this.Filter.BuildQuery(context, builder);
            }

            if (this.Bind != null)
            {
                this.Bind.BuildQuery(context, builder);
            }

            if (this.InlineData != null)
            {
                this.InlineData.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.BuildMock(context, builder);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.BuildMock(context, builder);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.BuildMock(context, builder);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.BuildMock(context, builder);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.BuildMock(context, builder);
            }

            if (this.Filter != null)
            {
                this.Filter.BuildMock(context, builder);
            }

            if (this.Bind != null)
            {
                this.Bind.BuildMock(context, builder);
            }

            if (this.InlineData != null)
            {
                this.InlineData.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupOrUnionGraphPattern != null)
            {
                this.GroupOrUnionGraphPattern.BuildOther(context, builder);
            }

            if (this.OptionalGraphPattern != null)
            {
                this.OptionalGraphPattern.BuildOther(context, builder);
            }

            if (this.MinusGraphPattern != null)
            {
                this.MinusGraphPattern.BuildOther(context, builder);
            }

            if (this.GraphGraphPattern != null)
            {
                this.GraphGraphPattern.BuildOther(context, builder);
            }

            if (this.ServiceGraphPattern != null)
            {
                this.ServiceGraphPattern.BuildOther(context, builder);
            }

            if (this.Filter != null)
            {
                this.Filter.BuildOther(context, builder);
            }

            if (this.Bind != null)
            {
                this.Bind.BuildOther(context, builder);
            }

            if (this.InlineData != null)
            {
                this.InlineData.BuildOther(context, builder);
            }

        }
    }

    public class OptionalGraphPattern : TokenPair
    {
        public OptionalGraphPattern()
        {
        }
        public String OPTIONAL
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class GraphGraphPattern : TokenPair
    {
        public GraphGraphPattern()
        {
        }
        public String GRAPH
        { get; set; }
        public VarOrIri VarOrIri
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Parse(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Wise(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Format(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildQuery(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildMock(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildOther(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class ServiceGraphPattern : TokenPair
    {
        public ServiceGraphPattern()
        {
        }
        public String SERVICE
        { get; set; }
        public String SILENT
        { get; set; }
        public VarOrIri VarOrIri
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Parse(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Wise(context);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Format(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildQuery(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildMock(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildOther(context, builder);
            }

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class Bind : TokenPair
    {
        public Bind()
        {
        }
        public String BIND
        { get; set; }
        public Expression Expression
        { get; set; }
        public String AS
        { get; set; }
        public Var Var
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Expression != null)
            {
                this.Expression.Parse(context);
            }

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Expression != null)
            {
                this.Expression.Wise(context);
            }

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.Format(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildQuery(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildMock(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildOther(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

        }
    }

    public class InlineData : TokenPair
    {
        public InlineData()
        {
        }
        public String VALUES
        { get; set; }
        public DataBlock DataBlock
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.DataBlock != null)
            {
                this.DataBlock.BuildOther(context, builder);
            }

        }
    }

    public class DataBlock : TokenPair
    {
        public DataBlock()
        {
        }
        public InlineDataOneVar InlineDataOneVar
        { get; set; }
        public InlineDataFull InlineDataFull
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.Parse(context);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.Wise(context);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.Format(context, builder);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.BuildQuery(context, builder);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.BuildMock(context, builder);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.InlineDataOneVar != null)
            {
                this.InlineDataOneVar.BuildOther(context, builder);
            }

            if (this.InlineDataFull != null)
            {
                this.InlineDataFull.BuildOther(context, builder);
            }

        }
    }

    public class InlineDataOneVar : TokenPair
    {
        public InlineDataOneVar()
        {
            this.DataBlockValues = new List<DataBlockValue>();
        }
        public Var Var
        { get; set; }
        public List<DataBlockValue> DataBlockValues
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildOther(context, builder);
            }

        }
    }

    public class InlineDataFull : TokenPair
    {
        public InlineDataFull()
        {
            this.NILs = new List<String>();
            this.Vars = new List<Var>();
            this.DataBlockValues = new List<DataBlockValue>();
        }
        public List<String> NILs
        { get; set; }
        public List<Var> Vars
        { get; set; }
        public List<DataBlockValue> DataBlockValues
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Parse(context);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Wise(context);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].Format(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Vars.Count(); i++)
            {
                this.Vars[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.DataBlockValues.Count(); i++)
            {
                this.DataBlockValues[i].BuildOther(context, builder);
            }

        }
    }

    public class DataBlockValue : TokenPair
    {
        public DataBlockValue()
        {
        }
        public Iri Iri
        { get; set; }
        public RDFLiteral RDFLiteral
        { get; set; }
        public NumericLiteral NumericLiteral
        { get; set; }
        public BooleanLiteral BooleanLiteral
        { get; set; }
        public String UNDEF
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Parse(context);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Parse(context);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Wise(context);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Wise(context);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Format(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Format(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildQuery(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildQuery(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildMock(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildMock(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildOther(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildOther(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildOther(context, builder);
            }

        }
    }

    public class MinusGraphPattern : TokenPair
    {
        public MinusGraphPattern()
        {
        }
        public String MINUS
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class GroupOrUnionGraphPattern : TokenPair
    {
        public GroupOrUnionGraphPattern()
        {
            this.GroupGraphPatterns = new List<GroupGraphPattern>();
            this.UNIONs = new List<String>();
        }
        public List<GroupGraphPattern> GroupGraphPatterns
        { get; set; }
        public List<String> UNIONs
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GroupGraphPatterns.Count(); i++)
            {
                this.GroupGraphPatterns[i].BuildOther(context, builder);
            }

        }
    }

    public class Filter : TokenPair
    {
        public Filter()
        {
        }
        public String FILTER
        { get; set; }
        public Constraint Constraint
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Constraint != null)
            {
                this.Constraint.BuildOther(context, builder);
            }

        }
    }

    public class Constraint : TokenPair
    {
        public Constraint()
        {
        }
        public BrackettedExpression BrackettedExpression
        { get; set; }
        public BuiltInCall BuiltInCall
        { get; set; }
        public FunctionCall FunctionCall
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Parse(context);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Parse(context);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Wise(context);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Wise(context);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Format(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Format(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildQuery(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildQuery(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildMock(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildMock(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildOther(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildOther(context, builder);
            }

            if (this.FunctionCall != null)
            {
                this.FunctionCall.BuildOther(context, builder);
            }

        }
    }

    public class FunctionCall : TokenPair
    {
        public FunctionCall()
        {
        }
        public Iri Iri
        { get; set; }
        public ArgList ArgList
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildOther(context, builder);
            }

        }
    }

    public class ArgList : TokenPair
    {
        public ArgList()
        {
            this.Expressions = new List<Expression>();
        }
        public String NIL
        { get; set; }
        public String DISTINCT
        { get; set; }
        public List<Expression> Expressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ExpressionList : TokenPair
    {
        public ExpressionList()
        {
            this.Expressions = new List<Expression>();
        }
        public String NIL
        { get; set; }
        public List<Expression> Expressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ConstructTemplate : TokenPair
    {
        public ConstructTemplate()
        {
        }
        public ConstructTriples ConstructTriples
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConstructTriples != null)
            {
                this.ConstructTriples.BuildOther(context, builder);
            }

        }
    }

    public class ConstructTriples : TokenPair
    {
        public ConstructTriples()
        {
        }
        public TriplesSameSubject TriplesSameSubject
        { get; set; }
        public ConstructTriples ConstructTriples0
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Parse(context);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Wise(context);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.Format(context, builder);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildQuery(context, builder);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildMock(context, builder);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.TriplesSameSubject != null)
            {
                this.TriplesSameSubject.BuildOther(context, builder);
            }

            if (this.ConstructTriples0 != null)
            {
                this.ConstructTriples0.BuildOther(context, builder);
            }

        }
    }

    public class TriplesSameSubject : TokenPair
    {
        public TriplesSameSubject()
        {
        }
        public VarOrTerm VarOrTerm
        { get; set; }
        public PropertyListNotEmpty PropertyListNotEmpty
        { get; set; }
        public TriplesNode TriplesNode
        { get; set; }
        public PropertyList PropertyList
        { get; set; }       

        public void Parse(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Parse(context);
            }

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Parse(context);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Parse(context);
            }

            if (this.PropertyList != null)
            {
                this.PropertyList.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Wise(context);

                if (this.PropertyListNotEmpty != null)
                {
                    this.PropertyListNotEmpty.Wise(context);
                }

                context.AddTriple(this.VarOrTerm.Text, this.VarOrTerm);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Wise(context);

                if (this.PropertyList != null)
                {
                    this.PropertyList.Wise(context);
                }
            }
        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Format(context, builder);
            }

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Format(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Format(context, builder);
            }

            if (this.PropertyList != null)
            {
                this.PropertyList.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildQuery(context, builder);
            }

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildQuery(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildQuery(context, builder);
            }

            if (this.PropertyList != null)
            {
                this.PropertyList.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildMock(context, builder);
            }

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildMock(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildMock(context, builder);
            }

            if (this.PropertyList != null)
            {
                this.PropertyList.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildOther(context, builder);
            }

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildOther(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildOther(context, builder);
            }

            if (this.PropertyList != null)
            {
                this.PropertyList.BuildOther(context, builder);
            }

        }
    }

    public class PropertyList : TokenPair
    {
        public PropertyList()
        {
        }
        public PropertyListNotEmpty PropertyListNotEmpty
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildOther(context, builder);
            }

        }
    }

    public class PropertyListNotEmpty : TokenPair
    {
        public PropertyListNotEmpty()
        {
            this.Verbs = new List<Verb>();
            this.ObjectLists = new List<ObjectList>();
        }
        public List<Verb> Verbs
        { get; set; }
        public List<ObjectList> ObjectLists
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].Parse(context);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].Wise(context);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].Format(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Verbs.Count(); i++)
            {
                this.Verbs[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildOther(context, builder);
            }

        }
    }

    public class Verb : TokenPair
    {
        public Verb()
        {
        }
        public VarOrIri VarOrIri
        { get; set; }

        public void Parse(SparqlContext context)
        {
            if (this.VarOrIri != null)
            {
                this.VarOrIri.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrIri != null)
            {
                this.VarOrIri.BuildOther(context, builder);
            }

        }
    }

    public class ObjectList : TokenPair
    {
        public ObjectList()
        {
            this.@objects = new List<@object>();
        }
        public List<@object> @objects
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.@objects.Count(); i++)
            {
                this.@objects[i].BuildOther(context, builder);
            }

        }
    }

    public class @object : TokenPair
    {
        public @object()
        {
        }
        public GraphNode GraphNode
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNode != null)
            {
                this.GraphNode.BuildOther(context, builder);
            }

        }
    }

    public class TriplesSameSubjectPath : TokenPair
    {
        public TriplesSameSubjectPath()
        {
        }
        public VarOrTerm VarOrTerm
        { get; set; }
        public PropertyListPathNotEmpty PropertyListPathNotEmpty
        { get; set; }
        public TriplesNodePath TriplesNodePath
        { get; set; }
        public PropertyListPath PropertyListPath
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Parse(context);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Parse(context);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Parse(context);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Wise(context);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Wise(context);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Wise(context);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Format(context, builder);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Format(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Format(context, builder);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildQuery(context, builder);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildQuery(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildQuery(context, builder);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildMock(context, builder);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildMock(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildMock(context, builder);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildOther(context, builder);
            }

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildOther(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildOther(context, builder);
            }

            if (this.PropertyListPath != null)
            {
                this.PropertyListPath.BuildOther(context, builder);
            }

        }
    }

    public class PropertyListPath : TokenPair
    {
        public PropertyListPath()
        {
        }
        public PropertyListPathNotEmpty PropertyListPathNotEmpty
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildOther(context, builder);
            }

        }
    }

    public class PropertyListPathNotEmpty : TokenPair
    {
        public PropertyListPathNotEmpty()
        {
            this.VerbPaths = new List<VerbPath>();
            this.VerbSimples = new List<VerbSimple>();
            this.ObjectLists = new List<ObjectList>();
        }
        public List<VerbPath> VerbPaths
        { get; set; }
        public List<VerbSimple> VerbSimples
        { get; set; }
        public ObjectListPath ObjectListPath
        { get; set; }
        public List<ObjectList> ObjectLists
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].Parse(context);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].Parse(context);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.Parse(context);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].Wise(context);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].Wise(context);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.Wise(context);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].Format(context, builder);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].Format(context, builder);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.Format(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].BuildQuery(context, builder);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].BuildMock(context, builder);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.VerbPaths.Count(); i++)
            {
                this.VerbPaths[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.VerbSimples.Count(); i++)
            {
                this.VerbSimples[i].BuildOther(context, builder);
            }

            if (this.ObjectListPath != null)
            {
                this.ObjectListPath.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectLists.Count(); i++)
            {
                this.ObjectLists[i].BuildOther(context, builder);
            }

        }
    }

    public class VerbPath : TokenPair
    {
        public VerbPath()
        {
        }
        public Path Path
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Path != null)
            {
                this.Path.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Path != null)
            {
                this.Path.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Path != null)
            {
                this.Path.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Path != null)
            {
                this.Path.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Path != null)
            {
                this.Path.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Path != null)
            {
                this.Path.BuildOther(context, builder);
            }

        }
    }

    public class VerbSimple : TokenPair
    {
        public VerbSimple()
        {
        }
        public Var Var
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

        }
    }

    public class ObjectListPath : TokenPair
    {
        public ObjectListPath()
        {
            this.ObjectPaths = new List<ObjectPath>();
        }
        public List<ObjectPath> ObjectPaths
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPaths.Count(); i++)
            {
                this.ObjectPaths[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectPath : TokenPair
    {
        public ObjectPath()
        {
        }
        public GraphNodePath GraphNodePath
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GraphNodePath != null)
            {
                this.GraphNodePath.BuildOther(context, builder);
            }

        }
    }

    public class Path : TokenPair
    {
        public Path()
        {
        }
        public PathAlternative PathAlternative
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathAlternative != null)
            {
                this.PathAlternative.BuildOther(context, builder);
            }

        }
    }

    public class PathAlternative : TokenPair
    {
        public PathAlternative()
        {
            this.PathSequences = new List<PathSequence>();
        }
        public List<PathSequence> PathSequences
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathSequences.Count(); i++)
            {
                this.PathSequences[i].BuildOther(context, builder);
            }

        }
    }

    public class PathSequence : TokenPair
    {
        public PathSequence()
        {
            this.PathEltOrInverses = new List<PathEltOrInverse>();
        }
        public List<PathEltOrInverse> PathEltOrInverses
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathEltOrInverses.Count(); i++)
            {
                this.PathEltOrInverses[i].BuildOther(context, builder);
            }

        }
    }

    public class PathElt : TokenPair
    {
        public PathElt()
        {
        }
        public PathPrimary PathPrimary
        { get; set; }
        public PathMod PathMod
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.Parse(context);
            }

            if (this.PathMod != null)
            {
                this.PathMod.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.Wise(context);
            }

            if (this.PathMod != null)
            {
                this.PathMod.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.Format(context, builder);
            }

            if (this.PathMod != null)
            {
                this.PathMod.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.BuildQuery(context, builder);
            }

            if (this.PathMod != null)
            {
                this.PathMod.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.BuildMock(context, builder);
            }

            if (this.PathMod != null)
            {
                this.PathMod.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PathPrimary != null)
            {
                this.PathPrimary.BuildOther(context, builder);
            }

            if (this.PathMod != null)
            {
                this.PathMod.BuildOther(context, builder);
            }

        }
    }

    public class PathEltOrInverse : TokenPair
    {
        public PathEltOrInverse()
        {
            this.PathElts = new List<PathElt>();
        }
        public List<PathElt> PathElts
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathElts.Count(); i++)
            {
                this.PathElts[i].BuildOther(context, builder);
            }

        }
    }

    public class PathMod : TokenPair
    {
        public PathMod()
        {
        }
        public String ALL
        { get; set; }

        public void Parse(SparqlContext context)
        {

        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class PathPrimary : TokenPair
    {
        public PathPrimary()
        {
        }
        public Iri Iri
        { get; set; }
        public PathNegatedPropertySet PathNegatedPropertySet
        { get; set; }
        public Path Path
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.Parse(context);
            }

            if (this.Path != null)
            {
                this.Path.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.Wise(context);
            }

            if (this.Path != null)
            {
                this.Path.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.Format(context, builder);
            }

            if (this.Path != null)
            {
                this.Path.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.BuildQuery(context, builder);
            }

            if (this.Path != null)
            {
                this.Path.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.BuildMock(context, builder);
            }

            if (this.Path != null)
            {
                this.Path.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.PathNegatedPropertySet != null)
            {
                this.PathNegatedPropertySet.BuildOther(context, builder);
            }

            if (this.Path != null)
            {
                this.Path.BuildOther(context, builder);
            }

        }
    }

    public class PathNegatedPropertySet : TokenPair
    {
        public PathNegatedPropertySet()
        {
            this.PathOneInPropertySets = new List<PathOneInPropertySet>();
        }
        public List<PathOneInPropertySet> PathOneInPropertySets
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PathOneInPropertySets.Count(); i++)
            {
                this.PathOneInPropertySets[i].BuildOther(context, builder);
            }

        }
    }

    public class PathOneInPropertySet : TokenPair
    {
        public PathOneInPropertySet()
        {
            this.Iris = new List<Iri>();
        }
        public List<Iri> Iris
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Iris.Count(); i++)
            {
                this.Iris[i].BuildOther(context, builder);
            }

        }
    }

    public class Integer : TokenPair
    {
        public Integer()
        {
        }
        public String INTEGER
        { get; set; }

        public void Parse(SparqlContext context)
        {

        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class TriplesNode : TokenPair
    {
        public TriplesNode()
        {
        }
        public Collection Collection
        { get; set; }
        public BlankNodePropertyList BlankNodePropertyList
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Collection != null)
            {
                this.Collection.Parse(context);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Collection != null)
            {
                this.Collection.Wise(context);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Collection != null)
            {
                this.Collection.Format(context, builder);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Collection != null)
            {
                this.Collection.BuildQuery(context, builder);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Collection != null)
            {
                this.Collection.BuildMock(context, builder);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Collection != null)
            {
                this.Collection.BuildOther(context, builder);
            }

            if (this.BlankNodePropertyList != null)
            {
                this.BlankNodePropertyList.BuildOther(context, builder);
            }

        }
    }

    public class BlankNodePropertyList : TokenPair
    {
        public BlankNodePropertyList()
        {
        }
        public PropertyListNotEmpty PropertyListNotEmpty
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListNotEmpty != null)
            {
                this.PropertyListNotEmpty.BuildOther(context, builder);
            }

        }
    }

    public class TriplesNodePath : TokenPair
    {
        public TriplesNodePath()
        {
        }
        public CollectionPath CollectionPath
        { get; set; }
        public BlankNodePropertyListPath BlankNodePropertyListPath
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.Parse(context);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.Wise(context);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.Format(context, builder);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.BuildQuery(context, builder);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.BuildMock(context, builder);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.CollectionPath != null)
            {
                this.CollectionPath.BuildOther(context, builder);
            }

            if (this.BlankNodePropertyListPath != null)
            {
                this.BlankNodePropertyListPath.BuildOther(context, builder);
            }

        }
    }

    public class BlankNodePropertyListPath : TokenPair
    {
        public BlankNodePropertyListPath()
        {
        }
        public PropertyListPathNotEmpty PropertyListPathNotEmpty
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PropertyListPathNotEmpty != null)
            {
                this.PropertyListPathNotEmpty.BuildOther(context, builder);
            }

        }
    }

    public class Collection : TokenPair
    {
        public Collection()
        {
            this.GraphNodes = new List<GraphNode>();
        }
        public List<GraphNode> GraphNodes
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodes.Count(); i++)
            {
                this.GraphNodes[i].BuildOther(context, builder);
            }

        }
    }

    public class CollectionPath : TokenPair
    {
        public CollectionPath()
        {
            this.GraphNodePaths = new List<GraphNodePath>();
        }
        public List<GraphNodePath> GraphNodePaths
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.GraphNodePaths.Count(); i++)
            {
                this.GraphNodePaths[i].BuildOther(context, builder);
            }

        }
    }

    public class GraphNode : TokenPair
    {
        public GraphNode()
        {
        }
        public VarOrTerm VarOrTerm
        { get; set; }
        public TriplesNode TriplesNode
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Parse(context);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Wise(context);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Format(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildQuery(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildMock(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildOther(context, builder);
            }

            if (this.TriplesNode != null)
            {
                this.TriplesNode.BuildOther(context, builder);
            }

        }
    }

    public class GraphNodePath : TokenPair
    {
        public GraphNodePath()
        {
        }
        public VarOrTerm VarOrTerm
        { get; set; }
        public TriplesNodePath TriplesNodePath
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Parse(context);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Wise(context);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.Format(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildQuery(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildMock(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.VarOrTerm != null)
            {
                this.VarOrTerm.BuildOther(context, builder);
            }

            if (this.TriplesNodePath != null)
            {
                this.TriplesNodePath.BuildOther(context, builder);
            }

        }
    }

    public class VarOrTerm : TokenPair
    {
        public VarOrTerm()
        {
        }
        public Var Var
        { get; set; }
        public GraphTerm GraphTerm
        { get; set; }
        public String Text { get; set; }

        public void Parse(SparqlContext context)
        {
            if (this.Var != null)
            {
                this.Var.Parse(context);

                this.Text = this.Var.Text;
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.Parse(context);

                this.Text = this.GraphTerm.Text;
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

            if (this.GraphTerm != null)
            {
                this.GraphTerm.BuildOther(context, builder);
            }

        }
    }

    public class VarOrIri : TokenPair
    {
        public VarOrIri()
        {
        }
        public Var Var
        { get; set; }
        public Iri Iri
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

        }
    }

    public class Var : TokenPair
    {
        public Var()
        {
        }
        public String VAR1
        { get; set; }
        public String VAR2
        { get; set; }

        public void Parse(SparqlContext context)
        {
            var var = this.VAR1 == null ? this.VAR2 : this.VAR1;
            //if (context.Variables.Contains(var))
            //{
            //    context.AddError(this, "变量重复:" + var);
            //    return;
            //}

            this.Text = var;
            context.AddVariable(var, this);
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class GraphTerm : TokenPair
    {
        public GraphTerm()
        {
        }
        public Iri Iri
        { get; set; }
        public RDFLiteral RDFLiteral
        { get; set; }
        public NumericLiteral NumericLiteral
        { get; set; }
        public BooleanLiteral BooleanLiteral
        { get; set; }
        public BlankNode BlankNode
        { get; set; }
        public String NIL
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
                this.Text = this.Iri.Text;
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Parse(context);
                this.Text = this.RDFLiteral.Text;
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Parse(context);
                this.Text = this.NumericLiteral.Text;
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Parse(context);
                this.Text = this.BooleanLiteral.Text;
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.Parse(context);
                this.Text = this.BlankNode.Text;
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Wise(context);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Wise(context);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Wise(context);
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Format(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Format(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Format(context, builder);
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildQuery(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildQuery(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildQuery(context, builder);
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildMock(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildMock(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildMock(context, builder);
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildOther(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildOther(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildOther(context, builder);
            }

            if (this.BlankNode != null)
            {
                this.BlankNode.BuildOther(context, builder);
            }

        }

        public string Text { get; set; }
    }

    public class Expression : TokenPair
    {
        public Expression()
        {
        }
        public ConditionalOrExpression ConditionalOrExpression
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.ConditionalOrExpression != null)
            {
                this.ConditionalOrExpression.BuildOther(context, builder);
            }

        }
    }

    public class ConditionalOrExpression : TokenPair
    {
        public ConditionalOrExpression()
        {
            this.ConditionalAndExpressions = new List<ConditionalAndExpression>();
        }
        public List<ConditionalAndExpression> ConditionalAndExpressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ConditionalAndExpressions.Count(); i++)
            {
                this.ConditionalAndExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ConditionalAndExpression : TokenPair
    {
        public ConditionalAndExpression()
        {
            this.ValueLogicals = new List<ValueLogical>();
        }
        public List<ValueLogical> ValueLogicals
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ValueLogicals.Count(); i++)
            {
                this.ValueLogicals[i].BuildOther(context, builder);
            }

        }
    }

    public class ValueLogical : TokenPair
    {
        public ValueLogical()
        {
        }
        public RelationalExpression RelationalExpression
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.RelationalExpression != null)
            {
                this.RelationalExpression.BuildOther(context, builder);
            }

        }
    }

    public class RelationalExpression : TokenPair
    {
        public RelationalExpression()
        {
            this.NumericExpressions = new List<NumericExpression>();
            this.ExpressionLists = new List<ExpressionList>();
        }
        public List<NumericExpression> NumericExpressions
        { get; set; }
        public String EQUAL
        { get; set; }
        public String NOTEQUAL
        { get; set; }
        public String LT
        { get; set; }
        public String GT
        { get; set; }
        public String LTEQUAL
        { get; set; }
        public String GTEQUAL
        { get; set; }
        public String IN
        { get; set; }
        public List<ExpressionList> ExpressionLists
        { get; set; }
        public String NOTIN
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].Parse(context);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].Wise(context);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].Format(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NumericExpressions.Count(); i++)
            {
                this.NumericExpressions[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildOther(context, builder);
            }

        }
    }

    public class NumericExpression : TokenPair
    {
        public NumericExpression()
        {
        }
        public AdditiveExpression AdditiveExpression
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.AdditiveExpression != null)
            {
                this.AdditiveExpression.BuildOther(context, builder);
            }

        }
    }

    public class AdditiveExpression : TokenPair
    {
        public AdditiveExpression()
        {
            this.MultiplicativeExpressions = new List<MultiplicativeExpression>();
            this.ADDs = new List<String>();
            this.SUBTRACTIONs = new List<String>();
            this.AdditiveExpressionMultis = new List<AdditiveExpressionMulti>();
        }
        public List<MultiplicativeExpression> MultiplicativeExpressions
        { get; set; }
        public List<String> ADDs
        { get; set; }
        public List<String> SUBTRACTIONs
        { get; set; }
        public List<AdditiveExpressionMulti> AdditiveExpressionMultis
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].Parse(context);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].Wise(context);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].Format(context, builder);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.MultiplicativeExpressions.Count(); i++)
            {
                this.MultiplicativeExpressions[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.AdditiveExpressionMultis.Count(); i++)
            {
                this.AdditiveExpressionMultis[i].BuildOther(context, builder);
            }

        }
    }

    public class MultiplicativeExpression : TokenPair
    {
        public MultiplicativeExpression()
        {
            this.MultiplicativeExpressionItems = new List<MultiplicativeExpressionItem>();
        }
        public UnaryExpression UnaryExpression
        { get; set; }
        public List<MultiplicativeExpressionItem> MultiplicativeExpressionItems
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.Parse(context);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.Wise(context);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.Format(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.BuildMock(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.UnaryExpression != null)
            {
                this.UnaryExpression.BuildOther(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildOther(context, builder);
            }

        }
    }

    public class AdditiveExpressionMulti : TokenPair
    {
        public AdditiveExpressionMulti()
        {
            this.MultiplicativeExpressionItems = new List<MultiplicativeExpressionItem>();
        }
        public NumericLiteralPositive NumericLiteralPositive
        { get; set; }
        public NumericLiteralNegative NumericLiteralNegative
        { get; set; }
        public List<MultiplicativeExpressionItem> MultiplicativeExpressionItems
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Parse(context);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Parse(context);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Wise(context);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Wise(context);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Format(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Format(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildQuery(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildMock(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildMock(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildOther(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildOther(context, builder);
            }

            for (int i = 0; i < this.MultiplicativeExpressionItems.Count(); i++)
            {
                this.MultiplicativeExpressionItems[i].BuildOther(context, builder);
            }

        }
    }

    public class MultiplicativeExpressionItem : TokenPair
    {
        public MultiplicativeExpressionItem()
        {
            this.UnaryExpressions = new List<UnaryExpression>();
        }
        public List<UnaryExpression> UnaryExpressions
        { get; set; }
        public String DIVISION
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.UnaryExpressions.Count(); i++)
            {
                this.UnaryExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class UnaryExpression : TokenPair
    {
        public UnaryExpression()
        {
            this.PrimaryExpressions = new List<PrimaryExpression>();
        }
        public String NEGATE
        { get; set; }
        public List<PrimaryExpression> PrimaryExpressions
        { get; set; }
        public String ADD
        { get; set; }
        public String SUBTRACTION
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.PrimaryExpressions.Count(); i++)
            {
                this.PrimaryExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class PrimaryExpression : TokenPair
    {
        public PrimaryExpression()
        {
        }
        public BrackettedExpression BrackettedExpression
        { get; set; }
        public BuiltInCall BuiltInCall
        { get; set; }
        public IriOrFunction IriOrFunction
        { get; set; }
        public RDFLiteral RDFLiteral
        { get; set; }
        public NumericLiteral NumericLiteral
        { get; set; }
        public BooleanLiteral BooleanLiteral
        { get; set; }
        public Var Var
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Parse(context);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Parse(context);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.Parse(context);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Parse(context);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Parse(context);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Parse(context);
            }

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Wise(context);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Wise(context);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.Wise(context);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Wise(context);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Wise(context);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Wise(context);
            }

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.Format(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.Format(context, builder);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.Format(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.Format(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.Format(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.Format(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildQuery(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildQuery(context, builder);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.BuildQuery(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildQuery(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildQuery(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildQuery(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildMock(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildMock(context, builder);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.BuildMock(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildMock(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildMock(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildMock(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.BrackettedExpression != null)
            {
                this.BrackettedExpression.BuildOther(context, builder);
            }

            if (this.BuiltInCall != null)
            {
                this.BuiltInCall.BuildOther(context, builder);
            }

            if (this.IriOrFunction != null)
            {
                this.IriOrFunction.BuildOther(context, builder);
            }

            if (this.RDFLiteral != null)
            {
                this.RDFLiteral.BuildOther(context, builder);
            }

            if (this.NumericLiteral != null)
            {
                this.NumericLiteral.BuildOther(context, builder);
            }

            if (this.BooleanLiteral != null)
            {
                this.BooleanLiteral.BuildOther(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

        }
    }

    public class BrackettedExpression : TokenPair
    {
        public BrackettedExpression()
        {
        }
        public Expression Expression
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Expression != null)
            {
                this.Expression.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Expression != null)
            {
                this.Expression.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Expression != null)
            {
                this.Expression.BuildOther(context, builder);
            }

        }
    }

    public class BuiltInCall : TokenPair
    {
        public BuiltInCall()
        {
            this.Expressions = new List<Expression>();
            this.NILs = new List<String>();
            this.ExpressionLists = new List<ExpressionList>();
        }
        public Aggregate Aggregate
        { get; set; }
        public String STR
        { get; set; }
        public List<Expression> Expressions
        { get; set; }
        public String LANG
        { get; set; }
        public String LANGMATCHES
        { get; set; }
        public String DATATYPE
        { get; set; }
        public String BOUND
        { get; set; }
        public Var Var
        { get; set; }
        public String IRI
        { get; set; }
        public String URI
        { get; set; }
        public String BNODE
        { get; set; }
        public List<String> NILs
        { get; set; }
        public String RAND
        { get; set; }
        public String ABS
        { get; set; }
        public String CEIL
        { get; set; }
        public String FLOOR
        { get; set; }
        public String ROUND
        { get; set; }
        public String CONCAT
        { get; set; }
        public List<ExpressionList> ExpressionLists
        { get; set; }
        public SubstringExpression SubstringExpression
        { get; set; }
        public String STRLEN
        { get; set; }
        public StrReplaceExpression StrReplaceExpression
        { get; set; }
        public String UCASE
        { get; set; }
        public String LCASE
        { get; set; }
        public String ENCODEFORURI
        { get; set; }
        public String CONTAINS
        { get; set; }
        public String STRSTARTS
        { get; set; }
        public String STRENDS
        { get; set; }
        public String STRBEFORE
        { get; set; }
        public String STRAFTER
        { get; set; }
        public String YEAR
        { get; set; }
        public String MONTH
        { get; set; }
        public String DAY
        { get; set; }
        public String HOURS
        { get; set; }
        public String MINUTES
        { get; set; }
        public String SECONDS
        { get; set; }
        public String TIMEZONE
        { get; set; }
        public String TZ
        { get; set; }
        public String NOW
        { get; set; }
        public String UUID
        { get; set; }
        public String STRUUID
        { get; set; }
        public String MD5
        { get; set; }
        public String SHA1
        { get; set; }
        public String SHA256
        { get; set; }
        public String SHA384
        { get; set; }
        public String SHA512
        { get; set; }
        public String COALESCE
        { get; set; }
        public String IF
        { get; set; }
        public String STRLANG
        { get; set; }
        public String STRDT
        { get; set; }
        public String SameTerm
        { get; set; }
        public String IsIRI
        { get; set; }
        public String IsURI
        { get; set; }
        public String IsBLANK
        { get; set; }
        public String IsLITERAL
        { get; set; }
        public String IsNUMERIC
        { get; set; }
        public RegexExpression RegexExpression
        { get; set; }
        public ExistsFunc ExistsFunc
        { get; set; }
        public NotExistsFunc NotExistsFunc
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.Parse(context);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

            if (this.Var != null)
            {
                this.Var.Parse(context);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Parse(context);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.Parse(context);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.Parse(context);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.Parse(context);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.Parse(context);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.Wise(context);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

            if (this.Var != null)
            {
                this.Var.Wise(context);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Wise(context);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.Wise(context);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.Wise(context);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.Wise(context);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.Wise(context);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.Format(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.Format(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].Format(context, builder);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.Format(context, builder);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.Format(context, builder);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.Format(context, builder);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.Format(context, builder);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildQuery(context, builder);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.BuildQuery(context, builder);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.BuildQuery(context, builder);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.BuildQuery(context, builder);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.BuildQuery(context, builder);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.BuildMock(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildMock(context, builder);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.BuildMock(context, builder);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.BuildMock(context, builder);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.BuildMock(context, builder);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.BuildMock(context, builder);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Aggregate != null)
            {
                this.Aggregate.BuildOther(context, builder);
            }

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

            if (this.Var != null)
            {
                this.Var.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ExpressionLists.Count(); i++)
            {
                this.ExpressionLists[i].BuildOther(context, builder);
            }

            if (this.SubstringExpression != null)
            {
                this.SubstringExpression.BuildOther(context, builder);
            }

            if (this.StrReplaceExpression != null)
            {
                this.StrReplaceExpression.BuildOther(context, builder);
            }

            if (this.RegexExpression != null)
            {
                this.RegexExpression.BuildOther(context, builder);
            }

            if (this.ExistsFunc != null)
            {
                this.ExistsFunc.BuildOther(context, builder);
            }

            if (this.NotExistsFunc != null)
            {
                this.NotExistsFunc.BuildOther(context, builder);
            }

        }
    }

    public class RegexExpression : TokenPair
    {
        public RegexExpression()
        {
            this.Expressions = new List<Expression>();
        }
        public String REGEX
        { get; set; }
        public List<Expression> Expressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class SubstringExpression : TokenPair
    {
        public SubstringExpression()
        {
            this.Expressions = new List<Expression>();
        }
        public String SUBSTR
        { get; set; }
        public List<Expression> Expressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class StrReplaceExpression : TokenPair
    {
        public StrReplaceExpression()
        {
            this.Expressions = new List<Expression>();
        }
        public String REPLACE
        { get; set; }
        public List<Expression> Expressions
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ExistsFunc : TokenPair
    {
        public ExistsFunc()
        {
        }
        public String EXISTS
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class NotExistsFunc : TokenPair
    {
        public NotExistsFunc()
        {
        }
        public String NOT
        { get; set; }
        public String EXISTS
        { get; set; }
        public GroupGraphPattern GroupGraphPattern
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.GroupGraphPattern != null)
            {
                this.GroupGraphPattern.BuildOther(context, builder);
            }

        }
    }

    public class Aggregate : TokenPair
    {
        public Aggregate()
        {
            this.DISTINCTs = new List<String>();
            this.Expressions = new List<Expression>();
        }
        public String COUNT
        { get; set; }
        public List<String> DISTINCTs
        { get; set; }
        public String ALL
        { get; set; }
        public List<Expression> Expressions
        { get; set; }
        public String SUM
        { get; set; }
        public String MIN
        { get; set; }
        public String MAX
        { get; set; }
        public String AVG
        { get; set; }
        public String SAMPLE
        { get; set; }
        public String GROUPCONCAT
        { get; set; }
        public String SEPARATOR
        { get; set; }
        public String @string
        { get; set; }

        public void Parse(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Expressions.Count(); i++)
            {
                this.Expressions[i].BuildOther(context, builder);
            }

        }
    }

    public class IriOrFunction : TokenPair
    {
        public IriOrFunction()
        {
        }
        public Iri Iri
        { get; set; }
        public ArgList ArgList
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Parse(context);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Parse(context);
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.Iri != null)
            {
                this.Iri.Wise(context);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.Format(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildQuery(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildMock(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.Iri != null)
            {
                this.Iri.BuildOther(context, builder);
            }

            if (this.ArgList != null)
            {
                this.ArgList.BuildOther(context, builder);
            }

        }
    }

    public class RDFLiteral : TokenPair
    {
        public RDFLiteral()
        {
        }
        public String @string
        { get; set; }
        public String LANGTAG
        { get; set; }
        public XsdIri XsdIri
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = this.@string;

            if (this.XsdIri != null)
            {
                this.XsdIri.Parse(context);
                this.Text += this.XsdIri.Text;
            }
            else
            {
                this.Text += this.LANGTAG;
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildOther(context, builder);
            }

        }

        public string Text { get; set; }
    }

    public class NumericLiteral : TokenPair
    {
        public NumericLiteral()
        {
        }
        public NumericLiteralUnsigned NumericLiteralUnsigned
        { get; set; }
        public NumericLiteralPositive NumericLiteralPositive
        { get; set; }
        public NumericLiteralNegative NumericLiteralNegative
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.Parse(context);
                this.Text = this.NumericLiteralUnsigned.Text;
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Parse(context);
                this.Text = this.NumericLiteralPositive.Text;
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Parse(context);
                this.Text = this.NumericLiteralNegative.Text;
            }

        }

        public void Wise(SparqlContext context)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.Wise(context);
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Wise(context);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.Format(context, builder);
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.Format(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.BuildQuery(context, builder);
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildQuery(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.BuildMock(context, builder);
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildMock(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.NumericLiteralUnsigned != null)
            {
                this.NumericLiteralUnsigned.BuildOther(context, builder);
            }

            if (this.NumericLiteralPositive != null)
            {
                this.NumericLiteralPositive.BuildOther(context, builder);
            }

            if (this.NumericLiteralNegative != null)
            {
                this.NumericLiteralNegative.BuildOther(context, builder);
            }

        }

        public string Text { get; set; }
    }

    public class NumericLiteralUnsigned : TokenPair
    {
        public NumericLiteralUnsigned()
        {
        }
        public String INTEGER
        { get; set; }
        public String DECIMAL
        { get; set; }
        public String @dOUBLE
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = (this.INTEGER ?? this.DECIMAL) ?? this.dOUBLE;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class NumericLiteralPositive : TokenPair
    {
        public NumericLiteralPositive()
        {
        }
        public String INTEGERPOSITIVE
        { get; set; }
        public String DECIMALPOSITIVE
        { get; set; }
        public String DOUBLEPOSITIVE
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = (this.INTEGERPOSITIVE ?? this.DECIMALPOSITIVE) ?? this.DOUBLEPOSITIVE;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class NumericLiteralNegative : TokenPair
    {
        public NumericLiteralNegative()
        {
        }
        public String INTEGERNEGATIVE
        { get; set; }
        public String DECIMALNEGATIVE
        { get; set; }
        public String DOUBLENEGATIVE
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = this.INTEGERNEGATIVE ?? this.DECIMALNEGATIVE ?? this.DOUBLENEGATIVE;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class BooleanLiteral : TokenPair
    {
        public BooleanLiteral()
        {
            
        }

        public void Parse(SparqlContext context)
        {
            this.Text = this.BeginToken.Text;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class Iri : TokenPair
    {
        public Iri()
        {
        }
        public String IRIREF
        { get; set; }
        public PrefixedName PrefixedName
        { get; set; }

        public void Parse(SparqlContext context)
        {

            if (this.IRIREF != null)
                this.Text = this.IRIREF;

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Parse(context);
                this.Text = this.PrefixedName.Text;
            }

        }

        public void Wise(SparqlContext context)
        {
            if (this.IRIREF != null)
            {
                var owlName = context.ResloveName(this.IRIREF);
                if (owlName == null)
                {
                    context.AddError(this, "找不到名称：" + this.IRIREF);
                    return;
                }

                var obj = GlobalService.ModelManager.Reslove(owlName.Value.NameSpace, owlName.Value.LocalName);
                if (obj == null)
                {
                    context.AddError(this, "找不到RDF对象：" + this.IRIREF);
                    return;
                }
            }

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Wise(context);
            }

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Format(context, builder);
            }

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildMock(context, builder);
            }

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildOther(context, builder);
            }

        }

        public string Text { get; set; }
    }

    public class PrefixedName : TokenPair
    {
        public PrefixedName()
        {
        }
        public String PNAMELN
        { get; set; }
        public String PNAMENS
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = this.PNAMELN ?? this.PNAMENS;
        }

        public void Wise(SparqlContext context)
        {
            if (this.PNAMENS != null)
            {
                context.AddError(this, "暂不支持分析:" + this.PNAMENS);
            }
            else if (this.PNAMELN != null)
            {
                if (this.PNAMELN.StartsWith("rdf"))
                {
                }
                var owlName = context.ResloveName(this.PNAMELN);
                if (owlName == null)
                {
                    context.AddError(this, "找不到名称：" + this.PNAMELN);
                    return;
                }

                var obj = GlobalService.ModelManager.Reslove(owlName.Value.NameSpace, owlName.Value.LocalName);
                if (obj == null)
                {
                    context.AddError(this, "找不到RDF对象：" + this.PNAMELN);
                    return;
                }
            }
        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class BlankNode : TokenPair
    {
        public BlankNode()
        {
        }
        public String BLANKNODELABEL
        { get; set; }
        public String ANON
        { get; set; }

        public void Parse(SparqlContext context)
        {
            this.Text = this.BLANKNODELABEL ?? this.ANON;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

    public class XsdIri : TokenPair
    {
        public XsdIri()
        {
        }
        public String IRIREF
        { get; set; }
        public String PNAMELN
        { get; set; }
        public String PNAMENS
        { get; set; }

        public void Parse(SparqlContext context)
        {
            if ( this.IRIREF != null )
                this.Text = "^^" + this.IRIREF;
            if (this.PNAMELN != null)
                this.Text = this.PNAMELN;
            if (this.PNAMENS != null)
                this.Text = this.PNAMENS;
        }

        public void Wise(SparqlContext context)
        {

        }

        public void Format(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SparqlContext context, IndentStringBuilder builder)
        {

        }

        public string Text { get; set; }
    }

}