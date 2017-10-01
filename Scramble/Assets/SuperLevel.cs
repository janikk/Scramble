using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLevel : SubLevel {
    
    [SerializeField] private SubLevel parent;
    
	override public bool canMove()
    {
        return parent.canMove();
    }
}
