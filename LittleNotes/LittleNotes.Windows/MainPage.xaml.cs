using Windows.ApplicationModel.DataTransfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LittleNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {

            this.InitializeComponent();
            // Tell Windows 8 that our app can share.
            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }

        private void NewNoteBtn_Click(object sender, RoutedEventArgs e)
        {

            // Hide the menu.
            NotesGrid.Visibility = Visibility.Collapsed;
            // Reset the content of the text editor since we are starting a blank note.
            Notepad.Text = "";
            // Show text editor.
            Notepad.Visibility = Visibility.Visible;


        }

        private void NotesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveClose_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Creates a new textblock that for this note.
                TextBlock block = new TextBlock();
                block.Width = 250;
                block.Height = 125;
                block.Text = Notepad.Text;

                // Assign the click function.
                block.Tapped += block_Tapped;

                // Add that note to the grid.
                NotesGrid.Items.Add(block);

                // Go back to main menu.
                Notepad.Visibility = Visibility.Collapsed;
                NotesGrid.Visibility = Visibility.Visible;

            }
        }
        private void block_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Get a reference to the block that has been tapped.
            TextBlock block = sender as TextBlock;

            // Open the text editor with the content of that block.
            Notepad.Text = block.Text;
            NotesGrid.Visibility = Visibility.Collapsed;
            Notepad.Visibility = Visibility.Visible;

            // Since we are currently editing this block, remove it from the menu.
            // It will be added again once we save the note.
            NotesGrid.Items.Remove(block);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in NotesGrid.SelectedItems)
            {
                // Don't delete the "New Note" button.
                if (element.GetType() != typeof(Button))
                    NotesGrid.Items.Remove(element);
            }
        }
        void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            // We only have text to share when a note is selected.
            if (Notepad.Visibility == Visibility.Visible)
            {
                DataPackage requestData = args.Request.Data;
                requestData.Properties.Title = "My little note";
                requestData.SetText(Notepad.Text);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Creates a new textblock that for this note.
                TextBlock block = new TextBlock();
                block.Width = 250;
                block.Height = 125;
                block.Text = Notepad.Text;

                // Assign the click function.
                block.Tapped += block_Tapped;

                // Add that note to the grid.
                NotesGrid.Items.Add(block);
                

            }


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Go back to main menu.
                Notepad.Visibility = Visibility.Collapsed;
                NotesGrid.Visibility = Visibility.Visible;

            }
        }
    }
}
