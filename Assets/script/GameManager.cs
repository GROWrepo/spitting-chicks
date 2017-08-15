using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    STATUS_GAME SG;
    Rect[] Menus;
    GUIStyle US = new GUIStyle();
    GameObject players;
    GameObject items;
    GameObject landscapes;
    bool isSpawn;
    int spawnCoolDown;
    int cool;
    public float time;
    bool isDisa;

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
        landscapes = this.gameObject.GetComponent<Transform>().GetChild(0).GetChild(1).gameObject;
        isSpawn = false;
        spawnCoolDown = 100;
        cool = 4;
        time = 4.0f;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnGUI()
    {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("sample")))
        {
            if (SG == STATUS_GAME.MENU)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Start Game") || Input.GetKeyDown(KeyCode.Space))
                {
                    SG = STATUS_GAME.PLAYING;
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.PLAYING)
            {
                Time.timeScale = 1.0f;
                if (GUI.Button(Menus[2], "||", US))
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
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    landscapes.GetComponent<Transform>().GetChild(4).gameObject.SetActive(!landscapes.GetComponent<Transform>().GetChild(4).gameObject.activeSelf);
                    time = cool;
                }
            }
            if (SG == STATUS_GAME.PAUSE)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Resume Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.END)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Restart Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                    SceneManager.LoadScene("sample");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }

            }
        } else if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("background")))
        {
            if (SG == STATUS_GAME.MENU)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Start Game") || Input.GetKeyDown(KeyCode.Space))
                {
                    SG = STATUS_GAME.PLAYING;
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.PLAYING)
            {
                Time.timeScale = 1.0f;
                if (GUI.Button(Menus[2], "||", US))
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
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    landscapes.GetComponent<Transform>().GetChild(4).gameObject.SetActive(!landscapes.GetComponent<Transform>().GetChild(4).gameObject.activeSelf);
                    time = cool;
                }
            }
            if (SG == STATUS_GAME.PAUSE)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Resume Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.END)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Restart Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                    SceneManager.LoadScene("background");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }

            }

        }
        else if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("background 1")))
        {
            if (SG == STATUS_GAME.MENU)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Start Game") || Input.GetKeyDown(KeyCode.Space))
                {
                    SG = STATUS_GAME.PLAYING;
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.PLAYING)
            {
                Time.timeScale = 1.0f;
                if (GUI.Button(Menus[2], "||", US))
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
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    landscapes.GetComponent<Transform>().GetChild(4).gameObject.SetActive(!landscapes.GetComponent<Transform>().GetChild(4).gameObject.activeSelf);
                    time = cool;
                }
            }
            if (SG == STATUS_GAME.PAUSE)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Resume Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }
            }
            if (SG == STATUS_GAME.END)
            {
                Time.timeScale = 0.0f;
                if (GUI.Button(Menus[0], "Restart Game"))
                {
                    this.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(0).SendMessage("pause");
                    SG = STATUS_GAME.PLAYING;
                    SceneManager.LoadScene("background 1");
                }
                if (GUI.Button(Menus[1], "End Game"))
                {
                    Application.Quit();
                }

            }

        }
    }
    private void setStatus(STATUS_GAME newSG)
    {
        SG = newSG;
    }
}
