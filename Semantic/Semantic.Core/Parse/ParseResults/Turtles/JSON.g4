/** Taken from "The Definitive ANTLR 4 Reference" by Terence Parr */

// Derived from http://json.org

grammar JSON;

json:   objectT
    |   arrayT
    ;

annotation:
              '(' annotation_pair ( ',' annotation_pair )* ')'
          ;
annotation_pair:
     annotation_tag '=' annotation_value              
;
annotation_tag:
                ID                    
              ;
annotation_value:
    STRINGT
    |   NUMBER    
    |   'true'  // keywords
    |   'false'
    |   'null'
;
objectT
    :   ('{' pair (',' pair)* '}' 
            |   '{' '}' // empty object
        ) annotation?
    ;
    
pair:   STRINGT ':' valueT annotation?;

arrayT
    :   '[' valueT (',' valueT)* ']'  
    |   '[' ']' // empty array
    ;

valueT
    :   STRINGT
    |   NUMBER
    |   objectT  // recursion
    |   arrayT   // recursion
    |   'true'  // keywords
    |   'false'
    |   'null'
    ;
ID  :     ('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;

STRINGT :  '"' (ESC | ~["\\])* '"' ;

fragment ESC :   '\\' (["\\/bfnrt] | UNICODE) ;
fragment UNICODE : 'u' HEX HEX HEX HEX ;
fragment HEX : [0-9a-fA-F] ;

NUMBER
    :   '-'? INT '.' [0-9]+ EXP? // 1.35, 1.35E-9, 0.3, -4.5
    |   '-'? INT EXP             // 1e10 -3e4
    |   '-'? INT                 // -3, 45
    ;

fragment INT :   '0' | [1-9] [0-9]* ; // no leading zeros
fragment EXP :   [Ee] [+\-]? INT ; // \- since - means "range" inside [...]

WS  :   [ \t\n\r]+ -> skip ;