using UnityEngine;

namespace TinyGiantStudio.Text
{
    //Named this way to avoid confusion for users when trying to add components from the XRToolkit plugin
    public class XRToolkitGlobalInputControllerForModularTextAsset : MonoBehaviour
    {
        public static XRToolkitGlobalInputControllerForModularTextAsset Instance;

        public GameObject currentlySelected;

        void Awake()
        {
            if (Instance)
                Debug.LogWarning("Multiple XRToolkitGlobalInputControllerForModularTextAsset script found on scene.");

            Instance = this;
        }

        public void SelectNewItem(GameObject newTarget)
        {
            if (currentlySelected == null)
                return;

            if (currentlySelected == newTarget)
                return;

            //here currentlyselected is the old target
            if (currentlySelected.GetComponent<InputField>())
                currentlySelected.GetComponent<InputField>()?.Focus(false);


            currentlySelected = newTarget;

            //if (currentlySelected.GetComponent<Button>())
            //    currentlySelected.GetComponent<Button>().SelectButton();

            if (currentlySelected.GetComponent<InputField>())
                currentlySelected.GetComponent<InputField>().Focus(true);
        }
        public void UnselectCurrentlySelected()
        {
            if (currentlySelected == null)
                return;

            currentlySelected.GetComponent<InputField>()?.Focus(false);
        }

        public void Unselect(GameObject target)
        {
            if (currentlySelected == target)
            {
                currentlySelected.GetComponent<InputField>()?.Focus(false);

                currentlySelected = null;
            }
        }
    }
}