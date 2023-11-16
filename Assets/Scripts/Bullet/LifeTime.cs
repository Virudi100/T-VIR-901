using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script permet de detruire la balle apres un certain temps déterminé par -> Cooldown

public class LifeTime : MonoBehaviour
{
    private int cooldown = 3;           //Determine le temps avant la destruction de l'objet
    private bool isDying = false;       //Booleen permettant de lancé la sequence de destruction (à utilisé plus tard)

    private void Start()
    {
        StartCoroutine(Dying());        //Lancement de la séquence à la création de l'objet
    }

    IEnumerator Dying()
    {
        //isDying = true;                 //set le booleen à vrai pour évité le lancé plusieurs fois la séquence
        int i = 0;                      // le int i, sert ici de cooldown actificiel auquel on va rajouter 1 a chaque passage de la boucle
        
        while(i < cooldown)             // tant que le i n'est pas egale au cooldown souhaité on lui rajoute 1 avec 1 secondes de pause entre chaque ajout
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        Destroy(gameObject);            //l'objet est détruit

        yield return null;
    }
}
