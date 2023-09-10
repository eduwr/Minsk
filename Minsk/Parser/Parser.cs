using Minsk.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minsk.Parser
{
    internal class Parser
    {
        public Parser(string text)
        {


            var tokens = new List<SyntaxToken>();

            var lexer = new Lexer.Lexer(text);
            SyntaxToken token;
            do
            {
                token = lexer.NextToken();

                if (token.Kind != SyntaxKind.WhiteSpaceToken && token.Kind != SyntaxKind.BadToken)
                {
                    tokens.Add(token);
                }


            } while (token.Kind != SyntaxKind.EnfOfFileToken);
        }
    }
}
