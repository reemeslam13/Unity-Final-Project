using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public string sceneName;
 
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
  

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
    }

    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
      

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

      
       
    }

    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);

        //Set Player Prefs
        PlayerPrefs.SetInt("maxhp", 100);
        PlayerPrefs.SetInt("xp", 0);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("sp", 0);
        PlayerPrefs.SetInt("rage", 0);
        PlayerPrefs.SetInt("attack", 10);

        SceneManager.LoadScene(sceneName); //change it with the scene you want
        
    }

    public void openOptions_Game()
    {
        //enable respective panel
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
       
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

       
    }
    public void openOptions_Controls()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
      

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

     

    }
    public void openOptions_Gfx()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
      

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");


    }

   

    
    #endregion

    #region Back Buttons

    public void back_options()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");

        //disable BLUR
       // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");
        
        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
       
    }

    void playClickSound() {

    }


    #endregion
}
