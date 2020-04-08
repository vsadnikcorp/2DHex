using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile 
{//TileType is the terrain type of the tile
    public enum TileType { Flat, Mountain, Water }
    private TileType _type = TileType.Flat;

   //TileType property with setter/getter
    public TileType Type
    {
        get { return _type; }
        set
        {
            TileType oldType = _type;
            _type = value;

            //if (callbackTileTypeChanged != null && oldType != _type)
            if (callbackTileTypeChanged != null)
            {
                //CALL THE CALLBACK AND LET THINGS NOW TILES HAVE CHANGED
                callbackTileTypeChanged(this);
            }
        }
    }

    //somthing movable and stackable (ie, like unit?)
    LooseObject looseObject;

    //something fixed, perhaps a factory, entrench, etc.
    InstalledObject installedObject;

    World world;

    public int X { get; private set; }
    public int Y { get; private set; }

    //FUNCTION CALLED BACK WHENEVER TILE TYPE CHANGES
    Action<Tile> callbackTileTypeChanged;

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.X = x;
        this.Y = y;
    }

    //REGISTER A FUNCTION TO BE CALLED BACK WHEN OUR TILETYPE CHANGES
    public void RegisterTileTypeChangedCallback(Action<Tile>callback_tile)
    {
        callbackTileTypeChanged += callback_tile;
    }
    //UNREGISTER A CALLBACK
    public void UnregisterTileTypeChangedCallback(Action<Tile> callback_tile)
    {
        callbackTileTypeChanged -= callback_tile;
    }
}
