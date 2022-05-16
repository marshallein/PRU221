using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNode<T>
{
    public T Value { get; set; }
    public ListNode<T> NextNode { get; set; }

    public ListNode(T value, ListNode<T> nextNode)
    {
        Value = value;
        NextNode = nextNode;
    }
}
