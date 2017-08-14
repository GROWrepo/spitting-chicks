using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    public STATUS_PLAYER SP, preSTATUS;
    public Player self = new Player();
    public float stuned;
    public int frames;
    public bool invisible;
	// Use this for initialization
	void Start () {
        this.SP = STATUS_PLAYER.PAUSE;
        this.preSTATUS = STATUS_PLAYER.IDLE;
        self.setBullet((GameObject)Resources.Load("Pref/Seed"));
        stuned = 0.0f;
        frames = 0;
        invisible = false;
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
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[1].name, true);
                this.SP = STATUS_PLAYER.JUMPING;
            }       
            else if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
                this.SP = STATUS_PLAYER.WALKING;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(-this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
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
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(this.self.getSpeed() * 2 / 3 * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(-this.self.getSpeed() * 2 / 3 * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
            }
        }
        if (this.SP == STATUS_PLAYER.STUN)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[1].name, true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(-this.self.getSpeed() * Time.deltaTime, 0, 0);
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, true);
            }
            if(stuned > self.getStunning())
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                this.SP = STATUS_PLAYER.IDLE;
            }
            else
            {
                this.stuned += Time.deltaTime;
            }
            if(invisible)
            {
                Debug.Log(this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(0).gameObject);
                this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                frames++;
                if(frames > 5)
                {
                    invisible = false;
                    frames = 0;
                }
            }
            else
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                frames++;
                if(frames > 5)
                {
                    invisible = true;
                    frames = 0;
                }
            }
        }
        if (this.SP == STATUS_PLAYER.WALKING)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, self.getJump()));
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[1].name, true);
                this.SP = STATUS_PLAYER.JUMPING;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!self.getIsRight())
                {
                    self.setIsRight(true);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(this.self.getSpeed() * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (self.getIsRight())
                {
                    self.setIsRight(false);
                    this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 180, 0);
                }
                this.gameObject.GetComponent<Transform>().Translate(-this.self.getSpeed() * Time.deltaTime, 0, 0);
            }
            else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[0].name, false);
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
        this.gameObject.GetComponent<Animator>().SetBool(this.gameObject.GetComponent<Animator>().parameters[1].name, false);
        SP = STATUS_PLAYER.IDLE;
    }

    private void SuperJumps()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1.6f * self.getJump())); //슈퍼점프 높이 조절
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
        if (this.SP != STATUS_PLAYER.STUN)
        {
            this.self.setCurrentHealth(this.self.getCurrentHealth() - damage);
            if (this.self.getCurrentHealth() > 0)
            {
                this.gameObject.GetComponent<Transform>().GetChild(1).GetChild(0).localScale = new Vector3((float)this.self.getCurrentHealth() / this.self.getMaxHealth(), 1.0f, 1.0f);
                Debug.Log("Current HP bar Scale :" + (float)this.self.getCurrentHealth() / this.self.getMaxHealth());
                Debug.Log("Current Health :" + this.self.getCurrentHealth());
                this.SP = STATUS_PLAYER.STUN;
                this.stuned = 0;
            }
            else
            {
                Debug.Log("Die Already");
                this.gameObject.GetComponent<Transform>().parent.parent.parent.gameObject.SendMessage("setStatus", STATUS_GAME.END);
            }
        }
    }
    public STATUS_PLAYER getSP()
    {
        return this.SP;
    }
}
