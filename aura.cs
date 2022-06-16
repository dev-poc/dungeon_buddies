using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aura : MonoBehaviour
{
    Bestiary otherBestiary,parentBestiary;
    Statulator otherStatulator,parentStatulator;
   
    DynamicStats otherDynamicStats,parentDynamicStats;
    Behavioural parentBehavioural,otherBehavioural;

    public GameObject[] inAura;
    
    private float auraSize=1;
    // Start is called before the first frame update
    void Start()
    {
        //parentBestiary=gameObject.GetComponentInParent<Bestiary>();
        parentStatulator=gameObject.GetComponentInParent<Statulator>();
        parentDynamicStats=gameObject.GetComponentInParent<DynamicStats>();
        parentBehavioural=gameObject.GetComponentInParent<Behavioural>();

        ResizeAura();
        gameObject.name="aura";
        if (parentStatulator.bestiary.nameOf!="DeBeetle") {SetUpTriggering();}
    }
    void ResizeAura()
    {
        if (parentStatulator.sizeModifier==0)
        {
            //Debug.Log("Aura forcing sizeModifier for parent");
            parentStatulator.sizeModifier=Random.Range((float)parentStatulator.bestiary.size,(float)parentStatulator.bestiary.size*1.9f);
        }
        auraSize=parentStatulator.bestiary.viewDist*parentStatulator.sizeModifier;
        gameObject.transform.localScale=new Vector3(auraSize,auraSize,auraSize);

    }
    void SetUpTriggering()
    {
        gameObject.GetComponent<Renderer>().enabled=false;
        gameObject.GetComponent<Collider>().isTrigger=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        otherStatulator=other.gameObject.GetComponentInParent<Statulator>();
        otherBehavioural=other.gameObject.GetComponentInParent<Behavioural>();
        otherDynamicStats=other.gameObject.GetComponentInParent<DynamicStats>();
    //    otherBestiary=gameObject.GetComponentInParent<Bestiary>();
        if (otherStatulator.sizeModifier >= parentStatulator.sizeModifier+1.0f)
        {
            // Is scared.
            parentBehavioural.inFear=true;
            
        }
Debug.Log(otherStatulator.sizeModifier+" - "+parentStatulator.sizeModifier);
        Debug.Log(otherStatulator.sizeModifier >= parentStatulator.sizeModifier+1.0f);//.transform.parent.name +" Entered Aura of "+parentBehavioural.name);
     //   parentBehavioural.otherNear=true;
     //   parentBehavioural.nearbyThings.Add(other);
      //  Debug.Log(parentBehavioural.nearbyThings);
    }



}
