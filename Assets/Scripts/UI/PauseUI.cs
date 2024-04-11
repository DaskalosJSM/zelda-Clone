using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI : MonoBehaviour
{
    public GameManager gameManagerOb;
   
    void Start()
    {
        gameManagerOb = this.GetComponent<GameManager>();
    }
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonMenu = root.Q<Button>("MenuButton");
        Button buttonContinue = root.Q<Button>("ContinueButton");
   
        buttonMenu.clicked += () => Menu();
        buttonContinue.clicked += () => Continue() ;
     }

    void Menu() 
    {
        gameObject.SetActive(false);
        gameManagerOb.PrincipalMenu();
    }
    void Continue() 
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
