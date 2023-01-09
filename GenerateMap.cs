using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMap : MonoBehaviour
{
    public int sizeX = 10;
    public int sizeY = 10;
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

    


    // Start is called before the first frame update
    void Start()
    {
        int[] choices = new int[5] {8, 16, 24, 32, 40};
        foreach (int i in choices) {
            validChoices.Add(i);
        }
        
        for (int i = 0; i < 50; i++) {
            
            for (int j = 0; j < 50; j++) {
                map[i,j] = 1;
            }
        }
        generateRoads();
        generateHotSpots();
        generatePassengers();
        CreateMap();
        print();
    }
    
    void generateHotSpots() {
        
        int row = Random.Range(0,100);
        int col = Random.Range(0,100);
        for (int i = 0; i < 4; i++)
        {
            map[HorizontalRoads[i], Random.Range(5,41)] = 2;
        }

        for (int i = 0; i < 4; i++)
        {
            map[Random.Range(5,41), HorizontalRoads[i]] = 2;
        }
    }

     void generatePassengers() {
        
        for (int i = 0; i < 4; i++)
        {
            map[HorizontalRoads[i], Random.Range(5,41)] = 4;
        }

        for (int i = 0; i < 4; i++)
        {
            map[Random.Range(5,41), HorizontalRoads[i]] = 4;
        }
    }

    int GenerateRoadSimple() {
        int ans = validChoices[Random.Range(0, validChoices.Count)];
        validChoices.Remove(ans);
        return ans;
    }

    

    //How man
    void generateRoads() {
        int[] rowRoads = new int[4];
        //Generating Horizontal Rows 
        for (int i = 0; i < 4; i++) {
            int row = GenerateRoadSimple(); 
            Debug.Log("This is the road" + row.ToString());
            rowRoads[i] = row;
            
            for (int j = 3; j < 46; j++) {
                if (row != -1) {
                    map[j,row] = 3;
                    map[j,row+1] = 3;
                    map[j,row-1] = 3;
                    map[j,row+2] = 3;
                }

            }
        
        }

        HorizontalRoads = rowRoads;
        
        // //Generating Vertical Roads
        for (int i = 0; i < 4; i++) {
            // int col = Random.Range(0,4);
            for (int j = 5; j < 41; j++) {
                if (map[rowRoads[i], j] == 1) {
                    map[rowRoads[i],j ] = 3;
                    map[rowRoads[i]+1,j ] = 3;
                    map[rowRoads[i]-1,j ] = 3;
                    map[rowRoads[i]+2,j ] = 3;
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
        for (int i = 0; i < 50; i++) {
                for (int j = 0; j < 50; j++) { 
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
