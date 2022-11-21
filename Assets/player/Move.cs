using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
// READ.IT
Move Functions Configurations UI Button:
    Event trigger > Pointer Down (Player(Move2.Function));
    Event trigger > Pointer Up (Player(Move2.Reset));               //    <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

Jump Functions Configurations UI Button:
    On Click(Player(Move2.Jump));


*/
public class Move : MonoBehaviour
{
    
	// private Transform transform;
	Vector3 pos;
	Quaternion rot;
	int heart = 2;
	public ScoreManager score;
    public List<GameObject> Life;
    // Variável que controla a força do pulo do objeto controlado
    public float jumpForce = 12.0f;

    //Acessamos o componente Rigidbody através dessa variável
    public Rigidbody rigidBody;

    //Variável que controla a massa/peso do objeto controlado
    public float mass = 3.0f;

    //Variável de controle que nos diz se o personagem está ou não no chão
    private bool isGround = false;

    //Variável que controla a vaelocidade de movimento
    public float moveSpeed = 20.0f;

    //Variável que controla a vaelocidade de Giro
    public float turnSpeed = 150.0f;

    //Variável de controle de movimento da função move()
    private float speed = 0.0f;

    //Variável de controle de tipo de movimento da função move()
    int type;

    public float sensitivity = 5;

    private float turner;

    // Start is called before the first frame update
    void Start()
    {
		
	    Transform transform = GetComponent<Transform>();

		pos = new Vector3();
		pos = transform.position;
		rot = transform.rotation;

        //Assim que o script  é executado, obtemos o componente Rigidbody e atribuimos a nossa variável
        rigidBody = GetComponent<Rigidbody>();

		//Definimos o valor da massa via script
		GetComponent<Rigidbody>().mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        turner = Input.GetAxis("Mouse X") * sensitivity;
        float rotate =
            (Input.GetAxis("Horizontal") * turnSpeed) * Time.deltaTime;

        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        Movement (type, speed);
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
    //Verifica se o personagem tocou no chão
        isGround = true;
        if (collision.gameObject.name == "GameOver")
        {
            transform.position = pos;
            transform.rotation = rot;
            score.GameOver();
        }
        if (collision.gameObject.name == "Bomb")
        {
            Life[heart].gameObject.SetActive(false);
            heart--;
        }
        if (heart < 0)
        {
            transform.position = pos;
            transform.rotation = rot;
            for (int i = 0; i < 3; i++)
            {
                Life[i].gameObject.SetActive(true);
            }
            heart = 2;
            score.GameOver();
        }
    }

    //Verifica se o personagem saiu do chão
    void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

    public void Forward()
    {
        Debug.Log("!!!!!!!! Forward !!!!!!!!!");
        speed = moveSpeed;

        // type = 1; // 1-Rotate
        type = 2; // 2-Tranlate
    }

    public void Back()
    {
        Debug.Log("!!!!!!!! Back !!!!!!!!!");
        speed = -moveSpeed;

        // type = 1; // 1-Rotate
        type = 2; // 2-Tranlate
    }

    public void Left()
    {
        Debug.Log("!!!!!!!! Left !!!!!!!!!");
        speed = -turnSpeed;

        type = 1; // 1-Rotate
        // type = 2; // 2-Tranlate
    }

    public void Right()
    {
        Debug.Log("!!!!!!!! Right !!!!!!!!!");
        speed = turnSpeed;
        type = 1; // 1-Rotate
        // type = 2; // 2-Tranlate
    }

    public void Reset()
    {
        type = 0;
        speed = 0;
    }

    public void Movement(int type, float speed)
    {
        switch (type)
        {
            case 1:
                transform.Rotate(0, speed * Time.deltaTime, 0);
                break;
            case 2:
                transform.Translate(0, 0, speed * Time.deltaTime);
                break;
            default:
                type = 0;
                speed = 0;
                break;
        }
    }

    public void Jump()
    {
        Debug.Log("!!!!!!!! Jump !!!!!!!!!");
        if (!isGround)
        {
            return;
        }
        else
        {
            // Adicionamos uma força ao Rigidbody para fazer o personagem pular, então multiplicamos (0, 1, 0) pelo valor do pulo Ajustamos a força para o tipo Impulse
            GetComponent<Rigidbody>()
                .AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
