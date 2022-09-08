using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Material hiddenMaterial;
    public Material originalMaterial;
    public LevelManager manager;
    
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseUp()
    {
        manager.CubeIsClicked(this); //le cube dit que l'on lui a cliqué dessus et le manager va lui dire de révéler sa couleur
    }

    public void RevealColor()
    {
        GetComponent<Renderer>().material = hiddenMaterial;

    }

    public void UnrevealColor()
    {
        GetComponent<Renderer>().material = originalMaterial;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

    // void OnMouseEnter() //event, nécessite un Collider
    // {
    //     GetComponent<Renderer>().material = hiddenMaterial;
    // }

    // void OnMouseExit()
    // {
    //     GetComponent<Renderer>().material = originalMaterial;
    // }