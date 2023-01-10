using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    //Take in the 2D Array Read through it an parse it into a Node Graph

    //Use Dijstras/A* To find the distances of each passenger and player

    //

    private Transform player;

    private Transform[] passengers;

    private int[,] map = new int[50,50];




    // Start is called before the first frame update
    public void GeneratePath()
    {
        map = GameObject.Find("Test").GetComponent<GenerateMap>().map;
        int sizeX = GameObject.Find("Test").GetComponent<GenerateMap>().sizeX;
        int sizeY = GameObject.Find("Test").GetComponent<GenerateMap>().sizeY;
// Driver's Code


		GFG t = new GFG();
        
		// Function call
		int[] hello = t.dijkstra(map, 4);
        foreach(int i in hello){
            print(i);
        }

        MazeSolover maze = new MazeSolover(map);
        bool solved = maze.solve();


        Hashtable nodelist = new Hashtable();
        //ContainsKey("")
      
             
        for (int i = 0; i < sizeX; i++) {
            
            for (int j = 0; j < sizeY; j++) {
                if (map[i,j] == 3) {
                    
                    Node newNode = new Node(null, 3, new int[2]{i,j});
                    nodelist 
                }
                if (map[i,j] == 4) {
                    Node newNode = new Node(null, 4, new int[2]{i,j});
                }
                
                
                
            }
           
            
        // }
    }

    Node[] checkNeighbors(int i, int j) {
        Node[] neighbors = new Node[8];
        //right
        if (map[i+1, j] == 3) {

        }
        //left
        if (map[i-1, j] == 3) {

        }

        //up
        if (map[i + 1, j + 1] == 3) {

        }
        if (map[i - 1, j + 1] == 3) {

        }
        if (map[i, j + 1] == 3) {

        }
        //down
        if (map[i + 1, j - 1] == 3) {

        }
        if (map[i - 1, j - 1] == 3) {

        }
        if (map[i, j - 1] == 3) {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
