using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
	public int sceneBuildInd;
	[SerializeField] private string spawnLocation;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			SpawnManager.Instance.SetSpawnLocation(spawnLocation);
			SceneManager.LoadScene(sceneBuildInd, LoadSceneMode.Single);
		}
	}
}
