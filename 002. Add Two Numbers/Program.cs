using System.Numerics;

namespace _2._Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make instance of program
            Program program = new Program();


            //ListNode1
            ListNode listNode1 = new ListNode(2);
            listNode1.next = new ListNode(4);
            listNode1.next.next = new ListNode(3);
            //ListNode2
            ListNode listNode2 = new ListNode(5);
            listNode2.next = new ListNode(6);
            listNode2.next.next = new ListNode(4);

            //Get result
            ListNode result = program.AddTwoNumbers(listNode1, listNode2);

            //Print results
            Console.WriteLine("Test 1:");

            while (result != null)
            {
                Console.Write(result.val);
                result = result.next;
            }
            Console.WriteLine("\n");


            //ListNode3
            ListNode listNode3 = new ListNode(0);

            //ListNode4
            ListNode listNode4 = new ListNode(0);

            //Get result
            result = program.AddTwoNumbers(listNode3, listNode4);

            //Print results
            Console.WriteLine("Test 2:");

            while (result != null)
            {
                Console.Write(result.val);
                result = result.next;
            }
            Console.WriteLine("\n");


            //ListNode5
            ListNode listNode5 = new ListNode(9);
            listNode5.next = new ListNode(9);
            listNode5.next.next = new ListNode(9);
            listNode5.next.next.next = new ListNode(9);
            listNode5.next.next.next.next = new ListNode(9);
            listNode5.next.next.next.next.next = new ListNode(9);
            listNode5.next.next.next.next.next.next = new ListNode(9);
            //ListNode6
            ListNode listNode6 = new ListNode(9);
            listNode6.next = new ListNode(9);
            listNode6.next.next = new ListNode(9);
            listNode6.next.next.next = new ListNode(9);

            //Get result
            result = program.AddTwoNumbers(listNode5, listNode6);

            //Print results
            Console.WriteLine("Test 3:");

            while (result != null)
            {
                Console.Write(result.val);
                result = result.next;
            }
            Console.WriteLine("\n");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            //Get numbers that are reversed
            BigInteger num1 = convertListNodeToBigInt(l1);
            BigInteger num2 = convertListNodeToBigInt(l2);

            //Add numbers
            BigInteger result = num1 + num2;

            //Return result
            return ConvertBigIntToListNode(result);
        }


        //Converts the list node to int and reverses it
        public BigInteger convertListNodeToBigInt(ListNode listNode)
        {
            //Variables
            string listNum = "";
            BigInteger num = 0;
            BigInteger multiplier = 1;

            //Put lists into strings
            while (listNode != null)
            {
                listNum += listNode.val.ToString();
                listNode = listNode.next;
            }

            //Reverse string
            char[] array = listNum.ToCharArray();
            Array.Reverse(array);
            listNum = new string(array);

            //Convert to BigInteger
            num = BigInteger.Parse(listNum);

            //Return result
            return num;
        }

        //Convert int to listNode
        public ListNode ConvertBigIntToListNode(BigInteger num)
        {
            //Incase input is 0
            if (num == 0)
            {
                return new ListNode(0);
            }

            //Variables
            ListNode head = new ListNode(0);
            ListNode current = head;

            //Iterate though the num and create a new node for each digit
            while (num > 0)
            {
                BigInteger digit = num % 10;
                num /= 10;
                current.next = new ListNode((int)digit);
                current = current.next;
            }
            return head.next;
        }
    }
}
