using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermelon : MonoBehaviour {
    bool isDown = false;
    int capacity;
	// Use this for initialization
	void Start () {
        this.capacity = 10;
	}
	
	// Update is called once per frame
	void Update () {

    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.SendMessage("getSeed", this.capacity);
                this.isGotten();
            }
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Transform>().parent.gameObject.SendMessage("getSeed", this.capacity);
            collision.gameObject.GetComponent<Transform>().parent.gameObject.SendMessage("hitDamage", this.capacity);
            this.isGotten();
        }
    }
    private void isGotten()
    {
        this.capacity += 5;
        this.gameObject.SetActive(false);
    }
}
