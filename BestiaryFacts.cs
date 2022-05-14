using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryFacts : MonoBehaviour
{
    //Defaults -1 which will randomize at start if Prefab details are not chosen.
    //stats
        [Tooltip("Used for basic intimidation. 1:Tiny,5:Huge")]
        public int size=-1;
        [Tooltip("Sustained walk in straight line")]
        public float speed=-1f;
        [Tooltip("How many degrees per second turning speed. Also used for dodge.")]
        public float agility=-1f;
        [Tooltip("How far from death it is.")]
        public int health=-1;


    //behaviourals
        [Tooltip("How long it will walk before observing. Low=Paranoid High=Gormless")]
        public float wanderDistance=-1;
        [Tooltip("Wander in a straight line? 0=Straight 180=March hare")]
        public float deviateRange=-1;

    //traits
        [Tooltip("Will it attack smaller creatures unprovoked?")]
        public bool carnivore=false;
        [Tooltip("Will it pick up a shiny?")]
        public bool curious=true;
        [Tooltip("Will it activate a shiny?")]
        public bool intelligent=false;


    // Start is called before the first frame update
    void Start()
    {
        if (size == -1) 
        {
            size=Random.Range(1,4);
            transform.localScale=new Vector3(size,size,size);
        }
        else if (size != -1)
        {
            float randomizer=Random.Range(1f,1.5f);
            transform.localScale=new Vector3(size*randomizer,size*randomizer,size*randomizer);
        }
        if (speed== -1) speed=Random.Range(3f,7f);
        else if (speed!= -1)speed=speed*Random.Range(.7f,1.3f);

        if (agility== -1) agility=Random.Range(90f,180f);
        else if (agility!= -1) agility=agility+Random.Range(-25f,25f);

        if (health== -1) health=Random.Range(size*5,size*25);
        else if (health!= -1) health=health+Random.Range(-size*5,size*5);

        if (wanderDistance== -1) wanderDistance=Random.Range(3f,7f);
        else if (wanderDistance != -1) wanderDistance=wanderDistance*Random.Range(-size*2,size*2);

        if (deviateRange== -1) deviateRange=Random.Range(90/size,180/size);
        else if (deviateRange!= -1) deviateRange=deviateRange+Random.Range(10/size,20/size);


// mucking with adding variable to behaviour tree component
       // gameObject.GetComponent<Wander>().wanderDistance=wanderDistance;

    }



}
