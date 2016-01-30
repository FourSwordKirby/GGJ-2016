using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    public static List<Player> Players;
    public static CameraControls Camera;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }

        Camera = GameObject.FindObjectOfType<CameraControls>();
        if (Camera == null)
        {
            Debug.Log("Cannot find camera on the current scene.");
        }

        Players = new List<Player>(GameObject.FindObjectsOfType<Player>());
        if (Players == null)
        {
            Debug.Log("Cannot find players on the current scene.");
        }
    }

    void Start()
    {
    }

    void Update()
    {
        /*ButtonCheck*/
        if (Controls.AInputDown(0))
            Debug.Log("P1 ATTACK");
        if (Controls.BInputDown(0))
            Debug.Log("P1 SPECIAL");
        if (Controls.YInputDown(0))
            Debug.Log("P1 JUMP");
        if (Controls.RInputDown(0))
            Debug.Log("P1 SHIELD");
        if (Controls.LInputDown(0))
            Debug.Log("P1 ENHANCE");
        if (Controls.ZInputDown(0))
            Debug.Log("P1 SUPER");
        if (Controls.pauseInputDown(0))
            Debug.Log("PAUSE");

        if (Controls.AInputDown(1))
            Debug.Log("P2 ATTACK");
        if (Controls.BInputDown(1))
            Debug.Log("P2 SPECIAL");
        if (Controls.YInputDown(1))
            Debug.Log("P2 JUMP");
        if (Controls.RInputDown(1))
            Debug.Log("P2 SHIELD");
        if (Controls.LInputDown(1))
            Debug.Log("P2 ENHANCE");
        if (Controls.ZInputDown(1))
            Debug.Log("P2 SUPER");
        if (Controls.pauseInputDown(1))
            Debug.Log("PAUSE");

        /*Scene Transition*/
        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("hi");
                LoadScene("TitleScene");
            }
        }
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
