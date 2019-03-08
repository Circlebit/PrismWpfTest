using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismWpfTest
{
    class ViewAViewModel : BindableBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private ObservableCollection<Name> _names;
        public ObservableCollection<Name> Names
        {
            get { return _names; }
            set { SetProperty(ref _names, value); }
        }

        public ICommand AddNameCommand { get; set; }

        public ViewAViewModel()
        {
            Names = new ObservableCollection<Name>();
            AddNameCommand = new DelegateCommand(Execute, CanExecute)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => LastName);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            Names.Add(new Name(FirstName, LastName));
            FirstName = String.Empty;
            LastName = String.Empty;
        }
    }

    class Name
    {
        public string First { get; set; }
        public string Last { get; set; }

        public string Full => First + ' ' + Last;

        public Name(string firstName, string lastName)
        {
            First = firstName;
            Last = lastName;
        }
    }
}
