using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour {
    public float speed;
    public Vector2 left, right;
    public bool isLeft;
    // Use this for initialization
    void Start () {
        left = this.gameObject.GetComponent<Transform>().localPosition;
        right = left + new Vector2(10 , 0);
        speed = 4.0f;
        isLeft = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (isLeft)
        {
            if(left.x > this.gameObject.GetComponent<Transform>().localPosition.x)
            {
                isLeft = false;
            }
        }
        else
        {
            if(right.x < this.gameObject.GetComponent<Transform>().localPosition.x)
            {
                isLeft = true;
            }
        }
        if (!isLeft)
        {
            this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0, 0);
        }
        else
        {

            this.GetComponent<Transform>().Translate(-this.speed * Time.deltaTime, 0, 0);
        }

    }
}
