using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG455LabProjecct
{
    public partial class ChoiceForm : Form
    {
        private Student selectedStudent;
        private string filepath;
        public ChoiceForm(Student student, string filepath)
        {
            InitializeComponent();
            selectedStudent = student;
            this.filepath = filepath;
        }

        private void ChoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPersonalInfo personalForm = new EditPersonalInfo(selectedStudent, filepath);
            personalForm.ShowDialog();
        }

        private void btnCourseData_Click(object sender, EventArgs e)
        {
            EditCourses courseForm = new EditCourses(selectedStudent, filepath);
            courseForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
