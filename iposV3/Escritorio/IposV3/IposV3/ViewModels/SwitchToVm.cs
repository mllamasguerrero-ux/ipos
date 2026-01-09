using System;

namespace StudentsManager.ViewModels {
    public class SwitchToVm {
        public Type ViewModel { get; private set; }

        public SwitchToVm(Type viewModel) {
            ViewModel = viewModel;
        }
    }
}