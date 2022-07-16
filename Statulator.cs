using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statulator : MonoBehaviour
{
    [SerializeField]


    public Bestiary bestiary;
    [HideInInspector] public float placeholder;

    public float statulatorSize;

//    public bool otherNear=false,otherInSight=false;//Controlled by child aura //moving to Behavioural

    SphereCollider aura;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name=bestiary.nameOf+" - "+Time.time;
//Defaulting variables 
        if (bestiary.size_bestiary==-1) {bestiary.size_bestiary=Random.Range(1,5);}
        statulatorSize=(bestiary.size_bestiary-1)+Random.Range(0.1f,1f);

        if (bestiary.nameOf == "DeBeetle") {DeBeetleSpoor();}
        if (gameObject.transform.localScale==new Vector3(1, 1, 1)) {AdjustForSize(statulatorSize);}
    }
    void DeBeetleSpoor()
    /* DeBeetle to be used to DeBug */
    {
        Debug.Log("There is a DeBeetle at:"+gameObject.transform.position);
        Debug.Log("Name of: "+gameObject.name);
        Debug.Log("Bestiary-Size - "+bestiary.size_bestiary);
        Debug.Log("Statulator-Size - "+statulatorSize);
    }
    
    void AdjustForSize(float adjustSize)
    {
       gameObject.transform.localScale=gameObject.transform.localScale*adjustSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}