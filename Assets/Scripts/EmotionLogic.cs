using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EmotionLogic : MonoBehaviour {

	public Text resultText; 
	public static List<string> listOfPossibleEmotions = new List<string>();
	public static List<Attribute> listOfAttributes = new List<Attribute> ();
	public static Dictionary<string, string[]> behavioralQuestions = new Dictionary<string, string[]> ();
	public static Dictionary<string, int> emotionFrequency = new Dictionary<string, int> ();
	public List<string> listOfPlausibleEmotions = new List<string> ();

	public GameObject behaviorQuestions;

	public static bool updated = false;
	public bool askQuestions = false;

	public static class EmotionLogicEngine {
		public static string currentEmotion = "";

		public static Dictionary<string, string> emotionDictionary = new Dictionary<string, string>();

		public static bool containChecker(Attribute checkingAtt) {
			foreach (Attribute att in listOfAttributes) {
				if (att.attributeCode ().Equals (checkingAtt.attributeCode ())) {
					return true;
				}
			}
			return false;
		}

		public static void addAttribute(Attribute addingAttribute) {
			// check if the attribute is already in the list of attributes
			if (containChecker(addingAttribute) == false) {
				listOfAttributes.Add (addingAttribute);

				// increment this emotion in the emotion frequency dictionary
				string emotionsToAdd = emotionDictionary[addingAttribute.attributeCode ()];
				// If the attribute indicates more than one emotion, break it up and then update it
				if (emotionsToAdd.Contains ("|")) {
					char[] separator = { '|' };
					string[] emotions = emotionsToAdd.Split (separator);

					for (int x = 0; x < emotions.Length; x++) {
						emotionFrequency [emotions [x]] = emotionFrequency [emotions [x]] + 1;
					}
				} else {
					emotionFrequency [emotionsToAdd] = emotionFrequency [emotionsToAdd] + 1;
				}

			}

			// Update the list of possible emotion list
			updatePossibleEmotionList ();
		}

		public static void removeAttribute(Attribute removingAtt) {
			foreach (Attribute att in listOfAttributes) {
				// Check and make sure to remove the correct emotion
				if (att.attributeCode ().Equals (removingAtt.attributeCode ())) {
					listOfAttributes.Remove(att);

					// Decrement in emotionFrequency dictionary
					string emotionsToRemove = emotionDictionary[att.attributeCode ()];
					if (emotionsToRemove.Contains ("|")) {
						char[] separator = { '|' };
						string[] emotions = emotionsToRemove.Split (separator);

						for (int x = 0; x < emotions.Length; x++) {
							emotionFrequency [emotions [x]] = emotionFrequency [emotions [x]] - 1;
						}
					} else {
						emotionFrequency [emotionsToRemove] = emotionFrequency [emotionsToRemove] - 1;
					}
					break;
				}
			}
			// Update the possible emotion list
			updatePossibleEmotionList ();
		}

		public static void updatePossibleEmotionList() {
			// Evaluate or revaluate the emotion
			listOfPossibleEmotions.Clear ();

			// Recount the emotion frequency
			/*
			emotionFrequency ["Happy"] = 0;
			emotionFrequency ["Relaxed & Neutral"] = 0;
			emotionFrequency ["Playful"] = 0;
			emotionFrequency ["Curiosity"] = 0;
			emotionFrequency ["Cautious"] = 0;
			emotionFrequency ["Fear"] = 0;
			emotionFrequency ["Anxiety"] = 0;
			emotionFrequency ["Arousal"] = 0;
			emotionFrequency ["Stress Signal"] = 0;
			emotionFrequency ["Alert"] = 0;
			emotionFrequency ["Aggression"] = 0;
			emotionFrequency ["Confidence"] = 0;
			*/

			// Add and recount
			foreach (Attribute att in listOfAttributes) {
				string emotionsToAdd = emotionDictionary[att.attributeCode ()];
				if (emotionsToAdd.Contains ("|")) {
					char[] separator = { '|' };
					string[] emotions = emotionsToAdd.Split (separator);

					for (int x = 0; x < emotions.Length; x++) {
						if (listOfPossibleEmotions.Contains (emotions [x]) == false) {
							listOfPossibleEmotions.Add (emotions [x]);
						}
					}
				} else {
					if (listOfPossibleEmotions.Contains (emotionsToAdd) == false) {
						listOfPossibleEmotions.Add (emotionsToAdd);
					}
				}
			}
			updated = true;
		}

		// Not really used
		public static string getCurrentEmotion() {
			return listOfPossibleEmotions.ToString();
		}

		public static void setEmotionDictionary() {
			// This is called at the start and will update all the necessary dictionaries that will be used.
			emotionFrequency.Add ("Happy", 0);
			emotionFrequency.Add ("Relaxed & Neutral", 0);
			emotionFrequency.Add ("Playfulness", 0);
			emotionFrequency.Add ("Curiosity", 0);
			emotionFrequency.Add ("Cautious", 0);
			emotionFrequency.Add ("Fear", 0);
			emotionFrequency.Add ("Anxiety", 0);
			emotionFrequency.Add ("Stress Signal", 0);
			emotionFrequency.Add ("Alert", 0);
			emotionFrequency.Add ("Aggression", 0);
			emotionFrequency.Add ("Confidence", 0);
			emotionFrequency.Add ("Arousal", 0);

			emotionFrequency ["Happy"] = 0;
			emotionFrequency ["Relaxed & Neutral"] = 0;
			emotionFrequency ["Playful"] = 0;
			emotionFrequency ["Curiosity"] = 0;
			emotionFrequency ["Cautious"] = 0;
			emotionFrequency ["Fear"] = 0;
			emotionFrequency ["Anxiety"] = 0;
			emotionFrequency ["Arousal"] = 0;
			emotionFrequency ["Stress Signal"] = 0;
			emotionFrequency ["Alert"] = 0;
			emotionFrequency ["Aggression"] = 0;
			emotionFrequency ["Confidence"] = 0;


			// Behavior
			behavioralQuestions.Add("Happy", new string[]{"Panting", "Relaxed", "Tail Thumping on the floor", "Lying with one paw tucked under"});
			behavioralQuestions.Add("Relaxed & Neutral", new string[]{"Weight flat on feet"});
			behavioralQuestions.Add("Playfulness", new string[]{"Jerky and bouncy, bounce around in exaggerated twists and turns", "Dodge around you", "Paw at you", "Jump on you", "Front body lwoered by bent forepaws"});
			behavioralQuestions.Add("Curiosity", new string[]{"Relaxed but concentrating", "Use of paws, nose and mouth", "Engagement in activity"});
			behavioralQuestions.Add("Cautious", new string[]{"Concentrating"});
			behavioralQuestions.Add("Fear", new string[]{"Brief and indirect eye contact", "Hiding"});
			behavioralQuestions.Add("Anxiety", new string[]{"Escape from pressure", "Fidgety", "Look away"});
			// Add more detail later
			//behavioralQuestions.Add("Anxiety-Displacement", new string[]{"Yawning when not tired", "Licking lips without the presence of food", "Suddent scratching when not itchy", "Sudden biting at paws or other body part", "Suddeny sniffing the ground or other object", "Wet dog shake when not wet or dirty"});
			//behavioralQuestions.Add("Anxiety-Avoidance", new string[]{"Goes into another room", "Hiding behind a person or object", "Barking and retreating", "Avoiding eye contact"});
			behavioralQuestions.Add("Stress Signal", new string[]{"Scratching", "Rapid panting", "Hair loss", "Sniffing", "Yawning"});
			behavioralQuestions.Add("Alert", new string[]{"Intense", "Focused", "Stance up right"});
			behavioralQuestions.Add("Aggression", new string[]{"Guarding his or her own possesions against family members or guests", "Snap and intentionally miss", "Snarl", "Aggressive barking which is not stopped by your request", "Lunging on or off the leash", "Intentionalyl urinating in the house in your presence", "Bite"});

			// Appearance
			emotionDictionary.Add("Body0", "Confidence|Cautious|Aggression");
			emotionDictionary.Add("Body1", "Cautious");
			emotionDictionary.Add("Body2", "Fear|Stress Signal");
			emotionDictionary.Add("Body3", "Playful|Happy");
			emotionDictionary.Add("Body4", "Arousal|Aggression");
			emotionDictionary.Add("Body5", "Alert");

			// Whenever | is included in the string, make sure to break it up
			emotionDictionary.Add("Muscle0", "Relaxed & Neutral|Confidence|Happy");
			emotionDictionary.Add("Muscle1", "Fear|Stress Signal|Arousal");

			emotionDictionary.Add("Lips0", "Fear|Stress Signal");
			emotionDictionary.Add("Lips1", "Aggression");

			emotionDictionary.Add("Eyes0", "Playful");
			emotionDictionary.Add("Eyes1", "Fear|Stress Signal");
			emotionDictionary.Add("Eyes2", "Anxiety");
			emotionDictionary.Add("Eyes3", "Arousal");

			emotionDictionary.Add("Ears0", "Happy|Relaxed & Neutral");
			emotionDictionary.Add("Ears1", "Confidence|Playful|Alert");
			emotionDictionary.Add("Ears2", "Curiosity");
			emotionDictionary.Add("Ears3", "Fear|Stress Signal|Anxiety");
			emotionDictionary.Add("Ears4", "Arousal|Aggression|Alert");

			emotionDictionary.Add("Tail0", "Cautious|Anxiety|Stress Signal");
			emotionDictionary.Add("Tail1", "Relaxed & Neutral");
			emotionDictionary.Add("Tail2", "Fear");
			emotionDictionary.Add("Tail3", "Arousal|Aggression");
			emotionDictionary.Add ("Tail4", "Playful|Happy");
			emotionDictionary.Add ("Tail5", "Alert");

			emotionDictionary.Add("Tongue0", "Cautious|Fear|Stress Signal");
			emotionDictionary.Add("Tongue1", "Stress Signal");
			emotionDictionary.Add("Tongue2", "Relaxed & Neutral|Playful");

			emotionDictionary.Add("Head0", "Curiosity");
			emotionDictionary.Add("Head1", "Fear|Stress Signal");
			emotionDictionary.Add("Head2", "Relaxed & Neutral");
			emotionDictionary.Add("Head3", "Alert");

			emotionDictionary.Add("Paw0", "Fear|Stress Signal");
			emotionDictionary.Add("Paw1", "Fear|Stress Signal|Anxiety");
		}
	}

	// Use this for initialization
	void Start () {
		EmotionLogicEngine.setEmotionDictionary ();
	}
	
	// Update is called once per frame
	void Update () {
		if (updated == true) {
			resultText.GetComponent<Text> ().text = "Possible Emotions: ";

			// Later look more into SortedDictionary<K,V> to avoid these lines of shi*** code
			// ^ignore this

			foreach (string s in listOfPlausibleEmotions) {
				resultText.GetComponent<Text> ().text += (s + ", ");
			}

			updated = false;

			foreach (string s in emotionFrequency.Keys) {
				//resultText.GetComponent<Text> ().text += (emotionFrequency[s] + ", ");
			}

			// If any emotions in the list of emotions come up more than twice, add it to the list of plausible emotions
			foreach (string emotion in emotionFrequency.Keys) {
				if (emotionFrequency [emotion] > 2) {
					// Ask questions
					if (listOfPlausibleEmotions.Contains (emotion) == false) {
						listOfPlausibleEmotions.Add(emotion);
						askQuestions = true;
					}
				}
			}

			// As soon as an emotion is added to a list of plausible emotions, prompt the user with behavioral questions
			if (askQuestions == true) {
				//prompt the user with behavioral questions
				GameObject firstButton = behaviorQuestions.transform.GetChild(0).gameObject;
				behaviorQuestions.GetComponent<RectTransform> ().sizeDelta = new Vector2 (700f, 300f);
				firstButton.transform.GetComponentInChildren<Text> ().text = "If you observe any of these behaviors... ";

				// Dynamically create buttons for behavioral questions
				foreach (string emotion in listOfPlausibleEmotions) {
					firstButton.transform.GetComponentInChildren<Text> ().text += emotion + ", ";
					foreach (string question in behavioralQuestions[emotion]) {
						GameObject newButton = (GameObject)Instantiate (firstButton, behaviorQuestions.transform);
						newButton.transform.GetComponentInChildren<Text> ().text = question;
					}
				}

				firstButton.transform.GetComponentInChildren<Text> ().fontStyle = FontStyle.Bold;
				firstButton.transform.GetComponentInChildren<Text> ().color = Color.white;
				firstButton.GetComponent<Image> ().color = Color.blue;
			}
		}
	}
}
