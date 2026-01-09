using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using DataAccess;
using Models;

namespace IposV3Sync.ViewModels
{
    public class MainViewModel : Screen {
        private readonly IDataProvider<Student> studentsProvider;
        private readonly IWindowManager winManager;
        private string? studentsLoadedText;
        private Student? selectedStudent;
        public ObservableCollection<Student> Students { get; private set; }

        public string? StudentsLoadedText {
            get { return studentsLoadedText; }
            set {
                studentsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public MainViewModel(IDataProvider<Student> provider, IWindowManager winManager) {
            studentsProvider = provider;
            this.winManager = winManager;
            Students = new ObservableCollection<Student>();
        }

        public bool CanEditStudent {
            get { return SelectedStudent != null; }
        }

        public void EditStudent() {
            ConfigurationManager.AppSettings.Set("studentIdForEditing", SelectedStudent?.Id.ToString());
            


            //await winManager.ShowDialogAsync(IoC.Get<StudentsManager.ViewModels.EditStudentViewModel>());

            ReloadStudents();
        }

        public void AddStudent() {

            //await winManager.ShowDialogAsync(IoC.Get<StudentsManager.ViewModels.AddStudentViewModel>());

            
            ReloadStudents();
        }

        protected override async Task OnActivateAsync(CancellationToken cancelationToken) {
            ReloadStudents();
            await Task.CompletedTask;
        }
        
        public void SubmitChanges() {
            studentsProvider.SubmitChanges();
        }

        public void CloseApp() {
            Application.Current.Shutdown();
        }

        public Student? SelectedStudent {
            get { return selectedStudent; }
            set {
                selectedStudent = value;
                NotifyOfPropertyChange(() => CanEditStudent);
            }
        }

        public bool CanRemoveStudent {
            get { return SelectedStudent != null; }
        }

        public void RemoveStudent() {
            if(SelectedStudent != null)
            Students.Remove(SelectedStudent);
        }

        public void ReloadStudents() {
            Students.Clear();
            var students = studentsProvider.GetAll();
            foreach (var student in students) {
                if(student != null)
                    Students.Add(student);
            }
            StudentsLoadedText = "Loaded!";
        }
    }
}