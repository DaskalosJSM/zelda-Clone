using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/playerStatistics", order = 1)]
public class playerStatistics : ScriptableObject
{
    public float Health;
    public float MaxHealth;
    public float MaxStamina;
    public float Stamina;
    private GameObject Player;
    private int lostScene;
}
