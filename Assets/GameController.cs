using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Piece selected;


    public void tileClicked(ClickableTile tile)
    {
        if (selected == null)
        {
            //select and highlight mobable 
            if (tile.transform.childCount > 0)
            {
                selected = tile.transform.GetChild(0).GetComponent<Piece>();

                //TODO 

                if(selected.Team == 1)
                    SelectTile(tile.up);
                else
                    SelectTile(tile.down);

                SelectTile(tile.left);
                SelectTile(tile.right);

            }


        }
        else
        {
            ClickableTile parent = selected.transform.parent.GetComponent<ClickableTile>();
            //if in range, move 
            if (tile.movable)
            {
                selected.transform.SetParent(tile.transform);
                selected.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
                //reset movablity
                DeselectTile(parent.up);
                DeselectTile(parent.down);
                DeselectTile(parent.left);
                DeselectTile(parent.right);
                selected = null; 
        }



    }

    private void DeselectTile(ClickableTile tile)
    {
        if (tile == null)
        {
            return;
        }

        tile.movable = false;
        tile.GetComponent<Image>().color = Color.white;
       
    }

    private void SelectTile(ClickableTile tile)
    {
        if(tile== null)
        {
            return; 
        }

        if (tile.isEmpty())
        {
            tile.movable = true;
            tile.GetComponent<Image>().color = Color.cyan;
        }
   
       
    }

}
