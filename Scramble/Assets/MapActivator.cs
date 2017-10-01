using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActivator : MonoBehaviour {
    
    [SerializeField] private GameObject destructed;
    [SerializeField] private GameObject instantiated;
    
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player")
        {
            Transform t = destructed.transform;
            Destroy(destructed);
            Instantiate(instantiated, t.position, t.rotation);
            Destroy(gameObject);
        }
    }
}
