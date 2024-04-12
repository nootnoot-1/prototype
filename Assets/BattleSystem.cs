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
        int maxBmIndex = 1;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (bmIndex == 0) {
                SwitchBattleState(BattleState.AttackMenu);
            } else if (bmIndex == 1) {
                //update to ItemMenu
                //change battleState to ItemMenu
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (bmIndex == 0) {
                bmIndex = maxBmIndex;
                battleUI_script.NavigateMenuOptions(bmIndex);
            } else if (bmIndex == 1) {
                --bmIndex;
                battleUI_script.NavigateMenuOptions(bmIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (bmIndex == 0) {
                ++bmIndex;
                battleUI_script.NavigateMenuOptions(bmIndex);
            } else if (bmIndex == maxBmIndex) {
                bmIndex = 0;
                battleUI_script.NavigateMenuOptions(bmIndex);
            }
        }
    }
    void ItemMenuInput() {}
    void AttackMenuInput() {
        int maxAmIndex = player_script.GetAttackNames().Count - 1;
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack attack = player_script.GetAttackAt(amIndex);
            enemy_script.RecieveAttack(attack);
            SwitchBattleState(BattleState.EnemyTurn);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (amIndex == 0) {
                amIndex = maxAmIndex;
                battleUI_script.NavigateMenuOptions(amIndex);
            } else {
                --amIndex;
                battleUI_script.NavigateMenuOptions(amIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (amIndex == maxAmIndex) {
                amIndex = 0;
                battleUI_script.NavigateMenuOptions(amIndex);
            } else {
                ++amIndex;
                battleUI_script.NavigateMenuOptions(amIndex);
            }
        }
    }
    void TargetMenuInput() {}
    void EnemyTurnInput() {
        player_script.RecieveAttack(enemy_script.MakeAttack());
        SwitchBattleState(BattleState.BaseMenu);
    }

    void SwitchBattleState(BattleState newBattleState) {
        battleUI_script.RemoveCurrentMenu();
        if (newBattleState == BattleState.BaseMenu) {
            bmIndex = 0;
            battleUI_script.BuildBaseMenu();
        } else if (newBattleState == BattleState.AttackMenu) {
            amIndex = 0;
            battleUI_script.BuildAttackMenu(player_script.GetAttackNames());
        } else if (newBattleState == BattleState.EnemyTurn) {}
        battleState = newBattleState;
    }

}
