using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script permet de detruire la balle apres un certain temps d�termin� par -> Cooldown

public class LifeTime : MonoBehaviour
{
 
    [SerializeField] private BulletRebond bulletRebond;

    private void Start()
    {
        StartCoroutine(Dying());        //Lancement de la s�quence � la cr�ation de l'objet
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
        
        Destroy(gameObject);            //l'objet est d�truit

        yield return null;
    }
}
