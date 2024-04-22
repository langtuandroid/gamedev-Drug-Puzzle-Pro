using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("For any Queries Contact Us Gmail id: dollar99games@gmail.com ")]
    [Header("For any Queries Contact Us Skyid: dollar99games@outlook.com ")]
    [SerializeField]
    public string Contact_us_on_Gmail = "dollar99games@gmail.com";
    public string Contact_us_on_Skype = "dollar99games@outlook.com";


    public AudioSource _As;
    public static soundmanager instance;
    public AudioClip levelcomplete, pick, drop, start,movetostartposition,smallwin,cashsound;



    void Start()
    {
        if (instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        playmysound(start);
    }

    // Update is called once per frame
    public void playmysound(AudioClip sound)
    {
        _As.PlayOneShot(sound);
    }
}
