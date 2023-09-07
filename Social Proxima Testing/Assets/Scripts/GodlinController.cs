using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GodlinController : MonoBehaviour
{
    // variables
    public NavMeshAgent agent;
    public float speedWalk = 3;
    public LayerMask playerMask;
    public float viewRadius = 15;
    Vector3 target;
    public Transform Player;

    Animator Animator;

    public Transform[] WayPoints;
    int WayPointIndex;

    float timer = 0.0f;

    void Start()
    {
        Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speedWalk;

        UpdateDestination();
    }

    void Update()
    {
        EnviromentView();
        timer += Time.deltaTime;
        Debug.Log((Vector3.Distance(agent.transform.position, Player.transform.position)));
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWayPointIndex();
            Animator.SetFloat("Speed", 0.0f);
            Animator.SetBool("greet", false);
        }
        if (timer >= 30.0f)
        {
            timer = 0.0f;
            Animator.SetBool("greet", false);
            UpdateDestination();
        }
        if ((Vector3.Distance(agent.transform.position, Player.transform.position)) < 12.0f && (Vector3.Distance(agent.transform.position, Player.transform.position)) > 3.0f)
        {
            agent.transform.LookAt(Player.transform.position);
            Animator.SetBool("greet", true);
        }
    }

    void UpdateDestination()
    {
        target = WayPoints[WayPointIndex].position;
        agent.SetDestination(target);
        agent.transform.LookAt(target);
        Animator.SetFloat("Speed", Mathf.Abs(agent.speed/agent.speed));
    }
    void IterateWayPointIndex()
    {
        WayPointIndex++;
        if (WayPointIndex == WayPoints.Length)
        {
            WayPointIndex = 0;
        }
    }
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
    }
}
