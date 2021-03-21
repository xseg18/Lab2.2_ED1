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
                        Balance();
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
                        Balance();
                    }
                    else
                    {
                        Add(root.Left, data, key);
                    }
                }
            }
        }
        void Balance()
        {
            //disbalanced root
            if (Height(Root) >= 1)
            {
                //left subtree disbalanced
                if (Root.Left.Left == null)
                {
                    //LR Rotation
                    Node templeft = null;
                    if (Root.Left.Right.Left != null)
                    {
                        templeft = Root.Left.Right.Left;
                        Root.Left.Right.Left = null;
                    }
                    LeftRotation(Root.Left);
                    Root.Left.Left.Right = templeft;
                    if (Root.Left.Right != null)
                    {
                        templeft = Root.Left.Right;
                        Root.Left.Right = null;
                    }
                    RightRotation(Root);
                    Root.Right.Left = templeft;
                }
                else
                {
                    //LL rotation
                    Node templeft = null;
                    if (Root.Left.Right != null)
                    {
                        templeft = Root.Left.Right;
                        Root.Left.Right = null;
                    }
                    RightRotation(Root);
                    Root.Right.Right.Left = templeft;
                }
            }
            else if (Height(Root) <= -1)
            {
                // right subtree disbalanced
                if (Root.Right.Right == null)
                {
                    // RL rotation
                    Node tempright = null;
                    if (Root.Right.Left.Right != null)
                    {
                        tempright = Root.Right.Left.Right;
                        Root.Right.Left.Right = null;
                    }
                    LeftRotation(Root.Right);
                    Root.Right.Right.Left = tempright;
                    if (Root.Right.Left != null)
                    {
                        tempright = Root.Right.Left;
                        Root.Right.Left = null;
                    }
                    RightRotation(Root);
                    Root.Left.Right = tempright;
                }
            }
            //left path

            //right path
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
                int Fheight = Lheight - Rheight;
                return Fheight;
            }
        }
        void LeftRotation(Node root)
        {
            Node LeftNode = null;
            LeftNode.Data = root.Data;
            LeftNode.Key = root.Key;
            LeftNode.Left = root.Left;
            root = root.Right;
            root.Left = LeftNode;
            root.Right = null;
        }
        void RightRotation(Node root)
        {
            Node RightNode = null;
            RightNode.Data = root.Data;
            RightNode.Key = root.Key;
            RightNode.Right = root.Right;
            root = root.Left;
            root.Right = RightNode;
            root.Left = null;
        }
    }
}

