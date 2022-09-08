using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Material hiddenMaterial;
    public Material originalMaterial;
    public LevelManager manager;
    private Animator animator;
    
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        animator.SetBool("mouseOver", true); 
    }
    
    void OnMouseExit()
    {
        animator.SetBool("mouseOver", false);
    }
    void OnMouseUp()
    {
        manager.CubeIsClicked(this); //le cube dit que l'on lui a cliqué dessus et le manager va lui dire de révéler sa couleur
    }

    public void RevealColor()
    {
        GetComponent<Renderer>().material = hiddenMaterial;
        animator.SetBool("cubeSelected", true);

    }

    public void UnrevealColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
        animator.SetBool("cubeSelected", false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
