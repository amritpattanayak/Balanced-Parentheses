/***************************************************************/
// C# program to check balanced parentheses for an input string./ 
// It includes the (), {}, [].                                  /
// Stack is sused to solve the problem.                         /
/***************************************************************/
using System;
using System.Collections;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to check Balanced Parentheses (), {}, [].");
            string expression = Console.ReadLine(); //Read the Input string
            if (IsBalanced(expression))
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("Not balanced");
            Console.ReadLine();
        }

        /// <summary>
        /// Check the parenthesis pair
        /// </summary>
        /// <param name="c1">Expected '{', '(', '['</param>
        /// <param name="c2">Expected '}', ')', ']'</param>
        /// <returns>If a parentheses par, return true; else flase;</returns>
        static bool IsParenthesesMatch(char c1, char c2)
        {
            switch (c1) {
                case '{': return c2 == '}';
                case '[': return c2 == ']';
                case '(': return c2 == ')';
            }
            return false;
        }

        /// <summary>
        /// Check for balanced parentheses {}, [], ()
        /// </summary>
        /// <param name="expression">Expression string</param>
        /// <returns>If balance, return true; else false;</returns>
        static bool IsBalanced(string expression)
        {
            Stack parenthesesStack = new Stack();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{')
                {
                    parenthesesStack.Push(expression[i]); //Push to the Stack if any opening parentaheses found in the expression
                }
                else
                {
                    //Check for closing parentheses
                    if (expression[i] == ')' || expression[i] == ']' || expression[i] == '}')
                    {
                        if (parenthesesStack.Count == 0) // Stack count is 0, means there is no opening parentheses for the current closing parentheses
                        {
                            return false;
                        }
                        if (IsParenthesesMatch((char)parenthesesStack.Peek(), expression[i]))
                        {
                            parenthesesStack.Pop(); // The top of the stack and the current closing parentheses make a pair. So remove the top from the stack
                        }
                        else
                        {
                            return false; // The top of the stack and the current closing parentheses are not a pair
                        }
                    }
                }
            }
            // Stack count 0, means the string is having balnced parentheses.
            // Stack count > 0, means atlease one opening parenthese has not balanced
            return parenthesesStack.Count == 0 ? true : false; 
        }
    }
}
