using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Controller : MonoBehaviour
{
    public GameObject Cube;
    public GameObject CubeClone;
    public bool q;

    // Start is called before the first frame update
    void Start()
    {
        q = true;   
        InstQ();
        CubeClone = GameObject.FindWithTag("CubeClone");
        CubeClone.AddComponent<MeshRenderer>();
        Debug.Log("STARTED! \n Space - Destroy \n I - Create \n D - turn off \n E - turn on \n Q - switch (for gameobject/for Components)");        
    }

    // //  Method for game object

    public void SpaceQube()                     //Method on Space, Destroy Qube
    {
        CubeClone = GameObject.FindWithTag("CubeClone");
        Destroy(CubeClone.GetComponent<MeshRenderer>());            
        Destroy(CubeClone);
        Debug.Log("Cube Destroyed");
    }

    public void IQube()                         //Method on I, Create Qube
    {        
        InstQ();
        CubeClone = GameObject.FindWithTag("CubeClone");
        CubeClone.AddComponent<MeshRenderer>();
        Debug.Log("Cube Created");
    }

    public void DQube()                         //Method on D, Turn off Qube
    {
        CubeClone = GameObject.FindWithTag("CubeClone");
        CubeClone.GetComponent<MeshRenderer>().enabled = false;
        CubeClone.SetActive(false);
        Debug.Log("Cube turned off");
    }

    public void EQube()                         //Method on E, Turn on Qube
    {
        //CubeClone = GameObject.FindWithTag("CubeClone");
        //CubeClone.SetActive(true);                                //does not work
        //CubeClone.GetComponent<MeshRenderer>().enabled = true;

        CubeClone = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("CubeClone"));
        CubeClone.SetActive(true);
        Debug.Log("Cube turned on");
    }

    // // Methods for Components

    public void SpaceMR()                       //Method on Space, Destroy Mesh Renderer
    {
        CubeClone = GameObject.FindWithTag("CubeClone");
        Destroy(CubeClone.GetComponent<MeshRenderer>());
        Debug.Log("Mesh Render Destroyed");
    }

    public void IMR()                           //Method on I, Create Mesh Renderer
    {
        CubeClone = GameObject.FindWithTag("CubeClone");
        CubeClone.AddComponent<MeshRenderer>();
        Debug.Log("Mesh Render Created");
    }

    public void DMR()                           //Method on D, Turn off Mesh Renderer
    {
        CubeClone = GameObject.FindWithTag("CubeClone");
        CubeClone.GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("Mesh Render turned off");
    }

    public void EMR()                           //Method on E, Turned on Mesh Renderer
    {
        //CubeClone = GameObject.FindWithTag("CubeClone");
        //CubeClone.SetActive(true);                                //does not work
        //CubeClone.GetComponent<MeshRenderer>().enabled = true;

        CubeClone = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("CubeClone"));
        CubeClone.GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("Mesh Render turned on");
    }

    // Instantiate for Qube

    public void InstQ()
    {
        Instantiate(Cube);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (q == true)
            {
                Debug.Log("Switched");
                q = false;
            }
                else
                q = true;          
        }

        if (q == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpaceQube();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                IQube();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                DQube();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                EQube();
            }
        }

        if (q == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpaceMR();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                IMR();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                DMR();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                EMR();
            }
        }
    }
}
