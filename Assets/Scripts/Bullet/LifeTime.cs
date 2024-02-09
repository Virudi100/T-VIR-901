using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script permet de detruire la balle apres un certain temps déterminé par -> Cooldown

public class LifeTime : MonoBehaviour
{
 
    [SerializeField] private BulletRebond bulletRebond;

    private void Start()
    {
        StartCoroutine(Dying());        //Lancement de la séquence à la création de l'objet
    }

    IEnumerator Dying()
    {

        yield return new WaitForSeconds(3);

        Destroy(bulletRebond.startPosition.gameObject);

        if(bulletRebond.impactPosition != null )
        {
            Destroy(bulletRebond.impactPosition.gameObject);
        }
        
        if(bulletRebond.endPosition != null)
        {
            Destroy(bulletRebond.endPosition.gameObject);
        }
        
        Destroy(gameObject);            //l'objet est détruit

        yield return null;
    }
}
