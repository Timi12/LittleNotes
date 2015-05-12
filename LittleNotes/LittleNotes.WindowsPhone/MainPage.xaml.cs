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

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in NotesGrid.ClickedItems)
            {
                // Don't delete the "New Note" button.
                if (element.GetType() != typeof(Button))
                    NotesGrid.Items.Remove(element);
            }
        }
    }
}
