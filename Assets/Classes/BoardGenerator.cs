using UnityEngine;
using System.Collections;

public class BoardGenerator : MonoBehaviour {

    public bool run; 

    public int width;
    public int height;

    public Piece piece;
    public ClickableTile tile; 

    public GameObject board;

    // Use this for initialization
    void Start()
    {
        if (!run)
        {
            return;
        }

        ClickableTile[][] tiles = new ClickableTile[height][];

        //generate board obbjetc and parent them to board 
        for (int i = 0; i < height; i++)
        {
            tiles[i] = new ClickableTile[width];
            for (int j = 0; j < width; j++)
            {
                //create new tile 
                ClickableTile newTile = GameObject.Instantiate(tile);

                //set tile name 
                newTile.name = "tile " + j + " " + i;
                newTile.x = j;
                newTile.y = i;

                //parent tile to board 
                newTile.transform.SetParent(board.transform);

                //store tile map
                newTile.transform.SetParent(board.transform);
                tiles[i][j] = newTile;
            }
        }

        //relate each tile object to surrdening
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //up 
                if (i - 1 >= 0 && i - 1 <= height - 1)
                {
                    tiles[i][j].up = tiles[i - 1][j];
                }

                //down 
                if (i + 1 >= 0 && i + 1 <= height - 1)
                {
                    tiles[i][j].down = tiles[i + 1][j];
                }

                //right 
                if (j + 1 >= 0 && j + 1 <= width - 1)
                {
                    tiles[i][j].right = tiles[i][j + 1];
                }

                //left 
                if (j - 1 >= 0 && j - 1 <= width - 1)
                {
                    tiles[i][j].left = tiles[i][j - 1];
                }
            }
        }


        //set piece 
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Piece newPiece = GameObject.Instantiate(piece);

                newPiece.isKing = false;
                newPiece.Team = i / 2;
                newPiece.name = "piece " + newPiece.Team; 

                int offset = (newPiece.Team == 1) ? 2 : 0; 

                newPiece.transform.SetParent(tiles[offset + i + 1][j].transform); 

            }
        }
        
    }
	
}
