using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gregMovementPlayer : MonoBehaviour
{

    float maxX = 9.5f;
    float minX = -9.5f;
    float maxY = 9.5f;
    float minY = -9.5f;

    public float timer;
    public int newTarget;
    public float speed;

    public NavMeshAgent nav;
    public Vector3 Target;
    private CharacterController controller;
    public bool nomNom = false;


    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
     
    }

    private void Update()
    {

       transform.Translate(0, 0, .1f);
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        Debug.DrawRay(transform.position, forward, Color.green);

        if (hit.collider != null && hit.collider.transform.GetComponent<GregAnim>())
        {
       // print(hit.collider.transform.name);
      //  print(Vector3.Distance(hit.collider.transform.position, transform.position));
     
        if (Vector3.Distance(hit.collider.transform.position, transform.position) < 2 )
        {
            if (Vector3.Dot(transform.forward, hit.collider.transform.forward) > 0.25 && !nomNom)         
            {
                nomNom = true;
                Destroy(hit.collider.gameObject, 0);
                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                StartCoroutine(Eating());
            }
        }
    }
}
        
    IEnumerator Eating()
    {
        yield return new WaitForSeconds(1);
        nomNom = false;
    }

}
