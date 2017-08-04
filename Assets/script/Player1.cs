using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    public STATUS_PLAYER SP, preSTATUS;
    public Player self = new Player();
	// Use this for initialization
	void Start () {
        this.SP = STATUS_PLAYER.PAUSE;
        this.preSTATUS = STATUS_PLAYER.IDLE;
        self.setBullet((GameObject)Resources.Load("Pref/Sphere"));
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.SP == STATUS_PLAYER.IDLE)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[1].name, true);
                this.SP = STATUS_PLAYER.JUMPING;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[0].name, true);
                this.SP = STATUS_PLAYER.WALKING;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(-this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[0].name, true);
                this.SP = STATUS_PLAYER.WALKING;
            }
        }
        if (this.SP == STATUS_PLAYER.CROUCHING)
        {

        }
        if (this.SP == STATUS_PLAYER.DEAD)
        {

        }
        if (this.SP == STATUS_PLAYER.JUMPING)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(this.self.getSpeed() * 2 / 3 * Time.deltaTime, 0, 0);
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[0].name, true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(-this.self.getSpeed() * 2 / 3 * Time.deltaTime, 0, 0);
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[0].name, true);
            }
        }
        if (this.SP == STATUS_PLAYER.STUN)
        {

        }
        if (this.SP == STATUS_PLAYER.WALKING)
        {
            if(this.GetComponent<Rigidbody2D>().GetPointVelocity(new Vector2(0,0)) == new Vector2(0,0))
            {
                
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[1].name, true);
                this.SP = STATUS_PLAYER.JUMPING;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(this.self.getSpeed() * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.GetComponent<Transform>().Translate(-this.self.getSpeed() * Time.deltaTime, 0, 0);
            }
            else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[0].name, false);
                this.SP = STATUS_PLAYER.IDLE;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            if(collision.gameObject.tag == "GROUND" && collision.gameObject.GetComponent<Transform>().)
            {
                if(this.SP == STATUS_PLAYER.JUMPING)
                {
                    this.onGround();
                }
            } 
        }
    }

    private void onGround()
    {
        this.GetComponent<Animator>().SetBool(this.GetComponent<Animator>().parameters[1].name, false);
        SP = STATUS_PLAYER.IDLE;
    }

    private void SuperJumps()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
        SP = STATUS_PLAYER.JUMPING;
    }

    private void pause()
    {
        if (this.SP == STATUS_PLAYER.PAUSE)
        {
            this.SP = preSTATUS;
        }
        else
        {
            this.preSTATUS = this.SP;
            this.SP = STATUS_PLAYER.PAUSE;
        }
    }

    private void getSeed(int capacity)
    {
        this.self.setSeeds(capacity);
    }
}
