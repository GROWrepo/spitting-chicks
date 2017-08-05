using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {
    public float speed;
    public Vector2 low, high;
    public bool isDown;
	// Use this for initialization
	void Start ()
    {
        low = this.gameObject.GetComponent<Transform>().localPosition;
        high = low + new Vector2(0, 10);
        speed = 4.0f;
        isDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDown)
        {
            if (low.y > this.gameObject.GetComponent<Transform>().localPosition.y)
            {
                isDown = false;
            }
        }
        else
        {
             if (high.y < this.gameObject.GetComponent<Transform>().localPosition.y) 
            {
                isDown = true;
            }
        }
        if (!isDown) {
            this.GetComponent<Transform>().Translate(0, this.speed * Time.deltaTime, 0);
        }
        else
        {
            
            this.GetComponent<Transform>().Translate(0, -this.speed * Time.deltaTime, 0);
        }
    }
    private void function()
    {
        Debug.Log("my first function");
    }
}
