using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {

        gregMovement target = other.transform.GetComponent<gregMovement>();
        gregMovementPlayer target2 = other.transform.GetComponent<gregMovementPlayer>();

        if (target)
        {
            target.nav.Stop();
            StartCoroutine(Stopped(target));
        }

        if (target2)
        {
            target2.rooted = true;
            StartCoroutine(Rooted(target2));
        }

    }

    IEnumerator Stopped(gregMovement target)
    {
        yield return new WaitForSeconds(3);
        target.nav.Resume();
        target.NewTarget();
    }

    IEnumerator Rooted(gregMovementPlayer target)
    {
        yield return new WaitForSeconds(3);

        target.rooted = false;
    }

}
