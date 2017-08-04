﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    STATUS_GAME SG;
    Rect[] Menus;
    GUIStyle US = new GUIStyle();
    GameObject players;
    GameObject items;
    bool isSpawn;
    int spawnCoolDown;
	// Use this for initialization
	void Start () {
        SG = STATUS_GAME.MENU;
        Menus = new Rect[3];
        Menus[0] = new Rect(Screen.width * 5 / 20, Screen.height * 3 / 20, Screen.width * 10 / 20, Screen.height * 5 / 20);
        Menus[1] = new Rect(Screen.width * 5 / 20, Screen.height * 11 / 20, Screen.width * 10 / 20, Screen.height * 5 / 20);
        Menus[2] = new Rect(Screen.width * 18 / 20, Screen.height * 1 / 20, Screen.height * 3 / 20, Screen.height * 3 / 20);
        US.alignment = TextAnchor.MiddleCenter;
        US.fontSize = Screen.width / 40;
        US.fontStyle = FontStyle.Bold;
        players = this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(0).gameObject;
        items = this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(2).gameObject;
        isSpawn = false;
        spawnCoolDown = 100;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnGUI()
    {
        if (SG == STATUS_GAME.MENU)
        {
            Time.timeScale = 0.0f;
            if (GUI.Button(Menus[0], "Start Game") || Input.GetKeyDown(KeyCode.Space))
            {
                SG = STATUS_GAME.PLAYING;
                this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause") ;
            }
            if (GUI.Button(Menus[1], "End Game"))
            {
                Application.Quit();
            }
        }
        if(SG == STATUS_GAME.PLAYING)
        {
            Time.timeScale = 1.0f;
            if(GUI.Button(Menus[2],"||", US))
            {
                this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                SG = STATUS_GAME.PAUSE;
            }
            if (!isSpawn)
            {
                if (spawnCoolDown > 0)
                {
                    spawnCoolDown -= 1;
                }
                else
                {
                    items.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                    isSpawn = true;
                }
            }
            else
            {
                if (!items.GetComponent<Transform>().GetChild(0).gameObject.activeSelf)
                {
                    isSpawn = false;
                    spawnCoolDown = 100;
                }
            }
        }
        if(SG == STATUS_GAME.PAUSE)
        {
            Time.timeScale = 0.0f;
            if(GUI.Button(Menus[0], "Resume Game"))
            {
                this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                SG = STATUS_GAME.PLAYING;
            }
            if (GUI.Button(Menus[1], "End Game"))
            {
                Application.Quit();
            }
        }
    }
}