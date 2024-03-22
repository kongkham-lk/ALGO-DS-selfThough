using System.Xml.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Node root = new Node(1,
            new Node(2, new Node(4), new Node(5)),
            new Node(3, new Node(6), new Node(7)));

        IterateNodes(Connect(root));
    }

    public static Node Connect(Node root)
    {
        if (root == null) return root;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            int size = queue.Count;
            Node prevNode = null;

            while (size > 0)
            {
                Node currNode = queue.Dequeue();

                if (prevNode != null)
                    prevNode.next = currNode;

                prevNode = currNode;

                if (currNode.left != null)
                    queue.Enqueue(currNode.left);
                if (currNode.right != null)
                    queue.Enqueue(currNode.right);

                size--;
            }

            prevNode.next = null;
        }
        return root;
    }

    public static void IterateNodes(Node root)
    {
        Console.Write("[ ");

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            int size = queue.Count;

            while (size > 0)
            {
                Node currNode = queue.Dequeue();
                Console.Write(currNode.val + " ");

                if (currNode.next == null)
                    Console.Write("# ");

                if (currNode.left != null)
                    queue.Enqueue(currNode.left);
                if (currNode.right != null)
                    queue.Enqueue(currNode.right);

                size--;
            }
        }
        Console.WriteLine("]\n");
    }
}