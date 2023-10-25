using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyStatistics", order = 2)]
public class EnemyStatistics : ScriptableObject
{

    [Header("Variables")]
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float timeBetweenAttacks;

    [SerializeField]
    private float damagePlayer;

    [SerializeField]
    private float Trusth;

    [SerializeField]
    private float RewardCuantity;


    [SerializeField]
    private float WalkPointRange;

    [SerializeField]
    private float SigthRange;

    [SerializeField]
    private float AttacRange;

    public float _maxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float _timeBetweenAttacks { get { return timeBetweenAttacks; } set { timeBetweenAttacks = value; } }
    public float _damagePlayer { get { return damagePlayer; } set { damagePlayer = value; } }
    public float _Trusth { get { return Trusth; } set { Trusth = value; } }
    public float _RewardCuantity { get { return RewardCuantity; } set { RewardCuantity = value; } }
    public float _WalkPointRange { get { return WalkPointRange; } set { WalkPointRange = value; } }
    public float _SigthRange { get { return SigthRange; } set { SigthRange = value; } }
    public float _AttacRange { get { return AttacRange; } set { AttacRange = value; } }

    [Header("GameObjects")]
    public GameObject PrefabReward;
}
