using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CustomActions input;

    NavMeshAgent agent;
    
    //Movement
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new CustomActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, clickableLayers))
        {
            agent.destination = hit.point;
            if(clickEffect != null)
            {
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
            }
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
