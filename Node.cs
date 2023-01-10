using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node[] neighbors = new Node[8];
    public int value = 0;
    public int[] coord = new int[2];

    public Node(Node[] friends, int nodeType, int[] location){
        neighbors = friends;
        value = nodeType;
        coord = location;
    }
}
