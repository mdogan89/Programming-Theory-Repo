using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    // ENCAPSULATION
    private string animalName = string.Empty;
    public string AnimalName
    {
        get => animalName; set
        {
            if (value.Length < 2)
            {
                Debug.Log("Too short name!");
                animalName = string.Empty;
            }
            else if (value.Length > 255)
            {
                Debug.Log("Too long name");
                animalName = string.Empty;
            }
            else
            {
                animalName = value;
            }
        }
    }

    protected AudioSource audioSource;

    protected virtual void Move(int speed)
    {
        transform.position = transform.position + RandomVector() * speed;
    }

    protected abstract void Jump();

    protected void OnMouseDown()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    //ABSTRACTION
    public Vector3 RandomVector()
    {
        int x = Random.Range(-20, 20);
        int y = 0;
        int z = Random.Range(-20, 20);
        return new Vector3(x, y, z);
    }
}
