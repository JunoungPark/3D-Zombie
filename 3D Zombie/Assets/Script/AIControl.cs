using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] int count;
    [SerializeField] Transform[] wayPoint;
    public int health;

    private Transform tempPoint = null;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            agent.speed = 0;
            CancelInvoke();
            animator.Play("mixamo_com");
            Destroy(gameObject, 3);
        }

    }
    public void SetTarget(Transform newTarget)
    {
        CancelInvoke();
        tempPoint = newTarget;
    }
    public void RemoveTarget()
    {
        tempPoint = null;
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }
    public void MoveNext()
    {
        if (agent.velocity == Vector3.zero)
        {
            agent.SetDestination(wayPoint[count++].position);
            if (count >= wayPoint.Length)
            {
                count = 0;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            SetTarget(other.transform);
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            transform.LookAt(other.transform);
            agent.SetDestination(tempPoint.position);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            RemoveTarget();
        }
    }

}
