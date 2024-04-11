using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public GameManager gameManagerOb;
   
    void Start()
    {
        gameManagerOb = this.GetComponent<GameManager>();
    }
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("StartButton");
        Button buttonClose = root.Q<Button>("CloseButton");
   
        buttonClose.clicked += () => gameManagerOb.CloseApp();
        buttonStart.clicked += () => StartGame() ;
     }
    
    void StartGame() 
    {
        gameManagerOb.Game();
        gameObject.SetActive(false);
    }
     void CloseApp() 
    {
        gameManagerOb.CloseApp();
    }
     void PauseScreen()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}
