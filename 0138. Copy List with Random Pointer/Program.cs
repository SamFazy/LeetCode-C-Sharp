using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test Cases

        //Test 1
        Node node0Test1 = new Node(7);
        Node node1Test1 = new Node(13);
        Node node2Test1 = new Node(11);
        Node node3Test1 = new Node(10);
        Node node4Test1 = new Node(1);

        //Link the next pointers
        node0Test1.next = node1Test1;
        node1Test1.next = node2Test1;
        node2Test1.next = node3Test1;
        node3Test1.next = node4Test1;
        node4Test1.next = null;

        //Link random pointer
        node0Test1.random = null;
        node1Test1.random = node0Test1;
        node2Test1.random = node4Test1;
        node3Test1.random = node2Test1;
        node4Test1.random = node0Test1;


        //Test 2
        Node node0Test2 = new Node(1);
        Node node1Test2 = new Node(2);

        //Link the next pointers
        node0Test2.next = node1Test2;
        node1Test2.next = null;

        //Link the random pointer
        node0Test2.random = node1Test2;
        node1Test2.random = node1Test2;


        //Test 3
        Node node0Test3 = new Node(3);
        Node node1Test3 = new Node(3);
        Node node2Test3 = new Node(3);

        //Link the next pointers
        node0Test3.next = node1Test3;
        node1Test3.next = node2Test3;
        node2Test3.next = null;

        //Link the random pointer
        node0Test3.random = null;
        node1Test3.random = node0Test3;
        node2Test3.random = null;


        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printNodes(node0Test1);
        Console.Write("Output: ");
        program.printNodes(program.CopyRandomList(node0Test1));
        Console.WriteLine("Expected: 7 null, 13 0, 11 4, 10 2, 1 0");

    }

    public void printNodes(Node head)
    {
        //Build dictionary to map each node to its index
        Dictionary<Node, int> nodeToIndex = new Dictionary<Node, int>();
        Node current = head;
        int index = 0;
        while (current != null)
        {
            nodeToIndex[current] = index;
            current = current.next;
            index++;
        }

        //Print values and random pointer indices
        current = head;
        while (current != null)
        {
            string randomIndex = current.random != null ? nodeToIndex[current.random].ToString() : "null";
            Console.Write($"{current.val} {randomIndex}");

            if (current.next != null)
            {
                Console.Write(", ");
            }

            current = current.next;
        }

        Console.WriteLine();
    }

    //Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public Node CopyRandomList(Node head)
    {
        //Make sure head isnt null
        if(head == null)
        {
            return null;
        }

        //Create dictionary to hold nodes
        Dictionary <Node,Node> nodes = new Dictionary<Node,Node>();

        //Create dummy head
        Node dummyHead = head;

        //Put both original and new copied nodes into the dictionary
        while (dummyHead != null)
        {
            //Make the copy
            Node copyNode = new Node(dummyHead.val);

            //Put copy and original into dictionary
            nodes.Add(dummyHead, copyNode);

            //Move dummyHead forward
            dummyHead = dummyHead.next;
        }

        //Reset dummy head
        dummyHead = head;

        while (dummyHead != null)
        {
            Node copyNode = nodes[dummyHead];

            copyNode.next = dummyHead.next != null ? nodes[dummyHead.next] : null;

            copyNode.random = dummyHead.random != null ? nodes[dummyHead.random] : null;

            dummyHead = dummyHead.next;
        }

        return nodes[head];
    }
}