using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    [SerializeField]
    private Transform tf;
    public float speed;
   // public Transform target;
    private GameObject ob;
    //calls the ForeScythe script
    public ForeScythe fs;
    private int playercount;
    private int AIcount;
    public Text countText;
    public Text AIcountText;
    private NavMeshAgent agent;
    private GameObject goal;
    private TrailRenderer Trail;
    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        Trail = GetComponent<TrailRenderer>();
        playercount = 0;
        AIcount = 0;
        SetCountText();
        SetAICountText();
    }
	
	// allows the player to move while Forescythe is not active basic WASD movement
	void Update () {
        goal = GameObject.FindGameObjectWithTag("Goal");
        //FindClosestCoin();
        float step = speed * Time.deltaTime;
        //if ForeSycthe is not active able to control the character
        if(fs.foreScytheOn==false){
            
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 movement = new Vector3(0, 0, 1);
                tf.Translate(movement * Time.deltaTime, Space.World);

            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 movement = new Vector3(0, 0, -1);
                tf.Translate(movement * Time.deltaTime, Space.World);

            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 movement = new Vector3(-1, 0, 0);
                tf.Translate(movement * Time.deltaTime, Space.World);

            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 movement = new Vector3(1, 0, 0);
                tf.Translate(movement * Time.deltaTime, Space.World);

            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                //fs.Forescythe();
                fs.StartCoroutine("Forescythe");
            }
            Trail.enabled = false;
        }//if ForeScythe is active can't control character and AI is in control
        else if (fs.foreScytheOn == true)
        {//PLACEHOLDER the actual AI script will be more than this 
         //Vector3 movement = new Vector3( 1, 0, 0);
         //tf.Translate(movement * Time.deltaTime, Space.World);

            // tf.position = Vector3.MoveTowards(tf.position, ob.transform.position, step);
            Trail.enabled = true;
            agent.isStopped = false;
            agent.SetDestination(goal.transform.position);
            
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            if (fs.foreScytheOn == false)
            {
                playercount = playercount + 1;
                SetCountText();
            }
            else if (fs.foreScytheOn == true)
            {
                AIcount = AIcount + 1;
                SetAICountText();
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Player Count: " + playercount.ToString();
    }

    void SetAICountText()
    {
        AIcountText.text = "AI Count: " + AIcount.ToString();
    }

   // public void FindClosestCoin()
   // {
  //      GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag("Coin");
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;
      //  Vector3 position = tf.position;
    //    foreach (GameObject go in gos)
     //   {
      //      Vector3 diff = go.transform.position - position;
      //      float curDistance = diff.sqrMagnitude;
      //      if (curDistance < distance)
      //      {
       //         closest = go;
       //         distance = curDistance;
       //         ob = closest;
       //     }
      //  }
        
   // }

}
