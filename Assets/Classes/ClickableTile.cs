using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class ClickableTile : MonoBehaviour, IPointerClickHandler
{
    public GameController gameController; 

    public ClickableTile up;
    public ClickableTile down;
    public ClickableTile left;
    public ClickableTile right;

    public int x; 
    public int y;

    public bool movable; 

    public void OnPointerClick(PointerEventData eventData)
    {
        gameController.tileClicked(this); 
    }

    // Use this for initialization
    void Start ()
    {
        movable = false; 
    }


    public bool isEmpty()
    {
        return transform.childCount == 0; 
    }
	
}
