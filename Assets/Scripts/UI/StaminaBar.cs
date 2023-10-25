using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image healthBar;
    private float Maxstamina;
    private float CurrentStamina;
    public playerStatistics Player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Maxstamina = Player.MaxStamina;
        CurrentStamina = Player.Stamina;
        healthBar.fillAmount = CurrentStamina / Maxstamina;
    }
}