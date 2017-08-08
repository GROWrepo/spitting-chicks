using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {
    public bool isDisa;
    public int cool;
    public float time;


    // Use this for initialization
    void Start () {
        isDisa = true;
        cool = 6;
        time = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.SetActive(isDisa);
        isDisa = time < cool / 2;
        if(time > cool)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}