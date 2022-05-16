using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LinkedList<T>
{

    private ListNode<T> head;
    private int count;

    public ListNode<T> Head { get { return head; } }
    public int Count { get { return count; } }

    public void Add(T item)
    {
        if (head == null)
        {
            head = new ListNode<T>(item, null);
        }
        else
        {
            head = new ListNode<T>(item, head);
        }
        count++;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        ListNode<T> CurrentNode = head;
        int nodeCount = 0;
        while (CurrentNode != null)
        {
            sb.Append(CurrentNode.Value.ToString());
            nodeCount++;
            if (nodeCount < count)
            {
                sb.Append(',');
            }
            CurrentNode = CurrentNode.NextNode;
        }
        return sb.ToString();
    }

}
