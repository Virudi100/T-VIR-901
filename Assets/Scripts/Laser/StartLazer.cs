using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StartLazer : MonoBehaviour
{
    [Header("Mise place")]
    [SerializeField] private GameObject bullet;             //Stock bullet prefab
    
    private int speed = 5;                                //Shoot speed

    private bool isLoop = false;

    private ManageAnimations animations;

    // Start is called before the first frame update
    void Start()
    {
        //Find object with tag "AnimScript" and get ManageAnimations component
        animations = GameObject.FindGameObjectWithTag("AnimScript").GetComponent<ManageAnimations>();
    }

    void FixedUpdate()
    {
        if(animations.isPlaying == true && isLoop == false)
        {
            //if game is playing -> laser shoot
            isLoop = true;
            StartCoroutine(Shooting());
        }
    }

    IEnumerator Shooting()
    {
        GameObject newbullet;                               //Create object before instanciate

        while(animations.isPlaying == true)                                       //while game is playing
        {
                newbullet = Instantiate(bullet, gameObject.transform);                              //Create bullet at current gameobject position
                newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * speed);  //Add force multiply with speed value on forward direction
                newbullet.transform.parent = null;                                                  //Clear parent
                yield return new WaitForSeconds(0.05f);                                             //Wait 0.05sec 
        }
        isLoop = false;
        yield return null;
    }
}
