using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gregMovement : MonoBehaviour
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
    public bool nomNom = false;
    public Rigidbody rigBody;


    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rigBody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= newTarget)
        {
            NewTarget();
            timer = 0;
            nav.speed = speed;
        }
        transform.LookAt(Target);
        transform.forward.Set(Target.x, Target.y, Target.z);
        //  Debug.DrawLine(Vector3.one, transform.forward, Color.black);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        Debug.DrawRay(transform.position, forward, Color.green);

        if (hit.collider != null && hit.collider.transform.GetComponent<GregAnim>())
        {
             print(hit.collider.transform.name);
             print(Vector3.Distance(hit.collider.transform.position, transform.position));

            if (Vector3.Distance(hit.collider.transform.position, transform.position) < 2)
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

   public void NewTarget()
    {
        float myX = transform.position.x;
        float myZ = transform.position.z;

        float xPos =  Random.Range(minX,maxX);
        float zPos =  Random.Range(minY,maxY);

        Target = new Vector3(xPos, transform.position.y, zPos);

        nav.SetDestination(Target);
       
    }
   
    public void Halt()
    {
        Target = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        nav.SetDestination(Target);
    }

        
    IEnumerator Eating()
{
    yield return new WaitForSeconds(1);
    nomNom = false;
}

}

