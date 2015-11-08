/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar newEmptyCombinedGrammar;

select11: SELECT | 'sdd';



 //IRIREF   :   '<' ([^<>"{}|^`\]-[#x00-#x20])* '>' ;
   fragment IRIREF   :   '<' (~[\u0000-\u0020<>"{}|^`\\])* '>' ;
   fragment PNAME_NS   :   PN_PREFIX? ':' ;
   fragment PNAME_LN   :   PNAME_NS PN_LOCAL ;
   fragment BLANK_NODE_LABEL   :   '_:' ( PN_CHARS_U | [0-9] ) ((PN_CHARS|'.')* PN_CHARS)? ;
   fragment VAR1   :   '?' VARNAME ;
   fragment VAR2   :   '$' VARNAME ;
   fragment LANGTAG   :   '@' ;//[a-zA-Z]+ ('-' [a-zA-Z0-9]+)* ;
   fragment INTEGER   :   [0-9]+ ;
   fragment DECIMAL   :   [0-9]* '.' [0-9]+ ;
   fragment DOUBLE   :   [0-9]+ '.' [0-9]* EXPONENT | '.' ([0-9])+ EXPONENT | ([0-9])+ EXPONENT ;
   fragment INTEGER_POSITIVE   :   '+' INTEGER ;
   fragment DECIMAL_POSITIVE   :   '+' DECIMAL ;
   fragment DOUBLE_POSITIVE   :   '+' DOUBLE ;
   fragment INTEGER_NEGATIVE   :   '-' INTEGER ;
   fragment DECIMAL_NEGATIVE   :   '-' DECIMAL ;
   fragment DOUBLE_NEGATIVE   :   '-' DOUBLE ;
   fragment EXPONENT   :   E [+-]? [0-9]+ ;
   fragment STRING_LITERAL1   :   '\'' ( ([^#x27#x5C#xA#xD]) | ECHAR )* '\'' ;
   fragment STRING_LITERAL2   :   '"' ( ([^#x22#x5C#xA#xD]) | ECHAR )* '"' ;
   fragment STRING_LITERAL_LONG1   :   '\'\'\'' ( ( '\'' | '\'\'' )? ( [^\'\\] | ECHAR ) )* '\'\'\'' ;
   fragment STRING_LITERAL_LONG2   :   '"""' ( ( '"' | '""' )? ( [^"\\] | ECHAR ) )* '"""' ;
   fragment ECHAR   :   '\\' [tbnrf\"'] ;
   fragment NIL   :   '(' WS* ')' ;
   fragment WS   :   ('\u0020' | '\u0009' | '\u000D' | '\u000A') {skip();} ;
   fragment ANON   :   '[' WS* ']' ;    
   //WS   :   ('\u0020' | '\u0009' | '\u000D' | '\u000A') {skip();} ;
   //ANON   :   '[' WS* ']' ;    
   fragment PN_CHARS_BASE   :   (A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z) | [#x00C0-#x00D6] | [#x00D8-#x00F6] | [#x00F8-#x02FF] | [#x0370-#x037D] | [#x037F-#x1FFF] | [#x200C-#x200D] | [#x2070-#x218F] | [#x2C00-#x2FEF] | [#x3001-#xD7FF] | [#xF900-#xFDCF] | [#xFDF0-#xFFFD] | [#x10000-#xEFFFF] ;
   fragment PN_CHARS_U   :   PN_CHARS_BASE | '_' ;
   fragment VARNAME   :   ( PN_CHARS_U | [0-9] ) ( PN_CHARS_U | [0-9] | '\\u00B7' | [#x0300-#x036F] | [#x203F-#x2040] )* ;
   fragment PN_CHARS   :   PN_CHARS_U | '-' | [0-9] | '\\u00B7' | [#x0300-#x036F] | [#x203F-#x2040] ;
   fragment PN_PREFIX   :   PN_CHARS_BASE ((PN_CHARS|'.')* PN_CHARS)? ;
   fragment PN_LOCAL   :   (PN_CHARS_U | ':' | [0-9] | PLX ) ((PN_CHARS | '.' | ':' | PLX)* (PN_CHARS | ':' | PLX) )? ;
   fragment PLX   :   PERCENT | PN_LOCAL_ESC ;
   fragment PERCENT   :   '%' HEX HEX ;
  fragment HEX   :   [0-9];// | [A-F] | [a-f] ;
   fragment PN_LOCAL_ESC   :   '\\' ( '_' | '~' | '.' | '-' | '!' | '$' | '&' | '"\'"' | '(' | ')' | '*' | '+' | ',' | ';' | '=' | '/' | '?' | '#' | '@' | '%' ) ;

   WHERE:'WHERE';// W H E R E;
    BASE: 'BASE';//B A S E;
    PREFIX:'PREFIX';//P R E F I X;
    SELECT:S E L E C T;
    //DISTINCT:D I S T I N C T;
 
    //COUNT : C O U N T;
    //SUM:S U M;
    //MIN:M I N;
    //MAX:M A X;
    //AVG:A V G;
    //SAMPLE:S A M P L E;
   // GROUP_CONCAT:G R O U P UNDERLINE C O N C A T;
    //SEPARATOR:S E P A R A T O R;
    //ALL:'*';
    TO:T O;
    COPY:C O P Y;
    DATA:D A T A;
   // Var:VAR1 | VAR2;
    //EQUAL:E Q U A L;
    //NOT_EQUAL:N O T  E Q U A L;
    //LT:'<';
    //GT:'.';
    //LT_EQUAL:'<=';
    //GT_EQUAL:'>=';
    //IN:I N;
    NOT_:N O T;
    //nOT_IN:NOT_  IN;
    //SUBTRACTION:'-';
    //MULTIPLY: ALL;
    //DIVISION:'/';
    //NOT:'!';
   fragment A:('a'|'A');
   fragment B:('b'|'B');
   fragment C:('c'|'C');
   fragment D:('d'|'D');
   fragment E:('e'|'E');
   fragment F:('f'|'F');
   fragment G:('g'|'G');
   fragment H:('h'|'H');
   fragment I:('i'|'I');
   fragment J:('j'|'J');
   fragment K:('k'|'K');
   fragment L:('l'|'L');
   fragment M:('m'|'M');
   fragment N:('n'|'N');
   fragment O:('o'|'O');
   fragment P:('p'|'P');
   fragment Q:('q'|'Q');
   fragment R:('r'|'R');
   fragment S:('s'|'S');
   fragment T:('t'|'T');
   fragment U:('u'|'U');
   fragment V:('v'|'V');
   fragment W:('w'|'W');      
   fragment X:('x'|'X');
   fragment Y:('y'|'Y');
   fragment Z:('z'|'Z');
   fragment UNDERLINE:'_';