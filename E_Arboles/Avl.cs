using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace E_Arboles
{
    public class AVL<T, Y> where T : IComparable
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public T Key;
            public Y Data;
            public Node(T Key, Y Data)
            {
                this.Key = Key;
                this.Data = Data;
            }
        }
        public Node Root;
        public string Order = "";

        public void Add(T key, Y data)
        {
            Node item = new Node(key, data);
            if (Root == null)
            {
                Root = item;
            }
            else
            {
                Root = Add(Root, item);
            }
        }

        private Node Add(Node actual, Node item)
        {
            if (actual == null)
            {
                actual = item;
                return actual;
            }
            else if (item.Key.CompareTo(actual.Key) > 0)
            {
                actual.Right = Add(actual.Right, item);
                actual = Balance(actual);
            }
            else if (item.Key.CompareTo(actual.Key) < 0)
            {
                actual.Left = Add(actual.Left, item);
                actual = Balance(actual);
            }
            return actual;
        }

        private Node Balance(Node actual)
        {
            if (dBalance(actual) > 1)
            {
                if (dBalance(actual.Right) > 0)
                {
                    actual = RotRR(actual);
                }
                else
                {
                    actual = RotRL(actual);
                }
            }
            else if (dBalance(actual) < -1)
            {
                if (dBalance(actual.Left) > 0)
                {
                    actual = RotLR(actual);
                }
                else
                {
                    actual = RotLL(actual);
                }
            }
            return actual;
        }

        private int dBalance(Node actual)
        {
            int Lbalance = Height(actual.Left);
            int Rbalance = Height(actual.Right);
            return Rbalance - Lbalance;
        }

        private int Height(Node actual)
        {
            if (actual == null)
            {
                return 0;
            }
            else
            {
                int Lheight = Height(actual.Left);
                int Rheight = Height(actual.Right);
                return Lheight > Rheight ? Lheight + 1 : Rheight + 1;
            }
        }

        private Node RotRR(Node root)
        {
            Node temp = root.Right;
            root.Right = temp.Left;
            temp.Left = root;
            return temp;
        }

        private Node RotLL(Node root)
        {
            Node temp = root.Left;
            root.Left = temp.Right;
            temp.Right = root;
            return temp;
        }

        private Node RotLR(Node root)
        {
            Node temp = root.Left;
            root.Left = RotRR(temp);
            return RotLL(root);
        }

        private Node RotRL(Node root)
        {
            Node temp = root.Right;
            root.Right = RotLL(temp);
            return RotRR(root);
        }

        public string PreOrder(Node head)
        {
            if (head == null)
            {
                return "";
            }
            Order += head.Key.ToString() + " =>";
            PreOrder(head.Left);
            PreOrder(head.Right);
            return Order;
        }
        public string InOrder(Node head)
        {
            if (head == null)
            {
                return "";
            }
            InOrder(head.Left);
            Order += head.Key.ToString() + " =>";
            InOrder(head.Right);
            return Order;
        }
        public string PostOrder(Node head)
        {
            if (head == null)
            {
                return "";
            }
            PostOrder(head.Left);
            PostOrder(head.Right);
            Order += head.Key.ToString() + " =>";
            return Order;
        }
        public Y Find(T data)
        {
            if (Root == null)
            {
                return default(Y);
            }
            else if (Root.Key.CompareTo(data) == 0)
            {
                return Root.Data;
            }
            else if (Root.Key.CompareTo(data) < 0)
            {
                Node temp = Root.Right;
                while (temp != null)
                {
                    if (temp.Key.Equals(data))
                    {
                        return temp.Data;
                    }
                    else
                    {
                        if (temp.Left != null)
                        {
                            if (temp.Left.Key.Equals(data))
                            {
                                return temp.Left.Data;
                            }
                        }
                        temp = temp.Right;
                    }
                }
            }
            else
            {
                Node temp = Root.Left;
                while (temp != null)
                {
                    if (temp.Key.Equals(data))
                    {
                        return temp.Data;
                    }
                    else
                    {
                        if (temp.Right != null)
                        {
                            if (temp.Right.Key.Equals(data))
                            {
                                return temp.Right.Data;
                            }
                        }
                        temp = temp.Left;
                    }
                }
            }
            return default(Y);
        }
    }
}

