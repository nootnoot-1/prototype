using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    private int attackValue;

    public void setAttackValue(int value) {
        this.attackValue = value;
    }
    public int getAttackValue() {
        return this.attackValue;
    }
}
