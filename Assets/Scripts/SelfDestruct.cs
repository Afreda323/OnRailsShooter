﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destroySelf", 3f);
	}
	
    private void destroySelf () 
    {
        Destroy(gameObject);
    }
}
