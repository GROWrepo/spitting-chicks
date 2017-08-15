using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    Transform ObstacleTransform;
    public Vector3 LocalScale;
    public bool top;

    // Use this for initialization
    void Start () {
        ObstacleTransform = this.GetComponent<Transform>().GetChild(0);
        LocalScale = ObstacleTransform.localScale;
        top = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(ObstacleTransform.localScale.y == LocalScale.y)
        {
            ObstacleTransform.localScale += new Vector3(0, -0.01f, 0);
            top = true;

        } else if(0 < ObstacleTransform.localScale.y && ObstacleTransform.localScale.y < LocalScale.y)
        {
            if (top)
            {
                ObstacleTransform.localScale += new Vector3(0, -0.01f, 0);

            } else if(!top)
            {
                ObstacleTransform.localScale += new Vector3(0, 0.01f, 0);
            }  

        } else if(ObstacleTransform.localScale.y < 0)
        { 
            ObstacleTransform.localScale += new Vector3(0, 0.01f, 0);
            top = false;

        } 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("hitDamage", 10);
        }
    }
  

}
