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
    public partial class EditPersonalInfo : Form
    {
        private Student selectedStudent;
        private string filePath;
        
        public EditPersonalInfo(Student student, string filePath)
        {
            InitializeComponent();
            selectedStudent = student;
            LoadPersonalData();
            this.filePath = filePath;
        }

        private void LoadPersonalData()
        {
            txtFirstName.Text = selectedStudent.FirstName;
            txtMiddleName.Text = selectedStudent.MiddleName;
            txtLastName.Text = selectedStudent.LastName;
            txtEmail.Text = selectedStudent.Email;
            cmbBoxStatusInCanada.SelectedItem = selectedStudent.StatusInCanada;
            txtHomeAddress.Text = selectedStudent.HomeAddress;
            txtPhoneNumber.Text = selectedStudent.PhoneNumber;
            dtpDateOfBirth.Value = selectedStudent.DateOfBirth;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            selectedStudent.FirstName = txtFirstName.Text;
            selectedStudent.MiddleName = txtMiddleName.Text;
            selectedStudent.LastName = txtLastName.Text;
            selectedStudent.Email = txtEmail.Text;
            selectedStudent.StatusInCanada = cmbBoxStatusInCanada.SelectedItem.ToString();
            selectedStudent.HomeAddress = txtHomeAddress.Text;
            selectedStudent.PhoneNumber = txtPhoneNumber.Text;
            selectedStudent.DateOfBirth = dtpDateOfBirth.Value;


            TxtReader txtReader = new TxtReader();
            List<Student> allStudents = txtReader.LoadStudentsFromTxt(filePath); 

            
            foreach (Student student in allStudents)
            {
                if (student.Email == selectedStudent.Email)
                {
                    
                    student.FirstName = selectedStudent.FirstName;
                    student.MiddleName = selectedStudent.MiddleName;
                    student.LastName = selectedStudent.LastName;
                    student.DateOfBirth = selectedStudent.DateOfBirth;
                    student.StatusInCanada = selectedStudent.StatusInCanada;
                    student.HomeAddress = selectedStudent.HomeAddress;
                    student.PhoneNumber = selectedStudent.PhoneNumber;

                    break; 
                }
            }

            
            TxtWriter txtWriter = new TxtWriter();
            txtWriter.SaveStudentsToTxt(filePath, allStudents);
            
            Form mainForm = Application.OpenForms["Main"];
            ((Main)mainForm).RefreshData();  // to refresh the main table on the main form
            
            MessageBox.Show("Personal information saved successfully!");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void EditPersonalInfo_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
