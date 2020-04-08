using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldController : MonoBehaviour
{

    public static WorldController WorldInstance { get; protected set; }
    //World world;
    public World World { get; protected set; }

    public Sprite spriteFlat;
    public Sprite spriteMountain;
    public Sprite spriteWater;

    public int Width;
    public int Height;

    //float TESTrandomtimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //SET STATIC VARIABLE _worldinstance TO THIS WORLD INSTANCE
        if(WorldInstance != null)
        {
            Debug.Log("There should never be two worldcontrollers");
        }
        WorldInstance = this;

        //CREATE A WORLD WITH EMPTY TILES
        World = new World(Width, Height);

        //CREATE A GAMEOBJECT FOR EACH OF OUR TILES
        //SO THAT THEY SHOW VISUALLY
        for (int x = 0; x < World.Width; x++)
        {
            for (int y = 0; y < World.Height; y++)
            {
                Tile tile_data = World.GetTileAt(x, y);
                GameObject GO_tile = new GameObject();
                GO_tile.name = "Tile_" + x + "_" + y;
                //GO_tile.transform.position = new Vector3(tile_data.X, tile_data.Y,0);
                GO_tile.transform.position = new Vector2(tile_data.X, tile_data.Y);
                GO_tile.transform.SetParent(this.transform, true);

                //ADD A SPRITE RENDERER, BUT DON'T ADD SPRITE
                //BECAUSE ALL THE TILES ARE EMPTY FOR NOW
                GO_tile.AddComponent<SpriteRenderer>();

                tile_data.RegisterTileTypeChangedCallback((tile) => { TESTING_OnTileTypeChanged(tile, GO_tile);
                }); ;
            }
        }
        World.TESTING_RandomizeTiles();

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// CHANGES MAP GRAPHICS IF MAP DATA CHANGES.SEE 22:54
    /// https://www.youtube.com/watch?v=hnC8iSehFSM
    /// </summary>
    /// <param name="tile_data"></param>
    /// <param name="GO_tile"></param>
    void TESTING_OnTileTypeChanged(Tile tile_data, GameObject GO_tile)
    {
        switch (tile_data.Type)
        {
            case Tile.TileType.Flat:
                GO_tile.GetComponent<SpriteRenderer>().sprite = spriteFlat;
                break;
            case Tile.TileType.Mountain:
                GO_tile.GetComponent<SpriteRenderer>().sprite = spriteMountain;
                break;
            case Tile.TileType.Water:
                GO_tile.GetComponent<SpriteRenderer>().sprite = spriteWater;
                break;
        }
    }
}
