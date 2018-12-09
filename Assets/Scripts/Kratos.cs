using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Kratos : MonoBehaviour
{
    public int healthPoints;
    public int maxHealthPoints;
    public int attackDamage;
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
        attackDamage = 10;
    }

    public void refillHealth(){
        this.healthPoints = this.maxHealthPoints;
    }

    //Types:
    //0 = Health, 1 = Movement, 2 = Attack
    public void upgradeSkill(int type){
        upgrades[level-2] = type;
        switch(type){
            case 0: maxHealthPoints = (int)(1.1 * maxHealthPoints); healthPoints = maxHealthPoints; break;
            case 1: KratosController.movementSpeed *= 1.1f; break;
            case 2: attackDamage = (int)(1.1 * attackDamage); break;
        }
    }

    public void getExp(int exp){
        experience += exp;
        int maxExp = 500 * 2 ^ (level - 1);
        if (experience >= maxExp){
            experience = experience - maxExp;
            level++;
            skillPoints++;
        }
    }
}