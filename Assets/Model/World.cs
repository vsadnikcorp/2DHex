using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World 
{
    Tile[,] tiles;
    int width;
    int height;

    public int Width
    {
        get
        {
            return width;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }
    }
    

    public World(int width, int height)
    {
        this.width = width;
        this.height = height;

        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }
    }

    public Tile GetTileAt(int x, int y)
    {
        if (x > width || x < 0 || y > height || y < 0)
        {
            Debug.Log("Tile (" + x + ", " + y + ") is out of range.");
            return null;
        }

        return tiles[x, y];
    }

    public void TESTING_RandomizeTiles()
    {
        int random;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                random = Random.Range(0, 3);

                switch (random)
                {
                    case 0:
                        tiles[x, y].Type = Tile.TileType.Flat;
                        break;
                    case 1:
                        tiles[x, y].Type = Tile.TileType.Mountain;
                        break;
                    case 2:
                        tiles[x, y].Type = Tile.TileType.Water;
                        break;
                }
            }
        }
    }

}
