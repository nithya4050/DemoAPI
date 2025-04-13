using DemoAPI.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoAPI.Service;
using AutoMapper;


namespace DemoAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(txtname.Text);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           finally
            {
                //it must execute, we can flow revert here, safer side

                MessageBox.Show("Finally block execute");
            }





            MapperConfiguration mapperConfiguration = new MapperConfiguration(x => x.CreateMap<StudentReg, Employee>()
            .ForMember(dest => dest.fullname, opt => opt.MapFrom(src => src.fullname))
            .ForMember(dest1 => dest1.emailID, opt => opt.MapFrom(src => src.emailID))

            .ForMember(dest2 => dest2.password, opt => opt.MapFrom(src => src.password))
            .ForMember(dest3 => dest3.employeetype, opt => opt.MapFrom(src => src.employeetype))


            );
            
            StudentReg studentReg = new StudentReg();
            studentReg.fullname = txtname.Text;
            studentReg.emailID = txtemail.Text;
            studentReg.password = txtpassword.Text;
            studentReg.employeetype = 1;

            Employee employee = mapperConfiguration.CreateMapper().Map<Employee>(studentReg);





            APIHelper aPIHelper = new APIHelper();
            string output = await aPIHelper.SaveStudent(studentReg);

        }
    }
}