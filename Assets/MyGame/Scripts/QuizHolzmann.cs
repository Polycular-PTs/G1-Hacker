using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizHolzmann : MonoBehaviour
{
    //Fragen 1 Falsch:
    public string answer12 = "Um weniger Glückwünsche zu bekommen";
    public string answer13 = "Damit Pakete nicht falsch geliefert werden";

    //Fragen 1 Richtig
    public string answer11 = "Um Datenschutz besser zu gewährleisten";
    public string answer14 = "Um es Hacker erschweren an dein Passwort zu kommen";

    //Fragen 2 Falsch
    public string answer21 = "Damit seine Freunde & Familie nicht immer alles wissen";
    public string answer22 = "Damit man anderen Anonym nachspionieren kann";

    //Fragen 2 Richtig
    public string answer23 = "Um sich vor Cyberangriffen zu schützen";
    public string answer24 = "Um Cybermobbing aus dem Weg zu gehen";

    //Fragen 3 Falsch
    public string answer31 = "Benutzernamen";
    public string answer32 = "Welche Daten die Firma speichert& verkäuft";

    //Fragen 3 Falsch
    public string answer33 = "Perönliche Angaben wie Geburtstag";
    public string answer34 = "Welchen Personen du folgst";

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;


    private void Start()
    {
        button1.GetComponentInChildren<TMP_Text>().text = answer11;
            

    }
    public void CheckAnswer(bool right)
    {
        if (!right)
        {
            button1.GetComponent<Image>().color = Color.red;
        }
    }


    private void Update()
    {
        
    }
}
