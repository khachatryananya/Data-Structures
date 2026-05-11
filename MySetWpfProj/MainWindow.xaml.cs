using LinkedListLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MySetWpf
{
    public partial class MainWindow : Window
    {
        MySet<Student> _men = new MySet<Student>();
        MySet<Student> _women = new MySet<Student>();
        MySet<Student> _reading = new MySet<Student>();
        MySet<Student> _writing = new MySet<Student>();
        MySet<Student> _arithmetic = new MySet<Student>();

        Dictionary<string, MySet<Student>> allSets = new Dictionary<string, MySet<Student>>();

        public MainWindow()
        {
            InitializeComponent();

            Student james = new Student(1, "James", Gender.Male);
            Student robert = new Student(2, "Robert", Gender.Male);
            Student john = new Student(3, "John", Gender.Male);
            Student mark = new Student(4, "Mark", Gender.Male);
            Student otherMark = new Student(5, "Mark", Gender.Male);

            _men.AddRange(new[] { james, robert, john, mark, otherMark });

            Student liz = new Student(6, "Liz", Gender.Female);
            Student amy = new Student(7, "Amy", Gender.Female);
            Student eve = new Student(8, "Eve", Gender.Female);

            _women.AddRange(new[] { liz, amy, eve });

            _reading.AddRange(new[] { james, robert, liz });
            _writing.AddRange(new[] { robert, mark, amy, liz });
            _arithmetic.AddRange(new[] { john, mark, otherMark, amy });

            allSets.Add("Men", _men);
            allSets.Add("Women", _women);
            allSets.Add("Reading", _reading);
            allSets.Add("Writing", _writing);
            allSets.Add("Arithmetic", _arithmetic);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var name in allSets.Keys)
            {
                LeftSet.Items.Add(name);
                RightSet.Items.Add(name);
            }

            Operation.Items.Add("Union");
            Operation.Items.Add("Intersection");
            Operation.Items.Add("Difference");
            Operation.Items.Add("Symmetric diff");
        }

        private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeftMember.Items.Clear();

            if (LeftSet.SelectedItem == null) return;

            string name = LeftSet.SelectedItem.ToString();
            DisplaySetData(allSets[name], LeftMember);
        }

        private void DisplaySetData(MySet<Student> set, ListBox listBox)
        {
            if (set == null) return;

            foreach (var student in set)
            {
                listBox.Items.Add(student.ToString());
            }
        }
    }
}