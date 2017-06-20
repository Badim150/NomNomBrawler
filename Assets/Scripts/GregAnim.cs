using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregAnim : MonoBehaviour {

    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject upperJaw;
    [SerializeField] private GameObject lowerJaw;
    [SerializeField] private GameObject eye;

    private float minLimit;
    private float maxLimit;
    private bool switchFlag = false;

    private void Start()
    {
        minLimit = upperJaw.transform.position.y - .15f;
        maxLimit = upperJaw.transform.position.y;
        
    }

    // Update is called once per frame
    void Update () {

        if(switchFlag)
        {
            upperJaw.transform.position = new Vector3(upperJaw.transform.position.x, upperJaw.transform.position.y+0.02f, upperJaw.transform.position.z);
            lowerJaw.transform.position = new Vector3(lowerJaw.transform.position.x, lowerJaw.transform.position.y-0.02f, lowerJaw.transform.position.z);
        }
        else
        {
            upperJaw.transform.position = new Vector3(upperJaw.transform.position.x, upperJaw.transform.position.y - 0.02f, upperJaw.transform.position.z);
            lowerJaw.transform.position = new Vector3(lowerJaw.transform.position.x, lowerJaw.transform.position.y + 0.02f, lowerJaw.transform.position.z);
        }

      //  if (upperJaw.transform.position.y <= minLimit)
      if(upperJaw.transform.position.y - lowerJaw.transform.position.y <= 0.2f)
        {
            switchFlag = true;
        }
     //   if (upperJaw.transform.position.y >= maxLimit)
         if(eye.transform.position.y - upperJaw.transform.position.y <= 0.2f)
        {
            switchFlag = false;
        }
        
        leftArm.transform.Rotate(leftArm.transform.position, -10f);
        rightArm.transform.Rotate(leftArm.transform.position, 10f);

    }
}
