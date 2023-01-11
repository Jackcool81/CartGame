using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

public class Distance
{
    //Take in the 2D Array Read through it an parse it into a Node Graph

    //Use Dijstras/A* To find the distances of each passenger and player

    //

    // private Transform player;

    // private Transform[] passengers;

   

    public int sizeX = 50;
    public int sizeY = 50;



    public Hashtable nodelist = new Hashtable();



    public int[,] map = new int[50,50];


    public int[,] GenerateHeirarchy(int[] horizontal, int[] vertical){
        int col = 0;
        for (int i = 0; i < sizeX; i++) {
            
            for (int j = 0; j < sizeY; j++) {
                map[i,j] = 1;
                
            }
          
            
        }


    
        for (int i = 0; i < horizontal.Length; i++) {
           
            // print(col);
            
            // int col = Random.Range(0,4);
            for (int j = 3; j < sizeY - 3; j++) {
                map[horizontal[i], j] = 3;
            }
        }

      


        for (int i = 0; i < vertical.Length; i++) {
           
            // print(col);
        
            // int col = Random.Range(0,4);
            for (int j = 3; j < sizeY - 3; j++) {
                map[j, vertical[i]] = 3;
            }
        }

        map[horizontal[0], 5] = 4;

        map[horizontal[1], 30] = 0;
        return map;
    }

    // Start is called before the first frame update
    public Hashtable GeneratePath(int[,] mapper)
    {  
        map = mapper;
        for (int i = 0; i < sizeX; i++) {
            
            for (int j = 0; j < sizeY; j++) {
                if (map[i,j] == 3 || map[i,j] == 4 || map[i,j] == 0)  {
                    string key = i.ToString() + " , " + j.ToString();
                    if (!nodelist.ContainsKey(key)) { //Base Case
                        Console.WriteLine("Hello123");
                        List<Node> neighbors = checkNeighbors(i , j);
                        Node newNode = new Node(neighbors, 3, new int[2]{i,j});
                        nodelist.Add(key, newNode);
                    }
                    else {
                        List<Node> neighbors = checkNeighbors(i , j);
                        Node temp = (Node) nodelist[key]; 
                        
                        temp.UpdateNeighbors(neighbors);
                        nodelist[key] = temp;
                    }

                    
                    
                }   
            }
        }
        return nodelist;
    }

    Node CreateNode(int i, int j){

        if (map[i,j] == 3 || map[i,j] == 4 || map[i,j] == 0)
        {
            string key = i.ToString() + " , " + j.ToString();
            if (!nodelist.ContainsKey(key)){
                Node newNode = new Node(null, map[i, j], new int[2]{i, j});
                nodelist.Add(key, newNode);
                return newNode;
            }
            return (Node) nodelist[key];
        }
        return null;
            
    }

    List<Node> checkNeighbors(int i, int j) {

        List<Node> neighbors = new List<Node>();


        //right
        Node temp = CreateNode(i+1, j);
            if (temp != null) {
                neighbors.Add(temp);
            }
      
        
        //left
    
           
            temp = CreateNode(i-1, j);
            if (temp != null) {
                neighbors.Add(temp);
            }
        

        //up
     
        //    neighbors[2] = CreateNode(i+1, j+1); 
        
       
        //     neighbors[3] = CreateNode(i-1, j+1); 
        
     
          
            temp = CreateNode(i, j+1);
            if (temp != null) {
                neighbors.Add(temp);
            }
       
        //down
       
            // neighbors[5] = CreateNode(i+1, j-1); 
        
      
            // neighbors[6] = CreateNode(i-1, j-1); 
      
     
            temp = CreateNode(i, j-1);
            if (temp != null) {
                neighbors.Add(temp);
            }
            
            return neighbors;
        
    }

    public Node finder(Node root, int nameToSearchFor)
    {   
        Queue<Node> Q = new Queue<Node>();
        
        HashSet<Node> S = new HashSet<Node>();
        Console.WriteLine("Root Coord " + root.coord[0].ToString() + " " + root.coord[1].ToString());
        Q.Enqueue(root);
        S.Add(root);

        while (Q.Count > 0)
        {
            Node e = Q.Dequeue();
            if (e != null) {
                e.visited = true;
                if (e.value == nameToSearchFor)
                    return e;
                foreach (Node friend in e.neighbors)
                {
                        if (friend.visited == false) {
                            friend.distance = e.distance + 1;
                            friend.pred = e;
                            Q.Enqueue(friend);
                            S.Add(friend);
                        }
                       
                    
                    
                    
                }
            }
        }
        return null;
    }


    public int count = 0;

    public Node DFSSearch(Node root, int nameToSearchFor)
    {
        if (count == 2) {
            return null;
        }
        count++;
        if (nameToSearchFor == root.value){
            Console.WriteLine(root.value);
            return root;

        }
        Console.WriteLine("The Root is " + root.coord[0].ToString() + root.coord[1].ToString());
        Node personFound = null;
        for (int i = 0; i < root.neighbors.Count; i++)
        {
           
                Console.WriteLine("The Root is " + root.neighbors[i].coord[0].ToString() + root.neighbors[i].coord[1].ToString());
                personFound = DFSSearch(root.neighbors[i], nameToSearchFor);
                Console.WriteLine(personFound);
                if (personFound != null)
                    break;
            
            
        }
        return personFound;
    }



}

