using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEl;
    private VisualElement menuOptionsEl;
    private VisualElement healthBarEl;
    private string activeMenuOptionClass = "menu-option-active";

    void OnEnable()
    {
        rootEl = uiDoc.rootVisualElement;
        menuOptionsEl = rootEl.Q(className: "menu-options");
        healthBarEl = rootEl.Q(className: "health-bar");
    }

    public void NavigateMenuOptions(int index) {
        menuOptionsEl.Q(className: activeMenuOptionClass).RemoveFromClassList(className: activeMenuOptionClass);
        menuOptionsEl.Query(className: "menu-option").AtIndex(index).AddToClassList(className: activeMenuOptionClass);
    }

    public void UpdatePlayerHealth(int index) {
        healthBarEl.Q(className: "health-bar-fill").style.width = new StyleLength(index);
    }

    public void BuildBaseMenu() {

    }
    public void BuildAttackItemMenu() {

    }
    public void BuildEnemyTurnMenu() {
        
    }

    //update health function
    //navigate battle menu functions (simple, one task, logic for combining these should be in BattleSystem?)

}
