using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
        BuildBaseMenu();
    }

    public void NavigateMenuOptions(int index) {
        menuOptionsEl.Q(className: activeMenuOptionClass).RemoveFromClassList(className: activeMenuOptionClass);
        menuOptionsEl.Query(className: "menu-option").AtIndex(index).AddToClassList(className: activeMenuOptionClass);
    }

    public void UpdatePlayerHealth(int index) {
        healthBarEl.Q(className: "health-bar-fill").style.width = new StyleLength(index);
    }

    public void BuildBaseMenu() {
                // <ui:VisualElement class = "menu-option  menu-option-active">
                //     <ui:Label text = "Attack"/>
                // </ui:VisualElement>
                // <ui:VisualElement class = "menu-option">
                //     <ui:Label text = "Item"/>
                // </ui:VisualElement>
        menuOptionsEl.Add(CreateMenuOption("attack"));
        menuOptionsEl.Query(className: "menu-option").AtIndex(0).AddToClassList(className: activeMenuOptionClass);
        menuOptionsEl.Add(CreateMenuOption("item"));
    }
    private VisualElement CreateMenuOption(string labeltext) {
        VisualElement menuOption = new();
        menuOption.AddToClassList("menu-option");
        Label label = new() { text = labeltext };
        menuOption.Add(label);
        return menuOption;
    }
    public void BuildAttackMenu(List<string> attacknames) {
        foreach (string attackname in attacknames) {
            menuOptionsEl.Add(CreateMenuOption(attackname));
        }
        menuOptionsEl.Query(className: "menu-option").AtIndex(0).AddToClassList(className: activeMenuOptionClass);
    }
    public void BuildEnemyTurnMenu() {
        
    }
    public void RemoveCurrentMenu() {
        for (int i = menuOptionsEl.childCount; i > 0; --i)
        {
            menuOptionsEl.RemoveAt(i-1);
        }
    }

    //update health function
    //navigate battle menu functions (simple, one task, logic for combining these should be in BattleSystem?)

}
