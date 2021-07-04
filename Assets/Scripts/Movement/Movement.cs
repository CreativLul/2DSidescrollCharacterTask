using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Geschwindigkeit des Spielers
    [SerializeField]
    private float speed = 3f;

    //Variable zum Zugriff auf die Transform Eigenschaften 
    private Transform myTransform;

    //Variable zum zugreifen auf den Animator 
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        animator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //setzt den Trigger für die Animationen auf 0;
        animator.SetFloat("speed", 0f);

        Walk();
        Run();

    }


    /// <summary>
    /// Ermöglicht die Bewegung des Players durch drücken von den Tasten. A: links; D: rechts; SPACE: oben(jump); S:unten(fall).
    /// Der Speed hat nur Einfluss auf die Horizontale Bewegung.  
    /// </summary>
    private void Walk()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myTransform.Translate(4.4f * Time.deltaTime * Vector2.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myTransform.Translate(3f * Time.deltaTime * Vector2.down);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }
    }

    
    /// <summary>
    /// Führt eine Bewebung des Players aus. Die Geschwindigkeit hängt vom speed ab. Durch Time.deltaTime wird die Bewegung den Frames angepasst.
    /// </summary>
    /// <param name="direction"></param> Bewegungsrichtung
    private void Move(Vector2 direction)
    {

        animator.SetFloat("speed", speed);
        myTransform.Translate(speed * Time.deltaTime * direction);
    }

    /// <summary>
    /// Erhöht den speed wenn die linke Shift Taste gedrückt wird. Setzt den speed beim loslassen zurück.
    /// </summary>
    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.speed = 6f;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            this.speed = 3f;
        }
    }
}
