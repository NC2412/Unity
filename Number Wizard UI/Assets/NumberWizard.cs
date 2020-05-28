using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
	int max;
	int min;
	int guess;
	int guessesLeft = 5;
	
	public Text text;
	public Text guesses;
	
	// Use this for initialization
	void Start ()
	{
		StartGame ();
	}
	
	void StartGame ()
	{
		max = 1000;
		min = 1;
		guess = 500;
		
		
		max = max + 1;
	}
	
	
	public void GuessHigher ()
	{
		min = guess;
		NextGuess ();
	}
	
	public void GuessLower ()
	{
		max = guess;
		NextGuess ();
	}
	
	void NextGuess ()
	{
		guess = Random.Range (min, max);
		text.text = "Is your number: " + guess + "?";
		guessesLeft = guessesLeft - 1;
		guesses.text = "Guesses left: " + guessesLeft;
		if (guessesLeft < 0) {
			Application.LoadLevel ("Win");
		}
	}
}