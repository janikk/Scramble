using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {
    [SerializeField] private string mapAxis;
    [SerializeField] private float zDisp;
    private bool mapped;
    private GameObject player;
	// Use this for initialization
	void Start () {
		mapped = false;
	}
	
	void Awake()
    {
        player = GameObject.FindWithTag("player");
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(mapAxis))
        {
            if(mapped)
            {
                unMap();
            }
            else
            {
                map();
            }
        }
	}
	
	void map()
    {
        transform.position = new Vector3(0, 0, transform.position.z + zDisp);
    }
    
    void unMap()
    {
        Vector3 newPos = new Vector3(player.transform.parent.position.x, player.transform.parent.position.y, transform.position.z - zDisp);
        transform.position = newPos;
    }
}
