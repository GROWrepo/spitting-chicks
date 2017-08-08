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
        self.setBullet((GameObject)Resources.Load("Pref/Seed"));
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.shot(self.getIsRight());
        }
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
            if(collision.gameObject.tag == "GROUND" && collision.gameObject.GetComponent<Transform>().parent.name != "SuperJumps")
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
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1.6f * self.getJump())); //슈퍼점프 높이 조절
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
    private void shot(bool isRight)
    {
        int multi;
        multi = isRight ? 1 : -1;
        GameObject tempBullet = Instantiate<GameObject>(self.getBullet(),this.gameObject.GetComponent<Transform>().position + new Vector3(2.5f * multi, 2.0f),Quaternion.identity);
        tempBullet.SendMessage("setRight", self.getIsRight());
    }
    private void hitDamage(int damage)
    {
        Debug.Log(this.gameObject.GetComponent<Transform>().GetChild(1).GetChild(0).gameObject.name);
        this.self.setCurrentHealth(this.self.getCurrentHealth() - damage);
        if (this.self.getCurrentHealth() > 0)
        {
            this.gameObject.GetComponent<Transform>().GetChild(1).GetChild(0).localScale = new Vector3((float)this.self.getCurrentHealth() / this.self.getMaxHealth(), 1.0f, 1.0f);
            Debug.Log("Current HP bar Scale :" + (float)this.self.getCurrentHealth() / this.self.getMaxHealth());
            Debug.Log("Current Health :" + this.self.getCurrentHealth());
        }
        else
        {
            Debug.Log("Die Already");
        }
    }
}
