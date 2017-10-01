using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SubLevel : MonoBehaviour {
    GameObject player;
	// Use this for initialization    
	void Start()
    {
		
	}
	
	void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        player = GameObject.FindWithTag("player");
        foreach(Transform t in transform)
        {
            if(t.gameObject.tag == "ememy")t.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player")
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            col.gameObject.transform.parent = transform;
            foreach(Transform t in transform)
            {
                if(t.gameObject.tag == "ememy")t.gameObject.SetActive(true);
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "player")
        {
            foreach(Transform t in transform)
            {
                if(t.gameObject.tag == "ememy")t.gameObject.SetActive(false);
            }
        }
    }
    
    virtual public bool canMove()
    {
        return player.transform.parent != transform;
    }
}
