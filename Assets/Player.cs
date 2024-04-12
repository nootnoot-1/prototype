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
    private List<Attack> attacks = new();

    void OnEnable()
    {
        battleUI_script = battleUI.GetComponent<BattleUI>();
        LoadAttacks();
    }

    private void LoadAttacks() {
        Attack punch = ScriptableObject.CreateInstance<Attack>();
        punch.BuildAttack("punch", attackStat);
        Attack kick = ScriptableObject.CreateInstance<Attack>();
        kick.BuildAttack("kick", attackStat*2);
        Attack wail = ScriptableObject.CreateInstance<Attack>();
        wail.BuildAttack("wail", 2);
        attacks.Add(punch);
        attacks.Add(kick);
        attacks.Add(wail);
    }

    public List<string> GetAttackNames() { 
        List<string> attackNames = new();
        foreach (Attack attack in attacks) {
            attackNames.Add(attack.GetName());
        }
        return attackNames; 
    }

    //functions that return moveclass
    //function that recieves moveclass
    public Attack GetAttackAt(int index) {
        return attacks[index]; 
    }

    public void RecieveAttack(Attack attack) {
        int damage = attack.GetAttackValue() - defenseStat;
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
