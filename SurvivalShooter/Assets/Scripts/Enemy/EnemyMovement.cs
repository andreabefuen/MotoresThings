using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    GameObject safeZone;
    Transform home;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    public float influenceDistance = 2.5f;
    Rigidbody enemy;
    Animator anim;

    PlayerMovement pm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Home")
        {
            nav.enabled = false;
            anim.SetBool("Walk", false);
            //nav.enabled = false;
        }
    }
    void Awake ()
    {
        //Buscar el objeto con la etiqueta Player
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        safeZone = GameObject.FindGameObjectWithTag("SafeArea");
        home = GameObject.FindGameObjectWithTag("Home").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();

        //Cambios para la primera practica
        anim = GetComponent<Animator>();
        enemy = GetComponent<Rigidbody>();

        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();

        
        

        //h = home.GetComponent<Collider>();
    }

    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        //  nav.SetDestination (player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}

    



        //Cambios para la primera practica
        if (Vector3.Distance(player.position, enemy.position) < influenceDistance && pm.dentro == false)
        //if (Mathf.Abs(player.position.x - enemy.position.x) < influenceDistance)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
            anim.SetBool("Walk",true);
            pm.salir = false;
            
        }

        else if (pm.dentro)
        {
            nav.enabled = true;
            anim.SetBool("Walk", true);
            nav.SetDestination(home.position);
        }

        else if(pm.salir == true)
        {
            nav.enabled = true;
            anim.SetBool("Walk", true);
            nav.SetDestination(home.position);
        }

        else
        {
            anim.SetBool("Walk", false);
            nav.enabled = false;
            
        }
    }
}
