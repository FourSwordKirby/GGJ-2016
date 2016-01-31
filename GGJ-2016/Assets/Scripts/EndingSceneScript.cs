using UnityEngine;
using System.Collections;

public class EndingSceneScript : MonoBehaviour {

    private int state = 0;
    private float timer;

    public bool good;
    public GameObject cut1;
    public GameObject cut2;
    public GameObject prompt;
    private AudioSource audio;

    void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        TransitionManager.Instance.FadeToEmpty(() => state++);
        cut1.SetActive(true);
        cut2.SetActive(false);
        prompt.SetActive(false);
    }

    // Update is called once per frame
	void Update ()
    {
        if(state == 0)
        {
            // do nothing
        }
        else if (state == 1)
        {
            timer = 5.0f;
            state++;
        }
        else if (state == 2)
        {
            timer -= Time.deltaTime;
            if(timer <= 0.0f
                || Controls.AInputDown(0) || Controls.AInputDown(1) ||
                Controls.BInputDown(0) || Controls.BInputDown(1))
            {
                state++;
                if(good)
                {
                    TransitionManager.Instance.FadeToWhite(() =>
                    {
                        cut1.SetActive(false);
                        cut2.SetActive(true);
                        state++;
                    });
                }
                else
                {
                    TransitionManager.Instance.FadeToDark(() =>
                    {
                        cut1.SetActive(false);
                        cut2.SetActive(true);
                        state++;
                    });
                }
            }
        }
        else if (state == 3)
        {
            // Wait
        }
        else if (state == 4)
        {
            TransitionManager.Instance.FadeToEmpty(() => state++);
            state++;
        }
        else if (state == 5)
        {
            // Wait
        }
        else if (state == 6)
        {
            audio.Play();
            timer = 5.0f;
            state++;
        }
        else if (state == 7)
        {
            timer -= Time.deltaTime;
            if(timer < 0.0f)
            {
                prompt.SetActive(true);
                state++;
            }
        }
        else if (state == 8)
        {
            if(Controls.AInputDown(0) || Controls.AInputDown(1) ||
                Controls.BInputDown(0) || Controls.BInputDown(1))
            {
                state++;
                if(good)
                {
                    TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("IntroScene"));
                }
                else
                {
                    TransitionManager.Instance.FadeToDark(() => Application.LoadLevel("IntroScene"));
                }
            }
        }
        
	}
}
