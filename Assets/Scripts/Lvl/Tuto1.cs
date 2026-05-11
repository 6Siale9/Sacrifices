using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tuto1 : MonoBehaviour
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
        CheckForSelection();
        CheckForInput();
    }

    private void Bravo()
    {
        if (_state < 3)
        {
            _state = 3;
            NextText();
        }
    }

    private void CheckForInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_state != 3)
            {
                _state += 1;
                NextText();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_state != 2)
            {
                _state += 1;
                NextText();
            }
        }
    }

    private void CheckForSelection()
    {
        if (!_done)
        {
            if (_ant.Selected)
            {
                _done = true;
                Bravo();
            }
        }
    }

    private void NextText()
    {
        SondManager.Instance.PlaySound("Skip");
        switch (_state)
        {
            case 0:
                _text.text = "Bienvenue, vite les fourmis ont besoin de toi";
                break;
            case 1:
                _text.text = "Mene celle ci jusque sa fourmiliere";
                break;
            case 2:
                _text.text = "Pour pouvoir la diriger, selectionne la avec clic droit";
                break;
            case 3:
                _text.text = "Bien, maintenant utilise ton clic gauche pour la deplacer";
                break;
            case 4:
                _text.text = "Tu peux toujours la deselectionner avec clic droit";
                break;
            case 5:
                _text.text = "Maintenant emmene la jusque chez elle au bout du chemin de terre";
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
