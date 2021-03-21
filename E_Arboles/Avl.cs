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
            public Node Right;
            public Node Left;
            public T Key;
            public Y Data;
        }
        public Node Root;
        string order;
        public void Add(Node root, Y data, T key)
        {
            Node Adding = new Node();
            Adding.Data = data;
            Adding.Key = key;
            if (Root == null)
            {
                Root = Adding;
            }
            else
            {
                if (Adding.Key.CompareTo(root.Key) > 0)
                {
                    if (root.Right == null)
                    {
                        root.Right = Adding;
                        Balance(Root);
                    }
                    else
                    {
                        Add(root.Right, data, key);

                    }
                }
                else if (Adding.Key.CompareTo(root.Key) < 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = Adding;
                        Balance(Root);
                    }
                    else
                    {
                        Add(root.Left, data, key);
                    }
                }
            }
        }
        void Balance(Node root)
        {
            if (root != null)
            {
                int disbalance = Height(root.Right) - Height(root.Left);
                if (disbalance > 1)
                {
                    Node temp = root.Right;
                    if (Height(temp.Right) - Height(temp.Left) >= -1 && Height(temp.Right) - Height(temp.Left) <= 1)
                    {
                        if (temp.Right != null)
                        {
                            LeftRotation(root);
                        }
                        else
                        {
                            RightRotation(temp);
                            LeftRotation(root);
                        }
                    }
                    else
                    {
                        Balance(temp, root, "");
                    }
                }
                else if (disbalance < -1)
                {
                    Node temp = root.Left;
                    if (Height(temp.Right) - Height(temp.Left) >= -1 && Height(temp.Right) - Height(temp.Left) <= 1)
                    {
                        if (temp.Left != null)
                        {
                            RightRotation(root);
                        }
                        else
                        {
                            LeftRotation(temp);
                            RightRotation(root);
                        }
                    }
                    else
                    {
                        Balance(temp, root, "L");
                    }

                }
                Balance(root.Left);
                Balance(root.Right);
            }
        }
        void Balance(Node root, Node prev, string direc)
        {
            if (root != null)
            {


                int disbalance = Height(root.Right) - Height(root.Left);
                if (disbalance > 1)
                {
                    Node temp = root.Right;
                    if (Height(temp.Right) - Height(temp.Left) >= -1 && Height(temp.Right) - Height(temp.Left) <= 1)
                    {
                        if (temp.Right != null)
                        {
                            LeftRotation(root);
                        }
                        else
                        {
                            RightRotation(temp);
                            LeftRotation(root);
                        }
                        if (direc == "L")
                        {
                            prev.Left = root;
                        }
                        else
                        {
                            prev.Right = root;
                        }
                    }
                    else
                    {
                        Balance(temp, root, "");
                    }
                }
                else if (disbalance < -1)
                {
                    Node temp = root.Left;
                    if (Height(temp.Right) - Height(temp.Left) >= -1 && Height(temp.Right) - Height(temp.Left) <= 1)
                    {
                        if (temp.Left != null)
                        {
                            RightRotation(root);
                        }
                        else
                        {
                            LeftRotation(temp);
                            RightRotation(root);
                        }
                        if (direc == "L")
                        {
                            prev.Left = root;
                        }
                        else
                        {
                            prev.Right = root;
                        }
                    }
                    else
                    {
                        Balance(temp, root, "L");
                    }
                }
                Balance(root.Left);
                Balance(root.Right);
            }
        }
        int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int Lheight = Height(root.Left);
                int Rheight = Height(root.Right);
                if(Lheight > Rheight)
                {
                    return (Lheight + 1);
                }
                else
                {
                    return (Rheight + 1);
                }
            }
        }
        void LeftRotation(Node root)
        {
            Node LeftNode = new Node();
            LeftNode.Data = root.Data;
            LeftNode.Key = root.Key;
            root.Data = root.Right.Data;
            root.Key = root.Right.Key;
            root.Left = LeftNode;
            root.Right = root.Right.Right;
        }
        void RightRotation(Node root)
        {
            Node RightNode = new Node();
            RightNode.Data = root.Data;
            RightNode.Key = root.Key;
            root.Data = root.Left.Data;
            root.Key = root.Left.Key;
            root.Right = RightNode;
            root.Left = root.Left.Left;
        }
    }
}

