using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tuto2 : MonoBehaviour
{
    [SerializeField] private Ant _ant = null;
    private bool _done = false;
    private int _state = 0;
    [SerializeField] private TMP_Text _text = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }



    private void CheckForInput()
    {
        if (_done)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _state = 2;
                NextText();
            }
            if (Input.GetMouseButtonUp(0))
            {
                _state = 2;
                NextText();
            }
        }
    }

    private void NextText()
    {
        switch (_state)
        {
            case 0:
                _text.text = "Les fourmis rouge arrivent bientôt, mène cette fourmis vers une source de nourriture";
                break;
            case 1:
                _text.text = "";
                break;
            case 2:
                _text.text = "Pour pouvoir la diriger, sélectionne la avec clic droit";
                break;
            case 3:
                _text.text = "Bien, maintenant utilise ton clic gauche pour la déplacer";
                break;
            case 4:
                _text.text = "Tu peux toujours la désélectionner avec clic droit";
                break;
            case 5:
                _text.text = "Maintenant emmène là jusqu'au point en surbrillance";
                break;
            case 6:
                _text.text = "Bonne chance !";
                break;
            default:
                _text.text = "";
                break;
        }
    }
}
