using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIThought : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameController gameController;
    bool RoundPlaying = true;
    public string Objective = null;
    [SerializeField]private string CurrentObjective;
    public GameObject CurrentGameObjective;
    [SerializeField] private GameObject[] Ramps;
    [SerializeField] private GameObject[] TrickSpots;
    private float TimeSincePointEarned = 0;
    private float RandomActivity = 0;
    private bool IfActionEvents;
    private bool Grinding;
    private string spellingWord;
    private string WordtoBeSpelled;
    private bool MovingtoObjective;
    private bool NewObjective;
    private int frames = 0;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentObjective = null;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        gameController = GameObject.Find("GameManger").GetComponent<GameController>();
        Objective = gameController.wordInQuestion2.Substring(gameController.player2spelling.Length, 1);
        TimeForObjective();
        CurrentObjective = "Objective";
        NewObjective = false;
        
    }

    private void TimeForObjective()
    {
        TimeSincePointEarned += 1;
        if (TimeSincePointEarned > 31f)
        {
            TimeSincePointEarned = 0;
        }
        Invoke("TimeForObjective", 1f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        WordtoBeSpelled = gameController.wordInQuestion2;
        spellingWord = gameController.player2spelling;
        int x = spellingWord.Length + 1;
        Objective = gameController.wordInQuestion2.Substring(gameController.player2spelling.Length, 1);
        //Debug.Log(CurrentObjective);
        if (CurrentGameObjective != null)
        {
            Debug.Log(CurrentGameObjective.name);
        }

        if (RoundPlaying == true)
        {
            if (frames % 5 == 0)
            {
                ObjectiveFinder();
            }
        }
        if (Vector3.zero != agent.velocity.normalized && Grinding == false)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
        if (CurrentGameObjective != null)
        {
            Debug.Log(Vector3.Distance(gameObject.transform.position, CurrentGameObjective.transform.position));
        }

        Debug.Log(Objective);
        
    }

    private void ObjectiveFinder()
    {
        if (CurrentObjective == null)
        {
            if (TimeSincePointEarned > 30f)
            {
                CurrentObjective = "Objective";
            }
            else
            {
                int RandObjective = UnityEngine.Random.Range(0, 2);
                switch (RandObjective)
                {
                    case 0:
                        CurrentObjective = "Trick";
                        break;
                    case 1:
                        CurrentObjective = "Ramp";
                        break;
                    default:
                        break;
                }
            }
        }
        if (CurrentGameObjective != null && IfActionEvents == false)
        {
            if (Vector3.Distance(gameObject.transform.position, CurrentGameObjective.transform.position) > 0.4f && MovingtoObjective == false || NewObjective == true)
            {
                switch (CurrentObjective)
                {
                    case "Ramp":
                        int rdnumber = UnityEngine.Random.Range(0, Ramps.Length);
                        Vector3 dest = Ramps[rdnumber].transform.position;
                        //Debug.Log("Dest is: " + dest);
                        if (dest != null)
                        {
                            agent.SetDestination(dest);
                            CurrentGameObjective = Ramps[rdnumber];
                        }
                        NewObjective = false;
                        break;
                    case "Trick":

                        int rdnumber2 = UnityEngine.Random.Range(0, TrickSpots.Length);
                        Vector3 dest2 = TrickSpots[rdnumber2].transform.position;
                        //Debug.Log("Dest2 is: " + dest2);
                        if (dest2 != null)
                        {
                            agent.SetDestination(dest2);
                            CurrentGameObjective = TrickSpots[rdnumber2];
                        }
                        NewObjective = false;
                        break;

                    case "Objective":
                        Objective = gameController.wordInQuestion2.Substring(gameController.player2spelling.Length, 1);
                        if (GameObject.Find(Objective).transform.position != null)
                        {
                            agent.SetDestination(GameObject.Find(Objective).transform.position);
                            CurrentGameObjective = GameObject.Find(Objective.ToUpper());
                        }
                        NewObjective = false;
                        break;
                    default:
                        break;
                }
                MovingtoObjective = true;
            }
            else if(Vector3.Distance(gameObject.transform.position, CurrentGameObjective.transform.position) < 0.4f)
            {
                if (IfActionEvents == false)
                {
                    //Debug.Log("ActionEvents");
                    IfActionEvents = true;
                    StartCoroutine(ActionEvents());
                }
            }
        }
        
    }

    private IEnumerator ActionEvents()
    {
        
        switch (CurrentObjective)
        {
            case "Ramp":
                // Ramp Animation
                yield return new WaitForSeconds(5f);
                break;
            case "Trick":
                // Trick Animation
                yield return new WaitForSeconds(5f);
                break;
            case "Objective":
                TimeSincePointEarned = 0f;
                break;
            default:
                break;
        }
        IfActionEvents = false;
        CurrentObjective = null;
        MovingtoObjective = false;
        NewObjective = true;
    }
}
