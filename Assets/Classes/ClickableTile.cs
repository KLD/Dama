using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class ClickableTile : MonoBehaviour, IPointerClickHandler
{
    public ClickableTile up;
    public ClickableTile down;
    public ClickableTile left;
    public ClickableTile right;

    public int x; 
    public int y; 

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("I got clicked : " + gameObject.name); 
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
