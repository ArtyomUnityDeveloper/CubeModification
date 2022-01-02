using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float cubeSpeed = 15.0f;
    int objectSizeMax = 8;

    // Targets for cube to move
    public Transform[] targets;
    int targetIndex = 0;
    Vector3 nextTarget;


    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        float step = cubeSpeed * Time.deltaTime;
        int numberOfTargets = targets.Length;


        if (targetIndex <= targets.Length - 1)
        {
            nextTarget = targets[targetIndex].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, nextTarget, step);


            if (transform.position == nextTarget)
            {
                GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 0f, 1f);
                int randomSize = Random.Range(1, objectSizeMax);
                transform.localScale = Vector3.one * randomSize;

                transform.Rotate(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));

                targetIndex++;
            }
        }
        else
        {
            targetIndex = 0;
        }


       /* if (Vector3.Distance(transform.position, targets[0].position) > 0.001f)
        { 
            transform.position = Vector3.MoveTowards(transform.position, targets[0].position, step);
        } 
        else if (Vector3.Distance(transform.position, targets[0].position) < 0.001f)
        {
            Debug.Log("Target1 reached");
            transform.position = Vector3.MoveTowards(transform.position, targets[1].position, step);
        } */

    }
}
