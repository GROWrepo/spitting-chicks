using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour {
    public float speed;
    public float rotate;
    public bool isRight;
    private int damage;
	// Use this for initialization
	void Start () {
        speed = 8.0f;
        rotate = 20.0f;
        damage = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.GetComponent<Transform>().GetChild(0).Rotate(new Vector3(0, 0, rotate));
        speed = isRight? 8.0f : -8.0f;
        this.gameObject.GetComponent<Transform>().Translate(speed * Time.deltaTime,0,0);
    }
    private void setRight(bool isRight)
    {
        this.isRight = isRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player1>().getSP() != STATUS_PLAYER.STUN)
            {
                collision.gameObject.SendMessage("hitDamage", this.damage);
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag == "BULLET")
        {

        }
    }
}
