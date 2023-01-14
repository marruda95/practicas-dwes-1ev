using Spectre.Console;
using Students;
using Subjects;


int exit = 0;

string langEnv = Environment.GetEnvironmentVariable("language");

List<Student> students = new List<Student>();  
students.Add(new Student{ 
    Username = "marruda95", 
    Password = "1234", 
    Name = "Maria", 
    Age = 27, 
    Average = 5.6m, 
    isHere = true, 
    dateAdded = new DateTime(), 
    enrolled = new List<Subject>{
        new Subject{Name = "Programming"},
        new Subject{Name = "Gym"}
    }
});

students.Add(new Student{ 
    Username = "pepe1234", 
    Password = "1234", 
    Name = "Pepe", 
    Age = 25, 
    Average = 6.8m, 
    isHere = false, 
    dateAdded = new DateTime(),
    enrolled = new List<Subject>{
        new Subject{Name = "Math"},
        new Subject{Name = "English"}
    } 
});

List<Subject> subjects = new List<Subject>(); 
subjects.Add(new Subject{ Name = "Math", howManyStudents = 3, Price = 23.5m, isAvailable = true, startDay = new DateTime()  });
subjects.Add(new Subject{ Name = "Gym", howManyStudents = 5, Price = 26.0m, isAvailable = false, startDay = new DateTime()  });
subjects.Add(new Subject{ Name = "English", howManyStudents = 19, Price = 100.5m, isAvailable = false, startDay = new DateTime()  });
subjects.Add(new Subject{ Name = "Programming", howManyStudents = 3, Price = 45.2m, isAvailable = true, startDay = new DateTime()  });


AnsiConsole.Write(new FigletText("SCHOOL").Color(ConsoleColor.Blue));

while (exit == 0){
    mainMenu(); 
}

void mainMenu() {
    Console.ForegroundColor = ConsoleColor.Cyan; 
    if(langEnv == "en"){
        Console.Write("------ App for your Classes ------ \n");
    }else{
        Console.Write("------ App para Clases ------\n");
    }
    Console.Write("------ Choose an option to continue\n"); 
    Console.ResetColor(); 
    Console.Write("1 ------  Student Area\n"); 
    Console.Write("2 ------  Check Class Information\n"); 
    Console.Write("3 ------  Exit App\n"); 

    string option = Console.ReadLine(); 

    if (option == "1") {
      exit = userMenu();
    } else if (option == "2"){
        subjects.ForEach(e => {
            Console.WriteLine($"Class: {e.Name} // Price: {e.Price}€ // Available: {e.isAvailable}");
        });
        exit = 0;
    } else if (option == "3"){
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.Write("------ Exiting App ------\n ");
        exit = 1; 
        Console.ResetColor(); 
    } else {
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.Write("INCORRECT INPUT");
        exit = 1;
        Console.ResetColor(); 

    }
}
int userMenu() {
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.Write("------ User Area ------\n");
    Console.ResetColor(); 
    Console.Write("1 ------  Log In\n"); 
    Console.Write("2 ------  Sign Up\n"); 

    string optionStudentArea = Console.ReadLine(); 

    if (optionStudentArea == "1"){
        Console.Write("Username: \n"); 
        string username = Console.ReadLine(); 
        var userSelected = students.Find(e => e.Username == username);

        if (userSelected.Name == null){
            Console.Write("Sorry, that user doesn't exist.");
        } else {
            Console.Write("Password: \n");
            string password = Console.ReadLine(); 
            if(userSelected.Password == password){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Welcome back!\n");
                Console.Write("Here are your classes: \n");
                Console.ResetColor();
                var studentSubject = userSelected.enrolled;
                studentSubject.ForEach(e => {
                    Console.WriteLine(e.Name);
                });
            }else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Incorrect Password");
                Console.ResetColor(); 
                return 1;
            }
        }

        return 0;
        
    }else if (optionStudentArea == "2"){
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Age: ");
        string ageString = Console.ReadLine();
        int ageInt = Int32.Parse(ageString);

        students.Add(new Student{ Username = $"{username}", Password = $"{password}", Name = $"{name}", Age = ageInt, Average = 0, isHere = true, dateAdded = new DateTime() });
        Console.Write("User Created!");

        return 0;


    }else {
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.Write("INCORRECT INPUT");
        return 1;
    }
}


