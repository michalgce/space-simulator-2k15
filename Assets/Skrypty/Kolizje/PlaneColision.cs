using UnityEngine;
using System.Collections;

public class PlaneColision : MonoBehaviour
{
	public GameObject explosion;
	private int dozwolonaIloscKolizji = 3;
	public GameObject pasekZdrowia;
	private ObslugaPaska obslugaPaskaAmunicji;
	private float odjacZdrowiaZaKolizje;
	public GameObject symulator;
	private GameController gameController;

	void Start ()
	{
		gameController = symulator.GetComponent<GameController> ();
		obslugaPaskaAmunicji = pasekZdrowia.GetComponent<ObslugaPaska> ();
		odjacZdrowiaZaKolizje = 1.0f / dozwolonaIloscKolizji;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name.Contains("Asteroid")){
			Vector3 position = other.transform.position;
			Quaternion rotation = other.transform.rotation;
			float scale = other.transform.localScale.x;
			if (explosion != null)
			{
				Instantiate(explosion, position, rotation);
			}
			Destroy (other.gameObject);
			// mniejsze tylko niszczymy
			if(scale > 0.3){
				int ile = howManyNewAsteroids();
				float newScale = calculateNewScale(scale, ile);
				for(int i = 0; i<ile ; i++){
					Vector3 newPos = calculateNewRandPosition(position);
					GameObject go = GameObject.Find("Symulator");
					AsteroidsManager asteroidsManager = (AsteroidsManager) go.GetComponent(typeof(AsteroidsManager));
					asteroidsManager.dajAsteroide(newPos, rotation, newScale);
				}
			}
			dozwolonaIloscKolizji--;
			obslugaPaskaAmunicji.ZmienStanPaska(odjacZdrowiaZaKolizje);
			if(dozwolonaIloscKolizji == 0){
				if (explosion != null)
				{
					Instantiate(explosion, position, rotation);
				}
				//Destroy (gameObject);
				gameController.GameOver();
			}
		}
	}

	int howManyNewAsteroids(){
		int rand = (int) Random.Range (2, 6);
		return rand;
	}

	float calculateNewScale(float oldScale, int ile){
		float newScale = oldScale / (ile+1);
		return newScale;
	}

	Vector3 calculateNewRandPosition(Vector3 position){
		float r = 2;
		float x0 = position.x;
		float y0 = position.y;
		float z0 = position.z;
		float x = Random.Range (x0 - 1, x0 + 1);
		float y = Random.Range (y0 - 1, y0 + 1);
		float z = Mathf.Sqrt (Mathf.Pow (r, 2) - Mathf.Pow (x - x0, 2) - Mathf.Pow (y - y0, 2)) + z0;
		return new Vector3(x, y, z);
	}


}