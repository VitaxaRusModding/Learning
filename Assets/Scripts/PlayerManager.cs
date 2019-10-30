
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Animator animator;

    public CharacterController Controller;

    public Transform m_Transform;

    public Transform camera_parrent;
    void Start()
    {
        animator = GetComponent<Animator>();

        Controller = GetComponent<CharacterController>();

        m_Transform = GetComponent<Transform>();
    }
}