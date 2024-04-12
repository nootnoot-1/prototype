using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //STATS
    [SerializeField] int maxHealth = 25;
    [SerializeField] int currentHealth = 25;
    [SerializeField] int attackStat = 6;
    [SerializeField] int defenseStat = 2;

    public Attack MakeAttack() {
        Attack punch = ScriptableObject.CreateInstance<Attack>();
        punch.BuildAttack("punch", attackStat);
        Debug.Log("Enemy punched for a value of: " + attackStat + "!");
        return punch;
    }

    public void RecieveAttack(Attack attack) {
        int damage = attack.GetAttackValue() - defenseStat;
        if (damage > 0) {
            currentHealth -= damage;
        }
        Debug.Log("Enemy took " + damage + " damage!");
        Debug.Log("Enemy has " + currentHealth + " health");
    }
}
