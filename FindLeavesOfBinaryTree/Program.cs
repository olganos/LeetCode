var tree = new TreeNode(1,
    new TreeNode(2,
        new TreeNode(4),
        new TreeNode(5)),
    new TreeNode(3)
 );

var tree2 = new TreeNode(1, null, new TreeNode(2));

var solution = new Solution();
//var result = solution.FindLeaves(tree);
var result2 = solution.FindLeaves(tree2);

public class Solution
{
    public IList<IList<int>> FindLeaves(TreeNode root)
    {
        IList<IList<int>> leaves = new List<IList<int>>();

        while (!(root.left == null && root.right == null))
        {
            var currentLeaves = new Queue<QueueItem>();
            Traverse(root, currentLeaves);
            var currentValues = new List<int>();
            while (currentLeaves.Any())
            {
                var queueItem = currentLeaves.Dequeue();
                if (queueItem.isLeft)
                {
                    currentValues.Add(queueItem.node.left.val);
                    queueItem.node.left = null;
                }
                if (!queueItem.isLeft)
                {
                    currentValues.Add(queueItem.node.right.val);
                    queueItem.node.right = null;
                }
            }
            leaves.Add(currentValues);
        }

        var rootValues = new List<int>();
        rootValues.Add(root.val);
        root = null;

        leaves.Add(rootValues);

        return leaves;
    }

    private void Traverse(TreeNode node, Queue<QueueItem> leaves)
    {
        if (node == null)
            return;

        Traverse(node.left, leaves);
        Traverse(node.right, leaves);
        if (node.left != null && node.left.left == null && node.left.right == null)
        {
            leaves.Enqueue(new QueueItem { node = node, isLeft = true });
        }
        if (node.right != null && node.right.left == null && node.right.right == null)
        {
            leaves.Enqueue(new QueueItem { node = node, isLeft = false });
        }
    }
}

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class QueueItem
{
    public TreeNode node { get; set; }
    public bool isLeft { get; set; }
}
