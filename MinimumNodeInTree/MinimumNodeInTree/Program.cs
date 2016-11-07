using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumNodeInTree
{
    /* Java implementation to find minimum depth
   of a given Binary tree */

    /* Class containing left and right child of current
    node and key value*/
    class Node
    {
        int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
    public class BinaryTree
    {
        //Root of the Binary Tree
        Node root;

        int minimumDepth()
        {
            return minimumDepth(root);
        }

        /* Function to calculate the minimum depth of the tree */
        int minimumDepth(Node root)
        {
            if (root == null)
                return 0;

            int rightDepth = 1, leftDepth = 1;

            leftDepth += minimumDepth(root.left);
            rightDepth += minimumDepth(root.right);

            return leftDepth < rightDepth ? leftDepth : rightDepth;
        }

        /* Driver program to test above functions */
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("The minimum depth of " +
              "binary tree is : " + tree.minimumDepth());
        }
    }
}
