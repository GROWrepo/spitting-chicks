using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour {
    GameObject SuperJumpObject;
    public float multi;
    public int cool;
    private bool onCool;
    public int calc;
	// Use this for initialization
	void Start () {
        SuperJumpObject = GameObject.Find("SuperJumps");
        multi = 1.6f;
        onCool = false;
        cool = 5;
        calc = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (onCool)
        {
            calc--;
        }
        if(calc <= 0)
        {
            onCool = false;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(collision.gameObject.tag == "Player" && !onCool)
            {
                collision.gameObject.SendMessage("SuperJumps");
                onCool = true;
                calc = cool;
            }
        }
    }

}
