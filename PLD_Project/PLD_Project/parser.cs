
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                     =  0, // (EOF)
        SYMBOL_ERROR                   =  1, // (Error)
        SYMBOL_WHITESPACE              =  2, // (Whitespace)
        SYMBOL_MINUS                   =  3, // '-'
        SYMBOL_EXCLAMEQ                =  4, // '!='
        SYMBOL_NUM                     =  5, // '#'
        SYMBOL_LPARAN                  =  6, // '('
        SYMBOL_RPARAN                  =  7, // ')'
        SYMBOL_TIMES                   =  8, // '*'
        SYMBOL_TIMESEQ                 =  9, // '*='
        SYMBOL_DIV                     = 10, // '/'
        SYMBOL_DIVEQ                   = 11, // '/='
        SYMBOL_COLON                   = 12, // ':'
        SYMBOL_BACKSLASH               = 13, // '\'
        SYMBOL_LBRACE                  = 14, // '{'
        SYMBOL_RBRACE                  = 15, // '}'
        SYMBOL_PLUS                    = 16, // '+'
        SYMBOL_PLUSEQ                  = 17, // '+='
        SYMBOL_LT                      = 18, // '<'
        SYMBOL_LTEQ                    = 19, // '<='
        SYMBOL_EQ                      = 20, // '='
        SYMBOL_MINUSEQ                 = 21, // '-='
        SYMBOL_EQEQ                    = 22, // '=='
        SYMBOL_GT                      = 23, // '>'
        SYMBOL_GTEQ                    = 24, // '>='
        SYMBOL_BOOL                    = 25, // Bool
        SYMBOL_CASE                    = 26, // case
        SYMBOL_DIGIT                   = 27, // Digit
        SYMBOL_DO                      = 28, // do
        SYMBOL_FOR                     = 29, // for
        SYMBOL_FROM                    = 30, // from
        SYMBOL_IDENTIFIER              = 31, // Identifier
        SYMBOL_IF                      = 32, // if
        SYMBOL_LOOP                    = 33, // loop
        SYMBOL_OTHERWISE               = 34, // otherwise
        SYMBOL_OTHERWISE_IF            = 35, // 'otherwise_if'
        SYMBOL_SHOW                    = 36, // show
        SYMBOL_STRINGLITERAL           = 37, // StringLiteral
        SYMBOL_SWITCH                  = 38, // switch
        SYMBOL_TO                      = 39, // to
        SYMBOL_UNTIL                   = 40, // until
        SYMBOL_WHILE                   = 41, // while
        SYMBOL_ASSIGNMENT_OPERATOR     = 42, // <assignment_operator>
        SYMBOL_ASSIGNMENT_STATEMENT    = 43, // <assignment_statement>
        SYMBOL_CASE_CLAUSE             = 44, // <case_clause>
        SYMBOL_CASE_CLAUSE_LIST        = 45, // <case_clause_list>
        SYMBOL_COMPARISON              = 46, // <comparison>
        SYMBOL_COMPLEX_STATEMENT       = 47, // <complex_statement>
        SYMBOL_CONDITIONAL_STATEMENT   = 48, // <conditional_statement>
        SYMBOL_CONTAINER               = 49, // <container>
        SYMBOL_DO_WHILE_LOOP_STATEMENT = 50, // <do_while_loop_statement>
        SYMBOL_ELSE_CLAUSE             = 51, // <else_clause>
        SYMBOL_ELSEIF_CLAUSE           = 52, // <elseif_clause>
        SYMBOL_ELSEIF_CLAUSE_LIST      = 53, // <elseif_clause_list>
        SYMBOL_EXPRESSION              = 54, // <expression>
        SYMBOL_EXPRESSION_STATEMENT    = 55, // <expression_statement>
        SYMBOL_FACTOR                  = 56, // <factor>
        SYMBOL_FOR_LOOP_STATEMENT      = 57, // <for_loop_statement>
        SYMBOL_IDENTIFIER2             = 58, // <identifier>
        SYMBOL_PHRASE                  = 59, // <phrase>
        SYMBOL_PRINT_STATEMENT         = 60, // <print_statement>
        SYMBOL_PROGRAM                 = 61, // <program>
        SYMBOL_SIMPLE_STATEMENT        = 62, // <simple_statement>
        SYMBOL_STATEMENT               = 63, // <statement>
        SYMBOL_STATEMENT_LIST          = 64, // <statement_list>
        SYMBOL_SWITCH_STATEMENT        = 65, // <switch_statement>
        SYMBOL_TERM                    = 66, // <term>
        SYMBOL_VARIABLE                = 67, // <variable>
        SYMBOL_WHILE_LOOP_STATEMENT    = 68  // <while_loop_statement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                                =  0, // <program> ::= <statement_list>
        RULE_STATEMENT_LIST                                                         =  1, // <statement_list> ::= <statement>
        RULE_STATEMENT_LIST2                                                        =  2, // <statement_list> ::= <statement> <statement_list>
        RULE_ELSEIF_CLAUSE_LIST                                                     =  3, // <elseif_clause_list> ::= <elseif_clause>
        RULE_ELSEIF_CLAUSE_LIST2                                                    =  4, // <elseif_clause_list> ::= <elseif_clause> <elseif_clause_list>
        RULE_CASE_CLAUSE_LIST                                                       =  5, // <case_clause_list> ::= <case_clause>
        RULE_CASE_CLAUSE_LIST2                                                      =  6, // <case_clause_list> ::= <case_clause> <case_clause_list>
        RULE_STATEMENT                                                              =  7, // <statement> ::= <simple_statement>
        RULE_STATEMENT2                                                             =  8, // <statement> ::= <complex_statement>
        RULE_SIMPLE_STATEMENT                                                       =  9, // <simple_statement> ::= <expression_statement>
        RULE_SIMPLE_STATEMENT2                                                      = 10, // <simple_statement> ::= <assignment_statement>
        RULE_SIMPLE_STATEMENT3                                                      = 11, // <simple_statement> ::= <print_statement>
        RULE_SIMPLE_STATEMENT4                                                      = 12, // <simple_statement> ::= <conditional_statement>
        RULE_COMPLEX_STATEMENT                                                      = 13, // <complex_statement> ::= <for_loop_statement>
        RULE_COMPLEX_STATEMENT2                                                     = 14, // <complex_statement> ::= <while_loop_statement>
        RULE_COMPLEX_STATEMENT3                                                     = 15, // <complex_statement> ::= <do_while_loop_statement>
        RULE_COMPLEX_STATEMENT4                                                     = 16, // <complex_statement> ::= <switch_statement>
        RULE_EXPRESSION_STATEMENT_NUM                                               = 17, // <expression_statement> ::= <expression> '#'
        RULE_ASSIGNMENT_STATEMENT_EQ_NUM                                            = 18, // <assignment_statement> ::= <variable> '=' <expression> '#'
        RULE_ASSIGNMENT_OPERATOR_EQ                                                 = 19, // <assignment_operator> ::= '='
        RULE_ASSIGNMENT_OPERATOR_PLUSEQ                                             = 20, // <assignment_operator> ::= '+='
        RULE_ASSIGNMENT_OPERATOR_MINUSEQ                                            = 21, // <assignment_operator> ::= '-='
        RULE_ASSIGNMENT_OPERATOR_TIMESEQ                                            = 22, // <assignment_operator> ::= '*='
        RULE_ASSIGNMENT_OPERATOR_DIVEQ                                              = 23, // <assignment_operator> ::= '/='
        RULE_COMPARISON_EQEQ                                                        = 24, // <comparison> ::= '=='
        RULE_COMPARISON_EXCLAMEQ                                                    = 25, // <comparison> ::= '!='
        RULE_COMPARISON_LT                                                          = 26, // <comparison> ::= '<'
        RULE_COMPARISON_GT                                                          = 27, // <comparison> ::= '>'
        RULE_COMPARISON_LTEQ                                                        = 28, // <comparison> ::= '<='
        RULE_COMPARISON_GTEQ                                                        = 29, // <comparison> ::= '>='
        RULE_PRINT_STATEMENT_SHOW_COLON_LPARAN_RPARAN_NUM                           = 30, // <print_statement> ::= show ':' '(' <expression> ')' '#'
        RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE         = 31, // <conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}'
        RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE2        = 32, // <conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <else_clause>
        RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE3        = 33, // <conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <elseif_clause_list> <else_clause>
        RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE4        = 34, // <conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <elseif_clause_list>
        RULE_ELSEIF_CLAUSE_OTHERWISE_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE       = 35, // <elseif_clause> ::= 'otherwise_if' '(' <expression> ')' '\' '{' <statement_list> '}'
        RULE_ELSE_CLAUSE_OTHERWISE_BACKSLASH_LBRACE_RBRACE                          = 36, // <else_clause> ::= otherwise '\' '{' <statement_list> '}'
        RULE_FOR_LOOP_STATEMENT_FOR_LPARAN_FROM_TO_RPARAN_BACKSLASH_LBRACE_RBRACE   = 37, // <for_loop_statement> ::= for <variable> '(' from <expression> to <expression> ')' '\' '{' <statement_list> '}'
        RULE_WHILE_LOOP_STATEMENT_LOOP_LBRACE_RBRACE_UNTIL_COLON_LPARAN_RPARAN_NUM  = 38, // <while_loop_statement> ::= loop '{' <statement_list> '}' until ':' '(' <expression> ')' '#'
        RULE_DO_WHILE_LOOP_STATEMENT_DO_LBRACE_RBRACE_WHILE_COLON_LPARAN_RPARAN_NUM = 39, // <do_while_loop_statement> ::= do '{' <statement_list> '}' while ':' '(' <expression> ')' '#'
        RULE_SWITCH_STATEMENT_SWITCH_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE          = 40, // <switch_statement> ::= switch '(' <expression> ')' '\' '{' <case_clause_list> '}'
        RULE_CASE_CLAUSE_CASE_COLON                                                 = 41, // <case_clause> ::= case <expression> ':' <statement_list>
        RULE_EXPRESSION                                                             = 42, // <expression> ::= <phrase>
        RULE_EXPRESSION2                                                            = 43, // <expression> ::= <expression> <assignment_operator> <phrase>
        RULE_PHRASE                                                                 = 44, // <phrase> ::= <container>
        RULE_PHRASE2                                                                = 45, // <phrase> ::= <phrase> <comparison> <container>
        RULE_CONTAINER                                                              = 46, // <container> ::= <term>
        RULE_CONTAINER_PLUS                                                         = 47, // <container> ::= <container> '+' <term>
        RULE_CONTAINER_MINUS                                                        = 48, // <container> ::= <container> '-' <term>
        RULE_TERM                                                                   = 49, // <term> ::= <factor>
        RULE_TERM_TIMES                                                             = 50, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                               = 51, // <term> ::= <term> '/' <factor>
        RULE_FACTOR                                                                 = 52, // <factor> ::= <variable>
        RULE_FACTOR_DIGIT                                                           = 53, // <factor> ::= Digit
        RULE_FACTOR_BOOL                                                            = 54, // <factor> ::= Bool
        RULE_FACTOR_STRINGLITERAL                                                   = 55, // <factor> ::= StringLiteral
        RULE_FACTOR_LPARAN_RPARAN                                                   = 56, // <factor> ::= '(' <expression> ')'
        RULE_VARIABLE                                                               = 57, // <variable> ::= <identifier>
        RULE_IDENTIFIER_IDENTIFIER                                                  = 58  // <identifier> ::= Identifier
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst1;
        ListBox lst2;

        public MyParser(string filename,ListBox lst1,ListBox lst2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst1 = lst1;
            this.lst2 = lst2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //'#'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BACKSLASH :
                //'\'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //Bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE :
                //otherwise
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE_IF :
                //'otherwise_if'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHOW :
                //show
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTIL :
                //until
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT_OPERATOR :
                //<assignment_operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT_STATEMENT :
                //<assignment_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_CLAUSE :
                //<case_clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_CLAUSE_LIST :
                //<case_clause_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISON :
                //<comparison>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPLEX_STATEMENT :
                //<complex_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONAL_STATEMENT :
                //<conditional_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTAINER :
                //<container>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_LOOP_STATEMENT :
                //<do_while_loop_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE_CLAUSE :
                //<else_clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEIF_CLAUSE :
                //<elseif_clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEIF_CLAUSE_LIST :
                //<elseif_clause_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION_STATEMENT :
                //<expression_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_LOOP_STATEMENT :
                //<for_loop_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER2 :
                //<identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PHRASE :
                //<phrase>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STATEMENT :
                //<print_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SIMPLE_STATEMENT :
                //<simple_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_LIST :
                //<statement_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STATEMENT :
                //<switch_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE :
                //<variable>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_LOOP_STATEMENT :
                //<while_loop_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST :
                //<statement_list> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST2 :
                //<statement_list> ::= <statement> <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSEIF_CLAUSE_LIST :
                //<elseif_clause_list> ::= <elseif_clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSEIF_CLAUSE_LIST2 :
                //<elseif_clause_list> ::= <elseif_clause> <elseif_clause_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CLAUSE_LIST :
                //<case_clause_list> ::= <case_clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CLAUSE_LIST2 :
                //<case_clause_list> ::= <case_clause> <case_clause_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <simple_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <complex_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT :
                //<simple_statement> ::= <expression_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT2 :
                //<simple_statement> ::= <assignment_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT3 :
                //<simple_statement> ::= <print_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT4 :
                //<simple_statement> ::= <conditional_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPLEX_STATEMENT :
                //<complex_statement> ::= <for_loop_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPLEX_STATEMENT2 :
                //<complex_statement> ::= <while_loop_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPLEX_STATEMENT3 :
                //<complex_statement> ::= <do_while_loop_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPLEX_STATEMENT4 :
                //<complex_statement> ::= <switch_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_STATEMENT_NUM :
                //<expression_statement> ::= <expression> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_STATEMENT_EQ_NUM :
                //<assignment_statement> ::= <variable> '=' <expression> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_OPERATOR_EQ :
                //<assignment_operator> ::= '='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_OPERATOR_PLUSEQ :
                //<assignment_operator> ::= '+='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_OPERATOR_MINUSEQ :
                //<assignment_operator> ::= '-='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_OPERATOR_TIMESEQ :
                //<assignment_operator> ::= '*='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_OPERATOR_DIVEQ :
                //<assignment_operator> ::= '/='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_EQEQ :
                //<comparison> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_EXCLAMEQ :
                //<comparison> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_LT :
                //<comparison> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_GT :
                //<comparison> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_LTEQ :
                //<comparison> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_GTEQ :
                //<comparison> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_SHOW_COLON_LPARAN_RPARAN_NUM :
                //<print_statement> ::= show ':' '(' <expression> ')' '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE :
                //<conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE2 :
                //<conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <else_clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE3 :
                //<conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <elseif_clause_list> <else_clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONAL_STATEMENT_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE4 :
                //<conditional_statement> ::= if '(' <expression> ')' '\' '{' <statement_list> '}' <elseif_clause_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSEIF_CLAUSE_OTHERWISE_IF_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE :
                //<elseif_clause> ::= 'otherwise_if' '(' <expression> ')' '\' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_CLAUSE_OTHERWISE_BACKSLASH_LBRACE_RBRACE :
                //<else_clause> ::= otherwise '\' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_LOOP_STATEMENT_FOR_LPARAN_FROM_TO_RPARAN_BACKSLASH_LBRACE_RBRACE :
                //<for_loop_statement> ::= for <variable> '(' from <expression> to <expression> ')' '\' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_LOOP_STATEMENT_LOOP_LBRACE_RBRACE_UNTIL_COLON_LPARAN_RPARAN_NUM :
                //<while_loop_statement> ::= loop '{' <statement_list> '}' until ':' '(' <expression> ')' '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_LOOP_STATEMENT_DO_LBRACE_RBRACE_WHILE_COLON_LPARAN_RPARAN_NUM :
                //<do_while_loop_statement> ::= do '{' <statement_list> '}' while ':' '(' <expression> ')' '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STATEMENT_SWITCH_LPARAN_RPARAN_BACKSLASH_LBRACE_RBRACE :
                //<switch_statement> ::= switch '(' <expression> ')' '\' '{' <case_clause_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CLAUSE_CASE_COLON :
                //<case_clause> ::= case <expression> ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <phrase>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<expression> ::= <expression> <assignment_operator> <phrase>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PHRASE :
                //<phrase> ::= <container>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PHRASE2 :
                //<phrase> ::= <phrase> <comparison> <container>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTAINER :
                //<container> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTAINER_PLUS :
                //<container> ::= <container> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTAINER_MINUS :
                //<container> ::= <container> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <variable>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_DIGIT :
                //<factor> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_BOOL :
                //<factor> ::= Bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_STRINGLITERAL :
                //<factor> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPARAN_RPARAN :
                //<factor> ::= '(' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE :
                //<variable> ::= <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER_IDENTIFIER :
                //<identifier> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message1 = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + ", in line: " + args.UnexpectedToken.Location.LineNr;
            lst1.Items.Add(message1);
            string message2 = "Expected token: " + args.ExpectedTokens.ToString();
            lst1.Items.Add(message2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "     \t \t" + (SymbolConstants)args.Token.Symbol.Id;
            lst2.Items.Add(info);
        }
    }
}
