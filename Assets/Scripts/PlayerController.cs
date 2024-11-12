using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Mirror;

/*public delegate void OnJumpDelegate();*/
public class PlayerController : NetworkBehaviour, IDamageable
{
    public float speed = 5.0f;
    public int playerHealth = 100;
    public int playerScore = 0;

    public float normalSpeed = 5.0f;
    public float boostedSpeed = 10.0f;
    private bool isBoosted = false;

    public int level = 1;
    public int experience = 100;

    public Weapon equippedWeapon;

    public PlayerActionManager actionManager;

    private PlayerStats stats;

    public GameEvent playerDiedEvent;

   /* public static event OnJumpDelegate OnJump;*/

    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        stats = new PlayerStats(100, 50);
        Debug.Log("Initial Stats - Health: " + stats.health + ", Mana: " + stats.mana);

        stats = stats.withHealth(stats.health - 20);
        Debug.Log("After Damage - Health: " + stats.health + ", Mana: " + stats.mana);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float speed = isBoosted ? boostedSpeed : normalSpeed;

        Move(horizontal, vertical);

        if (playerScore >= 50 && !isBoosted)
        {
            isBoosted = true;
            Debug.Log("Speed Boost Active!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = transform.forward;
            float rayDistance = 5f;

            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red, 1f);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    equippedWeapon.Attack(damageable);
                }
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.AddScore(10);
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<Health>().TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionManager.PerformAction("Move Forward");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionManager.PerformAction("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            actionManager.UndoAction();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();
        }
    }

    void Jump()
    {
        Debug.Log("Player has jumped");
        EventManager.TriggerEvent("PlayerJump");
    }

    public void Move(float  horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement *  speed * Time.deltaTime);
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        Debug.Log("Player health " + playerHealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player is dead!");
        playerDiedEvent.Raise();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            playerScore += 10;
            Debug.Log("Score: " + playerScore);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item"))
        {
            string itemName = other.gameObject.name;
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName]++;
            }
            else
            {
                inventory.Add(itemName, 1);
            }
            Destroy(other.gameObject);
            Debug.Log(itemName + " collected. Quantity: " + inventory[itemName]);
            DisplayInventory();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }

    void DisplayInventory()
    {
        Debug.Log("Inventory Contents:");
        foreach (KeyValuePair<string, int> item in inventory)
        {
            Debug.Log(item.Key + ": " + item.Value);
        }
    }

    public void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerdata.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(this);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game Saved to " + path);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerdata.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            level = data.level;
            experience = data.experience;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

            Debug.Log("Game Loaded from " + path);
        }
        else
        {
            Debug.LogError("Save file not found at " + path);
        }
    }

}
