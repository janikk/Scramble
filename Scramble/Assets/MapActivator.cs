using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActivator : MonoBehaviour {
    
    [SerializeField] private GameObject destructed;
    [SerializeField] private GameObject activated;
    [SerializeField] private GameObject activated2;
    
    AudioSource source;
    
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player")
        {
            if(activated != null)activated.SetActive(true);
            if(activated2 != null)
            {
                activated2.GetComponent<SlidePuzzle>().enabled = true;
                SpriteRenderer sr= activated2.GetComponent<SpriteRenderer>();
                if(sr != null)
                {
                    sr.color = Color.black;
                }
            }
            Destroy(destructed);
            Destroy(gameObject);
        }
    }
}
