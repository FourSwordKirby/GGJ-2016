using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour {

    public Image BlankImage;
    public Sprite ButtonA;
    public Sprite ButtonB;
    public Sprite JoyUp;
    public Sprite JoyRight;
    public Sprite JoyDown;
    public Sprite JoyLeft;

    public int PlayerNumber = 1;

    private Text timerText;
    private Animator anim;
    private RectTransform controls;
    private Text instr;
    private Heart[] hearts;

    void Start()
    {
        timerText = this.transform.FindChild("TimerUI").GetComponent<Text>();
        anim = this.transform.FindChild("Result").GetComponent<Animator>();
        controls = this.transform.FindChild("Controls").GetComponent<RectTransform>();
        instr = this.transform.FindChild("Instructions").GetComponent<Text>();
    }

    public void SetTime(float time)
    {
        timerText.text = "" + time;
    }

    public void SetInstructions(string str)
    {
        instr.text = str;
    }

    public void SetControls(string str)
    {
        foreach (Transform t in controls.transform)
        {
            Destroy(t.gameObject);
        }
        float width = controls.rect.width;
        float spacing = width / str.Length;
        float startX = -width / 2 + spacing / 2;
        for (int i = 0; i < str.Length; ++i)
        {
            Image im = Instantiate<Image>(BlankImage);
            im.sprite = PickSprite(str[i]);
            im.transform.SetParent(controls, false);
            im.transform.SetSiblingIndex(i);
            im.GetComponent<RectTransform>().anchoredPosition = new Vector3(startX + i * spacing, 0.0f, 0.0f);
        }
    }

    private Sprite PickSprite(char letter)
    {
        switch (letter)
        {
            case 'A':
                return ButtonA;
            case 'B':
                return ButtonB;
            case 'L':
                return JoyLeft;
            case 'R':
                return JoyRight;
            case 'U':
                return JoyUp;
            case 'D':
                return JoyDown;
        }
        return ButtonA;
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
