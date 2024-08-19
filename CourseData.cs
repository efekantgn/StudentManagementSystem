using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class CourseData : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Main mainForm;
        Course course;
        public CourseData(Main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void GetDataSource(Course course)
        {
            this.course = course;
            teCourseCode.Text = course.course_code.ToString();
            teName.Text = course.course_name;
        }

        public void EnableButton(FormOpenType formOpenType)
        {
            switch (formOpenType)
            {
                case FormOpenType.None: break;
                case FormOpenType.Add:
                    barBtnSave.Enabled = false;
                    barBtnAdd.Enabled = true;
                    break;
                case FormOpenType.Edit:
                    barBtnSave.Enabled = true;
                    barBtnAdd.Enabled = false;
                    break;

            }
        }

        private void barBtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            course.course_name = teName.Text;
            course.course_code = teCourseCode.Text;
            mainForm.AddNewCourse(course);
            this.Close();
        }

        private void barBtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            course.course_name = teName.Text;
            course.course_code = teCourseCode.Text;
            mainForm.UpdateCourse(course);
            this.Close();
        }
    }
}