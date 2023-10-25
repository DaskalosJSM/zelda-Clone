using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyStateMachine : MonoBehaviour
{
    EnemyBaseState _currentState;
    EnemyStateFactory _States;

    //Variables

    [Header("References")]
    public EnemyStatistics Enemy;
    public GameObject HitBox;
    [SerializeField] private Transform Player;

    [Header("Animations")]
    [SerializeField] private Rig _Rigging;
    [SerializeField] private Animator Animations;

    [Header("Enemy Mode")]
    [SerializeField] private bool CanbeHurt;

    [Header("Enemy Stats")]
    [SerializeField] private float health;
    [SerializeField] private bool IsHurt;
    private Rigidbody rb;

    [Header("Attacking")]
    [SerializeField] private bool alreadyAttacked;
    private UnityEngine.AI.NavMeshAgent agent;

    [Header("NavMesh Elements")]
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrolling")]
    private Vector3 walkPoint;
    private bool walkPointSet;
    private bool playerInSightRange, playerInAttackRange;

    // Get & Sets
    public float _Health { get { return health; } set { health = value; } }
    public Rigidbody _RigidBody { get { return rb; } set { rb = value; } }
    public Transform _Player { get { return Player; } set { Player = value; } }
    public Animator _Animations { get { return Animations; } set { Animations = value; } }
    public Rig Rigging { get { return _Rigging; } set { _Rigging = value; } }
    public bool _IsHurt { get { return IsHurt; } set { IsHurt = value; } }
    public bool _alreadyAttacked { get { return alreadyAttacked; } set { alreadyAttacked = value; } }
    public UnityEngine.AI.NavMeshAgent _agent { get { return agent; } set { agent = value; } }
    public LayerMask _whatIsGround { get { return whatIsGround; } set { whatIsGround = value; } }
    public LayerMask _whatIsPlayer { get { return whatIsPlayer; } set { whatIsPlayer = value; } }
    public Vector3 _walkPoint { get { return walkPoint; } set { walkPoint = value; } }
    public bool _walkPointSet { get { return walkPointSet; } set { walkPointSet = value; } }
    public bool _playerInSightRange { get { return playerInSightRange; } set { playerInSightRange = value; } }
    public bool _playerInAttackRange { get { return playerInAttackRange; } set { playerInAttackRange = value; } }

    // CurrenState Get & Set
    public EnemyBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    // Corrutinas
    private Coroutine randomNumberCoroutine;
    public int AttackIndex;
    private void Awake()
    {
        _States = new EnemyStateFactory(this);
        _currentState = _States.Patrol();
        _currentState.EnterState();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animations = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
       // _Player = GameObject.Find("Player").GetComponent<Transform>();
        health = Enemy._maxHealth;
        Rigging.weight = 0f;
    }
    private void Update()
    {
        //Check for sight and attack range
        //Debug.Log(_currentState);
        playerInSightRange = Physics.CheckSphere(transform.position, Enemy._SigthRange, whatIsPlayer);
        if (!playerInSightRange) { Rigging.weight = 0f; }
        playerInAttackRange = Physics.CheckSphere(transform.position, Enemy._AttacRange, whatIsPlayer);

    }
    private void FixedUpdate()
    {
        _currentState.UpdateState();
        //        Debug.Log(CurrentState);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Enemy._AttacRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Enemy._SigthRange);
    }
    public void TakeDamage(float damage, float trhustPotenciator)
    {
        _Rigging.weight = 0;
        _agent.ResetPath();
        IsHurt = true;
        rb.AddForce(-transform.forward * Enemy._Trusth * trhustPotenciator, ForceMode.Impulse);
        Invoke("IsNotHurt", 3.0f);
        if (CanbeHurt)
        {
            _Health -= damage;
            if (_Health <= 0)
            {
                DeadEnemy();
            }
        }
    }
    public void DeadEnemy()
    {
        _currentState = _States.Die();
        _Rigging.weight = 0;
        StartCoroutine(DeadEnemyCorroutine(4));
    }
    public void DeactivateHitBox()
    {
        HitBox.SetActive(false);
    }
    public void ResetAttack()
    {
        _alreadyAttacked = false;
    }
    public void Invocation()
    {
        Invoke(nameof(ResetAttack), Enemy._timeBetweenAttacks);
    }
    public void IsNotHurt()
    {
        IsHurt = false;
    }
    public void ActivateRandomNumberCoroutine()
    {
        StartRandomNumberCoroutine();
    }
    public void DeactivateRandomNumberCoroutine()
    {
        StopCoroutine(randomNumberCoroutine);
    }
    private void StartRandomNumberCoroutine()
    {
        if (randomNumberCoroutine != null)
        {
            StopCoroutine(randomNumberCoroutine);
        }
        randomNumberCoroutine = StartCoroutine(RandomNumberGenerator());
    }

    private IEnumerator RandomNumberGenerator()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, 5);
            AttackIndex = randomNumber;
            yield return new WaitForSeconds(4f);
        }
    }
    private IEnumerator DeadEnemyCorroutine(int delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < Enemy._RewardCuantity; i++)
        {
            Vector3 posInicial = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(0f, 2f), transform.position.z + Random.Range(-2f, 2f));
            Instantiate(Enemy.PrefabReward, posInicial, Quaternion.identity);
            Enemy.PrefabReward.GetComponent<Rigidbody>().AddForce(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f), ForceMode.Impulse);
        }
        Destroy(this.gameObject);
    }
}