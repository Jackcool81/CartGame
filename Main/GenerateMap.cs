using System.Collections;
using System.Collections.Generic;

using System.IO;

public class GenerateMap
{
    public int sizeX = 50;
    public int sizeY = 50;
    public int[,] map = new int[50,50];

    

    //Generation Variables
    public int yRoads = 4;

    public int[] HorizontalRoads = new int[4];
    public int[] VerticalRoads = new int[4];

    public int[] passengers = new int [4];


    public int numChucks = 0;


    // public List<Vector2> worldTiles = new List<Vector2>();
    // public List<GameObject> worldTileObjects = new List<GameObject>();

    // private int[] validChoices = new int[50];
    List<int> validChoices = new List<int>();
    List<int> temp = new List<int>();
    
    public int[,] GenerateWorld() {
        Console.WriteLine("Hello");
        int[,] newmap = new int[sizeX, sizeY];
        map = newmap;
        HorizontalRoads = new int[Random.Range(3, sizeX/10)];
        VerticalRoads = new int[Random.Range(2, sizeX/10)];
     
      
        for (int i = 0; i < sizeX; i++) {
            
            for (int j = 0; j < sizeY; j++) {
                map[i,j] = 1;
                
            }
            if (i != 0 && i % 8 == 0 && sizeX - i > 8) {
                    validChoices.Add(i);
                    temp.Add(i);
            }
            
        }

        // print(HorizontalRoads.Length);
        generateRoads();
        // generateHotSpots();
        generatePassengers();
        print(map, "map.txt");
        return map;
        
    }

    
    
    // void generateHotSpots() {
        
    //     int row = Random.Range(0,100);
    //     int col = Random.Range(0,100);
    //     for (int i = 0; i < HorizontalRoads.Length; i++)
    //     {
    //         map[HorizontalRoads[i], Random.Range(5,sizeX - 5)] = 2;
    //     }

    //     for (int i = 0; i < HorizontalRoads.Length; i++)
    //     {
    //         map[Random.Range(5,sizeX - 5), HorizontalRoads[i]] = 2;
    //     }
    // }

     void generatePassengers() {

        //Need the number of passengers
        int numPass = Math.Clamp(HorizontalRoads.Length, (3), sizeX/10);
        
      

        map[HorizontalRoads[0], 5] = 4;

        map[HorizontalRoads[2], 30] = 0;

        // for (int i = 0; i < numPass; i++)
        // {
        //     map[Random.Range(5,sizeX - 5), HorizontalRoads[i]] = 4;
        // }
    }

    int GenerateXRoadSimple() {
        int ans = validChoices[Random.Range(0, validChoices.Count)];
        validChoices.Remove(ans);
        return ans;
    }

    int GenerateYRoadSimple() {
        int ans = validChoices[Random.Range(0, validChoices.Count)];
        validChoices.Remove(ans);
        return ans;
    }

    

    //How man
    void generateRoads() {
        
        //Generating Horizontal Rows 
        for (int i = 0; i < HorizontalRoads.Length; i++) {
            int row = GenerateXRoadSimple(); 
            HorizontalRoads[i] = row;
            
            for (int j = 3; j < sizeX - 3; j++) {
                if (row != -1) {
                    map[row,j] = 3;
                    map[row+1,j] = 3;
                    map[row-1,j] = 3;
                    map[row+2,j] = 3;
                }

            }
        
        }

        validChoices = temp;

        
        // //Generating Vertical Roads
        for (int i = 0; i < VerticalRoads.Length; i++) {
            int col = GenerateYRoadSimple();
            // print(col);
            VerticalRoads[i] = col;
            // int col = Random.Range(0,4);
            for (int j = 3; j < sizeY - 3; j++) {
                if (map[j, col] == 1) {
                    map[j,col ] = 3;
                    map[j,col+1 ] = 3;
                    map[j,col-1 ] = 3;
                    map[j,col+2 ] = 3;
                }
            }
        }
    }

    public void print(int[,] mapper, string path) {
        string fullPath = path;
        string line = "";
        using (StreamWriter writer = new StreamWriter(fullPath))
        {
              for (int i = 0; i < 50; i++) {
                for (int j = 0; j < 50; j++) {
                    line = line + mapper[i,j].ToString() + " ";
                }
                writer.WriteLine(line);
                line = "";
            }
           
        
        }
    }
    





    // Update is called once per frame
    void Update()
    {
        
    }
}
