using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneManager : MonoBehaviour
{

    [SerializeField] private string sceneName;

    private GameObject player;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && player != null)
        {
            StartCoroutine(PlayerEnterDoor());  
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    void OpenDoor()
    {
        animator.SetTrigger("open");
    }

    void CloseDoor()
    {
        animator.SetTrigger("close");
    }

    private IEnumerator PlayerEnterDoor()
    {
        player.GetComponent<Player>().enabled = false;
        OpenDoor();
        yield return new WaitForSeconds(2f);
        player.SetActive(false);
        CloseDoor();
        yield return new WaitForSeconds(1f);
        ChangeScene(sceneName);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
