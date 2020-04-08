using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector2 lastFramePosition;
    public GameObject tileCursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //UPDATE THE TILECURSOR POSITION
        Tile tileUnderMouse = GetTileAtWorldCoordinate(currentFramePosition);

        //if (tileUnderMouse != null)
        if (tileUnderMouse != null && !Input.anyKey)
        {
            tileCursor.SetActive(true);
            Vector2 cursorPosition = new Vector2(tileUnderMouse.X, tileUnderMouse.Y);
            tileCursor.transform.position = cursorPosition;
        }
        else
        {
            tileCursor.SetActive(false);
        }

        //HANDLE LEFT MOUSE BUTTON
        if(Input.GetMouseButtonUp(0))
        {
            if(tileUnderMouse != null)
            {
                tileUnderMouse.Type = Tile.TileType.Flat;
            }
        }

        Tile GetTileAtWorldCoordinate(Vector2 coord)
        {
            int x = Mathf.RoundToInt(coord.x);
            int y = Mathf.RoundToInt(coord.y);

            return WorldController.WorldInstance.World.GetTileAt(x, y);
        }
    }
}
