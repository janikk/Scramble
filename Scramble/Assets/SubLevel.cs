using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SubLevel : MonoBehaviour {
	// Use this for initialization
	void Start()
    {
		
	}
	
	void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "player")
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            col.gameObject.transform.parent = transform;
            Camera.main.transform.parent = transform;
        }
    }
    
    public bool canMove()
    {
        return !(Mathf.Approximately(Camera.main.transform.position.x, transform.position.x) && Mathf.Approximately(Camera.main.transform.position.y, transform.position.y));
    }
}
