using System;

namespace InheritanceExample
{
    // Clasa de bază Person
    public class Person
    {
        // Proprietate pentru nume
        public string Name { get; set; }

        // Constructorul care primește numele
        public Person(string name)
        {
            Name = name;
        }

        // Suprascrierea metodei ToString pentru afișarea numelui
        public override string ToString()
        {
            return Name;
        }
    }

    // Clasa Student, derivată din Person
    public class Student : Person
    {
        // Constructorul Student care apelează constructorul de bază
        public Student(string name) : base(name) { }

        // Metodă care semnifică faptul că studentul studiază
        public void Study()
        {
            Console.WriteLine("Study");
        }
    }

    // Clasa Teacher, derivată din Person
    public class Teacher : Person
    {
        // Constructorul Teacher care apelează constructorul de bază
        public Teacher(string name) : base(name) { }

        // Metodă care semnifică faptul că profesorul explică
        public void Explain()
        {
            Console.WriteLine("Explain");
        }
    }

    // Clasa Program conține metoda Main pentru rularea aplicației
    class Program
    {
        static void Main(string[] args)
        {
            // Se creează un array de tip Person cu 3 elemente.
            // Conform cerinței, primul element va fi Teacher, iar următoarele două Student.
            Person[] people = new Person[3];

            // Citirea numelor de la tastatură
            Console.WriteLine("Enter the name for the Teacher:");
            string teacherName = Console.ReadLine();
            people[0] = new Teacher(teacherName);

            Console.WriteLine("Enter the name for the first Student:");
            string studentName1 = Console.ReadLine();
            people[1] = new Student(studentName1);

            Console.WriteLine("Enter the name for the second Student:");
            string studentName2 = Console.ReadLine();
            people[2] = new Student(studentName2);

            // Iterăm prin array-ul de persoane și apelăm metoda specifică
            foreach (Person person in people)
            {
                // Dacă este profesor, se apelează Explain()
                if (person is Teacher teacher)
                {
                    teacher.Explain();
                }
                // Dacă este student, se apelează Study()
                else if (person is Student student)
                {
                    student.Study();
                }
            }

            // Exemplu de output pentru inputurile:
            // Teacher: Juan
            // Student: Sara
            // Student: Carlos
            // Va afișa:
            // Explain
            // Study
            // Study

            // Păstrează fereastra deschisă (opțional)
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
