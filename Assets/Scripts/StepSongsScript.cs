// ЗВУКИ ШАГОВ ДОЛЖНЫ БЫТЬ ПО 0,5 секунды
using UnityEngine;
using System.Collections;

public class StepSongsScript : MonoBehaviour
{

    public AudioClip[] Wood;
    public AudioSource source;
    private RaycastHit hit;
    private bool stepping = false;
    private CharacterController controller;
    public float StepTimer = 0.7f;//скорость звука шага
    private float StepTimerDown;
    public float n_speed = 0.3f;//скорость звука бега
    public float Gromkost = 0.5f;//громкость (максимальное значение = 1,0)


    void Start()
    {

        controller = transform.GetComponent<CharacterController>();

    }

    //да, кот скоммуниздил

    void Update()
    {


        if (Input.GetKey(KeyCode.LeftShift)) StepTimer = n_speed;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) StepTimer = 0.7f;

        if (Input.GetKey(KeyCode.LeftControl)) Gromkost = 0.2f;
        else if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.LeftControl)) Gromkost = 0.5f;


        if (controller.isGrounded)
        {
            if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
            {
                Move();
            }
        }
    }

    public void Move()
    {

        if (StepTimerDown > 0)
            StepTimerDown -= Time.deltaTime;
        if (StepTimerDown < 0)
            StepTimerDown = 0;
        if (StepTimerDown == 0)
        {

            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
            {
                if (hit.transform.tag == "Wood") 
                { 
                    source.PlayOneShot(Wood[Random.Range(0, Wood.Length)], Gromkost); 
                }
            }
            StepTimerDown = StepTimer;
        }

    }
}
