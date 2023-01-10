using System;

public class MazeSolover {

    private int TRIED = 2;
    private static int PATH = 3;



    private int[,] grid;
    private int height;
    private int width;

    private int[,] map;

    public MazeSolover(int[,] grid) {
        this.grid = grid;
        this.height = grid.Length;
        this.width = grid.Length;

        this.map = new int[height,width];
    }

    public bool solve() {
        return traverse(0,0);
    }

    private bool traverse(int i, int j) {
        if (!isValid(i,j)) {
            return false;
        }

        if ( isEnd(i, j) ) {
            map[i,j] = PATH;
            return true;
        } else {
            map[i,j] = TRIED;
        }

        // North
        if (traverse(i - 1, j)) {
            map[i-1,j] = PATH;
            return true;
        }
        // East
        if (traverse(i, j + 1)) {
            map[i,j + 1] = PATH;
            return true;
        }
        // South
        if (traverse(i + 1, j)) {
            map[i + 1,j] = PATH;
            return true;
        }
        // West
        if (traverse(i, j - 1)) {
            map[i,j - 1] = PATH;
            return true;
        }

        return false;
    }

    private bool isEnd(int i, int j) {
        return i == height - 1 && j == width - 1;
    }

    private bool isValid(int i, int j) {
        if (inRange(i, j) && isOpen(i, j) && !isTried(i, j)) {
            return true;
        }

        return false;
    }

    private bool isOpen(int i, int j) {
        return grid[i,j] == 1;
    }

    private bool isTried(int i, int j) {
        return map[i,j] == TRIED;
    }

    private bool inRange(int i, int j) {
        return inHeight(i) && inWidth(j);
    }

    private bool inHeight(int i) {
        return i >= 0 && i < height;
    }

    private bool inWidth(int j) {
        return j >= 0 && j < width;
    }

    public string toString() {
        string s = "";
        // foreach (int[] row in map) {
        //     s += Arrays.toString(row) + "\n";
        // }

        return s;
    }
}
