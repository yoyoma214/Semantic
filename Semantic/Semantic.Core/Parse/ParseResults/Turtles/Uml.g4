/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar Uml;

umlModel:
            (entity | character)*
        ;
entity:
          annotation*
          'class' ID inherit?
          '{'
               field *
          '}'
      ;

character:
           annotation*
          'character' ID inherit?
          '{'
               field *
          '}'
;

inherit:
           ':' (ID (',' ID)*)
       ;
field:
         annotation*
         system_type ID ';'
     ;

system_type:
               ID
           ;

annotation:
        '[' ID '(' annotation_pair (',' annotation_pair)* ')' ']'
    ;

annotation_pair:
     ID '=' valueT              
;

valueT:
          STRINGT | BOOL | NUMBER | 'null'
      ;

BOOL     :     'true' | 'false';
    
ID  :     ('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*
    ;

NUMBER
    :   '-'? INT '.' [0-9]+ EXP? // 1.35, 1.35E-9, 0.3, -4.5
    |   '-'? INT EXP             // 1e10 -3e4
    |   '-'? INT                 // -3, 45
    ;

fragment INT :   '0' | [1-9] [0-9]* ; // no leading zeros
fragment EXP :   [Ee] [+\-]? INT ; // \- since - means "range" inside [...]
COMMENT
    :  ( '//' ~('\n'|'\r')* '\r'? '\n' 
        |   '/*'  .*? '*/') {Skip();}
        
    ;

WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {Skip();}
    ;

STRINGT
    :  '"' ( ESC_SEQ | ~('\"'|'\\') )* '"'
    ;
     
CHAR:  '\'' ( ESC_SEQ | ~('\''|'\\') ) '\''
    ;

fragment
EXPONENT : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
HEX_DIGIT : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
ESC_SEQ
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    |   UNICODE_ESC
    |   OCTAL_ESC
    ;

fragment
OCTAL_ESC
    :   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7')
    ;

fragment
UNICODE_ESC
    :   '\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
    ;