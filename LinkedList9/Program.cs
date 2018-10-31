using System;
//Given a singly linked list which has data sorted in ascending order, construct a balanced BST.

namespace LinkedList9
{
    public class Node
    {
        public Node next;
        public int data;

        public Node()
        {
            next = null;
        }

        public Node(int val)
        {
            data = val;
            next = null;
        }
    }

    public class MyLL
    {
        public Node head;

        public MyLL()
        {
            head = null;
        }

        public Node AddTail(int val)
        {
            Node node = new Node(val);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = node;
            }
            return node;
        }

        public void PrintNodes()
        {
            Node curr = head;
            while (curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            }
        }

    }

    
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode()
        {
            data = 0;
            left = null;
            right = null;
        }
        public TreeNode(int val)
        {
            data = val;
            left = null;
            right = null;
        }
    }

    public class Tree
    {
        public TreeNode root;

        public Tree()
        {
            root = null;
        }
        
        public TreeNode LLToBST(Node left, Node right)
        {
            /* 1) Get the Middle of the linked list and make it root.
             * 2) Recursively do same for left half and right half.
            a) Get the middle of left half and make it left child of the root created in step 1.
            b) Get the middle of right half and make it right child of the root created in step 1. */
            if (right == null || left == null || left.data > right.data)
                return null;

            Node slow = left, fast = left, prev = null;
            while (fast!= null && fast.next != null)
            {
                if (right != null && (fast == right || fast == right.next))
                {
                    break;
                }
                prev = slow;
                fast = fast.next.next;
                slow = slow.next;
            }
            TreeNode root = new TreeNode(slow.data);
            root.left = LLToBST(left, prev);
            root.right = LLToBST(slow.next, right);
            return root;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyLL list = new MyLL();
            Node left, right;
            left = list.AddTail(1);
            list.AddTail(4);
            list.AddTail(8);
            list.AddTail(11);
            list.AddTail(14);
            list.AddTail(18);
            list.AddTail(19);
            list.AddTail(21);
            right = list.AddTail(51);

            list.PrintNodes();

            Tree bst = new Tree();

            TreeNode root = bst.LLToBST(left, right);


        }
    }
}
