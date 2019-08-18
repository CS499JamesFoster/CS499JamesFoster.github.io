# Code Review

This is a quick code review to showcase a few of the programs that will be enhanced for this portfolio as well as featuring some of my work outside of the coursework. The code review will cover three artifacts that showcase Software Design and Software Engineering, Algorithms and Data Structure, and Databases. Each artifact will be discussed and then the enhancmenets will be provided below. Thank you for the interest in my projects and my progress.

<div><iframe class="embed-responsive-item" width="560" height="315" src="https://www.youtube.com/embed/4oCa9eI3lqw" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe></div>


# Artifact One: Software Design and Software Engineering

## Artifact One: Enhancements:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enhancements that were accomplished are described more in detail in the narrative below. Here are the images of the enhancements and code for them. The content area has been added and some checks before using buttons have been added.

<img src="Enhancement One 1.PNG">

<img src="Enhancement One 2.PNG">

<img src="Enhancement One 3.PNG">

```
testing
```

<details><summary>EmployeesView.xaml.cs:</summary>
<p>

```
namespace TimeTracker.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        public EmployeesView()
        {
            InitializeComponent();
        }
    }
}
```

</p>
</details>

<details><summary>AddEmployeeViewModel.cs (Code for Graying Out Button):</summary>
<p>

```C#
public bool CanSubmitEmployee
{
    get
    {
        if (FirstName.Length > 0 && LastName.Length > 0 && Month > 0 && Day > 0 && Year > 1900)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}


```

</p>
</details>

<details><summary>EmployeesViewModel.cs:</summary>
<p>

```C#
namespace TimeTracker.ViewModels
{
    public class EmployeesViewModel : Conductor<object>
    {

        private BindableCollection<EmployeeModel> _employees = new BindableCollection<EmployeeModel>();
        private EmployeeModel _selectedEmployee;        

        public EmployeesViewModel()
        {
            ActivateItem(new AddEmployeeViewModel());


            DateTime hire = new DateTime(2011, 09, 12);
            DateTime hire2 = new DateTime(2018, 09, 12);
            DateTime hire3 = new DateTime(2015, 02, 27);
            DateTime hire4 = new DateTime(2016, 10, 31);

            Employees.Add(new EmployeeModel { FirstName = "James", MiddleInitial = "J", LastName = "Foster", HireDate = hire});
            Employees.Add(new EmployeeModel { FirstName = "Jane", MiddleInitial = "L", LastName = "Doe", HireDate = hire2 });
            Employees.Add(new EmployeeModel { FirstName = "John", MiddleInitial = " ", LastName = "Doe", HireDate = hire3 });
            Employees.Add(new EmployeeModel { FirstName = "Jack", MiddleInitial = "O", LastName = "Walker", HireDate = hire4 });
            Employees.Add(new EmployeeModel { FirstName = "Jim", MiddleInitial = "K", LastName = "Doe", HireDate = hire2 });
            Employees.Add(new EmployeeModel { FirstName = "Frank", MiddleInitial = "M", LastName = "Joker", HireDate = hire });

            Employees[0].VacationDays.Add(new VacationDayModel { UsedVacationTime = 8, DateVacationUsed = hire });
            Employees[0].Totals.VacationTimeTotal = 70;
            Employees[0].Totals.SickTimeTotal = 40;
        }

        public BindableCollection<EmployeeModel> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyOfPropertyChange(() => SelectedEmployee);
                NotifyOfPropertyChange(() => CanEditEmployeeBtn);
            }
        }

        public bool CanEditEmployeeBtn
        {
            get
            {
                return SelectedEmployee != null;
            }
            
        }

        public void EditEmployeeBtn()
        {

        }

        public void AddEmployeeBtn()
        {

        }
    }
}
```

</p>
</details>


## Artifact One: Narrative:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The artifact chosen for enhancement is the Time Tracker program developed for my current place of employment to help ensure tracking of vacation and sick hours for employees. It was created on 03/09/2019. The reason this artifact is great for my portfolio is that it demonstrates what I have been able to learn and apply throughout my coursework in a real setting and environment. I selected this item because it is challenging and I’m eager to continue polishing my skills as well as completing more projects and showing my worth to the company. Specifically, this item showcases everything I have come to learn through the CS program as well as skills like critical thinking and problem solving for unique situations to our industry. Everything in this project showcases my ability to create, implement, test, and accomplish tasks set forth by a client.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The artifact was improved in the following areas: (1) content area created for receiving employee information to add them to the list, (2) buttons were adjusted and allowed to be blocked out if requirements are not met, (3) content area is adjustable and scrollable to fit user screen resolution, and (4)  filler variables are set in place becoming ready for SQL connection. I think that I am progressing toward completing these outcomes. Specifically, CS-499-01, CS-499-02, CS-499-04, and CS-499-05 are all being addressed. I don’t think that CS-499-05 can ever really be completed with the growing threat of many different technologies that can and will disrupt current standards; however, I will strive to be vigilant in completing these tasks.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Reflecting on my progress, I’m really impressed that I can accomplish some of this that I once considered impossible or too hard to attempt. It really is an eye-opener to look back and see how far I have come. I constantly learn new ways of doing things as I work on these projects and love that part of programming. Challenges for me are always with UI as I have never worked with UI until the FaxIntake and now Time Tracker. I wanted to challenge myself so that I could become far more effective in my role at work as well as provide much value to the company and owners. Wiring up the UI still gives me a headache at times; however, I am very glad to be working on this project and showcasing my skills.


# Artifact Two: Algorithms and Data Structure

## Artifact Two: Enhancements:


## Artifact Two: Narrative:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The artifact that will showcase algorithms and data structure is the FaxIntake program created on January 18, 2019. This program marks the first official program that I created outside of any schoolwork for a productive reason. I developed it for my company in order to process our faxes in a more efficient manner after pointing them to our server. I chose this item because it demonstrates some of the best concepts put into practice that I have learned over the course of this program. Specifically, the area that showcases the use of data structures and algorithms is my search feature.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The search feature has been enhanced and improved. Searching will now allow the user to obtain files that are relevant to the search even if they are not an exact match of the string. For example, the file name “This is a fax” and “This is an awesome fax” would not be returned if the search was “This fax”; however, with the enhancement, both will now be returned because they contain strings relevant to the search. This function showcases the algorithm and data structures due to the manipulation of both to ensure that the proper results are returned relatively quickly. The enhancements will continue in the future as I develop further for partial string matches and continue the relevance features of the search.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The course objectives that were met were CS-499-01, CS-499-02, CS-499-03, CS-499-04, and CS-499-05. Securing the code is one of my top priorities and ensuring that the user cannot access internal information from the user input is an important part of securing this type of code. Because there is not access to a database, there is no risk for SQL Injection. The other outcomes are necessary for completing a solid program and continuing a focus on maintaining them is paramount. I will continue to enhance this program to ensure that I can get the most use out of my skills but also for efficiency sake for the company.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enhancing this artifact was natural for me. I took the knowledge gained so far and then used it to overcome the problem. I used logical analysis of the current set up and then provided a goal. Once I knew these two points, I could begin to fill in the areas of the program that needed to be refactored and built out. I had a few failed attempts to reach my goal and these attempts helped me find the solution. The solution was found by creating a new method that would “CompareSearch” taking in FileInfo and TextBox arguments. Once these were passed into the method, the I removed the “.pdf” from the end of the string and stored the strings split by spaces into an array. I set up a relevance value that would allow assessment of how relevant the search was to the file name being compared. If there is a direct match, then the method will return true and add the file to the list. If there is a partial match, the relevance value will become active. The string array will be looped through and then compared to the file names which have also be put into string arrays. If there is an exact match to one of the elements, then the relevance value will increment. If the relevance value matches the length of the array that was searched, then the file will be shown in the list as a valid searched item. There is more that can be done to polish this implementation as well as getting into the partial matches, but for now, this will be sufficient until I push those changes out.


# Artifact Three: Databases

## Artifact Three: Enhancements:


## Artifact Three: Narrative:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The artifact chosen for enhancement is the Time Tracker Database and the Time Tracker program developed for my current place of employment to help ensure tracking of vacation and sick hours for employees. The database was created recently in July 2019. The database was created in order to store the information for the company regarding the employees. This artifact in combination with the Time Tracker program is an example of everything I have learned about using databases such as creating, editing, inserting, reading, and establishing data in them. The database was created and then I was able to connect it to the Time Tracker program in order to use the data stored inside of the database.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The course objectives for this artifact are CS-499-01, CS-499-02, CS-499-03, CS-499-04, and CS-499-05. They have all been met during this implementation. The database will continue to need checks and continual maintenance, but for the current time, there is a great application of our objectives. During the creation of the database, all the tables were created and developed properly; however, sanitizing that data in the program for use or viewing is much more difficult. The only function currently created in the software is the reading employees from the database and displaying them in a selectable list. This will display their names in another field.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The process was more difficult as I expected than the other areas; however, I was surprised at how well the course on Advanced Programming Concepts added to the knowledge of connecting to a database using an API. This was invaluable for me to be able to figure out how to link them together and attempt a connection. The end result was that I was able to insert data into the database from MySQL workbench and then I was able to read that data from inside the program. This was a successful event for me as it was the part that I was most nervous about.




You can use the [editor on GitHub](https://github.com/CS499JamesFoster/CS499JamesFoster.github.io/edit/master/README.md) to maintain and preview the content for your website in Markdown files.

Whenever you commit to this repository, GitHub Pages will run [Jekyll](https://jekyllrb.com/) to rebuild the pages in your site, from the content in your Markdown files.

### Markdown

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/CS499JamesFoster/CS499JamesFoster.github.io/settings). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://help.github.com/categories/github-pages-basics/) or [contact support](https://github.com/contact) and we’ll help you sort it out.
