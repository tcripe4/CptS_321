namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class that encapsulates everything.
    /// </summary>
    public class ExpressionTree
    {
        public BaseNode root;
        public Dictionary<string, double> vars = new Dictionary<string, double>();
        public string Expression;

        /// <summary>
        /// The contructor for the expression tree
        /// </summary>
        /// <param name="expression">the string to be set</param>
        public ExpressionTree(string expression)
        {
            this.Expression = expression;
        }

        /// <summary>
        /// Gets or sets the root
        /// </summary>
        public BaseNode GetSetroot
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>
        /// Starts the evaluation
        /// </summary>
        /// <returns>the evluation function</returns>
        public double Evaluate()
        {
            if (root != null)
            {
                return this.root.Evaluate();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks which oeprator it is
        /// </summary>
        /// <param name="exp">the operator</param>
        /// <returns>whether it is an operator</returns>
        public bool CheckExpressions(char exp)
        {
            if (exp == '+' || exp == '*' || exp == '/' || exp == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 
        public void constructTree(string expression)
        {
            Stack<BaseNode> newStack = new Stack<BaseNode>();
            OperatorNode t;
            List<char> newlist = new List<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                newlist.Add(expression[i]);
            }
            for (int i = 0; i < newlist.Count; i++)
            {
                int num = expression.Length;
                NumericalNode numNode = new NumericalNode();
                // If operand, simply Push into stack 
                if (!CheckExpressions(newlist[i]) && newlist[i] != ' ')
                {
                    {
                        List<char> check = new List<char>();
                        int index = 0;
                        bool var = false;
                        while (!CheckExpressions(newlist[i]))
                        {
                            if (newlist[i] != ' ')
                            {
                                check.Add(newlist[i]);
                                if (Char.IsLetter(newlist[i]))
                                {
                                    var = true;
                                }
                                if (i + 1 == newlist.Count)
                                {
                                    break;
                                }
                                i++;
                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        string name = string.Join("", check.ToArray());
                        if (var == true)
                        {
                            VariableNode varNode = new VariableNode(name, this);
                            newStack.Push(varNode);
                        }
                        else
                        {
                            numNode.GetSetnum = Convert.ToInt16(name);
                            newStack.Push(numNode);
                        }
                    }
                }
                else if (expression[i] != ' ')// operator 
                {
                    t = new OperatorNode(newlist[i]);

                    // Pop two top nodes 
                    // Store top 
                    BaseNode t1 = newStack.Pop();     // Remove top 
                    BaseNode t2 = newStack.Pop();
                    

                    // make them children 
                    t.GetSetRight = t1;
                    t.GetSetLeft = t2;
                   
                    newStack.Push(t);
                    i++;
                }
            }

            this.root = newStack.Pop();

        }

        public void InfixToPostfix()
        {
            // initializing empty String for result
            String result = "";

            // initializing empty stack
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < Expression.Length; ++i)
            {
                char exp = Expression[i];

                // If the scanned character is an operand, add it to output.
                if (Char.IsLetterOrDigit(exp))
                    result += exp;

                else // an operator is encountered
                {
                    result += ' ';
                    while (stack.Count != 0 && Precedence(exp) <= Precedence(stack.Peek()))
                    {
                        result += stack.Pop();
                        result += ' ';
                    }
                    stack.Push(exp);
                }

            }

            // pop all the operators from the stack
            while (stack.Count != 0)
            {
                result += ' ';
                result += stack.Pop();
            }
            constructTree(result);
        }

        public int Precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        /// <summary>
        /// This is the base class for the nodes
        /// </summary>
        public abstract class BaseNode
        {
            /// <summary>
            /// The abstract method for evaluate
            /// </summary>
            /// <returns> a double </returns>
            public abstract double Evaluate();
        }

        /// <summary>
        /// The numerical node
        /// </summary>
        public class NumericalNode : BaseNode
        {
            private int number;

            /// <summary>
            /// Gets or sets the value
            /// </summary>
            public int GetSetnum
            {
                get { return this.number; }
                set { this.number = value; }
            }

            /// <summary>
            /// This returns the number for evaluation
            /// </summary>
            /// <returns>a number</returns>
            public override double Evaluate()
            {
                return this.number;
            }
        }

        /// <summary>
        /// The variable node
        /// </summary>
        public class VariableNode : BaseNode
        {
            private string name;
            private ExpressionTree test;

            /// <summary>
            /// Initializes a new instance of the <see cref="VariableNode"/> class.
            /// this is the constructor for the variable node
            /// </summary>
            /// <param name="name">The string</param>
            /// <param name="part">for the dictionary</param>
            public VariableNode(string name, ExpressionTree part)
            {
                this.name = name;
                this.test = part;
            }

            /// <summary>
            /// Returns the dictionary value
            /// </summary>
            /// <returns>a double </returns>
            public override double Evaluate()
            {
                return this.test.vars[this.name];
            }
        }

        /// <summary>
        /// The operator node that inherits from basenode
        /// </summary>
        public class OperatorNode : BaseNode
        {
            public BaseNode Right;
            public BaseNode Left;
            public char Operator;

            /// <summary>
            /// The constructor
            /// </summary>
            /// <param name="op">the operator</param>
            public OperatorNode(char op)
            {
                this.Operator = op;
                this.Left = null;
                this.Right = null;
            }

            /// <summary>
            /// The evaluation for operatornode
            /// </summary>
            /// <returns>a double</returns>
            public override double Evaluate()
            {
                double left = Left.Evaluate();
                double right = Right.Evaluate();

                switch (Operator)
                {
                    case '+':
                        return left + right;
                    case '-':
                        return left - right;
                    case '/':
                        return left / right;
                    case '*':
                        return left * right;
                    default: return -1;
                }

            }

            /// <summary>
            /// Sets the operator
            /// </summary>
            public char GetSetOperator
            {
                get { return this.Operator; }
                set { this.Operator = value; }
            }

            /// <summary>
            /// Gets or sets the left node
            /// </summary>
            public BaseNode GetSetLeft
            {
                get { return this.Left; }
                set { this.Left = value; }
            }

            /// <summary>
            /// Gets or sets the right node
            /// </summary>
            public BaseNode GetSetRight
            {
                get { return this.Right; }
                set { this.Right = value; }
            }

        }
    }
}
