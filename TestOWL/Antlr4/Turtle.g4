//namespace CodeHelper.Core.Parse.ParseResults.Sparqls;
//CodeHelper.Core.Parse.ParseResults.Sparqls;
//Parse(SparqlContext context);Parse(context)

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar Turtle;

turtleDoc :statement* ;
statement :directive |  triples '.' ;
directive :prefixID |  base |  sparqlPrefix |  sparqlBase ;
prefixID :'@prefix' PNAME_NS IRIREF '.' ;
base :'@base' IRIREF '.' ;
sparqlBase :'BASE' IRIREF ;
sparqlPrefix :'PREFIX' PNAME_NS IRIREF ;
triples :subject predicateObjectList |  blankNodePropertyList predicateObjectList? ;
predicateObjectList :verbObjectList (';' (verbObjectList)?)* ;
verbObjectList:verb objectList;
objectList :object (',' object)* ;
verb :predicate |  'a' ;
subject :iRI |  blankNode |  collection ;
predicate: iRI ;
object :iRI |  blankNode |  collection |  blankNodePropertyList |  literal ;
literal :RDFLiteral |  NumericLiteral |  BooleanLiteral ;
blankNodePropertyList :'[' predicateObjectList ']' ;
collection :'(' object* ')' ;
NumericLiteral :INTEGER |  DECIMAL |  DOUBLE ;
RDFLiteral :String (LANGTAG |  '^^' (IRIREF | PNAME_LN |  PNAME_NS ))? ;
BooleanLiteral :'true' |  'false' ;
String :STRING_LITERAL_QUOTE |  STRING_LITERAL_SINGLE_QUOTE |  STRING_LITERAL_LONG_SINGLE_QUOTE |  STRING_LITERAL_LONG_QUOTE ;
iRI :IRIREF |  prefixedName ;
//pNAME_NS: PNAME_NS;
prefixedName :PNAME_LN |  PNAME_NS ;
blankNode :BLANK_NODE_LABEL |  ANON ;
//IRIREF :'<' ([^#x00-#x20<>"{}|^`\\] |  UCHAR)* '>' ;/* #x00=NULL #01-#x1F=control codes #x20=space */ 


IRIREF :'<' (~['\u0000'..'\u0020'<>"{}|^`\\] | PN_CHARS | UCHAR)* '>' ;/* #x00=NULL #01-#x1F=control codes #x20=space */ 
//IRIREF :'<' .* '>' ;/* #x00=NULL #01-#x1F=control codes #x20=space */ 


PNAME_NS :PN_PREFIX? ':' ;

PNAME_LN :PNAME_NS PN_LOCAL ;

BLANK_NODE_LABEL :'_:' (PN_CHARS_U |  [0-9]) ((PN_CHARS |  '.')* PN_CHARS)? ;

LANGTAG :'@' [a-zA-Z]+ ('-' [a-zA-Z0-9]+)* ;

INTEGER :[+-]? [0-9]+ ;
DECIMAL :[+-]? [0-9]* '.' [0-9]+ ;
DOUBLE :[+-]? ([0-9]+ '.' [0-9]* EXPONENT |  '.' [0-9]+ EXPONENT |  [0-9]+ EXPONENT) ;
EXPONENT :[eE] [+-]? [0-9]+ ;
//STRING_LITERAL_QUOTE :'"' ([^#x22#x5C#xA#xD] |  ECHAR |  UCHAR)* '"' ;/* #x22=" #x5C=\ #xA=new line #xD=carriage return */ 
STRING_LITERAL_QUOTE :'"' (~['\u0022''\u005C''\u000A''\u000D'] |  ECHAR |  UCHAR)* '"' ;/* #x22=" #x5C=\ #xA=new line #xD=carriage return */ 
//STRING_LITERAL_SINGLE_QUOTE :'\'' ([^#x27#x5C#xA#xD] |  ECHAR |  UCHAR)* '\'' ;/* #x27=' #x5C=\ #xA=new line #xD=carriage return */ 
STRING_LITERAL_SINGLE_QUOTE :'\'' (~['\u0027''\u005C''\u000A''\u000D'] |  ECHAR |  UCHAR)* '\'' ;/* #x27=' #x5C=\ #xA=new line #xD=carriage return */ 
STRING_LITERAL_LONG_SINGLE_QUOTE :'\'\'\'' (('\'' |  '\'\'')? (~['\\] |  ECHAR |  UCHAR))* '\'\'\'' ;
STRING_LITERAL_LONG_QUOTE :'"""' (('"' |  '""')? (~["\\] |  ECHAR |  UCHAR))* '"""' ;
UCHAR :('\\u' HEX HEX HEX HEX) |  ('\\U' HEX HEX HEX HEX HEX HEX HEX HEX) ;
ECHAR :'\\' [tbnrf"\'\\] ;
//WS :#x20 |  #x9 |  #xD |  #xA ;/* #x20=space #x9=character tabulation #xD=carriage return #xA=new line */ 
WS :('\u0020' |  '\u0009' |  '\u000D' |  '\u000A') {skip();};/* #x20=space #x9=character tabulation #xD=carriage return #xA=new line */ 
COMMENT:
            ('#'  ~['\r''\n']*) {skip();}
       ;
ANON :'[' WS* ']' ;
//PN_CHARS_BASE :[A-Z] |  [a-z] |  [#x00C0-#x00D6] |  [#x00D8-#x00F6] |  [#x00F8-#x02FF] |  [#x0370-#x037D] |  [#x037F-#x1FFF] |  [#x200C-#x200D] |  [#x2070-#x218F] |  [#x2C00-#x2FEF] |  [#x3001-#xD7FF] |  [#xF900-#xFDCF] |  [#xFDF0-#xFFFD] |  [#x10000-#xEFFFF] ;
PN_CHARS_BASE :[A-Z] |  [a-z] |  ['\u00C0'..'\u00D6'] |  ['\u00D8'..'\u00F6'] |  ['\u00F8'..'\u02FF'] |  ['\u0370'..'\u037D'] |  ['\u037F'..'\u1FFF'] |  ['\u200C'..'\u200D'] |  ['\u2070'..'\u218F'] |  ['\u2C00'..'\u2FEF'] |  ['\u3001'..'\uD7FF'] |  ['\uF900'..'\uFDCF'] |  ['\uFDF0'..'\uFFFD'] |  ['\u10000'..'\uEFFFF'] ;
PN_CHARS_U :PN_CHARS_BASE |  '_' ;
//PN_CHARS :PN_CHARS_U |  '-' |  [0-9] |  #x00B7 |  [#x0300-#x036F] |  [#x203F-#x2040] ;
PN_CHARS :PN_CHARS_U |  '-' |  [0-9] |  '\u00B7' |  ['\u0300'..'\u036F'] |  ['\u203F'..'\u2040'] ;

PN_PREFIX :PN_CHARS_BASE ((PN_CHARS |  '.')* PN_CHARS)? ;
PN_LOCAL :(PN_CHARS_U |  ':' |  [0-9] |  PLX) ((PN_CHARS |  '.' |  ':' |  PLX)* (PN_CHARS |  ':' |  PLX))? ;
PLX :PERCENT |  PN_LOCAL_ESC ;
PERCENT :'%' HEX HEX ;
HEX :[0-9] |  [A-F] |  [a-f] ;
PN_LOCAL_ESC :'\\' ('_' |  '~' |  '.' |  '-' |  '!' |  '$' |  '&' |  '\'' |  '(' |  ')' |  '*' |  '+' |  ',' |  ';' |  '=' |  '/' |  '?' |  '#' |  '@' |  '%') ;