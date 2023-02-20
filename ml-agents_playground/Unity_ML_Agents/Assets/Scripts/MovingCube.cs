using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public GameObject target;

    public float distance;
    public Material winning_material;

    private float move_x;
    private float move_z;
    private Vector3 mover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the cube 
        move_x = Input.GetAxis("Horizontal");
        move_z = Input.GetAxis("Vertical");

        mover = new Vector3(move_x, 0, move_z) * 0.25f;

        transform.position = transform.position + mover;
        // alternative way of writting the line above is:
        // tranform.position += mover;


        // measure the distance from the cube to the target
        distance = Vector3.Distance(transform.position, target.transform.position);
    }


    // This functionality will get triggered ONLY when the two colliders bump into each other
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = winning_material;
    }
}
