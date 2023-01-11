using System;
using System.Collections;
using System.Collections.Generic;

class Program {

// Main Method
    static public void Main(String[] args)
    {
        GenerateMap mapper = new GenerateMap();
        int[,] map = mapper.GenerateWorld();
        Console.WriteLine("Horizontal Roads");
     
        Distance dist = new Distance();
        int[,] mapped = dist.GenerateHeirarchy(mapper.HorizontalRoads, mapper.VerticalRoads);
        mapper.print(mapped, "test.txt");
        Hashtable nodes = dist.GeneratePath(mapped);
        Node temp = (Node) nodes[mapper.HorizontalRoads[0].ToString() +" , "+ "5"];
        foreach (Node i in temp.neighbors) {
            Console.WriteLine(i.value);
        }
        // Console.WriteLine("next Node");
        // temp = (Node) nodes[mapper.HorizontalRoads[0].ToString() +" , "+ "6"];
        // foreach (Node i in temp.neighbors) {
        //     Console.WriteLine(i.value);
        // }
        // Console.WriteLine(dist.DFSSearch((Node) nodes[mapper.HorizontalRoads[0].ToString() +" , "+ "5"], 0));
        int v = (mapper.HorizontalRoads.Length + mapper.VerticalRoads.Length) * mapper.sizeX - 6;
        int []pred = new int[v];
        int []distance = new int[v];
        Node x = dist.finder((Node) nodes[mapper.HorizontalRoads[0].ToString() +" , "+ "5"], 0);
        Console.WriteLine(x.distance);
        
    }
}