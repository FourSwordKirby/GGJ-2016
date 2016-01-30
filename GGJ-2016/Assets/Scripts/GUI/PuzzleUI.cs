using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour {

    public int PlayerNumber = 1;

    private PuzzleManager manager;
    private Text timerText;

    void Start()
    {
        manager = GameObject.FindObjectOfType<PuzzleManager>();
        timerText = this.transform.FindChild("TimerUI").GetComponent<Text>();
    }

    void Update()
    {
        timerText.text = "" + manager.TimeRemaining;
    }
}
