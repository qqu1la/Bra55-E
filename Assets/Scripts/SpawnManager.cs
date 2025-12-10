using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager Instance { get; private set; }

	public GameObject Player;
	private Transform defaultPoint;
	private bool setPoint = false;
	private string spawnLocation = "DefaultSpawnPoint";
	private string setSpawnPoint = "";

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else Destroy(this.gameObject);
	}

	public void SetSpawnLocation(string _location)
	{
		setSpawnPoint = _location;
		setPoint = true;
	}

	private void OnLevelWasLoaded(int level)
	{
		if(level > 1)
		{
			Transform temp = GameObject.Find(setSpawnPoint).transform;
			Instantiate(Player, temp.position, Quaternion.identity);
			ResetLocation();
		}
		if(level == 1)
		{
			if(!setPoint)
			{
				SpawnAtStart();
			}
			else
			{
				SpawnAtSetLocation();
			}
		}
	}

	private void SpawnAtStart()
	{
		defaultPoint = GameObject.Find("DefaultSpawnPoint").transform;
		Instantiate(Player, defaultPoint.position, defaultPoint.rotation);
	}

	void SpawnAtSetLocation()
	{
		Transform spawnPoint = GameObject.Find(setSpawnPoint).transform;
		Instantiate(Player, spawnPoint.position, spawnPoint.rotation);
	}

	private void ResetLocation()
	{
		spawnLocation = "DefaultSpawnPoint";
		setPoint = false;
	}
}
