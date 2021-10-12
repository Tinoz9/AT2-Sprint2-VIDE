using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace At2_Sprint_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index = 0;
        int[] hoursArray = new int[24];
        bool sorted = false;

        private void random()
        {
            int min = 10;
            int max = 99;

            Random randNum = new Random();
            for (int i = 0; i < hoursArray.Length; i++)
            {
                if (i != null)
                {
                    hoursArray[i] = randNum.Next(min, max);
                    index++;
                    Console.WriteLine(hoursArray[i]);
                }
            }
        }
        // Method to populate array with random integers for the data stream    

        private void addBtn_Click(object sender, EventArgs e)
        {
            int check = 0;
            if (index < hoursArray.Length)
            {
                if (int.TryParse(textBox.Text, out check))
                {
                    hoursArray[index] = check;
                    index++;
                    textBox.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter an integer");
                }
            }
            display();
        }
        // Method that allows user to add elements to the array 
        // Checks to see if there is an integer entered
        // Message box to display error if otherwise

        private void display()
        {
            try
            {
                listBox.Items.Clear();
                for (int i = 0; i < index; i++)
                {
                    listBox.Items.Add(hoursArray[i]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Array is full");
            }
        }
        // Method displays the array elements in the listbox 
        // Error handing to check if array is full 

        private void editBtn_Click(object sender, EventArgs e)
        {
            int b;
            int a = listBox.SelectedIndex;
            listBox.Items.RemoveAt(a);
            bool c = int.TryParse(textBox.Text, out b);
            if (c == true)
            {
                listBox.Items.Insert(a, b);
            }
            else
            {
                MessageBox.Show("Please enter an integer");
            }
        }
        // Method to allow user to select and edit items in the listbox (array)
        // Error handling to check if input is an integer

        private void delBtn_Click(object sender, EventArgs e)
        {
            hoursArray[listBox.SelectedIndex] = hoursArray[index - 1];
            index--;
            display();
        }
        // Method to delete selected item from the listbox (array)  

        private void sortBtn_Click(object sender, EventArgs e)
        {
            sort();
            display();
        }
        // Sort button that uses the bubble sort algorithm

        private void binBtn_Click(object sender, EventArgs e)
        {
            int target;
            bool b = int.TryParse(textBox.Text, out target);
            int high = index - 1;
            int low = 0;
            int i = target;

            if (sorted)
            {
                try
                {
                    while (low <= high)
                    {
                        int mid = (high + low) / 2;
                        if (target == hoursArray[mid])
                        {
                            MessageBox.Show("Target found");
                            break;
                        }
                        else if (target > hoursArray[mid])
                        {
                            low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                        if (b == false)
                        {
                            MessageBox.Show("Please enter an integer");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Target not found");
                    throw;
                }
            }
        }
        // Binary search method to search for a user inputted value in the listbox (array)
        // Error handling to ensure the list is sorted before binary search

        private void sort()
        {
            for (int i = 0; i < index; i++)
            {
                for (int k = 0; k < index - 1; k++)
                {
                    if (hoursArray[k] > hoursArray[k + 1])
                    {
                        int temp = hoursArray[k];
                        hoursArray[k] = hoursArray[k + 1];
                        hoursArray[k + 1] = temp;
                    }
                }
            }
            sorted = true;
        }
        // Method to sort items in the listbox (Hoursarray) using bubble sort 
        // Set sorted to true for error handling to ensure list is sorted before binary search 

        private void buttonPop_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            random();
            display();
        }

        private void midEBtn_Click(object sender, EventArgs e)
        {

        }

        private void meanBtn_Click(object sender, EventArgs e)
        {

        }

        private void modeBtn_Click(object sender, EventArgs e)
        {

        }

        private void rangeBtn_Click(object sender, EventArgs e)
        {

        }

        private void seqBtn_Click(object sender, EventArgs e)
        {

        }


        // Populate button to add the random integers in the array to the list 

    }
}
