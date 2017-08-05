using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
    public float speed;
    public Vector2 left, right;
    public bool isTele;
    // Use this for initialization
    void Start () {
        left = this.gameObject.GetComponent<Transform>().localPosition;
        right = new Vector2(0, 10);
        speed = 4.0f; 
        isTele = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTele = true;
        }
        if (isTele)
        {
            this.gameObject.GetComponent<Transform>().Translate(0, 10, 0);
            isTele = false;
        }
	}
}
