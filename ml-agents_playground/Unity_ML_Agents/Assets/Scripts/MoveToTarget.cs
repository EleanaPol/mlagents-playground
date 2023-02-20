using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random = UnityEngine.Random;

public class MoveToTarget : Agent
{
    public List<GameObject> alphabet;
    public GameObject other_agent;
    public GameObject obstacle;
    public GameObject target;
    public GameObject ground;
    public BoxCollider agent_gen_region;
    public BoxCollider target_gen_region;

    public Material win_mat;
    public Material lose_mat;
    public Material agent_main;
    public Material agent_collided;
    public TrailRenderer trail;
    
    private float move_x;
    private float move_z;

    private Vector3 mover;
    private float distance;
    public int counter;

    public override void OnEpisodeBegin()
    {
        counter = 0;
        transform.GetComponent<MeshRenderer>().material = agent_main;
        
        // Reposition our agent in a random place withing the agent generation region
        float random_x = Random.Range(agent_gen_region.bounds.min.x, agent_gen_region.bounds.max.x);
        float random_z = Random.Range(agent_gen_region.bounds.min.z, agent_gen_region.bounds.max.z);

        Vector3 random_position = new Vector3(random_x, 0.5f, random_z);
        transform.position = random_position;
        
        // Reposition our target in a random place withing the target generation region
        float random_tx = Random.Range(target_gen_region.bounds.min.x, target_gen_region.bounds.max.x);
        float random_tz = Random.Range(target_gen_region.bounds.min.z, target_gen_region.bounds.max.z);

        Vector3 random_target_position = new Vector3(random_tx, 0.1f, random_tz);
        target.transform.position = random_target_position;
        
        // Reposition our obstacle in a random place withing the target generation region
        float random_ox = Random.Range(target_gen_region.bounds.min.x, target_gen_region.bounds.max.x);
        float random_oz = Random.Range(target_gen_region.bounds.min.z, target_gen_region.bounds.max.z);

        Vector3 random_obstacle_position = new Vector3(random_ox, 0, random_oz);
        obstacle.transform.position = random_obstacle_position;
        
        trail.Clear();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.transform.localPosition);
        sensor.AddObservation(obstacle.transform.localPosition);
        sensor.AddObservation(other_agent.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        move_x = actions.ContinuousActions[0];
        move_z = actions.ContinuousActions[1];

        mover = new Vector3(move_x, 0, move_z);
        transform.localPosition = transform.localPosition + mover* 0.2f;
        
        AddReward(-0.01f);
        
        // Test that my agent is not too close to the other agent in the scene
        distance = Vector3.Distance(transform.localPosition, other_agent.transform.localPosition);
        if (distance < 1.2f)
        {
            AddReward(-0.1f);
        }
        
        TestAgentHeight();
        counter = counter + 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            AddReward(5f);
            //ground.GetComponent<MeshRenderer>().material = win_mat;
            EndEpisode();
        }
        else if (other.gameObject == obstacle)
        {
            transform.GetComponent<MeshRenderer>().material = agent_collided;
            AddReward(-2f);
        }
    }

    private void TestAgentHeight()
    {
        if (transform.localPosition.y < 0.5f)
        {
            SetReward(-5f);
            //ground.GetComponent<MeshRenderer>().material = lose_mat;
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");
    }
}
