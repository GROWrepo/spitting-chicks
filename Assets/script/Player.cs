using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int CHealth;
    private int MHealth;
    private float damage;
    private float speed;
    private float jump;
    private bool isRight;
    private GameObject bullet;
    private int seeds;
    public Player()
    {
        this.CHealth = 100;
        this.MHealth = 100;
        this.damage = 10.0f;
        this.speed = 6.0f;
        this.jump = 550.0f;
        this.isRight = false;
        this.seeds = 0;
    }

#region getter
    public int getCurrentHealth()
    {
        return this.CHealth;
    }
    public int getMaxHealth()
    {
        return this.MHealth;
    }
    public float getDamage()
    {
        return this.damage;
    }
    public float getSpeed()
    {
        return this.speed;
    }
    public float getJump()
    {
        return this.jump;
    }
    public bool getIsRight()
    {
        return this.isRight;
    }
    public GameObject getBullet()
    {
        return this.bullet;
    }
    public int getSeeds()
    {
        return this.seeds;
    }
#endregion

#region setter
    public void setCurrentHealth(int CHealth)
    {
        this.CHealth = CHealth;
    }
    public void setMaxHealth(int MHealth)
    {
        this.MHealth = MHealth;
    }
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void setJump(float jump)
    {
        this.jump = jump;
    }
    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
    }
    public void setBullet(GameObject bullet)
    {
        this.bullet = bullet;
    }
    public void setSeeds(int seeds)
    {
        this.seeds = seeds;
    }
    #endregion

}
