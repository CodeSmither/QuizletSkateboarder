using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIThought : MonoBehaviour
{
    
    private NavMeshAgent agent;
    private GameController gameController;
    bool RoundPlaying = true;
    private string Objective = "E";
    private string CurrentObjective;
    [SerializeField] private GameObject[] Ramps;
    [SerializeField] private GameObject[] TrickSpots;
    [SerializeField] private GameObject[] GrindRailSpots;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        gameController = GameObject.Find("GameManger").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (RoundPlaying == true)
        {
            switch (CurrentObjective)
            {
                case "Ramp":
                    int rdnumber = Random.Range(0,Ramps.Length);
                    Vector3 dest = Ramps[rdnumber].transform.position;
                    if (dest != null)
                    {
                        agent.SetDestination(dest);
                    }
                    break;
                case "Trick":
                    int rdnumber2 = Random.Range(0,TrickSpots.Length);
                    Vector3 dest2 = TrickSpots[rdnumber2].transform.position;
                    if (dest2 != null)
                    {
                        agent.SetDestination(dest2);
                    }
                    break;

                case "Grind":
                    int rdnumber3 = Random.Range(0,GrindRailSpots.Length);
                    Vector3 dest3 = GrindRailSpots[rdnumber3].transform.position;
                    if (dest3 != null)
                    {
                        agent.SetDestination(dest3);
                    }
                    break;

                case "Objective":
                    Objective = gameController.wordInQuestion2.Substring(gameController.player2spelling.Length, 1);
                    if (Objective != null)
                    {
                        agent.SetDestination(GameObject.Find(Objective.ToUpper()).transform.position);
                    }
                    break;
                default:
                    break;
            }
            
        }
        if (Vector3.zero != agent.velocity.normalized)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
        
    }
}
