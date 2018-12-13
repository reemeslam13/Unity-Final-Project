using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_sound : MonoBehaviour {
    public Button effect,music,speech;
    public Button effect_on, music_on, speech_on;
    public static bool mute_sound_1;
    public  static bool mute_sound_2 ;
    public static bool mute_sound_3 ;
    // Use this for initialization
    void Start()
    {
        mute_sound_1 = true;
        mute_sound_2= true;
        mute_sound_3 = true;
        effect.onClick.AddListener(TaskOnClick_1);
        music.onClick.AddListener(TaskOnClick_2);
        speech.onClick.AddListener(TaskOnClick_3);

        effect_on.onClick.AddListener(TaskOnClick_4);
        music_on.onClick.AddListener(TaskOnClick_5);
        speech_on.onClick.AddListener(TaskOnClick_6);
    }
public void TaskOnClick_1()
{

        mute_sound_1 = false;
        effect.gameObject.SetActive(false);
        effect_on.gameObject.SetActive(true);
    }
    public void TaskOnClick_2()
    {

        mute_sound_2 = false;
        music.gameObject.SetActive(false);
        music_on.gameObject.SetActive(true);
    }
    public void TaskOnClick_3()
    {

        mute_sound_3 = false;
        speech.gameObject.SetActive(false);
        speech_on.gameObject.SetActive(true);
    }
    public void TaskOnClick_4()
    {

        mute_sound_1 = true;
        effect.gameObject.SetActive(true);
        effect_on.gameObject.SetActive(false);

    }
    public void TaskOnClick_5()
    {

        mute_sound_2 = true;
        music.gameObject.SetActive(true);
        music_on.gameObject.SetActive(false);
    }
    public void TaskOnClick_6()
    {

        mute_sound_3 = true;
        speech.gameObject.SetActive(true);
        speech_on.gameObject.SetActive(false);
    }

















    //effect sound
    public static bool getMute_1()
    {
        return mute_sound_1;
    }
    //music sound
    public  static bool getMute_2()
    {
        return mute_sound_2;
    }
    //speech sound
    public static bool getMute_3()
    {
        return mute_sound_3;
    }

}
