using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bornander.UI.ViewModels {
    public class TreeNodeViewModel : Notifier {
        private readonly ObservableCollection<TreeNodeViewModel> children;
        private readonly string name;

        public Type typeActivity = null;
        public string BitmapName = "";
        public string typeVar = "";

        private bool expanded;
        private bool match = true;

        public TreeNodeViewModel(string name, IEnumerable<TreeNodeViewModel> children) {
            this.name = name;
            this.children = new ObservableCollection<TreeNodeViewModel>(children);
        }

        public TreeNodeViewModel(string name)
            : this(name, Enumerable.Empty<TreeNodeViewModel>()) {
        }

        public override string ToString() {
            return name;
        }

        private bool IsCriteriaMatched(string criteria) {
            return String.IsNullOrEmpty(criteria) || name.Contains(criteria);
        }

        private void CheckChildren(string criteria, TreeNodeViewModel parent) {
            foreach (var child in parent.Children) {
                if (child.IsLeaf && !child.IsCriteriaMatched(criteria)) {
                    child.IsMatch = false;
                }
                CheckChildren(criteria, child);
            }
        }

        public void ApplyCriteria(string criteria, Stack<TreeNodeViewModel> ancestors) {
            if (IsCriteriaMatched(criteria)) {
                IsMatch = true;
                foreach (var ancestor in ancestors) {
                    ancestor.IsMatch = true;
                    ancestor.IsExpanded = true; // !String.IsNullOrEmpty(criteria);
                    CheckChildren(criteria, ancestor);
                }
                IsExpanded = true;
            } 
            else 
                IsMatch = false;

            ancestors.Push(this);
            foreach (var child in Children)
                child.ApplyCriteria(criteria, ancestors);

            ancestors.Pop();
        }

        public IEnumerable<TreeNodeViewModel> Children {
            get { return children; }
        }

        public string Name {
            get { return name; }
        }

        public bool IsExpanded {
            get { return expanded; }
            set {
                if (value == expanded)
                    return;

                expanded = value;
                if (expanded) {
                    foreach (var child in Children)
                        child.IsMatch = true;
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        public bool IsMatch {
            get { return match; }
            set {
                if (value == match)
                    return;

                match = value;
                OnPropertyChanged("IsMatch");
            }
        }

        public bool IsLeaf {
            get { return !Children.Any(); }
        }
    }
}
