using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Bornander.UI.Interaction;

namespace Bornander.UI.ViewModels
{
    public class SettingsViewModel : Notifier
    {
        private readonly ICommand storeInPreviousCommand;

        private readonly ObservableCollection<TreeNodeViewModel> roots = new ObservableCollection<TreeNodeViewModel>();
        private readonly ObservableCollection<string> previousCriteria = new ObservableCollection<string>();
        private string selectedCriteria = String.Empty;
        private string currentCriteria = String.Empty;

        public SettingsViewModel()
        {
            storeInPreviousCommand = new Command(StoreInPrevious);
        }

        public SettingsViewModel(IEnumerable<TreeNodeViewModel> roots)
        {
            foreach (var node in roots)
                this.roots.Add(node);

            storeInPreviousCommand = new Command(StoreInPrevious);
        }

        private void StoreInPrevious(object dummy)
        {
            if (String.IsNullOrEmpty(CurrentCriteria))
                return;

            if (!previousCriteria.Contains(CurrentCriteria))
                previousCriteria.Add(CurrentCriteria);

            SelectedCriteria = CurrentCriteria;
        }

        public void Add(IEnumerable<TreeNodeViewModel> roots)
        {
            foreach (var node in roots)
                this.roots.Add(node);

        }

        public void Clear()
        {
            this.roots.Clear();
        }

        public int ItemsCount()
        {
            return this.roots.Count;
        }


        private void ApplyFilter()
        {
            foreach (var node in roots)
                node.ApplyCriteria(CurrentCriteria, new Stack<TreeNodeViewModel>());
        }

        public ICommand StoreInPreviousCommand
        {
            get { return storeInPreviousCommand; }
        }

        public IEnumerable<TreeNodeViewModel> Roots
        {
            get { return roots; }
        }

        public IEnumerable<string> PreviousCriteria
        {
            get { return previousCriteria; }
        }

        public string SelectedCriteria
        {
            get { return selectedCriteria; }
            set
            {
                if (value == selectedCriteria)
                    return;

                selectedCriteria = value;
                OnPropertyChanged("SelectedCriteria");
            }
        }

        public string CurrentCriteria
        {
            get { return currentCriteria; }
            set
            {
                if (value == currentCriteria)
                    return;

                currentCriteria = value;
                OnPropertyChanged("CurrentCriteria");
                ApplyFilter();
            }
        }
    }
}
