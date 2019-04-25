using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public GameManager gm;
    // public float speed;
    public Transform player;
    private NavMeshAgent agent;
    public Animator anim;
    public float normalMoveSpeed;
    public float sprintSpeed;
    // Use this for initialization
    void Start()
    {
        //agent.speed = normalMoveSpeed;
        anim = GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.ForescytheChecker == true)
        {
            anim.SetBool("isForeScytheOn", gm.ForescytheChecker);
            //agent.speed = agent.speed+sprintSpeed;
        }
        else if (gm.ForescytheChecker == false)
        {
            anim.SetBool("isForeScytheOn", gm.ForescytheChecker);
            //agent.speed = agent.speed-sprintSpeed;
        }

        agent.SetDestination(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LoseState");

        }

    }
}