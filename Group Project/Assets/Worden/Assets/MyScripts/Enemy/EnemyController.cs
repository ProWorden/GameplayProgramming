using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
 
{
    public GameObject slime;

    public float lookRadius = 20f;
    public Transform target;
    NavMeshAgent agent;
    int maxHealth = 3;
    public int health = 3;
    bool hit = false;
    public float hitBack = 0f;
    bool delay = false;
    float delayTimer = 0f;
    Renderer render;
    public Material mat1;
    public Material mat2;

    public NewMovement3D player;
    public bool attacked = false;

    public float waitTimer = 0.0f;
    public Transform spawn;

    public player_health playerHP;

    bool removePlayerHealth = false;

    int formsLeft = 2;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        render = GetComponent<Renderer>();
    }

    

   
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <=lookRadius)
        {
            waitTimer = 0;

            if (delay)
            {
                delayTimer += Time.deltaTime;
                if (delayTimer > 0.2)
                {
                    delay = false;
                    delayTimer = 0;
                }
                agent.SetDestination(transform.position);
            }
            else
            {
                agent.SetDestination(target.position);
            }
            
        }
        else
        {



            waitTimer += Time.deltaTime;
            if (waitTimer >= 3)
            {
                waitTimer = 3;
                agent.SetDestination(spawn.position);
            }
            else
            {
                agent.SetDestination(transform.position);
            }

        }

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
        }


       
        if(hit)
        {
            hitBack += 3* Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, transform.position - (0.8f * transform.forward), hitBack);
            render.material = mat2;
            if (hitBack >= 0.5)
            {
                render.material = mat1;
            }
         

            if(hitBack >= 1)
            {
                hitBack = 1;
                hit = false;
                delay = true;
                if (health <= 0)
                {
                    if(formsLeft != 0)
                    {
                        Vector3 pos = transform.position;
                        DeathRespawn(new Vector3(pos.x, pos.y, pos.z + 2));
                        DeathRespawn(new Vector3(pos.x, pos.y, pos.z - 2));
                    }
                   
                    Destroy(this.gameObject);
                  
                }
            }

         
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }

    private void LateUpdate()
    {
        if (removePlayerHealth &&player.hitBack >=1)
        {
            playerHP.removeHealth();
            removePlayerHealth = false;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attacked"))
        {
            health--;
            hitBack = 0;
            hit = true;
            
        }
        else if(other.CompareTag("Player"))
        {
            if(player.hitBack >= 1)
            {
                player.hitBack = 0;

            }

            print("bam");

            removePlayerHealth = true;
           
            attacked = true;
            player.hitPlayer = true;
        }
    }

    void DeathRespawn(Vector3 pos)
    {
       
        GameObject spawn = Instantiate(slime, pos, transform.rotation);
        spawn.transform.localScale -= spawn.transform.localScale /3;

        EnemyController script = spawn.GetComponent<EnemyController>();
        script.formsLeft =  this.formsLeft - 1;

        if(script.formsLeft == 1)
        {
            script.health = maxHealth - 1;
        }
        else if(script.formsLeft == 0)
        {
            script.health = maxHealth - 2;
        }
    }

 
}
