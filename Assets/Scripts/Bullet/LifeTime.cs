using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private BulletRebond bulletRebond;

    private void Start()
    {
        StartCoroutine(Dying());        //Create object
    }

    IEnumerator Dying()
    {
        //Wait 3 seconds
        yield return new WaitForSeconds(3);

        //Destroy start point
        Destroy(bulletRebond.startPosition.gameObject);

        //Destroy impact point
        if(bulletRebond.impactPosition != null )
        {
            Destroy(bulletRebond.impactPosition.gameObject);
        }
        
        //Destroy end point
        if(bulletRebond.endPosition != null)
        {
            Destroy(bulletRebond.endPosition.gameObject);
        }

        //Destroy pres impact point
        if(bulletRebond.presImpactPosition != null )
        {
            Destroy(bulletRebond.presImpactPosition.gameObject);
        }
        
        //Destroy post impact point
        if(bulletRebond.postImpactPosition != null )
        {
            Destroy(bulletRebond.postImpactPosition.gameObject);
        }
        
        Destroy(gameObject);            //Destroy current gameobject

        yield return null;
    }
}
