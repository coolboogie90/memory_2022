using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject cubePrefab;
    
    public int rows, columns;
    public float padding;
    public Material[] materials;
    private List<Material> potentialMaterials; //une liste est plus simple à manipuler MAIS prend plus de mémoire qu'un tableau, moins souple
    // Start is called before the first frame update
    private List<CubeBehaviour> cubes = new List<CubeBehaviour>();

    private List<CubeBehaviour> cubesRevealed = new List<CubeBehaviour>();

    void Start()
    {
        if ((rows * columns) % 2 != 0) //si je ne suis pas un nb pair, j'affiche un message d'erreur et je ne génère pas le level
        {
            Debug.LogError("The level needs to have an even number of cubes.", gameObject);
            return;
        }
        potentialMaterials = new List<Material>();
        for (int i = 0; i < materials.Length; i++) //moins couteux qu'un foreach qui ferait une allocation de méméoire sur chaque élément de l liste
        {
            potentialMaterials.Add(materials[i]);
            potentialMaterials.Add(materials[i]); //o
        }

        float interval = 1 + padding;
        for(float y = 0; y < interval * rows; y += interval)
        {
            for(float x = 0; x < interval * columns; x += interval)
            {
                Vector3 position = new Vector3(x, y, 0f);
                CreateCube(position);
            }
        }
    }

    public void CubeIsClicked(CubeBehaviour cube)
    {
        if(cubesRevealed.Contains(cube)) return;
        cube.RevealColor();
        //Debug.Log($"{cube.name} has been revealed.");
        cubesRevealed.Add(cube);
        if(cubesRevealed.Count >= 2)
        {
            if(cubesRevealed[0].hiddenMaterial == cubesRevealed[1].hiddenMaterial)
            {
                Debug.Log("It's a match!!!");
            }
            cubesRevealed.Clear();
        }

    }

    private void CreateCube(Vector3 position)
    {
        GameObject cubeGO = Instantiate(cubePrefab, position, Quaternion.identity); //pour instancier un prefab : Instantiate(nom, position, rotation/Quaternion.identity) identity = un angle de (0,0,0) // un Vector3
        CubeBehaviour cube = cubeGO.GetComponent<CubeBehaviour>();
        cubes.Add(cube); //le "manager" se fait connaitre du cube/worker/behavior
        cube.manager = this; // le cube connait son manager, this étant l'endroit où on est >>> le manager du cube est ici dans ce script
        //>>>> on crée ici la relation entre Levelmanager et Cubebehaviour

        int index = Random.Range(0, potentialMaterials.Count);
        cube.hiddenMaterial = potentialMaterials[index];
        potentialMaterials.RemoveAt(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
