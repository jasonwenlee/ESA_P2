using ESA.Models.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustListEditor : ScrollView
    {
        CustomEditor currentRow; // Use for current event listener
        CustomEditor previousRow; // Use to maintain event listener for old row
        int indexCurrentRow;

        public CustListEditor()
        {
            InitializeComponent();
            InsertToList(indexCurrentRow, CreateNewStep());
        }

        // New entry event listnener
        private void NewEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentRow.TextChanged -= NewEntry_TextChanged;
            // Check keystroke and LastOrDefault() prevents **System.InvalidOperationException:** 'Sequence contains no elements'
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            string content = e.NewTextValue ?? " ";
            // Check row index that is currently focused. 
            foreach (var step in AddList.Children)
            {
                // If a step is focused and is not the last step in the list, check for enter key press
                if (step.IsFocused)
                {
                    indexCurrentRow = AddList.Children.IndexOf(step);
                    System.Diagnostics.Debug.WriteLine("NewEntry_TextChanged Line " + indexCurrentRow + " is in focus. " + "Key is " + key);
                    // Insert new step at a specific index below the currently focused step
                    if (key.ToString().Equals("\n"))
                    {
                        // Create a "placeholder" object to hold the current step when focusing on another row
                        CreatePreviousStep(indexCurrentRow);
                        InsertToList(indexCurrentRow + 1, CreateNewStep());
                        return;
                    }
                }
            }
            currentRow.TextChanged += NewEntry_TextChanged;
        }

        // Old entry event listener
        private void OldEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            previousRow.TextChanged -= OldEntry_TextChanged;
            // Check keystroke LastOrDefault() Prevents **System.InvalidOperationException:** 'Sequence contains no elements'
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            string content = e.NewTextValue ?? "";
            // Check row index that is currently focused. 
            foreach (var step in AddList.Children)
            {
                // If a step is focused, check for enter key input
                if (step.IsFocused)
                {
                    indexCurrentRow = AddList.Children.IndexOf(step);
                    System.Diagnostics.Debug.WriteLine("OldEntry_TextChanged Line " + indexCurrentRow + " is in focus. " + "Key is " + key);
                    // Insert new step at a specific index below the currently focused step
                    if (key.ToString().Equals("\n"))
                    {
                        // Create a "placeholder" object to hold the current step when focusing on another row
                        CreatePreviousStep(indexCurrentRow);
                        InsertToList(indexCurrentRow + 1, CreateNewStep());
                        return;
                    }
                }
            }
            previousRow.TextChanged += OldEntry_TextChanged;
        }

        // Create new step
        private CustomEditor CreateNewStep()
        {
            currentRow = new CustomEditor();
            currentRow.TextChanged += NewEntry_TextChanged;
            // Use this custom event handler to check for backspace event and delete a row
            // if it is empty on the final key event
            currentRow.OnBackspace += CurrentRow_OnBackspace;
            // This is used to check if focus has been shifted away from the current new row
            // without pressing the enter key. This subscription continues to hold onto the 
            // event
            currentRow.Unfocused += CurrentRow_Unfocused;
            return currentRow;
        }
        // Create a "placeholder" step to hold a previous/old step
        private void CreatePreviousStep(int index)
        {
            previousRow = new CustomEditor();
            previousRow.TextChanged += OldEntry_TextChanged;
            // Use this custom event handler to check for backspace event and delete the "placeholder" 
            // row if it is empty on the final key event
            previousRow.OnBackspace += PreviousRow_OnBackspace;
            // This is used to check if focus has been shifted away from the "placeholder" row
            // without pressing the enter key. This subscription continues to hold onto the 
            // event
            previousRow.Unfocused += PreviousRow_Unfocused;
            previousRow.Text = ((CustomEditor)AddList.Children.ElementAt(index)).Text.ToString().Trim();
            AddList.Children.RemoveAt(index);
            AddList.Children.Insert(index, previousRow);
        }
        // Use to check the final backspace key event for current empty row
        private void CurrentRow_OnBackspace(object sender, EventArgs e)
        {
            currentRow.OnBackspace -= CurrentRow_OnBackspace;
            foreach (var step in AddList.Children)
            {
                if (step.IsFocused)
                {
                    int thisIndex = AddList.Children.IndexOf(step);
                    if (thisIndex != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("hello " + thisIndex);
                        previousRow = new CustomEditor();
                        previousRow = (CustomEditor)AddList.Children.ElementAt(thisIndex - 1);
                        previousRow.Focus();
                        AddList.Children.RemoveAt(thisIndex);
                    }
                    return;
                }
            }
            currentRow.OnBackspace += CurrentRow_OnBackspace;
        }
        // Use to check the final backspace key event for "placeholder" empty row
        private void PreviousRow_OnBackspace(object sender, EventArgs e)
        {
            previousRow.OnBackspace -= PreviousRow_OnBackspace;
            foreach (var step in AddList.Children)
            {
                if (step.IsFocused)
                {
                    int thisIndex = AddList.Children.IndexOf(step);
                    if (thisIndex != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("goodbye " + thisIndex);
                        previousRow = new CustomEditor();
                        previousRow = (CustomEditor)AddList.Children.ElementAt(thisIndex - 1);
                        previousRow.Focus();
                        AddList.Children.RemoveAt(thisIndex);
                    }
                    return;
                }
            }
            previousRow.OnBackspace += PreviousRow_OnBackspace;
        }
        // Use this method to reassign event handler to current row when it is unfocused
        private void CurrentRow_Unfocused(object sender, FocusEventArgs e)
        {
            currentRow.TextChanged -= NewEntry_TextChanged;
            currentRow.OnBackspace -= CurrentRow_OnBackspace;
            currentRow.TextChanged += NewEntry_TextChanged;
            currentRow.OnBackspace += CurrentRow_OnBackspace;
        }
        // Use this method to reassign event handler to a previous/old row when it is unfocused
        private void PreviousRow_Unfocused(object sender, FocusEventArgs e)
        {
            previousRow.TextChanged -= OldEntry_TextChanged;
            previousRow.OnBackspace -= PreviousRow_OnBackspace;
            previousRow.TextChanged += OldEntry_TextChanged;
            previousRow.OnBackspace += PreviousRow_OnBackspace;
        }
        // Insert new row into list at chosen index
        private void InsertToList(int index, CustomEditor newRow)
        {
            AddList.Children.Insert(index, newRow);
            newRow.Placeholder = index.ToString();
            newRow.FontSize = 18;
            newRow.AutoSize = EditorAutoSizeOption.TextChanges;
            newRow.Focus();
        }
    }
}