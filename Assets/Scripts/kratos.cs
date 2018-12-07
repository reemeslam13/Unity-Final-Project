using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kratos : MonoBehaviour
{
    public int healthPoints;
    public int maxHealthPoints;
    public int fury;
    public int maxFury;
    public int level;
    public int experience;
    public int skillPoints;
    public List<int> upgrades;

    public void Start(){
        upgrades = new List<int>();
        healthPoints = 100;
        maxHealthPoints = 100;
        fury = 0;
        maxFury = 100;
        level = 1;
        experience = 0;
    }

    public void refillHealth(){
        this.healthPoints = this.maxHealthPoints;
    }

    //Types:
    //0 = Health, 1 = Movement, 2 = Attack
    public void upgradeSkill(int type){
        upgrades[level-2] = type;
    }
}