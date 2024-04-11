using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] Player player;
    private Player player_script;
    [SerializeField] Enemy enemy;
    private Enemy enemy_script;
    [SerializeField] BattleUI battleUI;
    private BattleUI battleUI_script;
    enum BattleState {BaseMenu, ItemMenu, AttackMenu, TargetMenu, EnemyTurn}
    private BattleState battleState; 
    private int bmIndex = 0;
    private int imIndex = 0;
    private int amIndex = 0;
    private int tmIndex = 0;
    private int etIndex = 0;

    void OnEnable()
    {
        //can be changed to Gameobject.Find("Player").GetComponent<Player>(); to avoid having to place objects into the serilized field
        enemy_script = enemy.GetComponent<Enemy>();
        player_script = player.GetComponent<Player>();
        battleUI_script = battleUI.GetComponent<BattleUI>();
        battleState = BattleState.BaseMenu;

    }

    void Update()
    {
        switch (battleState) {
            case BattleState.BaseMenu:
                BaseMenuInput();
            break;
            case BattleState.ItemMenu:
                ItemMenuInput();
            break;
            case BattleState.AttackMenu:
                AttackMenuInput();
            break;
            case BattleState.TargetMenu:
                TargetMenuInput();
            break;
            case BattleState.EnemyTurn:
                EnemyTurnInput();
            break;
        }
    }

    void BaseMenuInput(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (bmIndex == 0) {
                //update to AttackMenu
                //change battleState to AttackMenu
                Attack attack = player_script.Punch();
                enemy_script.RecieveAttack(attack);
                Attack enemyAttack = enemy_script.Punch();
                player_script.RecieveAttack(enemyAttack);
            } else if (bmIndex == 1) {
                //update to ItemMenu
                //change battleState to ItemMenu
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (bmIndex == 0) {
                // do nothing aka. going left on furthest left element will not go to the furthest right element yet
            } else if (bmIndex == 1) {
                --bmIndex;
                battleUI_script.NavigateMenuOptions(bmIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (bmIndex == 0) {
                ++bmIndex;
                battleUI_script.NavigateMenuOptions(bmIndex);
            } else if (bmIndex == 1) {
                // do nothing aka. going right on furthest right element will not go to the furthest left element yet
            }
        }
    }
    void ItemMenuInput(){}
    void AttackMenuInput(){}
    void TargetMenuInput(){}
    void EnemyTurnInput(){}

}
