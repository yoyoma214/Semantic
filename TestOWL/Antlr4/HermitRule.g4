//package com.kopbit.onteditor.domain.swrl.models;
//CodeHelper.Core.Parse.ParseResults.Swrls;
//Parse(SwrlContext context);Parse(context)
//Wise(SwrlContext context);Wise(context)
//Format(SwrlContext context ,IndentStringBuilder builder);Format(context ,builder)
//BuildQuery(SwrlContext context ,IndentStringBuilder builder);BuildQuery(context ,builder)
//BuildMock(SwrlContext context ,IndentStringBuilder builder);BuildMock(context ,builder)
//BuildOther(SwrlContext context ,IndentStringBuilder builder);BuildOther(context ,builder)

grammar HermitRule;

document: prefix * ontology;
prefix: PREFIX '(' prefix_item ')';
ontology : ONTOLOGY '('IRIREF axioms ')';
prefix_item : PNAME IRIREF; 
//varname : VARNAME?  ':';
axioms : ( axiom | ruleN | dGAxiom )*;
ruleN : dLSafeRule | dGRule;
dLSafeRule : DL_SAFE_RULE '(' annotation* BODY '(' atom* ')'
    HEAD '(' head ')' ')';

head: atom*;
axiom : declaration | classAxiom | objectPropertyAxiom | dataPropertyAxiom | datatypeDefinition | hasKey | assertion | annotationAxiom;
declaration: DECLARATION '(' axiomAnnotations entity ')';

entity: class_entity | data_type_entity | object_property_entity 
        | data_property_entity | annotation_property_entity | named_individual_entity;
class_entity:CLASS '(' classN ')';
data_type_entity:DATA_TYPE '(' datatype ')';
object_property_entity:OBJECT_PROPERTY '(' objectProperty ')';
data_property_entity:DATA_PROPERTY '(' dataProperty ')';
annotation_property_entity:ANNOTATION_PROPERTY '(' annotationProperty ')';
named_individual_entity:NAMED_INDIVIDUAL '(' namedIndividual ')';

classAxiom:subClassOf | equivalentClasses | disjointClasses | disjointUnion;
subClassOf:SUB_CLASS_OF '(' axiomAnnotations subClassExpression superClassExpression ')';
equivalentClasses:EQUIVALENT_CLASSES '(' axiomAnnotations classExpression classExpression classExpression* ')';
subClassExpression : classExpression;
superClassExpression:classExpression;
disjointClasses:DISJOINT_CLASSES '(' axiomAnnotations classExpression classExpression classExpression* ')';
disjointUnion:DISJOINT_UNION '(' axiomAnnotations classN disjointClassExpressions ')';
disjointClassExpressions:classExpression classExpression classExpression*;
objectPropertyAxiom: 
     subObjectPropertyOf | equivalentObjectProperties |
     disjointObjectProperties | inverseObjectProperties |
     objectPropertyDomain | objectPropertyRange |
     functionalObjectProperty | inverseFunctionalObjectProperty |
     reflexiveObjectProperty | irreflexiveObjectProperty |
     symmetricObjectProperty | asymmetricObjectProperty |
     transitiveObjectProperty;
subObjectPropertyOf:SUB_OBJECT_PROPERTY_OF '(' axiomAnnotations subObjectPropertyExpression superObjectPropertyExpression ')';
subObjectPropertyExpression:objectPropertyExpression | propertyExpressionChain;
propertyExpressionChain:OBJECT_PROPERTY_CHAIN '(' objectPropertyExpression objectPropertyExpression objectPropertyExpression* ')';
superObjectPropertyExpression:objectPropertyExpression;
equivalentObjectProperties:EQUIVALENT_OBJECT_PROPERTIES '(' axiomAnnotations objectPropertyExpression objectPropertyExpression objectPropertyExpression* ')';
disjointObjectProperties:DISJOINT_OBJECT_PROPERTIES '(' axiomAnnotations objectPropertyExpression objectPropertyExpression objectPropertyExpression* ')';

objectPropertyDomain : OBJECT_PROPERTY_DOMAIN '(' axiomAnnotations objectPropertyExpression classExpression ')';

objectPropertyRange : OBJECT_PROPERTY_RANGE '(' axiomAnnotations objectPropertyExpression classExpression ')';

inverseObjectProperties : INVERSE_OBJECT_PROPERTIES '(' axiomAnnotations objectPropertyExpression objectPropertyExpression ')';

functionalObjectProperty : FUNCTIONAL_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

inverseFunctionalObjectProperty : INVERSE_FUNCTIONAL_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

reflexiveObjectProperty : REFLEXIVE_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

irreflexiveObjectProperty : IRREFLEXIVE_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

symmetricObjectProperty : SYMMETRIC_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

asymmetricObjectProperty : ASYMMETRIC_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

transitiveObjectProperty : TRANSITIVE_OBJECT_PROPERTY '(' axiomAnnotations objectPropertyExpression ')';

dataPropertyAxiom :
     subDataPropertyOf | equivalentDataProperties | disjointDataProperties |
     dataPropertyDomain | dataPropertyRange | functionalDataProperty;

subDataPropertyOf : SUB_DATA_PROPERTY_OF '(' axiomAnnotations subDataPropertyExpression superDataPropertyExpression ')';
subDataPropertyExpression : dataPropertyExpression;
superDataPropertyExpression : dataPropertyExpression;

equivalentDataProperties : EQUIVALENT_DATA_PROPERTIES '(' axiomAnnotations dataPropertyExpression dataPropertyExpression dataPropertyExpression* ')';

disjointDataProperties : DISJOINT_DATA_PROPERTIES '(' axiomAnnotations dataPropertyExpression dataPropertyExpression dataPropertyExpression* ')';

dataPropertyDomain : DATA_PROPERTY_DOMAIN '(' axiomAnnotations dataPropertyExpression classExpression ')';

dataPropertyRange : DATA_PROPERTY_RANGE '(' axiomAnnotations dataPropertyExpression dataRange ')';

functionalDataProperty :FUNCTIONAL_DATA_PROPERTY '(' axiomAnnotations dataPropertyExpression ')';

datatypeDefinition : DATATYPE_DEFINITION '(' axiomAnnotations datatype dataRange ')';

hasKey : HAS_KEY '(' axiomAnnotations classExpression '(' objectPropertyExpression* ')' '(' dataPropertyExpression* ')' ')';

atom:
        class_atom | data_range_atom | object_property_atom 
    | data_property_atom | built_in_atom | same_individual_atom
    | different_individuals_atom
    ;
class_atom:CLASS_ATOM '(' classExpression iArg ')';
data_range_atom:DATA_RANGE_ATOM '(' dataRange dArg ')';
object_property_atom:OBJECT_PROPERTY_ATOM '(' objectPropertyExpression iArg iArg ')';
data_property_atom:DATA_PROPERTY_ATOM '(' dataProperty iArg dArg ')';
built_in_atom:BUILT_IN_ATOM '(' iRI dArg dArg* ')';
same_individual_atom:SAME_INDIVIDUAL_ATOM '(' iArg iArg ')';
different_individuals_atom:DIFFERENT_INDIVIDUALS_ATOM '(' iArg iArg')';

iArg : VARIABLE '(' iRI ')' | individual;
dArg : VARIABLE '(' iRI ')' | literal;
dGRule : DESCRIPTION_GRAPH_RULE '(' annotation* BODY '(' dGAtom* ')'
HEAD '(' headDGRule ')' ')';
headDGRule:dGAtom*;
dGAtom : CLASS_ATOM '(' classExpression iArg ')'
| OBJECT_PROPERTY_ATOM '(' objectPropertyExpression iArg iArg ')';
dGAxiom : DESCRIPTION_GRAPH '(' annotation* dGNodes
    dGEdges mainClasses')';
dGNodes : NODES'(' nodeAssertion nodeAssertion* ')';
nodeAssertion : NODE_ASSERTION'(' classN dGNode ')';
dGNode : iRI;
dGEdges : EDGES'(' edgeAssertion edgeAssertion* ')';
edgeAssertion : EDGE_ASSERTION '(' objectProperty dGNode dGNode')';
mainClasses : MAIN_CLASSES '(' classN classN* ')';

annotationSubject : iRI | anonymousIndividual;
annotationValue : anonymousIndividual | iRI | literal;
axiomAnnotations : annotation*;

annotation : ANNOTATION '(' annotationAnnotations annotationProperty annotationValue ')';
annotationAnnotations  :  annotation*;
annotationProperty : iRI;
annotationAxiom : annotationAssertion | subAnnotationPropertyOf | annotationPropertyDomain | annotationPropertyRange;

annotationAssertion : ANNOTATION_ASSERTION '(' axiomAnnotations annotationProperty annotationSubject annotationValue ')';

subAnnotationPropertyOf : SUB_ANNOTATION_PROPERTY_OF '(' axiomAnnotations subAnnotationProperty superAnnotationProperty ')';
subAnnotationProperty : annotationProperty;
superAnnotationProperty : annotationProperty;

annotationPropertyDomain : ANNOTATION_PROPERTY_DOMAIN '(' axiomAnnotations annotationProperty iRI ')';

annotationPropertyRange : ANNOTATION_PROPERTY_RANGE '(' axiomAnnotations annotationProperty iRI ')' ;

classExpression:     classN |
     objectIntersectionOf | objectUnionOf | objectComplementOf | objectOneOf |
     objectSomeValuesFrom | objectAllValuesFrom | objectHasValue | objectHasSelf |
     objectMinCardinality | objectMaxCardinality | objectExactCardinality |
     dataSomeValuesFrom | dataAllValuesFrom | dataHasValue |
     dataMinCardinality | dataMaxCardinality | dataExactCardinality;

objectIntersectionOf : OBJECT_INTERSECTION_OF '(' classExpression classExpression  classExpression* ')';

objectUnionOf : OBJECT_UNION_OF '(' classExpression classExpression classExpression* ')';

objectComplementOf : OBJECT_COMPLEMENT_OF '(' classExpression ')';

objectOneOf : OBJECT_ONE_OF '(' individual individual*')';

objectSomeValuesFrom : OBJECT_SOME_VALUES_FROM '(' objectPropertyExpression classExpression ')';

objectAllValuesFrom : OBJECT_ALL_VALUES_FROM '(' objectPropertyExpression classExpression ')';

objectHasValue : OBJECT_HAS_VALUE '(' objectPropertyExpression individual ')';

objectHasSelf : OBJECT_HAS_SELF '(' objectPropertyExpression ')';

objectMinCardinality : OBJECT_MIN_CARDINALITY '(' INTEGER objectPropertyExpression classExpression? ')';

objectMaxCardinality : OBJECT_MAX_CARDINALITY '(' INTEGER objectPropertyExpression  classExpression ? ')';

objectExactCardinality : OBJECT_EXACT_CARDINALITY '(' INTEGER objectPropertyExpression classExpression? ')';

dataSomeValuesFrom : DATA_SOME_VALUES_FROM '(' dataPropertyExpression dataPropertyExpression* dataRange ')';

dataAllValuesFrom : DATA_ALL_VALUES_FROM '(' dataPropertyExpression dataPropertyExpression* dataRange ')';

dataHasValue : DATA_HAS_VALUE '(' dataPropertyExpression literal ')';

dataMinCardinality : DATA_MIN_CARDINALITY '(' INTEGER dataPropertyExpression  dataRange? ')';

dataMaxCardinality : DATA_MAX_CARDINALITY '(' INTEGER dataPropertyExpression dataRange?  ')';

dataExactCardinality : DATA_EXACT_CARDINALITY '(' INTEGER dataPropertyExpression dataRange? ')';

dataPropertyExpression : dataProperty;

assertion :
     sameIndividual | differentIndividuals | classAssertion |
     objectPropertyAssertion | negativeObjectPropertyAssertion |
     dataPropertyAssertion | negativeDataPropertyAssertion;

sourceIndividual : individual;
targetIndividual : individual;
targetValue : literal;

sameIndividual : SAME_INDIVIDUAL '(' axiomAnnotations individual individual  individual* ')';

differentIndividuals : DIFFERENT_INDIVIDUALS '(' axiomAnnotations individual individual individual* ')';

classAssertion : CLASS_ASSERTION '(' axiomAnnotations classExpression individual ')';

objectPropertyAssertion : OBJECT_PROPERTY_ASSERTION '(' axiomAnnotations objectPropertyExpression sourceIndividual targetIndividual ')';

negativeObjectPropertyAssertion : NEGATIVE_OBJECT_PROPERTY_ASSERTION '(' axiomAnnotations objectPropertyExpression sourceIndividual targetIndividual ')';

dataPropertyAssertion : DATA_PROPERTY_ASSERTION '(' axiomAnnotations dataPropertyExpression sourceIndividual targetValue ')';

negativeDataPropertyAssertion : NEGATIVE_DATA_PROPERTY_ASSERTION '(' axiomAnnotations dataPropertyExpression sourceIndividual targetValue ')' ;

dataRange :
     datatype |
     dataIntersectionOf |
     dataUnionOf |
     dataComplementOf |
     dataOneOf |
     datatypeRestriction ;
dataIntersectionOf : DATA_INTERSECTION_OF '(' dataRange dataRange dataRange* ')' ;
dataUnionOf : DATA_UNION_OF '(' dataRange dataRange dataRange* ')' ;
dataComplementOf : DATA_COMPLEMENT_OF '(' dataRange ')' ;
dataOneOf : DATA_ONE_OF '(' literal literal* ')' ;
datatype : iRI;
objectPropertyExpression : objectProperty | inverseObjectProperty;
inverseObjectProperty : OBJECT_INVERSE_OF '(' objectProperty ')';       
datatypeRestriction : DATATYPE_RESTRICTION '(' datatype constrainingFacet restrictionValue ( constrainingFacet restrictionValue)* ')';
constrainingFacet : iRI ;
restrictionValue : literal;
dataProperty:iRI;
individual: namedIndividual | anonymousIndividual;
namedIndividual:iRI;
anonymousIndividual:BLANK_NODE_LABEL;                    
literal: String ( LANGTAG | xsdIri)? ;
String   :   STRING_LITERAL1 | STRING_LITERAL2 | STRING_LITERAL_LONG1 | STRING_LITERAL_LONG2 ;
classN:iRI;
objectProperty:iRI;
iRI:  IRIREF | prefixedName ;
   prefixedName   :  PNAME ;// PNAME_LN | PNAME_NS ;
   blankNode   :   BLANK_NODE_LABEL | ANON ; 
   xsdIri: '^^' (IRIREF | prefixedName);//PNAME_LN | PNAME_NS;
   COMMENT:
            ('#'  .*? ('\r'| '\r\n')) {skip();}
       ;
   IRIREF   :   '<' (~[\u0000-\u0020<>"{}|^`\\])* '>' ;   
   PNAME :PN_PREFIX? ':' PN_LOCAL? ;
   //PNAME_NS   :   PN_PREFIX? ':' ;
   //PNAME_LN   :   PN_PREFIX? ':' PN_LOCAL ;
   BLANK_NODE_LABEL   :   '_:' ( PN_CHARS_U | [0-9] ) ((PN_CHARS|'.')* PN_CHARS)? ;
   //VAR1   :   '?' VARNAME ;
   //VAR2   :   '$' VARNAME ;
   LANGTAG   :   '@' [a-zA-Z]+ ('-' [a-zA-Z0-9]+)* ;
   INTEGER   :   [0-9]+ ;
   DECIMAL   :   [0-9]* '.' [0-9]+ ;
   DOUBLE   :   [0-9]+ '.' [0-9]* EXPONENT | '.' ([0-9])+ EXPONENT | ([0-9])+ EXPONENT ;
   INTEGER_POSITIVE   :   '+' INTEGER ;
   DECIMAL_POSITIVE   :   '+' DECIMAL ;
   DOUBLE_POSITIVE   :   '+' DOUBLE ;
   INTEGER_NEGATIVE   :   '-' INTEGER ;
   DECIMAL_NEGATIVE   :   '-' DECIMAL ;
   DOUBLE_NEGATIVE   :   '-' DOUBLE ;
   fragment EXPONENT   :   E [+-]? [0-9]+ ;
   fragment STRING_LITERAL1   :   QUOTE1 ( (~[\u0027\u005C\u000A\u000D]) | ECHAR )* QUOTE1 ;
   fragment STRING_LITERAL2   :   QUOTE2 ( (~[\u0022\u005C\u000A\u000D]) | ECHAR )* QUOTE2 ;
   fragment STRING_LITERAL_LONG1   :   '\'\'\'' ( ( '\'' | '\'\'' )? ( ~[\'\\] | ECHAR ) )* '\'\'\'' ;
   fragment STRING_LITERAL_LONG2   :   '"""' ( ( '"' | '""' )? ( ~["\\] | ECHAR ) )* '"""' ;
   fragment ECHAR   :   '\\' [tbnrf\\"'] ;
   NIL   :   '(' WS* ')' ;
   WS   :   ('\u0020' | '\u0009' | '\u000D' | '\u000A') {skip();} ;
   ANON   :   '[' WS* ']' ;    
   
    DL_SAFE_RULE:'DLSafeRule';
    BODY:'Body';
    HEAD:'Head';
    DECLARATION:'Declaration';
    CLASS:'Class';
    DATA_TYPE:'Datatype';
    OBJECT_PROPERTY:'ObjectProperty';
    DATA_PROPERTY:'DataProperty';
    ANNOTATION_PROPERTY:'AnnotationProperty';
    NAMED_INDIVIDUAL:'NamedIndividual';
    SUB_CLASS_OF:'SubClassOf';
    EQUIVALENT_CLASSES:'EquivalentClasses';
    DISJOINT_CLASSES:'DisjointClasses';
    DISJOINT_UNION:'DisjointUnion';
    SUB_OBJECT_PROPERTY_OF:'SubObjectPropertyOf';
    OBJECT_PROPERTY_CHAIN:'ObjectPropertyChain';
    EQUIVALENT_OBJECT_PROPERTIES:'EquivalentObjectProperties';
    DISJOINT_OBJECT_PROPERTIES:'DisjointObjectProperties';
    OBJECT_PROPERTY_DOMAIN:'ObjectPropertyDomain';
    OBJECT_PROPERTY_RANGE:'ObjectPropertyRange';
    INVERSE_OBJECT_PROPERTIES:'InverseObjectProperties';
    FUNCTIONAL_OBJECT_PROPERTY:'FunctionalObjectProperty';
    INVERSE_FUNCTIONAL_OBJECT_PROPERTY:'InverseFunctionalObjectProperty';
    REFLEXIVE_OBJECT_PROPERTY:'ReflexiveObjectProperty';
    IRREFLEXIVE_OBJECT_PROPERTY :'IrreflexiveObjectProperty';
    SYMMETRIC_OBJECT_PROPERTY:'SymmetricObjectProperty';
    ASYMMETRIC_OBJECT_PROPERTY:'AsymmetricObjectProperty';
    TRANSITIVE_OBJECT_PROPERTY:'TransitiveObjectProperty';
    SUB_DATA_PROPERTY_OF:'SubDataPropertyOf';
    EQUIVALENT_DATA_PROPERTIES:'EquivalentDataProperties';
    DISJOINT_DATA_PROPERTIES:'DisjointDataProperties';
    DATA_PROPERTY_DOMAIN:'DataPropertyDomain';
    DATA_PROPERTY_RANGE:'DataPropertyRange';
    FUNCTIONAL_DATA_PROPERTY:'FunctionalDataProperty';
    DATATYPE_DEFINITION:'DatatypeDefinition';
    HAS_KEY:'HasKey';
    CLASS_ATOM:'ClassAtom';
    DATA_RANGE_ATOM:'DataRangeAtom';
    OBJECT_PROPERTY_ATOM:'ObjectPropertyAtom';
    DATA_PROPERTY_ATOM:'DataPropertyAtom';
    BUILT_IN_ATOM:'BuiltInAtom';
    SAME_INDIVIDUAL_ATOM:'SameIndividualAtom';
    DIFFERENT_INDIVIDUALS_ATOM:'DifferentIndividualsAtom';
    VARIABLE:'Variable';
    DESCRIPTION_GRAPH_RULE:'DescriptionGraphRule';
    DESCRIPTION_GRAPH:'DescriptionGraph';
    NODES:'Nodes';
    NODE_ASSERTION:'NodeAssertion';
    EDGES:'Edges';
    EDGE_ASSERTION:'EdgeAssertion';
    MAIN_CLASSES:'MainClasses';
    ANNOTATION:'Annotation';
    ANNOTATION_ASSERTION:'AnnotationAssertion';
    SUB_ANNOTATION_PROPERTY_OF:'SubAnnotationPropertyOf';
    ANNOTATION_PROPERTY_DOMAIN:'AnnotationPropertyDomain';
    ANNOTATION_PROPERTY_RANGE:'AnnotationPropertyRange';
    OBJECT_INTERSECTION_OF:'ObjectIntersectionOf';
    OBJECT_UNION_OF:'ObjectUnionOf';
    OBJECT_COMPLEMENT_OF:'ObjectComplementOf';
    OBJECT_ONE_OF:'ObjectOneOf';
    OBJECT_SOME_VALUES_FROM:'ObjectSomeValuesFrom';
    OBJECT_ALL_VALUES_FROM:'ObjectAllValuesFrom';
    OBJECT_HAS_VALUE:'ObjectHasValue';
    OBJECT_HAS_SELF:'ObjectHasSelf';
    OBJECT_MIN_CARDINALITY:'ObjectMinCardinality';
    OBJECT_MAX_CARDINALITY:'ObjectMaxCardinality';
    OBJECT_EXACT_CARDINALITY:'ObjectExactCardinality';
    DATA_SOME_VALUES_FROM:'DataSomeValuesFrom';
    DATA_ALL_VALUES_FROM:'DataAllValuesFrom';
    DATA_HAS_VALUE:'DataHasValue';
    DATA_MIN_CARDINALITY:'DataMinCardinality';
    DATA_MAX_CARDINALITY:'DataMaxCardinality';
    DATA_EXACT_CARDINALITY:'DataExactCardinality';
    SAME_INDIVIDUAL:'SameIndividual';
    DIFFERENT_INDIVIDUALS:'DifferentIndividuals';
    CLASS_ASSERTION:'ClassAssertion';
    OBJECT_PROPERTY_ASSERTION:'ObjectPropertyAssertion';
    NEGATIVE_OBJECT_PROPERTY_ASSERTION:'NegativeObjectPropertyAssertion';
    DATA_PROPERTY_ASSERTION:'DataPropertyAssertion';
    NEGATIVE_DATA_PROPERTY_ASSERTION:'NegativeDataPropertyAssertion';
    DATA_INTERSECTION_OF:'DataIntersectionOf';
    DATA_UNION_OF:'DataUnionOf';
    DATA_COMPLEMENT_OF:'DataComplementOf';
    DATA_ONE_OF:'DataOneOf';
    OBJECT_INVERSE_OF:'ObjectInverseOf';
    DATATYPE_RESTRICTION:'DatatypeRestriction';
    PREFIX:'Prefix';
    ONTOLOGY:'Ontology';
   // VAR:VARNAME? ':';
   fragment PN_CHARS_BASE   :   (A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z) | [\u00C0-\u00D6] | [\u00D8-\u00F6] | [\u00F8-\u02FF] | [\u0370-\u037D] | [\u037F-\u1FFF] | [\u200C-\u200D] | [\u2070-\u218F] | [\u2C00-\u2FEF] | [\u3001-\uD7FF] | [\uF900-\uFDCF] | [\uFDF0-\uFFFD];// | [\u10000-\uEFFFF] ;
   fragment PN_CHARS_U   :   PN_CHARS_BASE | '_' ;
   fragment VARNAME   :   ( PN_CHARS_U | [0-9] ) ( PN_CHARS_U | [0-9] | '\u00B7' | [\u0300-\u036F] | [\u203F-\u2040] )* ;   
   fragment PN_CHARS   :   PN_CHARS_U | '-' | [0-9] | '\u00B7' | [\u0300-\u036F] | [\u203F-\u2040] ;
   fragment PN_PREFIX   :   PN_CHARS_BASE ((PN_CHARS|'.')* PN_CHARS)? ;
   fragment PN_LOCAL   :   (PN_CHARS_U | ':' | [0-9] | PLX ) ((PN_CHARS | '.' | ':' | PLX)* (PN_CHARS | ':' | PLX) )? ;
   fragment PLX   :   PERCENT | PN_LOCAL_ESC ;
   fragment PERCENT   :   '%' HEX HEX ;
   fragment HEX   :   [0-9] | (A|B|C|D|E|F) ;
   fragment PN_LOCAL_ESC   :   '\\' ( '_' | '~' | '.' | '-' | '!' | '$' | '&' | '"\'"' | '(' | ')' | '*' | '+' | ',' | ';' | '=' | '/' | '?' | '#' | '@' | '%' ) ;
   fragment QUOTE2:'"';
   fragment QUOTE1:'\'';   
   
   fragment A:[aA];
   fragment B:[bB];
   fragment C:[cC];
   fragment D:[dD];
   fragment E:[eE];
   fragment F:[fF];
   fragment G:[gG];
   fragment H:[hH];
   fragment I:[iI];
   fragment J:[jJ];
   fragment K:[kK];
   fragment L:[lL];
   fragment M:[mM];
   fragment N:[nN];
   fragment O:[oO];
   fragment P:[pP];
   fragment Q:[qQ];
   fragment R:[rR];
   fragment S:[sS];
   fragment T:[tT];
   fragment U:[uU];
   fragment V:[vV];
   fragment W:[wW];      
   fragment X:[xX];
   fragment Y:[yY];
   fragment Z:[zZ];
   fragment UNDERLINE:'_';