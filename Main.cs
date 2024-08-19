using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace StudentManagementSystem
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        const string connectionString = "Data Source=DESKTOP-QLMJKG3;Initial Catalog=School;Integrated Security=True";
        public string Students = "Students";
        public string Courses = "Courses";
        public string Enrollments = "Enrollments";


        public Main()
        {
            InitializeComponent();
            gridControl.DataSource = GetTable(Students);
        }

#region Student CRUD
        public void AddNewStudent(Student st)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Insert Into "+ Students + " " +
                "(FirstName,LastName,CourseCount)" +
                "Values(@p1,@p2,@p3)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", st.FirstName);
            sc.Parameters.AddWithValue("@p2", st.LastName);
            sc.Parameters.AddWithValue("@p3", st.CourseCount);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }

        public int GetLastAddedDataID(string tableName)
        {
            DataTable dt = GetTable(tableName);
            return (int)dt.Rows[dt.Rows.Count - 1][0];
        }

        public void UpdateStudent(Student st)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Update "+ Students + " " +
                "Set FirstName=@p1,LastName=@p2,CourseCount=@p3 " +
                "Where StudentId=@p4";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", st.FirstName);
            sc.Parameters.AddWithValue("@p2", st.LastName);
            sc.Parameters.AddWithValue("@p3", st.CourseCount);
            sc.Parameters.AddWithValue("@p4", st.StudentId);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteStudent(Student student)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string delFromStudent = "Delete From " + Students + " Where StudentId=@p1";
            SqlCommand scStudent = new SqlCommand(delFromStudent, con);
            scStudent.Parameters.AddWithValue("@p1", student.StudentId);
            string delFromEnrollment = "Delete From " + Enrollments + " Where StudentId=@p1";
            SqlCommand scEnrolment = new SqlCommand(delFromEnrollment, con);
            scEnrolment.Parameters.AddWithValue("@p1", student.StudentId);
            con.Open();
            scEnrolment.ExecuteNonQuery();
            scStudent.ExecuteNonQuery();
            con.Close();
        }
       
        private Student GetSelectedStudent()
        {
            Student student;
            student.StudentId = (int)gridView1.GetFocusedRowCellValue("StudentId");
            student.FirstName = gridView1.GetFocusedRowCellValue("FirstName").ToString();
            student.LastName = gridView1.GetFocusedRowCellValue("LastName").ToString();
            student.CourseCount = (int)gridView1.GetFocusedRowCellValue("CourseCount");
            return student;
        }
#endregion

#region Course CRUD
        public void AddNewCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Insert Into "+ Courses + " " +
                "(CourseName,CourseCode)" +
                "Values(@p1,@p2)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.CourseName);
            sc.Parameters.AddWithValue("@p2", course.CourseCode);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Update "+ Courses + " "+
                "Set CourseName=@p1 , CourseCode=@p2 " +
                "Where CourseId=@p3";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.CourseName);
            sc.Parameters.AddWithValue("@p2", course.CourseCode);
            sc.Parameters.AddWithValue("@p3", course.CourseId);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Delete From "+ Courses + " Where CourseId = @p1";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.CourseId);

            string delFromEnrollment = "Delete From " + Enrollments + " Where CourseId=@p1";
            SqlCommand scEnrolment = new SqlCommand(delFromEnrollment, con);
            scEnrolment.Parameters.AddWithValue("@p1", course.CourseId);

            con.Open();
            scEnrolment.ExecuteNonQuery();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private Course GetSelectedCourse()
        {
            Course course = new Course
            {
                CourseId = (int)gridView1.GetFocusedRowCellValue("CourseId"),
                CourseName = gridView1.GetFocusedRowCellValue("CourseName").ToString(),
                CourseCode= gridView1.GetFocusedRowCellValue("CourseCode").ToString()
            };
            return course;
        }

        #endregion

#region Enrollment

        public void Enroll(Enrollment enrollment)
        {
            DataTable dt = GetTable(Enrollments);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i][1]==enrollment.StudentId
                    && (int)dt.Rows[i][2] == enrollment.CourseId)
                {
                    //already Enrolled.
                    break;
                }
            }

            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Insert Into " + Enrollments + " " +
                "(StudentId,CourseId)" +
                "Values(@p1,@p2)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", enrollment.StudentId);
            sc.Parameters.AddWithValue("@p2", enrollment.CourseId);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        
        public void Disenroll(Enrollment enrollment)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Delete From " + Enrollments + " Where CourseId = @p1 and StudentId=@p2";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", enrollment.CourseId);
            sc.Parameters.AddWithValue("@p2", enrollment.StudentId);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }

        #endregion
        public DataTable GetTable(string tableName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Select * from "+ tableName ;

            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        private void barBtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Student student = GetSelectedStudent();
            DeleteStudent(student);
            XtraMessageBox.Show(student.FirstName +" "+ student.LastName+ " deleted.");
        }


        private void barBtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.DataSource = null;
            gridView1.Columns.Clear();
            gridControl.DataSource = GetTable(Students);
        }

        private void barBtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Student student = GetSelectedStudent();

            NewStudentWindow studentWindow = new NewStudentWindow(this);
            studentWindow.Show();
            studentWindow.GetDataSource(student);
            studentWindow.EnableButton(FormOpenType.Edit);
            studentWindow.FillSelectedCourseList();
            studentWindow.FillUnselectedCourseList();
        }

        private void barBtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewStudentWindow studentWindow = new NewStudentWindow(this);
            studentWindow.Show();
            studentWindow.EnableButton(FormOpenType.Add);
            studentWindow.FillSelectedCourseList();
            studentWindow.FillUnselectedCourseList();
        }

        private void barBtnCourseAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            CourseData courseForm = new CourseData(this);
            courseForm.Show();
            courseForm.EnableButton(FormOpenType.Add);
        }

        private void barBtnCourseRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.DataSource = null;
            gridView1.Columns.Clear();
            gridControl.DataSource = GetTable(Courses);
        }

        private void barBtnCourseEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Course course = GetSelectedCourse();
            
            CourseData courseData = new CourseData(this);
            courseData.Show();
            courseData.GetDataSource(course);
            courseData.EnableButton(FormOpenType.Edit);
        }

        private void barBtnCourseDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Course course = GetSelectedCourse();
            DeleteCourse(course);
            XtraMessageBox.Show(course.CourseCode + " " + course.CourseName+ " deleted.");

        }
    }

    public struct Student
    {
        public int StudentId;
        public string FirstName;
        public string LastName;
        public int CourseCount;
    }
    public struct Course 
    {
        public int CourseId;
        public string CourseName;
        public string CourseCode;
    }
    public struct Enrollment
    {
        public int EnrollmentId;
        public int StudentId;
        public int CourseId;
    }
    public enum FormOpenType
    {
        None,
        Add,
        Edit
    }
}
