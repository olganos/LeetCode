// https://leetcode.com/problems/count-good-nodes-in-binary-tree/

using Helpers;

public class Solution
{

    private int count = 0;

    public int GoodNodes(TreeNode root)
    {
        if (root == null)
            return 0;

        countGoods(int.MinValue, root);
        return count;
    }

    private void countGoods(int max, TreeNode node)
    {
        if (node == null)
            return;

        if (max <= node.val)
        {
            count++;
            max = node.val;
        }

        countGoods(max, node.left);
        countGoods(max, node.right);
    }
}
