using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class QueryUnit
    {
        public Query Query { get; set; }
    }

    public class Query
    {
        public Prologue Prologue { get; set; }

        /// <summary>
        /// 与其他query属性互斥
        /// </summary>
        public SelectQuery SelectQuery { get; set; }

        /// <summary>
        /// 与其他query属性互斥
        /// </summary>
        public ConstructQuery ConstructQuery { get; set; }

        /// <summary>
        /// 与其他query属性互斥
        /// </summary>
        public DescribeQuery DescribeQuery { get; set; }

        /// <summary>
        /// 与其他query属性互斥
        /// </summary>
        public AskQuery AskQuery { get; set; }

        public ValuesClause ValuesClause { get; set; }

    }

    public class UpdateUnit
    {
        public Update Update { get; set; }
    }

    public class Prologue
    {
        public List<BaseDecl> BaseDecls { get; set; }
        public List<PrefixDecl> PrefixDecls { get; set; }

        public Prologue()
        {
            this.BaseDecls = new List<BaseDecl>();
            this.PrefixDecls = new List<PrefixDecl>();
        }
    }


    public class SelectQuery
    {
        public SelectClause SelectClause { get; set; }
        public List<DatasetClause> DatasetClauses { get; set; }
        public WhereClause WhereClause { get; set; }
        public SolutionModifier SolutionModifier { get; set; }
    }

    public class ConstructQuery
    {
        /// <summary>
        /// 与triplesTemplate互斥
        /// </summary>
        public ConstructTemplate ConstructTemplate { get; set; }

        /// <summary>
        /// 与triplesTemplate互斥
        /// </summary>
        public WhereClause WhereClause { get; set; }

        public List<DatasetClause> DatasetClauses { get; set; }
        public SolutionModifier SolutionModifier { get; set; }

        /// <summary>
        /// 与constructTemplate,whereClause互斥
        /// </summary>
        public TriplesTemplate TriplesTemplate { get; set; }
    }

    public class DescribeQuery
    {
        public List<VarOrIri> VarOrIris { get; set; }
        public List<DatasetClause> DatasetClauses { get; set; }
        public WhereClause WhereClause { get; set; }
        public SolutionModifier SolutionModifier { get; set; }
    }

    public class AskQuery
    {
        public List<DatasetClause> DatasetClauses { get; set; }
        public WhereClause WhereClause { get; set; }
        public SolutionModifier SolutionModifier { get; set; }

        public AskQuery()
        {
            this.DatasetClauses = new List<DatasetClause>();
        }
    }

    public class ValuesClause
    {
        public DataBlock DataBlock { get; set; }
    }

    public class Update
    {
        public Prologue Prologue { get; set; }
        public Update1 Update1 { get; set; }
        public Update Update0 { get; set; }
    }
    public class BaseDecl
    {
        public string IRIREF { get; set; }
    }

    public class PrefixDecl
    {
        public string PNAME_NS { get; set; }
        public string IRIREF { get; set; }
    }

    public class SelectClause
    {
        public bool IsDISTINCT { get; set; }
        public bool IsREDUCED { get; set; }
        public List<Var> Vars { get; set; }
        public List<Expression> Expressions { get; set; }
        public bool IsAll { get; set; }

        public SelectClause()
        {
            this.Vars = new List<Var>();
            this.Expressions = new List<Expression>();
        }
    }

    public class DatasetClause
    {
        public DefaultGraphClause DefaultGraphClause { get; set; }
        public NamedGraphClause NamedGraphClause { get; set; }
    }

    public class WhereClause
    {
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }

    public class SolutionModifier
    {
        public GroupClause GroupClause { get; set; }
        public HavingClause HavingClause { get; set; }
        public OrderClause OrderClause { get; set; }
        public LimitOffsetClauses LimitOffsetClauses { get; set; }
    }

    public class SubSelect
    {
        public SelectClause SelectClause { get; set; }
        public WhereClause WhereClause { get; set; }
        public SolutionModifier SolutionModifier { get; set; }
        public ValuesClause ValuesClause { get; set; }
    }

    public class Verb
    {
        public VarOrIri VarOrIri { get; set; }
        public bool IsA { get; set; }
    }

    public class Var
    {
        /// <summary>
        /// '?' VARNAME ;
        /// </summary>
        public string VAR1 { get; set; }

        /// <summary>
        /// '$' VARNAME ;
        /// </summary>
        public string VAR2 { get; set; }
    }

    public class Expression
    {
        public ConditionalOrExpression ConditionalOrExpression { get; set; }
    }

    public class ConstructTemplate
    {
        public ConstructTriples ConstructTriples { get; set; }
    }

    public class TriplesTemplate
    {
        public TriplesSameSubject TriplesSameSubject { get; set; }

        public TriplesTemplate TriplesTemplate0 { get; set; }
    }

    public class DefaultGraphClause
    {
        public SourceSelector SourceSelector { get; set; }
    }

    public class NamedGraphClause
    {
        public SourceSelector SourceSelector { get; set; }
    }

    public class SourceSelector
    {
        public Iri Iri { get; set; }
    }

    public class Iri
    {
        public string IRIREF { get; set; }
        public PrefixedName PprefixedName { get; set; }

    }

    public class GroupGraphPattern
    {
        public SubSelect SubSelect { get; set; }

        public GroupGraphPatternSub GroupGraphPatternSub { get; set; }

    }

    public class GroupClause
    {
        public List<GroupCondition> GroupConditions { get; set; }
        public GroupClause()
        {
            this.GroupConditions = new List<GroupCondition>();
        }
    }

    public class HavingClause
    {
        public List<HavingCondition> HavingConditions { get; set; }
        public HavingClause()
        {
            this.HavingConditions = new List<HavingCondition>();
        }
    }

    public class OrderClause
    {
        public List<OrderCondition> OrderConditions { get; set; }

        public OrderClause()
        {
            this.OrderConditions = new List<OrderCondition>();
        }
    }

    public class OrderCondition
    {
    }

    public class LimitOffsetClauses
    {
        public LimitClause LimitClause { get; set; }
        public OffsetClause OffsetClause { get; set; }

    }
    public class GroupCondition
    {
        public Constraint Constraint { get; set; }
    }
    public class BuiltInCall
    {
        public Aggregate Aggregate { get; set; }
        public SubstringExpression SubstringExpression { get; set; }
        public StrReplaceExpression StrReplaceExpression { get; set; }
        public RegexExpression RegexExpression { get; set; }
        public ExistsFunc ExistsFunc { get; set; }
        public NotExistsFunc NotExistsFunc { get; set; }

        public List<Expression> Expressions { get; set; }
        public ExpressionList ExpressionList { get; set; }

        public BuiltInCall()
        {
            Expressions = new List<Expression>();
        }
    }

    public class FunctionCall
    {
        public Iri Iri { get; set; }
        public ArgList ArgList { get; set; }
    }

    public class HavingCondition
    {
        public Constraint Constraint { get; set; }
    }

    public class Constraint
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public BrackettedExpression BrackettedExpression { get; set; }
        /// <summary>
        /// 排他存在
        /// </summary>
        public BuiltInCall BuiltInCall { get; set; }
        /// <summary>
        /// 排他存在
        /// </summary>
        public FunctionCall FunctionCall { get; set; }

    }
    public class BrackettedExpression
    {
        public Expression Expression { get; set; }
    }

    public class LimitClause
    {
        public int Limit { get; set; }
    }

    public class OffsetClause
    {
        public int Offset { get; set; }
    }

    public class DataBlock
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public InlineDataOneVar InlineDataOneVar { get; set; }
        /// <summary>
        /// 排他存在
        /// </summary>
        public InlineDataFull InlineDataFull { get; set; }
    }

    public class Update1
    {
        public Load Load { get; set; }
        public Clear Clear { get; set; }
        public Drop Drop { get; set; }
        public Add Add { get; set; }
        public Move Move { get; set; }
        public Copy Copy { get; set; }
        public Create Create { get; set; }
        public InsertData InsertData { get; set; }
        public DeleteData DeleteData { get; set; }
        public DeleteWhere DeleteWhere { get; set; }
        public Modify Modify { get; set; }
    }

    public class Load
    {
        public bool HasSILENT { get; set; }
        public Iri Iri { get; set; }
        public GraphRef GraphRef { get; set; }
    }
    public class Clear
    {
        public bool HasSILENT { get; set; }
        public GraphRefAll graphRefAll { get; set; }

    }
    public class Drop
    {
        public bool HasSILENT { get; set; }
        public GraphRefAll GraphRefAll { get; set; }
    }
    public class Create
    {
        public bool HasSILENT { get; set; }
        public GraphRef GraphRef { get; set; }
    }

    public class Add
    {
        public bool HasSILENT { get; set; }
        public GraphOrDefault graphOrDefault_from { get; set; }
        public GraphOrDefault graphOrDefault_to { get; set; }

    }

    public class Move
    {
        public bool HasSILENT { get; set; }
        public GraphOrDefault GraphOrDefault_From { get; set; }
        public GraphOrDefault GraphOrDefault_To { get; set; }
    }

    public class Copy
    {
        public bool HasSILENT { get; set; }
        public GraphOrDefault GraphOrDefault_From { get; set; }
        public GraphOrDefault GraphOrDefault_To { get; set; }
    }
 
    public class InsertData
    {
        public QuadData QuadData { get; set; }
    }

    public class DeleteData
    {
        public QuadData QuadData { get; set; }
    }

    public class DeleteWhere
    {
        public QuadPattern QuadPattern { get; set; }
    }

    public class Modify
    {
        public Iri Iri_With;

        public DeleteClause DeleteClause { get; set; }
        public InsertClause InsertClause { get; set; }
        public UsingClause UsingClause { get; set; }
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class GraphRef
    {
        public Iri Iri { get; set; }
    }
    public class GraphRefAll
    {
        public GraphRef GraphRef { get; set; }
        public bool Is_DEFAULT { get; set; }
        public bool Is_NAMED { get; set; }
        public bool Is_ALL { get; set; }

    }

    public class GraphOrDefault
    {
        public bool Is_DEFAULT { get; set; }
        public Iri Iri { get; set; }
    }

    public class QuadData
    {
        public Quads Quads { get; set; }
    }

    public class QuadPattern
    {
        public Quads Quads { get; set; }
    }
    public class DeleteClause
    {
        public QuadPattern QuadPattern { get; set; }
    }
    public class InsertClause
    {
        public QuadPattern QuadPattern { get; set; }
    }

    public class UsingClause
    {
        public Iri Iri { get; set; }
    }

    public class Quads
    {
        public List<TriplesTemplate> TriplesTemplates { get; set; }
        public List<QuadsNotTriples> QuadsNotTriples { get; set; }

    }
    public class QuadsNotTriples
    {
        public VarOrIri VarOrIri { get; set; }
        public TriplesTemplate TriplesTemplate { get; set; }
    }

    public class GroupGraphPatternSub
    {
        public List<TriplesBlock> TriplesBlocks { get; set; }
        public List<GraphPatternNotTriples> GraphPatternNotTriples { get; set; }
    }

    public class TriplesBlock
    {
        public TriplesSameSubjectPath TriplesSameSubjectPath { get; set; }
        public TriplesBlock TriplesBlock0 { get; set; }
    }

    public class GraphPatternNotTriples
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public GroupOrUnionGraphPattern GroupOrUnionGraphPattern { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public OptionalGraphPattern OptionalGraphPattern { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public MinusGraphPattern MinusGraphPattern { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public GraphGraphPattern GraphGraphPattern { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public ServiceGraphPattern ServiceGraphPattern { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public Bind Bind { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public InlineData InlineData { get; set; }        
    }
    public class OptionalGraphPattern
    {
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class GraphGraphPattern
    {
        public VarOrIri VarOrIri { get; set; }
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class ServiceGraphPattern
    {
        public bool HasSILENT { get; set; }
        public VarOrIri VarOrIri { get; set; }
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class Bind
    {
        public Expression Expression { get; set; }
        public string Var { get; set; }
    }
    public class InlineData
    {
        public DataBlock DataBlock { get; set; }

    }
    public class InlineDataOneVar
    {
        public string Var { get; set; }
        public List<DataBlockValue> DataBlockValues { get; set; }
    }
    public class InlineDataFull
    {
        public string NIL { get; set; }
        public List<string> Vars { get; set; }
        public List<DataBlockValue> DataBlockValues { get; set; }
    }
    public class DataBlockValue
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public Iri Iri { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string RDFLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string NumericLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string BooleanLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public bool Is_UNDEF { get; set; }
    }
    public class MinusGraphPattern
    {
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class GroupOrUnionGraphPattern
    {
        public List<GroupGraphPattern> GroupGraphPatterns { get; set; }
    }
    public class Filter
    {
        public Constraint Constraint { get; set; }
    }
    public class ArgList
    {
        public bool Is_NIL { get; set; }
        public bool Is_DISTINCT { get; set; }
        public List<Expression> Expressions { get; set; }
    }
    public class ExpressionList
    {
        public bool Is_NIL { get; set; }        
        public List<Expression> Expressions { get; set; }
    }
    public class ConstructTriples
    {
        public TriplesSameSubject TriplesSameSubject { get; set; }
        public ConstructTriples ConstructTriples0 { get; set; }
    }
    public class TriplesSameSubject
    {
        public VarOrTerm VarOrTerm { get; set; }
        public PropertyListNotEmpty PropertyListNotEmpty { get; set; }

        public TriplesNode TriplesNode { get; set; }
        public PropertyList PropertyList { get; set; }
    }
    public class PropertyList
    {
        public PropertyListNotEmpty PropertyListNotEmpty { get; set; }
    }
    public class PropertyListNotEmpty
    {
        public List<Verb> Verbs { get; set; }
        public List<ObjectList> ObjectLists { get; set; }
    }
    public class ObjectList
    {
        public List<Object> Objects { get; set; }

    }
    public class Object
    {
        public GraphNode GraphNode { get; set; }
    }
    public class TriplesSameSubjectPath
    {
        public VarOrTerm VarOrTerm { get; set; }
        public PropertyListPathNotEmpty PropertyListPathNotEmpty { get; set; }

        public TriplesNodePath TriplesNodePath { get; set; }
        public PropertyListPath PropertyListPath { get; set; }
    }
    public class PropertyListPath
    {
        public PropertyListPathNotEmpty PropertyListPathNotEmpty { get; set; }
    }
    public class PropertyListPathNotEmpty
    {
        public List<VerbPath> VerbPaths { get; set; }
        public List<VerbSimple> VerbSimples { get; set; }
        public ObjectListPath ObjectListPath { get; set; }
        public List<ObjectList> ObjectLists { get; set; }

        public PropertyListPathNotEmpty()
        {
            this.VerbPaths = new List<VerbPath>();
            this.VerbSimples = new List<VerbSimple>();
            this.ObjectLists = new List<ObjectList>();
        }
    }
    public class VerbPath
    {
        public Path Path { get; set; }
    }
    public class VerbSimple
    {
        public Var Var { get; set; }
    }
    public class ObjectListPath
    {
        public List<ObjectPath> ObjectPaths { get; set; }
        public ObjectListPath()
        {
            this.ObjectPaths = new List<ObjectPath>();
        }
    }
    public class ObjectPath
    {
        public GraphNodePath GraphNodePath { get; set; }
    }
    public class Path
    {
        public PathAlternative PathAlternative { get; set; }
    }
    public class PathAlternative
    {
        public List<PathSequence> PathSequences { get; set; }
        public PathAlternative()
        {
            this.PathSequences = new List<PathSequence>();
        }
    }
    public class PathSequence
    {
        public List<PathEltOrInverse> PathEltOrInverses { get; set; }
        public PathSequence()
        {
            this.PathEltOrInverses = new List<PathEltOrInverse>();
        }
    }
    public class PathElt
    {
        public PathPrimary PathPrimary { get; set; }
        public PathMod PathMod { get; set; }
    }
    public class PathEltOrInverse
    {
        public PathElt PathElt { get; set; }
    }
    public class PathMod
    {
        /// <summary>
        /// '?' | '*' | '+'
        /// </summary>
        public string Mod { get; set; }
    }
    public class PathPrimary
    {
        public Iri Iri { get; set; }
        public bool IsA { get; set; }
        public PathNegatedPropertySet PathNegatedPropertySet { get; set; }
        public Path Path { get; set; }
    }
    public class PathNegatedPropertySet
    {
        public List<PathOneInPropertySet> PathOneInPropertySets { get; set; }
        public PathNegatedPropertySet()
        {
            this.PathOneInPropertySets = new List<PathOneInPropertySet>();
        }
    }
    public class PathOneInPropertySet
    {
        public Iri Iri { get; set; }
        public bool IsA { get; set; }
        /// <summary>
        ///  '^' ( iri | 'a' ) 
        /// </summary>
        public bool HasNot { get; set; }
    }
    public class Integer
    {
        public string INTEGER { get; set; }
    }
    public class TriplesNode
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public Collection Collection { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public BlankNodePropertyList BlankNodePropertyList { get; set; }
    }
    public class BlankNodePropertyList
    {
        public PropertyListNotEmpty PropertyListNotEmpty { get; set; }
    }
    public class TriplesNodePath
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public CollectionPath CollectionPath { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public BlankNodePropertyListPath BlankNodePropertyListPath { get; set; }

    }
    public class BlankNodePropertyListPath
    {
        public PropertyListPathNotEmpty PropertyListPathNotEmpty { get; set; }
    }
    public class Collection
    {
        public List<GraphNode> GraphNodes { get; set; }

        public Collection()
        {
            this.GraphNodes = new List<GraphNode>();
        }
    }
    public class CollectionPath
    {
        public List<GraphNodePath> GraphNodePaths { get; set; }
        public CollectionPath()
        {
            this.GraphNodePaths = new List<GraphNodePath>();
        }
    }
    public class GraphNode
    {

        /// <summary>
        /// 排他存在
        /// </summary>
        public VarOrTerm VarOrTerm { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public TriplesNode TriplesNode { get; set; }
    }
    public class GraphNodePath
    {

        /// <summary>
        /// 排他存在
        /// </summary>
        public VarOrTerm VarOrTerm { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public TriplesNodePath TriplesNodePath { get; set; }
    }
    public class VarOrTerm
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public Var Var { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public GraphTerm GraphTerm { get; set; }
    }
    public class VarOrIri
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public Var Var { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public Iri Iri { get; set; }
    }

    public class GraphTerm
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public Iri Iri { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public RDFLiteral RDFLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public NumericLiteral NumericLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public BooleanLiteral BooleanLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public BlankNode BlankNode { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string NIL { get; set; }
    }

    public class ConditionalOrExpression
    {
        public List<ConditionalAndExpression> ConditionalAndExpressions { get; set; }

        public ConditionalOrExpression()
        {
            this.ConditionalAndExpressions = new List<ConditionalAndExpression>();
        }
    }

    public class ConditionalAndExpression
    {
        public List<ValueLogical> ValueLogicals { get; set; }

        public ConditionalAndExpression()
        {
            this.ValueLogicals = new List<ValueLogical>();
        }
    }
    public class ValueLogical
    {
        public RelationalExpression RelationalExpression { get; set; }
    }
    public class RelationalExpression
    {
        public List<NumericExpression> NumericExpression { get; set; }
        public ExpressionList ExpressionList { get; set; }

        public bool Is_Equal { get; set; }
        public bool Is_NotEqual { get; set; }
        public bool Is_LT { get; set; }
        public bool Is_GT { get; set; }
        public bool Is_LT_Equal { get; set; }
        public bool Is_GT_Equal { get; set; }
        public bool Is_In { get; set; }
        public bool Is_NotIn { get; set; }
    }

    public class NumericExpression
    {
        public AdditiveExpression AdditiveExpression { get; set; }
    }
    public class AdditiveExpression
    {
        public List<MultiplicativeExpression> MultiplicativeExpressions { get; set; }
        public bool Is_Add { get; set; }
        public bool Is_Subtraction { get; set; }
        public NumericLiteralPositive NumericLiteralPositive { get; set; }
        public NumericLiteralNegative NumericLiteralNegative { get; set; }

        public List<AdditiveExpressionMulti> AdditiveExpressionMultis { get; set; }

        public AdditiveExpression()
        {
            this.AdditiveExpressionMultis = new List<AdditiveExpressionMulti>();
            this.MultiplicativeExpressions = new List<MultiplicativeExpression>();
        }
    }

    public class AdditiveExpressionMulti
    {
        public NumericLiteralPositive NnumericLiteralPositive { get; set; }
        public NumericLiteralNegative NumericLiteralNegative { get; set; }
        public List<MultiplicativeExpressionItem> MultiplicativeExpressionItems { get; set; }

        public AdditiveExpressionMulti()
        {
            this.MultiplicativeExpressionItems = new List<MultiplicativeExpressionItem>();
        }
    }

    public class MultiplicativeExpressionItem
    {
        public bool Is_MULTIPLY { get; set; }
        public bool Is_DIVISION { get; set; }
    }

    public class MultiplicativeExpression
    {
        public UnaryExpression UnaryExpression { get; set; }
        public List<MultiplicativeExpressionItem> MultiplicativeExpressionItems { get; set; }

        public MultiplicativeExpression()
        {
            this.MultiplicativeExpressionItems = new List<MultiplicativeExpressionItem>();
        }
    }

    public class UnaryExpression
    {
        public bool Is_Not { get; set; }
        public bool IS_Add { get; set; }
        public bool IS_Substraction { get; set; }
        public PrimaryExpression PrimaryExpression { get; set; }
    }
    public class PrimaryExpression
    {
        public BrackettedExpression BrackettedExpression { get; set; }
        public BuiltInCall BuiltInCall { get; set; }
        public IriOrFunction IriOrFunction { get; set; }
        public RDFLiteral RDFLiteral { get; set; }
        public NumericLiteral NumericLiteral { get; set; }
        public BooleanLiteral BooleanLiteral { get; set; }
        public Var Var { get; set; }
    }
    public class RegexExpression
    {
        public List<Expression> Expressions { get; set; }
        public RegexExpression()
        {
            this.Expressions = new List<Expression>();
        }
    }
    public class SubstringExpression
    {
        public List<Expression> Expressions { get; set; }
        public SubstringExpression()
        {
            this.Expressions = new List<Expression>();
        }
    }

    public class StrReplaceExpression
    {
        public List<Expression> Expressions { get; set; }
        public StrReplaceExpression()
        {
            this.Expressions = new List<Expression>();
        }
    }

    public class ExistsFunc
    {
        public GroupGraphPattern GroupGraphPattern { get; set; }

    }
    public class NotExistsFunc
    {
        public GroupGraphPattern GroupGraphPattern { get; set; }
    }
    public class Aggregate
    {
        public bool Is_COUNT { get; set; }
        public bool Is_DISTINCT { get; set; }
        public bool Is_SUM { get; set; }
        public bool Is_MIN { get; set; }
        public bool Is_MAX { get; set; }
        public bool Is_AVG { get; set; }
        public bool Is_SAMPLE { get; set; }
        public bool Is_GROUP_CONCAT { get; set; }
        public bool Is_SEPARATOR { get; set; }
        public bool Is_ALL { get; set; }
        public Expression Expression { get; set; }
        public string String { get; set; }
    }
    public class IriOrFunction
    {
        public Iri iri { get; set; }
        public ArgList argList { get; set; }
    }
    public class RDFLiteral
    {
        public string String { get; set; }
        public string LANGTAG { get; set; }
        public Iri Iri { get; set; }
    }
    public class NumericLiteral
    {
        public NumericLiteralUnsigned NumericLiteralUnsigned { get; set; }
        public NumericLiteralPositive NumericLiteralPositive { get; set; }
        public NumericLiteralNegative NumericLiteralNegative { get; set; }
    }
    public class NumericLiteralUnsigned
    {
        public bool Is_INTEGER { get; set; }
        public bool Is_DECIMAL { get; set; }
        public bool Is_DOUBLE { get; set; }

        public string Value { get; set; }
    }
    public class NumericLiteralPositive
    {
        public bool Is_INTEGER_POSITIVE { get; set; }
        public bool Is_DECIMAL_POSITIVE { get; set; }
        public bool Is_DOUBLE_POSITIVE { get; set; }

        public string Value { get; set; }
    }
    public class NumericLiteralNegative
    {
        public bool Is_INTEGER_NEGATIVE { get; set; }
        public bool Is_DECIMAL_NEGATIVE { get; set; }
        public bool Is_DOUBLE_NEGATIVE { get; set; }

        public string Value { get; set; }
    }
    public class BooleanLiteral
    {
        public bool Value { get; set; }
    }
    public class String
    {
        public bool Is_STRING_LITERAL1{get;set;}
        public bool Is_STRING_LITERAL2 { get; set; }
        public bool Is_STRING_LITERAL_LONG1 { get; set; }
        public bool Is_STRING_LITERAL_LONG2 { get; set; }

        public string Value { get; set; }
    }
    public class PrefixedName
    {
        public bool Is_PNAME_LN { get; set; }
        public bool Is_PNAME_NS { get; set; }

        public string Value { get; set; }
    }
    public class BlankNode
    {
        public bool Is_BLANK_NODE_LABEL { get; set; }
        public bool Is_ANON { get; set; }

        public string Value { get; set; }

    }
}

