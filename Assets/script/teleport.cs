using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
    public bool isTele;
    public int cool;
    public float time;
    // Use this for initialization
    void Start () {
        isTele = true;
        cool = 1;
        time = 0.0f;
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
                collision.gameObject.GetComponent<Transform>().Translate(0, 10, 0);
                isTele = false;
                time = cool;
            }
        }
    }
}
