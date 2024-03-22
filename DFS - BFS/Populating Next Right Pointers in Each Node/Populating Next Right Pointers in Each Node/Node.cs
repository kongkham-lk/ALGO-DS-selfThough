public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left = null, Node _right = null, Node _next = null)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}