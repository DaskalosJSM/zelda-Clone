using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image healthBar;
    public float MaxHealt;
    public float CurrentHealth;
    public EnemyStatistics Enemystats;
    public EnemyStateMachine Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHealt = Enemystats._maxHealth;
        CurrentHealth = Enemy._Health;
        healthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}
