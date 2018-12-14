using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int healthPoints = 100;
    public int maxHealthPoints;
    public int attackDamage;
    public static int level;
    static public int experience;
    static public int skillPoints;
    public List<int> upgrades;
    public static int rage;
    public int maxRage;

    public ProgressBar healthBar;
    public ProgressBar rageBar;
    public Text skillPointText;
    public Text levelText;
    public Text expText;

    public static int wavesCompleted;


    public void Start(){
        upgrades = new List<int>();
        maxHealthPoints = PlayerPrefs.GetInt("maxhp", 100);
        healthPoints = maxHealthPoints;
        experience = PlayerPrefs.GetInt("xp",0);
        level = PlayerPrefs.GetInt("level",1);
        skillPoints = PlayerPrefs.GetInt("sp,0");
        rage = PlayerPrefs.GetInt("rage",0);
        levelText.text = "Level " + level;
        attackDamage = PlayerPrefs.GetInt("attack",10);
        maxRage = 100;
        skillPointText.text = "SP: " + skillPoints;
    }

    public void refillHealth(){
        this.healthPoints = this.maxHealthPoints;
    }

    void Update()
    {
        rageBar.BarValue = rage;
        healthBar.BarValue = (int)(((double)healthPoints/(double)maxHealthPoints)*100);
        levelText.text = "Level " + level;
        skillPointText.text = "SP: " + skillPoints;
        expText.text = "XP: " + experience + "/" + (500 * (Math.Pow(2, level - 1)));

        /* Cheats start   */
        if (Input.GetKeyDown(KeyCode.L))
            lvlUp();

        if (Input.GetKeyDown(KeyCode.H))
            healthPoints = maxHealthPoints;

        if (Input.GetKeyDown(KeyCode.K)) 
            killAllEnemies();

        if (Input.GetKeyDown(KeyCode.E))
            rage = maxRage;

        //print(wavesCompleted

        /* Cheats end */
        if (SceneManager.GetActiveScene().buildIndex == 1 && wavesCompleted != 3) {
            switch (wavesCompleted)
            {
                case 0:
                    if (GameObject.FindGameObjectWithTag("wave1").transform.childCount == 0) {
						GameObject.FindGameObjectWithTag("wall1").GetComponent<Collider>().enabled = false;
						wavesCompleted++;
                    }
                    break;

                case 1:
                    if (GameObject.FindGameObjectWithTag("wave2").transform.childCount == 0) {
						GameObject.FindGameObjectWithTag("wall2").GetComponent<Collider>().enabled = false;
						wavesCompleted++;
                    }
                    break;
                case 2:
                    if (GameObject.FindGameObjectWithTag("wave3").transform.childCount == 0) {
						wavesCompleted++;
                    }
					break;
                default:
                    break;
            }
        }


    }

    void killAllEnemies() {
        new List<GameObject>(GameObject.FindGameObjectsWithTag("erika")).ForEach(obj => Destroy(obj));
        new List<GameObject>(GameObject.FindGameObjectsWithTag("bora3y")).ForEach(obj => Destroy(obj));
        new List<GameObject>(GameObject.FindGameObjectsWithTag("boss")).ForEach(obj => Destroy(obj));

    }

    void lvlUp() {
        level++;
        skillPoints++;
    }

    //Types:
    //0 = Health, 1 = Movement, 2 = Attack
    public void upgradeSkill(int type){
        if(skillPoints > 0){
            skillPoints--;
            //upgrades[level-2] = type;
            switch(type){
                case 0: maxHealthPoints = (int)(1.1 * maxHealthPoints); healthPoints = maxHealthPoints; break;
                case 1: GetComponentInParent<PlayerBehaviour>().movementSpeed *= 1.1f; break;
                case 2: attackDamage = (int)(1.1 * attackDamage); break;
            }
            skillPointText.text = "SP: " + skillPoints;
        }
    }

    public static void getExp(int exp){
        experience += exp;
        int maxExp = (int)(500 * Math.Pow(2,level - 1));
        if (experience >= maxExp){
            experience = experience - maxExp;
            level++;
            skillPoints++;
        }
    }   
}