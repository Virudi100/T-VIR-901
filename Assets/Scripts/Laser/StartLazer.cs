using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

// Ce script permet au laser de tir� ses sph�res & de les tirer en face de lui

public class StartLazer : MonoBehaviour
{
    [Header("Mise place")]
    [SerializeField] private GameObject bullet;             //Stockage du mod�le de la balle via la fenetre inspector de Unity
    
    private int speed = 5;                                //Vitesse d'�jection de la balle

    private bool isLoop = false;

    private ManageAnimations animations;

    // Start is called before the first frame update
    void Start()
    {
        animations = GameObject.FindGameObjectWithTag("AnimScript").GetComponent<ManageAnimations>();
    }

    void FixedUpdate()
    {
        if(animations.isPlaying == true && isLoop == false)
        {
            isLoop = true;
            StartCoroutine(Shooting());
        }
    }

    IEnumerator Shooting()
    {
        GameObject newbullet;                               //Creer un objet pour stocker la balle instanci� et pouvoir l'utilis�

        while(animations.isPlaying == true)                                       //Tant que le taser doit tirer
        {
                newbullet = Instantiate(bullet, gameObject.transform);                              //Cr�er la balle � l'emplacement de l'objet qui tien le script
                newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * speed);  //Envoie la balle avec la puissance "speed" dans la direction forward
                newbullet.transform.parent = null;                                                  //Clear la balle de sont parent
                yield return new WaitForSeconds(0.05f);                                             //Attend 0.05 sec puis continue la boucle    
        }
        isLoop = false;
        yield return null;
    }
}
