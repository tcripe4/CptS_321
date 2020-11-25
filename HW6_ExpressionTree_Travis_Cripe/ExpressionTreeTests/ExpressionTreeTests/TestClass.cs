using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;
namespace ExpressionTreeTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            int num = 0;
            string expression = "Hello+12+World";
            ExpressionTree tree = new ExpressionTree(expression);
            tree.vars.Add("Hello", 12);
            tree.vars.Add("World", 12);
            Assert.IsTrue(tree.CreateTree());
            Assert.AreEqual(tree.Evaluate(), 36);
        }
    }
}

namespace CptS321
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

        /// <summary>
        /// Creates the tree
        /// </summary>
        public bool CreateTree()
        {
            Stack<BaseNode> TreeStack = new Stack<BaseNode>();
            Stack<OperatorNode> TreeStack1 = new Stack<OperatorNode>();
            for (int i = 0; i < Expression.Length; i++)
            {
                NumericalNode numNode = new NumericalNode();
                if (CheckExpressions(Expression[i])) // if the character is an operator
                {
                    OperatorNode expression = new OperatorNode(Expression[i]);
                    if (TreeStack1.Count == 0)
                    {
                        TreeStack1.Push(expression);
                    }
                    else
                    {
                        BaseNode temp1 = TreeStack.Pop();
                        BaseNode temp2 = TreeStack.Pop();
                        expression.Right = temp1;
                        expression.Left = temp2;
                        TreeStack.Push(expression);
                    }
                }
                else if (!CheckExpressions(Expression[i])) // if not an operator
                {
                    List<char> check = new List<char>();
                    int index = 0;
                    bool var = false;
                    while (!CheckExpressions(Expression[i]))
                    {
                        check.Add(Expression[i]);
                        if (Char.IsLetter(Expression[i]))
                        {
                            var = true;
                        }
                        if (i + 1 == Expression.Length)
                        {
                            break;
                        }
                        i++;
                        index++;
                    }
                    string name = string.Join("", check.ToArray());
                    if (var == true)
                    {
                        VariableNode varNode = new VariableNode(name, this);
                        //varNode.name = name;
                        TreeStack.Push(varNode);
                    }
                    else
                    {
                        numNode.GetSetnum = Convert.ToInt16(name);
                        TreeStack.Push(numNode);
                    }
                    if (i + 1 != Expression.Length)
                    {
                        i--;
                    }
                }
            }

            //finish any remaining operators and push the final expression on the stack
            while (TreeStack1.Count != 0)
            {
                OperatorNode expression1 = new OperatorNode(TreeStack1.Pop().GetSetOperator);
                expression1.Right = TreeStack.Pop();
                expression1.Left = TreeStack.Pop();
                TreeStack.Push(expression1);
            }

            this.root = TreeStack.Pop();
            return true;
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
                set { this.Left = (OperatorNode)value; }
            }

            /// <summary>
            /// Gets or sets the right node
            /// </summary>
            public BaseNode GetSetRight
            {
                get { return this.Right; }
                set { this.Right = (OperatorNode)value; }
            }

        }
    }
}

