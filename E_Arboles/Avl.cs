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
        public string Order = "";
        public void Add(Node root, T key, Y data)
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
                        Add(root.Right, key, data);

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
                        Add(root.Left, key, data);
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
                            if (temp.Left == null)
                            {
                                LeftRotation(root);
                            }
                            else
                            {
                                Node safe = new Node();
                                RightRotation(temp);
                                temp.Right.Right.Right = safe;
                                safe = temp.Right;
                                LeftRotation(root);
                                root.Left.Right = safe;
                            }
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
                            if(temp.Right == null)
                            {
                                RightRotation(root);
                            }
                            else 
                            {
                                Node safe = new Node();
                                safe = temp.Right;
                                LeftRotation(temp);
                                temp.Right.Left = safe;
                                safe = temp.Right;
                                RightRotation(root);
                                root.Right.Left = safe;
                            }
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
                            if (temp.Left == null)
                            {
                                LeftRotation(root);
                            }
                            else
                            {
                                Node safe = new Node();
                                RightRotation(temp);
                                safe = temp.Right;
                                LeftRotation(root);
                                root.Left.Right = safe;
                            }
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
                            if (temp.Right == null)
                            {
                                RightRotation(root);
                            }
                            else
                            {
                                Node safe = new Node();
                                safe = temp.Right;
                                LeftRotation(temp);
                                temp.Right.Left = safe;
                                safe = temp.Right;
                                RightRotation(root);
                                root.Right.Left = safe;
                            }
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
            LeftNode.Left = root.Left;
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
            RightNode.Right = root.Right;
            root.Data = root.Left.Data;
            root.Key = root.Left.Key;
            root.Right = RightNode;
            root.Left = root.Left.Left;
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
    }
}

