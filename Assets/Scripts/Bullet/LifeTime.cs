using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script permet de detruire la balle apres un certain temps d�termin� par -> Cooldown

public class LifeTime : MonoBehaviour
{
    private int cooldown = 3;           //Determine le temps avant la destruction de l'objet
    private bool isDying = false;       //Booleen permettant de lanc� la sequence de destruction (� utilis� plus tard)

    private void Start()
    {
        StartCoroutine(Dying());        //Lancement de la s�quence � la cr�ation de l'objet
    }

    IEnumerator Dying()
    {
        //isDying = true;                 //set le booleen � vrai pour �vit� le lanc� plusieurs fois la s�quence
        int i = 0;                      // le int i, sert ici de cooldown actificiel auquel on va rajouter 1 a chaque passage de la boucle
        
        while(i < cooldown)             // tant que le i n'est pas egale au cooldown souhait� on lui rajoute 1 avec 1 secondes de pause entre chaque ajout
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        Destroy(gameObject);            //l'objet est d�truit

        yield return null;
    }
}
