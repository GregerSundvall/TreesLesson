
using System;
using System.Collections.Generic;

namespace TreesLesson.Properties
{
    public class Tree<T>
    {
        private T _value;
        private Tree<T> _parent;
        private Tree<T> _left;
        private Tree<T> _right;

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Tree<T> Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        public Tree<T> Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public Tree<T> Right
        {
            get { return _right; }
            set { _right = value; }
        }
        
        
        //Methods
        public void Insert(T value)
        {
            Tree<T> item = new Tree<T>(value);
            Queue<Tree<T>> levels = new Queue<Tree<T>>();
            levels.Enqueue(this);
            Tree<T> currentNode;

            while (levels.Count > 0)
            {
                currentNode = levels.Dequeue();
                if (currentNode.Left == null)
                {
                    item.Parent = currentNode;
                    currentNode.Left = item;
                    return;
                }

                if (currentNode.Right == null)
                {
                    item.Parent = currentNode;
                    currentNode.Right = item;
                    return;
                }
                levels.Enqueue(currentNode.Left);
                levels.Enqueue(currentNode.Right);
            }
        }

        public Tree<T> PreOrderSearch(T target)
        {
            return preOrder(this, target);
        }

        private Tree<T> preOrder(Tree<T> node, T target)
        {
            if (node == null)
            {
                return null;
            }

            if (object.Equals(target, node.Value))
            {
                return node;
            }

            Tree<T> left = preOrder(node.Left, target);
            if (left != null)
            {
                return left;
            }
            Tree<T> right = preOrder(node.Right, target);
            if (right != null)
            {
                return right;
            }

            return null;
        }
        
        public Tree<T> InOrderSearch(T target)
        {
            return inOrder(this, target);
        }

        private Tree<T> inOrder(Tree<T> node, T target)
        {
            if (node == null)
            {
                return null;
            }

            Tree<T> left = inOrder(node.Left, target);
            if (left != null)
            {
                return left;
            }
            if (object.Equals(target, node.Value))
            {
                return node;
            }

            Tree<T> right = inOrder(node.Right, target);
            if (right != null)
            {
                return right;
            }

            return null;
        }
        
        public Tree<T> PostOrderSearch(T target)
        {
            return postOrder(this, target);
        }

        private Tree<T> postOrder(Tree<T> node, T target)
        {
            if (node == null)
            {
                return null;
            }

            Tree<T> left = postOrder(node.Left, target);
            if (left != null)
            {
                return left;
            }
            Tree<T> right = postOrder(node.Right, target);
            if (right != null)
            {
                return right;
            }
            if (object.Equals(target, node.Value))
            {
                return node;
            }

            return null;
        }
        
        public void PrintLevels()
        {
            Queue<Tree<T>> levels = new Queue<Tree<T>>();
            levels.Enqueue(this);
            Tree<T> currentNode;
            int level = 0;

            while (levels.Count > 0)
            {
                currentNode = levels.Dequeue();
                if (currentNode.Depth() != level)
                {
                    Console.WriteLine();
                    level++;
                }
                Console.Write(currentNode.Value + " ");
                if (currentNode.Left != null)
                {
                    levels.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    levels.Enqueue(currentNode.Right);
                }
            }
        }
        
        public int Depth()
        {
            int depth = 0;
            Tree<T> currentParent = _parent;
            while (currentParent != null)
            {
                currentParent = currentParent.Parent;
                depth++;
            }
            return depth;
        }

        public int Height()
        {
            int height = 0;
            Tree<T> left = _left;
            while (left != null)
            {
                left = left.Left;
                height++;
            }
            return height;
        }
        
        public bool IsFull()
        {
            int height = Height();
            int rightDepth = 0;
            
            Tree<T> right = this.Right;
            while (right != null)
            {
                right = right.Right;
                rightDepth++;
            }
            return height == rightDepth;
        }
        
        // Constructors
        
        public Tree(T value = default(T))
        {
            _value = value;
            _parent = _left = _right = null;
        }
        public Tree(T value, Tree<T> parent)
        {
            _value = value;
            _parent = parent;
            _left = _right = null;
        }
    }
}