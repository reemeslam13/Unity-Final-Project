using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
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

    public ProgressBar progressBar;
    public ProgressBar rageBar;
    public Text skillPointText;
    public Text levelText;
    public Text expText;


    public void Start(){
        upgrades = new List<int>();
        healthPoints = 100;
        maxHealthPoints = 100;
        level = 1;
        levelText.text = "Level 1";
        skillPoints = 0;
        experience = 0;
        attackDamage = 10;
        rage = 0;
        maxRage = 100;
        skillPointText.text = "SP: " + skillPoints;
    }

    public void refillHealth(){
        this.healthPoints = this.maxHealthPoints;
    }

    void Update()
    {
        rageBar.BarValue = rage;
        progressBar.BarValue = (int)(((double)healthPoints/(double)maxHealthPoints)*100);
        levelText.text = "Level " + level;
        skillPointText.text = "SP: " + skillPoints;
        expText.text = "XP: " + experience + "/" + (500 * (Math.Pow(2, level - 1)));
    }

    //Types:
    //0 = Health, 1 = Movement, 2 = Attack
    public void upgradeSkill(int type){
        if(skillPoints > 0){
            skillPoints--;
            upgrades[level-2] = type;
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
        int maxExp = 500 * 2 ^ (level - 1);
        if (experience >= maxExp){
            experience = experience - maxExp;
            level++;
            skillPoints++;
        }
    }
}