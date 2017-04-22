using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EmotionLogic : MonoBehaviour {

	public Text resultText; 
	public Text resultTextEmotion;
	public static List<string> listOfPossibleEmotions = new List<string>();
	public static List<Attribute> listOfAttributes = new List<Attribute> ();
	public static Dictionary<string, string[]> behavioralQuestions = new Dictionary<string, string[]> ();
	public static Dictionary<string, int> emotionFrequency = new Dictionary<string, int> ();
	public List<string> listOfPlausibleEmotions = new List<string> ();

	public GameObject behaviorQuestions;

	public bool displayResult = false;
	public static bool updated = false;
	public bool askQuestions = false;
	public static bool behavioralQuestionsAsked = false;
	public bool debugBool = false;

	public GameObject meshClick;

	public GameObject resultPictureGO;

	public int thisCount;
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
					string[] emotions = emotionsToAdd.Split (new char[]{ '|' }); // Taken a char[] as an input

					for (int x = 0; x < emotions.Length; x++) {
						emotionFrequency [emotions [x]] += 1;
					}
				} else {
					emotionFrequency [emotionsToAdd] += 1;
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
						string[] emotions = emotionsToRemove.Split (new char[]{ '|' });

						for (int x = 0; x < emotions.Length; x++) {
							emotionFrequency [emotions [x]] -= 1;
						}
					} else {
						emotionFrequency [emotionsToRemove] -= 1;
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

		// Not really used, determine later if it needs to be removed
		public static string getCurrentEmotion() {
			return listOfPossibleEmotions.ToString();
		}

		// This will address the issue where we have emotionFRequency not reseting after
		// the scene reloads
		public static void resetEmotionLogics() {
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

			listOfPossibleEmotions.Clear ();

			listOfAttributes.Clear ();
		}

		public static void setEmotionDictionary() {
			// This is called at the start and will update all the necessary dictionaries that will be used.
			emotionFrequency.Clear();
			emotionFrequency.Add ("Happy", 0);
			emotionFrequency.Add ("Relaxed & Neutral", 0);
			emotionFrequency.Add ("Playful", 0);
			emotionFrequency.Add ("Curiosity", 0);
			emotionFrequency.Add ("Cautious", 0);
			emotionFrequency.Add ("Fear", 0);
			emotionFrequency.Add ("Anxiety", 0);
			emotionFrequency.Add ("Stress Signal", 0);
			emotionFrequency.Add ("Alert", 0);
			emotionFrequency.Add ("Aggression", 0);
			emotionFrequency.Add ("Confidence", 0);
			emotionFrequency.Add ("Arousal", 0);

			// For some reason this prevents errors.
			resetEmotionLogics();


			// Behavior
			behavioralQuestions.Clear();
			behavioralQuestions.Add("Happy", new string[]{"Panting", "Relaxed", "Tail Thumping on the floor", "Lying with one paw tucked under"});
			behavioralQuestions.Add("Relaxed & Neutral", new string[]{"Weight flat on feet"});
			behavioralQuestions.Add("Playful", new string[]{"Jerky and bouncy, bounce around in exaggerated twists and turns", "Dodge around you", "Paw at you", "Jump on you", "Front body lwoered by bent forepaws"});
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
			emotionDictionary.Clear();
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
			emotionDictionary.Add("Eyes1", "Fear|Stress Signal|Anxiety");
			emotionDictionary.Add("Eyes2", "Arousal");

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
		resultPictureGO.GetComponent<RawImage>().enabled = false;
		askQuestions = false;
	}
	
	// Update is called once per frame
	void Update () {
		debugBool = behavioralQuestionsAsked;
		if (updated == true) {
			
			resultText.GetComponent<Text> ().text = "";

			foreach (string s in listOfPlausibleEmotions) {
				resultText.GetComponent<Text> ().text += (s + ", ");
			}

			updated = false;

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
			// Unless there are only one pluasible emotion
			if (askQuestions == true) {
				// change this number to 2
				if (listOfPlausibleEmotions.Count > 1) {
					meshClick.GetComponent<MeshClick>().setEverythingToZero ();
					//prompt the user with behavioral questions
					GameObject firstButton = behaviorQuestions.transform.GetChild(0).gameObject;
					behaviorQuestions.GetComponent<RectTransform> ().sizeDelta = new Vector2 (700f, 300f);
					firstButton.transform.GetComponentInChildren<Text> ().text = "Choose behaviors that you observe. Current possible emotions: ";

					// Dynamically create buttons for behavioral questions
					foreach (string emotion in listOfPlausibleEmotions) {
						firstButton.transform.GetComponentInChildren<Text> ().text += emotion + ", ";
						foreach (string question in behavioralQuestions[emotion]) {
							GameObject newButton = (GameObject)Instantiate (firstButton, behaviorQuestions.transform);
							newButton.transform.GetComponentInChildren<Text> ().text = question;
						}
					}
					firstButton.transform.GetComponentInChildren<Text> ().fontStyle = FontStyle.Bold;
					firstButton.transform.GetComponentInChildren<Text> ().color = Color.black;
					firstButton.GetComponent<Image> ().color = Color.white;

					behavioralQuestionsAsked = true;
				}
				else {
					meshClick.GetComponent<MeshClick> ().CloseAllButtons ();
					foreach (string s in listOfPlausibleEmotions) {
						ShowResult (s);
					}
				}
			}
		}

		List<string> attributeHandlerBehaviorAttributes = GetComponent<AttributeHandler> ().behaviorAttributes;
		thisCount = 0;
		if (attributeHandlerBehaviorAttributes.Count != thisCount || attributeHandlerBehaviorAttributes.Count > 1) {
			thisCount = attributeHandlerBehaviorAttributes.Count;
			debugBool = true;
			behavioralQuestionsAsked = false;
			Dictionary<string, int> finalEmotionCount = new Dictionary<string, int> (); 

			foreach (string pe in listOfPlausibleEmotions) {
				finalEmotionCount.Add (pe, 0);
				finalEmotionCount [pe] = 0;
			}

			foreach (string b in GetComponent<AttributeHandler>().behaviorAttributes) {
				foreach (string e in behavioralQuestions.Keys) {
					string[] listBehavior = behavioralQuestions [e];
					for (int x = 0; x < listBehavior.Length; x++) {
						if (listBehavior [x].Equals (b)) { //Error?
							finalEmotionCount [e] += 1;
						}
					}
				}
			}

			int largestNumber = 0;
			string largestEmotion = "";
			foreach (string fe in finalEmotionCount.Keys) {
				if (finalEmotionCount[fe] > largestNumber) {
					largestNumber = finalEmotionCount [fe];
					largestEmotion = fe;
				}
			}

			// This is where we display our results picture
			if (largestEmotion.Equals ("") == false) {
				ShowResult (largestEmotion);
			}
		}
	}

	public void ShowResult(string largestEmotion) {
		displayResult = true;

		resultPictureGO.GetComponent<RawImage>().enabled = true;
		string displayString = "";
		if (largestEmotion.Equals ("Happy")) {
			displayString = "\n" + "The dog is happy and relaxed. He or she might move in a relaxed, easy way, and will encourage you to play and share their happiness.";
		} else if (largestEmotion.Equals ("Relaxed & Neutral")) {
			displayString = "\n" + "The dog is relaxed and reasonably content. Such a dog is unconcerned and unthreatened by any activities going on in his immediate environment and is usually approachable.";
		} else if (largestEmotion.Equals ("Playful")) {
			displayString = "\n" + "Here we have the basic invitation to play. It may be accompanied by excited barking or playful attacks and retreats. This set of signals may be used as a sort of \"punctuation mark\" to indicate that any previous rough behaviour was not meant as a threat or challenge.";
		} else if (largestEmotion.Equals ("Curiosity")) {
			displayString = "\n" + "The dog's weight will be back on his rear legs, ready to flee quickly if the need should arise.";
		} else if (largestEmotion.Equals ("Cautious")) {
			displayString = "\n" + "The dog might have confidence issues. Maybe the dog needs to overcome his or her fears. This dog is definitely unconfortable.";
		} else if (largestEmotion.Equals ("Fear")) {
			displayString = "\n" + "This dog is somewhat fearful and is offering signs of submission. These signals are designed to pacify the individual who is of higher social status or whom the dog sees as potentially threatening, in order to avoid any further challenges and prevent conflict.";
		} else if (largestEmotion.Equals ("Anxiety")) {
			displayString = "\n" + "Please remember: It is a GOOD THING that a dog shows you that he is anxious or uncomfortable, rather than going straight to a bite. If you observe one paw raised or the half moon eye, the dog just wants to be left alone.";
		} else if (largestEmotion.Equals ("Stress Signal")) {
			displayString = "\n" + "This dog is under either social or environmental stress. These signals, however, are a general \"broadcast\" of his state of mind and are not being specifically addressed to any other individual";
		} else if (largestEmotion.Equals ("Alert")) {
			displayString = "\n" + "If the dog has detected something of interest, or something unknown, these signals communicate that he is now alert and paying attention while he is assessing the situation to determine if there is any threat or if any action should be taken.";
		} else if (largestEmotion.Equals ("Aggression")) {
			displayString = "\n" + "This is a very dominant and confident animal. Here he or she is not only expressing his or her social dominance, but is also threatening that he will act aggressively if he is challenged.";
		} else if (largestEmotion.Equals ("Confidence")) {
			displayString = "\n" + "This dog trusts his own abilities and judgment, as well as his owner.  He is not needy, unstable nor fearful.";
		} else if (largestEmotion.Equals ("Arousal")) {
			displayString = "\n" + "Arousal is how responsive your dog is to events occurring from you cue and the environment. Arousal is cumulative and doesn't go down quickly. At a certain threshhold, you may see overarousal or fear responses to relatively mild triggers of fear and anxiety"; 
		}

		resultTextEmotion.GetComponent<Text> ().text = (largestEmotion);
		resultTextEmotion.GetComponent<RectTransform> ().sizeDelta = new Vector2 (800f, 350f);

		resultText.GetComponent<Text> ().text = (displayString);
		resultText.GetComponent<RectTransform> ().sizeDelta = new Vector2 (800f, 350f);
	}

	public void ReloadScene() {
		EmotionLogicEngine.resetEmotionLogics();
		Application.LoadLevel(Application.loadedLevel);
	}
}
