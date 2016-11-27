//package com.kopbit.onteditor.domain.manchester.models;import com.kopbit.onteditor.domain.manchester.common.TokenPair;import com.kopbit.onteditor.domain.manchester.ManchesterContext;import com.kopbit.onteditor.domain.manchester.common.IndentStringBuilder;
//import com.kopbit.onteditor.domain.manchester.common.TokenPair;
//parse(ManchesterContext context);parse(context)
//wise(ManchesterContext context);wise(context)
//format(ManchesterContext context ,IndentStringBuilder builder);format(context ,builder)
//buildResource(ManchesterContext context ,Object resource);buildResource(context ,resource)

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar Manchester;

description : conjunction (  OR conjunction )+
         | conjunction ;
conjunction : classIRI THAT restrictionNotAble ( AND restrictionNotAble )*
         | primary ( AND primary )*;         
restrictionNotAble: NOT? restriction;
primary :  NOT? ( restriction | atomic ) ;
restriction : 
         objectPropertyMin
         | objectPropertyMax
         | objectPropertySome
         | objectPropertyOnly
         | objectPropertyValue
         | objectPropertySelf
         | objectPropertyExactly
         | dataPropertySome
         | dataPropertyOnly
         | dataPropertyValue
         | dataPropertyMin
         | dataPropertyMax
         | dataPropertyExactly;
objectPropertySome:objectPropertyExpression SOME primary;
objectPropertyOnly:objectPropertyExpression ONLY primary;
objectPropertyValue:objectPropertyExpression VALUE individual;
objectPropertySelf:objectPropertyExpression SELF;
objectPropertyMin:objectPropertyExpression MIN INTEGER_VALUE  primary ?;
objectPropertyMax:objectPropertyExpression MAX INTEGER_VALUE primary ?;
objectPropertyExactly:objectPropertyExpression EXACTLY INTEGER_VALUE primary ?;

dataPropertySome:dataPropertyExpression SOME dataPrimary;
dataPropertyOnly:dataPropertyExpression ONLY dataPrimary;
dataPropertyValue:dataPropertyExpression VALUE literal;
dataPropertyMin:dataPropertyExpression MIN INTEGER_VALUE dataPrimary ?;
dataPropertyMax:dataPropertyExpression MAX INTEGER_VALUE dataPrimary ?;
dataPropertyExactly:dataPropertyExpression EXACTLY INTEGER_VALUE dataPrimary ? ;

atomic : classIRI
         | '{' individualList '}'  
         | '(' description ')' ;

individualList: individual +;

objectPropertyExpression : objectPropertyIRI | inverseObjectProperty ;
inverseObjectProperty : INVERSE objectPropertyIRI  ;
dataPropertyExpression : dataPropertyIRI ;

dataRange : dataConjunction ( OR dataConjunction )* ;
dataConjunction : dataPrimary ( AND dataPrimary )*;
dataPrimary : ( NOT )? dataAtomic ;
dataAtomic : datatype
         | '{' literalList '}'
         | datatypeRestriction 
         | '(' dataRange ')' ;
datatypeRestriction : datatype '[' facet restrictionValue ( ',' facet restrictionValue )* ']' ;
facet : LENGTH | MIN_LENGTH | MAX_LENGTH | PATTERN | LANG_RANGE | LE | LT | GE | GT ;
restrictionValue : literal ;
literalList: literal +;

classIRI : iri ;
datatype : datatypeIRI | INTEGER | DECIMAL | FLOAT | STRING ;
datatypeIRI : iri ;
objectPropertyIRI : iri ;
dataPropertyIRI : iri ;
annotationPropertyIRI : iri ;
individual : individualIRI | nodeID ;
individualIRI : iri ;
nodeID : BLANK_NODE_LABEL;//a finite sequence of characters matching the BLANK_NODE_LABEL production of [SPARQL]

literal : typedLiteral | stringLiteralNoLanguage | stringLiteralWithLanguage | integerLiteral | decimalLiteral | floatingPointLiteral;
typedLiteral : lexicalValue TYPE_TAG datatype;
stringLiteralNoLanguage : QUOTED_STRING;
stringLiteralWithLanguage : QUOTED_STRING LANGUAGE_TAG;
decimalLiteral : DECIMAL_VALUE;

integerLiteral : INTEGER_VALUE;
floatingPointLiteral : FLOAT_VALUE;
lexicalValue : QUOTED_STRING ;

entity : DATA_TYPE '(' datatype ')' 
       | CLASS '(' classIRI ')' 
       | OBJECT_PROPERTY '(' objectPropertyIRI ')' 
       | DATA_PROPERTY '('dataPropertyIRI ')' 
       | ANNOTATION_PROPERTY '(' annotationPropertyIRI ')' 
       | NAMED_INDIVIDUAL '(' individualIRI ')';

iri : FULL_IRI | ABBREVIATED_IRI | SIMPLE_IRI ;

//begin keywords is not case-insensitive
THAT:T H A T;
AND: A N D;
OR: O R;
ONLY:O N L Y;
SOME:S O M E;
NOT:N O T;
MIN:M I N;
MAX:M A X;
SELF:S E L F;
EXACTLY:E X A C T L Y;
VALUE:V A L U E;
INVERSE:I N V E R S E;
LENGTH:L E N G T H;
MIN_LENGTH:M I N L E N G T H;
MAX_LENGTH:M A X L E N G T H;
PATTERN:P A T T E R N;
LANG_RANGE:L A N G R A N G E;
INTEGER:I N T E G E R;
DECIMAL:D E C I M A L;
FLOAT:F L O A T;
STRING:S T R I N G;
DATA_TYPE:D A T A T Y P E;
CLASS:C L A S S;
OBJECT_PROPERTY:O B J E C T P R O P E R T Y;
DATA_PROPERTY:D A T A P R O P E R T Y;
ANNOTATION_PROPERTY:A N N O T A T I O N P R O P E R T Y;
NAMED_INDIVIDUAL:N A M E D I N D I V I D U A L;
GT:'>';
LT:'<';
GE:'>=';
LE:'<=';
fragment POSITIVE:'+';
fragment NEGATIVE:'-';
TYPE_TAG:'^^';
fragment DOT:'.';
//end keywords
DECIMAL_VALUE : (POSITIVE | NEGATIVE)? DIGITS '.' DIGITS;
INTEGER_VALUE : (POSITIVE | NEGATIVE)? DIGITS;
FLOAT_VALUE : ( POSITIVE | NEGATIVE)? ( DIGITS (DOT DIGITS)? EXPONENT? | DOT DIGITS (EXPONENT)?) ( 'f' | 'F' );
LANGUAGE_TAG : '@' [a-zA-Z]+ ('-' [a-zA-Z0-9]+)*;// (U+40) followed a nonempty sequence of characters matching the langtag production from [BCP 47]
QUOTED_STRING :  STRING_LITERAL1 | STRING_LITERAL2 | STRING_LITERAL_LONG1 | STRING_LITERAL_LONG2 ;// a finite sequence of characters in which " (U+22) and \ (U+5C) occur only in pairs of the form \" (U+5C, U+22) and \\ (U+5C, U+5C), enclosed in a pair of " (U+22) characters
BLANK_NODE_LABEL   :   '_:' ( PN_CHARS_U | [0-9] ) ((PN_CHARS|'.')* PN_CHARS)? ;
PREFIX_NAME : PN_PREFIX? ':' ; //a finite sequence of characters matching the PNAME_NS production of [SPARQL] and not matching any of the keyword terminals of the syntax
ABBREVIATED_IRI : PNAME_LN ;//a finite sequence of characters matching the PNAME_LN production of [SPARQL]
SIMPLE_IRI :PN_LOCAL ;// a finite sequence of characters matching the PN_LOCAL production of [SPARQL] and not matching any of the keyword terminals of the syntax
//NON_NEGATIVE_INTEGER : ZERO | POSITIVE_INTEGER ;
FULL_IRI :'<' (~[\u0000-\u0020<>"{}|^`\\])* '>';//an IRI as defined in [RFC 3987], enclosed in a pair of < (U+3C) and > (U+3E) characters

fragment EXPONENT : ('e' | 'E') ['+' | '-'] DIGITS ;
fragment DECIMAL_LITERAL : ['+' | '-'] DIGITS '.' DIGITS ;
fragment INTEGER_LITERAL : ['+' | '-'] DIGITS ;
fragment STRING_LITERAL1   :   QUOTE1 ( (~[\u0027\u005C\u000A\u000D]) | ECHAR )* QUOTE1 ;
fragment STRING_LITERAL2   :   QUOTE2 ( (~[\u0022\u005C\u000A\u000D]) | ECHAR )* QUOTE2 ;
fragment STRING_LITERAL_LONG1   :   '\'\'\'' ( ( '\'' | '\'\'' )? ( ~[\'\\] | ECHAR ) )* '\'\'\'' ;
fragment STRING_LITERAL_LONG2   :   '"""' ( ( '"' | '""' )? ( ~["\\] | ECHAR ) )* '"""' ;
fragment ECHAR   :   '\\' [tbnrf\\"'] ;
fragment POSITIVE_INTEGER : NON_ZERO  DIGIT* ;
fragment DIGITS : DIGIT+ ;// { digit } ;
fragment DIGIT : ZERO | NON_ZERO ;
fragment NON_ZERO : '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' ;
fragment ZERO : '0' ;

fragment PNAME_LN   :   PNAME_NS PN_LOCAL ;
fragment PNAME_NS   :   PN_PREFIX? ':' ;

fragment PN_PREFIX   :   PN_CHARS_BASE ((PN_CHARS|'.')* PN_CHARS)? ;
fragment PN_CHARS_BASE   :   (A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z) | [\u00C0-\u00D6] | [\u00D8-\u00F6] | [\u00F8-\u02FF] | [\u0370-\u037D] | [\u037F-\u1FFF] | [\u200C-\u200D] | [\u2070-\u218F] | [\u2C00-\u2FEF] | [\u3001-\uD7FF] | [\uF900-\uFDCF] | [\uFDF0-\uFFFD];// | [\u10000-\uEFFFF] ;
fragment PN_CHARS_U   :   PN_CHARS_BASE | '_' ;
fragment VARNAME   :   ( PN_CHARS_U | [0-9] ) ( PN_CHARS_U | [0-9] | '\u00B7' | [\u0300-\u036F] | [\u203F-\u2040] )* ;
fragment PN_CHARS   :   PN_CHARS_U | '-' | [0-9] | '\u00B7' | [\u0300-\u036F] | [\u203F-\u2040] ;
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

WS   :   ('\u0020' | '\u0009' | '\u000D' | '\u000A') {skip();} ;