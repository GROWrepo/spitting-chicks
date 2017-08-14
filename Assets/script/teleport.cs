using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
    public bool isTele;
    public int cool;
    public float time;
    GameObject dest;
    // Use this for initialization
    void Start () {
        isTele = true;
        cool = 1;
        time = 0.0f;
        dest = GameObject.Find("Ground (3)");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isTele)
        {
            if(time < 0)
            {
                isTele = true;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(collision.gameObject.tag == "Player" && isTele)
            {
                collision.gameObject.GetComponent<Transform>().Translate(dest.GetComponent<Transform>().position - collision.gameObject.GetComponent<Transform>().position + new Vector3(0,1,0));
                isTele = false;
                time = cool;
            }
        }
    }
}
