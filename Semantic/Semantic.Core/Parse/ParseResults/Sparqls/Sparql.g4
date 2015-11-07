grammar Sparql;

queryUnit   :   query  ;
query   :   prologue
( selectQuery | constructQuery | describeQuery | askQuery )
valuesClause ;
   updateUnit   :   update  ;
   prologue   :   ( baseDecl | prefixDecl )* ;
   baseDecl   :   'BASE' IRIREF ;
   prefixDecl   :   PREFIX PNAME_NS IRIREF ;
   selectQuery   :   selectClause datasetClause* whereClause solutionModifier ;
   subSelect   :   selectClause whereClause solutionModifier valuesClause ;
   selectClause   :   SELECT ( 'DISTINCT' | 'REDUCED' )? ( ( var | ( '(' expression 'AS' var ')' ) )+ | ALL ) ;
   constructQuery   :   'CONSTRUCT' ( constructTemplate datasetClause* whereClause solutionModifier | datasetClause* WHERE '{' triplesTemplate? '}' solutionModifier ) ;
   describeQuery   :   'DESCRIBE' ( varOrIri+ | ALL ) datasetClause* whereClause? solutionModifier ;
   askQuery   :   'ASK' datasetClause* whereClause solutionModifier ;
   datasetClause   :   'FROM' ( defaultGraphClause | namedGraphClause ) ;
   defaultGraphClause   :   sourceSelector ;
   namedGraphClause   :   'NAMED' sourceSelector ;
   sourceSelector   :   iri ;
   whereClause   :   WHERE? groupGraphPattern ;
   solutionModifier   :   groupClause? havingClause? orderClause? limitOffsetClauses? ;
   groupClause   :   'GROUP' 'BY' groupCondition+ ;
   groupCondition   :   builtInCall | functionCall | '(' expression ( 'AS' var )? ')' | var  ;
   havingClause   :   'HAVING' havingCondition+ ;
   havingCondition   :   constraint ;
   select11: SELECT | 'sdd';
   orderClause   :   'ORDER' 'BY' orderCondition+ ;
   orderCondition   :    ( ( 'ASC' | 'DESC' ) brackettedExpression )
| ( constraint | var )  ;
   limitOffsetClauses   :   limitClause offsetClause? | offsetClause limitClause?  ;
   limitClause   :   'LIMIT' INTEGER ;
   offsetClause   :   'OFFSET' INTEGER ;
   valuesClause   :   ( 'VALUES' dataBlock )? ;
   update   :   prologue ( update1 ( ';' update )? )? ;
   update1   :   load | clear | drop | add | move | copy | create | insertData | deleteData | deleteWhere | modify ;
   load   :   'LOAD' 'SILENT'? iri ( 'INTO' graphRef )? ;
   clear   :   'CLEAR' 'SILENT'? graphRefAll ;
   drop   :   'DROP' 'SILENT'? graphRefAll ;
   create   :   'CREATE' 'SILENT'? graphRef ;
   add   :   'ADD' 'SILENT'? graphOrDefault 'TO' graphOrDefault ;
   move   :   'MOVE' 'SILENT'? graphOrDefault 'TO' graphOrDefault ;
   copy   :   'COPY' 'SILENT'? graphOrDefault 'TO' graphOrDefault ;
   insertData   :   'INSERT' 'DATA' quadData ;
   deleteData   :   'DELETE' 'DATA' quadData ;
   deleteWhere   :   'DELETE' 'WHERE' quadPattern ;
   modify   :   ( 'WITH' iri )? ( deleteClause insertClause? | insertClause ) usingClause* 'WHERE' groupGraphPattern ;
   deleteClause   :   'DELETE' quadPattern ;
   insertClause   :   'INSERT' quadPattern ;
   usingClause   :   'USING' ( iri | 'NAMED' iri ) ;
   graphOrDefault   :   'DEFAULT' | 'GRAPH'? iri  ;
   graphRef   :   'GRAPH' iri ;
   graphRefAll   :   graphRef | 'DEFAULT' | 'NAMED' | 'ALL' ;
   quadPattern   :   '{' quads '}' ;
   quadData   :   '{' quads '}' ;
   quads   :   triplesTemplate? ( quadsNotTriples '.'? triplesTemplate? )* ;
   quadsNotTriples   :   'GRAPH' varOrIri '{' triplesTemplate? '}' ;
   triplesTemplate   :   triplesSameSubject ( '.' triplesTemplate? )? ;
   groupGraphPattern   :   '{' ( subSelect | groupGraphPatternSub ) '}' ;
   groupGraphPatternSub   :   triplesBlock? ( graphPatternNotTriples '.'? triplesBlock? )* ;
   triplesBlock   :   triplesSameSubjectPath ( '.' triplesBlock? )? ;
   graphPatternNotTriples   :   groupOrUnionGraphPattern | optionalGraphPattern | minusGraphPattern | graphGraphPattern | serviceGraphPattern | filter | bind | inlineData ;
   optionalGraphPattern   :   'OPTIONAL' groupGraphPattern ;
   graphGraphPattern   :   'GRAPH' varOrIri groupGraphPattern ;
   serviceGraphPattern   :   'SERVICE' 'SILENT'? varOrIri groupGraphPattern ;
   bind   :   'BIND' '(' expression 'AS' Var ')' ;
   inlineData   :   'VALUES' dataBlock ;
   dataBlock   :   inlineDataOneVar | inlineDataFull ;
   inlineDataOneVar   :   Var '{' dataBlockValue* '}' ;
   inlineDataFull   :   ( NIL | '(' Var* ')' ) '{' ( '(' dataBlockValue* ')' | NIL )* '}' ;
   dataBlockValue   :   iri | RDFLiteral | NumericLiteral | BooleanLiteral | 'UNDEF' ;
   minusGraphPattern   :   'MINUS' groupGraphPattern ;
   groupOrUnionGraphPattern   :   groupGraphPattern ( 'UNION' groupGraphPattern )* ;
   filter   :   'FILTER' constraint ;
   constraint   :   brackettedExpression | builtInCall | functionCall ;
   functionCall   :   iri ArgList ;
   argList   :   NIL | '(' 'DISTINCT'? expression ( ',' expression )* ')'  ;
   expressionList   :   NIL | '(' expression ( ',' expression )* ')'  ;
   constructTemplate   :   '{' constructTriples? '}' ;
   constructTriples   :   triplesSameSubject ( '.' constructTriples? )? ;
   triplesSameSubject   :   varOrTerm propertyListNotEmpty | triplesNode propertyList ;
   propertyList   :   propertyListNotEmpty? ;
   propertyListNotEmpty   :   verb objectList ( ';' ( verb objectList )? )* ;
   verb   :   varOrIri | 'a' ;
   objectList   :   object ( ',' object )* ;
   object   :   graphNode ;
   triplesSameSubjectPath   :   varOrTerm propertyListPathNotEmpty | triplesNodePath propertyListPath ;
   propertyListPath   :   propertyListPathNotEmpty? ;
   propertyListPathNotEmpty   :   ( verbPath | verbSimple ) objectListPath ( ';' ( ( verbPath | verbSimple ) objectList )? )*; 
   verbPath   :   path ;
   verbSimple   :   var ;
   objectListPath   :   objectPath ( ',' objectPath )* ;
   objectPath   :   graphNodePath ;
   path   :   pathAlternative ;
   pathAlternative   :   pathSequence ( '|' pathSequence )* ;
   pathSequence   :   pathEltOrInverse ( '/' pathEltOrInverse )* ;
   pathElt   :   pathPrimary pathMod? ;
   pathEltOrInverse   :   pathElt | '^' pathElt ;
   pathMod   :   '?' | ALL | '+' ;
   pathPrimary   :   iri | 'a' | '!' pathNegatedPropertySet | '(' path ')'  ;
   pathNegatedPropertySet   :   pathOneInPropertySet | '(' ( pathOneInPropertySet ( '|' pathOneInPropertySet )* )? ')' ; 
   pathOneInPropertySet   :   iri | 'a' | '^' ( iri | 'a' )  ;
   integer   :   INTEGER ;
   triplesNode   :   collection | blankNodePropertyList ;
   blankNodePropertyList   :   '[' propertyListNotEmpty ']' ;
   triplesNodePath   :   collectionPath | blankNodePropertyListPath ;
   blankNodePropertyListPath   :   '[' propertyListPathNotEmpty ']' ;
   collection   :   '(' graphNode+ ')' ;
   collectionPath   :   '(' graphNodePath+ ')' ;
   graphNode   :   varOrTerm | triplesNode ;
   graphNodePath   :   varOrTerm | triplesNodePath ;
   varOrTerm   :   var | graphTerm ;
   varOrIri   :   var | iri ;
   var   :   VAR1 | VAR2 ;
   graphTerm   :   iri | rDFLiteral | numericLiteral | booleanLiteral | blankNode | NIL ;
   expression   :   conditionalOrExpression ;
   conditionalOrExpression   :   conditionalAndExpression ( '||' conditionalAndExpression )* ;
   conditionalAndExpression   :   valueLogical ( '&&' valueLogical )* ;
   valueLogical   :   relationalExpression ;
   EQUAL:'=';
   NOT_EQUAL:'!=';
   LT:'<';
   GT:'>';
   LT_EQUAL:'<=';
   GT_EQUAL:'>=';
   IN:'IN';
   NOT_IN:'NOT' 'IN';
   
   relationalExpression   :   numericExpression ( EQUAL numericExpression | NOT_EQUAL numericExpression | LT numericExpression | GT numericExpression | LT_EQUAL numericExpression | GT_EQUAL numericExpression | IN expressionList | NOT_IN expressionList )? ;
   numericExpression   :   additiveExpression ;
   ADD :'+';
   SUBTRACTION:'-';
   MULTIPLY:'*';
   DIVISION:'/';
   NOT:'!';
   additiveExpression   :   multiplicativeExpression ( ADD multiplicativeExpression | SUBTRACTION multiplicativeExpression | additiveExpressionMulti )* ;
   
   multiplicativeExpression   :   unaryExpression ( multiplicativeExpressionItem )* ;
   
   additiveExpressionMulti:
                             ( numericLiteralPositive | numericLiteralNegative ) ( multiplicativeExpressionItem )*
                         ;
   multiplicativeExpressionItem:
                                    MULTIPLY unaryExpression | DIVISION unaryExpression
                                ;
   unaryExpression   :     NOT primaryExpression 
| ADD primaryExpression 
| SUBTRACTION primaryExpression 
| primaryExpression ;
   primaryExpression   :   brackettedExpression | builtInCall | iriOrFunction | rDFLiteral | numericLiteral | booleanLiteral | var ;
   brackettedExpression   :   '(' expression ')' ;
   builtInCall   :     aggregate 
| 'STR' '(' expression ')' 
| 'LANG' '(' expression ')' 
| 'LANGMATCHES' '(' expression ',' expression ')' 
| 'DATATYPE' '(' expression ')' 
| 'BOUND' '(' var ')' 
| 'IRI' '(' expression ')' 
| 'URI' '(' expression ')' 
| 'BNODE' ( '(' expression ')' | NIL ) 
| 'RAND' NIL 
| 'ABS' '(' expression ')' 
| 'CEIL' '(' expression ')' 
| 'FLOOR' '(' expression ')' 
| 'ROUND' '(' expression ')' 
| 'CONCAT' expressionList 
| substringExpression 
| 'STRLEN' '(' expression ')' 
| strReplaceExpression 
| 'UCASE' '(' expression ')' 
| 'LCASE' '(' expression ')' 
| 'ENCODE_FOR_URI' '(' expression ')' 
| 'CONTAINS' '(' expression ',' expression ')' 
| 'STRSTARTS' '(' expression ',' expression ')' 
| 'STRENDS' '(' expression ',' expression ')' 
| 'STRBEFORE' '(' expression ',' expression ')' 
| 'STRAFTER' '(' expression ',' expression ')' 
| 'YEAR' '(' expression ')' 
| 'MONTH' '(' expression ')' 
| 'DAY' '(' expression ')' 
| 'HOURS' '(' expression ')' 
| 'MINUTES' '(' expression ')' 
| 'SECONDS' '(' expression ')' 
| 'TIMEZONE' '(' expression ')' 
| 'TZ' '(' expression ')' 
| 'NOW' NIL 
| 'UUID' NIL 
| 'STRUUID' NIL 
| 'MD5' '(' expression ')' 
| 'SHA1' '(' expression ')' 
| 'SHA256' '(' expression ')' 
| 'SHA384' '(' expression ')' 
| 'SHA512' '(' expression ')' 
| 'COALESCE' expressionList 
| 'IF' '(' expression ',' expression ',' expression ')' 
| 'STRLANG' '(' expression ',' expression ')' 
| 'STRDT' '(' expression ',' expression ')' 
| 'sameTerm' '(' expression ',' expression ')' 
| 'isIRI' '(' expression ')' 
| 'isURI' '(' expression ')' 
| 'isBLANK' '(' expression ')' 
| 'isLITERAL' '(' expression ')' 
| 'isNUMERIC' '(' expression ')' 
| regexExpression 
| existsFunc 
| notExistsFunc ;
   regexExpression   :   'REGEX' '(' expression ',' expression ( ',' expression )? ')' ;
   substringExpression   :   'SUBSTR' '(' expression ',' expression ( ',' expression )? ')' ;
   strReplaceExpression   :   'REPLACE' '(' expression ',' expression ',' expression ( ',' expression )? ')' ;
   existsFunc   :   'EXISTS' groupGraphPattern ;
   notExistsFunc   :   'NOT' 'EXISTS' groupGraphPattern ;
   COUNT : 'COUNT';
   DISTINCT : 'DISTINCT';
   SUM : 'SUM';
   MIN : 'MIN';
   MAX : 'MAX';
   AVG : 'AVG';
   SAMPLE : 'SAMPLE';
   GROUP_CONCAT : 'GROUP_CONCAT';
   SEPARATOR : 'SEPARATOR';   
   ALL:'*';
   
   aggregate   :     COUNT '(' DISTINCT? (ALL | expression ) ')' 
| SUM '(' DISTINCT? expression ')' 
| MIN '(' DISTINCT? expression ')' 
| MAX '(' DISTINCT? expression ')' 
| AVG '(' DISTINCT? expression ')' 
| SAMPLE '(' DISTINCT? expression ')' 
| GROUP_CONCAT '(' DISTINCT? expression ( ';' SEPARATOR '=' string )? ')'  ;
   iriOrFunction   :   iri argList? ;
   rDFLiteral   :   string ( LANGTAG | ( '^^' iri ) )? ;
   numericLiteral   :   numericLiteralUnsigned | numericLiteralPositive | numericLiteralNegative ;
   numericLiteralUnsigned   :   INTEGER | DECIMAL | DOUBLE ;
   numericLiteralPositive   :   INTEGER_POSITIVE | DECIMAL_POSITIVE | DOUBLE_POSITIVE ;
   numericLiteralNegative   :   INTEGER_NEGATIVE | DECIMAL_NEGATIVE | DOUBLE_NEGATIVE ;
   booleanLiteral   :   'true' | 'false' ;
   string   :   STRING_LITERAL1 | STRING_LITERAL2 | STRING_LITERAL_LONG1 | STRING_LITERAL_LONG2 ;
   iri   :   IRIREF | prefixedName ;
   prefixedName   :   PNAME_LN | PNAME_NS ;
   blankNode   :   BLANK_NODE_LABEL | ANON ;

   //IRIREF   :   '<' ([^<>"{}|^`\]-[#x00-#x20])* '>' ;
   IRIREF   :   '<' (~[\u0000-\u0020<>"{}|^`\\])* '>' ;
   PNAME_NS   :   PN_PREFIX? ':' ;
   PNAME_LN   :   PNAME_NS PN_LOCAL ;
   BLANK_NODE_LABEL   :   '_:' ( PN_CHARS_U | [0-9] ) ((PN_CHARS|'.')* PN_CHARS)? ;
   VAR1   :   '?' VARNAME ;
   VAR2   :   '$' VARNAME ;
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
   EXPONENT   :   [eE] [+-]? [0-9]+ ;
   STRING_LITERAL1   :   '\'' ( ([^#x27#x5C#xA#xD]) | ECHAR )* '\'' ;
   STRING_LITERAL2   :   '"' ( ([^#x22#x5C#xA#xD]) | ECHAR )* '"' ;
   STRING_LITERAL_LONG1   :   '\'\'\'' ( ( '\'' | '\'\'' )? ( [^\'\\] | ECHAR ) )* '\'\'\'' ;
   STRING_LITERAL_LONG2   :   '"""' ( ( '"' | '""' )? ( [^"\\] | ECHAR ) )* '"""' ;
   ECHAR   :   '\\' [tbnrf\"'] ;
   NIL   :   '(' WS* ')' ;
   WS   :   ('\u0020' | '\u0009' | '\u000D' | '\u000A') {skip();} ;
   ANON   :   '[' WS* ']' ;    
   PN_CHARS_BASE   :   [A-Z] | [a-z] | [#x00C0-#x00D6] | [#x00D8-#x00F6] | [#x00F8-#x02FF] | [#x0370-#x037D] | [#x037F-#x1FFF] | [#x200C-#x200D] | [#x2070-#x218F] | [#x2C00-#x2FEF] | [#x3001-#xD7FF] | [#xF900-#xFDCF] | [#xFDF0-#xFFFD] | [#x10000-#xEFFFF] ;
   PN_CHARS_U   :   PN_CHARS_BASE | '_' ;
   VARNAME   :   ( PN_CHARS_U | [0-9] ) ( PN_CHARS_U | [0-9] | '\\u00B7' | [#x0300-#x036F] | [#x203F-#x2040] )* ;
   PN_CHARS   :   PN_CHARS_U | '-' | [0-9] | '\\u00B7' | [#x0300-#x036F] | [#x203F-#x2040] ;
   PN_PREFIX   :   PN_CHARS_BASE ((PN_CHARS|'.')* PN_CHARS)? ;
   PN_LOCAL   :   (PN_CHARS_U | ':' | [0-9] | PLX ) ((PN_CHARS | '.' | ':' | PLX)* (PN_CHARS | ':' | PLX) )? ;
   PLX   :   PERCENT | PN_LOCAL_ESC ;
   PERCENT   :   '%' HEX HEX ;
   HEX   :   [0-9] | [A-F] | [a-f] ;
   PN_LOCAL_ESC   :   '\\' ( '_' | '~' | '.' | '-' | '!' | '$' | '&' | '"\'"' | '(' | ')' | '*' | '+' | ',' | ';' | '=' | '/' | '?' | '#' | '@' | '%' ) ;

   WHERE: W H E R E;
    BASE:B A S E;
    PREFIX:P R E F I X;
    SELECT:S E L E C T;
    //DISTINCT:D I S T I N C T;
    REDUCED:R E D U C E D;
    AS:A S;
    CONSTRUCT:C O N S T R U C T;
    DESCRIBE:D E S C R I B E;
    ASK:A S K;
    FROM:F R O M;
    NAMED:N A M E D;
    GROUP:G R O U P;
    BY:B Y;
    HAVING:H A V I N G;
    ORDER:O R D E R;
    ASC:A S C;
    DESC:D E S C;
    LIMIT:L I M I T;
    OFFSET:O F F S E T;
    VALUES:V A L U E S;
    LOAD:L O A D;
    SILENT:S I L E N T;
    INTO:I N T O;
    CLEAR:C L E A R;
    DROP:D R O P;
    CREATE:C R E A T E;
    //ADD:A D D;
    MOVE:M O V E;
    WITH:W I T H;
    DELETE:D E L E T E;
    INSERT:I N S E R T;
    USING:U S I N G;
    DEFAULT:D E F A U L T;
    GRAPH:G R A P H;
    //ALL:A L L;
    OPTIONAL:O P T I O N A L;
    SERVICE:S E R V I C E;
    BIND:B I N D;
    MINUS:M I N U S;
    UNDEF:U N D E F;
    UNION:U N I O N;
    FILTER:F I L T E R;
    STR:S T R;
    LANG:L A N G;
    LANGMATCHES:L A N G M A T C H E S;
    DATATYPE:D A T A T Y P E;
    BOUND:B O U N D;
    IRI:I R I;
    URI:U R I;
    BNODE:B N O D E;
    RAND:R A N D;
    ABS:A B S;
    CEIL:C E I L;
    FLOOR:F L O O R;
    ROUND:R O U N D;
    CONCAT:C O N C A T;
    STRLEN:S T R L E N;
    UCASE:U C A S E;
    LCASE:L C A S E;
    ENCODE_FOR_URI:E N C O D E UNDERLINE F O R UNDERLINE U R I;
    CONTAINS:C O N T A I N S;
    STRSTARTS:S T R S T A R T S;
    STRENDS:S T R E N D S;
    STRBEFORE:S T R B E F O R E;
    STRAFTER:S T R A F T E R;
    YEAR:Y E A R;
    MONTH:M O N T H;
    DAY:D A Y;
    HOURS:H O U R S;
    MINUTES:M I N U T E S;
    SECONDS:S E C O N D S;
    TIMEZONE:T I M E Z O N E;
    TZ:T Z;
    NOW:N O W;
    UUID:U U I D;
    STRUUID:S T R U U I D;
    MD5:M D '5';
    SHA1:S H A '1';
    SHA256:S H A '256';
    SHA384:S H A '384';
    SHA512:S H A '512';
    COALESCE:C O A L E S C E;
    IF:I F;
    STRLANG:S T R L A N G;
    STRDT:S T R D T;
    SameTerm:S A M E T E R M;
    IsIRI:I S I R I;
    IsURI:I S U R I;
    IsBLANK:I S B L A N K;
    IsLITERAL:I S L I T E R A L;
    IsNUMERIC:I S N U M E R I C;
    REGEX:R E G E X;
    SUBSTR:S U B S T R;
    REPLACE:R E P L A C E;
    EXISTS:E X I S T S;
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
    nOT_IN:NOT_  IN;
    //SUBTRACTION:'-';
    //MULTIPLY: ALL;
    //DIVISION:'/';
    //NOT:'!';
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