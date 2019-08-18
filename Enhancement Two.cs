        /// <summary>
        /// Compares the strings so that closer matches can be found
        /// </summary>
        /// <param name="file">File information</param>
        /// <param name="searchBox">Text to search</param>
        /// <returns></returns>
        private bool CompareSearch(FileInfo file, TextBox searchBox)
        {
            //Arrays to store separation of strings
            string[] fileStringArray = file.Name.ToString().Substring(0, file.Name.ToString().Length - 4).Split(' '); //-4 to remove ".pdf"
            string[] searchStringArray;

            //value of relevance for the search
            int relevanceValue = 0;
            bool match = true;

            //returns true if searchbox is empty for universal search
            if(searchBox.Text == "")
            {
                match = true;
                return match;
            }

            //ensures searchbox is separated into array
            if (searchBox.Text.Contains(" "))
            {
                searchStringArray = searchBox.Text.Split(' ');
            }
            else
            {
                searchStringArray = new string[] { searchBox.Text.ToString() };
            }


            //loops for comparison of strings
            for(int i = 0; i < searchStringArray.Length; i++)
            {
                for (int j = 0; j < fileStringArray.Length; j++)
                {
                    if(searchStringArray[i].ToLower() == fileStringArray[j].ToLower())
                    {
                        relevanceValue += 1;
                    } 
                }
            }

            //if the relevanceVlaue is equal to the length of the search then there are good matches
            if(relevanceValue == searchStringArray.Length)
            {
                match = true;
            }
            else
            {
                match = false;
            }

            //clean up the arrays for next call
            Array.Clear(fileStringArray, 0, fileStringArray.Length);
            Array.Clear(searchStringArray, 0, searchStringArray.Length);
            return match;

        }

        /// <summary>
        /// OVERLOAD Searches for a file based on user input.
        /// </summary>
        /// <param name="aListBox">Displays search result in current listbox.</param>
        /// <param name="searchBox">Uses tab specific search boxes.</param>
        /// <param name="aLabel">Updates label with current fax count.</param>
        /// <param name="cb">Verifies which checkbox is checked.</param>
        /// <param name="tabNumb">Passes tab number to reference which tab is being checked.</param>
        /// <param name="date">Passes date to Truncate search.</param>
        private void SearchFiles(ListBox aListBox, TextBox searchBox, Label aLabel, CheckBox cb, int tabNumb, DateTime date)
        {
            int countSub = 0;
            int finalCount = 0;
            DirectoryInfo[] dirInfoArray = new DirectoryInfo[14];
            //creates new directory info and stores into an array for reference
            for(int i = 0; i < 14; i++)
            {
                dirInfoArray[i] = new DirectoryInfo(FolderPath(i));
            }

            aListBox.Items.Clear();
            try {
                //obtains the directory and lists the files in that directory according to the search box
                DirectoryInfo dirInfo = new DirectoryInfo(@"\\PRS-SRV\Faxes\");
                FileInfo[] Files = dirInfo.GetFiles("*" + searchBox.Text + "*.pdf", SearchOption.AllDirectories);
                foreach (FileInfo file in Files)
                {
                    if (cb.Checked) 
                    {
                        //will only search a certain directory
                        if (file.Directory.Name == dirInfoArray[tabNumb].Name) 
                        {
                            if (CompareSearch(file, searchBox))
                            {
                                aListBox.Items.Add(file);
                            }
                                
                        }
                    }
                    else
                    {
                        //Keeps the backup directory from putting files into the search
                        if (file.Directory.Name != dirInfoArray[13].Name)
                        {
                            //checking to see if any of the date radio buttons are checked
                            if (rbDate.Checked)
                            {
                                if (file.LastWriteTime.Date.CompareTo(date.Date) == 0) //Only show faxes equal to a certain date
                                {
                                    if (file.Directory.Name == dirInfoArray[12].Name)
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            FilterListBox.Items.Add("--------In Done--------");
                                            FilterListBox.Items.Add(file);
                                            FilterListBox.Items.Add("-------------------------");
                                            countSub += 2;
                                        }

                                    }
                                    else
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            aListBox.Items.Add(file);
                                        }
                                            
                                    }
                                }
                            }
                            else if (rbDateBefore.Checked)
                            {
                                if (file.LastWriteTime.Date.CompareTo(date.Date) < 0) //Only show faxes before a certain date
                                {
                                    if (file.Directory.Name == dirInfoArray[12].Name)
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            FilterListBox.Items.Add("--------In Done--------");
                                            FilterListBox.Items.Add(file);
                                            FilterListBox.Items.Add("-------------------------");
                                            countSub += 2;
                                        }

                                    }
                                    else
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            aListBox.Items.Add(file);
                                        }
                                            
                                    }
                                }

                            }
                            else if (rbDateAfter.Checked)
                            {
                                if (file.LastWriteTime.Date.CompareTo(date.Date) > 0) //Only show faxes after a certain date
                                {
                                    if (file.Directory.Name == dirInfoArray[12].Name)
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            FilterListBox.Items.Add("--------In Done--------");
                                            FilterListBox.Items.Add(file);
                                            FilterListBox.Items.Add("-------------------------");
                                            countSub += 2;
                                        }

                                    }
                                    else
                                    {
                                        if (CompareSearch(file, searchBox))
                                        {
                                            aListBox.Items.Add(file);
                                        }
                                            
                                    }
                                }
                            }
                            else
                            {
                                if (file.Directory.Name == dirInfoArray[12].Name)
                                {
                                    if (CompareSearch(file, searchBox))
                                    {
                                        FilterListBox.Items.Add("--------In Done--------");
                                        FilterListBox.Items.Add(file);
                                        FilterListBox.Items.Add("-------------------------");
                                        countSub += 2;
                                    }

                                }
                                else
                                {
                                    if (CompareSearch(file, searchBox))
                                    {
                                        aListBox.Items.Add(file);
                                    }
                                        
                                }
                            }
                                

                        }

                    }
                }
                foreach (object item in FilterListBox.Items)
                {
                    aListBox.Items.Add(item);
                }

                finalCount = (aListBox.Items.Count - countSub);
                aLabel.Text = "Searched Fax Count:    " + finalCount.ToString();
                aLabel.Refresh();
                finalCount = 0;
                countSub = 0;
                FilterListBox.Items.Clear();
                //Clear checked status on radio buttons
                if (rbDateBefore.Checked)
                {
                    rbDateBefore.Checked = !rbDateBefore.Checked;
                }
                if(rbDate.Checked)
                {
                    rbDate.Checked = !rbDate.Checked;
                }
                if (rbDateAfter.Checked)
                {
                    rbDateAfter.Checked = !rbDateAfter.Checked;
                }



            }
            catch (ArgumentException)
            {
                MessageBox.Show("File names cannot contain the following characters: \\ / : * ? \" < > | \nPlease do not use those characters in the name.");
                searchBox.Clear(); //clears the textbox
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Searches for a file based on user input.
        /// </summary>
        /// <param name="aListBox">Displays search result in current listbox.</param>
        /// <param name="searchBox">Uses tab specific search boxes.</param>
        /// <param name="aLabel">Updates label with current fax count.</param>
        /// <param name="cb">Verifies which checkbox is checked.</param>
        /// <param name="tabNumb">Passes tab number to reference which tab is being checked.</param>
        private void SearchFiles(ListBox aListBox, TextBox searchBox, Label aLabel, CheckBox cb, int tabNumb)
        {

            int countSub = 0;
            int finalCount = 0;

            DirectoryInfo[] dirInfoArray = new DirectoryInfo[14];
            //creates new directory info and stores into an array for reference
            for (int i = 0; i < 14; i++)
            {
                dirInfoArray[i] = new DirectoryInfo(FolderPath(i));
            }

            aListBox.Items.Clear();
            try
            {
                //obtains the directory and lists the files in that directory according to the search box
                DirectoryInfo dirInfo = new DirectoryInfo(@"\\PRS-SRV\Faxes\");
                FileInfo[] Files = dirInfo.GetFiles("*.pdf", SearchOption.AllDirectories);

                foreach (FileInfo file in Files)
                {
                    if (cb.Checked)
                    {
                        //will only search a certain directory
                        if (file.Directory.Name == dirInfoArray[tabNumb].Name)
                        {
                            if(CompareSearch(file, searchBox))
                            {
                                aListBox.Items.Add(file);
                            }
                            
                        }
                    }
                    else
                    {
                        //Keeps the backup directory from putting files into the search
                        if (file.Directory.Name != dirInfoArray[13].Name)
                        {

                            if (file.Directory.Name == dirInfoArray[12].Name)
                            {
                                if(CompareSearch(file, searchBox))
                                {
                                    FilterListBox.Items.Add("----In Done----");
                                    FilterListBox.Items.Add(file);
                                    FilterListBox.Items.Add("-------------------------");
                                    countSub += 2;
                                }

                            }
                            else
                            {
                                if (CompareSearch(file, searchBox))
                                {
                                    aListBox.Items.Add(file);
                                }
                                    
                            }


                        }

                    }
                }

                foreach (object item in FilterListBox.Items)
                {
                    aListBox.Items.Add(item);
                }

                finalCount = (aListBox.Items.Count - countSub);
                aLabel.Text = "Searched Fax Count:    " + finalCount.ToString();
                aLabel.Refresh();
                finalCount = 0;
                countSub = 0;
                FilterListBox.Items.Clear();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("File names cannot contain the following characters: \\ / : * ? \" < > | \nPlease do not use those characters in the name.");
                searchBox.Clear(); //clears the textbox
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }