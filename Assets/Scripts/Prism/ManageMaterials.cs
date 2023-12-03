using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ManageMaterials : MonoBehaviour
{
    MeshRenderer targetRenderer;

    private void Start()
    {
        targetRenderer = GetComponent<MeshRenderer>();
        if (targetRenderer == null)
        {
            Debug.LogError("MeshRenderer component not found on this GameObject.");
        }
        else
        {
            Debug.Log("MeshRenderer found: " + targetRenderer.gameObject.name);
        }
    }

    public void ChangeMaterial(Material newMaterial)
    {

        targetRenderer = GetComponent<MeshRenderer>();

        if (newMaterial == null)
        {
            Debug.LogError("ChangeMaterial called with null material.");
            return;
        }

       

      
            // For prefab assets, use 'sharedMaterial'
            targetRenderer.sharedMaterial = newMaterial;
        

        Debug.Log("Material changed to: " + newMaterial.name);
    }


}
