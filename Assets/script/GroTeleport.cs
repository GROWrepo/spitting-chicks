using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroTeleport : MonoBehaviour {
    public Vector2 up, down;
    public bool isTeleGro;

	// Use this for initialization
	void Start () {
        down = this.gameObject.GetComponent<Transform>().localPosition;
        up = new Vector2(0, 10);
        isTeleGro = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTeleGro = true;
        }
        if (isTeleGro)
        {
            this.gameObject.GetComponent<Transform>().Translate(0, 4, 0);
            isTeleGro = false;
        }



    }
}
