using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    public bool isSpawn;
    public int cool;
    public float time;



    // Use this for initialization
    void Start()
    {
        cool = 4;
        time = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isSpawn)
        {
            if (cool > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
            }
        }

    }
}
