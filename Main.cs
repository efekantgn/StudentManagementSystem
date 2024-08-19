using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraBars;
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
                "(first_name,last_name,course_count)" +
                "Values(@p1,@p2,@p3)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", st.first_name);
            sc.Parameters.AddWithValue("@p2", st.last_name);
            sc.Parameters.AddWithValue("@p3", st.course_count);
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
                "Set first_name=@p1,last_name=@p2,course_count=@p3 " +
                "Where student_id=@p4";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", st.first_name);
            sc.Parameters.AddWithValue("@p2", st.last_name);
            sc.Parameters.AddWithValue("@p3", st.course_count);
            sc.Parameters.AddWithValue("@p4", st.student_id);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteStudent(Student student)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string delFromStudent = "Delete From " + Students + " Where student_id=@p1";
            SqlCommand scStudent = new SqlCommand(delFromStudent, con);
            scStudent.Parameters.AddWithValue("@p1", student.student_id);
            string delFromEnrollment = "Delete From " + Enrollments + " Where student_id=@p1";
            SqlCommand scEnrolment = new SqlCommand(delFromEnrollment, con);
            scEnrolment.Parameters.AddWithValue("@p1", student.student_id);
            con.Open();
            scEnrolment.ExecuteNonQuery();
            scStudent.ExecuteNonQuery();
            con.Close();
        }
       
        private Student GetSelectedStudent()
        {
            Student student;
            student.student_id = (int)gridView1.GetFocusedRowCellValue("student_id");
            student.first_name = gridView1.GetFocusedRowCellValue("first_name").ToString();
            student.last_name = gridView1.GetFocusedRowCellValue("last_name").ToString();
            student.course_count = (int)gridView1.GetFocusedRowCellValue("course_count");
            return student;
        }
#endregion

#region Course CRUD
        public void AddNewCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Insert Into "+ Courses + " " +
                "(course_name,course_code)" +
                "Values(@p1,@p2)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.course_name);
            sc.Parameters.AddWithValue("@p2", course.course_code);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Update "+ Courses + " "+
                "Set course_name=@p1 , course_code=@p2 " +
                "Where course_id=@p3";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.course_name);
            sc.Parameters.AddWithValue("@p2", course.course_code);
            sc.Parameters.AddWithValue("@p3", course.course_id);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteCourse(Course course)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Delete From "+ Courses + " Where course_id = @p1";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", course.course_id);

            string delFromEnrollment = "Delete From " + Enrollments + " Where course_id=@p1";
            SqlCommand scEnrolment = new SqlCommand(delFromEnrollment, con);
            scEnrolment.Parameters.AddWithValue("@p1", course.course_id);

            con.Open();
            scEnrolment.ExecuteNonQuery();
            sc.ExecuteNonQuery();
            con.Close();
        }
        private Course GetSelectedCourse()
        {
            Course course = new Course
            {
                course_id = (int)gridView1.GetFocusedRowCellValue("course_id"),
                course_name = gridView1.GetFocusedRowCellValue("course_name").ToString(),
                course_code= gridView1.GetFocusedRowCellValue("course_code").ToString()
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
                if ((int)dt.Rows[i][1]==enrollment.student_id
                    && (int)dt.Rows[i][2] == enrollment.course_id)
                {
                    //already Enrolled.
                    break;
                }
            }

            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Insert Into " + Enrollments + " " +
                "(student_id,course_id)" +
                "Values(@p1,@p2)";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", enrollment.student_id);
            sc.Parameters.AddWithValue("@p2", enrollment.course_id);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
        }
        
        public void Disenroll(Enrollment enrollment)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "Delete From " + Enrollments + " Where course_id = @p1 and student_id=@p2";
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.Parameters.AddWithValue("@p1", enrollment.course_id);
            sc.Parameters.AddWithValue("@p2", enrollment.student_id);
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
            DeleteStudent(GetSelectedStudent());
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
            DeleteCourse(GetSelectedCourse());
        }

        public void EnrollToCourses(Student st,List<Course> courses)
        {
            
        }
    }

    public struct Student
    {
        public int student_id;
        public string first_name;
        public string last_name;
        public int course_count;
    }
    public struct Course 
    {
        public int course_id;
        public string course_name;
        public string course_code;
    }
    public struct Enrollment
    {
        public int enrollment_id;
        public int student_id;
        public int course_id;
    }
    public enum FormOpenType
    {
        None,
        Add,
        Edit
    }
}
