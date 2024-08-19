using DevExpress.Data.Extensions;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class StudentData : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Main mainForm;
        Student student;
        Dictionary<string, Course> courses = new Dictionary<string, Course>();
        List<Course> selectedCourses = new List<Course>();
        List<Course> unselectedCourses = new List<Course>();
        

        public StudentData(Main mainform)
        {
            InitializeComponent();
            this.mainForm = mainform;
            InitializeCoursesDitcionary();
        }

        public void FillUnselectedCourseList()
        {
            unselectedCourses = courses.Values.ToList();

            for (int i = 0; i < unselectedCourses.Count; i++)
            {
                for (int j = 0; j < selectedCourses.Count; j++)
                {
                    if (unselectedCourses[i].CourseId == selectedCourses[j].CourseId)
                    {
                        unselectedCourses.RemoveAt(i);
                        i--; 
                        break; 
                    }
                }
            }

            //foreach (var course in unselectedCourses)
            //{
            //    listBoxAllCourses.Items.Add(course.CourseName);
            //}
            unselectedCourses.ForEach(course =>
            {
                listBoxAllCourses.Items.Add(course.CourseName);
            });
        }

        private void InitializeCoursesDitcionary()
        {
            DataTable dataTable = mainForm.GetTable(mainForm.Courses);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Course course = new Course()
                {
                    CourseId = (int)dataTable.Rows[i][0],
                    CourseName = dataTable.Rows[i][1].ToString(),
                    CourseCode = dataTable.Rows[i][2].ToString()
                };
                courses.Add(dataTable.Rows[i][1].ToString(), course);
            }
        }

        public void FillSelectedCourseList()
        {
            DataTable dataTableEnrolments = mainForm.GetTable(mainForm.Enrollments);
            List<Course> coursesList = courses.Values.ToList();
            for (int i = 0; i < dataTableEnrolments.Rows.Count; i++)
            {
                if ((int)dataTableEnrolments.Rows[i][1] != student.StudentId) continue;

                int courseId = (int)dataTableEnrolments.Rows[i][2];

                for (int j = 0; j < coursesList.Count; j++)
                {
                    if (courseId != (int)coursesList[j].CourseId) continue;

                    Course course = new Course()
                    {
                        CourseId = coursesList[j].CourseId,
                        CourseName = coursesList[j].CourseName,
                        CourseCode = coursesList[j].CourseCode
                    };
                    selectedCourses.Add(course);
                    listBoxSelectedCourses.Items.Add(course.CourseName);
                }
            }

        }


        public void GetDataSource(Student st)
        {
            student = st;
            textEdit1.Text = student.FirstName;
            textEdit2.Text = student.LastName;
        }
       
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CalculateSelectedCourses();
            student.FirstName = textEdit1.Text;
            student.LastName = textEdit2.Text;
            student.CourseCount = selectedCourses.Count;
            mainForm.UpdateStudent(student);
            EnrollToCourses();
            mainForm.RefreshGridView(mainForm.Students);
            this.Close();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CalculateSelectedCourses();
            student.FirstName = textEdit1.Text;
            student.LastName = textEdit2.Text;
            student.CourseCount = selectedCourses.Count;
            mainForm.AddNewStudent(student);
            student.StudentId = mainForm.GetLastAddedDataID(mainForm.Students);
            EnrollToCourses();
            mainForm.RefreshGridView(mainForm.Students);

            this.Close();
        }

        private void DisEnrollToAllCourses()
        {
            //List<Course> coursesList = courses.Values.ToList();

            //foreach (Course course in coursesList)
            //{
            //    DisenrollToCourse(course);
            //}
            courses.Values.ToList().ForEach(course => 
            {
                DisenrollToCourse(course);
            });
        }
        private void EnrollToCourses()
        {
            DisEnrollToAllCourses();
            //foreach (Course course in selectedCourses)
            //{
            //    EnrollToCourse(course);
            //}
            selectedCourses.ForEach(course =>
            {
                EnrollToCourse(course);
            });
        }
        private void EnrollToCourse(Course course)
        {
            Enrollment enrollment = new Enrollment()
            {
                StudentId = student.StudentId,
                CourseId = course.CourseId,
            };
            mainForm.Enroll(enrollment);
        }
        private void DisenrollToCourse(Course course)
        {
            Enrollment enrollment = new Enrollment()
            {
                StudentId = student.StudentId,
                CourseId = course.CourseId,
            };
            mainForm.Disenroll(enrollment);
        }

        public void EnableButton(FormOpenType formOpenType)
        {
            switch (formOpenType)
            {
                case FormOpenType.None: break;
                case FormOpenType.Add: 
                    bbiSave.Enabled = false;
                    btnAdd.Enabled = true;
                    break;
                case FormOpenType.Edit:
                    bbiSave.Enabled = true;
                    btnAdd.Enabled = false;
                    break;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MoveItemListToList(listBoxAllCourses, listBoxSelectedCourses);
        }

        private void MoveItemListToList(ListBoxControl l1, ListBoxControl l2)
        {
            if(l1.SelectedItem==null) return ; 

            string courseName = l1.SelectedItem.ToString();
            l1.Items.Remove(courseName);
            l2.Items.Add(courseName);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MoveItemListToList(listBoxSelectedCourses, listBoxAllCourses);
        }

        public void CalculateSelectedCourses()
        {
            selectedCourses.Clear();
            unselectedCourses.Clear();
            for (int i = 0; i < listBoxSelectedCourses.Items.Count; i++)
            {
                courses.TryGetValue(listBoxSelectedCourses.Items[i].ToString(), out Course course);

                selectedCourses.Add(course);
            }
            for (int i = 0; i < listBoxAllCourses.Items.Count; i++)
            {
                courses.TryGetValue(listBoxAllCourses.Items[i].ToString(), out Course course);

                unselectedCourses.Add(course);
            }
        }
    }
    
}