namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses)
                || parentheses.Length % 2 == 1)
            {
                return false;
            }

            Stack<char> openBrackets = new Stack<char>(parentheses.Length / 2);

            foreach (var bracket in parentheses)
            {
                char expectedBracket = default;

                switch (bracket)
                {
                    case ']':
                        expectedBracket = '[';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    case ')':
                        expectedBracket = '(';
                        break;
                    default:
                        openBrackets.Push(bracket);
                        break;
                }

                if (expectedBracket != default
                    && openBrackets.Pop() != expectedBracket)
                {
                    return false;
                }

            }

            return openBrackets.Count == 0;
        }
    }
}
