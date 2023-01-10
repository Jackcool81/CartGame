using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMap : MonoBehaviour
{
    public int sizeX = 50;
    public int sizeY = 50;
    public int[,] map = new int[50,50];

    

    //Generation Variables
    public int yRoads = 4;

    private int[] HorizontalRoads = new int[4];
    private int[] VerticalRoads = new int[4];

    //Sprites
    public Sprite road;
    public Sprite forest;
    public Sprite landmark;
    public Sprite passenger;

    public GameObject[] worldChunks;
    public int numChucks = 0;

    public GameObject invScript;

    public List<Vector2> worldTiles = new List<Vector2>();
    public List<GameObject> worldTileObjects = new List<GameObject>();

    // private int[] validChoices = new int[50];
    List<int> validChoices = new List<int>();
    List<int> temp = new List<int>();
    
    public void GenerateWorld() {
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
        generateHotSpots();
        generatePassengers();
        CreateMap();
        print();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }
    
    void generateHotSpots() {
        
        int row = Random.Range(0,100);
        int col = Random.Range(0,100);
        for (int i = 0; i < HorizontalRoads.Length; i++)
        {
            map[HorizontalRoads[i], Random.Range(5,sizeX - 5)] = 2;
        }

        for (int i = 0; i < HorizontalRoads.Length; i++)
        {
            map[Random.Range(5,sizeX - 5), HorizontalRoads[i]] = 2;
        }
    }

     void generatePassengers() {

        //Need the number of passengers
        int numPass = Mathf.Clamp(HorizontalRoads.Length, (int)(Mathf.Ceil(sizeX/20)), sizeX/10);
        
        print(numPass); 

        
        // for (int i = 0; i < numPass; i++)
        // {
        //     map[HorizontalRoads[i], Random.Range(5,sizeX - 5)] = 4;
        // }

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
            Debug.Log("This is the road" + row.ToString());
            HorizontalRoads[i] = row;
            
            for (int j = 3; j < sizeX - 3; j++) {
                if (row != -1) {
                    map[j,row] = 3;
                    map[j,row+1] = 3;
                    map[j,row-1] = 3;
                    map[j,row+2] = 3;
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
                if (map[col, j] == 1) {
                    map[col,j ] = 3;
                    map[col+1,j ] = 3;
                    map[col-1,j ] = 3;
                    map[col+2,j ] = 3;
                }
            }
        }
    }

    void print() {
        string fullPath = "C:\\Users\\Jackw\\Documents\\Githubs\\CarriageGame\\TheCarriageGame\\Assets\\Scripts\\test.txt";
        string line = "";
        using (StreamWriter writer = new StreamWriter(fullPath))
        {
              for (int i = 0; i < 50; i++) {
                for (int j = 0; j < 50; j++) {
                    line = line + map[i,j].ToString() + " ";
                }
                writer.WriteLine(line);
                line = "";
            }
           
        
        }
    }
    
    void CreateMap() {
        Sprite tileSprite = null; 
        for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) { 
                    if (map[i,j] == 1) {
                        tileSprite = forest;
                    }
                    if (map[i,j] == 3) {
                        tileSprite = road;
                    }
                    if (map[i,j] == 2) {
                        tileSprite = landmark;
                    }
                    if (map[i,j] == 4) {
                        tileSprite = passenger;
                    }
                    PlaceTile(tileSprite, i, j);
                    
                }
        }
    }


    public void PlaceTile(Sprite tileSprite, int x, int y) {
        if (tileSprite == null)
        {
            return;
        }

        GameObject newTile = new GameObject();

        float chunkCoord = (Mathf.Round(x / 50) * 50);
        chunkCoord /= 50;
        Debug.Log(chunkCoord);

        newTile.AddComponent<SpriteRenderer>();
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.AddComponent<BoxCollider2D>();
        newTile.transform.position = new Vector2(x +0.5f,y +0.5f);
        worldTiles.Add(newTile.transform.position - (Vector3.one * 0.5f));
        worldTileObjects.Add(newTile);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
