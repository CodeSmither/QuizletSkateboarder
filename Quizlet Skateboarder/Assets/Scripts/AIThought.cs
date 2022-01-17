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
        Objective = gameController.wordInQuestion2.Substring(gameController.player2spelling.Length,1);
        
        if (RoundPlaying == true)
        {
            agent.SetDestination(GameObject.Find(Objective.ToUpper()).transform.position);
        }
        if (Vector3.zero != agent.velocity.normalized)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
        
    }
}
