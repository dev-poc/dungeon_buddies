using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statulator : MonoBehaviour
{
    [SerializeField]
 //   private bool debugMode=false;
    public Bestiary bestiary;
[HideInInspector] public float placeholder;

    public float sizeModifier;
    public bool otherNear=false,otherInSight=false;//Controlled by child aura

    SphereCollider aura;
    // Start is called before the first frame update
    void Start()
    {
        if (sizeModifier==0)        {sizeModifier=Random.Range((float)bestiary.size,(float)bestiary.size*1.9f);}
        gameObject.name=bestiary.nameOf+" - "+Time.time;
        Instantiate(bestiary.model,transform.position,Quaternion.identity,transform.parent=transform);




        
        
        
        
        
        

        if (bestiary.nameOf == "DeBeetle") {DeBeetleSpoor();}
        //AdjustForSize();
    }
    void DeBeetleSpoor()
    /* DeBeetle to be used to DeBug */
    {
        Debug.Log("You see Bug tracks, they look like:");
        //Debug.Log("Statulator-ViewDist - "+this_viewDist);
    }
    
    void AdjustForSize()
    {
        gameObject.transform.parent.localScale=gameObject.transform.parent.localScale*sizeModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}