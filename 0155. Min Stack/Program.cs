/**
 * NOTE: I did not create any tests for this LeetCode Question
 */


/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
public class MinStack
{
    //Variable
    public Stack<int> stack;
    private Stack<int> minStack;

    //Initialize the constructor
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    //Put val on the top of the stack
    public void Push(int val)
    {
        stack.Push(val);

        //Pust onto minStack if is smaller than current minimum
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }

    //Remove the top element of the stack
    public void Pop()
    {
        if(stack.Count > 0)
        {
            int popped = stack.Pop();

            if (popped == minStack.Peek() )
            {
                minStack.Pop();
            }
        }
    }

    //Gets the top element of the stack
    public int Top()
    {
        return stack.Peek();
    }

    //Returns the smallest element in the stack
    public int GetMin()
    {
        return minStack.Peek();
    }
}