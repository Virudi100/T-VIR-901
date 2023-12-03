using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageInputField : MonoBehaviour
{
    // retrieve prism gameobject script Indice de refraction
    [SerializeField] private IndiceDeRefraction _indiceDeRefractionScript;

    // initialize input field text mesh pro
    private TMP_InputField _inputField;




    // Start is called before the first frame update
    void Start()
    {
        GameObject inputFieldObj = GameObject.Find("IDRInput");
        if (inputFieldObj != null )
        {
            _inputField = inputFieldObj.GetComponent<TMP_InputField>();

        }

        if (_inputField == null)
        {
            Debug.LogError("ManageInputField: Le TMP_InputField n'est pas assign� dans l'�diteur Unity.");
            return;
        }

        GameObject prismeGameObject = GameObject.FindWithTag("Prisme");
        if (prismeGameObject != null)
        {
            _indiceDeRefractionScript = prismeGameObject.GetComponent<IndiceDeRefraction>();
        }
        if (_indiceDeRefractionScript == null)
        {
            Debug.LogError("ManageInputField: Le script IndiceDeRefraction n'a pas �t� trouv� sur l'objet avec le tag 'Prisme'.");
            return;
        }

        _inputField.text = _indiceDeRefractionScript.iDR.ToString();
        _inputField.onValueChanged.AddListener(UpdateRefractionIndex);


    }
    public void UpdateRefractionIndex(string input)
    {
        Debug.Log($"Tentative de mise � jour de l'IDR avec l'entr�e : {input}");

        if (float.TryParse(input, out float newIDR))
        {
            Debug.Log($"Mise � jour de l'IDR � : {newIDR}");
            _indiceDeRefractionScript.iDR = newIDR;
        }
        else
        {
            Debug.LogError("Entr�e invalide pour l'indice de r�fraction");
        }
    }



}
