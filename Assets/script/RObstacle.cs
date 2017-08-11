using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RObstacle : MonoBehaviour {
    Transform RObstacleTransform;
    public Vector3 LocalScale;
    public bool bottom;
    public bool first;
    // Use this for initialization
    void Start () {
        RObstacleTransform = this.GetComponent<Transform>().GetChild(0);
        LocalScale = RObstacleTransform.localScale;
        first = true;
        bottom = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(first)
        {
            RObstacleTransform.localScale -= LocalScale;
            RObstacleTransform.localScale += new Vector3(LocalScale.x, 0, LocalScale.z);
            first = false;       
        }

        if(RObstacleTransform.localScale.y <= 0)
        {
            RObstacleTransform.localScale += new Vector3(0, 0.01f, 0);
            bottom = true;

        } else if (0 < RObstacleTransform.localScale.y && RObstacleTransform.localScale.y < LocalScale.y)
        {
            if (bottom)
            {
                RObstacleTransform.localScale += new Vector3(0, 0.01f, 0);

            } else if (!bottom)
            {
                RObstacleTransform.localScale += new Vector3(0, -0.01f, 0);
            }

        } else if (RObstacleTransform.localScale.y >= LocalScale.y)
        {
            RObstacleTransform.localScale += new Vector3(0, -0.01f, 0);
            bottom = false;
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
