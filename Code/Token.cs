using System.Collections.Generic;

namespace Code
{
    public enum TokenType
    {
        Text,
        Keyword,
        Identifier,
        String,
        Literal,
        Operator,
        Embedded,
        Delimiter,
        WhiteSpace,
        LineComment,
        Comment
    }

    public enum TokenKind
    {
        Primitive,
        Class,
        Object,
        Array,
        Enum,
        InnerClass,
        InnerObject,
        All,
        Tuple,
        Stream,
        FlexArray
    }

    /*
     public enum TokenKind {
        Keyword,
        Identifier,
        Operator,
        Literal,
        Punctuator,
        Class,
        Array,
        Object,
        InnerClass,
        InnerObject,  =>    {}
        String,  =>  ' " `
        Function,
        Null,
        Undefined,
        Comment
     }
     */

    public class Token
    {
        public TokenKind kind { get; private set; }
        public int pos { get; private set; }
        public int col { get; private set; }
        public int line { get; private set; }
        public int start { get; private set; }
        public int end { get; private set; }
        public string value { get; private set; }
        public string filename { get; private set; }
        public Token(TokenKind tk, int p, int c, int l, int s, int e, string v)
        {
            kind = tk;
            pos = p;
            col = c;
            line = l;
            start = s;
            end = e;
            value = v;
        }
    }

    public class TokenList
    {
        private List<Token> tokens;
        private int length = 0;
        internal int Length;
        internal Token this[int index]
        {
            get { return tokens[index]; }
            set { tokens[index] = value; }
        }
        internal TokenList() => tokens = new List<Token>(4);
        internal TokenList(int n) => tokens = new List<Token>(n);
        internal void Add(Token t) => tokens.Add(t);
    }
}