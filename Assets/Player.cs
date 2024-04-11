using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] BattleUI battleUI;
    private BattleUI battleUI_script;

    //STATS
    [SerializeField] int maxHealth = 40;
    [SerializeField] int currentHealth = 30;
    [SerializeField] int attackStat = 10;
    [SerializeField] int defenseStat = 2;

    void OnEnable()
    {
        battleUI_script = battleUI.GetComponent<BattleUI>();
    }

    //functions that return moveclass
    //function that recieves moveclass
    public Attack Punch() {
        Attack punch = ScriptableObject.CreateInstance<Attack>();
        punch.setAttackValue(attackStat);
        Debug.Log("Player punched for a value of: " + attackStat + "!");
        return punch;
    }

    public void RecieveAttack(Attack attack) {
        int damage = attack.getAttackValue() - defenseStat;
        if (damage > 0) {
            currentHealth -= damage;
        }
        Debug.Log("Player took " + damage + " damage!");
        Debug.Log("Player has " + currentHealth + " health");
        battleUI_script.UpdatePlayerHealth(CalcHealthBarPixels());

    }

    private int CalcHealthBarPixels() {
        float currenth = currentHealth;
        float maxh = maxHealth;
        float percent = currenth / maxh;
        return (int)(percent * 640);
    }


}
