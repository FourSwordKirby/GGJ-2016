using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {

    public Sprite ButtonA;
    public Sprite ButtonB;
    public Sprite JoyUp;
    public Sprite JoyRight;
    public Sprite JoyDown;
    public Sprite JoyLeft;

    private Animator anim;
    private SpriteRenderer inputSprite;

    void Start()
    {
        Init();
    }

	// Use this for initialization
	public void Init()
    {
        anim = GetComponent<Animator>();
        inputSprite = this.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }
	
    public void Display(char letter)
    {
        switch(letter)
        {
            case 'A':
                inputSprite.sprite = ButtonA;
                break;
            case 'B':
                inputSprite.sprite = ButtonB;
                break;
            case 'L':
                inputSprite.sprite = JoyLeft;
                break;
            case 'R':
                inputSprite.sprite = JoyRight;
                break;
            case 'U':
                inputSprite.sprite = JoyUp;
                break;
            case 'D':
                inputSprite.sprite = JoyDown;
                break;
        }
        anim.SetBool("Hidden", false);
    }

    public void Hide()
    {
        anim.SetBool("Hidden", true);
    }
}
