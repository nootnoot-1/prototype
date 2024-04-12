using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    private string attackName;
    private int attackValue;

    public void BuildAttack(string name, int attackValue) {
        this.attackName = name;
        this.attackValue = attackValue;
    }

    public string GetName() {
        return this.attackName;
    }
    public int GetAttackValue() {
        return this.attackValue;
    }
}
