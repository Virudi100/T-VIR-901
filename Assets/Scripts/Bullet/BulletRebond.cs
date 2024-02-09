using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Determine l'angle de rebond du laser selon la zone d'impact

public class BulletRebond : MonoBehaviour
{
    private bool rebonded = false;

    [Header("Rewind")]
    public Transform startPosition;
    public Transform impactPosition;
    public Transform endPosition;
    [SerializeField] private GameObject empty;
    [SerializeField] private ManageAnimations anims;

    [SerializeField] private Slider mainSlider;


    private void Start()
    {
        anims = GameObject.FindGameObjectWithTag("AnimScript").GetComponent<ManageAnimations>();
        startPosition = Instantiate(empty,gameObject.transform).transform;
        startPosition.parent = null;

        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider = GameObject.FindGameObjectWithTag("RewindSlider").GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }


    private void Update()
    {
        if (anims.isPlaying == false && endPosition == null)
        {
            endPosition = Instantiate(empty, gameObject.transform).transform;
            endPosition.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!rebonded)  //Necessaire pour empecher le laser de rebondir sur l'autre face après avoir traversé le prisme
        {
            if (other.CompareTag("Prisme2Pente"))       //Quand le laser touche la pente du prisme 2
            {
                impactPosition = Instantiate(empty, gameObject.transform).transform;
                impactPosition.parent = null;

                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().iDR);      //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().refractionColor;  //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }

            if (other.CompareTag("PrismePenteGauche"))  //Quand le laser touche la pente du prisme
            {
                impactPosition = Instantiate(empty, gameObject.transform).transform;
                impactPosition.parent = null;

                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);     //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);   
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor; //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }
            if (other.CompareTag("PrismePenteDroite"))  //Quand le laser touche la pente du prisme
            {
                impactPosition = Instantiate(empty, gameObject.transform).transform;
                impactPosition.parent = null;

                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);     //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor; //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }
        }
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        //Par rapport a la position du slider la balle bouge vers une position

        if (mainSlider.value > 0.6f)
        {
            gameObject.transform.position = endPosition.position;
        }

        if (mainSlider.value > 0.4f && mainSlider.value < 0.6f && impactPosition != null)
        {
            gameObject.transform.position = impactPosition.position;
        }
        else
            gameObject.transform.position = endPosition.position;

        if (mainSlider.value >= 0 && mainSlider.value < 0.4f)
        {
            gameObject.transform.position = startPosition.position;
        }
    }
}
