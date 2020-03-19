using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Assignment_2
{
    class Diff
    {

        //data arrays to contain the text file data
        private List<string> dataArrayOne = new List<string>();
        private List<string> dataArrayTwo = new List<string>();

        //names of the files
        private string fileNameOne = " ";
        private string fileNameTwo = " ";

        //the directory of both files
        private string fileDirectoryOne = " ";
        private string fileDirectoryTwo = " ";

        //constructor calls check input 
        public Diff()
        {
            checkForInput();
        }

        //takes a directory and an array as arguments
        public void loadFile(string fileDirectory, ref List<string> array)
        {
            //Clears any existing data
            array.Clear();
            string currentValue = "";
            using (StreamReader sr = new StreamReader(fileDirectory)) //Reads the file
            {
                //while there's data add it to the array
                while ((currentValue = sr.ReadLine()) != null)
                {


                    array.Add(currentValue);


                }
            }

            //call method to check if the data is the same
            isTheDataTheSame();
        }


        public bool isTheDataTheSame()
        {
            //compare the arrays and return true if they're the same
            if (dataArrayOne.SequenceEqual(dataArrayTwo))
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public void outputToConsole()
        {
            if (isTheDataTheSame())
            {
                //If they are the same output that they are not different
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{fileNameOne} and {fileNameTwo} are not different");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            else
            {
                //If they are not the same output that they are different
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{fileNameOne} and {fileNameTwo} are different");
                Console.ForegroundColor = ConsoleColor.Gray;

            }

        }


        public void checkForInput()
        {
            //constantly checks for input of the diff command
            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput.StartsWith("diff"))
                {
                    try
                    {

                        //Creates substrings for both file names by looking for blankspace in the text
                        userInput = userInput.Substring(5);
                        foreach (char i in userInput)
                        {
                            if (i == ' ')
                            {
                                fileNameOne = userInput.Substring(0, userInput.IndexOf(i));

                                fileNameTwo = userInput.Substring(userInput.IndexOf(i) + 1);

                            }
                        }
                    }
                    catch
                    {


                    }

                    //appends text to make it a directory
                    fileDirectoryTwo = "ResourceFiles/" + fileNameTwo;

                    fileDirectoryOne = "ResourceFiles/" + fileNameOne;



                    //calls check directory to ensure the files exist
                    checkDirecotry();


                }




            }



        }

        public void checkDirecotry()
        {
            if (File.Exists(fileDirectoryOne) && File.Exists(fileDirectoryTwo))
            {
                //If they exist load the files into the appropriate array
                loadFile(fileDirectoryOne, ref dataArrayOne);
                loadFile(fileDirectoryTwo, ref dataArrayTwo);
                outputToConsole();

            }




        }


    }


}
