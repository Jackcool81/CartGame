using System.Collections;
using System.Collections.Generic;

public class Node
{

    public List<Node> neighbors = new List<Node>();
    public int value = 0;
    public int[] coord = new int[2];

    public int distance = 0;

    public Node pred = null;

    public bool visited = false;

    public Node(List<Node> friends, int nodeType, int[] location){
        neighbors = friends;
        value = nodeType;
        coord = location;
        
    }

    public void UpdateNeighbors(List<Node> friends) {
        neighbors = friends;
    }
}
