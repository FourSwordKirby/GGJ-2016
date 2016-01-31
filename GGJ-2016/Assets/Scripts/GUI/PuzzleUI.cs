using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour {

    public int PlayerNumber = 1;

    private Text timerText;
    private Animator anim;

    void Start()
    {
        timerText = this.transform.FindChild("TimerUI").GetComponent<Text>();
        anim = this.transform.FindChild("Result").GetComponent<Animator>();
    }

    public void SetTime(float time)
    {
        timerText.text = "" + time;
    }

    public void PlaySuccessAnimation()
    {
        anim.SetTrigger("Success");
    }

    public void PlayFailAnimation()
    {
        anim.SetTrigger("Fail");
    }

    public void StopResultAnimation()
    {
        anim.SetTrigger("None");
    }
}
