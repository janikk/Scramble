using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour {
    
    [SerializeField] private LayerMask layerMask = Physics2D.DefaultRaycastLayers;
    [SerializeField] private string axisU;
    [SerializeField] private string axisD;
    [SerializeField] private string axisL;
    [SerializeField] private string axisR;
    
	// Use this for initialization
	void Start () {
		
	}
	
	void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(axisU))
        {
            slideUp();
        }
        else if(Input.GetButtonDown(axisD))
        {
            slideDown();
        }
        else if(Input.GetButtonDown(axisL))
        {
            slideLeft();
        }
        else if(Input.GetButtonDown(axisR))
        {
            slideRight();
        }
	}
	
	void slideDown()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.up, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            SubLevel sl = hit.collider.gameObject.GetComponent<SubLevel>();
            if(sl && sl.canMove())
            {
                Vector3 temp = transform.position;
                transform.position = sl.transform.position;
                sl.transform.position = temp;
            }
        }
    }
    
    void slideUp()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            SubLevel sl = hit.collider.gameObject.GetComponent<SubLevel>();
            if(sl && sl.canMove())
            {
                Vector3 temp = transform.position;
                transform.position = sl.transform.position;
                sl.transform.position = temp;
            }
        }
    }
    
    void slideLeft()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.right, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            SubLevel sl = hit.collider.gameObject.GetComponent<SubLevel>();
            if(sl && sl.canMove())
            {
                Vector3 temp = transform.position;
                transform.position = sl.transform.position;
                sl.transform.position = temp;
            }
        }
    }
    
    void slideRight()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.left, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            SubLevel sl = hit.collider.gameObject.GetComponent<SubLevel>();
            if(sl && sl.canMove())
            {
                Vector3 temp = transform.position;
                transform.position = sl.transform.position;
                sl.transform.position = temp;
            }
        }
    }
}
